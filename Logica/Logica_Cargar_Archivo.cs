using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Cargar_Archivo
    {

        DataClassesDataContext db = new DataClassesDataContext();
        
        public int Analizar_Existencia_Ejercicio(int ID_Ejercicio)
        {
            return db.Existencia_De_Ejercicio(ID_Ejercicio);
        }

        public List<Obtener_Ubicacion_De_RespuestasResult> Obtener_Ubicacion_Respuesta(int ID_Ejercicio)
        {
            return db.Obtener_Ubicacion_De_Respuestas(ID_Ejercicio).ToList();
        }

    }
}
