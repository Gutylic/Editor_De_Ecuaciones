using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Vaciar_Base
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public int Tabla_Ano()
        {
            return db.Borrar_Tabla_De_Anos();
        }
        public int Tabla_Colegio()
        {
            return db.Borrar_Tabla_De_Colegios();
        }
        
         public int Tabla_Materias()
        {
            return db.Borrar_Tabla_De_Materias();
        }
        


        public int Tabla_Temas()
        {
            return db.Borrar_Tabla_De_Temas();
        }

        public int Tabla_Profesor()
        {
            return db.Borrar_Tabla_De_Profesores();
        }

        
        public int Administrador()
        {
            return db.Borrar_Administrador();
        }

        

        public int Ejercicios()
        {
            return db.Borrar_Tabla_De_Ejercicios();
        }

        public int Empresa()
        {
            return db.Borrar_Tabla_De_Empresa();
        }
    }
}
