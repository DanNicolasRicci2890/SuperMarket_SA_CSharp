using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR18
    {
        /*
                PR18: (FINALIZADO)
                    Procede con la eliminacion de una sucursal seleccionada.
        */
        public static void EliminarSucursales(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSucursalRemove, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SucursalRemove)(dt.GetMState(TypeState._SucursalRemove))) 
                {
                    case (SucursalRemove._REMOVE): SUP18.ModificaciondeSucursales(ref dt); break;
                    case (SucursalRemove._MENSAGE01): SUP18.MensageP1(ref dt); break;
                    case (SucursalRemove._ELIMINAR_SUCURSAL): SUP18.EliminarSucursal1(ref dt); break;
                    case (SucursalRemove._ELIMINAR_SUCURSAL2): SUP18.EliminarSucursal2(ref dt); break;
                    case (SucursalRemove._MENSAGE02): SUP18.MensageP2(ref dt); break;
                    case (SucursalRemove._VOLVER): SUP18.VolverSucursal(ref dt); break;
                }
            }
        }
    }
}
