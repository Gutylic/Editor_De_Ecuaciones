﻿using System;
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
            string Linea = "";
            // quitare todos los caracteres que genera wiris para que el codigo quede limpio y sin espacio
            string[] Terminos_Borrados = new string[] { "<msubsup>", "<mmultiscripts>", "<presubsup>", "</presubsup>", "<mprescripts/>", "<none/>", "</mmultiscripts>", "</msubsup>", "<mo largeop=\"true\">", "<mrow/>", "<munder>", "</munder>", "<munderover>", "</munderover>", "<mover>", "</mover>", "<menclose notation=\"updiagonalstrike\">", "<menclose notation=\"updiagonalstrike\"/>", "</menclose>", "<mfenced open=\"|\" close=\"|\">", "</mfenced>", "<mi mathvariant=\"normal\">", "<mfrac>", "</mfrac>", "<msup>", "</msup>", "<msub>", "</msub>", "<mrow>", "</mrow>", "<msqrt>", "</msqrt>", "<mroot>", "</mroot>", "<mi>", "</mi>", "<mn>", "</mn>", "<mo>", "</mo>", "<mspace linebreak=\"newline\"/>", "&#8201;", "</math>","<msqrt/>", "<math xmlns=\"http://www.w3.org/1998/Math/MathML\">", "<maction actiontype=\"argument\">", "</maction>", "<mstyle displaystyle=\"true\">", "</mstyle>", "<mfenced open=\"||\" close=\"||\">", "<menclose notation=\"circle\">", "<menclose notation=\"actuarial\">", "<menclose notation=\"roundedbox\">", "<menclose notation=\"roundedbox\"/>", "<menclose notation=\"top\">", "<menclose notation=\"left\">", "<menclose notation=\"box\"/>", "<menclose notation=\"right\">", "<menclose notation=\"bottom\"/>", "<mfenced open=\"&#8970;\" close=\"&#8971;\">", "<mfenced open=\"&lt;\" close=\"&#62;\" separators=\"|\">", "<mfenced open=\"&#8968;\" close=\"&#8969;\">", "<menclose notation=\"top\"/>", "<menclose notation=\"left\"/>", "<menclose notation=\"right\"/>", "<menclose notation=\"circle\"/>", "<menclose notation=\"actuarial\"/>", "<menclose notation=\"bottom\">", "<menclose notation=\"box\">", "<menclose notation=\"downdiagonalstrike\">", "<menclose notation=\"downdiagonalstrike updiagonalstrike\">", "<menclose notation=\"horizontalstrike\">", "<menclose notation=\"verticalstrike\">", "<menclose>", "<menclose notation=\"verticalstrike horizontalstrike\">", "<menclose notation=\"horizontalstrike\">", "<menclose notation=\"downdiagonalstrike\"/>", "<menclose notation=\"downdiagonalstrike updiagonalstrike\"/>", "<menclose notation=\"verticalstrike\"/>", "<menclose>", "<menclose notation=\"verticalstrike horizontalstrike\"/>", "<menclose/>", "<mtable>", "<mtr>", "<mtd/>", "</mtr>", "</mtable>", "<mtd>", "</mtd>", "<mfenced open=\"[\" close=\"]\">", "<mfenced>", "<mfenced open=\"[\" close=\"]\">", "<mfenced open=\"[\" close=\"]\">", "<mfenced open=\"{\" close=\"\">", "<mtable columnalign=\"left\">", "<mfenced open=\"\" close=\"}\">", 
                "&#172;","&#175;","&#176;","&#177;","&#183;","&#960;","&#729;","&#168;","&#945;","&#946;","&#947;","&#948;","&#949;","&#950;","&#951;","&#952;","&#977;","&#953;","&#954;","&#955;","&#956;","&#957;","&#958;","&#959;","&#982;","&#961;","&#962;","&#963;","&#964;","&#965;","&#966;","&#981;","&#967;","&#968;","&#969;","&#913;","&#914;","&#915;","&#916;","&#917;","&#918;","&#919;","&#920;","&#921;","&#922;","&#923;","&#924;","&#925;","&#926;","&#927;","&#928;","&#929;","&#931;","&#932;","&#933;","&#934;","&#935;","&#936;","&#937;","&#8597;","&#8592;", "&#8593;","&#8595;","&#8596;","&#8594;","&#8598;", "&#8599;","&#8600;","&#8601;","&#8618;","&#8629;","&#8657;","&#8645;","&#8659;","&#8617;","&#8661;","&#8636;","&#8637;","&#8646;","&#8651;","&#8652;","&#8640;","&#8644;","&#8641;","&#8656;","&#8658;","&#8660;","&#8612;","&#8614;","&#8704;","&#8706;", "&#8707;" ,"&#8708;","&#8709;","&#8710;","&#8711;", "&#8712;","&#8715;","&#8721;","&#8719;","&#8713;", "&#8716;","&#8728;", "&#8726;", "&#8723;","&#8729;","&#8733;","&#8734;","&#8736;","&#8737;","&#8738;","&#8741;","&#8742;","&#8743;", "&#8744;","&#8745;","&#8746;","&#8756;","&#8757;","&#8769;","&#8773;","&#8776;", "&#8747;","&#8750;","&#8748;","&#8751;","&#8749;","&#8752;","&#8801;", "&#8804;","&#8805;", "&#8810;", "&#8826;","&#8834;","&#8835;", "&#8838;", "&#8839;","&#8847;" ,"&#8848;", "&#8849;", "&#8850;","&#8851;","&#8852;","&#8853;","&#8855;","&#8857;", "&#8859;", "&#8861;","&#8869;","&#8882;", "&#8883;","&#8900;","&#9633;","&#9649;","&#9651;","&#9675;","&#9180;","&#9181;","&#9183;","&#9182;","&#10808;","&#10888;","&#10529;","&#10530;","&#10606;","&#10602;","&#10607;","&#10605;","&#x000B1;","&#x0222A;","&#x003C0;","&#x0221E;","&#x02208;","&#x02282;","&#x02229;","&#x02265;","&#x02264;","&#x02205;","&#x003bd","<mi mathvariant=\"fraktur\">","<mi mathvariant=\"script\">",
                "&#x000B7;","&#x02218;","&#x02216;","&#x02213;","&#x02207;","&#x02206;","&#x02202;","&#x02035;","&#x02261;","&#x02243;","&#x02248;","&#x02245;","&#x02260;","&#x02262;","&#x02241;","&#x02249;","&#x02A87;","&#x0226B;","&#x0227B;","&#x02A88;","&#x0221D;","&#x022B2;","&#x0226A;","&#x0227A;","&#x022B3;","&#x0220B;","&#x02283;","&#x02209;","&#x0220C;","&#x02286;","&#x02287;","&#x0228F;","&#x02290;","&#x02291;","&#x02292;","&#x02293;","&#x02294;","&#x02203;","&#x000AC;","&#x02227;","&#x02228;","&#x02200;","&#x02204;","&#x02234;","&#x02235;","&#x02220;","&#x02225;","&#x022A5;","&#x02226;","&#x02221;","&#x02222;","&#x022C4;","&#x025A1;","&#x025B3;","&#x025CB;","&#x025AD;","&#x025B1;","&#x02295;","&#x02297;","&#x02299;","&#x0229D;","&#x0229B;","&#x02219;","&#x02A38;","&#x000B0;","&#x02190;","&#x02192;","&#x02194;","&#x021D0;","&#x021D2;","&#x021D4;","&#x021A4;","&#x021A6;","&#x02197;","&#x02198;","&#x02196;","&#x02199;","&#x02921;","&#x02922;","&#x021A9;","&#x021AA;","&#x021BC;","&#x021C0;","&#x02191;","&#x02193;","&#x021D1;","&#x021D3;","&#x0296A;","<mtable columnalign=\"right\">","&#x0296D;","&#x021CB;","&#x021CC;","&#x021BD;","&#x021C1;","&#x021C6;","&#x021C4;","&#x021C5;","&#x021F5;","&#x0296E;","&#x0296F;","&#x02195;","&#x021D5;","&#x021B5;","&#x022EE;","&#x02026;","&#x022F1;","&#x022EF;","&#x02192;","&#x02192;","&#x02192;","&#x02190;","&#x02190;","&#x000AF;","&#x02194;","&#x021C0;","&#x02192;","&#x022F0;","&#x003B1;","&#x003B3;","&#x003B2;","&#x003B4;","&#x003B5;","&#x003B6;","&#x003B7;","&#x003B8;","&#x003D1;","&#x003B9;","&#x003C2;","&#x003C1;","&#x003D6;","&#x003BF;","&#x003BE;","&#x003BC;","&#x003BB;","&#x003BA;","&#x003C3;","&#x003C4;","&#x003C5;","&#x003C6;","&#x003D5;","&#x003C7;","&#x003C8;","&#x003C9;","&#x00392;","&#x00393;","&#x00394;","&#x00395;","&#x00396;","&#x00397;","&#x00398;","&#x003A0;","&#x003A9;","&#x0039F;","&#x003A8;","&#x00396;","&#x0039E;","&#x003A7;","&#x003A6;","&#x0039D;","&#x00394;","&#x00393;","&#x0039B;","&#x003A4;","&#x003A3;","&#x0039A;","&#x00399;","&#x003A1;","&#x003BD;"
                ,"&#x00391;","&#x0039C;","&#x003A5;","<mi mathvariant=\"double-struck\">","&#x02119;","&#x02124;","&#x02102;","&#x0210D;","&#x1D540;","&#x02115;","&#x0211D;","&#x02115;","&#x0211A;","&#x02124;","&#x0222B;","&#x0222B;","&#x0222B;","&#x0222B;","&#x000D7;","&#x0222B;","&#x0222C;","&#x0222F;","&#x0222E;","&#x0222D;","&#x02230;","&#x02211;","&#x0220F;","<mfenced open=\"&#x0230A;\" close=\"&#x0230B;\">","<mfenced open=\"&lt;\" close=\"&gt;\" separators=\"|\">","<mfenced open=\"&#x02308;\" close=\"&#x02309;\">","&#x023DE;","&#x023DC;","&#x023DD;","&#x023DF;","&#x000A8;","&#x002D9;","<menclose notation=\"horizontalstrike\"/>","<mstack charalign=\"center\" stackalign=\"right\">","<msrow>","</msrow>","<msrow/>","<msline/>","</mstack>","<mlongdiv charalign=\"center\" charspacing=\"0px\" stackalign=\"left\">","<msgroup>","</msgroup>","</mlongdiv>"};
            

            string[] Enunciado_Limpio = Enunciado.Split(Terminos_Borrados, StringSplitOptions.RemoveEmptyEntries);
            foreach (string Caracter in Enunciado_Limpio) // genero una variable nueva ya corregida si los caracteres raros de wiris
            {
                Linea = Linea + Caracter;
            }
            // pongo todos los terminos en minusculas y saco los acentos
            Linea = Linea.Replace("<mspace linebreak=\"newline\"/>", " ");
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
            Linea = Linea.Replace("'", "´");
            Linea = Linea.Replace("A", "a");
            Linea = Linea.Replace("&#x000a0;", " ");
            Linea = Linea.Replace("&#x000a1;", "¡");
            Linea = Linea.Replace("&#x000bf;", "¿");
            Linea = Linea.Replace("&quot;", "\"");
            Linea = Linea.Replace("&#x000b4;", "´");
            Linea = Linea.Replace("&amp;", "&");
            Linea = Linea.Replace("<mo></mo>", "");
            Linea = Linea.Replace("&#x000e1;", "a");
            Linea = Linea.Replace("&#x000e9;", "e");
            Linea = Linea.Replace("&#x000ed;", "i");
            Linea = Linea.Replace("&#x000f3;", "o");
            Linea = Linea.Replace("&#x000fa;", "u");
            Linea = Linea.Replace("&#x000f1;", "n");
            Linea = Linea.Replace("&#x000d1;", "n");
            Linea = Linea.Replace("&#x000bf;", "¿");
            Linea = Linea.Replace("&#x000c1;", "a");
            Linea = Linea.Replace("&#x000c9;", "e");
            Linea = Linea.Replace("&#x000cd;", "i");
            Linea = Linea.Replace("&#x000d3;", "o");
            Linea = Linea.Replace("&#x000dc;", "u");
            Linea = Linea.Replace("&#x000da;", "u");
            Linea = Linea.Replace("&#x000fc;", "u");


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
            Linea = Linea.Replace("&#x000ba;", "º");
            Linea = Linea.Replace("&#x02009;", "");
            Linea = Linea.Trim(); // elimino los espacios delante y detras de la variable creada
            return Linea; // variable final limpia de wiris

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




