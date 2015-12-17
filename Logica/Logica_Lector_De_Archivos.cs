﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logica
{
    public class Logica_Lector_De_Archivos
    {
        DataClassesDataContext db = new DataClassesDataContext();
        string Etiqueta_Armada;
        string Respuesta;

        public int Actualizar_En_Tabla_Primera_Parte(int ID, string Enunciado_MATH, string Titulo, string Ubicacion_Video_Y_Explicaciones, int Tipo_De_Institucion, int Tipo_De_Ejercicio, string Explicacion_Realizada, string Ubicacion_Respuesta_Imprimible, string Ubicacion_Respuesta_Visible)
        {

            if (Ubicacion_Video_Y_Explicaciones == string.Empty)
            {
                Ubicacion_Video_Y_Explicaciones = null;
                return db.Actualizar_Datos_En_La_Base(ID, Quitar_Encabezado_MATH(Enunciado_MATH), Enunciado_Limpio(Enunciado_MATH), Titulo, Tipo_De_Institucion, Tipo_De_Ejercicio, Ubicacion_Respuesta_Imprimible, Ubicacion_Respuesta_Visible, Ubicacion_Video_Y_Explicaciones, Convert.ToBoolean(Explicacion_Realizada));
            }
            return db.Insertar_Datos_En_La_Base(Quitar_Encabezado_MATH(Enunciado_MATH), Enunciado_Limpio(Enunciado_MATH), Titulo, Tipo_De_Institucion, Tipo_De_Ejercicio, Ubicacion_Respuesta_Imprimible, Ubicacion_Respuesta_Visible, Ubicacion_Video_Y_Explicaciones, Convert.ToBoolean(Explicacion_Realizada));
        }

        public string Quitar_Encabezado_MATH(string Enunciado_MATH)
        {
            Enunciado_MATH = Enunciado_MATH.Replace("&#x000a0;", "");
            Enunciado_MATH = Enunciado_MATH.Replace("<mo></mo>", "");
            Enunciado_MATH = Enunciado_MATH.Substring(49);

            return Enunciado_MATH.Remove(Enunciado_MATH.Length - 7, 7).ToLower();
           
        }

        public string Enunciado_Limpio(string Enunciado_MATH)
        {
            string Linea = "";
            // quitare todos los caracteres que genera wiris para que el codigo quede limpio y sin espacio
            string[] Terminos_Borrados = new string[] { "<msubsup>", "<mmultiscripts>", "<presubsup>", "</presubsup>", "<mprescripts/>", "<none/>", "</mmultiscripts>", "</msubsup>", "<mo largeop=\"true\">", "<mrow/>", "<munder>", "</munder>", "<munderover>", "</munderover>", "<mover>", "</mover>", "<menclose notation=\"updiagonalstrike\">", "</menclose>", "<mfenced open=\"|\" close=\"|\">", "</mfenced>", "<mi mathvariant=\"normal\">", "<mfrac>", "</mfrac>", "<msup>", "</msup>", "<msub>", "</msub>", "<mrow>", "</mrow>", "<msqrt>", "</msqrt>", "<mroot>", "</mroot>", "<mi>", "</mi>", "<mn>", "</mn>", "<mo>", "</mo>", "<mspace linebreak=\"newline\"/>", "&#8201;", "</math>", "<math xmlns=\"http://www.w3.org/1998/Math/MathML\">", "<maction actiontype=\"argument\">", "</maction>", "<mstyle displaystyle=\"true\">", "</mstyle>", "<mfenced open=\"||\" close=\"||\">", "<menclose notation=\"circle\">", "<menclose notation=\"actuarial\">", "<menclose notation=\"roundedbox\">", "<menclose notation=\"roundedbox\"/>", "<menclose notation=\"top\">", "<menclose notation=\"left\">", "<menclose notation=\"box\"/>", "<menclose notation=\"right\">", "<menclose notation=\"bottom\"/>", "<mfenced open=\"&#8970;\" close=\"&#8971;\">", "<mfenced open=\"&lt;\" close=\"&#62;\" separators=\"|\">", "<mfenced open=\"&#8968;\" close=\"&#8969;\">", "<menclose notation=\"top\"/>", "<menclose notation=\"left\"/>", "<menclose notation=\"right\"/>", "<menclose notation=\"circle\"/>", "<menclose notation=\"actuarial\"/>", "<menclose notation=\"bottom\">", "<menclose notation=\"box\">", "<menclose notation=\"downdiagonalstrike\">", "<menclose notation=\"downdiagonalstrike updiagonalstrike\">", "<menclose notation=\"horizontalstrike\">", "<menclose notation=\"verticalstrike\">", "<menclose>", "<menclose notation=\"verticalstrike horizontalstrike\">", "<menclose notation=\"horizontalstrike\">", "<menclose notation=\"downdiagonalstrike\"/>", "<menclose notation=\"downdiagonalstrike updiagonalstrike\"/>", "<menclose notation=\"verticalstrike\"/>", "<menclose>", "<menclose notation=\"verticalstrike horizontalstrike\"/>", "<menclose/>", "<mtable>", "<mtr>", "<mtd/>", "</mtr>", "</mtable>", "<mtd>", "</mtd>", "<mfenced open=\"[\" close=\"]\">", "<mfenced>", "<mfenced open=\"[\" close=\"]\">", "<mfenced open=\"[\" close=\"]\">", "<mfenced open=\"{\" close=\"\">", "<mtable columnalign=\"left\">", "<mfenced open=\"\" close=\"}\">", 
              "&#172;","&#175;","&#176;","&#177;","&#183;","&#960;","&#729;","&#168;",
              "&#945;","&#946;","&#947;","&#948;","&#949;","&#950;",
              "&#951;","&#952;","&#977;","&#953;","&#954;","&#955;","&#956;",
              "&#957;","&#958;","&#959;","&#982;","&#961;","&#962;","&#963;",
              "&#964;","&#965;","&#966;","&#981;","&#967;","&#968;","&#969;",
              "&#913;","&#914;","&#915;","&#916;","&#917;","&#918;","&#919;",
              "&#920;","&#921;","&#922;","&#923;","&#924;","&#925;","&#926;",
              "&#927;","&#928;","&#929;","&#931;","&#932;","&#933;","&#934;",
              "&#935;","&#936;","&#937;","&#x000a0;",
              "&#8597;","&#8592;", "&#8593;","&#8595;","&#8596;","&#8594;",
              "&#8598;", "&#8599;","&#8600;","&#8601;","&#8618;","&#8629;",
              "&#8657;","&#8645;","&#8659;","&#8617;","&#8661;","&#8636;","&#8637;",
              "&#8646;","&#8651;","&#8652;","&#8640;","&#8644;","&#8641;",
              "&#8656;","&#8658;","&#8660;","&#8612;","&#8614;",
              "&#8704;","&#8706;", "&#8707;" ,"&#8708;","&#8709;",
              "&#8710;","&#8711;", "&#8712;","&#8715;","&#8721;","&#8719;",
              "&#8713;", "&#8716;","&#8728;", "&#8726;", "&#8723;", 
              "&#8729;","&#8733;","&#8734;","&#8736;","&#8737;","&#8738;","&#8741;","&#8742;",              
              "&#8743;", "&#8744;","&#8745;","&#8746;","&#8756;","&#8757;",
              "&#8769;","&#8773;","&#8776;",              
              "&#8747;","&#8750;","&#8748;","&#8751;","&#8749;","&#8752;",
              "&#8801;", "&#8804;","&#8805;", "&#8810;",
              "&#8826;","&#8834;","&#8835;", "&#8838;", "&#8839;",
              "&#8847;" ,"&#8848;", "&#8849;", "&#8850;","&#8851;",
              "&#8852;","&#8853;","&#8855;","&#8857;", "&#8859;",    
              "&#8861;","&#8869;","&#8882;", "&#8883;",       
              "&#8900;","&#9633;","&#9649;","&#9651;","&#9675;",
              "&#9180;","&#9181;","&#9183;","&#9182;",
              "&#10808;","&#10888;",
              "&#10529;","&#10530;",
              "&#10606;","&#10602;","&#10607;","&#10605;"   
              };
            string[] Enunciado_Limpio = Enunciado_MATH.Split(Terminos_Borrados, StringSplitOptions.RemoveEmptyEntries);
            foreach (string Caracter in Enunciado_Limpio) // genero una variable nueva ya corregida si los caracteres raros de wiris
            {
                Linea = Linea + Caracter;
            }
            // pongo todos los terminos en minusculas y saco los acentos
            Linea = Linea.ToLower();
            Linea = Linea.Replace("&#x000a0;", "");
            Linea = Linea.Replace("&#225;", "a");
            Linea = Linea.Replace("&#233;", "e");
            Linea = Linea.Replace("&#237;", "i");
            Linea = Linea.Replace("&#243;", "o");
            Linea = Linea.Replace("&#250;", "u");
            Linea = Linea.Replace("&#160;", " ");
            Linea = Linea.Replace("&#193;", "a");
            Linea = Linea.Replace("&#201;", "e");
            Linea = Linea.Replace("&#205;", "i");
            Linea = Linea.Replace("&#211;", "o");
            Linea = Linea.Replace("&#218;", "u");
            Linea = Linea.Replace("&#209;", "n");
            

            Linea = Linea.Trim(); // elimino los espacios delante y detras de la variable creada
            return Linea; // variable final limpia de wiris
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

        public void Actualizar_En_Tabla_Segunda_Parte(string Tema1_S, string Tema2_S, string Tema3_S, string Tema1, string Tema2, string Tema3, string Materia1, string Materia2, string Materia3, string Colegio1, string Colegio2, string Colegio3, string Ano1, string Ano2, string Ano3, string Profesor1, string Profesor2, string Profesor3)
        {
            db.Sinonimos_Temas(Corregir_Etiqueta(Tema1), Corregir_Etiqueta(Tema2), Corregir_Etiqueta(Tema3));
            db.Temas(Corregir_Etiqueta(Tema1_S), Corregir_Etiqueta(Tema2_S), Corregir_Etiqueta(Tema3_S));
            db.Materias(Corregir_Etiqueta(Materia1), Corregir_Etiqueta(Materia2), Corregir_Etiqueta(Materia3));
            db.Sinonimos_Colegios(Corregir_Etiqueta(Colegio1), Corregir_Etiqueta(Colegio2), Corregir_Etiqueta(Colegio3));
            db.Sinonimos_Anos(Corregir_Etiqueta(Ano1), Corregir_Etiqueta(Ano2), Corregir_Etiqueta(Ano3));
            db.Profesores(Corregir_Etiqueta(Profesor1), Corregir_Etiqueta(Profesor2), Corregir_Etiqueta(Profesor3));

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

        public string Obtener_Profesor()
        {
            db.Obtener_Etiqueta_Profesores(ref Respuesta);
            return Respuesta;
        }
        public string Obtener_Tema()
        {
            db.Obtener_Etiqueta_Tema(ref Respuesta);
            return Respuesta;
        }
        public string Obtener_Colegio()
        {
            db.Obtener_Etiqueta_Colegios(ref Respuesta);
            return Respuesta;
        }

        public string Obtener_Ano()
        {
            db.Obtener_Etiqueta_Anos(ref Respuesta);
            return Respuesta;
        }

        public string Obtener_Materia()
        {
            db.Obtener_Etiqueta_Materias(ref Respuesta);
            return Respuesta;
        }
        

        public void Actualizar_Un_Archivo_TXT(string Nombre_Archivo, string Enunciado,
            string Titulo, string Institucion, string Ejercicio,string Impresion, string Visible,
            string Video, string Explicacion, string Tema1_S, string Tema2_S,
            string Tema3_S, string Tema1, string Tema2,
            string Tema3, string Materia1, string Materia2,
            string Materia3, string Colegio1, string Colegio2,
            string Colegio3, string Ano1, string Ano2,
            string Ano3, string Profesor1, string Profesor2, string Profesor3,
            string Etiqueta_Ano, string Etiqueta_Colegio, string Etiqueta_Materia, string Etiqueta_Tema, string Etiqueta_Profesor) // carga dos archivos en c: correspondiente a los enunciados
        {


            StreamWriter Archivo = File.CreateText("C:\\archivo/" + Nombre_Archivo); // carga el archivo corregido del enunciado en c:
            string Enunciado_Corregido = Enunciado_Limpio(Enunciado);
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
            Archivo.Write(Etiqueta_Profesor);
            Archivo.Write("╝");
            Archivo.Write(Etiqueta_Tema);
            Archivo.Flush();
            Archivo.Close();

        }

        public void Actualizar_En_Tabla_Tercera_Parte(int Identificador, string Tema1_S, string Tema2_S, string Tema3_S, string Tema1, string Tema2, string Tema3, string Materia1, string Materia2, string Materia3, string Colegio1, string Colegio2, string Colegio3, string Ano1, string Ano2, string Ano3, string Profesor1, string Profesor2, string Profesor3)
        {
            db.Actualizar_En_La_Tabla_De_Busqueda(Identificador,Union_Etiqueta_Tema(Corregir_Etiqueta(Tema1_S), Corregir_Etiqueta(Tema2_S), Corregir_Etiqueta(Tema3_S), Corregir_Etiqueta(Tema1), Corregir_Etiqueta(Tema2), Corregir_Etiqueta(Tema3)), Buscar_Materia(Corregir_Etiqueta(Materia1), Corregir_Etiqueta(Materia2), Corregir_Etiqueta(Materia3)), Buscar_Colegio(Corregir_Etiqueta(Colegio1), Corregir_Etiqueta(Colegio2), Corregir_Etiqueta(Colegio3)), Buscar_Ano(Corregir_Etiqueta(Ano1), Corregir_Etiqueta(Ano2), Corregir_Etiqueta(Ano3)), Buscar_Profesor(Corregir_Etiqueta(Profesor1), Corregir_Etiqueta(Profesor2), Corregir_Etiqueta(Profesor3)));
        }


        public string Buscar_Profesor(string Dato1, string Dato2, string Dato3) // vamos a formar la etiqueta de consulta para el profesor
        {

            string[] Datos = new string[3];
            string[] Etiqueta = new string[3];

            Datos[0] = Dato1;
            Datos[1] = Dato2;
            Datos[2] = Dato3;

            for (int I = 0; I <= 2; I++)
            {
                Etiqueta[I] = string.Empty;
                if (Datos[I] == null)
                {
                    Etiqueta[I] = null;
                    break;
                }
                else
                {
                    List<int> Valor = (from p in db.Tabla_De_Profesores where p.Profesor == Datos[I] select p.Etiqueta_Profesor).ToList();

                    foreach (int s in Valor)
                    {
                        Etiqueta[I] = Etiqueta[I] + "p" + s + " ";

                    }
                }
            }

            string Union = Etiqueta[0] + Etiqueta[1] + Etiqueta[2];

            string[] Respuesta = Union.Trim().Split(' ');

            if (Respuesta[0] == string.Empty)
            {
                return "p";
            }

            Etiqueta[0] = string.Empty;

            foreach (string s in Respuesta.Distinct().ToArray())
            {
                Etiqueta[0] = Etiqueta[0] + s + " ";
            }

            return Etiqueta[0].Trim();


        }

        public string Buscar_Materia(string Dato1, string Dato2, string Dato3) // vamos a formar la etiqueta de consulta para el materia
        {

            string[] Datos = new string[3];
            string[] Etiqueta = new string[3];

            Datos[0] = Dato1;
            Datos[1] = Dato2;
            Datos[2] = Dato3;

            for (int I = 0; I <= 2; I++)
            {
                Etiqueta[I] = string.Empty;
                if (Datos[I] == null)
                {
                    Etiqueta[I] = null;
                    break;
                }
                else
                {
                    List<int> Valor = (from p in db.Tabla_De_Materias where p.Materia == Datos[I] select p.Etiqueta_Materia).ToList();

                    foreach (int s in Valor)
                    {
                        Etiqueta[I] = Etiqueta[I] + "m" + s + " ";

                    }
                }
            }

            string Union = Etiqueta[0] + Etiqueta[1] + Etiqueta[2];

            string[] Respuesta = Union.Trim().Split(' ');

            if (Respuesta[0] == string.Empty)
            {
                return "m";
            }

            Etiqueta[0] = string.Empty;

            foreach (string s in Respuesta.Distinct().ToArray())
            {
                Etiqueta[0] = Etiqueta[0] + s + " ";
            }

            return Etiqueta[0].Trim();

        }

        public string Buscar_Tema_Sinonimo(string Dato1, string Dato2, string Dato3) // etiqueta la consulta
        {

            string[] Datos = new string[3];
            string[] Etiqueta = new string[3];

            Datos[0] = Dato1;
            Datos[1] = Dato2;
            Datos[2] = Dato3;

            for (int I = 0; I <= 2; I++)
            {
                Etiqueta[I] = string.Empty;
                if (Datos[I] == null)
                {
                    Etiqueta[I] = null;
                    break;
                }
                else
                {
                    List<int> Valor = (from p in db.Tabla_De_Temas where p.Tema == Datos[I] select p.Etiqueta_Tema).ToList();

                    foreach (int s in Valor)
                    {
                        Etiqueta[I] = Etiqueta[I] + "t" + s + " ";

                    }
                }
            }

            string Union = Etiqueta[0] + Etiqueta[1] + Etiqueta[2];

            string[] Respuesta = Union.Trim().Split(' ');

            Etiqueta[0] = string.Empty;

            foreach (string s in Respuesta.Distinct().ToArray())
            {
                Etiqueta[0] = Etiqueta[0] + s + " ";
            }

            return Etiqueta[0];


        }

        public string Buscar_Tema(string Dato1, string Dato2, string Dato3) // etiqueta la consulta
        {
            string[] Datos = new string[3];
            string[] Etiqueta = new string[3];

            Datos[0] = Dato1;
            Datos[1] = Dato2;
            Datos[2] = Dato3;

            for (int I = 0; I <= 2; I++)
            {
                Etiqueta[I] = string.Empty;
                if (Datos[I] == null)
                {
                    Etiqueta[I] = null;
                    break;
                }
                else
                {
                    List<int> Valor = (from p in db.Tabla_De_Temas where p.Tema == Datos[I] select p.Etiqueta_Tema).ToList();

                    foreach (int s in Valor)
                    {
                        Etiqueta[I] = Etiqueta[I] + "t" + s + " ";

                    }
                }
            }

            string Union = Etiqueta[0] + Etiqueta[1] + Etiqueta[2];

            string[] Respuesta = Union.Trim().Split(' ');

            Etiqueta[0] = string.Empty;

            foreach (string s in Respuesta.Distinct().ToArray())
            {
                Etiqueta[0] = Etiqueta[0] + s + " ";
            }

            return Etiqueta[0];

        }

        public string Union_Etiqueta_Tema(string Dato1, string Dato2, string Dato3, string Dato4, string Dato5, string Dato6)
        {
            string Union = Buscar_Tema_Sinonimo(Dato1, Dato2, Dato3) + Buscar_Tema(Dato4, Dato5, Dato6);

            string[] Respuesta = Union.Trim().Split(' ');

            if (Respuesta[0] == string.Empty)
            {
                return "t";
            }

            Etiqueta_Armada = string.Empty;
            foreach (string s in Respuesta.Distinct().ToArray()) // paso la lista a una variable string
            {
                Etiqueta_Armada = Etiqueta_Armada + s + " "; //separo cada componente de la lista con un or especial para la busqueda constains
            }

            return Etiqueta_Armada.Trim();  // devuelve la cadena string con un comodin especial para constains

        }

        public string Buscar_Ano(string Dato1, string Dato2, string Dato3) // etiqueta la consulta
        {

            string[] Datos = new string[3];
            string[] Etiqueta = new string[3];

            Datos[0] = Dato1;
            Datos[1] = Dato2;
            Datos[2] = Dato3;

            for (int I = 0; I <= 2; I++)
            {
                Etiqueta[I] = string.Empty;
                if (Datos[I] == null)
                {
                    Etiqueta[I] = null;
                    break;
                }
                else
                {
                    List<int> Valor = (from p in db.Tabla_De_Anos where p.Ano == Datos[I] select p.Etiqueta_Ano).ToList();

                    foreach (int s in Valor)
                    {
                        Etiqueta[I] = Etiqueta[I] + "a" + s + " ";

                    }
                }
            }

            string Union = Etiqueta[0] + Etiqueta[1] + Etiqueta[2];

            string[] Respuesta = Union.Trim().Split(' ');

            if (Respuesta[0] == string.Empty)
            {
                return "a";
            }

            Etiqueta[0] = string.Empty;

            foreach (string s in Respuesta.Distinct().ToArray())
            {
                Etiqueta[0] = Etiqueta[0] + s + " ";
            }

            return Etiqueta[0].Trim();


        }

        public string Buscar_Colegio(string Dato1, string Dato2, string Dato3) // etiqueta la consulta
        {

            string[] Datos = new string[3];
            string[] Etiqueta = new string[3];

            Datos[0] = Dato1;
            Datos[1] = Dato2;
            Datos[2] = Dato3;

            for (int I = 0; I <= 2; I++)
            {
                Etiqueta[I] = string.Empty;
                if (Datos[I] == null)
                {
                    Etiqueta[I] = null;
                    break;
                }
                else
                {
                    List<int> Valor = (from p in db.Tabla_De_Colegios where p.Colegio == Datos[I] select p.Etiqueta_Colegio).ToList();

                    foreach (int s in Valor)
                    {
                        Etiqueta[I] = Etiqueta[I] + "c" + s + " ";

                    }
                }
            }

            string Union = Etiqueta[0] + Etiqueta[1] + Etiqueta[2];

            string[] Respuesta = Union.Trim().Split(' ');

            if (Respuesta[0] == string.Empty)
            {
                return "c";
            }

            Etiqueta[0] = string.Empty;

            foreach (string s in Respuesta.Distinct().ToArray())
            {
                Etiqueta[0] = Etiqueta[0] + s + " ";
            }

            return Etiqueta[0].Trim();


        }

    }
}
