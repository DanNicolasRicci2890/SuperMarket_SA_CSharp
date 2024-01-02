using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;
using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class SUP13
    {
        public static void EliminarSucursalesST(ref BDState dt)
        {
            dt.SetMState(TypeState._SucursalST, SucursalesST._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSucursalSeek, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._VERIF_SUCUR);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_SEEK);
            dt.COND_SUCURSAL = 3;
        }
        public static void ModificarSucursalesST(ref BDState dt)
        {
            dt.SetMState(TypeState._SucursalST, SucursalesST._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSucursalSeek, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._VERIF_SUCUR);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_SEEK);
            dt.COND_SUCURSAL = 2;
        }
        public static void VisualizarSucursalesST(ref BDState dt)
        {
            dt.SetMState(TypeState._SucursalST, SucursalesST._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSucursalSeek, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._VERIF_SUCUR);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_SEEK);
            dt.COND_SUCURSAL = 1;
        }
        public static void AgregarSucursalesST(ref BDState dt)
        {
            dt.SetMState(TypeState._SucursalST, SucursalesST._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._INACTIVATED);            
            dt.SetMState(TypeState._LiveSucursAddST, LiveProgram._ACTIVATED);            
            dt.SetMState(TypeState._SucursAddST, SucursalesAddST._ADD);            
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_ADD);
            dt.SUCURSALCREATE = new Sucursal();
        }
        public static void ListaSucursalesST(ref BDState dt)
        {
            dt.SetMState(TypeState._SucursalST, SucursalesST._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSucursListST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursListST, SucursalesListST._VERIF_SUCURS);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_LISTER);
        }
        public static void VolverMenuAnterior(ref BDState dt)
        {
            dt.SetMState(TypeState._SucursalST, SucursalesST._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._Administrador, Administrador._MENUOPCION);
            dt.SetMState(TypeState._LiveAdministrador, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._StateMain, StateMain._ADMINISTRADOR);
        }
        public static void MenuOptionSucursal(ref BDState dt)
        {
            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

            string[] selection = { "  Lista de Sucursales    " ,
                                   "  Visualizar Sucursales  " ,
                                   "  Agregar Sucursales     " ,
                                   "  Modificar Sucursales   " ,
                                   "   Eliminar Sucursales   " ,
                                   "          Volver         " };
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            IOMENU menuopcion = new IOMENU("Administracion - SUCURSALES - Menu de Opciones", selection, 4, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 20, 10);
            int roles = 0;
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 0, 0);  // 1
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 1, 1);  // 2
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 2, 2);  // 4
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 3, 3);  // 8
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 4, 4);  // 16
            menuopcion.SetDataInfo(roles + 32);
            menuopcion.Display(color.NEGRO, color.NEGRO);
            int opcion = Convert.ToInt32(menuopcion.GetDataInfo());
            switch (opcion)
            {
                case 0: dt.SetMState(TypeState._SucursalST, SucursalesST._LISTA); break;
                case 1: dt.SetMState(TypeState._SucursalST, SucursalesST._VISUALIZAR); break;
                case 2: dt.SetMState(TypeState._SucursalST, SucursalesST._AGREGAR); break;
                case 3: dt.SetMState(TypeState._SucursalST, SucursalesST._MODIFICAR); break;
                case 4: dt.SetMState(TypeState._SucursalST, SucursalesST._ELIMINAR); break;
                case 5: dt.SetMState(TypeState._SucursalST, SucursalesST._VOLVER); break;
            }
        }
    }
}
