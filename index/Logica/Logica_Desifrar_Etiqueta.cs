using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Desifrar_Etiqueta
    {

        DataClassesDataContext db = new DataClassesDataContext();
        string Dato;

        public string Buscar_Etiquetas_Materias(string Etiqueta)
        {
            string[] Separar_Etiqueta = Etiqueta.Split(' ');

            for (int I = 0; I < Separar_Etiqueta.Length; I++ )
            {
                Separar_Etiqueta[I] = Separar_Etiqueta[I].Replace('m',' ').Trim();

                try
                {
                    List<string> Etiquetas_Totales = (from p in db.Tabla_De_Materias where p.Etiqueta_Materia == int.Parse(Separar_Etiqueta[I]) select p.Materia).ToList();

                    foreach (string s in Etiquetas_Totales)
                    {

                        Dato = Dato + " " + s;

                    }
                }
                catch
                { 
                
                }
            }

            return Dato.Trim();
                    
        }

        public string Buscar_Etiquetas_Temas(string Etiqueta)
        {
            string[] Separar_Etiqueta = Etiqueta.Split(' ');

            for (int I = 0; I < Separar_Etiqueta.Length; I++)
            {
                Separar_Etiqueta[I] = Separar_Etiqueta[I].Replace('t', ' ').Trim();

                try
                {
                    List<string> Etiquetas_Totales = (from p in db.Tabla_De_Temas where p.Etiqueta_Tema == int.Parse(Separar_Etiqueta[I]) select p.Tema).ToList();

                    foreach (string s in Etiquetas_Totales)
                    {

                        Dato = Dato + " " + s;

                    }
                }
                catch { }

            }

            return Dato.Trim();

        }

        public string Buscar_Etiquetas_Anos(string Etiqueta)
        {
            string[] Separar_Etiqueta = Etiqueta.Split(' ');

            for (int I = 0; I < Separar_Etiqueta.Length; I++)
            {
                Separar_Etiqueta[I] = Separar_Etiqueta[I].Replace('a', ' ').Trim();

                try
                {

                    List<string> Etiquetas_Totales = (from p in db.Tabla_De_Anos where p.Etiqueta_Ano == int.Parse(Separar_Etiqueta[I]) select p.Ano).ToList();

                    foreach (string s in Etiquetas_Totales)
                    {

                        Dato = Dato + " " + s;

                    }
                }
                catch
                {
                    
                }

            }

            return Dato.Trim();

        }

        public string Buscar_Etiquetas_Colegios(string Etiqueta)
        {
            string[] Separar_Etiqueta = Etiqueta.Split(' ');

            for (int I = 0; I < Separar_Etiqueta.Length; I++)
            {
                Separar_Etiqueta[I] = Separar_Etiqueta[I].Replace('c', ' ').Trim();

                try
                {
                    List<string> Etiquetas_Totales = (from p in db.Tabla_De_Colegios where p.Etiqueta_Colegio == int.Parse(Separar_Etiqueta[I]) select p.Colegio).ToList();

                    foreach (string s in Etiquetas_Totales)
                    {

                        Dato = Dato + " " + s;

                    }
                }
                catch { }

            }

            return Dato.Trim();

        }

        public string Buscar_Etiquetas_Profesores(string Etiqueta)
        {
            string[] Separar_Etiqueta = Etiqueta.Split(' ');

            for (int I = 0; I < Separar_Etiqueta.Length; I++)
            {
                Separar_Etiqueta[I] = Separar_Etiqueta[I].Replace('p', ' ').Trim();

                try
                {

                    List<string> Etiquetas_Totales = (from p in db.Tabla_De_Profesores where p.Etiqueta_Profesor == int.Parse(Separar_Etiqueta[I]) select p.Profesor).ToList();

                    foreach (string s in Etiquetas_Totales)
                    {

                        Dato = Dato + " " + s;

                    }
                }
                catch { }

            }

            return Dato.Trim();

        }


    }
}
