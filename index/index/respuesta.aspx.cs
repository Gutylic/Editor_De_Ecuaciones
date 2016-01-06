using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace index
{
    public partial class respuesta : System.Web.UI.Page
    {

        Logica_Respuestas LR = new Logica_Respuestas();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Boton_Respuesta_Click(object sender, EventArgs e)
        {

            if (TextBox_Respuesta.Text == string.Empty)
            {
                return;
            }

            List<Buscar_RespuestasResult> Datos = LR.Logica_Respuesta(int.Parse(TextBox_Respuesta.Text));

            try { 
                Respuesta_Del_Ejercicio.Visible = true;
                Respuesta_Del_Ejercicio.ImageUrl = "respuesta_imprimible/" + Datos[0].Ubicacion_Respuesta_Imprimible + ".png";
                return;

            }
            catch (Exception) {

                Respuesta_Del_Ejercicio.Visible = false;
                return; 
            }
           
           

           
        }
    }
}