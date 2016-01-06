using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace index
{
    public partial class Cargar_Administradores : System.Web.UI.Page
    {

        Logica_Administradores LA = new Logica_Administradores();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Boton_Cargar_Click(object sender, EventArgs e)
        {

            if (TextBox_Insertar_Administrador.Text == string.Empty || TextBox_Insertar_Password.Text == string.Empty || TextBox_Insertar_Empresa.Text == string.Empty)
            {
                return;
            }


            int Valor = LA.Insertar_Administrador(TextBox_Insertar_Administrador.Text, TextBox_Insertar_Password.Text, TextBox_Insertar_Empresa.Text);

            if (TextBox_Insertar_Password.Text.Length <= 5)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('La contraseña debe tener mas de 5 caracteres');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }


            if (Valor == 1)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('El administrador fue creado correctamente');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }
            if (Valor == 0)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('El administrador creado ya existe');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }
            if (Valor == -6)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('En estos momentos no se puede procesar su consulta');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }
        }

        protected void Boton_Actualizar_Click(object sender, EventArgs e)
        {
            if (TextBox_Insertar_Administrador.Text == string.Empty || TextBox_Insertar_Password.Text == string.Empty)
            {
                return;
            }

            if (TextBox_Insertar_Password.Text.Length <= 5)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('La contraseña debe tener mas de 5 caracteres');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }

            int Valor = LA.Actuaizar_Administrador(TextBox_Insertar_Administrador.Text, TextBox_Insertar_Password.Text);
            if (Valor == 1)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('El administrador fue actualizado correctamente');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }
            if (Valor == -6)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('En estos momentos no se puede procesar su consulta');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }
            if (Valor == 0)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('El administrador no existe');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }
        }

        protected void Boton_Borrar_Click(object sender, EventArgs e)
        {
            if (TextBox_Insertar_Administrador.Text == string.Empty)
            {
                return;
            }
            int Valor = LA.Borrar_Administrador(TextBox_Insertar_Administrador.Text);
            if (Valor == 1)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('El administrador fue borrado correctamente');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }
            if (Valor == -6)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('En estos momentos no se puede procesar su consulta');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }
            if (Valor == 0)
            {
                string Mensaje = @"<script type='text/javascript'>   
                                   alert('El administrador no existe');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Mensaje, false);
                return;
            }
        }
    }
}