using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR21
    {
        /*
            PR21: (FINALIZADO)
                Administra la lista de tipos de Productos.
        */
        public static void ListTypeProduct(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveProductosListTypeST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch((ProductosListTypeST)(dt.GetMState(TypeState._ProductosListTypeST)))
                {
                    case (ProductosListTypeST._VERIF): SUP21.VerifTypeListProductos(ref dt); break;
                    case (ProductosListTypeST._MENSAGE1): SUP21.Mensage01(ref dt); break;
                    case (ProductosListTypeST._LISTER): SUP21.ListerTypeProduct(ref dt); break;
                    case (ProductosListTypeST._ADD): SUP21.AddTypeProduct(ref dt); break;
                    case (ProductosListTypeST._VOLVER): SUP21.VolverTypeProduct(ref dt); break;
                    case (ProductosListTypeST._VISUAL): SUP21.VisualTypeProduct(ref dt); break;
                }
            }
        }
    }
}
