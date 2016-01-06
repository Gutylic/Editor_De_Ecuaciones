using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Administradores
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public int Insertar_Administrador(string Administrador, string Password, string Empresa)
        {
            return db.Insertar_Administrador(Administrador, Password, Empresa);
        }

        public int Actuaizar_Administrador(string Administrador, string Password)
        {
            return db.Actualizar_Administrador(Administrador, Password);
        }

        public int Borrar_Administrador(string Administrador)
        {
            return db.Borar_Administrador(Administrador);
        }

    }
}
