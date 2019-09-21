using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIRMA_ASPNET.Admin
{
    public partial class Urun : System.Web.UI.Page
    {
        FIRMAEntities db = new FIRMAEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            fuRESIM1.Width = 50;
            fuRESIM1.Height = 70;

            GridView1.DataSource = db.VW_URUN_MARKA_KATEGORI.ToList();
            GridView1.DataBind();

            if (IsPostBack == false)
            {
                ddlKATEGORI_ADI.DataSource = db.KATEGORIs.ToList();
                ddlKATEGORI_ADI.DataTextField = "KATEGORI_ADI";
                ddlKATEGORI_ADI.DataValueField = "KATEGORI_REFNO";
                ddlKATEGORI_ADI.DataBind();

                ddlMARKA_ADI.DataSource = db.MARKAs.ToList();
                ddlMARKA_ADI.DataTextField = "MARKA_ADI";
                ddlMARKA_ADI.DataValueField = "MARKA_REFNO";
                ddlMARKA_ADI.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int refno = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            URUN k = db.URUNs.Find(refno);

            if (k != null)
            {
                txtURUN_REFNO.Text = k.URUN_REFNO.ToString();
                txtURUN_ADI.Text = k.URUN_ADI;
                txtKDV_ORANI.Text = k.KDV_ORANI.ToString();
                txtFIYATI.Text = k.FIYATI.ToString();
                ddlDURUMU.SelectedValue = k.DURUMU.ToString();
                ddlKATEGORI_ADI.SelectedValue = k.KATEGORI_REFNO.ToString();
                ddlMARKA_ADI.SelectedValue = k.MARKA_REFNO.ToString();
                // txtACIKLAMA.Text = HttpUtility.HtmlDecode(k.ACIKLAMA);
                txtACIKLAMA.Text = k.ACIKLAMA;
                //fuRESIM1


            }
            //kayıt panelini ac liste panelini kapat
            pnlUrunKayit.Visible = true;
            pnlUrunListe.Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;//tıklanılan sayfa
            GridView1.DataSource = db.VW_URUN_MARKA_KATEGORI.Where(k => k.URUN_ADI.Contains(txtUrunAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //vazgec
            GridView1.DataSource = db.VW_URUN_MARKA_KATEGORI.ToList();
            GridView1.DataBind();
            pnlUrunKayit.Visible = false;
            pnlUrunListe.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //sil
            if (txtURUN_REFNO.Text != "")
            {
                int refno = Convert.ToInt32(txtURUN_REFNO.Text);
                URUN k = db.URUNs.Find(refno);

                db.URUNs.Remove(k);

                db.SaveChanges();

                GridView1.DataSource = db.VW_URUN_MARKA_KATEGORI.ToList();
                GridView1.DataBind();
                pnlUrunKayit.Visible = false;
                pnlUrunListe.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //yeni
            txtURUN_REFNO.Text = "";
            txtURUN_ADI.Text = "";
            txtKDV_ORANI.Text = "";
            txtFIYATI.Text = "";
            txtACIKLAMA.Text = "";
            //fuRESIM1

            //kayıt panelini ac liste panelini kapat
            pnlUrunKayit.Visible = true;
            pnlUrunListe.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ara
            GridView1.DataSource = db.VW_URUN_MARKA_KATEGORI.Where(k => k.URUN_ADI.Contains(txtUrunAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //kaydet
            if (txtURUN_REFNO.Text != "") //ekranda kayıt varsa
            {
                int refno = Convert.ToInt32(txtURUN_REFNO.Text);
                URUN k = db.URUNs.Find(refno);

                k.URUN_REFNO = Convert.ToInt32(txtURUN_REFNO.Text);
                k.URUN_ADI = txtURUN_ADI.Text;
                k.KDV_ORANI = Convert.ToInt32(txtKDV_ORANI.Text);
                k.FIYATI = Convert.ToDecimal(txtFIYATI.Text);
                k.DURUMU = Convert.ToBoolean(ddlDURUMU.SelectedValue);
                k.KATEGORI_REFNO = Convert.ToInt32(ddlKATEGORI_ADI.SelectedValue);
                k.MARKA_REFNO = Convert.ToInt32(ddlMARKA_ADI.SelectedValue);
                k.ACIKLAMA= HttpUtility.HtmlDecode(txtACIKLAMA.Text);
                k.RESIM1 = fuRESIM1.FileName;
                k.RESIM2 = fuRESIM2.FileName;
                k.RESIM3 = fuRESIM3.FileName;
                k.RESIM4 = fuRESIM4.FileName;


                if ((fuRESIM1.PostedFile != null) && (fuRESIM1.PostedFile.ContentLength > 0) || (fuRESIM2.PostedFile != null) && (fuRESIM2.PostedFile.ContentLength > 0) || (fuRESIM3.PostedFile != null) && (fuRESIM3.PostedFile.ContentLength > 0) || (fuRESIM4.PostedFile != null) && (fuRESIM4.PostedFile.ContentLength > 0))
                {

                    string SaveLocation = Server.MapPath("Images/" + fuRESIM1.FileName);
                    string SaveLocation2 = Server.MapPath("Images/" + fuRESIM2.FileName);
                    string SaveLocation3 = Server.MapPath("Images/" + fuRESIM3.FileName);
                    string SaveLocation4 = Server.MapPath("Images/" + fuRESIM4.FileName);
                    try
                    {
                        fuRESIM1.PostedFile.SaveAs(SaveLocation);
                        fuRESIM2.PostedFile.SaveAs(SaveLocation2);
                        fuRESIM3.PostedFile.SaveAs(SaveLocation3);
                        fuRESIM4.PostedFile.SaveAs(SaveLocation4);

                    }
                    catch (Exception ex)
                    {

                    }
                }
                db.SaveChanges();
            }
            else
            {
                URUN k = new URUN();
                k.URUN_ADI = txtURUN_ADI.Text;
                k.KDV_ORANI = Convert.ToInt32(txtKDV_ORANI.Text);
                k.FIYATI = Convert.ToDecimal(txtFIYATI.Text);
                k.DURUMU = Convert.ToBoolean(ddlDURUMU.SelectedValue);
                k.KATEGORI_REFNO = Convert.ToInt32(ddlKATEGORI_ADI.SelectedValue);
                k.MARKA_REFNO = Convert.ToInt32(ddlMARKA_ADI.SelectedValue);
                k.ACIKLAMA = HttpUtility.HtmlDecode(k.ACIKLAMA);
                k.RESIM1 = fuRESIM1.FileName;
                k.RESIM2 = fuRESIM2.FileName;
                k.RESIM3 = fuRESIM3.FileName;
                k.RESIM4 = fuRESIM4.FileName;

                if ((fuRESIM1.PostedFile != null) && (fuRESIM1.PostedFile.ContentLength > 0) || (fuRESIM2.PostedFile != null) && (fuRESIM2.PostedFile.ContentLength > 0) || (fuRESIM3.PostedFile != null) && (fuRESIM3.PostedFile.ContentLength > 0) || (fuRESIM4.PostedFile != null) && (fuRESIM4.PostedFile.ContentLength > 0))
                {

                    string SaveLocation = Server.MapPath("Images/" + fuRESIM1.FileName);
                    string SaveLocation2 = Server.MapPath("Images/" + fuRESIM2.FileName);
                    string SaveLocation3 = Server.MapPath("Images/" + fuRESIM3.FileName);
                    string SaveLocation4 = Server.MapPath("Images/" + fuRESIM4.FileName);
                    try
                    {
                        fuRESIM1.PostedFile.SaveAs(SaveLocation);
                        fuRESIM2.PostedFile.SaveAs(SaveLocation2);
                        fuRESIM3.PostedFile.SaveAs(SaveLocation3);
                        fuRESIM4.PostedFile.SaveAs(SaveLocation4);

                    }
                    catch (Exception ex)
                    {

                    }
                }


                db.URUNs.Add(k);//yeni kayıt dbset e ekleniyor.
                db.SaveChanges();
            }
            //degisikliklerin ekrana yansıtılması için
            GridView1.DataSource = db.VW_URUN_MARKA_KATEGORI.ToList();
            GridView1.DataBind();
            //kaydet i kapat listeyi ac
            pnlUrunKayit.Visible = false;
            pnlUrunListe.Visible = true;
        }
    }
}