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
    public class SUP22
    {
        public static void MensageP5(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   L O S   D A T O S   ",
                                 "   H A N   S I D O   ",
                                 "   G U A R D A D O   ",
                                 "   E N   L A   B A S E   ",
                                 "   D  E   ",
                                 "   D  A  T  O  S   " };
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.DARK_CYAN, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            if (dt.POSITION == 2) 
            {
                dt.SetMState(TypeState._LiveProductosAddTypeST, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._none);
                dt.SetMState(TypeState._LiveProductosListTypeST, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._LISTER);
                dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_LISTER_TYPE);
                dt.POSITION = -1;
            }
            else { dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._PRESENT); }
        }
        public static void SaveFileProduct(ref BDState dt)
        {
            FDTypeProduct tp = new FDTypeProduct(dt.TIPRODUCTCREATE.ProductName, dt.TIPRODUCTCREATE.Code);
            tp.SaveProductFile();
            dt.TIPRODUCTCREATE = new TypeProduct();
            dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._MENSAGE5);
        }
        public static void SaveTypeProduct(ref BDState dt)
        {
            FDTypeProduct tp = new FDTypeProduct("ListTypeProduct");
            tp.LoadTypeProductList();
            tp.AddTypeProductList(dt.TIPRODUCTCREATE);
            tp.OrdenamientoTypeProducto();
            tp.SaveTypeProductList();
            dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._SAVE_FILETP);
        }
        public static void MensageP4(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O R R E C T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[5];
            mensaje[0] = "   E L   C O D I G O   D E L   ";
            mensaje[1] = "   T I P O    D E    P R O D U C T O   ";
            mensaje[2] = "   I N G R E S A D O   ";
            mensaje[3] = "   S E    E N C U E N T R A   ";
            mensaje[4] = "   E X I S T E N T E   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[2];
            mensaje[0] = "   I N G R E S E   ";
            mensaje[1] = "   O T R O   C O D I G O   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._PRESENT);
        }
        public static void VerifExitCode(ref BDState dt)
        {
            FDTypeProduct fdtprod = new FDTypeProduct("ListTypeProduct");
            fdtprod.LoadTypeProductList();
            int pos = fdtprod.SeekCodeTypeProduct(dt.TIPRODUCTCREATE.Code);
            if (pos != -1) { dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._MENSAGE4); }
            if (pos == -1) { dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._SAVE_TYPEPROD); }
        }
        public static void MensageP3(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O R R E C T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[5];
            mensaje[0] = "   E L   N O M B R E   D E L   ";
            mensaje[1] = "   T I P O    D E    P R O D U C T O   ";
            mensaje[2] = "   I N G R E S A D O   ";
            mensaje[3] = "   S E    E N C U E N T R A   ";
            mensaje[4] = "   E X I S T E N T E   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[2];
            mensaje[0] = "   I N G R E S E   ";
            mensaje[1] = "   O T R O   N O M B R E   ";            
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._PRESENT);
        }
        public static void VerifExitNom(ref BDState dt)
        {
            FDTypeProduct fdtprod = new FDTypeProduct("ListTypeProduct");
            fdtprod.LoadTypeProductList();
            int pos = fdtprod.SeekNomTypeProduct(dt.TIPRODUCTCREATE.ProductName);
            if (pos == -1) { dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._VERIF_COD); }
            if (pos != -1) { dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._MENSAGE3); }
        }
        public static void MensageP2(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[4];
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   E L   C O D I G O  ";
            mensaje[2] = "   D E L   ";
            mensaje[3] = "   T I P O    D E   P R O D U C T O   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._PRESENT);
        }
        public static void MensageP1(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[4];
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   E L   N O M B R E  ";
            mensaje[2] = "   D E L   ";
            mensaje[3] = "   T I P O    D E   P R O D U C T O   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._PRESENT);
        }
        public static void VerifContenido(ref BDState dt)
        {
            if (!(dt.TIPRODUCTCREATE.ProductName.Equals("")))
            {
                if (!(dt.TIPRODUCTCREATE.Code.Equals("")))
                {
                    dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._VERIF_NOM);
                }
                else { dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._MENSAGE2); }
            } else { dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._MENSAGE1); }
        }
        public static void VolverMenu(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveProductosAddTypeST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._none);
            if (dt.POSITION == 2)
            {
                dt.SetMState(TypeState._LiveProductosListTypeST, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._LISTER);
                dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_LISTER_TYPE);
            } else
            {
                dt.SetMState(TypeState._LiveProductosST, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._ProductosST, ProductosST._MENUOPTION);
                dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ST);
            }            
        }
        public static void IngresarTipoProducto(ref BDState dt)
        {
            bool estado = true, script = false;
            int contador = 0;
            IN key_data = new IN();
            key_data.SetCondIN(INCond._ENTER);
            key_data.SetCondIN(INCond._TAB);
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            IODATAINFO TipoProducto_ = new IODATAINFO(" Tipo de Producto ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 35, 15);
            IODATAINFO Codigo_ = new IODATAINFO(" Codigo ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 15, 10, 97, 15);
            IOBUTTON btn_ACEPTAR_ = new IOBUTTON("   GUARDAR   ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 68, 20);
            IOBUTTON btn_ESCAPE_ = new IOBUTTON("    SALIR    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 97, 20);

            TipoProducto_.SetTypeDataIN(TypeDataIN._LETTER);
            TipoProducto_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            TipoProducto_.SetTypeDataIN(TypeDataIN._SPACE);
            Codigo_.SetTypeDataIN(TypeDataIN._NUMERIC_PAD);

            TipoProducto_.SetDataInfo(dt.TIPRODUCTCREATE.ProductName);
            Codigo_.SetDataInfo(dt.TIPRODUCTCREATE.Code);

            while (estado)
            {
                TipoProducto_.SetInactivated();
                Codigo_.SetInactivated();
                btn_ACEPTAR_.SetInactivated();
                btn_ESCAPE_.SetInactivated();

                if (!script)
                {
                    switch(contador)
                    {
                        case 0: TipoProducto_.SetSemiInactivated(); break;
                        case 1: Codigo_.SetSemiInactivated(); break;
                        case 2: btn_ACEPTAR_.SetSemiInactivated(); break;
                        case 3: btn_ESCAPE_.SetSemiInactivated(); break;
                    }
                }
                if (script)
                {
                    switch (contador)
                    {
                        case 0: TipoProducto_.SetActivated(); break;
                        case 1: Codigo_.SetActivated(); break;
                        case 2: btn_ACEPTAR_.SetActivated(); break;
                        case 3: btn_ESCAPE_.SetActivated(); break;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (i != contador)
                    {
                        switch (i)
                        {
                            case 0: TipoProducto_.Display(color.NEGRO, color.NEGRO); break; 
                            case 1: Codigo_.Display(color.NEGRO, color.NEGRO); break;
                            case 2: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                            case 3: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                        }
                    }
                }
                switch (contador)
                {
                    case 0: TipoProducto_.Display(color.NEGRO, color.NEGRO); break;
                    case 1: Codigo_.Display(color.NEGRO, color.NEGRO); break;
                    case 2: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                    case 3: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                }
                if ((bool)btn_ACEPTAR_.GetDataInfo())
                {
                    dt.TIPRODUCTCREATE.ProductName = Convert.ToString(TipoProducto_.GetDataInfo());
                    dt.TIPRODUCTCREATE.Code = Convert.ToString(Codigo_.GetDataInfo());
                    dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._VERIF_CONT);
                    estado = false;
                }
                if ((bool)btn_ESCAPE_.GetDataInfo())
                {
                    dt.TIPRODUCTCREATE = new TypeProduct();
                    dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._VOLVER);
                    estado = false;
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if (tecla.Equals("TAB"))
                    {
                        contador++;
                        if (contador == 4) { contador = 0; }
                    } else { if (tecla.Equals("ENTER")) { script = true; } }
                }
                else { script = false; }
            }
        }
        public static void Presentador(ref BDState dt)
        {
            string deg = "Administrador - Tipo de Producto - Ingreso";
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            DRAW.CuadradoSolid(color.BLANCO, 44, 1, 70, 8);
            OUT.PrintLine(deg, color.ROJO, color.BLANCO, 72, 9);
            dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._IN_DATA);
        }
    }
}
