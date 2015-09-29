using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace index
{
    public partial class index : System.Web.UI.Page
    {

        Logica_Editor_De_Ecuaciones LEDE = new Logica_Editor_De_Ecuaciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Session["Anterior"] != null)
            {
                Titulo.Text =(string) Session["Titulo"];
                Ubicacion_Del_Video_Y_Explicacion.Text = (string)Session["Ubicacion_Del_Video_Y_Explicacion"];
                DropDownList_Tipo.SelectedValue = Session["DropDownList_Tipo"].ToString();
                DropDownList_Institucion.SelectedValue = Session["DropDownList_Institucion"].ToString();
                DropDownList_Enunciado_Realizado.SelectedValue = Session["DropDownList_Enunciado_Realizado"].ToString();
            }
          
        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            Session["Contenido_Wiris"] = Contenido_Wiris.Value;
            if (Titulo.Text == string.Empty)
            { 
                string Fallo = @"<script type='text/javascript'>   
                                   alert('No puede dejar la caja de título vacio');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Fallo, false);
                    return;
            }

            
            Session["Titulo"] = Titulo.Text;
            Session["Ubicacion_Del_Video_Y_Explicacion"] = Ubicacion_Del_Video_Y_Explicacion.Text;
            Session["DropDownList_Tipo"] = int.Parse(DropDownList_Tipo.SelectedValue);
            Session["DropDownList_Institucion"] = int.Parse(DropDownList_Institucion.SelectedValue);
            Session["DropDownList_Enunciado_Realizado"] = DropDownList_Enunciado_Realizado.SelectedValue;

            if (DropDownList_Tipo.SelectedValue == "3" || DropDownList_Tipo.SelectedValue == "2")
            {
                DropDownList_Enunciado_Realizado.SelectedValue = "false";
            }

            if (DropDownList_Tipo.SelectedValue == "1")
            {
                Ubicacion_Del_Video_Y_Explicacion.Text = null;
            }

            if ((DropDownList_Enunciado_Realizado.SelectedValue == "true" || DropDownList_Tipo.SelectedValue == "3") && Ubicacion_Del_Video_Y_Explicacion.Text == string.Empty )
            {
                string Fallo = @"<script type='text/javascript'>   
                                   alert('No puede dejar la caja de texto de respuesta de videos vacio');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Fallo, false);
                return;         
            }


            Response.Redirect("index1.aspx");

        }
    }
}