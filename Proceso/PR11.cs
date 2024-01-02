using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR11
    {
        /*
            PR11: (FINALIZADO)
                proceso de ingresar roles y permisos a los usuarios que operan 
                el programa.
                    _ Perfiles de usuarios.
                    _ roles de SysAdmin.
                    _ roles de Administrativo.
        */
        public static void OtorgarRolesPermisosUsuario(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSysAdminRolesPer, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SysAdminRolesPerm)(dt.GetMState(TypeState._SysAdminRolesPer)))
                {
                    case (SysAdminRolesPerm._MENUOPCION): SUP11.MenuOpcion(ref dt); break;
                    case (SysAdminRolesPerm._VOLVER): SUP11.Volver(ref dt); break;
                    case (SysAdminRolesPerm._PERFILES): SUP11.Perfiles(ref dt); break;
                    case (SysAdminRolesPerm._PERF_SYSADMIN): SUP11.PerfilesSysAdmin(ref dt); break;
                    case (SysAdminRolesPerm._PERF_ADMINISTRATIVO): SUP11.PerfilesAdministrativo(ref dt); break;
                    case (SysAdminRolesPerm._PERF_CONTADURIA): SUP11.PerfilesContaduria(ref dt); break;
                    case (SysAdminRolesPerm._PERF_DEPOSLOGIC): SUP11.PerfilesDepositoLogica(ref dt); break;
                    case (SysAdminRolesPerm._PERF_CAJERO): SUP11.PerfilesCajero(ref dt); break;
                    case (SysAdminRolesPerm._SAVE_ROLES): SUP11.SaveRolesPermisos(ref dt); break;
                }
            }
        }
    }
}
