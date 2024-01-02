using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR28
    {
        /*
            PR28: (FINALIZADO)
                Realizamos la compra de mercaderia a sucursal central.
        */
        public static void CompraProductoStockCentral(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveContaduriaProductST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ContaduriaCompraST)(dt.GetMState(TypeState._ContaduriaProductST))) 
                {
                    case (ContaduriaCompraST._TIPO_PRODUCT): SUP28.ListaTipoProductos(ref dt); break;
                    case (ContaduriaCompraST._VOLVER): SUP28.VolverContaduria(ref dt); break;
                    case (ContaduriaCompraST._VERIF_TIPO_PRODUCT): SUP28.VerificarListaProductos(ref dt); break;
                    case (ContaduriaCompraST._MENSAGE01): SUP28.Mensage01(ref dt); break;
                    case (ContaduriaCompraST._PRODUCT): SUP28.ListerProductos(ref dt); break;
                    case (ContaduriaCompraST._INCREMENT_PRODUCT): SUP28.IncredProducto(ref dt); break;
                    case (ContaduriaCompraST._MENSAGE02): SUP28.Mensage02(ref dt); break;
                    case (ContaduriaCompraST._SAVE_PRODUCT): SUP28.SaveStockProduct(ref dt); break;
                    case (ContaduriaCompraST._MENSAGE03): SUP28.Mensage03(ref dt); break;
                }
            }
        }
    }
}
