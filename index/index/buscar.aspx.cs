﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using Logica;


namespace index
{
    public partial class buscar : System.Web.UI.Page
    {

        Logica_Busqueda LB = new Logica_Busqueda();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Boton_Para_Leer_Archivo_Click(object sender, EventArgs e)
        {

            if (Subir_Archivo.HasFile)
            {

                StreamReader obj = new StreamReader("C:\\archivo/" + Subir_Archivo.FileName);
                string sLine = obj.ReadLine();
                obj.Close();
                TextBox_MATH.Text = sLine;
                return;

            }
            else 
            {
                TextBox_MATH.Text = string.Empty;
                return;
            }

        }

        protected void Boton_De_Borrado_Del_TextArea_MATH_Click(object sender, EventArgs e)
        {
            Session["Contenido_Wiris"] = null;
            TextBox_MATH.Text = "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"></math>";
            TextBox_Por_Ano.Text = string.Empty;
            TextBox_Por_Colegio.Text = string.Empty;
            TextBox_Por_Materia.Text = string.Empty;
            TextBox_Por_Profesor.Text = string.Empty;
            TextBox_Por_Tema.Text = string.Empty;
        }

        protected void Boton_Busqueda_Enunciado_Profundidad_Click(object sender, EventArgs e)
        {
            int Valor;
            Session["Contenido_Wiris"] = Contenido_Wiris.Value;
            if (TextBox_Profundidad.Text == string.Empty)
            {
                return;
            }  
            else
            {

                if (TextBox_MATH.Text == "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"></math>")
                {
                    return;
                }

                if (!TextBox_MATH.Text.StartsWith("<math xmlns=\"http://www.w3.org/1998/Math/MathML\">"))
                {
                    return;
                
                }


                Valor = TextBox_MATH.Text.Length;                

                if (Valor > int.Parse(TextBox_Profundidad.Text))
                {
                    Valor = int.Parse(TextBox_Profundidad.Text);
                }

            }

            
            string Cadena = @"window.open('buscar_x_profundidad.aspx?Enunciado=" + LB.Logica_Buscar_Por_Profundidad(TextBox_MATH.Text, Valor) + "','_blank');";            
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
        }

        protected void Boton_Busqueda_En_Enunciado_Limpio_Porcentaje_Click(object sender, EventArgs e)
        {
            Session["Contenido_Wiris"] = Contenido_Wiris.Value;

            if (TextBox_MATH.Text == string.Empty || TextBox_MATH.Text == "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"></math>")
            {
                return;
            }
            
            if (LB.Logica_Por_Porcentaje(TextBox_MATH.Text).Valor_1 == null)
            {
                string script = @"<script type='text/javascript'>
                                        alert('No puede buscar con tan pocas palabras en el enunciado');
                                        </script>";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }

            

            string Enunciado_1 = LB.Logica_Por_Porcentaje(TextBox_MATH.Text).Valor_1;
            string Enunciado_2 = LB.Logica_Por_Porcentaje(TextBox_MATH.Text).Valor_2;
            string Cadena = @"window.open('buscar_x_porcentaje.aspx?Enunciado_1=" + Enunciado_1 + "&Enunciado_2=" + Enunciado_2 + "','_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                        
        }

        protected void Boton_Busqueda_En_Enunciado_Limpio_Palabras_Claves_Click(object sender, EventArgs e)
        {
            Session["Contenido_Wiris"] = Contenido_Wiris.Value;
            if (TextBox_MATH.Text == string.Empty)
            {
                return;
            }

            string Cadena = TextBox_MATH.Text.Replace("\r", " ");
            Cadena = Cadena.Replace("\n", " ");

            Cadena = @"window.open('buscar_x_clave.aspx?Enunciado=" + TextBox_MATH.Text.ToLower().Trim() + "','_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
        }

        protected void Boton_Busqueda_Por_Institucion_Click(object sender, EventArgs e)
        {
            Session["Contenido_Wiris"] = Contenido_Wiris.Value;
           
            string Cadena = @"window.open('buscar_x_institucion.aspx?Institucion=" + DropDownList_Tipo_De_Institucion.SelectedValue + "','_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
        }

        protected void Boton_Busqueda_Por_Ficha_Completa_Click(object sender, EventArgs e)
        {
            Session["Contenido_Wiris"] = Contenido_Wiris.Value;

            if ((TextBox_MATH.Text.StartsWith("Tema:")) && (TextBox_Por_Ano.Text != string.Empty || TextBox_Por_Colegio.Text != string.Empty || TextBox_Por_Materia.Text != string.Empty || TextBox_Por_Profesor.Text != string.Empty || TextBox_Por_Tema.Text != string.Empty)) 
            {
                string script = @"<script type='text/javascript'>
                                        alert('Los datos cargados en el cuadro de archivo y en cada materia estan llenos, solo debe estar completo uno de ellos');
                                        </script>";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }

            if (TextBox_MATH.Text.StartsWith("Tema:"))
            {

                string[] str = TextBox_MATH.Text.Split('╝');
                string Tema = str[1].Replace(" ", "").ToString().ToLower();
                string Materia = str[3].Replace(" ", "").ToString().ToLower();
                string Profesor = str[5].Replace(" ", "").ToString().ToLower();
                string Colegio = str[7].Replace(" ", "").ToString().ToLower();
                string Ano = str[9].Replace(" ", "").ToString().ToLower();

                if (Profesor == string.Empty && Ano == string.Empty && Colegio == string.Empty && Materia == string.Empty && Tema == string.Empty) //vacio
                {
                    string script = @"<script type='text/javascript'>
                                        alert('Todos los datos de la ficha vacios, generan muchisimas respuestas. Por favor rellene alguno de ellos');
                                        </script>";
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                    return;
                }

                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema= " + Tema + "&Materia= " + Materia + "&Maestro= " + Profesor + "&Colegio= " + Colegio + "&Ano= " + Ano + "&ficha=','_blank');"; // busca por ficha y bloquea el boton de buscar por enunciado
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
            }

            else
            { 
            
                string Tema = TextBox_Por_Tema.Text.Trim().ToLower();
                string Materia = TextBox_Por_Materia.Text.Trim().ToLower();
                string Profesor = TextBox_Por_Profesor.Text.Trim().ToLower();
                string Colegio = TextBox_Por_Colegio.Text.Trim().ToLower();
                string Ano = TextBox_Por_Ano.Text.Trim().ToLower();

                if (Profesor == string.Empty && Ano == string.Empty && Colegio == string.Empty && Materia == string.Empty && Tema == string.Empty) //vacio
                {
                    string script = @"<script type='text/javascript'>
                                            alert('Todos los datos de la ficha vacios, generan muchisimas respuestas. Por favor rellene alguno de ellos');
                                            </script>";
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                    return;
                }

                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema= " + Tema + "&Materia= " + Materia + "&Maestro= " + Profesor + "&Colegio= " + Colegio + "&Ano= " + Ano + "&ficha=','_blank');"; // busca por ficha y bloquea el boton de buscar por enunciado
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                
            
            }



        }

        protected void Boton_Busqueda_Por_Tema_Click(object sender, EventArgs e)
        {
            string Tema = string.Empty;
            if (TextBox_MATH.Text.Contains('╝'))
            {
                string[] str = TextBox_MATH.Text.Split('╝');
                Tema = str[1].Replace(" ", "").ToString().ToLower();
            }


            if (TextBox_Por_Tema.Text == string.Empty && Tema == string.Empty)
            {
                return;
            }

            if (TextBox_Por_Tema.Text != string.Empty && Tema != string.Empty)
            {
                string script = @"<script type='text/javascript'>
                                        alert('el casillero tema o el editor MATH los dos contienen datos, alguno debe estar vacio');
                                        </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }

            if (Tema != string.Empty)
            {
                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema=" + Tema + "&Materia= &Maestro= &Colegio= &Ano= &ficha=','_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                return;
            }
            else
            {
                Tema = TextBox_Por_Tema.Text.Replace(" ", "");
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 ]");
                Tema = reg.Replace(Tema.Normalize(System.Text.NormalizationForm.FormD), "").ToLower();
                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema=" + Tema + "&Materia= &Maestro= &Colegio= &Ano= &ficha=','_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                return;
            }
        }
                
        protected void Boton_Busqueda_Por_Materia_Click(object sender, EventArgs e)
        {
            string Materia = string.Empty;


            if (TextBox_MATH.Text.Contains('╝'))
            { 
                string[] str = TextBox_MATH.Text.Split('╝');
                Materia = str[3].Replace(" ", "").ToString().ToLower();
            }
            

            if (TextBox_Por_Materia.Text == string.Empty && Materia == string.Empty)
            {
                return;
            }

            if (TextBox_Por_Materia.Text != string.Empty && Materia != string.Empty)
            {
                string script = @"<script type='text/javascript'>
                                        alert('el casillero tema o el editor MATH los dos contienen datos, alguno debe estar vacio');
                                        </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }

            if (Materia != string.Empty)
            {
                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema= &Materia=" + Materia + "&Maestro= &Colegio= &Ano= &ficha=','_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                return;
            }
            else
            {
                Materia = TextBox_Por_Materia.Text.Replace(" ", "");
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 ]");
                Materia = reg.Replace(Materia.Normalize(System.Text.NormalizationForm.FormD), "").ToLower();
                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema= &Materia=" + Materia + "&Maestro= &Colegio= &Ano= &ficha=','_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                return;

            }
        }

        protected void Boton_Busqueda_Por_Profesor_Click(object sender, EventArgs e)
        {
            string Profesor = string.Empty;
            if (TextBox_MATH.Text.Contains('╝'))
            {
                string[] str = TextBox_MATH.Text.Split('╝');
                Profesor = str[5].Replace(" ", "").ToString().ToLower();
            }
            

            if (TextBox_Por_Profesor.Text == string.Empty && Profesor == string.Empty)
            {
                return;
            }

            if (TextBox_Por_Profesor.Text != string.Empty && Profesor != string.Empty)
            {
                string script = @"<script type='text/javascript'>
                                        alert('el casillero tema o el editor MATH los dos contienen datos, alguno debe estar vacio');
                                        </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }

            if (Profesor != string.Empty)
            {
                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema= &Materia= &Maestro=" + Profesor + " &Colegio= &Ano= &ficha=','_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                return;
            }
            else
            {
                Profesor = TextBox_Por_Profesor.Text.Replace(" ", "");
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 ]");
                Profesor = reg.Replace(Profesor.Normalize(System.Text.NormalizationForm.FormD), "").ToLower();
                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema= &Materia= &Maestro=" + Profesor + " &Colegio= &Ano= &ficha=','_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                return;

            }
        }

        protected void Boton_Busqueda_Por_Colegio_Click(object sender, EventArgs e)
        {
            string Colegio = string.Empty;
            if (TextBox_MATH.Text.Contains('╝'))
            {
                string[] str = TextBox_MATH.Text.Split('╝');
                Colegio = str[7].Replace(" ", "").ToString().ToLower();
            }
           
            if (TextBox_Por_Colegio.Text == string.Empty && Colegio == string.Empty)
            {
                return;
            }

            if (TextBox_Por_Colegio.Text != string.Empty && Colegio != string.Empty)
            {
                string script = @"<script type='text/javascript'>
                                        alert('el casillero tema o el editor MATH los dos contienen datos, alguno debe estar vacio');
                                        </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }

            if (Colegio != string.Empty)
            {
                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema= &Materia= &Maestro= &Colegio=" + Colegio + "&Ano= &ficha=','_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                return;
            }
            else
            {
                Colegio = TextBox_Por_Colegio.Text.Replace(" ", "");
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 ]");
                Colegio = reg.Replace(Colegio.Normalize(System.Text.NormalizationForm.FormD), "").ToLower();
                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema= &Materia= &Maestro= &Colegio=" + Colegio + "&Ano= &ficha=','_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                return;

            }
        }

        protected void Boton_Busqueda_Por_Ano_Click(object sender, EventArgs e)
        {

            string Ano = string.Empty;
            if (TextBox_MATH.Text.Contains('╝'))
            {
                string[] str = TextBox_MATH.Text.Split('╝');
                Ano = str[9].Replace(" ", "").ToString().ToLower();
            }
           
            if (TextBox_Por_Ano.Text == string.Empty && Ano == string.Empty)
            {
                return;
            }

            if (TextBox_Por_Ano.Text != string.Empty && Ano != string.Empty)
            {
                string script = @"<script type='text/javascript'>
                                        alert('el casillero tema o el editor MATH los dos contienen datos, alguno debe estar vacio');
                                        </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }

            if (Ano != string.Empty)
            {
                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema= &Materia= &Maestro= &Colegio= &Ano=" + Ano + "','_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                return;
            }
            else
            {
                Ano = TextBox_Por_Colegio.Text.Replace(" ", "");
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 ]");
                Ano = reg.Replace(Ano.Normalize(System.Text.NormalizationForm.FormD), "").ToLower();
                string Cadena = @"window.open('buscar_x_ficha.aspx?Tema= &Materia= &Maestro= &Colegio= &Ano=" + Ano + "','_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
                return;

            }
        }

    }

}