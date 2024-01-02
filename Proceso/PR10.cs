using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR10
    {
        /*
            PR10: (FINALIZADO)
                Ingresa a un menu de estado de usuario:
                        _ Configuracion avanzada.
                        _ Expiracion de cuenta
                        _ Expiracion de password
                        _ Bloqueo de contraseña
                        _ Bloqueo de cuenta
                        _ Reseteo de contraseña
                        _ guardar modificaciones.
        */
        public static void EstadoUsuarioSistema(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSysAdminEstado, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SysAdminEstado)(dt.GetMState(TypeState._SysAdminEstado)))
                {
                    case (SysAdminEstado._MENUOPCION): SUP10.MenuOpcion(ref dt); break;
                    case (SysAdminEstado._VOLVER): SUP10.volvermenu(ref dt); break;
                    case (SysAdminEstado._CONFIG_AVANZADO): SUP10.ConfiguracionAvanzada(ref dt); break;
                    case (SysAdminEstado._EXPIRACION_COUNT): SUP10.ConfigExpiracionCuenta(ref dt); break;
                    case (SysAdminEstado._EXPIRACION_PASSW): SUP10.ConfigExpiracionPassword(ref dt); break;
                    case (SysAdminEstado._BLOQUEO_PASS): SUP10.BloqueoPassword(ref dt); break;
                    case (SysAdminEstado._BLOQUEO_ACOUNT): SUP10.BloqueoAcount(ref dt); break;
                    case (SysAdminEstado._RESET_PASSWORD): SUP10.ResetPasswordAcount(ref dt); break;
                    case (SysAdminEstado._SAVE_USER): SUP10.GuardarDatosUsuario(ref dt); break;
                }
            }
        }
    }
}
