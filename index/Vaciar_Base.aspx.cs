using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace index
{
    public partial class Vaciar_Base : System.Web.UI.Page
    {

        Logica_Vaciar_Base LVB = new Logica_Vaciar_Base();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Boton_Borrar_Temas_Click(object sender, EventArgs e)
        {
            if (TextBox_Insertar_Administrador.Text == "Segundo" && TextBox_Insertar_Password.Text == "7eptimo")
            {
                LVB.Tabla_Temas();
                TextBox_Insertar_Administrador.Text = string.Empty;
                TextBox_Insertar_Password.Text = string.Empty;
            }
        }

        protected void Boton_Borrar_Anos_Click(object sender, EventArgs e)
        {
            if (TextBox_Insertar_Administrador.Text == "Primero" && TextBox_Insertar_Password.Text == "8ctavo")
            {
                LVB.Tabla_Ano();
                TextBox_Insertar_Administrador.Text = string.Empty;
                TextBox_Insertar_Password.Text = string.Empty;
            }
        }

        protected void Boton_Borror_Colegios_Click(object sender, EventArgs e)
        {
            if (TextBox_Insertar_Administrador.Text == "Tercero" && TextBox_Insertar_Password.Text == "6exto")
            {
                LVB.Tabla_Colegio();
                TextBox_Insertar_Administrador.Text = string.Empty;
                TextBox_Insertar_Password.Text = string.Empty;
            }
        }

        protected void Boton_Borrar_Profesores_Click(object sender, EventArgs e)
        {
            if (TextBox_Insertar_Administrador.Text == "Cuarto" && TextBox_Insertar_Password.Text == "5uinto")
            {
                LVB.Tabla_Profesor();
                TextBox_Insertar_Administrador.Text = string.Empty;
                TextBox_Insertar_Password.Text = string.Empty;
            }
        }

        protected void Boton_Borrar_Materias_Click(object sender, EventArgs e)
        {
            if (TextBox_Insertar_Administrador.Text == "Quinto" && TextBox_Insertar_Password.Text == "4uarto")
            {
                LVB.Tabla_Materias();
                TextBox_Insertar_Administrador.Text = string.Empty;
                TextBox_Insertar_Password.Text = string.Empty;
            }
        }

        protected void Boton_Borrar_Administradores_Click(object sender, EventArgs e)
        {
            if (TextBox_Insertar_Administrador.Text == "Sexto" && TextBox_Insertar_Password.Text == "3ercero")
            {
                LVB.Administrador();
                TextBox_Insertar_Administrador.Text = string.Empty;
                TextBox_Insertar_Password.Text = string.Empty;
            }
        }

        protected void Boton_Borrar_Empresas_Click(object sender, EventArgs e)
        {
            if (TextBox_Insertar_Administrador.Text == "Septimo" && TextBox_Insertar_Password.Text == "2egundo")
            {
                LVB.Empresa();
                TextBox_Insertar_Administrador.Text = string.Empty;
                TextBox_Insertar_Password.Text = string.Empty;
            }
        }

        protected void Boton_Borrar_Ejercicios_Click(object sender, EventArgs e)
        {
            if (TextBox_Insertar_Administrador.Text == "Octavo" && TextBox_Insertar_Password.Text == "1rimero")
            {
                LVB.Ejercicios();
                TextBox_Insertar_Administrador.Text = string.Empty;
                TextBox_Insertar_Password.Text = string.Empty;
            }
        }
    }
}