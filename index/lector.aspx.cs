using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Logica;

namespace index
{
    public partial class lector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {

                if (Session["Anterior"] != null)
                {



                    if ((int)Session["Anterior"] == 1)
                    {

                        string[] datos = Session["Datos"].ToString().Split('╝');
                        Session["Contenido_Wiris"] = Session["Contenido_Corregido_Wiris"].ToString();
                        Titulo.Text = Session["Titulo"].ToString();
                        DropDownList_Institucion.SelectedValue = Session["DropDownList_Institucion"].ToString();
                        DropDownList_Tipo.SelectedValue = Session["DropDownList_Tipo"].ToString();
                        Ubicacion_De_Impresion.Text = Session["Ubicacion_De_Impresion"].ToString();
                        Ubicacion_Del_Ejercicio.Text = Session["Ubicacion_Del_Ejercicio"].ToString();
                        Ubicacion_Del_Video_Y_Explicacion.Text = Session["Ubicacion_Del_Video_Y_Explicacion"].ToString();
                        DropDownList_Enunciado_Realizado.SelectedValue = Session["DropDownList_Enunciado_Realizado"].ToString();
                        Session["Siguiente"] = 1;

                    }

                    if ((int)Session["Anterior"] == 2)
                    {
                        Session["Siguiente"] = null;
                        Titulo.Text = string.Empty;
                        Session["Contenido_Wiris"] = null;
                        Contenido_Wiris.Value = null;
                        Session["Anterior"] = null;
                    }


                }
                else
                {

                    Session["Siguiente"] = null;


                }

            }
        }

        protected void Cargar_Ejercicio_Click(object sender, EventArgs e)
        {
            if (Subir_Ejercicio.HasFile == false)
            {
                return;
            }
           
            Session["fileName"] = Subir_Ejercicio.FileName;

            try
            {
                string Identificadora = (((string)Session["fileName"]).Substring(9));
                int Identificador = int.Parse(Identificadora.Substring(0, Identificadora.Length - 4));
                Session["ID"] = Identificador;
            }

            catch 
            {
                return;
            }


            string filename = Path.Combine(Server.MapPath("~/corregido"), (string)Session["fileName"]);
            Subir_Ejercicio.SaveAs(filename);
            StreamReader file = new StreamReader(filename, System.Text.Encoding.UTF8);
            string texto;
            texto = file.ReadToEnd();
            file.Close();
            Session["Datos"] = texto;
            string[] datos = Session["Datos"].ToString().Split('╝');            
            Session["Contenido_Wiris"] = datos[0];
            Session["Titulo"] = datos[2];
            DropDownList_Institucion.SelectedValue = datos[3].ToString();
            DropDownList_Tipo.SelectedValue = datos[4].ToString();
            Ubicacion_De_Impresion.Text = datos[5];
            Ubicacion_Del_Ejercicio.Text = datos[6];
            Ubicacion_Del_Video_Y_Explicacion.Text = datos[7];
            DropDownList_Enunciado_Realizado.SelectedValue = datos[8].ToString();
            Session["Nombre_Del_Archivo"] = Subir_Ejercicio.FileName.Substring(0, 9) + " " +  Subir_Ejercicio.FileName.Substring(9, Subir_Ejercicio.FileName.Length - 13);
            Titulo.Text = datos[2];

        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {

            if (Session["fileName"] == null)
            {
                return;
            }

            Session["Contenido_Wiris"] = Contenido_Wiris.Value;

            if (Titulo.Text == string.Empty)
            {
                string Fallo = @"<script type='text/javascript'>   
                                   alert('No puede quedar la caja del título vacio');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Fallo, false);
                return;
            }

            

            if (DropDownList_Tipo.SelectedValue == "3" || DropDownList_Tipo.SelectedValue == "2")
            {
                DropDownList_Enunciado_Realizado.SelectedValue = "false";
                Ubicacion_De_Impresion.Text = string.Empty;
                Ubicacion_Del_Ejercicio.Text = string.Empty;
            }
                        
            if (DropDownList_Tipo.SelectedValue == "1")
            {
                Ubicacion_Del_Video_Y_Explicacion.Text = null;
            }

            if ((DropDownList_Enunciado_Realizado.SelectedValue == "true" || DropDownList_Tipo.SelectedValue == "3") && Ubicacion_Del_Video_Y_Explicacion.Text == string.Empty)
            {
                string Fallo = @"<script type='text/javascript'>   
                                   alert('No puede en este caso dejar la respuesta de video vacio');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Fallo, false);
                return;
            }

            Session["Anterior"] = 1;
            Session["Titulo"] = Titulo.Text;
            Session["Ubicacion_Del_Video_Y_Explicacion"] = Ubicacion_Del_Video_Y_Explicacion.Text;
            Session["DropDownList_Tipo"] = int.Parse(DropDownList_Tipo.SelectedValue);
            Session["DropDownList_Institucion"] = int.Parse(DropDownList_Institucion.SelectedValue);
            Session["DropDownList_Enunciado_Realizado"] = DropDownList_Enunciado_Realizado.SelectedValue;
            Session["Ubicacion_De_Impresion"] = Ubicacion_De_Impresion.Text;
            Session["Ubicacion_Del_Ejercicio"] = Ubicacion_Del_Ejercicio.Text;
            Session["Contenido_Corregido_Wiris"] = Contenido_Wiris.Value;

            
            Response.Redirect("lector1.aspx");
        }
    }
}