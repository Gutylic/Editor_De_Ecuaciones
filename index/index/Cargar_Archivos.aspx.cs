using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace index
{
    public partial class Cargar_Archivos : System.Web.UI.Page
    {

        Logica_Cargar_Archivo LAC = new Logica_Cargar_Archivo();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Boton_Cargar_Click(object sender, EventArgs e)
        {
            
            if (LAC.Analizar_Existencia_Ejercicio(int.Parse(TextBox_Numero_De_Ejercicio.Text)) != 1)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('No existe el ejercicio a cargar, verifique el número');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }

            if (!FileUpload_Enunciado.HasFile)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('Es obligatorio cargar un archivo con el enunciado');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }

            if (!FileUpload_Ficha.HasFile)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('Es obligatorio cargar un archivo con la ficha del ejercicio');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }


            List<Obtener_Ubicacion_De_RespuestasResult> Datos = LAC.Obtener_Ubicacion_Respuesta(int.Parse(TextBox_Numero_De_Ejercicio.Text));

            if (Datos[0].ID_Tipo_De_Ejercicio == 1)
            {

                if (!FileUpload_Respuesta_Imprimible.HasFile)
                {
                    string Mensaje = @"<script type='text/javascript'>   
                                   alert('Es obligatorio cargar un archivo con la respuesta imprimible');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                    return;
                }

                if (!FileUpload_Respuesta_Visible.HasFile)
                {
                    string Mensaje = @"<script type='text/javascript'>   
                                   alert('Es obligatorio cargar un archivo con la respuesta visible');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                    return;
                }

                FileUpload_Enunciado.SaveAs(Server.MapPath("enunciado\\Enunciado" + TextBox_Numero_De_Ejercicio.Text + ".png"));
                FileUpload_Enunciado.SaveAs(@"c:\enunciado\\Enunciado" + TextBox_Numero_De_Ejercicio.Text + ".png");
                FileUpload_Ficha.SaveAs(@"c:\ficha\Ficha" + TextBox_Numero_De_Ejercicio.Text + ".png");
                FileUpload_Respuesta_Imprimible.SaveAs(Server.MapPath("respuesta_imprimible\\" + Datos[0].Ubicacion_Respuesta_Imprimible + ".png"));
                FileUpload_Respuesta_Imprimible.SaveAs(@"c:\respuesta_imprimible\\" + Datos[0].Ubicacion_Respuesta_Imprimible + ".png");
                FileUpload_Respuesta_Visible.SaveAs(@"c:\respuesta_visible\\" + Datos[0].Ubicacion_Respuesta_Visible + ".png");
                string OK = @"<script type='text/javascript'>   
                                   alert('Los archivos ya fueron cargados');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", OK, false);
                return;
                
            }

            if (Datos[0].ID_Tipo_De_Ejercicio == 3)
            {

                if (FileUpload_Respuesta_Imprimible.HasFile)
                {
                    string Mensaje = @"<script type='text/javascript'>   
                                   alert('No debe cargar un archivo con la respuesta imprimible, en un video');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                    return;
                }

                if (FileUpload_Respuesta_Visible.HasFile)
                {
                    string Mensaje = @"<script type='text/javascript'>   
                                   alert('No debe cargar un archivo con la respuesta imprimible, en un video');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                    return;
                }

                FileUpload_Enunciado.SaveAs(Server.MapPath("enunciado\\Enunciado" + TextBox_Numero_De_Ejercicio.Text + ".png"));
                FileUpload_Enunciado.SaveAs(@"c:\enunciado\\Enunciado" + TextBox_Numero_De_Ejercicio.Text + ".png");
                FileUpload_Ficha.SaveAs(@"c:\ficha\Ficha" + TextBox_Numero_De_Ejercicio.Text + ".png");                
                string OK = @"<script type='text/javascript'>   
                                   alert('Los archivos ya fueron cargados');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", OK, false);
                return;

            }

            
        }
    }
}