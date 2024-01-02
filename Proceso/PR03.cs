using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR03
    {
        /*
            PR03: (FINALIZADO)
                Ingreso al menu principal de los tipos de Perfiles:
                    _ Perfil del usuario (el perfil del usuario que ingresa en seccion)
                    _ SysAdmin (perfil de seguridad informatica)
                    _ Administrador (Administrador de sucursales, productos y stock de sucursales)
        */
        public static void SystemUserData(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSystemUser, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SystemUser)(dt.GetMState(TypeState._SystemUser)))
                {
                    case (SystemUser._PRESENTADOR): SUP03.MenuOpcion(ref dt); break;
                    case (SystemUser._CERRAR_SESION): SUP03.CerrarSesion(ref dt); break;
                    case (SystemUser._PERFIL_USER): SUP03.PerfilUsuario(ref dt); break;
                    case (SystemUser._SYSADMIN): SUP03.SysadminSeg(ref dt); break;
                    case (SystemUser._ADMINISTRADOR): SUP03.Administrator(ref dt); break;
                    case (SystemUser._CONTADURIA): SUP03.Contaduria(ref dt); break;
                    case (SystemUser._CAJERO): SUP03.Cajero(ref dt); break;
                    case (SystemUser._DEPOSITO_LOGISTICA): SUP03.DepositoYLogistica(ref dt); break;
                }
            }
        }
        
    }
}
