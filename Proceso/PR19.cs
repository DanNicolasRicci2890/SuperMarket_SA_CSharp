using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR19
    {
        /*
                PR19: (FINALIZADO)
                    Procede con la visualizacion de una sucursal seleccionada.
                    para su eliminacion o modificacion.
        */
        public static void VisualizarSucursales(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSucursalVisual, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SucursalVisual)(dt.GetMState(TypeState._SucursalVisual)))
                {
                    case (SucursalVisual._VISUAL): SUP19.VisualSucursal(ref dt); break;
                    case (SucursalVisual._MENU): SUP19.MenuSucursal(ref dt); break;
                    case (SucursalVisual._VOLVER): SUP19.Volver(ref dt); break;
                    case (SucursalVisual._MODIF): SUP19.Modificacion(ref dt); break;
                    case (SucursalVisual._REMOVE): SUP19.Eliminacion(ref dt); break;
                }
            }
        }
    }
}
