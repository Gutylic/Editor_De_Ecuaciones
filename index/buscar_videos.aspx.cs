﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace index
{
    public partial class buscar_videos : System.Web.UI.Page
    {

        Logica_Buscar_Video LBV = new Logica_Buscar_Video();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            { 
                Cargar_Variables_De_URL(Request.QueryString["Videos"]); // carga las variables de la URL                
                Listado_De_Parecidos((string)ViewState["Enunciado_1"], (string)ViewState["Enunciado_2"], (string)ViewState["Enunciado_3"], (string)ViewState["Enunciado_4"], (string)ViewState["Enunciado_5"], (string)ViewState["Enunciado_6"], (string)ViewState["Enunciado_7"], (string)ViewState["Enunciado_8"], (string)ViewState["Enunciado_9"], (string)ViewState["Enunciado_10"], 0); // Llama al datalist de enunciados parecidos, desde la pagina cero
                Condiciones_Paginacion(); // datos para armado de la paginacion del datalist
            }
            
        }

        public void Cargar_Variables_De_URL(string Enunciado)
        {

            string[] str = new string[10];
            Enunciado = Enunciado.Trim();
            str = Enunciado.Split(' ');

            int cantidad = str.Length;

            switch (cantidad)
            {
                case 1:
                    ViewState["Enunciado_1"] = "\"" + str[0] + "*\"";
                    break;
                case 2:
                    ViewState["Enunciado_1"] = "\"" + str[0] + "*\"" ;
                    ViewState["Enunciado_2"] = "\"" + str[1] + "*\"";   
                    break;
                case 3:
                    ViewState["Enunciado_1"] = "\"" + str[0] + "*\"" ;
                    ViewState["Enunciado_2"] = "\"" + str[1] + "*\"";
                    ViewState["Enunciado_3"] = "\"" + str[2] + "*\"";
                    break;
                case 4:
                    ViewState["Enunciado_1"] = "\"" + str[0] + "*\"" ;
                    ViewState["Enunciado_2"] = "\"" + str[1] + "*\"";
                    ViewState["Enunciado_3"] = "\"" + str[2] + "*\"";
                    ViewState["Enunciado_4"] = "\"" + str[3] + "*\"";
                    break;
                case 5:
                    ViewState["Enunciado_1"] = "\"" + str[0] + "*\"" ;
                    ViewState["Enunciado_2"] = "\"" + str[1] + "*\"";
                    ViewState["Enunciado_3"] = "\"" + str[2] + "*\"";
                    ViewState["Enunciado_4"] = "\"" + str[3] + "*\"";
                    ViewState["Enunciado_5"] = "\"" + str[4] + "*\"";
                    break;
                case 6:
                    ViewState["Enunciado_1"] = "\"" + str[0] + "*\"" ;
                    ViewState["Enunciado_2"] = "\"" + str[1] + "*\"";
                    ViewState["Enunciado_3"] = "\"" + str[2] + "*\"";
                    ViewState["Enunciado_4"] = "\"" + str[3] + "*\"";
                    ViewState["Enunciado_5"] = "\"" + str[4] + "*\"";
                    ViewState["Enunciado_6"] = "\"" + str[5] + "*\"";
                    break;
                case 7:
                    ViewState["Enunciado_1"] = "\"" + str[0] + "*\"" ;
                    ViewState["Enunciado_2"] = "\"" + str[1] + "*\"";
                    ViewState["Enunciado_3"] = "\"" + str[2] + "*\"";
                    ViewState["Enunciado_4"] = "\"" + str[3] + "*\"";
                    ViewState["Enunciado_5"] = "\"" + str[4] + "*\"";
                    ViewState["Enunciado_6"] = "\"" + str[5] + "*\"";
                    ViewState["Enunciado_7"] = "\"" + str[6] + "*\"";
                    break;
                case 8:
                    ViewState["Enunciado_1"] = "\"" + str[0] + "*\"";
                    ViewState["Enunciado_2"] = "\"" + str[1] + "*\"";
                    ViewState["Enunciado_3"] = "\"" + str[2] + "*\"";
                    ViewState["Enunciado_4"] = "\"" + str[3] + "*\"";
                    ViewState["Enunciado_5"] = "\"" + str[4] + "*\"";
                    ViewState["Enunciado_6"] = "\"" + str[5] + "*\"";
                    ViewState["Enunciado_7"] = "\"" + str[6] + "*\"";
                    ViewState["Enunciado_8"] = "\"" + str[7] + "*\"";
                    break;
                case 9:
                    ViewState["Enunciado_1"] = "\"" + str[0] + "*\"" ;
                    ViewState["Enunciado_2"] = "\"" + str[1] + "*\"";
                    ViewState["Enunciado_3"] = "\"" + str[2] + "*\"";
                    ViewState["Enunciado_4"] = "\"" + str[3] + "*\"";
                    ViewState["Enunciado_5"] = "\"" + str[4] + "*\"";
                    ViewState["Enunciado_6"] = "\"" + str[5] + "*\"";
                    ViewState["Enunciado_7"] = "\"" + str[6] + "*\"";
                    ViewState["Enunciado_8"] = "\"" + str[7] + "*\"";
                    ViewState["Enunciado_9"] = "\"" + str[8] + "*\"";
                    break;
                case 10:
                    ViewState["Enunciado_1"] = "\"" + str[0] + "*\"";
                    ViewState["Enunciado_2"] = "\"" + str[1] + "*\"";
                    ViewState["Enunciado_3"] = "\"" + str[2] + "*\"";
                    ViewState["Enunciado_4"] = "\"" + str[3] + "*\"";
                    ViewState["Enunciado_5"] = "\"" + str[4] + "*\"";
                    ViewState["Enunciado_6"] = "\"" + str[5] + "*\"";
                    ViewState["Enunciado_7"] = "\"" + str[6] + "*\"";
                    ViewState["Enunciado_8"] = "\"" + str[7] + "*\"";
                    ViewState["Enunciado_9"] = "\"" + str[8] + "*\"";
                    ViewState["Enunciado_10"] = "\"" + str[9] + "*\"";
                    break;

            }


        }

        #region DataList

        public void Listado_De_Parecidos(string Enunciado_1, string Enunciado_2, string Enunciado_3, string Enunciado_4, string Enunciado_5, string Enunciado_6, string Enunciado_7, string Enunciado_8, string Enunciado_9, string Enunciado_10, int Pagina)
        {
            Resultado_DataList.DataSource = LBV.Mostrar_Videos(Enunciado_1, Enunciado_2, Enunciado_3, Enunciado_4, Enunciado_5, Enunciado_6, Enunciado_7, Enunciado_8, Enunciado_9, Enunciado_10).Skip(Pagina * 3).Take(3); // datalist que muestra los enunciados similares de a 10 datos 
            Resultado_DataList.DataBind();
        }


        #endregion


        #region Paginacion_Del_DataList
        public void Condiciones_Paginacion()
        {
            ViewState["Pagina_Enunciado"] = 0; // arranca de la pagina cero
            Centros_Paginados.Visible = false; // contenedor de los paginados siguiente y anterior centrales
            Siguiente_Primero.Visible = true; // siguiente primero arranca true
            Anterior_Ultimo.Visible = false; // anterior ultimo es false
            ViewState["Cantidad_De_Datos_Enunciado"] = LBV.Contar_Videos((string)ViewState["Enunciado_1"], (string)ViewState["Enunciado_2"], (string)ViewState["Enunciado_3"], (string)ViewState["Enunciado_4"], (string)ViewState["Enunciado_5"], (string)ViewState["Enunciado_6"], (string)ViewState["Enunciado_7"], (string)ViewState["Enunciado_8"], (string)ViewState["Enunciado_9"], (string)ViewState["Enunciado_10"]); //cantidad de datos al buscar por enunciados
            if ((int)ViewState["Cantidad_De_Datos_Enunciado"] == 0)
            {
                Lista.Visible = false;
                return;
            }
            Lista.Visible = true;

            ViewState["Cantidad_De_Paginas_Enunciado"] = (int)ViewState["Cantidad_De_Datos_Enunciado"] / 3; //cantidad de paginas que se generan empezando por el cero
            ViewState["Resto_Enunciado"] = (int)ViewState["Cantidad_De_Datos_Enunciado"] % 3; // cantidad de ejercicios que faltan para completar una hoja
            if ((int)ViewState["Resto_Enunciado"] == 0) // si el resto es exacto necesito una hoja menos porque se arranca de la hoja cero
            {
                ViewState["Cantidad_De_Paginas_Enunciado"] = (int)ViewState["Cantidad_De_Paginas_Enunciado"] - 1; // resto una hoja
            }
            if ((int)ViewState["Cantidad_De_Datos_Enunciado"] <= 3) // si cuento con menos de 10 datos no muestra siguiente primero
            {
                Siguiente_Primero.Visible = false;
            }
        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            
            ViewState["Pagina_Enunciado"] = (int)ViewState["Pagina_Enunciado"] + 1; // se suma una hoja
           
            if ((int)ViewState["Pagina_Enunciado"] == (int)ViewState["Cantidad_De_Paginas_Enunciado"]) // se fija si estoy en la ultima hoja
            {
                Listado_De_Parecidos((string)ViewState["Enunciado_1"], (string)ViewState["Enunciado_2"], (string)ViewState["Enunciado_3"], (string)ViewState["Enunciado_4"], (string)ViewState["Enunciado_5"], (string)ViewState["Enunciado_6"], (string)ViewState["Enunciado_7"], (string)ViewState["Enunciado_8"], (string)ViewState["Enunciado_9"], (string)ViewState["Enunciado_10"], (int)ViewState["Pagina_Enunciado"]); // llama al datalist 
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = false; // siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = true; // anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la ultima hoja
            {
                Listado_De_Parecidos((string)ViewState["Enunciado_1"], (string)ViewState["Enunciado_2"], (string)ViewState["Enunciado_3"], (string)ViewState["Enunciado_4"], (string)ViewState["Enunciado_5"], (string)ViewState["Enunciado_6"], (string)ViewState["Enunciado_7"], (string)ViewState["Enunciado_8"], (string)ViewState["Enunciado_9"], (string)ViewState["Enunciado_10"], (int)ViewState["Pagina_Enunciado"]); // llama al datalist 
                Centros_Paginados.Visible = true; // solo muestra los paginados centrales de siguiente y anterior
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy ni en la primera ni en la ultima hoja
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Enunciado"] = (int)ViewState["Pagina_Enunciado"] - 1; //se resta una hoja
            if ((int)ViewState["Pagina_Enunciado"] == 0) // estoy en la primera pagina
            {
                Listado_De_Parecidos((string)ViewState["Enunciado_1"], (string)ViewState["Enunciado_2"], (string)ViewState["Enunciado_3"], (string)ViewState["Enunciado_4"], (string)ViewState["Enunciado_5"], (string)ViewState["Enunciado_6"], (string)ViewState["Enunciado_7"], (string)ViewState["Enunciado_8"], (string)ViewState["Enunciado_9"], (string)ViewState["Enunciado_10"], (int)ViewState["Pagina_Enunciado"]); // llama al datalist 
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = true;// siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = false;// anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // no estoy en la primera hoja
            {
                Listado_De_Parecidos((string)ViewState["Enunciado_1"], (string)ViewState["Enunciado_2"], (string)ViewState["Enunciado_3"], (string)ViewState["Enunciado_4"], (string)ViewState["Enunciado_5"], (string)ViewState["Enunciado_6"], (string)ViewState["Enunciado_7"], (string)ViewState["Enunciado_8"], (string)ViewState["Enunciado_9"], (string)ViewState["Enunciado_10"], (int)ViewState["Pagina_Enunciado"]); // llama al datalist 
                Centros_Paginados.Visible = true; // aparece pues no estoy ni en la primera ni en la ultima hoja 
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy en la primera pagina
            }
        }

        #endregion



    }
}