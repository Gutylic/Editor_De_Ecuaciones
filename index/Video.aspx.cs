using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index
{
    public partial class Video : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Boton_Click(object sender, EventArgs e)
        {
            if (TextBox_Videos.Text == string.Empty)
            {
                return;
            }


            string Cadena = @"window.open('buscar_videos.aspx?Videos=" + TextBox_Videos.Text.Trim().ToLower() + "','_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
        }
    }
}