using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR02
    {
        /*
            PR02: (FINALIZADO)
                _ Realiza el ingreso de usuario/contraseña.
                _ Realiza el testeo de ingreso de logueo y realiza el proceso de ingreso
        */
        public static void LoginUserPassword(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveLoginUserPass, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((LoginUser)(dt.GetMState(TypeState._LoginUserPass)))
                {
                    case (LoginUser._DISPLAY): SUP02.Display(ref dt); break;
                    case (LoginUser._PRESENT): SUP02.Presentacion(ref dt); break;
                    case (LoginUser._LOGIN): SUP02.IngresoUserPass(ref dt); break;
                    case (LoginUser._SALIR): SUP02.Salida(ref dt); break;
                    case (LoginUser._VERIFICAR): SUP02.Verificador(ref dt); break;
                    case (LoginUser._USER_INEXIT): SUP02.UsuarioInexistente(ref dt); break;
                    case (LoginUser._USER_INHABILITARY): SUP02.UsuarioDeshabilitado(ref dt); break;
                    case (LoginUser._USER_BLOCKED_PASS): SUP02.UsuarioBloqueadoPassword(ref dt); break;
                    case (LoginUser._USER_BLOCKED): SUP02.UsuarioBloqueado(ref dt); break;
                    case (LoginUser._USER_EXPIRATED):  SUP02.UsuarioFechaExpiracion(ref dt); break;
                    case (LoginUser._USER_EXPIRATED_PASS): SUP02.UsuarioFechaExpPassword(ref dt); break;
                    case (LoginUser._ACCESS_DENEGATED): SUP02.AccesoDenegado(ref dt); break;
                    case (LoginUser._ACCESS_ACEPTADED): SUP02.AccesoPermitido(ref dt); break;
                    case (LoginUser._PASS): SUP02.Passrouter(ref dt); break;
                }
            }
        }
    }
}
