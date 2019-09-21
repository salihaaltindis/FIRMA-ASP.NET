using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIRMA_ASPNET.Admin
{
    public partial class Marka : System.Web.UI.Page
    {
        FIRMAEntities db = new FIRMAEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.MARKAs.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int refno = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            MARKA k = db.MARKAs.Find(refno);

            if (k != null)
            {
                txtMARKA_ADI.Text = k.MARKA_ADI;
                txtMARKA_REFNO.Text = k.MARKA_REFNO.ToString();

            }
            //kayıt panelini ac liste panelini kapat
            pnlMarkaKayit.Visible = true;
            pnlMarkaListe.Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;//tıklanılan sayfa
            GridView1.DataSource = db.MARKAs.Where(k => k.MARKA_ADI.Contains(txtMarkaAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //kaydet
            if (txtMARKA_REFNO.Text != "") //ekranda kayıt varsa
            {
                int refno = Convert.ToInt32(txtMARKA_REFNO.Text);
                MARKA k = db.MARKAs.Find(refno);
                k.MARKA_ADI = txtMARKA_ADI.Text;
                k.MARKA_REFNO = Convert.ToInt32(txtMARKA_REFNO.Text);

                db.SaveChanges();
            }
            else
            {
                MARKA k = new MARKA();
                k.MARKA_ADI = txtMARKA_ADI.Text;
                db.MARKAs.Add(k);//yeni kayıt dbset e ekleniyor.
                db.SaveChanges();
            }
            //degisikliklerin ekrana yansıtılması için
            GridView1.DataSource = db.MARKAs.ToList();
            GridView1.DataBind();
            //kaydet i kapat listeyi ac
            pnlMarkaKayit.Visible = false;
            pnlMarkaListe.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //vazgec
            GridView1.DataSource = db.MARKAs.ToList();
            GridView1.DataBind();
            pnlMarkaKayit.Visible = false;
            pnlMarkaListe.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //sil
            if (txtMARKA_REFNO.Text != "")
            {
                int refno = Convert.ToInt32(txtMARKA_REFNO.Text);
                MARKA k = db.MARKAs.Find(refno);

                db.MARKAs.Remove(k);

                db.SaveChanges();

                GridView1.DataSource = db.MARKAs.ToList();
                GridView1.DataBind();
                pnlMarkaKayit.Visible = false;
                pnlMarkaListe.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //yeni
            txtMARKA_ADI.Text = "";
            txtMARKA_REFNO.Text = "";


            //kayıt panelini ac liste panelini kapat
            pnlMarkaKayit.Visible = true;
            pnlMarkaListe.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ara
            GridView1.DataSource = db.MARKAs.Where(k => k.MARKA_ADI.Contains(txtMarkaAra.Text)).ToList();
            GridView1.DataBind();
        }
    }
}