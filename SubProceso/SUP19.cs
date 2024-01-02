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
    public class SUP19
    {
        public static void Eliminacion(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSucursalVisual, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursalVisual, SucursalVisual._none);
            dt.SetMState(TypeState._LiveSucursalRemove, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalRemove, SucursalRemove._REMOVE);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_REMOVE);            
        }
        public static void Modificacion(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSucursalVisual, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursalVisual, SucursalVisual._none);
            dt.SetMState(TypeState._LiveSucursalModif, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalModif, SucursalModif._MODIF);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_MODIF);
            dt.COND_SUCURSAL = 4;
        }
        public static void Volver(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSucursalVisual, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursalVisual, SucursalVisual._none);
            if (dt.COND_SUCURSAL == 5)
            {
                dt.SetMState(TypeState._LiveSucursListST, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._SucursListST, SucursalesListST._VERIF_SUCURS);
                dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_LISTER);
            } else
            {
                dt.SetMState(TypeState._LiveSucursalST, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._SucursalST, SucursalesST._MENUOPCION);
                dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES);                
            }
            dt.SUCURSALCREATE = new Sucursal();
            dt.COND_SUCURSAL = 0;
        }
        public static void MenuSucursal(ref BDState dt)
        {
            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

            string[] selection = { "  Modificar Sucursales   " ,
                                   "   Eliminar Sucursales   " ,
                                   "          Volver         " };
            int roles = 0;
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 3, 0);  // 1
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 4, 1);  // 2            
            IOMENU menuopcion = new IOMENU("Administracion - SUCURSALES - Menu de Opciones", selection, 3, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 72, 10);
            menuopcion.SetDataInfo(roles + 4);
            menuopcion.Display(color.NEGRO, color.NEGRO);
            int opcion = Convert.ToInt32(menuopcion.GetDataInfo());
            switch (opcion) 
            {
                case 0: dt.SetMState(TypeState._SucursalVisual, SucursalVisual._MODIF); break;
                case 1: dt.SetMState(TypeState._SucursalVisual, SucursalVisual._REMOVE); break;
                case 2: dt.SetMState(TypeState._SucursalVisual, SucursalVisual._VOLVER); break;
            }
        }
        public static void VisualSucursal(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_VERDE, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            Usuario usuario_sesion = dt.USERSESION;
            
            OUT.PrintLine(usuario_sesion.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + usuario_sesion.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            color[] back = { color.NEGRO, color.NEGRO };
            color[] fore = { color.GRIS, color.CYAN };

            DRAW.CuadradoLineDouble(color.NEGRO, color.DARK_GRIS, 60, 5, 8, 10);
            DRAW.CuadradoLineDouble(color.NEGRO, color.DARK_GRIS, 60, 11, 8, 17);
            
            string[] nombresucursal = { "Nombre de la Sucursal: ", dt.SUCURSALCREATE.NOMSUCURSAL };
            string[] codigo = { "Codigo: ", dt.SUCURSALCREATE.CODIGO };
            string op = String.Concat(dt.SUCURSALCREATE.DIRECCION, " ", dt.SUCURSALCREATE.NUMERO);
            string[] direccion = { "direccion: ", op };
            string[] codigopostal = { "codigo postal: ", dt.SUCURSALCREATE.CODPOST.ToString() };
            string[] provincia = { "provincia: ", dt.SUCURSALCREATE.PROVINCIA };
            string[] localidad = { "localidad: ", dt.SUCURSALCREATE.LOCALIDAD };
            string[] pais = { "pais: ", dt.SUCURSALCREATE.PAIS };

            OUT.PrintLine(nombresucursal, fore, back, 10, 12);
            OUT.PrintLine(codigo, fore, back, 25, 14);
            OUT.PrintLine(direccion, fore, back, 16, 19);
            OUT.PrintLine(codigopostal, fore, back, 12, 21);
            OUT.PrintLine(provincia, fore, back, 16, 23);
            OUT.PrintLine(localidad, fore, back, 16, 25);
            OUT.PrintLine(pais, fore, back, 21, 27);
            dt.SetMState(TypeState._SucursalVisual, SucursalVisual._MENU);
        }
    }
}
