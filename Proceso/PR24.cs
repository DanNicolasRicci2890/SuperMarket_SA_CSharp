using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    /*
            PR24: (FINALIZADO)
                El ingreso , modificacion o eliminacion de mercaderia en nuestras base de datos.
    */
    public class PR24
    {
        public static void AgregarProductos(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveProductosAddST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ProductosAddST)(dt.GetMState(TypeState._ProductosAddST))) 
                {
                    case (ProductosAddST._VERIF_TP): SUP24.VerificarTypeProducts(ref dt); break;
                    case (ProductosAddST._MENSAGE1): SUP24.MensageP1(ref dt); break;
                    case (ProductosAddST._ADD_PRODUCT): SUP24.AgregarProduccion(ref dt); break;
                    case (ProductosAddST._VOLVER): SUP24.VolverTipoProducto(ref dt); break;
                    case (ProductosAddST._MENSAGE2): SUP24.MensageP2(ref dt); break;
                    case (ProductosAddST._VERIF_DATO): SUP24.VerificadorDatos(ref dt); break;
                    case (ProductosAddST._MENSAGE3): SUP24.MensageP3(ref dt); break;
                    case (ProductosAddST._MENSAGE4): SUP24.MensageP4(ref dt); break;
                    case (ProductosAddST._MENSAGE5): SUP24.MensageP5(ref dt); break;
                    case (ProductosAddST._MENSAGE6): SUP24.MensageP6(ref dt); break;
                    case (ProductosAddST._MENSAGE7): SUP24.MensageP7(ref dt); break;
                    case (ProductosAddST._MENSAGE8): SUP24.MensageP8(ref dt); break;
                    case (ProductosAddST._VERIF_CODIGO): SUP24.VerificarCodigo(ref dt); break;
                    case (ProductosAddST._SAVE_ADD): SUP24.SaveProducto(ref dt); break;
                    case (ProductosAddST._MENSAGE9): SUP24.MensageP9(ref dt); break;
                }
            }
        }
    }
}
