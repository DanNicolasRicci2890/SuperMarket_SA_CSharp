using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR15
    {
        /*
                PR15: (FINALIZADO)
                    Procede a crear una Sucursal, en la lista y como recurso de productos
        */
        public static void IngresoSucursales(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSucursAddST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SucursalesAddST)(dt.GetMState(TypeState._SucursAddST))) 
                {
                    case (SucursalesAddST._ADD): SUP15.IngresodeSucursales(ref dt); break;
                    case (SucursalesAddST._VOLVER): SUP15.VolverSucursal(ref dt); break;
                    case (SucursalesAddST._VERIF_DATOS): SUP15.VerificadorDatos(ref dt); break;
                    case (SucursalesAddST._MENSAGE01): SUP15.MensageP1(ref dt); break;
                    case (SucursalesAddST._MENSAGE02): SUP15.MensageP2(ref dt); break;
                    case (SucursalesAddST._MENSAGE03): SUP15.MensageP3(ref dt); break;
                    case (SucursalesAddST._MENSAGE04): SUP15.MensageP4(ref dt); break;
                    case (SucursalesAddST._MENSAGE05): SUP15.MensageP5(ref dt); break;
                    case (SucursalesAddST._MENSAGE06): SUP15.MensageP6(ref dt); break;
                    case (SucursalesAddST._MENSAGE07): SUP15.MensageP7(ref dt); break;
                    case (SucursalesAddST._MENSAGE08): SUP15.MensageP8(ref dt); break;
                    case (SucursalesAddST._VERIF_NOMB): SUP15.VerificarNombreSucursal(ref dt); break;
                    case (SucursalesAddST._MENSAGE09): SUP15.MensageP9(ref dt); break;
                    case (SucursalesAddST._VERIF_CODE): SUP15.VerificarCodigo(ref dt); break;
                    case (SucursalesAddST._MENSAGE10): SUP15.MensageP10(ref dt); break;
                    case (SucursalesAddST._SAVE_SUCURSAL): SUP15.GuardarSucursal(ref dt); break;
                    case (SucursalesAddST._CREATE_SUCURSAL): SUP15.CrearSucursal(ref dt); break;
                    case (SucursalesAddST._MENSAGE11): SUP15.MensageP11(ref dt); break;
                }
            }
        }
    }
}
