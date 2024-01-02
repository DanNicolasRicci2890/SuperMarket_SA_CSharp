using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;

namespace SuperMarket_SA
{
    public class SUP05
    {
        public static void RemoveUser(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdmin, SysAdmin._REMOVE_USER);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._VERIFICAR);
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._none);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_SEEK);
            dt.CONDICION_LISTA = LiveProgram._INACTIVATED;
        }
        public static void RolesPermisos(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdmin, SysAdmin._ROLES_PERMISOS);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._VERIFICAR);
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._none);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_SEEK);
            dt.CONDICION_LISTA = LiveProgram._INACTIVATED;
        }
        public static void EstadoUsuario(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdmin, SysAdmin._STATE_USER);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._ACTIVATED);

            dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._VERIFICAR);
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._none);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_SEEK);
            dt.CONDICION_LISTA = LiveProgram._INACTIVATED;
        }
        public static void ModificarUsuario(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdmin, SysAdmin._MODIFI_USER);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._VERIFICAR);
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._none);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_SEEK);
            dt.CONDCREATE = true;
        }
        public static void IngresoUsuario(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdmin, SysAdmin._INGRESO_USER);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._VERIFICAR);
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._none);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_SEEK);
        }
        public static void CrearUsuarios(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdmin, SysAdmin._none);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);            
            dt.SetMState(TypeState._LiveSysAdminCreate, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_CREATE);
            dt.CONDICION_LISTA = LiveProgram._INACTIVATED;
            dt.USERCREATE = new Usuario();
            dt.CONDCREATE = false;
        }
        public static void ListaUsuarios(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdmin, SysAdmin._none);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdminLister, SysAdminLister._VERIFICAR);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_LISTER);
        }
        public static void VolverMain(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdmin, SysAdmin._none);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SystemUser, SystemUser._PRESENTADOR);
            dt.SetMState(TypeState._StateMain, StateMain._SYSTEM_USER);
        }
        public static void MenuSysAdmin(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);

            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

            string[] selopcion = { " Lista de Usuarios " , //1 ---> bit 0
                                   " Crear Usuarios " ,    //2 ---> bit 1
                                   " Ingresar Usuarios al Sistema " , //4 ---> bit 2
                                   " Modificar datos del Usuario " , //8 ---> bit 3
                                   " Estado de Cuenta " , //16 ---> bit 4, 
                                   " Agregar o Modificar Roles " , //32
                                   " Eliminar usuarios " , //64
                                   " Volver al Menu " , }; //128


            Console.ResetColor();
            int estado_condicion = 0;
            IOMENU menuopcion = new IOMENU("SysAdmin - Seguridad Informatica", selopcion, 4, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 12, 10);
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 1, 0);  //" Lista de Usuarios "
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 2, 1);  //" Crear Usuarios "
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 3, 2);  //" Ingresar Usuarios al Sistema "
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 4, 3);  //" Modificar datos del Usuario "

            // " Estado de Cuenta "
            // bit 4 ---> "Habilitar o Deshabilitar"
            // bit 5 ---> "switch para habilitar o deshabilitar la fecha de expiracion."
            // bit 6 ---> "switch para habilitar o deshabilitar la fecha de expiracion de contraseña."
            // bit 7 ---> "fecha de expiracion"
            // bit 8 ---> "fecha de expiracion de contraseña"
            // bit 9 ---> "Bloqueo y desbloqueo de contraseña"
            // bit 10 ---> "Bloqueo y desbloqueo de cuenta"
            // bit 11 ---> "Reseteo de Contraseña"
            
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, new int[] { 5 , 6 , 7 , 8 , 9 , 10 , 11 , 12 } ,4);

            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 13, 5);  //" Agregar o Modificar Roles "
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 14, 6);  //" Eliminar usuarios "

            menuopcion.SetDataInfo(estado_condicion + 128);
            menuopcion.Display(color.NEGRO, color.NEGRO);
            
            int opcion = (int)menuopcion.GetDataInfo();
            switch (opcion)
            {
                case 0: dt.SetMState(TypeState._SysAdmin, SysAdmin._LISTA_USER); break;
                case 1: dt.SetMState(TypeState._SysAdmin, SysAdmin._CREATE_USER); break;
                case 2: dt.SetMState(TypeState._SysAdmin, SysAdmin._INGRESO_USER); break;
                case 3: dt.SetMState(TypeState._SysAdmin, SysAdmin._MODIFI_USER); break;
                case 4: dt.SetMState(TypeState._SysAdmin, SysAdmin._STATE_USER); break;
                case 5: dt.SetMState(TypeState._SysAdmin, SysAdmin._ROLES_PERMISOS); break;
                case 6: dt.SetMState(TypeState._SysAdmin, SysAdmin._REMOVE_USER); break;
                case 7: dt.SetMState(TypeState._SysAdmin, SysAdmin._VOLVER); break;
            }
        }
    }
}
