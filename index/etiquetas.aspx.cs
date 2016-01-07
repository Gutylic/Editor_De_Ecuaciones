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
    public partial class etiquetas : System.Web.UI.Page
    {

        Logica_Insertar_Etiquetas LIE = new Logica_Insertar_Etiquetas();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        int Dato;
        string[] datos;

        public void Cargando_Valores_Al_TextBox(string[] Valor)
        {
            Dato = Valor.Length;

            Array.Resize(ref Valor, 12);
            for (int I = Dato; I <= 11; I++)
            {
                Valor[I] = string.Empty;
            }

            TextBox_1.Text = Valor[0];
            TextBox_2.Text = Valor[1];
            TextBox_3.Text = Valor[2];
            TextBox_4.Text = Valor[3];
            TextBox_5.Text = Valor[4];
            TextBox_6.Text = Valor[5];
            TextBox_7.Text = Valor[6];
            TextBox_8.Text = Valor[7];
            TextBox_9.Text = Valor[8];
            TextBox_10.Text = Valor[9];
            TextBox_11.Text = Valor[10];
            TextBox_12.Text = Valor[11];
        }


        protected void Cargar_Ejercicio_Click(object sender, EventArgs e)
        {
            if (Subir_Archivo.HasFile == false)
            {
                return;
            }
            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "1")
            {
                return;
            }

            Session["Archivo_Subido"] = Subir_Archivo.FileName;
            string filename = Path.Combine(Server.MapPath("~/corregido"), Subir_Archivo.FileName);
            Subir_Archivo.SaveAs(filename);
            StreamReader file = new StreamReader(filename, System.Text.Encoding.UTF8);
            string texto;            
            texto = file.ReadToEnd();
            file.Close();
            Session["Datos"] = texto;
            datos = texto.Split('╝');
            Session["DropDownList_Tipo_De_Etiqueta"] = DropDownList_Tipo_De_Etiqueta.SelectedValue;


            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "2")
            {
                string[] Valor = LIE.Buscar_Etiquetas_Tema(datos[31]).Split(' ');

                Cargando_Valores_Al_TextBox(Valor);

                return;
            }

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "3")
            {
                string[] Valor = LIE.Buscar_Etiquetas_Colegio(datos[28]).Split(' ');

                Cargando_Valores_Al_TextBox(Valor);

                return;
            }

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "5")
            {
                string[] Valor = LIE.Buscar_Etiquetas_Profesor(datos[30]).Split(' ');

                Cargando_Valores_Al_TextBox(Valor);

                return;
            }

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "6")
            {
                string[] Valor = LIE.Buscar_Etiquetas_Materia(datos[29]).Split(' ');

                Cargando_Valores_Al_TextBox(Valor);

                return;
            }


            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "4")
            {
                string[] Valor = LIE.Buscar_Etiquetas_Ano(datos[27]).Split(' ');

                Cargando_Valores_Al_TextBox(Valor);
               
                return;
            }

        }

        protected void Insertar_Etiqueta_Click(object sender, EventArgs e)
        {
            if (Session["Datos"] == null) 
            {
                return;
            }

            string[] datos = Session["Datos"].ToString().Split('╝');
            
            string Tema1 = LIE.Correcion_De_Datos_Vacios(TextBox13.Text, TextBox14.Text, TextBox15.Text).Valor_1;
            string Tema2 = LIE.Correcion_De_Datos_Vacios(TextBox13.Text, TextBox14.Text, TextBox15.Text).Valor_2;
            string Tema3 = LIE.Correcion_De_Datos_Vacios(TextBox13.Text, TextBox14.Text, TextBox15.Text).Valor_3;
            
            LIE.Insertar_En_Tabla(Tema1,Tema2 ,Tema3 , Session["DropDownList_Tipo_De_Etiqueta"].ToString());

            string[] Etiqueta = new string[15];
            Etiqueta[0] = LIE.Buscar_Etiquetas(TextBox13.Text, "2");
            Etiqueta[1] = LIE.Buscar_Etiquetas(TextBox14.Text, "2");
            Etiqueta[2] = LIE.Buscar_Etiquetas(TextBox15.Text, "2");

            Etiqueta[3] = LIE.Buscar_Etiquetas(TextBox13.Text, "3");
            Etiqueta[4] = LIE.Buscar_Etiquetas(TextBox14.Text, "3");
            Etiqueta[5] = LIE.Buscar_Etiquetas(TextBox15.Text, "3");

            Etiqueta[6] = LIE.Buscar_Etiquetas(TextBox13.Text, "4");
            Etiqueta[7] = LIE.Buscar_Etiquetas(TextBox14.Text, "4");
            Etiqueta[8] = LIE.Buscar_Etiquetas(TextBox15.Text, "4");

            Etiqueta[9] = LIE.Buscar_Etiquetas(TextBox13.Text, "5");
            Etiqueta[10] = LIE.Buscar_Etiquetas(TextBox14.Text, "5");
            Etiqueta[11] = LIE.Buscar_Etiquetas(TextBox15.Text, "5");

            Etiqueta[12] = LIE.Buscar_Etiquetas(TextBox13.Text, "6");
            Etiqueta[13] = LIE.Buscar_Etiquetas(TextBox14.Text, "6");
            Etiqueta[14] = LIE.Buscar_Etiquetas(TextBox15.Text, "6");


            LIE.Actualizar_Un_Archivo_TXT(Session["Archivo_Subido"].ToString(),datos[0],datos[1],datos[2],
                datos[3].ToString(),datos[4].ToString(),datos[5],datos[6],datos[7],datos[8].ToString(),
                datos[9],datos[10],datos[11],datos[12],datos[13],datos[14],datos[15],datos[16],datos[17],
                datos[18],datos[19],datos[20],datos[21],datos[22],datos[23],datos[24],datos[25],datos[26],LIE.Cargar_Etiqueta_Ano(Etiqueta[6],Etiqueta[7],Etiqueta[8],datos[27]),
                LIE.Cargar_Etiqueta_Colegio(Etiqueta[3],Etiqueta[4],Etiqueta[5],datos[28]),LIE.Cargar_Etiqueta_Materia(Etiqueta[12],Etiqueta[13],Etiqueta[14],datos[29]),
                LIE.Cargar_Etiqueta_Tema(Etiqueta[0],Etiqueta[1],Etiqueta[2],datos[30]),LIE.Cargar_Etiqueta_Profesor(Etiqueta[9],Etiqueta[10],Etiqueta[11],datos[31]));

           
           
           
        }
    }
}