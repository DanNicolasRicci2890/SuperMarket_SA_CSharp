using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR05
    {
        /*
            PR05: (FINALIZADO)
                Se realiza los accesos de SYSADMIN
                    _ Ingreso a la lista de usuarios
                    _ Crear usuarios
                    _ Ingreso de usuarios al sistema.
                    _ Modificar usuarios
                    _ ver y modificar el estado del usuario
                    _ Roles y permisos de usuarios
        */
        public static void SysAdminSeg(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSysAdmin, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SysAdmin)(dt.GetMState(TypeState._SysAdmin))) 
                {
                    case (SysAdmin._MENU): SUP05.MenuSysAdmin(ref dt); break;
                    case (SysAdmin._VOLVER): SUP05.VolverMain(ref dt); break;
                    case (SysAdmin._LISTA_USER): SUP05.ListaUsuarios(ref dt); break;
                    case (SysAdmin._CREATE_USER): SUP05.CrearUsuarios(ref dt); break;
                    case (SysAdmin._INGRESO_USER): SUP05.IngresoUsuario(ref dt); break;
                    case (SysAdmin._MODIFI_USER): SUP05.ModificarUsuario(ref dt); break;
                    case (SysAdmin._STATE_USER): SUP05.EstadoUsuario(ref dt); break;
                    case (SysAdmin._ROLES_PERMISOS): SUP05.RolesPermisos(ref dt); break;
                    case (SysAdmin._REMOVE_USER): SUP05.RemoveUser(ref dt); break;
                }
            }
        }
    }
}
