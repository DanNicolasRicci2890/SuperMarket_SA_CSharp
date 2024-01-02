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
    public class SUP28
    {
        public static void Mensage03(ref BDState dt)
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
            dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._TIPO_PRODUCT);
        }
        public static void SaveStockProduct(ref BDState dt)
        {
            FDStockProduct pol = new FDStockProduct("CASA_CENTRAL", "");
            pol.LoadStockProduct();
            pol.AddStockProduct(dt.STOCKPRO, CondStock._INCREMENTO);
            pol.OrdenamientoBurbuja();
            pol.SaveStockProduct();
            dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._MENSAGE03);
        }
        public static void Mensage02(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   E R R O R   ", "   D E   " , "   I N G R E S O   "};
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   C A N T I D A D   ";
            mensaje[1] = "   I N C O R R E C T A   ";            
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._INCREMENT_PRODUCT);
        }
        public static void IncredProducto(ref BDState dt)
        {
            string titulo = " Contaduria - Lista de Productos -  " + dt.PRODUCTCREATE.TProduct.ProductName + " (" + dt.PRODUCTCREATE.TProduct.Code + ")";
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            DRAW.CuadradoSolid(color.BLANCO, titulo.Length + 2, 1, 80, 10);
            OUT.PrintLine(titulo, color.ROJO, color.BLANCO, 82, 11);

            bool estado = true, script = false;
            int contador = 0;
            IN key_data = new IN();
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backSelect = { color.DARK_GRIS, color.AMARILLO, color.DARK_GRIS, color.BLANCO };
            color[] foreSelect = { color.NEGRO, color.AZUL, color.NEGRO, color.VERDE };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };


            string[] switchSelect = FUNCTION.ListTipoProducto();
            string[] switchMoneda = { "Peso", "Dolar" };

            key_data.SetCondIN(INCond._ENTER);
            key_data.SetCondIN(INCond._ARROWS);

            IOSWICHT TipoProducto_ = new IOSWICHT(" tipo de Producto ", switchSelect, backcorral, forecorral, backtitulo, foretitulo, backSelect, foreSelect, TypeLine._DOUBLE, TypePost._LEFT, 20, 16);
            IODATAINFO Codigo_ = new IODATAINFO(" Codigo ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 15, 10, 20, 23);
            IODATAINFO Marca_ = new IODATAINFO(" Marca ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 20, 15, 51, 23);
            IODATAINFO NombreProducto_ = new IODATAINFO(" Nombre de Producto ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 86, 23);
            IODATAINFO TipoCant_ = new IODATAINFO(" Unidad de venta ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 20, 15, 20, 28);
            IODATAINFO CantidadVenta_ = new IODATAINFO(" Cantida por Venta ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 10, 8, 65, 28);
            IOSWICHT Moneda_ = new IOSWICHT(" moneda ", switchMoneda, backcorral, forecorral, backtitulo, foretitulo, backSelect, foreSelect, TypeLine._DOUBLE, TypePost._LEFT, 20, 33);
            IODATAINFO Precio_ = new IODATAINFO(" Precio $ ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 15, 10, 50, 33);
            IODATAINFO Incremento_ = new IODATAINFO(" Cantidad a Comprar ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 15, 10, 90, 33);
            IOBUTTON btn_ACEPTAR_ = new IOBUTTON("  INGRESAR   ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 71, 42);
            IOBUTTON btn_ESCAPE_ = new IOBUTTON("    SALIR    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 111, 42);

            Codigo_.SetTypeDataIN(TypeDataIN._NUMERIC_PAD);
            Marca_.SetTypeDataIN(TypeDataIN._LETTER);
            Marca_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Marca_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Marca_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);
            Marca_.SetTypeDataIN(TypeDataIN._SPACE);
            NombreProducto_.SetTypeDataIN(TypeDataIN._LETTER);
            NombreProducto_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            NombreProducto_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            NombreProducto_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);
            NombreProducto_.SetTypeDataIN(TypeDataIN._SPACE);
            TipoCant_.SetTypeDataIN(TypeDataIN._LETTER);
            TipoCant_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            CantidadVenta_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Precio_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Precio_.SetTypeDataIN(TypeDataIN._CARACTER_SPECIAL);
            Incremento_.SetTypeDataIN(TypeDataIN._NUMERIC_PAD);

            int pos = 0;
            while ((pos < switchSelect.Length) && (switchSelect[pos] != dt.PRODUCTCREATE.TProduct.ProductName))
            {
                pos++;
            }
            TipoProducto_.SetDataInfo(Convert.ToInt32(Math.Pow(2, pos)));
            Codigo_.SetDataInfo(dt.PRODUCTCREATE.Codigo);
            Marca_.SetDataInfo(dt.PRODUCTCREATE.Marca);
            NombreProducto_.SetDataInfo(dt.PRODUCTCREATE.NombreProducto);
            TipoCant_.SetDataInfo(dt.PRODUCTCREATE.TipoCantidad);
            CantidadVenta_.SetDataInfo(dt.PRODUCTCREATE.CantVenta);
            switch (dt.PRODUCTCREATE.Moneda)
            {
                case (TipoMoneda._PESOS): Moneda_.SetDataInfo(1); break;
                case (TipoMoneda._DOLAR): Moneda_.SetDataInfo(2); break;
            }
            Precio_.SetDataInfo(dt.PRODUCTCREATE.Precio.ToString());
            Incremento_.SetDataInfo("");

            TipoProducto_.SetInactivated();
            Codigo_.SetInactivated();
            Marca_.SetInactivated();
            NombreProducto_.SetInactivated();
            TipoCant_.SetInactivated();
            CantidadVenta_.SetInactivated();
            Moneda_.SetInactivated();
            Precio_.SetInactivated();
            Incremento_.SetInactivated();
            btn_ACEPTAR_.SetInactivated();
            btn_ESCAPE_.SetInactivated();
            
            TipoProducto_.Display(color.NEGRO, color.NEGRO);
            Codigo_.Display(color.NEGRO, color.NEGRO); 
            Marca_.Display(color.NEGRO, color.NEGRO);
            NombreProducto_.Display(color.NEGRO, color.NEGRO);
            TipoCant_.Display(color.NEGRO, color.NEGRO);
            CantidadVenta_.Display(color.NEGRO, color.NEGRO);
            Moneda_.Display(color.NEGRO, color.NEGRO);
            Precio_.Display(color.NEGRO, color.NEGRO);
            Incremento_.Display(color.NEGRO, color.NEGRO);
            btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO);
            btn_ESCAPE_.Display(color.NEGRO, color.NEGRO);

            while (estado)
            {
                Incremento_.SetInactivated();
                btn_ACEPTAR_.SetInactivated();
                btn_ESCAPE_.SetInactivated();
                if (!script)
                {
                    switch (contador)
                    {
                        case 0: Incremento_.SetSemiInactivated(); break;
                        case 1: btn_ACEPTAR_.SetSemiInactivated(); break;
                        case 2: btn_ESCAPE_.SetSemiInactivated(); break;
                    }
                }
                if (script)
                {
                    switch (contador)
                    {
                        case 0: Incremento_.SetActivated(); break;
                        case 1: btn_ACEPTAR_.SetActivated(); break;
                        case 2: btn_ESCAPE_.SetActivated(); break;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (i != contador)
                    {
                        switch (i)
                        {
                            case 0: Incremento_.Display(color.NEGRO, color.NEGRO); break;
                            case 1: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                            case 2: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                        }
                    }
                }
                switch (contador)
                {
                    case 0: Incremento_.Display(color.NEGRO, color.NEGRO); break;
                    case 1: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                    case 2: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                }
                if ((bool)btn_ESCAPE_.GetDataInfo())
                {
                    dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._PRODUCT);
                    estado = false;
                }
                if ((bool)btn_ACEPTAR_.GetDataInfo())
                {
                    try
                    {
                        int cantidad = Convert.ToInt32(Incremento_.GetDataInfo().ToString());
                        if (cantidad != 0)
                        {
                            dt.STOCKPRO.Codigo = dt.PRODUCTCREATE.TProduct.Code;
                            dt.STOCKPRO.TipoProducto = dt.PRODUCTCREATE.TProduct.ProductName;
                            dt.STOCKPRO.Marca = dt.PRODUCTCREATE.Marca;
                            dt.STOCKPRO.CodigoProducto = dt.PRODUCTCREATE.Codigo;
                            dt.STOCKPRO.NombreProducto = dt.PRODUCTCREATE.NombreProducto;
                            dt.STOCKPRO.TipoUnidad = dt.PRODUCTCREATE.TipoCantidad;
                            dt.STOCKPRO.StockGondola = 0;
                            dt.STOCKPRO.StockDeposito = cantidad;
                            dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._SAVE_PRODUCT);
                        }
                        else { dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._MENSAGE02); }
                    }
                    catch { dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._MENSAGE02); }                                        
                    estado = false;
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if (tecla.Equals("RIGHTARROW"))
                    {
                        contador++;
                        if (contador == 3) { contador = 0; }
                    }
                    else
                    {
                        if (tecla.Equals("LEFTARROW"))
                        {
                            contador--;
                            if (contador < dt.CONDPRODUCTCREATE) { contador = 2; }
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
        public static void ListerProductos(ref BDState dt)
        {
            List<Producto> lister = new List<Producto>();
            FDProducto opus = new FDProducto(dt.PRODUCTCREATE.TProduct.ProductName, dt.PRODUCTCREATE.TProduct.Code);
            opus.LoadListProduct(ref lister);
            IN key_data = new IN();
            
            key_data.SetCondIN(INCond._ARROWS);
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            
            string titulo = " Contaduria - Lista de Productos -  " + dt.PRODUCTCREATE.TProduct.ProductName + " (" + dt.PRODUCTCREATE.TProduct.Code + ")";
            int fr = titulo.Length + 2;
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            DRAW.CuadradoSolid(color.BLANCO, fr, 1, 80, 10);
            OUT.PrintLine(titulo, color.ROJO, color.BLANCO, 82, 11);

            bool estado = true, script = false;
            int contador = 0, inicio = 0, tope = 0, k = 0, index = 0;

            IOBUTTON btn_AGREGAR_ = new IOBUTTON("  SELECCIONAR  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 15);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("     VOLVER    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 23);
            
            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.BLANCO, new int[] { 20, 50, 20, 20, 30 }, new int[] { 3, 30 }, 10, 15);

            DRAW.CuadradoSolid(color.AZUL, 18, 1, 11, 16);
            DRAW.CuadradoSolid(color.AZUL, 48, 1, 32, 16);
            DRAW.CuadradoSolid(color.AZUL, 18, 1, 83, 16);
            DRAW.CuadradoSolid(color.AZUL, 18, 1, 104, 16);
            DRAW.CuadradoSolid(color.AZUL, 27, 1, 125, 16);
            OUT.PrintLine("     Marca ", color.BLANCO, color.AZUL, 12, 17);
            OUT.PrintLine(" Nombre del Producto ", color.BLANCO, color.AZUL, 35, 17);
            OUT.PrintLine("    Codigo ", color.BLANCO, color.AZUL, 85, 17);
            OUT.PrintLine("  Venta x Unidad ", color.BLANCO, color.AZUL, 105, 17);
            OUT.PrintLine("  PRECIO ", color.BLANCO, color.AZUL, 129, 17);

            btn_AGREGAR_.SetInactivated();
            btn_VOLVER_.SetInactivated();

            btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
            btn_VOLVER_.Display(color.NEGRO, color.NEGRO);

            inicio = 0;
            if (lister.Count < 10) { tope = lister.Count; }
            else { tope = 10; }
            color back = color.none;
            color fore = color.none;
            while (estado)
            {
                btn_AGREGAR_.SetInactivated();
                btn_VOLVER_.SetInactivated();
                btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                if (contador == 0)
                {
                    for (int i = inicio; i < tope; i++)
                    {
                        if (i == index)
                        {
                            back = color.BLANCO;
                            fore = color.MAGENTA;
                        }
                        else
                        {
                            back = color.NEGRO;
                            fore = color.GRIS;
                        }

                        IOdata.Selector(back, fore, lister[i].Marca, 18, 11, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister[i].NombreProducto, 48, 32, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister[i].Codigo, 18, 83, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister[i].TipoCantidad, 18, 104, 20 + (k * 3));

                        string ht = "";
                        switch (lister[i].Moneda)
                        {
                            case TipoMoneda._PESOS: ht = "   $ "; break;
                            case TipoMoneda._DOLAR: ht = " u$s "; break;
                        }
                        ht = String.Concat(ht, lister[i].Precio.ToString());
                        IOdata.Selector(back, fore, ht, 27, 125, 20 + (k * 3));
                        k++;
                    }
                    k = 0;
                }
                if (contador == 1)
                {
                    switch (script)
                    {
                        case false: btn_AGREGAR_.SetSemiInactivated(); break;
                        case true: btn_AGREGAR_.SetActivated(); break;
                    }
                    btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (contador == 2)
                {
                    switch (script)
                    {
                        case false: btn_VOLVER_.SetSemiInactivated(); break;
                        case true: btn_VOLVER_.SetActivated(); break;
                    }
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                }               
                if ((bool)btn_AGREGAR_.GetDataInfo())
                {
                    dt.PRODUCTCREATE = lister[index];
                    dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._INCREMENT_PRODUCT);
                    estado = false;
                    script = true;
                }
                if ((bool)btn_VOLVER_.GetDataInfo())
                {
                    dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._TIPO_PRODUCT);
                    estado = false;
                    script = true;
                }
                if (!(script))
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();

                    if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")) || (tecla.Equals("UPARROW")) || (tecla.Equals("DOWNARROW")))
                    {
                        if (contador == 0)
                        {
                            if (tecla.Equals("DOWNARROW"))
                            {
                                index++;
                                if (index == tope) { index = inicio; }
                            }
                            if (tecla.Equals("UPARROW"))
                            {
                                index--;
                                if (index < inicio) { index = tope; }
                            }
                            if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")))
                            {
                                DRAW.CuadradoSolid(color.NEGRO, 18, 27, 11, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 48, 27, 32, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 18, 27, 83, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 18, 27, 104, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 27, 27, 125, 20);
                                if (tecla.Equals("RIGHTARROW"))
                                {
                                    inicio += 10;
                                    tope += 10;
                                    if ((tope > lister.Count) && (inicio < lister.Count))
                                    {
                                        tope = lister.Count;
                                    }
                                    else
                                    {
                                        if ((tope > lister.Count) && (inicio > lister.Count))
                                        {
                                            inicio = 0;
                                            if (lister.Count < 10) { tope = lister.Count; }
                                            else { tope = 10; }
                                        }
                                    }
                                }
                                if (tecla.Equals("LEFTARROW"))
                                {
                                    inicio -= 10;
                                    tope -= 10;

                                    if ((inicio < 0) && (tope == 0) && (lister.Count > 10))
                                    {
                                        tope = lister.Count;
                                        inicio = (tope / 10) * 10;
                                    }
                                    else
                                    {
                                        if ((inicio < 0) && (tope < 0) && (lister.Count < 10))
                                        {
                                            inicio = 0;
                                            tope = lister.Count;
                                        }
                                        else
                                        {
                                            if (((tope - inicio) < 10) && ((tope % 10) != 0) && ((lister.Count - tope) == 10))
                                            {
                                                tope = inicio + 10;
                                            }
                                        }
                                    }
                                }
                                index = inicio;
                            }
                        }
                    }
                    else
                    {
                        if (tecla.Equals("TAB"))
                        {
                            contador++;
                            if (contador == 3) { contador = 0; }
                        }
                        else
                        {
                            if (tecla.Equals("ENTER"))
                            {
                                if ((contador >= 1) && (contador <= 2))
                                {
                                    script = true;
                                }
                            }
                        }
                    }
                }
                else { script = false; }
            }
        }
        public static void Mensage01(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O S   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[4];
            mensaje[0] = "   N O    P O S E E   ";
            mensaje[1] = "   P R O D U C T O S   D E   ";
            mensaje[2] = FUNCTION.SeparadorEspacio(dt.PRODUCTCREATE.TProduct.ProductName.ToString());
            mensaje[3] = "   E N   L A   B A S E   D E   D A T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._TIPO_PRODUCT);
        }
        public static void VerificarListaProductos(ref BDState dt)
        {
            FDProducto opus = new FDProducto(dt.PRODUCTCREATE.TProduct.ProductName, dt.PRODUCTCREATE.TProduct.Code);
            int count = opus.CountListProducto();

            if (count > 0) { dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._PRODUCT); }
            if (count == 0) { dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._MENSAGE01); }
        }
        public static void VolverContaduria(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveContaduriaProductST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._none);
            dt.SetMState(TypeState._LiveContaduriaST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._VERIF_USER);
            dt.SetMState(TypeState._StateMain, StateMain._CONTADURIA);
            dt.PRODUCTCREATE = new Producto();
            dt.POSITION = -1;
        }
        public static void ListaTipoProductos(ref BDState dt)
        {
            List<TypeProduct> lister = new List<TypeProduct>();
            FDTypeProduct opus = new FDTypeProduct("ListTypeProduct");
            opus.LoadTypeProductList(ref lister);
            IN key_data = new IN();

            key_data.SetCondIN(INCond._ARROWS);
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            string titulo = " Contaduria - Lista de Tipos de Productos - Ingreso de Stock";
            int fr = titulo.Length + 2;
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            DRAW.CuadradoSolid(color.BLANCO, fr, 1, 80, 10);
            OUT.PrintLine(titulo, color.ROJO, color.BLANCO, 82, 11);

            bool estado = true, script = false;
            int contador = 0, inicio = 0, tope = 0, k = 0, index = 0;

            IOBUTTON btn_AGREGAR_ = new IOBUTTON("  SELECCIONAR  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 15);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("     VOLVER    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 23);
            

            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.BLANCO, new int[] { 50, 20, 25 }, new int[] { 3, 30 }, 10, 15);

            DRAW.CuadradoSolid(color.AZUL, 48, 1, 11, 16);
            DRAW.CuadradoSolid(color.AZUL, 18, 1, 62, 16);
            DRAW.CuadradoSolid(color.AZUL, 22, 1, 83, 16);
            OUT.PrintLine(" Tipo de Producto ", color.BLANCO, color.AZUL, 25, 17);
            OUT.PrintLine("     Codigo ", color.BLANCO, color.AZUL, 63, 17);
            OUT.PrintLine(" Cant/Producto ", color.BLANCO, color.AZUL, 85, 17);


            btn_AGREGAR_.SetInactivated();
            btn_VOLVER_.SetInactivated();

            btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
            btn_VOLVER_.Display(color.NEGRO, color.NEGRO);

            inicio = 0;
            if (lister.Count < 10) { tope = lister.Count; }
            else { tope = 10; }
            color back = color.none;
            color fore = color.none;
            while (estado)
            {
                btn_AGREGAR_.SetInactivated();
                btn_VOLVER_.SetInactivated();
                btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                if (contador == 0)
                {
                    for (int i = inicio; i < tope; i++)
                    {
                        if (i == index)
                        {
                            back = color.BLANCO;
                            fore = color.MAGENTA;
                        }
                        else
                        {
                            back = color.NEGRO;
                            fore = color.GRIS;
                        }

                        IOdata.Selector(back, fore, lister[i].ProductName, 48, 11, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister[i].Code, 18, 62, 20 + (k * 3));
                        FDProducto opus2 = new FDProducto(lister[i].ProductName, lister[i].Code);
                        int countproduct = opus2.CountListProducto();
                        IOdata.Selector(back, fore, countproduct.ToString(), 22, 83, 20 + (k * 3));
                        k++;
                    }
                    k = 0;
                }
                if (contador == 1)
                {
                    switch (script)
                    {
                        case false: btn_AGREGAR_.SetSemiInactivated(); break;
                        case true: btn_AGREGAR_.SetActivated(); break;
                    }
                    btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (contador == 2)
                {
                    switch (script)
                    {
                        case false: btn_VOLVER_.SetSemiInactivated(); break;
                        case true: btn_VOLVER_.SetActivated(); break;
                    }
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)btn_AGREGAR_.GetDataInfo())
                {
                    dt.PRODUCTCREATE.TProduct = lister[index];
                    dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._VERIF_TIPO_PRODUCT);
                    estado = false;
                    script = true;
                }
                if ((bool)btn_VOLVER_.GetDataInfo())
                {
                    dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._VOLVER);
                    estado = false;
                    script = true;
                }
                if (!(script))
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();

                    if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")) || (tecla.Equals("UPARROW")) || (tecla.Equals("DOWNARROW")))
                    {
                        if (contador == 0)
                        {
                            if (tecla.Equals("DOWNARROW"))
                            {
                                index++;
                                if (index == tope) { index = inicio; }
                            }
                            if (tecla.Equals("UPARROW"))
                            {
                                index--;
                                if (index < inicio) { index = tope; }
                            }
                            if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")))
                            {
                                DRAW.CuadradoSolid(color.NEGRO, 48, 27, 11, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 17, 27, 62, 20);

                                if (tecla.Equals("RIGHTARROW"))
                                {
                                    inicio += 10;
                                    tope += 10;
                                    if ((tope > lister.Count) && (inicio < lister.Count))
                                    {
                                        tope = lister.Count;
                                    }
                                    else
                                    {
                                        if ((tope > lister.Count) && (inicio > lister.Count))
                                        {
                                            inicio = 0;
                                            if (lister.Count < 10) { tope = lister.Count; }
                                            else { tope = 10; }
                                        }
                                    }
                                }
                                if (tecla.Equals("LEFTARROW"))
                                {
                                    inicio -= 10;
                                    tope -= 10;

                                    if ((inicio < 0) && (tope == 0) && (lister.Count > 10))
                                    {
                                        tope = lister.Count;
                                        inicio = (tope / 10) * 10;
                                    }
                                    else
                                    {
                                        if ((inicio < 0) && (tope < 0) && (lister.Count < 10))
                                        {
                                            inicio = 0;
                                            tope = lister.Count;
                                        }
                                        else
                                        {
                                            if (((tope - inicio) < 10) && ((tope % 10) != 0) && ((lister.Count - tope) == 10))
                                            {
                                                tope = inicio + 10;
                                            }
                                        }
                                    }
                                }
                                index = inicio;
                            }
                        }
                    }
                    else
                    {
                        if (tecla.Equals("TAB"))
                        {
                            contador++;
                            if (contador == 3) { contador = 0; }
                        }
                        else
                        {
                            if (tecla.Equals("ENTER"))
                            {
                                if ((contador >= 1) && (contador <= 2))
                                {
                                    script = true;
                                }
                            }
                        }
                    }
                }
                else { script = false; }
            }
        }
    }
}
