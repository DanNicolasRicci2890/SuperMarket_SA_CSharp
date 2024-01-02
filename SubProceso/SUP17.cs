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
    public class SUP17
    {
        public static void MensageP7(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   L O S   D A T O S   ",
                                 "   D E   L A   S U C U R S A L   " ,
                                 "   H A N   S I D O   G U A R D A D A   ",
                                 "   E N   L A   B A S E   ",
                                 "   D  E   D  A  T  O  S   " };
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.DARK_CYAN, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            dt.SetMState(TypeState._SucursalModif, SucursalModif._VOLVER);
        }
        public static void ModificarSucursal(ref BDState dt)
        {
            FDSucursal sucursal = new FDSucursal("ListSucursales");

            // cargar la lista de sucursales.
            sucursal.LoadFileSucursales();

            // buscar la posicion donde se aloja la sucursal designada
            int index = sucursal.IndexListSucursal(dt.SUCURSALCREATE);

            // reemplazar la sucursal anterio por la modificada
            if (index != -1)
            {
                sucursal.ReplaceListSucursal(index, dt.SUCURSALCREATE);
            }

            // ordenar la lista de sucursales
            sucursal.OrdenamientoSucursal();

            // guardar la lista de sucursales
            sucursal.SaveFileSucursales();
            
            dt.SetMState(TypeState._SucursalModif, SucursalModif._MENSAGE07);
        }
        public static void MensageP6(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[3];
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   E L   P A I S   D E   ";
            mensaje[2] = "   L A   S U C U R S A L   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SucursalModif, SucursalModif._MODIF);
        }
        public static void MensageP5(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[3];
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   L A   L O C A L I D A D   ";
            mensaje[2] = "   D E   L A   S U C U R S A L   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SucursalModif, SucursalModif._MODIF);
        }
        public static void MensageP4(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[3];
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   L A   P R O V I N C I A   ";
            mensaje[2] = "   D E   L A   S U C U R S A L   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SucursalModif, SucursalModif._MODIF);
        }
        public static void MensageP3(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[3];
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   E L   C O D I G O   P O S T A L   ";
            mensaje[2] = "   D E   L A   S U C U R S A L   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SucursalModif, SucursalModif._MODIF);
        }
        public static void MensageP2(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[3];
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   E L   N U M E R O   D E   ";
            mensaje[2] = "   L A   S U C U R S A L   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SucursalModif, SucursalModif._MODIF);
        }
        public static void MensageP1(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[3];
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   L A   D I R E C C I O N   D E   ";
            mensaje[2] = "   L A   S U C U R S A L   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SucursalModif, SucursalModif._MODIF);
        }
        public static void VerificadorDatos(ref BDState dt)
        {
            dt.SetMState(TypeState._SucursalModif, SucursalModif._MENSAGE01);
            if (!(dt.SUCURSALCREATE.DIRECCION.Equals("")))
            {
                dt.SetMState(TypeState._SucursalModif, SucursalModif._MENSAGE02);
                if (!(dt.SUCURSALCREATE.NUMERO.Equals("")))
                {
                    dt.SetMState(TypeState._SucursalModif, SucursalModif._MENSAGE03);
                    if (!(dt.SUCURSALCREATE.CODPOST.Equals("")))
                    {
                        dt.SetMState(TypeState._SucursalModif, SucursalModif._MENSAGE04);
                        if (!(dt.SUCURSALCREATE.PROVINCIA.Equals("")))
                        {
                            dt.SetMState(TypeState._SucursalModif, SucursalModif._MENSAGE05);
                            if (!(dt.SUCURSALCREATE.LOCALIDAD.Equals("")))
                            {
                                dt.SetMState(TypeState._SucursalModif, SucursalModif._MENSAGE06);
                                if (!(dt.SUCURSALCREATE.PAIS.Equals("")))
                                {
                                    dt.SetMState(TypeState._SucursalModif, SucursalModif._MODIF_SUCURSAL);
                                }
                            }
                        }

                    }
                }
            }
        }
        public static void VolverSucursal(ref BDState dt) 
        {
            dt.SetMState(TypeState._LiveSucursalModif, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursalModif, SucursalModif._none);
            if (dt.COND_SUCURSAL == 4)
            {
                dt.SetMState(TypeState._LiveSucursalVisual, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._SucursalVisual, SucursalVisual._VISUAL);
                dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_VISUAL);
            }
            else
            {
                dt.SetMState(TypeState._LiveSucursalST, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._SucursalST, SucursalesST._MENUOPCION);
                dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES);
                dt.SUCURSALCREATE = new Sucursal();
                dt.COND_SUCURSAL = 0;
            }            
        }
        public static void ModificaciondeSucursales(ref BDState dt)
        {
            bool estado = true;
            bool script = false;
            int contador = 0;
            string deg = "Administracion - SUCURSALES - Modificacion de Sucursales ";
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
            IOBUTTON btn_ACEPTAR_ = new IOBUTTON("  MODIFICAR  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 71, 30);
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

            Direccion_.SetTypeDataIN(TypeDataIN._LETTER);
            Direccion_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Direccion_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Direccion_.SetTypeDataIN(TypeDataIN._CARACTER_SPECIAL);
            Direccion_.SetTypeDataIN(TypeDataIN._SHIFT_CARACTER_SPECIAL);
            Direccion_.SetTypeDataIN(TypeDataIN._SPACE);
            Nro_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            CodPost_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Provincia_.SetTypeDataIN(TypeDataIN._LETTER);
            Provincia_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Provincia_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Provincia_.SetTypeDataIN(TypeDataIN._SPACE);
            Localidad_.SetTypeDataIN(TypeDataIN._LETTER);
            Localidad_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Localidad_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Localidad_.SetTypeDataIN(TypeDataIN._SPACE);
            Pais_.SetTypeDataIN(TypeDataIN._LETTER);
            Pais_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Pais_.SetTypeDataIN(TypeDataIN._SPACE);

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
                        case 0: Direccion_.SetSemiInactivated(); break;
                        case 1: Nro_.SetSemiInactivated(); break;
                        case 2: CodPost_.SetSemiInactivated(); break;
                        case 3: Provincia_.SetSemiInactivated(); break;
                        case 4: Localidad_.SetSemiInactivated(); break;
                        case 5: Pais_.SetSemiInactivated(); break;
                        case 6: btn_ACEPTAR_.SetSemiInactivated(); break;
                        case 7: btn_ESCAPE_.SetSemiInactivated(); break;
                    }
                }
                if (script)
                {
                    switch (contador)
                    {
                        case 0: Direccion_.SetActivated(); break;
                        case 1: Nro_.SetActivated(); break;
                        case 2: CodPost_.SetActivated(); break;
                        case 3: Provincia_.SetActivated(); break;
                        case 4: Localidad_.SetActivated(); break;
                        case 5: Pais_.SetActivated(); break;
                        case 6: btn_ACEPTAR_.SetActivated(); break;
                        case 7: btn_ESCAPE_.SetActivated(); break;
                    }
                }
                NombreSucursal_.Display(color.NEGRO, color.NEGRO);
                Codigo_.Display(color.NEGRO, color.NEGRO);
                for (int i = 0; i < 8; i++)
                {
                    if (i != contador)
                    {
                        switch (i)
                        {
                            case 0: Direccion_.Display(color.NEGRO, color.NEGRO); break;
                            case 1: Nro_.Display(color.NEGRO, color.NEGRO); break;
                            case 2: CodPost_.Display(color.NEGRO, color.NEGRO); break;
                            case 3: Provincia_.Display(color.NEGRO, color.NEGRO); break;
                            case 4: Localidad_.Display(color.NEGRO, color.NEGRO); break;
                            case 5: Pais_.Display(color.NEGRO, color.NEGRO); break;
                            case 6: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                            case 7: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                        }
                    }
                }
                switch (contador)
                {
                    case 0: Direccion_.Display(color.NEGRO, color.NEGRO); break;
                    case 1: Nro_.Display(color.NEGRO, color.NEGRO); break;
                    case 2: CodPost_.Display(color.NEGRO, color.NEGRO); break;
                    case 3: Provincia_.Display(color.NEGRO, color.NEGRO); break;
                    case 4: Localidad_.Display(color.NEGRO, color.NEGRO); break;
                    case 5: Pais_.Display(color.NEGRO, color.NEGRO); break;
                    case 6: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                    case 7: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                }
                if ((bool)btn_ACEPTAR_.GetDataInfo())
                {
                    dt.SUCURSALCREATE.DIRECCION = Direccion_.GetDataInfo().ToString();
                    dt.SUCURSALCREATE.NUMERO = Convert.ToInt32(Nro_.GetDataInfo());
                    dt.SUCURSALCREATE.CODPOST = Convert.ToInt32(CodPost_.GetDataInfo());
                    dt.SUCURSALCREATE.PROVINCIA = Provincia_.GetDataInfo().ToString();
                    dt.SUCURSALCREATE.LOCALIDAD = Localidad_.GetDataInfo().ToString();
                    dt.SUCURSALCREATE.PAIS = Pais_.GetDataInfo().ToString();
                    estado = false;
                    script = true;
                    dt.SetMState(TypeState._SucursalModif, SucursalModif._VERIF_DATOS);
                }
                if ((bool)btn_ESCAPE_.GetDataInfo())
                {
                    estado = false;
                    script = true;
                    dt.SetMState(TypeState._SucursalModif, SucursalModif._VOLVER);
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if (tecla.Equals("RIGHTARROW"))
                    {
                        contador++;
                        if (contador == 8) { contador = 0; }
                    }
                    else
                    {
                        if (tecla.Equals("LEFTARROW"))
                        {
                            contador--;
                            if (contador < 0) { contador = 7; }
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
        public static void VerificarSucursales(ref BDState dt)
        {

        }
    }
}
