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

        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
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

            string Tema1_S = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1_S.Text,TextBox_Tema2_S.Text,TextBox_Tema3_S.Text).Valor_1;
            string Tema2_S = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1_S.Text,TextBox_Tema2_S.Text,TextBox_Tema3_S.Text).Valor_2;
            string Tema3_S = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1_S.Text,TextBox_Tema2_S.Text,TextBox_Tema3_S.Text).Valor_3;
            
            string Tema1 = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1.Text,TextBox_Tema2.Text,TextBox_Tema3.Text).Valor_1;
            string Tema2 = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1.Text,TextBox_Tema2.Text,TextBox_Tema3.Text).Valor_2;
            string Tema3 = LEDE.Correcion_De_Datos_Vacios(TextBox_Tema1.Text,TextBox_Tema2.Text,TextBox_Tema3.Text).Valor_3;

            string Ano1 = LEDE.Correcion_De_Datos_Vacios(TextBox_Ano1.Text,TextBox_Ano2.Text,TextBox_Ano3.Text).Valor_1;
            string Ano2 = LEDE.Correcion_De_Datos_Vacios(TextBox_Ano1.Text,TextBox_Ano2.Text,TextBox_Ano3.Text).Valor_2;
            string Ano3 = LEDE.Correcion_De_Datos_Vacios(TextBox_Ano1.Text,TextBox_Ano2.Text,TextBox_Ano3.Text).Valor_3;

            string Materia1 = LEDE.Correcion_De_Datos_Vacios(TextBox_Materia1.Text,TextBox_Materia2.Text,TextBox_Materia3.Text).Valor_1;
            string Materia2 = LEDE.Correcion_De_Datos_Vacios(TextBox_Materia1.Text,TextBox_Materia2.Text,TextBox_Materia3.Text).Valor_2;
            string Materia3 = LEDE.Correcion_De_Datos_Vacios(TextBox_Materia1.Text,TextBox_Materia2.Text,TextBox_Materia3.Text).Valor_3;

            string Colegio1 = LEDE.Correcion_De_Datos_Vacios(TextBox_Colegio1.Text,TextBox_Colegio2.Text,TextBox_Colegio3.Text).Valor_1;
            string Colegio2 = LEDE.Correcion_De_Datos_Vacios(TextBox_Colegio1.Text,TextBox_Colegio2.Text,TextBox_Colegio3.Text).Valor_2;
            string Colegio3 = LEDE.Correcion_De_Datos_Vacios(TextBox_Colegio1.Text,TextBox_Colegio2.Text,TextBox_Colegio3.Text).Valor_3;

            string Profesor1 = LEDE.Correcion_De_Datos_Vacios(TextBox_Profesor1.Text,TextBox_Profesor2.Text,TextBox_Profesor3.Text).Valor_1;
            string Profesor2 = LEDE.Correcion_De_Datos_Vacios(TextBox_Profesor1.Text,TextBox_Profesor2.Text,TextBox_Profesor3.Text).Valor_2;
            string Profesor3 = LEDE.Correcion_De_Datos_Vacios(TextBox_Profesor1.Text,TextBox_Profesor2.Text,TextBox_Profesor3.Text).Valor_3;
            
            LEDE.Insertar_En_Tabla_Segunda_Parte(Tema1_S,Tema2_S,Tema3_S,Tema1,Tema2,Tema3,Materia1,Materia2,Materia3,Colegio1,Colegio2,Colegio3,Ano1,Ano2,Ano3,Profesor1,Profesor2,Profesor3);

            LEDE.Insertar_En_Tabla_Tercera_Parte(Tema1_S,Tema2_S,Tema3_S,Tema1,Tema2,Tema3,Materia1,Materia2,Materia3,Colegio1,Colegio2,Colegio3,Ano1,Ano2,Ano3,Profesor1,Profesor2,Profesor3);

            TextBox_Ano.Text = LEDE.Obtener_Ano();
            TextBox_Materia.Text = LEDE.Obtener_Materia();
            TextBox_Colegio.Text = LEDE.Obtener_Colegio();
            TextBox_Profesor.Text = LEDE.Obtener_Profesor();
            TextBox_Tema.Text = LEDE.Obtener_Tema();
                       
            LEDE.Crear_Un_Archivo_TXT((string)Session["Contenido_Wiris"], (string)Session["Titulo"], Session["DropDownList_Institucion"].ToString(), Session["DropDownList_Tipo"].ToString(), (string)Session["Ubicacion_Del_Video_Y_Explicacion"], Session["DropDownList_Enunciado_Realizado"].ToString(), Tema1_S, Tema2_S, Tema3_S, Tema1, Tema2, Tema3, Materia1, Materia2, Materia3, Colegio1, Colegio2, Colegio3, Ano1, Ano2, Ano3, Profesor1, Profesor2, Profesor3, TextBox_Ano.Text, TextBox_Colegio.Text, TextBox_Materia.Text, TextBox_Profesor.Text, TextBox_Tema.Text);

            Nombre_Del_Archivo.Text = "  " + LEDE.Obtener_Nombre_De_Archivo();

        }
    }
}