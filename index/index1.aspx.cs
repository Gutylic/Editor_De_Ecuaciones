using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace index
{
    public partial class index1 : System.Web.UI.Page
    {

        Logica_Editor_De_Ecuaciones LEDE = new Logica_Editor_De_Ecuaciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
                if ((int)Session["Siguiente"] == 1)
                {
                
                    TextBox_Tema1_S.Text = (string)Session["Tema1_S"];
                    TextBox_Tema2_S.Text = (string)Session["Tema2_S"];
                    TextBox_Tema3_S.Text = (string)Session["Tema3_S"];

                    TextBox_Tema1.Text = (string)Session["Tema1"];
                    TextBox_Tema2.Text = (string)Session["Tema2"];
                    TextBox_Tema3.Text = (string)Session["Tema3"];

                    TextBox_Ano1.Text = (string)Session["Ano1"];
                    TextBox_Ano2.Text = (string)Session["Ano2"];
                    TextBox_Ano3.Text = (string)Session["Ano3"];

                    TextBox_Materia1.Text = (string)Session["Materia1"];
                    TextBox_Materia2.Text = (string)Session["Materia2"];
                    TextBox_Materia3.Text = (string)Session["Materia3"];

                    TextBox_Colegio1.Text = (string)Session["Colegio1"];
                    TextBox_Colegio2.Text = (string)Session["Colegio2"];
                    TextBox_Colegio3.Text = (string)Session["Colegio3"];

                    TextBox_Profesor1.Text = (string)Session["Profesor1"];
                    TextBox_Profesor2.Text = (string)Session["Profesor2"];
                    TextBox_Profesor3.Text = (string)Session["Profesor3"];
                }
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            Session["Tema1_S"] = TextBox_Tema1_S.Text;
            Session["Tema2_S"] = TextBox_Tema2_S.Text;
            Session["Tema3_S"] = TextBox_Tema3_S.Text;

            Session["Tema1"] = TextBox_Tema1.Text;
            Session["Tema2"] = TextBox_Tema2.Text;
            Session["Tema3"] = TextBox_Tema3.Text;

            Session["Ano1"] = TextBox_Ano1.Text;
            Session["Ano2"] = TextBox_Ano2.Text;
            Session["Ano3"] = TextBox_Ano3.Text;

            Session["Materia1"] = TextBox_Materia1.Text;
            Session["Materia2"] = TextBox_Materia2.Text;
            Session["Materia3"] = TextBox_Materia3.Text;

            Session["Colegio1"] = TextBox_Colegio1.Text;
            Session["Colegio2"] = TextBox_Colegio2.Text;
            Session["Colegio3"] = TextBox_Colegio3.Text;

            Session["Profesor1"] = TextBox_Profesor1.Text;
            Session["Profesor2"] = TextBox_Profesor2.Text;
            Session["Profesor3"] = TextBox_Profesor3.Text;
            
            Session["Anterior"] = 1;
            Response.Redirect("index.aspx");
        }

        protected void Cargar_Ejercicio_Click(object sender, EventArgs e)
        {
            Session.Remove("Anterior");
            Cargar_Ejercicio.Enabled = false;
            int Valor = LEDE.Insertar_En_Tabla_Primera_Parte((string)Session["Contenido_Wiris"],(string)Session["Titulo"],(string)Session["Ubicacion_Del_Video_Y_Explicacion"],(int)Session["DropDownList_Institucion"], (int)Session["DropDownList_Tipo"], (string)Session["DropDownList_Enunciado_Realizado"]);

            switch (Valor)
            {
                case 1:

                    string OK = @"<script type='text/javascript'>   
                                   alert('Se creo el ejercicio correctamente');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", OK, false);
                    break;

                case -6:

                    string Fallo = @"<script type='text/javascript'>   
                                   alert('No pudo crear el ejercicio pues no pudo conectarse a la base de datos');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Fallo, false);
                    break;
            }

            Session["Tema1_S"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1_S.Text,TextBox_Tema2_S.Text,TextBox_Tema3_S.Text).Valor_1;
            Session["Tema2_S"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1_S.Text, TextBox_Tema2_S.Text, TextBox_Tema3_S.Text).Valor_2;
            Session["Tema3_S"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1_S.Text, TextBox_Tema2_S.Text, TextBox_Tema3_S.Text).Valor_3;

            Session["Tema1"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1.Text, TextBox_Tema2.Text, TextBox_Tema3.Text).Valor_1;
            Session["Tema2"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1.Text, TextBox_Tema2.Text, TextBox_Tema3.Text).Valor_2;
            Session["Tema3"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1.Text, TextBox_Tema2.Text, TextBox_Tema3.Text).Valor_3;

            Session["Ano1"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Ano1.Text, TextBox_Ano2.Text, TextBox_Ano3.Text).Valor_1;
            Session["Ano2"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Ano1.Text, TextBox_Ano2.Text, TextBox_Ano3.Text).Valor_2;
            Session["Ano3"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Ano1.Text, TextBox_Ano2.Text, TextBox_Ano3.Text).Valor_3;

            Session["Materia1"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Materia1.Text, TextBox_Materia2.Text, TextBox_Materia3.Text).Valor_1;
            Session["Materia2"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Materia1.Text, TextBox_Materia2.Text, TextBox_Materia3.Text).Valor_2;
            Session["Materia3"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Materia1.Text, TextBox_Materia2.Text, TextBox_Materia3.Text).Valor_3;

            Session["Colegio1"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Colegio1.Text, TextBox_Colegio2.Text, TextBox_Colegio3.Text).Valor_1;
            Session["Colegio2"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Colegio1.Text, TextBox_Colegio2.Text, TextBox_Colegio3.Text).Valor_2;
            Session["Colegio3"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Colegio1.Text, TextBox_Colegio2.Text, TextBox_Colegio3.Text).Valor_3;

            Session["Profesor1"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Profesor1.Text, TextBox_Profesor2.Text, TextBox_Profesor3.Text).Valor_1;
            Session["Profesor2"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Profesor1.Text, TextBox_Profesor2.Text, TextBox_Profesor3.Text).Valor_2;
            Session["Profesor3"] = LEDE.Correcion_De_Datos_Vacios(TextBox_Profesor1.Text, TextBox_Profesor2.Text, TextBox_Profesor3.Text).Valor_3;
            
            LEDE.Insertar_En_Tabla_Segunda_Parte((string)Session["Tema1_S"],(string)Session["Tema2_S"],(string)Session["Tema3_S"],(string)Session["Tema1"],(string)Session["Tema2"],(string)Session["Tema3"],(string)Session["Materia1"],(string)Session["Materia2"],(string)Session["Materia3"],(string)Session["Colegio1"],(string)Session["Colegio2"],(string)Session["Colegio3"],(string)Session["Ano1"],(string)Session["Ano2"],(string)Session["Ano3"],(string)Session["Profesor1"],(string)Session["Profesor2"],(string)Session["Profesor3"]);

            LEDE.Insertar_En_Tabla_Tercera_Parte((string)Session["Tema1_S"], (string)Session["Tema2_S"], (string)Session["Tema3_S"], (string)Session["Tema1"], (string)Session["Tema2"], (string)Session["Tema3"], (string)Session["Materia1"], (string)Session["Materia2"], (string)Session["Materia3"], (string)Session["Colegio1"], (string)Session["Colegio2"], (string)Session["Colegio3"], (string)Session["Ano1"], (string)Session["Ano2"], (string)Session["Ano3"], (string)Session["Profesor1"], (string)Session["Profesor2"], (string)Session["Profesor3"]);

            TextBox_Ano.Text = LEDE.Obtener_Ano();
            TextBox_Materia.Text = LEDE.Obtener_Materia();
            TextBox_Colegio.Text = LEDE.Obtener_Colegio();
            TextBox_Profesor.Text = LEDE.Obtener_Profesor();
            TextBox_Tema.Text = LEDE.Obtener_Tema();
                       
            LEDE.Crear_Un_Archivo_TXT((string)Session["Contenido_Wiris"], (string)Session["Titulo"], Session["DropDownList_Institucion"].ToString(), Session["DropDownList_Tipo"].ToString(), (string)Session["Ubicacion_Del_Video_Y_Explicacion"], Session["DropDownList_Enunciado_Realizado"].ToString(),  (string)Session["Tema1_S"],(string)Session["Tema2_S"],(string)Session["Tema3_S"],(string)Session["Tema1"],(string)Session["Tema2"],(string)Session["Tema3"],(string)Session["Materia1"],(string)Session["Materia2"],(string)Session["Materia3"],(string)Session["Colegio1"],(string)Session["Colegio2"],(string)Session["Colegio3"],(string)Session["Ano1"],(string)Session["Ano2"],(string)Session["Ano3"],(string)Session["Profesor1"],(string)Session["Profesor2"],(string)Session["Profesor3"], TextBox_Ano.Text, TextBox_Colegio.Text, TextBox_Materia.Text, TextBox_Profesor.Text, TextBox_Tema.Text);

            Nombre_Del_Archivo.Text = "  " + LEDE.Obtener_Nombre_De_Archivo();

        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {

            Session["Tema1_S"] = null;
            Session["Tema2_S"] = null;
            Session["Tema3_S"] = null;

            Session["Tema1"] = null;
            Session["Tema2"] = null;
            Session["Tema3"] = null;

            Session["Ano1"] = null;
            Session["Ano2"] = null;
            Session["Ano3"] = null;

            Session["Materia1"] = null;
            Session["Materia2"] = null;
            Session["Materia3"] = null;

            Session["Colegio1"] = null;
            Session["Colegio2"] = null;
            Session["Colegio3"] = null;

            Session["Profesor1"] = null;
            Session["Profesor2"] = null;
            Session["Profesor3"] = null;

            Session["Titulo"] = null;
            Session["Ubicacion_Del_Video_Y_Explicacion"] = null;
            Session["Contenido_Wiris"] = null;
            Session["Anterior"] = null;
            Response.Redirect("index.aspx");

        }
    }
}