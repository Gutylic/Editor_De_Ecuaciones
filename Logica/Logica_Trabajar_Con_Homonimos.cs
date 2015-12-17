using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Trabajar_Con_Homonimos
    {

        DataClassesDataContext db = new DataClassesDataContext();

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


        public string Buscar_Etiquetas_Anos(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Etiqueta_Final = (from p in db.Tabla_De_Anos where p.Ano == Etiqueta select p.Etiqueta_Ano).SingleOrDefault();

            if (Etiqueta_Final == 0)
            {
                return "";
            }

            return "a" + Etiqueta_Final.ToString();

        }
        public string Buscar_Etiquetas_Anos_Nuevo(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Etiqueta_Final = (from p in db.Tabla_De_Anos where p.Ano == Etiqueta select p.Etiqueta_Ano).SingleOrDefault();

            if (Etiqueta_Final == 0)
            {
                return "";
            }
            return "a" + Etiqueta_Final.ToString();
        }
        public int Cantidad_De_Datos_Anos(string Etiqueta)
        {
            int J = 0;

            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Valor = (from p in db.Tabla_De_Anos where p.Ano == Etiqueta select p.Etiqueta_Ano).SingleOrDefault();

            List<int> Cantidad_De_Datos = (from p in db.Tabla_De_Anos where p.Etiqueta_Ano == Valor select p.ID_Ano).ToList();

            foreach (int s in Cantidad_De_Datos)
            {

                J = J + 1;

            }

            return J;

        }
        public void Relacionar_Etiqueta_Anos(string Etiqueta, string Codigo)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Codigo_Numerico = int.Parse(Codigo.Substring(1));

            int Valor = (from p in db.Tabla_De_Anos where p.Ano == Etiqueta select p.Etiqueta_Ano).SingleOrDefault();

            if (Valor != 0)
            {
                Tabla_De_Anos Etiqueta_Final = db.Tabla_De_Anos.Single(p => p.Ano == Etiqueta);
                Etiqueta_Final.Etiqueta_Ano = Codigo_Numerico;
                db.SubmitChanges();
                
            }
            else
            {
                Tabla_De_Anos Etiqueta_Final = new Tabla_De_Anos();
                Etiqueta_Final.Etiqueta_Ano = Codigo_Numerico;
                Etiqueta_Final.Ano = Etiqueta;
                db.Tabla_De_Anos.InsertOnSubmit(Etiqueta_Final);
                db.SubmitChanges();
                
            }

        }
        public void Agregar_Etiqueta_Anos(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);
            Tabla_De_Anos Etiqueta_Final = new Tabla_De_Anos();
            int Codigo_Numerico = db.Tabla_De_Anos.Max(p => p.Etiqueta_Ano);
            Etiqueta_Final.Etiqueta_Ano = Codigo_Numerico + 1;
            Etiqueta_Final.Ano = Etiqueta;
            db.Tabla_De_Anos.InsertOnSubmit(Etiqueta_Final);
            db.SubmitChanges();

        }
        public int Modificar_Etiqueta_Anos(string Etiqueta_1, string Etiqueta_2)
        {
            Etiqueta_1 = Corregir_Etiqueta(Etiqueta_1);
            Etiqueta_2 = Corregir_Etiqueta(Etiqueta_2);

            if (Buscar_Etiquetas_Anos(Etiqueta_1) == "" || Buscar_Etiquetas_Anos(Etiqueta_2) != "") 
            {
                return 0;
            }

            Tabla_De_Anos Etiqueta_Final = db.Tabla_De_Anos.Single(p => p.Ano == Etiqueta_1);
            Etiqueta_Final.Ano = Etiqueta_2;
            db.SubmitChanges();

            return 1;

        }        
        public int Borrar_Etiqueta_Anos(string Etiqueta) 
        { 
            Etiqueta = Corregir_Etiqueta(Etiqueta);
            if (Buscar_Etiquetas_Anos(Etiqueta) == "" )
            {
                return 0;
            }


            
            var Dato = from p in db.Tabla_De_Anos where p.Ano == Etiqueta select p;
            db.Tabla_De_Anos.DeleteAllOnSubmit(Dato);
            db.SubmitChanges();
            return 1;
        }


        public string Buscar_Etiquetas_Temas(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Etiqueta_Final = (from p in db.Tabla_De_Temas where p.Tema == Etiqueta select p.Etiqueta_Tema).SingleOrDefault();

            if (Etiqueta_Final == 0)
            {
                return "";
            }

            return "a" + Etiqueta_Final.ToString();

        }
        public string Buscar_Etiquetas_Temas_Nuevo(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Etiqueta_Final = (from p in db.Tabla_De_Temas where p.Tema == Etiqueta select p.Etiqueta_Tema).SingleOrDefault();

            if (Etiqueta_Final == 0)
            {
                return "";
            }
            return "a" + Etiqueta_Final.ToString();
        }
        public int Cantidad_De_Datos_Temas(string Etiqueta)
        {
            int J = 0;

            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Valor = (from p in db.Tabla_De_Temas where p.Tema == Etiqueta select p.Etiqueta_Tema).SingleOrDefault();

            List<int> Cantidad_De_Datos = (from p in db.Tabla_De_Temas where p.Etiqueta_Tema == Valor select p.ID_Tema).ToList();

            foreach (int s in Cantidad_De_Datos)
            {

                J = J + 1;

            }

            return J;

        }
        public void Relacionar_Etiqueta_Temas(string Etiqueta, string Codigo)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Codigo_Numerico = int.Parse(Codigo.Substring(1));

            int Valor = (from p in db.Tabla_De_Temas where p.Tema == Etiqueta select p.Etiqueta_Tema).SingleOrDefault();

            if (Valor != 0)
            {
                Tabla_De_Temas Etiqueta_Final = db.Tabla_De_Temas.Single(p => p.Tema == Etiqueta);
                Etiqueta_Final.Etiqueta_Tema = Codigo_Numerico;
                db.SubmitChanges();
            }
            else
            {
                Tabla_De_Temas Etiqueta_Final = new Tabla_De_Temas();
                Etiqueta_Final.Etiqueta_Tema = Codigo_Numerico;
                Etiqueta_Final.Tema = Etiqueta;
                db.Tabla_De_Temas.InsertOnSubmit(Etiqueta_Final);
                db.SubmitChanges();
            }

        }
        public void Agregar_Etiqueta_Temas(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);
            Tabla_De_Temas Etiqueta_Final = new Tabla_De_Temas();
            int Codigo_Numerico = db.Tabla_De_Temas.Max(p => p.Etiqueta_Tema);
            Etiqueta_Final.Etiqueta_Tema = Codigo_Numerico + 1;
            Etiqueta_Final.Tema = Etiqueta;
            db.Tabla_De_Temas.InsertOnSubmit(Etiqueta_Final);
            db.SubmitChanges();

        }
        public int Modificar_Etiqueta_Temas(string Etiqueta_1, string Etiqueta_2)
        {
            Etiqueta_1 = Corregir_Etiqueta(Etiqueta_1);
            Etiqueta_2 = Corregir_Etiqueta(Etiqueta_2);

            if (Buscar_Etiquetas_Temas(Etiqueta_1) == "" || Buscar_Etiquetas_Temas(Etiqueta_2) != "")
            {
                return 0;
            }

            Tabla_De_Temas Etiqueta_Final = db.Tabla_De_Temas.Single(p => p.Tema == Etiqueta_1);
            Etiqueta_Final.Tema = Etiqueta_2;
            db.SubmitChanges();

            return 1;

        }
        public int Borrar_Etiqueta_Temas(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);
            if (Buscar_Etiquetas_Temas(Etiqueta) == "")
            {
                return 0;
            }



            var Dato = from p in db.Tabla_De_Temas where p.Tema == Etiqueta select p;
            db.Tabla_De_Temas.DeleteAllOnSubmit(Dato);
            db.SubmitChanges();
            return 1;
        }


        public string Buscar_Etiquetas_Colegios(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Etiqueta_Final = (from p in db.Tabla_De_Colegios where p.Colegio == Etiqueta select p.Etiqueta_Colegio).SingleOrDefault();

            if (Etiqueta_Final == 0)
            {
                return "";
            }

            return "a" + Etiqueta_Final.ToString();

        }
        public string Buscar_Etiquetas_Colegios_Nuevo(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Etiqueta_Final = (from p in db.Tabla_De_Colegios where p.Colegio == Etiqueta select p.Etiqueta_Colegio).SingleOrDefault();

            if (Etiqueta_Final == 0)
            {
                return "";
            }
            return "a" + Etiqueta_Final.ToString();
        }
        public int Cantidad_De_Datos_Colegios(string Etiqueta)
        {
            int J = 0;

            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Valor = (from p in db.Tabla_De_Colegios where p.Colegio == Etiqueta select p.Etiqueta_Colegio).SingleOrDefault();

            List<int> Cantidad_De_Datos = (from p in db.Tabla_De_Colegios where p.Etiqueta_Colegio == Valor select p.ID_Colegio).ToList();

            foreach (int s in Cantidad_De_Datos)
            {

                J = J + 1;

            }

            return J;

        }
        public void Relacionar_Etiqueta_Colegios(string Etiqueta, string Codigo)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Codigo_Numerico = int.Parse(Codigo.Substring(1));

            int Valor = (from p in db.Tabla_De_Colegios where p.Colegio == Etiqueta select p.Etiqueta_Colegio).SingleOrDefault();

            if (Valor != 0)
            {
                Tabla_De_Colegios Etiqueta_Final = db.Tabla_De_Colegios.Single(p => p.Colegio == Etiqueta);
                Etiqueta_Final.Etiqueta_Colegio = Codigo_Numerico;
                db.SubmitChanges();
            }
            else
            {
                Tabla_De_Colegios Etiqueta_Final = new Tabla_De_Colegios();
                Etiqueta_Final.Etiqueta_Colegio = Codigo_Numerico;
                Etiqueta_Final.Colegio = Etiqueta;
                db.Tabla_De_Colegios.InsertOnSubmit(Etiqueta_Final);
                db.SubmitChanges();
            }

        }
        public void Agregar_Etiqueta_Colegios(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);
            Tabla_De_Colegios Etiqueta_Final = new Tabla_De_Colegios();
            int Codigo_Numerico = db.Tabla_De_Colegios.Max(p => p.Etiqueta_Colegio);
            Etiqueta_Final.Etiqueta_Colegio = Codigo_Numerico + 1;
            Etiqueta_Final.Colegio = Etiqueta;
            db.Tabla_De_Colegios.InsertOnSubmit(Etiqueta_Final);
            db.SubmitChanges();

        }
        public int Modificar_Etiqueta_Colegios(string Etiqueta_1, string Etiqueta_2)
        {
            Etiqueta_1 = Corregir_Etiqueta(Etiqueta_1);
            Etiqueta_2 = Corregir_Etiqueta(Etiqueta_2);

            if (Buscar_Etiquetas_Colegios(Etiqueta_1) == "" || Buscar_Etiquetas_Colegios(Etiqueta_2) != "")
            {
                return 0;
            }

            Tabla_De_Colegios Etiqueta_Final = db.Tabla_De_Colegios.Single(p => p.Colegio == Etiqueta_1);
            Etiqueta_Final.Colegio = Etiqueta_2;
            db.SubmitChanges();

            return 1;

        }
        public int Borrar_Etiqueta_Colegios(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);
            if (Buscar_Etiquetas_Colegios(Etiqueta) == "")
            {
                return 0;
            }



            var Dato = from p in db.Tabla_De_Colegios where p.Colegio == Etiqueta select p;
            db.Tabla_De_Colegios.DeleteAllOnSubmit(Dato);
            db.SubmitChanges();
            return 1;
        }


        public string Buscar_Etiquetas_Profesores(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Etiqueta_Final = (from p in db.Tabla_De_Profesores where p.Profesor == Etiqueta select p.Etiqueta_Profesor).SingleOrDefault();

            if (Etiqueta_Final == 0)
            {
                return "";
            }

            return "a" + Etiqueta_Final.ToString();

        }
        public string Buscar_Etiquetas_Profesores_Nuevo(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Etiqueta_Final = (from p in db.Tabla_De_Profesores where p.Profesor == Etiqueta select p.Etiqueta_Profesor).SingleOrDefault();

            if (Etiqueta_Final == 0)
            {
                return "";
            }
            return "a" + Etiqueta_Final.ToString();
        }
        public void Agregar_Etiqueta_Profesores(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);
            Tabla_De_Profesores Etiqueta_Final = new Tabla_De_Profesores();
            int Codigo_Numerico = db.Tabla_De_Profesores.Max(p => p.Etiqueta_Profesor);
            Etiqueta_Final.Etiqueta_Profesor = Codigo_Numerico + 1;
            Etiqueta_Final.Profesor = Etiqueta;
            db.Tabla_De_Profesores.InsertOnSubmit(Etiqueta_Final);
            db.SubmitChanges();

        }
        public int Modificar_Etiqueta_Profesores(string Etiqueta_1, string Etiqueta_2)
        {
            Etiqueta_1 = Corregir_Etiqueta(Etiqueta_1);
            Etiqueta_2 = Corregir_Etiqueta(Etiqueta_2);

            if (Buscar_Etiquetas_Profesores(Etiqueta_1) == "" || Buscar_Etiquetas_Profesores(Etiqueta_2) != "")
            {
                return 0;
            }

            Tabla_De_Profesores Etiqueta_Final = db.Tabla_De_Profesores.Single(p => p.Profesor == Etiqueta_1);
            Etiqueta_Final.Profesor = Etiqueta_2;
            db.SubmitChanges();

            return 1;

        }
        public int Borrar_Etiqueta_Profesores(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);
            if (Buscar_Etiquetas_Profesores(Etiqueta) == "")
            {
                return 0;
            }



            var Dato = from p in db.Tabla_De_Profesores where p.Profesor == Etiqueta select p;
            db.Tabla_De_Profesores.DeleteAllOnSubmit(Dato);
            db.SubmitChanges();
            return 1;
        }


        public string Buscar_Etiquetas_Materias(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Etiqueta_Final = (from p in db.Tabla_De_Materias where p.Materia == Etiqueta select p.Etiqueta_Materia).SingleOrDefault();

            if (Etiqueta_Final == 0)
            {
                return "";
            }

            return "a" + Etiqueta_Final.ToString();

        }
        public string Buscar_Etiquetas_Materias_Nuevo(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);

            int Etiqueta_Final = (from p in db.Tabla_De_Materias where p.Materia == Etiqueta select p.Etiqueta_Materia).SingleOrDefault();

            if (Etiqueta_Final == 0)
            {
                return "";
            }
            return "a" + Etiqueta_Final.ToString();
        }
        public void Agregar_Etiqueta_Materias(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);
            Tabla_De_Materias Etiqueta_Final = new Tabla_De_Materias();
            int Codigo_Numerico = db.Tabla_De_Materias.Max(p => p.Etiqueta_Materia);
            Etiqueta_Final.Etiqueta_Materia = Codigo_Numerico + 1;
            Etiqueta_Final.Materia = Etiqueta;
            db.Tabla_De_Materias.InsertOnSubmit(Etiqueta_Final);
            db.SubmitChanges();

        }
        public int Modificar_Etiqueta_Materias(string Etiqueta_1, string Etiqueta_2)
        {
            Etiqueta_1 = Corregir_Etiqueta(Etiqueta_1);
            Etiqueta_2 = Corregir_Etiqueta(Etiqueta_2);

            if (Buscar_Etiquetas_Materias(Etiqueta_1) == "" || Buscar_Etiquetas_Materias(Etiqueta_2) != "")
            {
                return 0;
            }

            Tabla_De_Materias Etiqueta_Final = db.Tabla_De_Materias.Single(p => p.Materia == Etiqueta_1);
            Etiqueta_Final.Materia = Etiqueta_2;
            db.SubmitChanges();

            return 1;

        }
        public int Borrar_Etiqueta_Materias(string Etiqueta)
        {
            Etiqueta = Corregir_Etiqueta(Etiqueta);
            if (Buscar_Etiquetas_Materias(Etiqueta) == "")
            {
                return 0;
            }



            var Dato = from p in db.Tabla_De_Materias where p.Materia == Etiqueta select p;
            db.Tabla_De_Materias.DeleteAllOnSubmit(Dato);
            db.SubmitChanges();
            return 1;
        }
    }
}
