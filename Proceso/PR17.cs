using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR17
    {
        /*
                PR17: (FINALIZADO)
                    Realiza la modificacion de una SUCURSAL, modificando la direccion de la misma
        */
        public static void ModificarSucursales(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSucursalModif, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SucursalModif)(dt.GetMState(TypeState._SucursalModif))) 
                {
                    case (SucursalModif._MODIF): SUP17.ModificaciondeSucursales(ref dt); break;
                    case (SucursalModif._VOLVER): SUP17.VolverSucursal(ref dt); break;
                    case (SucursalModif._VERIF_DATOS): SUP17.VerificadorDatos(ref dt); break;
                    case (SucursalModif._MENSAGE01): SUP17.MensageP1(ref dt); break;
                    case (SucursalModif._MENSAGE02): SUP17.MensageP2(ref dt); break;
                    case (SucursalModif._MENSAGE03): SUP17.MensageP3(ref dt); break;
                    case (SucursalModif._MENSAGE04): SUP17.MensageP4(ref dt); break;
                    case (SucursalModif._MENSAGE05): SUP17.MensageP5(ref dt); break;
                    case (SucursalModif._MENSAGE06): SUP17.MensageP6(ref dt); break;
                    case (SucursalModif._MODIF_SUCURSAL): SUP17.ModificarSucursal(ref dt); break;
                    case (SucursalModif._MENSAGE07): SUP17.MensageP7(ref dt); break;
                }
            }
        }
    }
}
