using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logica
{
    public class Logica_Insertar_Etiquetas
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int Contenido_Tabla;

        public string Buscar_Etiquetas_Ano(string Etiqueta)
        {
            string[] Ano = Etiqueta.Split('a');
            List<string> Contenido = new List<string>();

            for (int I = 1; I <= Ano.Length - 1; I++)
            {
                Ano[I] = Ano[I].Trim();
                List<string> Contenido_Tabla = (from p in db.Tabla_De_Anos where p.Etiqueta_Ano == int.Parse(Ano[I]) select p.Ano).ToList();

                Contenido = Contenido.Union(Contenido_Tabla).ToList();
            }

            return String.Join(" ", Contenido);
        
        }

        public string Buscar_Etiquetas_Tema(string Etiqueta)
        {
            string[] Tema = Etiqueta.Split('t');
            List<string> Contenido = new List<string>();

            for (int I = 1; I <= Tema.Length - 1; I++)
            {
                Tema[I] = Tema[I].Trim();
                List<string> Contenido_Tabla = (from p in db.Tabla_De_Temas where p.Etiqueta_Tema == int.Parse(Tema[I]) select p.Tema).ToList();

                Contenido = Contenido.Union(Contenido_Tabla).ToList();
            }

            return String.Join(" ", Contenido);

        }

        public string Buscar_Etiquetas_Colegio(string Etiqueta)
        {
            string[] Colegio = Etiqueta.Split('c');
            List<string> Contenido = new List<string>();

            for (int I = 1; I <= Colegio.Length - 1; I++)
            {
                Colegio[I] = Colegio[I].Trim();
                List<string> Contenido_Tabla = (from p in db.Tabla_De_Colegios where p.Etiqueta_Colegio == int.Parse(Colegio[I]) select p.Colegio).ToList();

                Contenido = Contenido.Union(Contenido_Tabla).ToList();
            }

            return String.Join(" ", Contenido);

        }

        public string Buscar_Etiquetas_Materia(string Etiqueta)
        {
            string[] Materia = Etiqueta.Split('m');
            List<string> Contenido = new List<string>();

            for (int I = 1; I <= Materia.Length - 1; I++)
            {
                Materia[I] = Materia[I].Trim();
                List<string> Contenido_Tabla = (from p in db.Tabla_De_Materias where p.Etiqueta_Materia == int.Parse(Materia[I]) select p.Materia).ToList();

                Contenido = Contenido.Union(Contenido_Tabla).ToList();
            }

            return String.Join(" ", Contenido);

        }

        public string Buscar_Etiquetas_Profesor(string Etiqueta)
        {
            string[] Profesor = Etiqueta.Split('p');
            List<string> Contenido = new List<string>();

            for (int I = 1; I <= Profesor.Length - 1; I++)
            {
                Profesor[I] = Profesor[I].Trim();
                List<string> Contenido_Tabla = (from p in db.Tabla_De_Profesores where p.Etiqueta_Profesor == int.Parse(Profesor[I]) select p.Profesor).ToList();

                Contenido = Contenido.Union(Contenido_Tabla).ToList();
            }

            return String.Join(" ", Contenido);

        }

        public string Corregir_Etiqueta(string Dato)
        {
            if (Dato != null)
            {
                string Linea = Dato.ToLower().Trim();
                
                Linea = Linea.Replace("á", "a");
                Linea = Linea.Replace("é;", "e");
                Linea = Linea.Replace("í;", "i");
                Linea = Linea.Replace("ó", "o");
                Linea = Linea.Replace("ú", "u");
                Linea = Linea.Replace(" ", "");
                Linea = Linea.Replace("Á;", "a");
                Linea = Linea.Replace("É", "e");
                Linea = Linea.Replace("Í", "i");
                Linea = Linea.Replace("Ó", "o");
                Linea = Linea.Replace("Ú", "u");
                Linea = Linea.Replace("ñ", "n");
                Linea = Linea.Replace("Ñ", "n");
                Linea = Linea.Replace("º", "");
                
                Linea = Linea.Trim(); // elimino los espacios delante y detras de la variable creada
                return Linea; // variable final limpia de wiris
            }

            return Dato;
        }

        public class Tres_Datos_Para_Sacar_Vacios
        {
            public string Valor_1 { get; set; }
            public string Valor_2 { get; set; }
            public string Valor_3 { get; set; }

        }

        public Tres_Datos_Para_Sacar_Vacios Correcion_De_Datos_Vacios(string Dato1, string Dato2, string Dato3)
        {

            Tres_Datos_Para_Sacar_Vacios Limpieza_De_Datos = new Tres_Datos_Para_Sacar_Vacios();

            string[] Dato = new string[3];
            Dato[0] = Dato1;
            Dato[1] = Dato2;
            Dato[2] = Dato3;

            for (int I = 0; I <= 2; I++)
            {

                if (Dato[I] == string.Empty)
                {

                    for (int J = I + 1; J <= 2; J++)
                    {
                        Dato[I] = Dato[J];
                        if (Dato[I] != string.Empty)
                        {
                            Dato[J] = string.Empty;
                            break;
                        }

                    }

                }

            }
            for (int I = 0; I <= 2; I++)
            {
                if (Dato[I] == string.Empty)
                {
                    Dato[I] = null;
                }
            }

            Limpieza_De_Datos.Valor_1 = Dato[0];
            Limpieza_De_Datos.Valor_2 = Dato[1];
            Limpieza_De_Datos.Valor_3 = Dato[2];

            return Limpieza_De_Datos;
        }    

        public void Insertar_En_Tabla(string TextBox1, string TextBox2, string TextBox3, string DropDownList)
        {
            switch (DropDownList) 
            { 
                case "2":
                    db.Temas(Corregir_Etiqueta(TextBox1), Corregir_Etiqueta(TextBox2), Corregir_Etiqueta(TextBox3));
                    break;
                case "3":
                    db.Colegios(Corregir_Etiqueta(TextBox1), Corregir_Etiqueta(TextBox2), Corregir_Etiqueta(TextBox3));
                    break;
                case "4":
                    db.Anos(Corregir_Etiqueta(TextBox1), Corregir_Etiqueta(TextBox2), Corregir_Etiqueta(TextBox3));
                    break;
                case "5":
                    db.Profesores(Corregir_Etiqueta(TextBox1), Corregir_Etiqueta(TextBox2), Corregir_Etiqueta(TextBox3));
                    break;
                case "6":
                    db.Materias(Corregir_Etiqueta(TextBox1), Corregir_Etiqueta(TextBox2), Corregir_Etiqueta(TextBox3));
                    break;
            
            }
            
        }

        public string Buscar_Etiquetas(string TextBox, string DropDownList)
        {

            switch (DropDownList)
            {
                case "2":
                    Contenido_Tabla = (from p in db.Tabla_De_Temas where p.Tema == Corregir_Etiqueta(TextBox) select p.Etiqueta_Tema).SingleOrDefault();
                    break;
                case "3":
                    Contenido_Tabla = (from p in db.Tabla_De_Colegios where p.Colegio == Corregir_Etiqueta(TextBox) select p.Etiqueta_Colegio).SingleOrDefault();
                    break;
                case "4":
                    Contenido_Tabla = (from p in db.Tabla_De_Anos where p.Ano == Corregir_Etiqueta(TextBox) select p.Etiqueta_Ano).SingleOrDefault();
                    break;
                case "5":
                    Contenido_Tabla = (from p in db.Tabla_De_Profesores where p.Profesor == Corregir_Etiqueta(TextBox) select p.Etiqueta_Profesor).SingleOrDefault();
                    break;
                case "6":
                    Contenido_Tabla = (from p in db.Tabla_De_Materias where p.Materia == Corregir_Etiqueta(TextBox) select p.Etiqueta_Materia).SingleOrDefault();
                    break;
            }

            if (Contenido_Tabla == 0)
            {
                return string.Empty;
            }
            return Contenido_Tabla.ToString();
        }

        public string Etiqueta_Final(string Etiqueta1, string Etiqueta2, string Etiqueta3, string Etiqueta_Total, string Variable)
        {
            string[] Etiqueta_Armada = Etiqueta_Total.Split(' ');

            for (int I = 0; I <= Etiqueta_Armada.Length - 1; I++)
            {
                if (Etiqueta1 != Variable && Etiqueta1 != Etiqueta_Armada[I])
                {
                    Etiqueta_Total = Etiqueta_Total + " " + Etiqueta1;
                    break;
                }
            }
            for (int I = 0; I <= Etiqueta_Armada.Length - 1; I++)
            {
                if (Etiqueta2 != Variable && Etiqueta2 != Etiqueta_Armada[I])
                {
                    Etiqueta_Total = Etiqueta_Total + " " + Etiqueta2;
                    break;
                }
            }
            for (int I = 0; I <= Etiqueta_Armada.Length - 1; I++)
            {
                if (Etiqueta3 != Variable && Etiqueta3 != Etiqueta_Armada[I])
                {
                    Etiqueta_Total = Etiqueta_Total + " " + Etiqueta3;
                    break;
                }
            }

            return Etiqueta_Total.Trim();        
        }



        public string Cargar_Etiqueta_Ano(string Etiqueta1, string Etiqueta2, string Etiqueta3, string Etiqueta_Total)
        {
            Etiqueta1 = "a" + Etiqueta1;
            Etiqueta2 = "a" + Etiqueta2;
            Etiqueta3 = "a" + Etiqueta3;

            return Etiqueta_Final(Etiqueta1, Etiqueta2, Etiqueta3, Etiqueta_Total,"a");
            

        }
        public string Cargar_Etiqueta_Profesor(string Etiqueta1, string Etiqueta2, string Etiqueta3, string Etiqueta_Total)
        {
            Etiqueta1 = "p" + Etiqueta1;
            Etiqueta2 = "p" + Etiqueta2;
            Etiqueta3 = "p" + Etiqueta3;

            return Etiqueta_Final(Etiqueta1, Etiqueta2, Etiqueta3, Etiqueta_Total, "p");
            

        }
        public string Cargar_Etiqueta_Materia(string Etiqueta1, string Etiqueta2, string Etiqueta3, string Etiqueta_Total)
        {
            Etiqueta1 = "m" + Etiqueta1;
            Etiqueta2 = "m" + Etiqueta2;
            Etiqueta3 = "m" + Etiqueta3;

            return Etiqueta_Final(Etiqueta1, Etiqueta2, Etiqueta3, Etiqueta_Total,"m");

        }
        public string Cargar_Etiqueta_Colegio(string Etiqueta1, string Etiqueta2, string Etiqueta3, string Etiqueta_Total)
        {
            Etiqueta1 = "c" + Etiqueta1;
            Etiqueta2 = "c" + Etiqueta2;
            Etiqueta3 = "c" + Etiqueta3;

            return Etiqueta_Final(Etiqueta1, Etiqueta2, Etiqueta3, Etiqueta_Total,"c");

        }
        public string Cargar_Etiqueta_Tema(string Etiqueta1, string Etiqueta2, string Etiqueta3, string Etiqueta_Total)
        {
            Etiqueta1 = "t" + Etiqueta1;
            Etiqueta2 = "t" + Etiqueta2;
            Etiqueta3 = "t" + Etiqueta3;

            return Etiqueta_Final(Etiqueta1, Etiqueta2, Etiqueta3, Etiqueta_Total,"t");

        }


        public void Actualizar_Un_Archivo_TXT(string Nombre_Archivo, string Enunciado, string Enunciado_Corregido,
           string Titulo, string Institucion, string Ejercicio, string Impresion, string Visible,
           string Video, string Explicacion, string Tema1_S, string Tema2_S,
           string Tema3_S, string Tema1, string Tema2,
           string Tema3, string Materia1, string Materia2,
           string Materia3, string Colegio1, string Colegio2,
           string Colegio3, string Ano1, string Ano2,
           string Ano3, string Profesor1, string Profesor2, string Profesor3,
           string Etiqueta_Ano, string Etiqueta_Colegio, string Etiqueta_Materia, string Etiqueta_Tema, string Etiqueta_Profesor) // carga dos archivos en c: correspondiente a los enunciados
        {


            StreamWriter Archivo = File.CreateText("C:\\archivo/" + Nombre_Archivo); // carga el archivo corregido del enunciado en c:            
            Archivo.Write(Enunciado);
            Archivo.Write("╝");
            Archivo.Write(Enunciado_Corregido);
            Archivo.Write("╝");
            Archivo.Write(Titulo);
            Archivo.Write("╝");
            Archivo.Write(Institucion);
            Archivo.Write("╝");
            Archivo.Write(Ejercicio);
            Archivo.Write("╝");
            Archivo.Write(Impresion);
            Archivo.Write("╝");
            Archivo.Write(Visible);
            Archivo.Write("╝");
            Archivo.Write(Video);
            Archivo.Write("╝");
            Archivo.Write(bool.Parse(Explicacion));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Tema1_S));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Tema2_S));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Tema3_S));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Tema1));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Tema2));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Tema3));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Materia1));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Materia2));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Materia3));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Colegio1));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Colegio2));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Colegio3));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Ano1));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Ano2));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Ano3));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Profesor1));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Profesor2));
            Archivo.Write("╝");
            Archivo.Write(Corregir_Etiqueta(Profesor3));
            Archivo.Write("╝");
            Archivo.Write(Etiqueta_Ano);
            Archivo.Write("╝");
            Archivo.Write(Etiqueta_Colegio);
            Archivo.Write("╝");
            Archivo.Write(Etiqueta_Materia);
            Archivo.Write("╝");
            Archivo.Write(Etiqueta_Tema);
            Archivo.Write("╝");
            Archivo.Write(Etiqueta_Profesor);
            Archivo.Flush();
            Archivo.Close();

        }


    }
}
