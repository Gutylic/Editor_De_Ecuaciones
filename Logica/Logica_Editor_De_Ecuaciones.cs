using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logica
{
    public class Logica_Editor_De_Ecuaciones
    {

        DataClassesDataContext db = new DataClassesDataContext();
        string Etiqueta_Armada;
        string Respuesta;
        
        string Ubicacion1 = RandomString(15);
        string Ubicacion2 = RandomString(15);

        public int Insertar_En_Tabla_Primera_Parte(string Enunciado_MATH, string Titulo, string Ubicacion_Video_Y_Explicaciones, int Tipo_De_Institucion, int Tipo_De_Ejercicio, string Explicacion_Realizada)
        {
            

            if (Ubicacion_Video_Y_Explicaciones == string.Empty) 
            {
                Ubicacion_Video_Y_Explicaciones = null;
                
                return db.Insertar_Datos_En_La_Base(Quitar_Encabezado_Y_Final_MATH(Enunciado_MATH), Enunciado_Limpio(Enunciado_MATH), Titulo, Tipo_De_Institucion, Tipo_De_Ejercicio,Ubicacion1 ,Ubicacion2, Ubicacion_Video_Y_Explicaciones, Convert.ToBoolean(Explicacion_Realizada));
            }
            return db.Insertar_Datos_En_La_Base(Quitar_Encabezado_Y_Final_MATH(Enunciado_MATH), Enunciado_Limpio(Enunciado_MATH), Titulo, Tipo_De_Institucion, Tipo_De_Ejercicio, Ubicacion1, Ubicacion2, Ubicacion_Video_Y_Explicaciones, Convert.ToBoolean(Explicacion_Realizada));
        }

        public string Quitar_Encabezado_Y_Final_MATH(string Enunciado_MATH)
        {
            Enunciado_MATH = Enunciado_MATH.Substring(49);
            Enunciado_MATH = Enunciado_MATH.Replace("&#x000A0;", "");
            Enunciado_MATH = Enunciado_MATH.Replace("<mo></mo>", "");
            return Enunciado_MATH.Remove(Enunciado_MATH.Length - 7, 7).ToLower();
        }
        
        public string Enunciado_Limpio(string Enunciado_MATH)
        {
            string Linea = "";
            // quitare todos los caracteres que genera wiris para que el codigo quede limpio y sin espacio

            string[] Terminos_Borrados = new string[] { "<msubsup>", "<mmultiscripts>", "<presubsup>", "</presubsup>", "<mprescripts/>", "<none/>", "</mmultiscripts>", "</msubsup>", "<mo largeop=\"true\">", "<mrow/>", "<munder>", "</munder>", "<munderover>", "</munderover>", "<mover>", "</mover>", "<menclose notation=\"updiagonalstrike\">", "<menclose notation=\"updiagonalstrike\"/>", "</menclose>", "<mfenced open=\"|\" close=\"|\">", "</mfenced>", "<mi mathvariant=\"normal\">", "<mfrac>", "</mfrac>", "<msup>", "</msup>", "<msub>", "</msub>", "<mrow>", "</mrow>", "<msqrt>", "</msqrt>", "<mroot>", "</mroot>", "<mi>", "</mi>", "<mn>", "</mn>", "<mo>", "</mo>", "&#8201;", "</math>","<msqrt/>", "<math xmlns=\"http://www.w3.org/1998/Math/MathML\">", "<maction actiontype=\"argument\">", "</maction>", "<mstyle displaystyle=\"true\">", "</mstyle>", "<mfenced open=\"||\" close=\"||\">", "<menclose notation=\"circle\">", "<menclose notation=\"actuarial\">", "<menclose notation=\"roundedbox\">", "<menclose notation=\"roundedbox\"/>", "<menclose notation=\"top\">", "<menclose notation=\"left\">", "<menclose notation=\"box\"/>", "<menclose notation=\"right\">", "<menclose notation=\"bottom\"/>", "<mfenced open=\"&#8970;\" close=\"&#8971;\">", "<mfenced open=\"&lt;\" close=\"&#62;\" separators=\"|\">", "<mfenced open=\"&#8968;\" close=\"&#8969;\">", "<menclose notation=\"top\"/>", "<menclose notation=\"left\"/>", "<menclose notation=\"right\"/>", "<menclose notation=\"circle\"/>", "<menclose notation=\"actuarial\"/>", "<menclose notation=\"bottom\">", "<menclose notation=\"box\">", "<menclose notation=\"downdiagonalstrike\">", "<menclose notation=\"downdiagonalstrike updiagonalstrike\">", "<menclose notation=\"horizontalstrike\">", "<menclose notation=\"verticalstrike\">", "<menclose>", "<menclose notation=\"verticalstrike horizontalstrike\">", "<menclose notation=\"horizontalstrike\">", "<menclose notation=\"downdiagonalstrike\"/>", "<menclose notation=\"downdiagonalstrike updiagonalstrike\"/>", "<menclose notation=\"verticalstrike\"/>", "<menclose>", "<menclose notation=\"verticalstrike horizontalstrike\"/>", "<menclose/>", "<mtable>", "<mtr>", "<mtd/>", "</mtr>", "</mtable>", "<mtd>", "</mtd>", "<mfenced open=\"[\" close=\"]\">", "<mfenced>", "<mfenced open=\"[\" close=\"]\">", "<mfenced open=\"[\" close=\"]\">", "<mfenced open=\"{\" close=\"\">", "<mtable columnalign=\"left\">", "<mfenced open=\"\" close=\"}\">", 
                "&#172;","&#175;","&#176;","&#177;","&#183;","&#960;","&#729;","&#168;","&#945;","&#946;","&#947;","&#948;","&#949;","&#950;","&#951;","&#952;","&#977;","&#953;","&#954;","&#955;","&#956;","&#957;","&#958;","&#959;","&#982;","&#961;","&#962;","&#963;","&#964;","&#965;","&#966;","&#981;","&#967;","&#968;","&#969;","&#913;","&#914;","&#915;","&#916;","&#917;","&#918;","&#919;","&#920;","&#921;","&#922;","&#923;","&#924;","&#925;","&#926;","&#927;","&#928;","&#929;","&#931;","&#932;","&#933;","&#934;","&#935;","&#936;","&#937;","&#8597;","&#8592;", "&#8593;","&#8595;","&#8596;","&#8594;","&#8598;", "&#8599;","&#8600;","&#8601;","&#8618;","&#8629;","&#8657;","&#8645;","&#8659;","&#8617;","&#8661;","&#8636;","&#8637;","&#8646;","&#8651;","&#8652;","&#8640;","&#8644;","&#8641;","&#8656;","&#8658;","&#8660;","&#8612;","&#8614;","&#8704;","&#8706;", "&#8707;" ,"&#8708;","&#8709;","&#8710;","&#8711;", "&#8712;","&#8715;","&#8721;","&#8719;","&#8713;", "&#8716;","&#8728;", "&#8726;", "&#8723;","&#8729;","&#8733;","&#8734;","&#8736;","&#8737;","&#8738;","&#8741;","&#8742;","&#8743;", "&#8744;","&#8745;","&#8746;","&#8756;","&#8757;","&#8769;","&#8773;","&#8776;", "&#8747;","&#8750;","&#8748;","&#8751;","&#8749;","&#8752;","&#8801;", "&#8804;","&#8805;", "&#8810;", "&#8826;","&#8834;","&#8835;", "&#8838;", "&#8839;","&#8847;" ,"&#8848;", "&#8849;", "&#8850;","&#8851;","&#8852;","&#8853;","&#8855;","&#8857;", "&#8859;", "&#8861;","&#8869;","&#8882;", "&#8883;","&#8900;","&#9633;","&#9649;","&#9651;","&#9675;","&#9180;","&#9181;","&#9183;","&#9182;","&#10808;","&#10888;","&#10529;","&#10530;","&#10606;","&#10602;","&#10607;","&#10605;","&#x000B1;","&#x0222A;","&#x003C0;","&#x0221E;","&#x02208;","&#x02282;","&#x02229;","&#x02265;","&#x02264;","&#x02205;","&#x003bd","<mi mathvariant=\"fraktur\">","<mi mathvariant=\"script\">",
                "&#x000B7;","&#x02218;","&#x02216;","&#x02213;","&#x02207;","&#x02206;","&#x02202;","&#x02035;","&#x02261;","&#x02243;","&#x02248;","&#x02245;","&#x02260;","&#x02262;","&#x02241;","&#x02249;","&#x02A87;","&#x0226B;","&#x0227B;","&#x02A88;","&#x0221D;","&#x022B2;","&#x0226A;","&#x0227A;","&#x022B3;","&#x0220B;","&#x02283;","&#x02209;","&#x0220C;","&#x02286;","&#x02287;","&#x0228F;","&#x02290;","&#x02291;","&#x02292;","&#x02293;","&#x02294;","&#x02203;","&#x000AC;","&#x02227;","&#x02228;","&#x02200;","&#x02204;","&#x02234;","&#x02235;","&#x02220;","&#x02225;","&#x022A5;","&#x02226;","&#x02221;","&#x02222;","&#x022C4;","&#x025A1;","&#x025B3;","&#x025CB;","&#x025AD;","&#x025B1;","&#x02295;","&#x02297;","&#x02299;","&#x0229D;","&#x0229B;","&#x02219;","&#x02A38;","&#x000B0;","&#x02190;","&#x02192;","&#x02194;","&#x021D0;","&#x021D2;","&#x021D4;","&#x021A4;","&#x021A6;","&#x02197;","&#x02198;","&#x02196;","&#x02199;","&#x02921;","&#x02922;","&#x021A9;","&#x021AA;","&#x021BC;","&#x021C0;","&#x02191;","&#x02193;","&#x021D1;","&#x021D3;","&#x0296A;","<mtable columnalign=\"right\">","&#x0296D;","&#x021CB;","&#x021CC;","&#x021BD;","&#x021C1;","&#x021C6;","&#x021C4;","&#x021C5;","&#x021F5;","&#x0296E;","&#x0296F;","&#x02195;","&#x021D5;","&#x021B5;","&#x022EE;","&#x02026;","&#x022F1;","&#x022EF;","&#x02192;","&#x02192;","&#x02192;","&#x02190;","&#x02190;","&#x000AF;","&#x02194;","&#x021C0;","&#x02192;","&#x022F0;","&#x003B1;","&#x003B3;","&#x003B2;","&#x003B4;","&#x003B5;","&#x003B6;","&#x003B7;","&#x003B8;","&#x003D1;","&#x003B9;","&#x003C2;","&#x003C1;","&#x003D6;","&#x003BF;","&#x003BE;","&#x003BC;","&#x003BB;","&#x003BA;","&#x003C3;","&#x003C4;","&#x003C5;","&#x003C6;","&#x003D5;","&#x003C7;","&#x003C8;","&#x003C9;","&#x00392;","&#x00393;","&#x00394;","&#x00395;","&#x00396;","&#x00397;","&#x00398;","&#x003A0;","&#x003A9;","&#x0039F;","&#x003A8;","&#x00396;","&#x0039E;","&#x003A7;","&#x003A6;","&#x0039D;","&#x00394;","&#x00393;","&#x0039B;","&#x003A4;","&#x003A3;","&#x0039A;","&#x00399;","&#x003A1;","&#x003BD;"
                ,"&#x00391;","&#x0039C;","&#x003A5;","<mi mathvariant=\"double-struck\">","&#x02119;","&#x02124;","&#x02102;","&#x0210D;","&#x1D540;","&#x02115;","&#x0211D;","&#x02115;","&#x0211A;","&#x02124;","&#x0222B;","&#x0222B;","&#x0222B;","&#x0222B;","&#x000D7;","&#x0222B;","&#x0222C;","&#x0222F;","&#x0222E;","&#x0222D;","&#x02230;","&#x02211;","&#x0220F;","<mfenced open=\"&#x0230A;\" close=\"&#x0230B;\">","<mfenced open=\"&lt;\" close=\"&gt;\" separators=\"|\">","<mfenced open=\"&#x02308;\" close=\"&#x02309;\">","&#x023DE;","&#x023DC;","&#x023DD;","&#x023DF;","&#x000A8;","&#x002D9;","<menclose notation=\"horizontalstrike\"/>","<mstack charalign=\"center\" stackalign=\"right\">","<msrow>","</msrow>","<msrow/>","<msline/>","</mstack>","<mlongdiv charalign=\"center\" charspacing=\"0px\" stackalign=\"left\">","<msgroup>","</msgroup>","</mlongdiv>"};
            

            string[] Enunciado_Limpio = Enunciado_MATH.Split(Terminos_Borrados, StringSplitOptions.RemoveEmptyEntries);
            foreach (string Caracter in Enunciado_Limpio) // genero una variable nueva ya corregida si los caracteres raros de wiris
            {
                Linea = Linea + Caracter;
            }
            // pongo todos los terminos en minusculas y saco los acentos
            Linea = Linea.ToLower();
            Linea = Linea.Replace("<mspace linebreak=\"newline\"/>", " ");
            Linea = Linea.Replace("&#x000a0;", " ");
            Linea = Linea.Replace("<mo></mo>", "");
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


            Linea = Linea.Replace("&#x000e1;", "a");
            Linea = Linea.Replace("&#x000e9;", "e");
            Linea = Linea.Replace("&#x000ed;", "i");
            Linea = Linea.Replace("&#x000f3;", "o");
            Linea = Linea.Replace("&#x000fa;", "u");
            Linea = Linea.Replace("&#x000f1;", "n");

            Linea = Linea.Replace("&#x000c1;", "a");
            Linea = Linea.Replace("&#x000c9;", "e");
            Linea = Linea.Replace("&#x000cd;", "i");
            Linea = Linea.Replace("&#x000d3;", "o");
            Linea = Linea.Replace("&#x000dc;", "u");
            Linea = Linea.Replace("&#x000da;", "u");
            Linea = Linea.Replace("&#x000fc;", "u");


            Linea = Linea.Trim(); // elimino los espacios delante y detras de la variable creada
            return Linea; // variable final limpia de wiris
        }

        public static readonly Random _rng = new Random();

        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890qwertyuiopasdfghjklzxcvbnm";

        public static string RandomString(int size)
        {

            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);

        }

        public class Tres_Datos_Para_Sacar_Vacios
        {
            public string Valor_1 { get; set; }
            public string Valor_2 { get; set; }
            public string Valor_3 { get; set; }
        
        }

        public Tres_Datos_Para_Sacar_Vacios Correcion_De_Datos_Vacios(string Dato1,string Dato2,string Dato3)
        {
    
            Tres_Datos_Para_Sacar_Vacios Limpieza_De_Datos = new Tres_Datos_Para_Sacar_Vacios();

            string[] Dato = new string[3];
            Dato[0] = Dato1;
            Dato[1] = Dato2;
            Dato[2] = Dato3;

            for (int I = 0; I <= 2; I++)
            {

                if(Dato[I] == string.Empty)
                {
                        
                    for(int J = I+1 ; J <= 2; J++)
                    {
                        Dato[I] = Dato[J];
                        if(Dato[I] != string.Empty)
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
        
        public void Insertar_En_Tabla_Segunda_Parte(string Tema1_S, string Tema2_S, string Tema3_S, string Tema1, string Tema2, string Tema3, string Materia1, string Materia2, string Materia3, string Colegio1, string Colegio2, string Colegio3, string Ano1, string Ano2, string Ano3, string Profesor1, string Profesor2, string Profesor3)
        {
            db.Sinonimos_Temas(Corregir_Etiqueta(Tema1),Corregir_Etiqueta(Tema2),Corregir_Etiqueta(Tema3));
            db.Temas(Corregir_Etiqueta(Tema1_S),Corregir_Etiqueta(Tema2_S),Corregir_Etiqueta(Tema3_S));            
            db.Materias(Corregir_Etiqueta(Materia1),Corregir_Etiqueta(Materia2),Corregir_Etiqueta(Materia3));
            db.Sinonimos_Colegios(Corregir_Etiqueta(Colegio1),Corregir_Etiqueta(Colegio2),Corregir_Etiqueta(Colegio3));
            db.Sinonimos_Anos(Corregir_Etiqueta(Ano1), Corregir_Etiqueta(Ano2),Corregir_Etiqueta(Ano3));
            db.Profesores(Corregir_Etiqueta(Profesor1), Corregir_Etiqueta(Profesor2),Corregir_Etiqueta(Profesor3));

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



        public void Crear_Un_Archivo_TXT(string Enunciado,
            string Titulo, string Institucion, string Ejercicio,
            string Video, string Explicacion, string Tema1_S, string Tema2_S,
            string Tema3_S, string Tema1, string Tema2,
            string Tema3, string Materia1, string Materia2,
            string Materia3, string Colegio1, string Colegio2,
            string Colegio3, string Ano1, string Ano2,
            string Ano3, string Profesor1, string Profesor2, string Profesor3,
            string Etiqueta_Ano, string Etiqueta_Colegio, string Etiqueta_Materia, string Etiqueta_Tema, string Etiqueta_Profesor) // carga dos archivos en c: correspondiente a los enunciados
        {


            StreamWriter Archivo = File.CreateText("C:\\archivo/Ejercicio" + db.Tabla_De_Ejercicios.Max(c => c.ID_Ejercicio) + ".txt"); // carga el archivo corregido del enunciado en c:
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
            Archivo.Write(Ubicacion1);
            Archivo.Write("╝");
            Archivo.Write(Ubicacion2);
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

        public void Insertar_En_Tabla_Tercera_Parte(string Tema1_S, string Tema2_S, string Tema3_S, string Tema1, string Tema2, string Tema3, string Materia1, string Materia2, string Materia3, string Colegio1, string Colegio2, string Colegio3, string Ano1, string Ano2, string Ano3, string Profesor1, string Profesor2, string Profesor3)
        {
            db.Insertar_En_La_Tabla_De_Busqueda(Union_Etiqueta_Tema(Corregir_Etiqueta(Tema1_S),Corregir_Etiqueta(Tema2_S),Corregir_Etiqueta(Tema3_S),Corregir_Etiqueta(Tema1),Corregir_Etiqueta(Tema2),Corregir_Etiqueta(Tema3)), Buscar_Materia(Corregir_Etiqueta(Materia1),Corregir_Etiqueta(Materia2),Corregir_Etiqueta(Materia3)), Buscar_Colegio(Corregir_Etiqueta(Colegio1),Corregir_Etiqueta(Colegio2),Corregir_Etiqueta(Colegio3)), Buscar_Ano(Corregir_Etiqueta(Ano1),Corregir_Etiqueta(Ano2),Corregir_Etiqueta(Ano3)), Buscar_Profesor(Corregir_Etiqueta(Profesor1),Corregir_Etiqueta(Profesor2),Corregir_Etiqueta(Profesor3)));
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

        public string Obtener_Nombre_De_Archivo()
        {
            return "Ejercicio " + db.Tabla_De_Ejercicios.Max(c => c.ID_Ejercicio); // carga el archivo 
            
        }


    }
}
