using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Busqueda
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;
        string Etiqueta_Armada;

        public List<Tabla_De_Ejercicios> Mostrar_Ejercicios_Porcentaje(string Enunciado_1, string Enunciado_2)
        {
            return db.Mostrar_Ejercicios_Por_Porcentaje_Del_Enunciado(Enunciado_1, Enunciado_2).ToList();
        }

        public List<Mostrar_Ejercicios_Por_Profundidad_Del_EnunciadoResult> Mostrar_Ejercicios_Profundidad(string Enunciado)
        {
            return db.Mostrar_Ejercicios_Por_Profundidad_Del_Enunciado(Enunciado).ToList();
        }

        public List<Vista_Buscar_Ejercicios> Mostrar_Ejercicios_Clave(string Var_1, string Var_2, string Var_3, string Var_4, string Var_5, string Var_6, string Var_7, string Var_8, string Var_9, string Var_10)
        {
            return db.Mostrar_Ejercicios_Por_Palabras_Claves_Del_Enunciado(Var_1, Var_2, Var_3, Var_4, Var_5, Var_6, Var_7, Var_8, Var_9, Var_10).ToList();
        }

        public int? Contar_Ejercicios_Porcentaje(string Enunciado_1, string Enunciado_2)
        {
            db.Contar_Ejercicios_Por_Porcentaje_Del_Enunciado(Enunciado_1, Enunciado_2, ref Cantidad);
            return Cantidad;
        }

        public int? Contar_Ejercicios_Profundidad(string Enunciado)
        {
            db.Contar_Ejercicios_Por_Profundidad_Del_Enunciado(Enunciado, ref Cantidad);
            return Cantidad;
        }

        public int? Contar_Ejercicios_Clave(string Var_1, string Var_2, string Var_3, string Var_4, string Var_5, string Var_6, string Var_7, string Var_8, string Var_9, string Var_10)
        {
            db.Contar_Ejercicios_Por_Palabras_Claves_Del_Enunciado(Var_1, Var_2, Var_3, Var_4, Var_5, Var_6, Var_7, Var_8, Var_9, Var_10, ref Cantidad);
            return Cantidad;
        }

        public string Correcion_Enunciado_MATH(string Enunciado)
        {
            Enunciado = Enunciado.Remove(0, 49); // quitar los cararcteres de adelante
            Enunciado = Enunciado.Remove(Enunciado.Length - 7, 7).ToLower(); // sacar los de atras y poner en minusculas
            Enunciado = Enunciado.Replace("&#x000A0;", " ");
            Enunciado = Enunciado.Replace("<mo></mo>", "");
            Enunciado = Enunciado.Replace("&#x000e1;", "a");
            Enunciado = Enunciado.Replace("&#x000e9;", "e");
            Enunciado = Enunciado.Replace("&#x000ed;", "i");
            Enunciado = Enunciado.Replace("&#x000f3;", "o");
            Enunciado = Enunciado.Replace("&#x000fa;", "u");
            Enunciado = Enunciado.Replace("&#x000f1;", "n");
            Enunciado = Enunciado.Replace("&#x000d1;", "n");
            Enunciado = Enunciado.Replace("&#x000c1;", "a");
            Enunciado = Enunciado.Replace("&#x000c9;", "e");
            Enunciado = Enunciado.Replace("&#x000cd;", "i");
            Enunciado = Enunciado.Replace("&#x000d3;", "o");
            Enunciado = Enunciado.Replace("&#x000dc;", "u");
            Enunciado = Enunciado.Replace("&#x000da;", "u");
            Enunciado = Enunciado.Replace("&#x000bf;", "¿");
            return Enunciado = Enunciado.Replace("&#x000fc;", "u");
        }

        public string Logica_Buscar_Por_Profundidad(string Enunciado, int Profundidad)
        {
            string Resultado = Correcion_Enunciado_MATH(Enunciado);            
            string Respuesta = Resultado.Substring(0, Profundidad);
            return Respuesta;
        }

        public class Dos_Datos_String_Para_Enunciado_Por_Porcentaje // clase extra utilizada para que alguna clase me devuelva dos valores
        {
            public string Valor_1 { get; set; }
            public string Valor_2 { get; set; }
        }


        public Dos_Datos_String_Para_Enunciado_Por_Porcentaje Logica_Por_Porcentaje(string Enunciado)
        {
            Dos_Datos_String_Para_Enunciado_Por_Porcentaje Datos = new Dos_Datos_String_Para_Enunciado_Por_Porcentaje();
            Enunciado = Correcion_Enunciado_MATH(Enunciado);
            string[] Palabras = Enunciado.Split(' ');
            int Cantidad_De_Palabras = Enunciado.Split(' ').Length + 1;
            int Resultado = (Cantidad_De_Palabras * 25) / 100;
            
            string Enunciado_1 = string.Empty;
            string Enunciado_2 = string.Empty;

            if(Palabras.Length == 3)
            {
                Datos.Valor_1 = "\"" + Palabras[0] + "\"";  // Variable 1
                Datos.Valor_2 = "\"" + Palabras[2] + "\"";  // Variable 2          
                return Datos;
            }
            if (Palabras.Length <= 2)
            {
                Datos.Valor_1 = null;
                return Datos;            
            }


            for (int I = 0; I < Resultado; I++)
            {
                Enunciado_1 = Enunciado_1 + " " + Palabras[I];
                Enunciado_2 = Enunciado_2 + " " + Palabras[(2 * Resultado) + I];
            }

            Enunciado_1 = Enunciado_1.Trim();
            Enunciado_2 = Enunciado_2.Trim();
          
            Datos.Valor_1 = "\"" + Enunciado_1 + "\"";  // Variable 1
            Datos.Valor_2 = "\"" + Enunciado_2 + "\"";  // Variable 2          
            return Datos;
        }

       

        public List<Tabla_De_Ejercicios> Mostrar_Ejercicios_Ficha_Completa(string Profesor, string Ano, string Colegio, string Materia, string Tema)
        {
            return db.Mostrar_Ejercicios_Por_Ficha_Completa(Profesor, Ano, Colegio,Materia, Tema ).ToList();
        }               

        public int? Contar_Ejercicios_Ficha_Completa(string Profesor, string Ano, string Colegio, string Materia, string Tema)
        {
            db.Contar_Ejercicios_Por_Ficha_Completa(Profesor, Ano, Colegio, Materia, Tema, ref Cantidad);
            return Cantidad;
        }

        public List<Mostrar_Ejercicios_Por_InstitucionResult> Mostrar_Ejercicio_Institucion(int Tipo_De_Institucion)
        {
            return db.Mostrar_Ejercicios_Por_Institucion(Tipo_De_Institucion).ToList();
        }

        public int? Contar_Ejercicio_Institucion(int Tipo_De_Institucion)
        {
            db.Contar_Ejercicios_Por_Institucion(Tipo_De_Institucion, ref Cantidad);
            return Cantidad;
        }


        public string Buscar_Profesor(string Dato) // vamos a formar la etiqueta de consulta para el profesor
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == " ") // dato llega vacio 
            {
                return "\"p*\"";  // devuelve la cadena string con un comodin especial para constains
            }
            IEnumerable<Tabla_De_Profesores> Etiqueta_Tabla_Profesor = (db.Buscar_En_Tabla_Profesores(Dato).ToList());  // busca en la tabla profesores y me devuelve una lista              
            foreach (Tabla_De_Profesores s in Etiqueta_Tabla_Profesor) // paso la lista a una variable string
            {
                Etiqueta_Armada = Etiqueta_Armada + "p" + s.Etiqueta_Profesor + " or "; //separo cada componente de la lista con un or especial para la busqueda constains
            }
            if (Etiqueta_Armada == string.Empty)
            {
                return "p0";
            }
            Etiqueta_Armada = Etiqueta_Armada.Trim().Substring(0, Etiqueta_Armada.Length - 3);

            return Etiqueta_Armada; // agregar la etiqueta cero que es la etiqueta por defecto
        }

        public string Buscar_Materia(string Dato) // vamos a formar la etiqueta de consulta para el materia
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == " ") // dato llega vacio
            {
                return "\"m*\"";// devuelve la cadena string con un comodin especial para constains
            }
            IEnumerable<Tabla_De_Materias> Etiqueta_Tabla_Materia = (db.Buscar_En_Tabla_Materias(Dato).ToList());// busca en la tabla materias y me devuelve una lista    
            
            
            foreach (Tabla_De_Materias s in Etiqueta_Tabla_Materia) // paso la lista a una variable string
            {
                Etiqueta_Armada = Etiqueta_Armada + "m" + s.Etiqueta_Materia + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
            }
            if (Etiqueta_Armada == string.Empty)
            {
                return "m0";
            }
            Etiqueta_Armada = Etiqueta_Armada.Trim().Substring(0, Etiqueta_Armada.Length - 3);

            return Etiqueta_Armada;// agregar la etiqueta cero que es la etiqueta por defecto
        }

        public string Buscar_Tema(string Dato) // etiqueta la consulta
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == " ") // dato llega vacio
            {
                return "\"t*\"";// devuelve la cadena string con un comodin especial para constains
            }
            IEnumerable<Tabla_De_Temas> Etiqueta_Tabla_Tema = (db.Buscar_En_Tabla_Temas(Dato).ToList());// busca en la tabla temas y me devuelve una lista                 
            foreach (Tabla_De_Temas s in Etiqueta_Tabla_Tema)  // paso la lista a una variable string 
            {
                Etiqueta_Armada = Etiqueta_Armada + "t" + s.Etiqueta_Tema + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
            }
            if (Etiqueta_Armada == string.Empty)
            {
                return "t0";
            }

            Etiqueta_Armada = Etiqueta_Armada.Trim().Substring(0, Etiqueta_Armada.Length - 3);

            return Etiqueta_Armada;// agregar la etiqueta cero que es la etiqueta por defecto

        }

        public string Buscar_Ano(string Dato) // etiqueta la consulta
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == " ") // dato llega vacio
            {
                return "\"a*\"";// devuelve la cadena string con un comodin especial para constains
            }
            IEnumerable<Tabla_De_Anos> Etiqueta_Tabla_Ano = (db.Buscar_En_Tabla_Anos(Dato).ToList());// busca en la tabla Años y me devuelve una lista  
            foreach (Tabla_De_Anos s in Etiqueta_Tabla_Ano) // paso la lista a una variable string  
            {
                Etiqueta_Armada = Etiqueta_Armada + "a" + s.Etiqueta_Ano + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
            }
            if (Etiqueta_Armada == string.Empty)
            {
                return "a0";
            }
            Etiqueta_Armada = Etiqueta_Armada.Trim().Substring(0, Etiqueta_Armada.Length - 3);

            return Etiqueta_Armada;// agregar la etiqueta cero que es la etiqueta por defecto
        }

        public string Buscar_Colegio(string Dato) // etiqueta la consulta
        {
            Etiqueta_Armada = string.Empty;
            if (Dato == " ") // dato llega vacio
            {
                return "\"c*\"";// devuelve la cadena string con un comodin especial para constains
            }
            IEnumerable<Tabla_De_Colegios> Etiqueta_Tabla_Colegio = (db.Buscar_En_Tabla_Colegios(Dato).ToList());// busca en la tabla Colegio y me devuelve una lista  
            foreach (Tabla_De_Colegios s in Etiqueta_Tabla_Colegio) // paso la lista a una variable string 
            {
                Etiqueta_Armada = Etiqueta_Armada + "c" + s.Etiqueta_Colegio + " or ";//separo cada componente de la lista con un or especial para la busqueda constains
            }
            if (Etiqueta_Armada == string.Empty)
            {
                return "c0";
            }
            Etiqueta_Armada = Etiqueta_Armada.Trim().Substring(0, Etiqueta_Armada.Length - 3);

            return Etiqueta_Armada;// agregar la etiqueta cero que es la etiqueta por defecto
        }


    }
}




