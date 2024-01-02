using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR16
    {
        /*
                PR16: (FINALIZADO)
                    Realiza la busqueda de una Sucursal para la visualizacion de la misma, para 
                    poder proceder a la visualizacion, modificacion y eliminacion.
        */
        public static void BuscarSucursales(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSucursalSeek, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SucursalesSeek)(dt.GetMState(TypeState._SucursalSeek))) 
                {
                    case (SucursalesSeek._VERIF_SUCUR): SUP16.VerificadorSucursales(ref dt); break;
                    case (SucursalesSeek._MENSAGE01): SUP16.Mensage01(ref dt); break;
                    case (SucursalesSeek._SEEK_SUCURSAL): SUP16.BuscadorSucursal(ref dt); break;
                    case (SucursalesSeek._MENSAGE02): SUP16.Mensage02(ref dt); break;
                    case (SucursalesSeek._CALIFICAR): SUP16.CalificadorSucursales(ref dt); break;
                    case (SucursalesSeek._VISUALIZAR): SUP16.VisualizarSucursales(ref dt); break;
                    case (SucursalesSeek._MODIFICAR): SUP16.ModificarSucursales(ref dt); break;
                    case (SucursalesSeek._ELIMINAR): SUP16.EliminarSucursales(ref dt); break;
                }
            }
        }
    }
}
