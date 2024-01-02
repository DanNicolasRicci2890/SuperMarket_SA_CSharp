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
    public class SUP18
    {
        public static void MensageP2(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   L O S   D A T O S   ",
                                 "   D E   L A   S U C U R S A L   " ,
                                 "   H A   S I D O   E L I M I N A D O   ",
                                 "   E N   L A   B A S E   ",
                                 "   D  E   D  A  T  O  S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.MAGENTA, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            dt.SetMState(TypeState._SucursalRemove, SucursalRemove._VOLVER);
        }
        public static void EliminarSucursal2(ref BDState dt)
        {
            FDSucursal sucursal = new FDSucursal(dt.SUCURSALCREATE.NOMSUCURSAL, dt.SUCURSALCREATE.CODIGO);
            sucursal.EliminarSucursal();
            dt.SetMState(TypeState._SucursalRemove, SucursalRemove._MENSAGE02);
        }
        public static void EliminarSucursal1(ref BDState dt)
        {
            FDSucursal sucursal = new FDSucursal("ListSucursales");

            // cargar el listado de sucursales
            sucursal.LoadFileSucursales();

            // localizar el objeto a eliminar.
            int posicion = sucursal.IndexListSucursal(dt.SUCURSALCREATE);

            // eliminar la sucursal de la lista
            sucursal.RemoveListSucursal(posicion);

            // guardar la lista de sucursales
            sucursal.SaveFileSucursales();            

            dt.SetMState(TypeState._SucursalRemove, SucursalRemove._ELIMINAR_SUCURSAL2);
        }
        public static void MensageP1(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   L O S   D A T O S   ",
                                 "   D E   L A   S U C U R S A L   " ,
                                 "   N O   H A   S I D O   E L I M I N A D O   ",
                                 "   E N   L A   B A S E   ",
                                 "   D  E   D  A  T  O  S   " };
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.DARK_CYAN, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            dt.SetMState(TypeState._SucursalRemove, SucursalRemove._VOLVER);
        }
        public static void VolverSucursal(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSucursalRemove, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursalRemove, SucursalRemove._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalST, SucursalesST._MENUOPCION);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES);
            dt.SUCURSALCREATE = new Sucursal();
            dt.COND_SUCURSAL = 0;
        }
        public static void ModificaciondeSucursales(ref BDState dt)
        {
            bool estado = true;
            bool script = false;
            int contador = 0;
            string deg = "Administracion - SUCURSALES - Eliminacion de Sucursales ";
            IN key_data = new IN();
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            DRAW.CuadradoSolid(color.BLANCO, 50, 1, 87, 6);
            OUT.PrintLine(deg, color.ROJO, color.BLANCO, 78, 7);
            key_data.SetCondIN(INCond._ENTER);
            key_data.SetCondIN(INCond._ARROWS);
            IODATAINFO NombreSucursal_ = new IODATAINFO(" Nombre de la Sucursal ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 55, 50, 15, 10);
            IODATAINFO Codigo_ = new IODATAINFO(" Codigo Sucursal ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 25, 20, 105, 10);
            IODATAINFO Direccion_ = new IODATAINFO(" Direccion ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 15, 17);
            IODATAINFO Nro_ = new IODATAINFO(" Nro ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 10, 8, 65, 17);
            IODATAINFO CodPost_ = new IODATAINFO("  Cod. Postal ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 10, 7, 90, 17);
            IODATAINFO Provincia_ = new IODATAINFO(" Provincia ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 125, 17);
            IODATAINFO Localidad_ = new IODATAINFO(" Localidad ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 15, 22);
            IODATAINFO Pais_ = new IODATAINFO(" Pais ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 65, 22);
            IOBUTTON btn_ACEPTAR_ = new IOBUTTON("  ELIMINAR  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 71, 30);
            IOBUTTON btn_ESCAPE_ = new IOBUTTON("    SALIR    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 111, 30);

            NombreSucursal_.SetDataInfo(dt.SUCURSALCREATE.NOMSUCURSAL);
            Codigo_.SetDataInfo(dt.SUCURSALCREATE.CODIGO);
            Direccion_.SetDataInfo(dt.SUCURSALCREATE.DIRECCION);
            Nro_.SetDataInfo(dt.SUCURSALCREATE.NUMERO);
            CodPost_.SetDataInfo(dt.SUCURSALCREATE.CODPOST);
            Provincia_.SetDataInfo(dt.SUCURSALCREATE.PROVINCIA);
            Localidad_.SetDataInfo(dt.SUCURSALCREATE.LOCALIDAD);
            Pais_.SetDataInfo(dt.SUCURSALCREATE.PAIS);
            btn_ACEPTAR_.SetDataInfo(false);
            btn_ESCAPE_.SetDataInfo(false);
            
            while (estado)
            {
                NombreSucursal_.SetInactivated();
                Codigo_.SetInactivated();
                Direccion_.SetInactivated();
                Nro_.SetInactivated();
                CodPost_.SetInactivated();
                Provincia_.SetInactivated();
                Localidad_.SetInactivated();
                Pais_.SetInactivated();
                btn_ACEPTAR_.SetInactivated();
                btn_ESCAPE_.SetInactivated();

                if (!script)
                {
                    switch (contador)
                    {
                        case 0: btn_ACEPTAR_.SetSemiInactivated(); break;
                        case 1: btn_ESCAPE_.SetSemiInactivated(); break;
                    }
                }
                if (script)
                {
                    switch (contador)
                    {
                        case 0: btn_ACEPTAR_.SetActivated(); break;
                        case 1: btn_ESCAPE_.SetActivated(); break;
                    }
                }
                NombreSucursal_.Display(color.NEGRO, color.NEGRO);
                Codigo_.Display(color.NEGRO, color.NEGRO);
                Direccion_.Display(color.NEGRO, color.NEGRO);
                Nro_.Display(color.NEGRO, color.NEGRO); 
                CodPost_.Display(color.NEGRO, color.NEGRO); 
                Provincia_.Display(color.NEGRO, color.NEGRO); 
                Localidad_.Display(color.NEGRO, color.NEGRO); 
                Pais_.Display(color.NEGRO, color.NEGRO);
                for (int i = 0; i < 2; i++)
                {
                    if (i != contador)
                    {
                        switch (i)
                        {
                            case 0: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                            case 1: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                        }
                    }
                }
                switch (contador)
                {
                    case 0: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                    case 1: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                }
                if ((bool)btn_ACEPTAR_.GetDataInfo())
                {
                    estado = false;
                    script = true;
                    dt.SetMState(TypeState._SucursalRemove, SucursalRemove._ELIMINAR_SUCURSAL);
                }
                if ((bool)btn_ESCAPE_.GetDataInfo())
                {
                    estado = false;
                    script = true;
                    dt.SetMState(TypeState._SucursalRemove, SucursalRemove._MENSAGE01);
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if (tecla.Equals("RIGHTARROW"))
                    {
                        contador++;
                        if (contador == 2) { contador = 0; }
                    }
                    else
                    {
                        if (tecla.Equals("LEFTARROW"))
                        {
                            contador--;
                            if (contador < 0) { contador = 1; }
                        }
                        else
                        {
                            if (tecla.Equals("ENTER")) { script = true; }
                        }
                    }
                }
                else { script = false; }
            }
        }
    }
}
