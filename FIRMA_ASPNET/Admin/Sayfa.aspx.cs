using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIRMA_ASPNET.Admin
{
    public partial class Sayfa : System.Web.UI.Page
    {

        FIRMAEntities db = new FIRMAEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.SAYFAs.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int refno = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            SAYFA k = db.SAYFAs.Find(refno);

            if (k != null)
            {
                //txtICERIK.Text = HttpUtility.HtmlDecode(k.ICERIK);
                txtICERIK.Text = k.ICERIK;
                txtBASLIK.Text = k.BASLIK;
                txtSAYFA_REFNO.Text = k.SAYFA_REFNO.ToString();

            }
            //kayıt panelini ac liste panelini kapat
            pnlSayfaKayit.Visible = true;
            pnlSayfaListele.Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;//tıklanılan sayfa
            GridView1.DataSource = db.SAYFAs.Where(k => k.BASLIK.Contains(txtSayfaAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //vazgec
            GridView1.DataSource = db.SAYFAs.ToList();
            GridView1.DataBind();
            pnlSayfaKayit.Visible = false;
            pnlSayfaListele.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //sil
            if (txtSAYFA_REFNO.Text != "")
            {
                int refno = Convert.ToInt32(txtSAYFA_REFNO.Text);
                SAYFA k = db.SAYFAs.Find(refno);

                db.SAYFAs.Remove(k);

                db.SaveChanges();

                GridView1.DataSource = db.SAYFAs.ToList();
                GridView1.DataBind();
                pnlSayfaKayit.Visible = false;
                pnlSayfaListele.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //yeni
            txtBASLIK.Text = "";
            txtICERIK.Text = "";
            txtSAYFA_REFNO.Text = "";


            //kayıt panelini ac liste panelini kapat
            pnlSayfaKayit.Visible = true;
            pnlSayfaListele.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ara
            GridView1.DataSource = db.SAYFAs.Where(k => k.BASLIK.Contains(txtSayfaAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //kaydet
            if (txtSAYFA_REFNO.Text != "") //ekranda kayıt varsa
            {
                int refno = Convert.ToInt32(txtSAYFA_REFNO.Text);
                SAYFA k = db.SAYFAs.Find(refno);
                k.BASLIK = txtBASLIK.Text;
                k.ICERIK = HttpUtility.HtmlDecode(txtICERIK.Text);
                k.SAYFA_REFNO = Convert.ToInt32(txtSAYFA_REFNO.Text);

                db.SaveChanges();
            }
            else
            {
                SAYFA k = new SAYFA();
                k.BASLIK = txtBASLIK.Text;
                k.ICERIK = HttpUtility.HtmlDecode(txtICERIK.Text);
                db.SAYFAs.Add(k);//yeni kayıt dbset e ekleniyor.
                db.SaveChanges();
            }
            //degisikliklerin ekrana yansıtılması için
            GridView1.DataSource = db.SAYFAs.ToList();
            GridView1.DataBind();
            //kaydet i kapat listeyi ac
            pnlSayfaKayit.Visible = false;
            pnlSayfaListele.Visible = true;
        }


    }
}