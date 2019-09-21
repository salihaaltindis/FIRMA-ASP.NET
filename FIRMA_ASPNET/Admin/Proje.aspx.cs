using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIRMA_ASPNET.Admin
{
    public partial class Proje : System.Web.UI.Page
    {
        FIRMAEntities db = new FIRMAEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.PROJEs.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int refno = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            PROJE k = db.PROJEs.Find(refno);

            if (k != null)
            {

                txtACIKLAMA.Text = k.ACIKLAMA;
                txtADI.Text = k.ADI;
                txtPROJE_REFNO.Text = k.PROJE_REFNO.ToString();
                //fuRESIM

            }
            //kayıt panelini ac liste panelini kapat
            pnlProjeKayit.Visible = true;
            pnlProjeListe.Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;//tıklanılan sayfa
            GridView1.DataSource = db.PROJEs.Where(k => k.ADI.Contains(txtProjeAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //vazgec
            GridView1.DataSource = db.PROJEs.ToList();
            GridView1.DataBind();
            pnlProjeKayit.Visible = false;
            pnlProjeListe.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //sil
            if (txtPROJE_REFNO.Text != "")
            {
                int refno = Convert.ToInt32(txtPROJE_REFNO.Text);
                PROJE k = db.PROJEs.Find(refno);

                db.PROJEs.Remove(k);

                db.SaveChanges();

                GridView1.DataSource = db.PROJEs.ToList();
                GridView1.DataBind();
                pnlProjeKayit.Visible = false;
                pnlProjeListe.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //yeni
            //fuRESIM1
            txtACIKLAMA.Text = "";
            txtADI.Text = "";
            txtPROJE_REFNO.Text = "";


            //kayıt panelini ac liste panelini kapat
            pnlProjeKayit.Visible = true;
            pnlProjeListe.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ara
            GridView1.DataSource = db.PROJEs.Where(k => k.ADI.Contains(txtProjeAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //kaydet
            if (txtPROJE_REFNO.Text != "") //ekranda kayıt varsa
            {
                int refno = Convert.ToInt32(txtPROJE_REFNO.Text);
                PROJE k = db.PROJEs.Find(refno);

                k.PROJE_REFNO = Convert.ToInt32(txtPROJE_REFNO.Text);
                k.ADI = txtADI.Text;
                k.ACIKLAMA = HttpUtility.HtmlDecode(txtACIKLAMA.Text);
                k.RESIM = fuRESIM.FileName;



                if ( (fuRESIM.PostedFile != null) && (fuRESIM.PostedFile.ContentLength > 0))
                {

                    string SaveLocation = Server.MapPath("Images/" + fuRESIM.FileName);
                   
                    try
                    {
                        fuRESIM.PostedFile.SaveAs(SaveLocation);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                db.SaveChanges();
            }
            else
            {
                PROJE k = new PROJE();
                
                k.ADI = txtADI.Text;
                k.ACIKLAMA = HttpUtility.HtmlDecode(txtACIKLAMA.Text);
                k.RESIM = fuRESIM.FileName;



                if ((fuRESIM.PostedFile != null) && (fuRESIM.PostedFile.ContentLength > 0))
                {

                    string SaveLocation = Server.MapPath("Images/" + fuRESIM.FileName);

                    try
                    {
                        fuRESIM.PostedFile.SaveAs(SaveLocation);
                    }
                    catch (Exception ex)
                    {

                    }
                }


                db.PROJEs.Add(k);//yeni kayıt dbset e ekleniyor.
                db.SaveChanges();
            }
            //degisikliklerin ekrana yansıtılması için
            GridView1.DataSource = db.PROJEs.ToList();
            GridView1.DataBind();
            //kaydet i kapat listeyi ac
            pnlProjeKayit.Visible = false;
            pnlProjeListe.Visible = true;
        }
    }
}