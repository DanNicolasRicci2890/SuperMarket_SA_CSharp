using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR20
    {
        /*
            PR20: (FINALIZADO)
                Administra los Productos y tipo de productos que posee el negocio.
        */
        public static void AdministrarProductos(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveProductosST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ProductosST)(dt.GetMState(TypeState._ProductosST)))
                {
                    case (ProductosST._MENUOPTION): SUP20.MenuOpcion(ref dt); break;
                    case (ProductosST._VOLVER): SUP20.Volver(ref dt); break;
                    case (ProductosST._LIST_TYPEPRODUCT): SUP20.ListTypeProduct(ref dt); break;
                    case (ProductosST._ADD_TYPEPRODUCT): SUP20.AddTypeProduct(ref dt); break;
                    case (ProductosST._REMOVE_TYPEPRODUCT): SUP20.RemoveTypeProduct(ref dt); break;
                    case (ProductosST._ADD_PRODUCT): SUP20.AddProduct(ref dt); break;
                    case (ProductosST._MODIF_PRODUCT): SUP20.ModifProduct(ref dt); break;
                    case (ProductosST._REMOVE_PRODUCT): SUP20.RemoveProduct(ref dt); break;
                    case (ProductosST._LIST_PRODUCT): SUP20.ListerProduct(ref dt); break;
                }
            }
        }
    }
}
