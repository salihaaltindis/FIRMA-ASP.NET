using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FIRMA_ASPNET.Admin
{
    public partial class Giris : System.Web.UI.Page
    {
        FIRMAEntities db = new FIRMAEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            //giriş yap
            KULLANICI k = db.KULLANICIs.Where(k1 => k1.KULLANICI_ADI == txtKULLANICIADI.Text && k1.PAROLA == txtPAROLA.Text).SingleOrDefault();
            //hiç kayıt gelmezse null atar. tek kayıt geleceginden eminsek
            if (k != null)
            {
                Session["GIRIS_YETKI"] = true;
                Response.Redirect("Kullanici.aspx");
            }
            else
            {
                Session["GIRIS_YETKI"] = false;
            }
        }
    }
}
