using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIRMA_ASPNET.Admin
{
    public partial class Kullanici : System.Web.UI.Page
    {
        FIRMAEntities db = new FIRMAEntities();
        protected void Page_Load(object sender, EventArgs e)
        {


            ////her form için bunu yapacaz yada master page yazcaz
            //if (Session["GIRIS_YETKI"] == null)
            //{
            //    Response.Redirect("Giris.aspx");
            //}
            //else
            //{
            //    if (Convert.ToBoolean(Session["GIRIS_YETKI"]) == false)
            //    {
            //        Response.Redirect("Giris.aspx");
            //    }
            //}

            GridView1.DataSource = db.KULLANICIs.ToList();
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int refno = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            KULLANICI k = db.KULLANICIs.Find(refno);

            if (k != null)
            {
                txtKULLANICI_ADI.Text = k.KULLANICI_ADI;
                txtPAROLA.Text = k.PAROLA;
                txtKULLANICI_REFNO.Text = k.KULLANICI_REFNO.ToString();

            }
            //kayıt panelini ac liste panelini kapat
            pnlKullaniciKayit.Visible = true;
            pnlKullaniciListe.Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;//tıklanılan sayfa
            GridView1.DataSource = db.KULLANICIs.Where(k => k.KULLANICI_ADI.Contains(txtKullanıcıAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //vazgec
            GridView1.DataSource = db.KULLANICIs.ToList();
            GridView1.DataBind();
            pnlKullaniciKayit.Visible = false;
            pnlKullaniciListe.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //sil
            if (txtKULLANICI_REFNO.Text != "")
            {
                int refno = Convert.ToInt32(txtKULLANICI_REFNO.Text);
                KULLANICI k = db.KULLANICIs.Find(refno);

                db.KULLANICIs.Remove(k);

                db.SaveChanges();

                GridView1.DataSource = db.KULLANICIs.ToList();
                GridView1.DataBind();
                pnlKullaniciListe.Visible = false;
                pnlKullaniciListe.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //yeni
            txtKULLANICI_ADI.Text = "";
            txtPAROLA.Text = "";
            txtKULLANICI_REFNO.Text = "";


            //kayıt panelini ac liste panelini kapat
            pnlKullaniciKayit.Visible = true;
            pnlKullaniciListe.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ara
            GridView1.DataSource = db.KULLANICIs.Where(k => k.KULLANICI_ADI.Contains(txtKullanıcıAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //kaydet
            if (txtKULLANICI_REFNO.Text != "") //ekranda kayıt varsa
            {
                int refno = Convert.ToInt32(txtKULLANICI_REFNO.Text);
                KULLANICI k = db.KULLANICIs.Find(refno);

                k.KULLANICI_REFNO = Convert.ToInt32(txtKULLANICI_REFNO.Text);
                k.KULLANICI_ADI = txtKULLANICI_ADI.Text;
                k.PAROLA = txtPAROLA.Text;
              
                db.SaveChanges();
            }
            else
            {
                KULLANICI k = new KULLANICI();
                k.KULLANICI_ADI = txtKULLANICI_ADI.Text;
                k.PAROLA = txtPAROLA.Text;

                db.KULLANICIs.Add(k);//yeni kayıt dbset e ekleniyor.
                db.SaveChanges();
            }
            //degisikliklerin ekrana yansıtılması için
            GridView1.DataSource = db.KULLANICIs.ToList();
            GridView1.DataBind();
            //kaydet i kapat listeyi ac
            pnlKullaniciKayit.Visible = false;
            pnlKullaniciListe.Visible = true;

        }
    }
    }
