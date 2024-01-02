using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;
using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class SUP16
    {
        public static void BuscadorSucursal(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            string leg = "";
            int tamaño = 0;
            string titulo = "Administracion - SUCURSALES - ";
            switch (dt.COND_SUCURSAL)
            {
                case (1): titulo = String.Concat(titulo, "Visualizar Sucursales"); tamaño = 50; break;
                case (2): titulo = String.Concat(titulo, "Modificacion de Sucursales"); tamaño = 58; break;
                case (3): titulo = String.Concat(titulo, "Eliminar Sucursales"); tamaño = 50; break;
            }
            IOdata.Selector(color.BLANCO, color.AZUL, titulo, tamaño, 70, 8);
            IODATAINFO Codigo_ = new IODATAINFO(" Codigo ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 15, 10, 30, 15);
            Codigo_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Codigo_.SetDataInfo((string)"");
            Codigo_.SetActivated();
            Codigo_.Display(color.NEGRO, color.NEGRO);
            leg = (string)Codigo_.GetDataInfo();
            
            FDSucursal sucursal = new FDSucursal("ListSucursales");
            sucursal.LoadFileSucursales();
            int index = sucursal.SeekCodSucursal(leg);
            dt.SUCURSALCREATE = sucursal.GetSucursal(index);
            if (index != -1) { dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._CALIFICAR); }
            if (index == -1) { dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._MENSAGE02); }
        }
        public static void Mensage01(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O S   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[4];
            mensaje[0] = "   N O    P O S E E   ";
            mensaje[1] = "   S U C U R S A L E S   ";
            mensaje[2] = "   E N   L A   ";
            mensaje[3] = "   B A S E   D E   D A T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._LiveSucursalSeek, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalST, SucursalesST._MENUOPCION);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES);
        }
        public static void VerificadorSucursales(ref BDState dt)
        {
            FDSucursal sucursal = new FDSucursal("ListSucursales");            
            int cont = sucursal.CountListSucursal();
            if (cont > 1) { dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._SEEK_SUCURSAL); }
            if (cont == 1) { dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._MENSAGE01); }
        }
        public static void Mensage02(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O R R E C T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[2];
            mensaje[0] = "   S U C U R S A L    I N G R E S A D O   ";
            mensaje[1] = "   I N E X I S T E N T E   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[3];
            mensaje[0] = "   I N G R E S E   ";
            mensaje[1] = "   U N    C O D I G O   ";
            mensaje[2] = "   E X I S T E N T E   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._LiveSucursalSeek, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalST, SucursalesST._MENUOPCION);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES);
            dt.COND_SUCURSAL = 0;
        }
        public static void CalificadorSucursales(ref BDState dt)
        {
            switch(dt.COND_SUCURSAL)
            {
                case 1: dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._VISUALIZAR); break;
                case 2: dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._MODIFICAR); break;
                case 3: dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._ELIMINAR); break;
            }
        }
        public static void VisualizarSucursales(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSucursalSeek, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._none);
            dt.SetMState(TypeState._LiveSucursalVisual, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalVisual, SucursalVisual._VISUAL);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_VISUAL);
            dt.COND_SUCURSAL = 0;
        }
        public static void ModificarSucursales(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSucursalSeek, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._none);
            dt.SetMState(TypeState._LiveSucursalModif, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalModif, SucursalModif._MODIF);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_MODIF);
            dt.COND_SUCURSAL = 0;
        }
        public static void EliminarSucursales(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSucursalSeek, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursalSeek, SucursalesSeek._none);
            dt.SetMState(TypeState._LiveSucursalRemove, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalRemove, SucursalRemove._REMOVE);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_REMOVE);
            dt.COND_SUCURSAL = 0;
        }
    }
}
