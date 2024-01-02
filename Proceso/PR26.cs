using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    /*
         PR26: (FINALIZADO)
            listea cada tipo de producto que obtengamos y podremos dirigirnos si queremos:
                    _ Agregar un nuevo producto.
                    _ Modificar un producto.
                    _ Eliminar un producto.
    */
    public class PR26
    {
        public static void ListerProductos(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveProductosListST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ProductosListST)(dt.GetMState(TypeState._ProductosListST)))
                {
                    case (ProductosListST._VERIF): SUP26.Verificador(ref dt); break;
                    case (ProductosListST._MENSAGE1): SUP26.Mensage01(ref dt); break;
                    case (ProductosListST._VOLVER): SUP26.Volver(ref dt); break;
                    case (ProductosListST._SEEK_LISTER): SUP26.ListerTypeProduct(ref dt); break;
                    case (ProductosListST._VERIF_LISTER): SUP26.VerifTypeListProduct(ref dt); break;
                    case (ProductosListST._MENSAGE2): SUP26.Mensage02(ref dt); break;
                    case (ProductosListST._LISTER_PRODUCT): SUP26.ListerProductos(ref dt); break;
                    case (ProductosListST._ADD_PRODUCT): SUP26.AddProductos(ref dt); break;
                    case (ProductosListST._MODIF_PRODUCT): SUP26.ModifProductos(ref dt); break;
                    case (ProductosListST._REMOVE_PRODUCT): SUP26.RemoveProductos(ref dt); break;
                }
            }
        }        
    }
}
