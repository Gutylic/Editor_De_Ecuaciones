using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Buscar_Video
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Vista_Buscar_Videos> Mostrar_Videos(string Var1, string Var2, string Var3, string Var4, string Var5, string Var6, string Var7, string Var8, string Var9, string Var10)
        {
            return db.Mostrar_Videos_Por_Palabras_Claves_Del_Enunciado(Var1, Var2, Var3, Var4, Var5, Var6, Var7, Var8, Var9, Var10).ToList();
        }

        public int? Contar_Videos(string Var1, string Var2, string Var3, string Var4, string Var5, string Var6, string Var7, string Var8, string Var9, string Var10)
        {
            db.Contar_Videos_Por_Palabras_Claves_Del_Enunciado(Var1, Var2, Var3, Var4, Var5, Var6, Var7, Var8, Var9, Var10,ref Cantidad);
            return Cantidad;
        }
        
    }

}
