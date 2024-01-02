using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR14
    {
        /*
                PR14: (FINALIZADO)
                    Administrar la lista de Sucursales. Seleccionamos una sucursal en la lista
                    y podemos modificar, visualizar o eliminar
        */
        public static void ListaSucursales(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSucursListST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SucursalesListST)(dt.GetMState(TypeState._SucursListST))) 
                {
                    case (SucursalesListST._VERIF_SUCURS): SUP14.VerificarListadoSucursales(ref dt); break;
                    case (SucursalesListST._MENSAGE01): SUP14.Mensage01(ref dt); break;
                    case (SucursalesListST._LISTER): SUP14.ListadoSucursalesSt(ref dt); break;
                    case (SucursalesListST._VOLVER): SUP14.VolverSucursales(ref dt); break;
                    case (SucursalesListST._VISUAL): SUP14.VisualSucursales(ref dt); break;
                }
            }
        }
    }
}
