using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Respuestas
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public List<Buscar_RespuestasResult> Logica_Respuesta(int ID_Ejercicio)
        {
            return db.Buscar_Respuestas(ID_Ejercicio).ToList();
        
        }
    }
}
