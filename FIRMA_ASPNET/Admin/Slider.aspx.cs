using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIRMA_ASPNET.Admin
{
    public partial class Slider : System.Web.UI.Page
    {
        FIRMAEntities db = new FIRMAEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.SLIDERs.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int refno = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            SLIDER k = db.SLIDERs.Find(refno);

            if (k != null)
            {
                //fuRESIM
                ddlDURUMU.SelectedValue = k.DURUMU.ToString();
                txtLINK.Text = k.LINK;
                txtBASLIK.Text = k.BASLIK;
                txtSLIDER_REFNO.Text = k.SLIDER_REFNO.ToString();

            }
            //kayıt panelini ac liste panelini kapat
            pnlSliderKayit.Visible = true;
            pnlSliderListe.Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;//tıklanılan sayfa
            GridView1.DataSource = db.SLIDERs.Where(k => k.BASLIK.Contains(txtSliderAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //vazgec
            GridView1.DataSource = db.SLIDERs.ToList();
            GridView1.DataBind();
            pnlSliderKayit.Visible = false;
            pnlSliderListe.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //sil
            if (txtSLIDER_REFNO.Text != "")
            {
                int refno = Convert.ToInt32(txtSLIDER_REFNO.Text);
                SLIDER k = db.SLIDERs.Find(refno);

                db.SLIDERs.Remove(k);

                db.SaveChanges();

                GridView1.DataSource = db.SLIDERs.ToList();
                GridView1.DataBind();
                pnlSliderKayit.Visible = false;
                pnlSliderListe.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //yeni
            txtBASLIK.Text = "";
            txtLINK.Text = "";
            //fuRESIM
            txtSLIDER_REFNO.Text = "";


            //kayıt panelini ac liste panelini kapat
            pnlSliderKayit.Visible = true;
            pnlSliderListe.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ara
            GridView1.DataSource = db.SLIDERs.Where(k => k.BASLIK.Contains(txtSliderAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //kaydet
            if (txtSLIDER_REFNO.Text != "") //ekranda kayıt varsa
            {
                int refno = Convert.ToInt32(txtSLIDER_REFNO.Text);
                SLIDER k = db.SLIDERs.Find(refno);

                k.SLIDER_REFNO = Convert.ToInt32(txtSLIDER_REFNO.Text);
                k.BASLIK = txtBASLIK.Text;
                k.DURUMU = Convert.ToBoolean(ddlDURUMU.SelectedValue);
                k.LINK = txtLINK.Text;
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
                db.SaveChanges();
            }
            else
            {
                SLIDER k = new SLIDER();
                k.SLIDER_REFNO = Convert.ToInt32(txtSLIDER_REFNO.Text);
                k.BASLIK = txtBASLIK.Text;
                k.DURUMU = Convert.ToBoolean(ddlDURUMU.SelectedValue);
                k.LINK = txtLINK.Text;
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


                db.SLIDERs.Add(k);//yeni kayıt dbset e ekleniyor.
                db.SaveChanges();
            }
            //degisikliklerin ekrana yansıtılması için
            GridView1.DataSource = db.SLIDERs.ToList();
            GridView1.DataBind();
            //kaydet i kapat listeyi ac
            pnlSliderKayit.Visible = false;
            pnlSliderListe.Visible = true;
        
    }
    }
}