using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace index
{
    public partial class buscar_x_porcentaje : System.Web.UI.Page
    {
        Logica_Busqueda LB = new Logica_Busqueda();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack) // la primera vez que carga
            {
                Cargar_Variables_De_URL(Request.QueryString["Enunciado_1"], Request.QueryString["Enunciado_2"]); // carga las variables de la URL                
                Listado_De_Parecidos((string)ViewState["Var_1"], (string)ViewState["Var_2"], 0); // Llama al datalist de enunciados parecidos, desde la pagina cero
                Condiciones_Paginacion(); // datos para armado de la paginacion del datalist

            }

        }

      
        #region Variables

        public void Cargar_Variables_De_URL(string Enunciado_1, string Enunciado_2)
        {
            ViewState["Var_1"] = Enunciado_1.ToLower(); // recupera desde el URL el Enunciado1
            ViewState["Var_2"] = Enunciado_2.ToLower(); // recupera desde el URL el Enunciado1
        }

        #endregion

        #region DataList

        public void Listado_De_Parecidos(string Enunciado_1, string Enunciado_2, int Pagina)
        {          
            Resultado_DataList.DataSource = LB.Mostrar_Ejercicios_Porcentaje(Enunciado_1, Enunciado_2).Skip(Pagina * 10).Take(10); // datalist que muestra los enunciados similares de a 10 datos 
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
            ViewState["Cantidad_De_Datos_Enunciado"] = LB.Contar_Ejercicios_Porcentaje((string)ViewState["Var_1"], (string)ViewState["Var_2"]); //cantidad de datos al buscar por enunciados
            if ((int)ViewState["Cantidad_De_Datos_Enunciado"] == 0)
            {
                Lista.Visible = false;
                return;
            }
            Lista.Visible = true;
            ViewState["Cantidad_De_Paginas_Enunciado"] = (int)ViewState["Cantidad_De_Datos_Enunciado"] / 10; //cantidad de paginas que se generan empezando por el cero
            ViewState["Resto_Enunciado"] = (int)ViewState["Cantidad_De_Datos_Enunciado"] % 10; // cantidad de ejercicios que faltan para completar una hoja
            if ((int)ViewState["Resto_Enunciado"] == 0) // si el resto es exacto necesito una hoja menos porque se arranca de la hoja cero
            {
                ViewState["Cantidad_De_Paginas_Enunciado"] = (int)ViewState["Cantidad_De_Paginas_Enunciado"] - 1; // resto una hoja
            }
            if ((int)ViewState["Cantidad_De_Datos_Enunciado"] <= 10) // si cuento con menos de 10 datos no muestra siguiente primero
            {
                Siguiente_Primero.Visible = false;
            }
        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Enunciado"] = (int)ViewState["Pagina_Enunciado"] + 1; // se suma una hoja
            if ((int)ViewState["Pagina_Enunciado"] == (int)ViewState["Cantidad_De_Paginas_Enunciado"]) // se fija si estoy en la ultima hoja
            {
                Listado_De_Parecidos((string)ViewState["Var_1"], (string)ViewState["Var_2"], (int)ViewState["Pagina_Enunciado"]); // llama al datalist 
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = false; // siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = true; // anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // si no estoy en la ultima hoja
            {
                Listado_De_Parecidos((string)ViewState["Var_1"], (string)ViewState["Var_2"], (int)ViewState["Pagina_Enunciado"]); // llama al datalist
                Centros_Paginados.Visible = true; // solo muestra los paginados centrales de siguiente y anterior
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy ni en la primera ni en la ultima hoja
            }
        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            ViewState["Pagina_Enunciado"] = (int)ViewState["Pagina_Enunciado"] - 1; //se resta una hoja
            if ((int)ViewState["Pagina_Enunciado"] == 0) // estoy en la primera pagina
            {
                Listado_De_Parecidos((string)ViewState["Var_1"], (string)ViewState["Var_2"], (int)ViewState["Pagina_Enunciado"]); // llama al datalist
                Centros_Paginados.Visible = false; // como es la ultima pagina la paginacion centrada es falsa
                Extremos_Paginados.Visible = true; // como es la ultima pagina la paginacion externa es verdadera
                Siguiente_Primero.Visible = true;// siguiente primero es falso pues estoy en la ultima hoja
                Anterior_Ultimo.Visible = false;// anterior ultimo verdadero pues estoy en la ultima hoja
            }
            else // no estoy en la primera hoja
            {
                Listado_De_Parecidos((string)ViewState["Var_1"], (string)ViewState["Var_2"], (int)ViewState["Pagina_Enunciado"]); // llama al datalist
                Centros_Paginados.Visible = true; // aparece pues no estoy ni en la primera ni en la ultima hoja 
                Extremos_Paginados.Visible = false; // no muestra los paginados externos de siguiente y anterior porque no estoy en la primera pagina
            }
        }

        #endregion

    }
}