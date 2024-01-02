using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR35
    {
        /*
            PR35:(FINALIZADO)
                Administra los procesos de un Cajero
        */
        public static void PerfilCajero(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveCajeroST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((CajeroST)(dt.GetMState(TypeState._CajeroST))) 
                {
                    case (CajeroST._VOLVER): SUP35.VolverMenu(ref dt); break;
                    case (CajeroST._LISTER_USER): SUP35.ListerUser(ref dt); break;
                    case (CajeroST._MENSAGE01): SUP35.Mensage01(ref dt); break;
                    case (CajeroST._LISTER_TYPE_PRODUCT): SUP35.ListerTypeProduct(ref dt); break;
                    case (CajeroST._MENSAGE02): SUP35.Mensage02(ref dt); break;
                    case (CajeroST._LISTER_PRODUCT): SUP35.ListerProduct(ref dt); break;
                    case (CajeroST._MENSAGE03): SUP35.Mensage03(ref dt); break;
                    case (CajeroST._LISTER_SUCURSAL): SUP35.ListerSucursal(ref dt); break;
                    case (CajeroST._MENSAGE04): SUP35.Mensage04(ref dt); break;
                    case (CajeroST._LISTER_STOCK): SUP35.ListerStock(ref dt); break;
                    case (CajeroST._MENSAGE05): SUP35.Mensage05(ref dt); break;
                    case (CajeroST._MENUOPTION): SUP35.MenuSucursal(ref dt); break;
                    case (CajeroST._VERIFSTOCK): SUP35.VerifStock(ref dt); break;
                    case (CajeroST._MENSAGE06): SUP35.Mensage06(ref dt); break;
                    case (CajeroST._CAJERO): SUP35.CajeroVenta(ref dt); break;
                    case (CajeroST._MENSAGE07): SUP35.Mensage07(ref dt); break;
                    case (CajeroST._MENSAGE08): SUP35.Mensage08(ref dt); break;
                    case (CajeroST._MENSAGE09): SUP35.Mensage09(ref dt); break;
                    case (CajeroST._MENSAGE10): SUP35.Mensage10(ref dt); break;
                    case (CajeroST._CAJERO_QUITAR): SUP35.CajeroVerQuitar(ref dt); break;
                    case (CajeroST._CAJERO_FINALY): SUP35.CajeroFinally(ref dt); break;
                    case (CajeroST._MENSAGE11): SUP35.Mensage11(ref dt); break;
                    case (CajeroST._ABONAR): SUP35.AbonarImporte(ref dt); break;
                    case (CajeroST._MENSAGE12): SUP35.Mensage12(ref dt); break;
                    case (CajeroST._MENSAGE13): SUP35.Mensage13(ref dt); break;
                    case (CajeroST._PROCESO_PAGO): SUP35.ProcesoPago(ref dt); break;
                    case (CajeroST._MENSAGE14): SUP35.Mensage14(ref dt); break;
                }
            }
        }
    }
}
