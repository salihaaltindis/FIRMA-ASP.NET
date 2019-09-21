using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIRMA_ASPNET.Admin
{
    public partial class Kategori : System.Web.UI.Page
    {
        FIRMAEntities db = new FIRMAEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.KATEGORIs.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int refno = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            KATEGORI k = db.KATEGORIs.Find(refno);

            if (k != null)
            {
                txtKATEGORI_ADI.Text = k.KATEGORI_ADI;
                txtKATEGORI_REFNO.Text = k.KATEGORI_REFNO.ToString();

            }
            //kayıt panelini ac liste panelini kapat
            pnlKategoriKayit.Visible = true;
            pnlKategoriListe.Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;//tıklanılan sayfa
            GridView1.DataSource = db.KATEGORIs.Where(k => k.KATEGORI_ADI.Contains(txtKategoriAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //kaydet
            if (txtKATEGORI_REFNO.Text != "") //ekranda kayıt varsa
            {
                int refno = Convert.ToInt32(txtKATEGORI_REFNO.Text);
                KATEGORI k = db.KATEGORIs.Find(refno);
                k.KATEGORI_ADI = txtKATEGORI_ADI.Text;
                k.KATEGORI_REFNO = Convert.ToInt32(txtKATEGORI_REFNO.Text);

                db.SaveChanges();
            }
            else
            {
                KATEGORI k = new KATEGORI();
                k.KATEGORI_ADI = txtKATEGORI_ADI.Text;
                db.KATEGORIs.Add(k);//yeni kayıt dbset e ekleniyor.
                db.SaveChanges();
            }
            //degisikliklerin ekrana yansıtılması için
            GridView1.DataSource = db.KATEGORIs.ToList();
            GridView1.DataBind();
            //kaydet i kapat listeyi ac
            pnlKategoriKayit.Visible = false;
            pnlKategoriListe.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //vazgec
            GridView1.DataSource = db.KATEGORIs.ToList();
            GridView1.DataBind();
            pnlKategoriKayit.Visible = false;
            pnlKategoriListe.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //sil
            if (txtKATEGORI_REFNO.Text != "")
            {
                int refno = Convert.ToInt32(txtKATEGORI_REFNO.Text);
                KATEGORI k = db.KATEGORIs.Find(refno);

                db.KATEGORIs.Remove(k);

                db.SaveChanges();

                GridView1.DataSource = db.KATEGORIs.ToList();
                GridView1.DataBind();
                pnlKategoriKayit.Visible = false;
                pnlKategoriListe.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //yeni
            txtKATEGORI_ADI.Text = "";
            txtKATEGORI_REFNO.Text = "";


            //kayıt panelini ac liste panelini kapat
            pnlKategoriKayit.Visible = true;
            pnlKategoriListe.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ara
            GridView1.DataSource = db.KATEGORIs.Where(k => k.KATEGORI_ADI.Contains(txtKategoriAra.Text)).ToList();
            GridView1.DataBind();
        }

    }
}