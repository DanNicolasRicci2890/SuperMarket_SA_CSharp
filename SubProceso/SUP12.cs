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
    public class SUP12
    {
        public static void Productos(ref BDState dt)
        {
            dt.SetMState(TypeState._Administrador, Administrador._none);
            dt.SetMState(TypeState._LiveAdministrador, LiveProgram._INACTIVATED);            
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._ACTIVATED);            
            dt.SetMState(TypeState._ProductosST, ProductosST._MENUOPTION);            
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ST);
        }
        public static void Sucursales(ref BDState dt)
        {
            dt.SetMState(TypeState._Administrador, Administrador._none);
            dt.SetMState(TypeState._LiveAdministrador, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalST, SucursalesST._MENUOPCION);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES);
        }
        public static void Volver(ref BDState dt)
        {
            dt.SetMState(TypeState._Administrador, Administrador._none);
            dt.SetMState(TypeState._LiveAdministrador, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SystemUser, SystemUser._PRESENTADOR);
            dt.SetMState(TypeState._StateMain, StateMain._SYSTEM_USER);
        }
        public static void MenuOpcion(ref BDState dt)
        {
            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

            string[] selection = { "  Sucursales   " ,
                                   "   Productos   " ,
                                   "    Volver    " };
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            IOMENU menuopcion = new IOMENU("Administracion - Menu de Opciones", selection, 3, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 20, 10);
            int roles = 0;
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, new int[] { 0, 1, 2, 3, 4 }, 0);
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, new int[] { 5, 6, 7, 8, 9 , 10 , 11 }, 1);            
            menuopcion.SetDataInfo(roles + 4);
            menuopcion.Display(color.NEGRO, color.NEGRO);
            int opcion = Convert.ToInt32(menuopcion.GetDataInfo());
            switch(opcion)
            {
                case 0: dt.SetMState(TypeState._Administrador, Administrador._SUCURSALES); break;
                case 1: dt.SetMState(TypeState._Administrador, Administrador._PRODUCTOS); break;
                case 2: dt.SetMState(TypeState._Administrador, Administrador._VOLVER); break; 
            }
        }
    }
}
