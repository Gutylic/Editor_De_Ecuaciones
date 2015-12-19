using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace index
{
    public partial class decodificador : System.Web.UI.Page
    {

        Logica_Desifrar_Etiqueta LDE = new Logica_Desifrar_Etiqueta();

        string Valor;
        int Dato;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Boton_De_Decodificacion_Click(object sender, EventArgs e)
        {
            if (Etiquetas_A_Decodificar.Text.StartsWith("m"))
            {
                Valor = LDE.Buscar_Etiquetas_Materias(Etiquetas_A_Decodificar.Text.Trim());
            }
            if (Etiquetas_A_Decodificar.Text.StartsWith("t"))
            {
                Valor = LDE.Buscar_Etiquetas_Temas(Etiquetas_A_Decodificar.Text.Trim());
            }
            if (Etiquetas_A_Decodificar.Text.StartsWith("p"))
            {
                Valor = LDE.Buscar_Etiquetas_Profesores(Etiquetas_A_Decodificar.Text.Trim());
            }
            if (Etiquetas_A_Decodificar.Text.StartsWith("a"))
            {
                Valor = LDE.Buscar_Etiquetas_Anos(Etiquetas_A_Decodificar.Text.Trim());
            }
            if (Etiquetas_A_Decodificar.Text.StartsWith("c"))
            {
                Valor = LDE.Buscar_Etiquetas_Colegios(Etiquetas_A_Decodificar.Text.Trim());
            }

            try
            {
                string[] Valor_Separado = Valor.Split(' ');

                Dato = Valor_Separado.Length;

                Array.Resize(ref Valor_Separado, 24);
                for (int I = Dato; I <= 23; I++)
                {
                    Valor_Separado[I] = string.Empty;
                }

                TextBox_1.Text = Valor_Separado[0];
                TextBox_2.Text = Valor_Separado[1];
                TextBox_3.Text = Valor_Separado[2];
                TextBox_4.Text = Valor_Separado[3];
                TextBox_5.Text = Valor_Separado[4];
                TextBox_6.Text = Valor_Separado[5];
                TextBox_7.Text = Valor_Separado[6];
                TextBox_8.Text = Valor_Separado[7];
                TextBox_9.Text = Valor_Separado[8];
                TextBox_10.Text = Valor_Separado[9];
                TextBox_11.Text = Valor_Separado[10];
                TextBox_12.Text = Valor_Separado[11];
                TextBox_13.Text = Valor_Separado[12];
                TextBox_14.Text = Valor_Separado[13];
                TextBox_15.Text = Valor_Separado[14];
                TextBox_16.Text = Valor_Separado[15];
                TextBox_17.Text = Valor_Separado[16];
                TextBox_18.Text = Valor_Separado[17];
                TextBox_19.Text = Valor_Separado[18];
                TextBox_20.Text = Valor_Separado[19];
                TextBox_21.Text = Valor_Separado[20];
                TextBox_22.Text = Valor_Separado[21];
                TextBox_23.Text = Valor_Separado[22];
                TextBox_24.Text = Valor_Separado[23];
            }
            catch 
            {
                return;
            }
        }
    }
}