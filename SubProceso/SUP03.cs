using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ScreemDisplay;
using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;
using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class SUP03
    {
        public static void Cajero(ref BDState dt)
        {
            dt.SetMState(TypeState._SystemUser, SystemUser._none);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveCajeroST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._CajeroST, CajeroST._LISTER_USER);
            dt.SetMState(TypeState._StateMain, StateMain._CAJEROST);
        }
        public static void DepositoYLogistica(ref BDState dt)
        {
            dt.SetMState(TypeState._SystemUser, SystemUser._none);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveDepotLogicST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._DepotLogicST, DepotLogicST._VERIF_TIPOPRODUCTO);
            dt.SetMState(TypeState._StateMain, StateMain._DEPOTLOGIC);
        }
        public static void Contaduria(ref BDState dt)
        {
            dt.SetMState(TypeState._SystemUser, SystemUser._none);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveContaduriaST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._VERIF_USER);
            dt.SetMState(TypeState._StateMain, StateMain._CONTADURIA);
        }
        public static void Administrator(ref BDState dt)
        {
            dt.SetMState(TypeState._SystemUser, SystemUser._none);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveAdministrador, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._Administrador, Administrador._MENUOPCION);
            dt.SetMState(TypeState._StateMain, StateMain._ADMINISTRADOR);
        }
        public static void SysadminSeg(ref BDState dt)
        {
            dt.SetMState(TypeState._SystemUser, SystemUser._none);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdmin, SysAdmin._MENU);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN);
        }
        public static void PerfilUsuario(ref BDState dt)
        {
            dt.SetMState(TypeState._SystemUser, SystemUser._none);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveUserPerfil, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._UserPerfil, UserPerfil._VIEW);
            dt.SetMState(TypeState._StateMain, StateMain._USER_PERFIL);
        }
        public static void CerrarSesion(ref BDState dt)
        {
            dt.SetMState(TypeState._SystemUser, SystemUser._none);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveLoginUserPass, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._PRESENT);
            dt.SetMState(TypeState._StateMain, StateMain._LOGIN_USER_PASS);
            dt.USERSESION = new Usuario();
        }
        public static void MenuOpcion(ref BDState dt)
        {
            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

            string[] selection = { "  Perfil de Usuario  " , // 1
                                   "  SysAdmin  " , // 2 *
                                   "  Administrativo  " , // 4 *
                                   "  Contaduria  " , // 8 *
                                   "  Sector de Caja  " , // 
                                   "  Deposito y Logistica  " , // 32 *
                                   "  Cerrar Secion  " };
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            IOMENU menuopcion = new IOMENU("Menu de Opciones", selection, 4, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 20, 10);
            int rolesypermisos = 0;
            FUNCTION.StateBit(ref rolesypermisos, dt.USERSESION.SystemSysAdmin, 0, 0); // 1
            FUNCTION.StateBit(ref rolesypermisos, dt.USERSESION.SystemRoles, 0, 1); // 2
            FUNCTION.StateBit(ref rolesypermisos, dt.USERSESION.SystemRoles, 1, 2); // 4
            FUNCTION.StateBit(ref rolesypermisos, dt.USERSESION.SystemRoles, 2, 3); // 8
            FUNCTION.StateBit(ref rolesypermisos, dt.USERSESION.SystemRoles, 3, 4); // 16
            FUNCTION.StateBit(ref rolesypermisos, dt.USERSESION.SystemRoles, 4, 5); // 32
            menuopcion.SetDataInfo(rolesypermisos + 64);
            menuopcion.Display(color.NEGRO, color.NEGRO);
            int opcion = (int)menuopcion.GetDataInfo();
            switch (opcion)
            {
                case 0: dt.SetMState(TypeState._SystemUser, SystemUser._PERFIL_USER); break;
                case 1: dt.SetMState(TypeState._SystemUser, SystemUser._SYSADMIN); break;
                case 2: dt.SetMState(TypeState._SystemUser, SystemUser._ADMINISTRADOR); break;
                case 3: dt.SetMState(TypeState._SystemUser, SystemUser._CONTADURIA); break;
                case 4: dt.SetMState(TypeState._SystemUser, SystemUser._CAJERO); break;
                case 5: dt.SetMState(TypeState._SystemUser, SystemUser._DEPOSITO_LOGISTICA); break;
                case 6: dt.SetMState(TypeState._SystemUser, SystemUser._CERRAR_SESION); break;
            }            
        }
    }
}
