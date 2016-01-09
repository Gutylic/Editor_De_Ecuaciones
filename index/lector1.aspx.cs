using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace index
{
    public partial class lector1 : System.Web.UI.Page
    {

        Logica_Lector_De_Archivos LLDA = new Logica_Lector_De_Archivos();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
               

                if (Session["Siguiente"] == null)
                {
                    string[] datos = Session["Datos"].ToString().Split('╝');
                    TextBox_Tema1_S.Text = datos[9];
                    TextBox_Tema2_S.Text = datos[10];
                    TextBox_Tema3_S.Text = datos[11];
                    TextBox_Tema1.Text = datos[12];
                    TextBox_Tema2.Text = datos[13];
                    TextBox_Tema3.Text = datos[14];
                    TextBox_Materia1.Text = datos[15];
                    TextBox_Materia2.Text = datos[16];
                    TextBox_Materia3.Text = datos[17];
                    TextBox_Colegio1.Text = datos[18];
                    TextBox_Colegio2.Text = datos[19];
                    TextBox_Colegio3.Text = datos[20];
                    TextBox_Ano1.Text = datos[21];
                    TextBox_Ano2.Text = datos[22];
                    TextBox_Ano3.Text = datos[23];
                    TextBox_Profesor1.Text = datos[24];
                    TextBox_Profesor2.Text = datos[25];
                    TextBox_Profesor3.Text = datos[26];
                    TextBox_Ano.Text = datos[27];
                    TextBox_Colegio.Text = datos[28];
                    TextBox_Materia.Text = datos[29];
                    TextBox_Tema.Text = datos[31];
                    TextBox_Profesor.Text = datos[30];
                    Nombre_Del_Archivo.Text = " " + Session["Nombre_Del_Archivo"].ToString();
                }
                else
                {
                    try
                    {

                        TextBox_Tema1_S.Text = Session["T1S"].ToString();
                        TextBox_Tema2_S.Text = Session["T2S"].ToString();
                        TextBox_Tema3_S.Text = Session["T3S"].ToString();
                        TextBox_Tema1.Text = Session["T1"].ToString();
                        TextBox_Tema2.Text = Session["T2"].ToString();
                        TextBox_Tema3.Text = Session["T3"].ToString();
                        TextBox_Materia1.Text = Session["M1"].ToString();
                        TextBox_Materia2.Text = Session["M2"].ToString();
                        TextBox_Materia3.Text = Session["M3"].ToString();
                        TextBox_Colegio1.Text = Session["C1"].ToString();
                        TextBox_Colegio2.Text = Session["C2"].ToString();
                        TextBox_Colegio3.Text = Session["C3"].ToString();
                        TextBox_Ano1.Text = Session["A1"].ToString();
                        TextBox_Ano2.Text = Session["A2"].ToString();
                        TextBox_Ano3.Text = Session["A3"].ToString();
                        TextBox_Profesor1.Text = Session["P1"].ToString();
                        TextBox_Profesor2.Text = Session["P2"].ToString();
                        TextBox_Profesor3.Text = Session["P3"].ToString();
                        TextBox_Ano.Text = Session["A"].ToString();
                        TextBox_Colegio.Text = Session["C"].ToString();
                        TextBox_Materia.Text = Session["M"].ToString();
                        TextBox_Tema.Text = Session["T"].ToString();
                        TextBox_Profesor.Text = Session["P"].ToString();
                        Nombre_Del_Archivo.Text = " " + Session["Nombre_Del_Archivo"].ToString();
                    }

                    catch {
                        return;
                    }

                    


                }

               


            }

           
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {

            if ((int)Session["Anterior"] == 2)
            {
                Session["Anterior"] = 2;
            }
            else
            { 
                Session["Anterior"] = 1;
            }
            
            Session["T1S"] = TextBox_Tema1_S.Text;
            Session["T2S"] = TextBox_Tema2_S.Text;
            Session["T3S"] = TextBox_Tema3_S.Text;
            Session["T1"] = TextBox_Tema1.Text;
            Session["T2"] = TextBox_Tema2.Text;
            Session["T3"] = TextBox_Tema3.Text;
            Session["M1"] = TextBox_Materia1.Text;
            Session["M2"] = TextBox_Materia2.Text;
            Session["M3"] = TextBox_Materia3.Text;
            Session["C1"] = TextBox_Colegio1.Text;
            Session["C2"] = TextBox_Colegio2.Text;
            Session["C3"] = TextBox_Colegio3.Text;
            Session["A1"] = TextBox_Ano1.Text;
            Session["A2"] = TextBox_Ano2.Text;
            Session["A3"] = TextBox_Ano3.Text;
            Session["P1"] = TextBox_Profesor1.Text;
            Session["P2"] = TextBox_Profesor2.Text;
            Session["P3"] = TextBox_Profesor3.Text;
            Session["T"] = TextBox_Tema.Text;
            Session["A"] = TextBox_Ano.Text;
            Session["P"] = TextBox_Profesor.Text;
            Session["M"] = TextBox_Materia.Text;
            Session["C"] = TextBox_Colegio.Text;
            Response.Redirect("lector.aspx");
            
        }

        protected void Actualizar_Ejercicio_Click(object sender, EventArgs e)
        {
            Session["Anterior"] = 2;
            Actualizar_Ejercicio.Enabled = false;
            string Identificadora = (((string)Session["fileName"]).Substring(9));
            int Identificador = int.Parse(Identificadora.Substring(0, Identificadora.Length-4));
            int Valor = LLDA.Actualizar_En_Tabla_Primera_Parte(Identificador,(string)Session["Contenido_Wiris"],(string)Session["Titulo"],(string)Session["Ubicacion_Del_Video_Y_Explicacion"],(int)Session["DropDownList_Institucion"], (int)Session["DropDownList_Tipo"], (string)Session["DropDownList_Enunciado_Realizado"],(string)Session["Ubicacion_De_Impresion"],(string)Session["Ubicacion_Del_Ejercicio"]);

            switch (Valor)
            {
                case 1:

                    break;

                case -6:

                    string Fallo = @"<script type='text/javascript'>   
                                   alert('Ha ocurrido un error y no pudo conectarse a la base de datos intente más tarde');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Fallo, false);
                    break;
            }

            string Tema1_S = LLDA.Correcion_De_Datos_Vacios(TextBox_Tema1_S.Text, TextBox_Tema2_S.Text, TextBox_Tema3_S.Text).Valor_1;
            string Tema2_S = LLDA.Correcion_De_Datos_Vacios(TextBox_Tema1_S.Text, TextBox_Tema2_S.Text, TextBox_Tema3_S.Text).Valor_2;
            string Tema3_S = LLDA.Correcion_De_Datos_Vacios(TextBox_Tema1_S.Text, TextBox_Tema2_S.Text, TextBox_Tema3_S.Text).Valor_3;

            string Tema1 = LLDA.Correcion_De_Datos_Vacios(TextBox_Tema1.Text, TextBox_Tema2.Text, TextBox_Tema3.Text).Valor_1;
            string Tema2 = LLDA.Correcion_De_Datos_Vacios(TextBox_Tema1.Text, TextBox_Tema2.Text, TextBox_Tema3.Text).Valor_2;
            string Tema3 = LLDA.Correcion_De_Datos_Vacios(TextBox_Tema1.Text, TextBox_Tema2.Text, TextBox_Tema3.Text).Valor_3;

            string Ano1 = LLDA.Correcion_De_Datos_Vacios(TextBox_Ano1.Text, TextBox_Ano2.Text, TextBox_Ano3.Text).Valor_1;
            string Ano2 = LLDA.Correcion_De_Datos_Vacios(TextBox_Ano1.Text, TextBox_Ano2.Text, TextBox_Ano3.Text).Valor_2;
            string Ano3 = LLDA.Correcion_De_Datos_Vacios(TextBox_Ano1.Text, TextBox_Ano2.Text, TextBox_Ano3.Text).Valor_3;

            string Materia1 = LLDA.Correcion_De_Datos_Vacios(TextBox_Materia1.Text, TextBox_Materia2.Text, TextBox_Materia3.Text).Valor_1;
            string Materia2 = LLDA.Correcion_De_Datos_Vacios(TextBox_Materia1.Text, TextBox_Materia2.Text, TextBox_Materia3.Text).Valor_2;
            string Materia3 = LLDA.Correcion_De_Datos_Vacios(TextBox_Materia1.Text, TextBox_Materia2.Text, TextBox_Materia3.Text).Valor_3;

            string Colegio1 = LLDA.Correcion_De_Datos_Vacios(TextBox_Colegio1.Text, TextBox_Colegio2.Text, TextBox_Colegio3.Text).Valor_1;
            string Colegio2 = LLDA.Correcion_De_Datos_Vacios(TextBox_Colegio1.Text, TextBox_Colegio2.Text, TextBox_Colegio3.Text).Valor_2;
            string Colegio3 = LLDA.Correcion_De_Datos_Vacios(TextBox_Colegio1.Text, TextBox_Colegio2.Text, TextBox_Colegio3.Text).Valor_3;

            string Profesor1 = LLDA.Correcion_De_Datos_Vacios(TextBox_Profesor1.Text, TextBox_Profesor2.Text, TextBox_Profesor3.Text).Valor_1;
            string Profesor2 = LLDA.Correcion_De_Datos_Vacios(TextBox_Profesor1.Text, TextBox_Profesor2.Text, TextBox_Profesor3.Text).Valor_2;
            string Profesor3 = LLDA.Correcion_De_Datos_Vacios(TextBox_Profesor1.Text, TextBox_Profesor2.Text, TextBox_Profesor3.Text).Valor_3;

            LLDA.Actualizar_En_Tabla_Segunda_Parte(Tema1_S, Tema2_S, Tema3_S, Tema1, Tema2, Tema3, Materia1, Materia2, Materia3, Colegio1, Colegio2, Colegio3, Ano1, Ano2, Ano3, Profesor1, Profesor2, Profesor3);

           
            
            
            
            
            
            LLDA.Actualizar_En_Tabla_Tercera_Parte(Identificador, Tema1_S, Tema2_S, Tema3_S, Tema1, Tema2, Tema3, Materia1, Materia2, Materia3, Colegio1, Colegio2, Colegio3, Ano1, Ano2, Ano3, Profesor1, Profesor2, Profesor3);





            string dato = string.Empty;
            string[] Etiqueta_Final = TextBox_Tema.Text.Split(' ');
            string[] Etiqueta_Inicial = LLDA.Obtener_Tema_Actualizar((int)Session["ID"]).Split(' ');

            List<string> Etiqueta = Etiqueta_Final.Union(Etiqueta_Inicial).ToList();
            
            foreach (string t in Etiqueta)
            {
                dato = dato + " " + t;
            }

            TextBox_Tema.Text = dato;


            string dato_1 = string.Empty;
            Etiqueta_Final = TextBox_Materia.Text.Split(' ');
            Etiqueta_Inicial = LLDA.Obtener_Materia_Actualizar((int)Session["ID"]).Split(' ');

            Etiqueta = Etiqueta_Final.Union(Etiqueta_Inicial).ToList();
            foreach (string t in Etiqueta)
            {
                dato_1 = dato_1 + " " + t;
            }

            TextBox_Materia.Text = dato_1;

            string dato_2 = string.Empty;
            Etiqueta_Final = TextBox_Ano.Text.Split(' ');
            Etiqueta_Inicial = LLDA.Obtener_Ano_Actualizar((int)Session["ID"]).Split(' ');

            Etiqueta = Etiqueta_Final.Union(Etiqueta_Inicial).ToList();
            foreach (string t in Etiqueta)
            {
                dato_2 = dato_2 + " " + t;
            }

            TextBox_Ano.Text = dato_2;

            string dato_3 = string.Empty;
            Etiqueta_Final = TextBox_Colegio.Text.Split(' ');
            Etiqueta_Inicial = LLDA.Obtener_Colegio_Actualizar((int)Session["ID"]).Split(' ');

            Etiqueta = Etiqueta_Final.Union(Etiqueta_Inicial).ToList();
            foreach (string t in Etiqueta)
            {
                dato_3 = dato_3 + " " + t;
            }

            TextBox_Colegio.Text = dato_3;




            string dato_4 = string.Empty;
            Etiqueta_Final = TextBox_Profesor.Text.Split(' ');
            Etiqueta_Inicial = LLDA.Obtener_Profesor_Actualizar((int)Session["ID"]).Split(' ');

            Etiqueta = Etiqueta_Final.Union(Etiqueta_Inicial).ToList();
            foreach (string t in Etiqueta)
            {
                dato_4 = dato_4 + " " + t;
            }

            TextBox_Profesor.Text = dato_4;
            

            

            


                        
            LLDA.Actualizar_Un_Archivo_TXT((string)Session["fileName"],(string)Session["Contenido_Wiris"], (string)Session["Titulo"], Session["DropDownList_Institucion"].ToString(), Session["DropDownList_Tipo"].ToString(),(string)Session["Ubicacion_De_Impresion"],(string)Session["Ubicacion_Del_Ejercicio"],(string)Session["Ubicacion_Del_Video_Y_Explicacion"], Session["DropDownList_Enunciado_Realizado"].ToString(), Tema1_S, Tema2_S, Tema3_S, Tema1, Tema2, Tema3, Materia1, Materia2, Materia3, Colegio1, Colegio2, Colegio3, Ano1, Ano2, Ano3, Profesor1, Profesor2, Profesor3, TextBox_Ano.Text, TextBox_Colegio.Text, TextBox_Materia.Text, TextBox_Profesor.Text, TextBox_Tema.Text);

            Session["T"] = string.Empty;
            Session["A"] = string.Empty;
            Session["P"] = string.Empty;
            Session["M"] = string.Empty;
            Session["C"] = string.Empty;
            Session["Contenido_Wiris"] = string.Empty;
            Session["Titulo"] = string.Empty;
        }
    }
}