using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR13
    {
        /*
                PR13: (FINALIZADO)
                    Administrador de Sucursales:
                                _ Listear Sucursales
                                _ Crear Sucursales
                                _ Modificar Sucursales
                                _ Visualizar Sucursales
                                _ Eliminar Sucursales
        */
        public static void MenuSucursales(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSucursalST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SucursalesST)(dt.GetMState(TypeState._SucursalST)))
                {
                    case (SucursalesST._MENUOPCION): SUP13.MenuOptionSucursal(ref dt); break;
                    case (SucursalesST._VOLVER): SUP13.VolverMenuAnterior(ref dt); break;
                    case (SucursalesST._LISTA): SUP13.ListaSucursalesST(ref dt); break;
                    case (SucursalesST._AGREGAR): SUP13.AgregarSucursalesST(ref dt); break;
                    case (SucursalesST._VISUALIZAR): SUP13.VisualizarSucursalesST(ref dt); break;
                    case (SucursalesST._MODIFICAR): SUP13.ModificarSucursalesST(ref dt); break;
                    case (SucursalesST._ELIMINAR): SUP13.EliminarSucursalesST(ref dt); break;
                }
            }
        }
    }
}
