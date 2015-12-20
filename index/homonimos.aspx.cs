using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using System.Data.Linq;

namespace index
{
    public partial class homonimos : System.Web.UI.Page
    {

        Logica_Trabajar_Con_Homonimos LTCH = new Logica_Trabajar_Con_Homonimos();
        DataClassesDataContext db = new DataClassesDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cargar_Etiqueta_Click(object sender, EventArgs e)
        {
            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "2")
            {
                Etiqueta_Predeterminada.SelectedValue = "2";
                Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Temas(Etiquetas_A_Decodificar.Text);
                Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Temas_Nuevo(Etiqueta_Nueva.Text);
            }
            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "3")
            {
                Etiqueta_Predeterminada.SelectedValue = "3";
                Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Colegios(Etiquetas_A_Decodificar.Text);
                Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Colegios_Nuevo(Etiqueta_Nueva.Text);
            }
            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "4")
            {
                Etiqueta_Predeterminada.SelectedValue = "4";
                Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Anos(Etiquetas_A_Decodificar.Text);
                Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Anos_Nuevo(Etiqueta_Nueva.Text);
            }
            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "5")
            {
                Etiqueta_Predeterminada.SelectedValue = "5";
                Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Profesores(Etiquetas_A_Decodificar.Text);
                Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Profesores(Etiqueta_Nueva.Text);
            }
            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "6")
            {
                Etiqueta_Predeterminada.SelectedValue = "6";
                Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Materias(Etiquetas_A_Decodificar.Text);
                Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Materias(Etiqueta_Nueva.Text);
            }
        }

        
        protected void Relacionar_Etiquetas_Click(object sender, EventArgs e)
        {

            if (DropDownList_Tipo_De_Etiqueta.SelectedItem.Value == "2")
            {
                Etiqueta_Predeterminada.SelectedValue = "2";                
                Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Temas(Etiquetas_A_Decodificar.Text);  
                Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Temas_Nuevo(Etiqueta_Nueva.Text);

                if (Etiqueta_Decodificadora.Text == string.Empty)
                {
                    return;
                }

                if (Nueva_Etiqueta_Codificadora.Text == string.Empty)
                {
                    Nueva_Etiqueta_Codificadora.Text = LTCH.Relacionar_Etiqueta_Temas(Etiqueta_Nueva.Text, Etiqueta_Decodificadora.Text);
                    return;
                }
                else
                {
                    Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Temas_Nuevo(Etiqueta_Nueva.Text);
                    string Error = @"<script type='text/javascript'>   
                                   alert('La etiqueta que usted desea relacionar tiene varias etiquetas relacionadas, borrela y vuela a crearla');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);                   
                    return;
                }
                
            }


            if (DropDownList_Tipo_De_Etiqueta.SelectedItem.Value == "3")
            {
                Etiqueta_Predeterminada.SelectedValue = "3";
                Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Colegios(Etiquetas_A_Decodificar.Text);
                Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Colegios_Nuevo(Etiqueta_Nueva.Text);

                if (Etiqueta_Decodificadora.Text == string.Empty)
                {
                    return;
                }

                if (Nueva_Etiqueta_Codificadora.Text == string.Empty)
                {
                    Nueva_Etiqueta_Codificadora.Text = LTCH.Relacionar_Etiqueta_Colegios(Etiqueta_Nueva.Text, Etiqueta_Decodificadora.Text);
                    return;
                }
                else
                {
                    Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Colegios_Nuevo(Etiqueta_Nueva.Text);
                    string Error = @"<script type='text/javascript'>   
                                   alert('La etiqueta que usted desea relacionar tiene varias etiquetas relacionadas, borrela y vuela a crearla');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                    return;
                }

            }


            if (DropDownList_Tipo_De_Etiqueta.SelectedItem.Value == "4")
            {
                Etiqueta_Predeterminada.SelectedValue = "4";
                Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Anos(Etiquetas_A_Decodificar.Text);
                Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Anos_Nuevo(Etiqueta_Nueva.Text);

                if (Etiqueta_Decodificadora.Text == string.Empty)
                {
                    return;
                }

                if (Nueva_Etiqueta_Codificadora.Text == string.Empty)
                {
                    Nueva_Etiqueta_Codificadora.Text = LTCH.Relacionar_Etiqueta_Anos(Etiqueta_Nueva.Text, Etiqueta_Decodificadora.Text);
                    return;
                }
                else
                {
                    Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Anos_Nuevo(Etiqueta_Nueva.Text);
                    string Error = @"<script type='text/javascript'>   
                                   alert('La etiqueta que usted desea relacionar tiene varias etiquetas relacionadas, borrela y vuela a crearla');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                    return;
                }

            }
            
        }

        protected void Agregar_Etiqueta_Click(object sender, EventArgs e)
        {

            if (Etiqueta_Predeterminada.SelectedValue == "2")
            {

                Etiqueta_Decodificadora.Text = "t" + LTCH.Agregar_Etiqueta(Etiquetas_A_Decodificar.Text, 2).ToString();
                string Error = @"<script type='text/javascript'>   
                                   alert('Verifique la existencia de la etiqueta');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                return;
            }

            if (Etiqueta_Predeterminada.SelectedValue == "3")
            {

                Etiqueta_Decodificadora.Text = "c" + LTCH.Agregar_Etiqueta(Etiquetas_A_Decodificar.Text, 3).ToString();
                string Error = @"<script type='text/javascript'>   
                                   alert('Verifique la existencia de la etiqueta');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                return;

            }

            if (Etiqueta_Predeterminada.SelectedValue == "5")
            {

                Etiqueta_Decodificadora.Text = "p" + LTCH.Agregar_Etiqueta(Etiquetas_A_Decodificar.Text, 5).ToString();
                string Error = @"<script type='text/javascript'>   
                                   alert('Verifique la existencia de la etiqueta');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                return;

            }

            if (Etiqueta_Predeterminada.SelectedValue == "6")
            {

                Etiqueta_Decodificadora.Text = "m" + LTCH.Agregar_Etiqueta(Etiquetas_A_Decodificar.Text, 6).ToString();
                string Error = @"<script type='text/javascript'>   
                                   alert('Verifique la existencia de la etiqueta');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                return;

            }

            if (Etiqueta_Predeterminada.SelectedValue == "4")
            {

                Etiqueta_Decodificadora.Text = "a" + LTCH.Agregar_Etiqueta(Etiquetas_A_Decodificar.Text, 4).ToString();
                string Error = @"<script type='text/javascript'>   
                                   alert('Verifique la existencia de la etiqueta');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                return;
            }

           


        }

        protected void Modificar_Etiqueta_Click(object sender, EventArgs e)
        {

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "2")
            {
                int Valor = LTCH.Modificar_Etiqueta_Temas(Etiquetas_A_Decodificar.Text, Etiqueta_Nueva.Text);

                switch (Valor)
                {
                    case 1:
                        Etiqueta_Predeterminada.SelectedValue = "2";
                        Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Temas(Etiquetas_A_Decodificar.Text);
                        Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Temas_Nuevo(Etiqueta_Nueva.Text);
                        Etiqueta_Decodificadora.Text = Nueva_Etiqueta_Codificadora.Text;
                        break;
                    case 0:
                        string Error = @"<script type='text/javascript'>
                                       alert('Error por dos causas: 1) caja de etiqueta buscada vacia 2) el codificador de la nueva etiqueta no esta vacio');                                       
                                       </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                        return;
                }

            }

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "3")
            {
                int Valor = LTCH.Modificar_Etiqueta_Colegios(Etiquetas_A_Decodificar.Text, Etiqueta_Nueva.Text);

                switch (Valor)
                {
                    case 1:
                        Etiqueta_Predeterminada.SelectedValue = "3";
                        Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Colegios(Etiquetas_A_Decodificar.Text);
                        Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Colegios_Nuevo(Etiqueta_Nueva.Text);
                        Etiqueta_Decodificadora.Text = Nueva_Etiqueta_Codificadora.Text;
                        break;
                    case 0:
                         string Error = @"<script type='text/javascript'>
                                       alert('Error por dos causas: 1) caja de etiqueta buscada vacia 2) el codificador de la nueva etiqueta no esta vacio');                                       
                                       </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                        return;
                }

            }

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "5")
            {
                int Valor = LTCH.Modificar_Etiqueta_Profesores(Etiquetas_A_Decodificar.Text, Etiqueta_Nueva.Text);

                switch (Valor)
                {
                    case 1:
                        Etiqueta_Predeterminada.SelectedValue = "5";
                        Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Profesores(Etiquetas_A_Decodificar.Text);
                        Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Profesores_Nuevo(Etiqueta_Nueva.Text);
                        Etiqueta_Decodificadora.Text = Nueva_Etiqueta_Codificadora.Text;
                        break;
                    case 0:
                         string Error = @"<script type='text/javascript'>
                                       alert('Error por dos causas: 1) caja de etiqueta buscada vacia 2) el codificador de la nueva etiqueta no esta vacio');                                       
                                       </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                        return;
                }

            }

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "4")
            {
                int Valor = LTCH.Modificar_Etiqueta_Anos(Etiquetas_A_Decodificar.Text, Etiqueta_Nueva.Text);

                switch (Valor)
                {
                    case 1:
                        Etiqueta_Predeterminada.SelectedValue = "4";
                        Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Anos(Etiquetas_A_Decodificar.Text);
                        Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Anos_Nuevo(Etiqueta_Nueva.Text);
                        Etiqueta_Decodificadora.Text = Nueva_Etiqueta_Codificadora.Text;
                        break;
                    case 0:
                         string Error = @"<script type='text/javascript'>
                                       alert('Error por dos causas: 1) caja de etiqueta buscada vacia 2) el codificador de la nueva etiqueta no esta vacio');                                       
                                       </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                        return;
                }

            }

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "6")
            {
                int Valor = LTCH.Modificar_Etiqueta_Materias(Etiquetas_A_Decodificar.Text, Etiqueta_Nueva.Text);

                switch (Valor)
                {
                    case 1:
                        Etiqueta_Predeterminada.SelectedValue = "6";
                        Etiqueta_Decodificadora.Text = LTCH.Buscar_Etiquetas_Materias(Etiquetas_A_Decodificar.Text);
                        Nueva_Etiqueta_Codificadora.Text = LTCH.Buscar_Etiquetas_Materias_Nuevo(Etiqueta_Nueva.Text);
                        Etiqueta_Decodificadora.Text = Nueva_Etiqueta_Codificadora.Text;
                        break;
                    case 0:
                         string Error = @"<script type='text/javascript'>
                                       alert('Error por dos causas: 1) caja de etiqueta buscada vacia 2) el codificador de la nueva etiqueta no esta vacio');                                       
                                       </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                        return;
                }

            }

        }

        protected void Borrar_Etiqueta_Click(object sender, EventArgs e)
        {

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "2")
            {
                Etiqueta_Predeterminada.SelectedValue = "2";
                int Valor = LTCH.Borrar_Etiqueta_Temas(Etiquetas_A_Decodificar.Text);

                switch (Valor)
                {
                    case 0:
                        string Error = @"<script type='text/javascript'>   
                                       alert('No existe la etiqueta que desea borrar');
                                       </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                        break;
                    case 1:
                        
                        break;

                }
            }

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "3")
            {
                Etiqueta_Predeterminada.SelectedValue = "3";
                int Valor = LTCH.Borrar_Etiqueta_Colegios(Etiquetas_A_Decodificar.Text);

                switch (Valor)
                {
                    case 0:
                        string Error = @"<script type='text/javascript'>   
                                       alert('No existe la etiqueta que desea borrar');
                                       </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                        break;
                    case 1:
                        
                        break;

                }
            }


            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "4")
            {
                Etiqueta_Predeterminada.SelectedValue = "4";
                int Valor = LTCH.Borrar_Etiqueta_Anos(Etiquetas_A_Decodificar.Text);

                switch (Valor)
                {
                    case 0:
                        string Error = @"<script type='text/javascript'>   
                                       alert('No existe la etiqueta que desea borrar');
                                       </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                        break;
                    case 1:
                       
                        break;

                }
            }

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "5")
            {
                Etiqueta_Predeterminada.SelectedValue = "5";
                int Valor = LTCH.Borrar_Etiqueta_Profesores(Etiquetas_A_Decodificar.Text);

                switch (Valor)
                {
                    case 0:
                        string Error = @"<script type='text/javascript'>   
                                       alert('No existe la etiqueta que desea borrar');
                                       </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                        break;
                    case 1:
                       
                        break;

                }
            }

            if (DropDownList_Tipo_De_Etiqueta.SelectedValue == "6")
            {
                Etiqueta_Predeterminada.SelectedValue = "6";
                int Valor = LTCH.Borrar_Etiqueta_Materias(Etiquetas_A_Decodificar.Text);

                switch (Valor)
                {
                    case 0:
                        string Error = @"<script type='text/javascript'>   
                                       alert('No existe la etiqueta que desea borrar');
                                       </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "", Error, false);
                        break;
                    case 1:
                        
                        break;

                }
            }
        }

        




        protected void Guardar_Materia_Click(object sender, EventArgs e)
        {
            List<Tabla_De_Materias> Valor = db.Tabla_De_Materias.ToList<Tabla_De_Materias>();

            XElement nodoraiz = new XElement("Contenido", from p in Valor select new XElement("Elementos", new XElement("ID_Materia", p.ID_Materia), new XElement("Materia", p.Materia), new XElement("Etiqueta_Materia", p.Etiqueta_Materia)));

            
            nodoraiz.Save(File.CreateText("c:\\XML/Materia.xml"));

            
        }

        protected void Guardar_Profesor_Click(object sender, EventArgs e)
        {
            List<Tabla_De_Profesores> Valor = db.Tabla_De_Profesores.ToList<Tabla_De_Profesores>();

            XElement nodoraiz = new XElement("Contenido", from p in Valor select new XElement("Elementos", new XElement("ID_Profesor", p.ID_Profesor), new XElement("Profesor", p.Profesor), new XElement("Etiqueta_Profesor", p.Etiqueta_Profesor)));


            nodoraiz.Save(File.CreateText("c:\\XML/Profesor.xml"));
        }

        protected void Guardar_Ano_Click(object sender, EventArgs e)
        {
            List<Tabla_De_Anos> Valor = db.Tabla_De_Anos.ToList<Tabla_De_Anos>();

            XElement nodoraiz = new XElement("Contenido", from p in Valor select new XElement("Elementos", new XElement("ID_Ano", p.ID_Ano), new XElement("Ano", p.Ano), new XElement("Etiqueta_Ano", p.Etiqueta_Ano)));


            nodoraiz.Save(File.CreateText("c:\\XML/Ano.xml"));
        }

        protected void Guardar_Colegio_Click(object sender, EventArgs e)
        {
            List<Tabla_De_Colegios> Valor = db.Tabla_De_Colegios.ToList<Tabla_De_Colegios>();

            XElement nodoraiz = new XElement("Contenido", from p in Valor select new XElement("Elementos", new XElement("ID_Colegio", p.ID_Colegio), new XElement("Colegio", p.Colegio), new XElement("Etiqueta_Colegio", p.Etiqueta_Colegio)));


            nodoraiz.Save(File.CreateText("c:\\XML/Colegio.xml"));
        }

        protected void Guardar_Tema_Click(object sender, EventArgs e)
        {
            List<Tabla_De_Temas> Valor = db.Tabla_De_Temas.ToList<Tabla_De_Temas>();

            XElement nodoraiz = new XElement("Contenido", from p in Valor select new XElement("Elementos", new XElement("ID_Tema", p.ID_Tema), new XElement("Tema", p.Tema), new XElement("Etiqueta_Tema", p.Etiqueta_Tema)));


            nodoraiz.Save(File.CreateText("c:\\XML/Tema.xml"));
        }
    }
}