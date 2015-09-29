using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using Logica;
using System.Data.Linq;


namespace index
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        DataClassesDataContext db = new DataClassesDataContext();


        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Tabla_De_Anos> Valor = db.Tabla_De_Anos.ToList<Tabla_De_Anos>();

            XElement nodoraiz = new XElement("Contenido", from p in Valor select new XElement("Elementos",new XElement("ID_Ano", p.ID_Ano), new XElement("Ano", p.Ano), new XElement("Etiqueta_Ano", p.Etiqueta_Ano)));

            //nodoraiz.Save(Server.MapPath("XML/Anos.xml"));
            nodoraiz.Save(File.CreateText("c:\\XML/Ano.xml"));

           // XDocument doc = null;

            //doc = XDocument.Load(Server.MapPath("XML/Anos.xml"));
           // doc = XDocument.Load(File.CreateText("c:\\XML/Ano.xml"));
        }

        public class Tabla
        {
            public string ID;
            public string Ano;
            public string Etiqueta;
        }

        
        protected void Button2_Click(object sender, EventArgs e)
        {
            XElement doc = XElement.Load(Server.MapPath("XML/Anos.xml"));

            List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                         select new Tabla()
                                             {
                                                 ID = item.Element("ID_Ano").Value,
                                                 Ano = item.Element("Ano").Value,
                                                 Etiqueta = item.Element("Etiqueta_Ano").Value,
                                             }).ToList();

            //db.Borrar_Tabla_De_Anos(); --- borre este procedimiento para que no ocupe espacio

            for (int I = 0; I <= Lista.Count - 1; I++)
            {
                Tabla_De_Anos Etiqueta_Final = new Tabla_De_Anos();
                Etiqueta_Final.Ano = Lista[I].Ano;
                Etiqueta_Final.Etiqueta_Ano = int.Parse(Lista[I].Etiqueta);
                db.Tabla_De_Anos.InsertOnSubmit(Etiqueta_Final);
                db.SubmitChanges();
            }
            
        }
    }
}