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
    public class SUP33
    {
        public static void Mensage03(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   S T O C K   D E   S U C U R S A L   ", "   M O D I F I C A D O   " };
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.CYAN, 100, 20);
            dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._LISTER_PRODUCTO);
        }
        public static void SaveListProduct(ref BDState dt)
        {
            FDStockProduct stock = new FDStockProduct(dt.SUCURSALCREATE.NOMSUCURSAL, dt.SUCURSALCREATE.CODIGO);
            stock.LoadStockProduct();
            int index = stock.SeekStockProduct(dt.STOCKPRO.CodigoProducto);
            stock.RemoveStockProduct(index);
            stock.AddStockProduct(dt.STOCKPRO, CondStock._INCREMENTO);
            stock.OrdenamientoBurbuja();
            stock.SaveStockProduct();
            dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._MENSAGE03);
        }
        public static void Mensage02(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   C A N T I D A D   I N G R E S A D A   ", "   E R R O N E O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[4];
            mensaje[0] = "   I N G R E S E    L A    C A N T I D A D   ";
            mensaje[1] = "   C O R R E C T A   ";
            mensaje[2] = "   Q U E   N O   S U P E R E   ";
            mensaje[3] = "   E L   S T O C K    M A X I M O   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._SELECT_PRODUCTO);
        }
        public static void DespositoGondola(ref BDState dt)
        {
            bool estado = true, script = false;
            int contador = 0;
            string tecla = "";
            int deposito = dt.STOCKPRO.StockDeposito;
            int gondola = dt.STOCKPRO.StockGondola;

            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            IOdata.Selector(color.BLANCO, color.AZUL, " Deposito y Logistica - Envio de Mercaderia ", 44, 64, 8);

            string ht = String.Concat("  ", dt.SUCURSALCREATE.NOMSUCURSAL, "_", dt.SUCURSALCREATE.CODIGO, "  ");
            IOdata.Selector(color.GRIS, color.MAGENTA, ht, ht.Length, 57, 14);
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            IODATAINFO Stock_ = new IODATAINFO(" Cant de Stock ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 20, 28);
            IOBUTTON btn_SELECCIONAR_ = new IOBUTTON("   MODIFICAR   ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 20, 33);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("     VOLVER    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 48, 33);
            IN key_data = new IN();

            OUT.PrintLine(" Tipo de Producto: ", color.BLANCO, color.NEGRO, 20, 18);
            OUT.PrintLine(" Producto: ", color.BLANCO, color.NEGRO, 28, 20);
            OUT.PrintLine(" tipo de unidad: ", color.BLANCO, color.NEGRO, 22, 22);
            OUT.PrintLine(" Stock en Deposito: ", color.BLANCO, color.NEGRO, 19, 24);
            OUT.PrintLine("  Stock en Gondola: ", color.BLANCO, color.NEGRO, 19, 26);

            string hg = String.Concat("(", dt.STOCKPRO.Codigo, ") ", dt.STOCKPRO.TipoProducto);
            OUT.PrintLine(hg, color.ROJO, color.NEGRO, 40, 18);
            hg = String.Concat(dt.STOCKPRO.Marca, " - ", dt.STOCKPRO.NombreProducto, " (", dt.STOCKPRO.CodigoProducto, ")");
            OUT.PrintLine(hg, color.ROJO, color.NEGRO, 40, 20);
            OUT.PrintLine(dt.STOCKPRO.TipoUnidad, color.ROJO, color.NEGRO, 40, 22);
            Stock_.SetDataInfo("");
            btn_SELECCIONAR_.SetDataInfo(false);
            btn_VOLVER_.SetDataInfo(false);
            Stock_.SetTypeDataIN(TypeDataIN._NUMERIC_PAD);
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            while (estado)
            {
                OUT.PrintLine(deposito.ToString(), color.ROJO, color.NEGRO, 40, 24);
                OUT.PrintLine(gondola.ToString(), color.ROJO, color.NEGRO, 40, 26);

                if (contador == 0)
                {
                    btn_SELECCIONAR_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    switch(script)
                    {
                        case false: Stock_.SetSemiInactivated(); break;
                        case true: Stock_.SetActivated(); break;
                    }
                    btn_SELECCIONAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    Stock_.Display(color.NEGRO, color.NEGRO);
                }
                if (contador == 1)
                {
                    Stock_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_SELECCIONAR_.SetSemiInactivated(); break;
                        case true: btn_SELECCIONAR_.SetActivated(); break;
                    }
                    Stock_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_SELECCIONAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (contador == 2)
                {
                    Stock_.SetInactivated();
                    btn_SELECCIONAR_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_VOLVER_.SetSemiInactivated(); break;
                        case true: btn_VOLVER_.SetActivated(); break;
                    }
                    Stock_.Display(color.NEGRO, color.NEGRO);
                    btn_SELECCIONAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);                    
                }
                if ((bool)(btn_SELECCIONAR_.GetDataInfo()))
                {
                    btn_SELECCIONAR_.SetDataInfo(false);

                    if ((deposito != dt.STOCKPRO.StockDeposito) && (gondola != dt.STOCKPRO.StockGondola))
                    {
                        dt.STOCKPRO.StockDeposito = deposito;
                        dt.STOCKPRO.StockGondola = gondola;
                        dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._SAVESTOCK);
                        estado = false;
                    }
                }
                if ((bool)(btn_VOLVER_.GetDataInfo()))
                {
                    dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._LISTER_PRODUCTO);
                    estado = false;
                }
                if (!script)
                {
                    tecla = key_data.InputMode();
                    if (tecla.Equals("TAB"))
                    {
                        contador++;
                        if (contador == 3) { contador = 0; }
                    }
                    else
                    {
                        if (tecla.Equals("ENTER"))
                        {
                            script = true;
                        }
                    }
                } 
                else 
                { 
                    script = false; 
                    if (contador == 0)
                    {
                        string getvalor = Stock_.GetDataInfo().ToString();
                        if (getvalor.Length != 0)
                        {
                            int valorget = Convert.ToInt32(getvalor);
                            if (valorget <= deposito)
                            {
                                deposito -= valorget;
                                gondola += valorget;
                                OUT.PrintLine("                    ", color.ROJO, color.NEGRO, 40, 24);
                                OUT.PrintLine("                    ", color.ROJO, color.NEGRO, 40, 26);
                            }
                            else 
                            { 
                                estado = false;
                                dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._MENSAGE02); 
                            }
                        }
                    }
                }
            }
        }
        public static void SeccionProducto(ref BDState dt)
        {
            List<StockProduct> lister_stock = new List<StockProduct>();
            List<TypeProduct> lister_typep = new List<TypeProduct>();

            FDStockProduct opus_stock = new FDStockProduct(dt.SUCURSALCREATE.NOMSUCURSAL, dt.SUCURSALCREATE.CODIGO);
            FDTypeProduct opus_typep = new FDTypeProduct("ListTypeProduct");

            opus_typep.LoadTypeProductList(ref lister_typep);

            IN key_data = new IN();

            key_data.SetCondIN(INCond._ARROWS);
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            string titulo = " Deposito y Logistica - Lista de Stock - ";
            string tecla = "";

            titulo = String.Concat(titulo, dt.SUCURSALCREATE.NOMSUCURSAL, "_", dt.SUCURSALCREATE.CODIGO);
            titulo = String.Concat("  ", titulo, "  ");
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();

            IOdata.SelectorMedio(color.BLANCO, color.ROJO, titulo, titulo.Length, 80, 9);

            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.BLANCO, new int[] { 30, 20, 40, 20, 15, 25 , 25 }, new int[] { 3, 30 }, 10, 15);
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            IOBUTTON btn_SELECCIONAR_ = new IOBUTTON("  SELECCIONAR  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 200, 15);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("     VOLVER    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 200, 22);

            btn_SELECCIONAR_.SetDataInfo(false);
            btn_VOLVER_.SetDataInfo(false);

            DRAW.CuadradoSolid(color.AZUL, 28, 1, 11, 16);
            DRAW.CuadradoSolid(color.AZUL, 18, 1, 42, 16);
            DRAW.CuadradoSolid(color.AZUL, 38, 1, 63, 16);
            DRAW.CuadradoSolid(color.AZUL, 18, 1, 104, 16);
            DRAW.CuadradoSolid(color.AZUL, 13, 1, 125, 16);
            DRAW.CuadradoSolid(color.AZUL, 23, 1, 141, 16);
            DRAW.CuadradoSolid(color.AZUL, 22, 1, 167, 16);
            OUT.PrintLine("    Grupo de Producto ", color.BLANCO, color.AZUL, 12, 17);
            OUT.PrintLine("   Marca ", color.BLANCO, color.AZUL, 45, 17);
            OUT.PrintLine(" Nombre del Producto ", color.BLANCO, color.AZUL, 73, 17);
            OUT.PrintLine("    Codigo ", color.BLANCO, color.AZUL, 105, 17);
            OUT.PrintLine(" Tipo Unidad ", color.BLANCO, color.AZUL, 126, 17);
            OUT.PrintLine(" STOCK EN DEPOSITO ", color.BLANCO, color.AZUL, 144, 17);
            OUT.PrintLine(" STOCK EN GONDOLA ", color.BLANCO, color.AZUL, 169, 17);

            color back = color.none;
            color fore = color.none;

            bool estado = true, comod = true, script = false;
            int i = 0, inicio = 0, tope = 0, k = 0, index = 0, contador = 0;

            while (estado)
            {
                if (contador == 0)
                {
                    btn_SELECCIONAR_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    btn_SELECCIONAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    if (comod)
                    {
                        comod = false;
                        while (lister_stock.Count == 0)
                        {
                            opus_stock.LoadStockProduct(ref lister_stock, lister_typep[i].Code);
                            i++;
                            if (i == lister_typep.Count) { i = 0; }
                        }
                        inicio = 0;
                        if (lister_stock.Count < 10) { tope = lister_stock.Count; }
                        else { tope = 10; }
                        index = inicio;
                    }
                    k = 0;
                    for (int j = 0; j < tope; j++)
                    {
                        if (index == j)
                        {
                            back = color.BLANCO;
                            fore = color.ROJO;
                        }
                        else
                        {
                            back = color.NEGRO;
                            fore = color.GRIS;
                        }

                        IOdata.Selector(back, fore, String.Concat(lister_stock[j].TipoProducto, "(", lister_stock[j].Codigo, ")"), 28, 11, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister_stock[j].Marca, 18, 42, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister_stock[j].NombreProducto, 38, 63, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister_stock[j].CodigoProducto, 18, 104, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister_stock[j].TipoUnidad, 13, 125, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister_stock[j].StockDeposito.ToString(), 23, 141, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister_stock[j].StockGondola.ToString(), 22, 167, 20 + (k * 3));
                        k++;
                    }
                }
                if (contador == 1)
                {
                    if (!script)
                    {
                        btn_SELECCIONAR_.SetSemiInactivated();
                        btn_VOLVER_.SetInactivated();
                    }
                    if (script)
                    {
                        btn_SELECCIONAR_.SetActivated();
                        btn_VOLVER_.SetInactivated();
                    }
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_SELECCIONAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (contador == 2)
                {
                    if (!script)
                    {
                        btn_VOLVER_.SetSemiInactivated();
                        btn_SELECCIONAR_.SetInactivated();
                    }
                    if (script)
                    {
                        btn_VOLVER_.SetActivated();
                        btn_SELECCIONAR_.SetInactivated();
                    }
                    btn_SELECCIONAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)(btn_VOLVER_.GetDataInfo()))
                {
                    dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._LISTER_SUCURSAL);
                    estado = false;
                }
                if ((bool)(btn_SELECCIONAR_.GetDataInfo()))
                {
                    dt.STOCKPRO = lister_stock[index];
                    dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._SELECT_PRODUCTO);
                    estado = false;
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    tecla = key_data.InputMode();
                    if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")) || (tecla.Equals("UPARROW")) || (tecla.Equals("DOWNARROW")))
                    {
                        if (contador == 0)
                        {
                            if ((tecla.Equals("UPARROW")) || (tecla.Equals("DOWNARROW")))
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
                            }
                            if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")))
                            {
                                DRAW.CuadradoSolid(color.NEGRO, 28, 27, 11, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 18, 27, 42, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 38, 27, 63, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 18, 27, 104, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 13, 27, 125, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 22, 27, 141, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 22, 27, 167, 20);
                                if (tecla.Equals("RIGHTARROW"))
                                {
                                    inicio += 10;
                                    tope += 10;
                                    if ((tope > lister_stock.Count) && (inicio < lister_stock.Count))
                                    {
                                        tope = lister_stock.Count;
                                    }
                                    else
                                    {
                                        if ((tope > lister_stock.Count) && (inicio > lister_stock.Count))
                                        {
                                            comod = true;
                                            lister_stock.Clear();
                                        }
                                    }
                                }
                                if (tecla.Equals("LEFTARROW"))
                                {
                                    inicio -= 10;
                                    tope -= 10;

                                    if ((inicio < 0) && (tope == 0) && (lister_stock.Count > 10))
                                    {
                                        tope = lister_stock.Count;
                                        inicio = (tope / 10) * 10;
                                    }
                                    else
                                    {
                                        if ((inicio < 0) && (tope < 0) && (lister_stock.Count < 10))
                                        {
                                            comod = true;
                                            lister_stock.Clear();
                                        }
                                        else
                                        {
                                            if (((tope - inicio) < 10) && ((tope % 10) != 0) && ((lister_stock.Count - tope) == 10))
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
                                if ((contador == 1) || (contador == 2))
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
            string[] mensaje = { "   S U C U R S A L    S E L E C C I O N A D A   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._LISTER_SUCURSAL);
        }
        public static void VerifSucursal(ref BDState dt)
        {
            FDStockProduct opus_stock = new FDStockProduct(dt.SUCURSALCREATE.NOMSUCURSAL, dt.SUCURSALCREATE.CODIGO);
            opus_stock.LoadStockProduct();
            int count = opus_stock.CountStockProduct();
            if (count > 0) { dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._LISTER_PRODUCTO); }
            if (count == 0) { dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._MENSAGE01); }
        }
        public static void VolverMenu(ref BDState dt)
        {
            dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._none);
            dt.SetMState(TypeState._LiveDepotLogicGondolaST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveDepotLogicST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._DepotLogicST, DepotLogicST._MENUOPTION);
            dt.SetMState(TypeState._StateMain, StateMain._DEPOTLOGIC);
        }
        public static void SeccionSucursal(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            IOdata.Selector(color.BLANCO, color.AZUL, " Deposito y Logistica - SUCURSALES - Listado de Sucursales ", 59, 74, 8);

            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 5, 60, 20 }, new int[] { 3, 31 }, 20, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 3, 1, 21, 13);
            DRAW.CuadradoSolid(color.DARK_GRIS, 58, 1, 27, 13);
            DRAW.CuadradoSolid(color.DARK_GRIS, 17, 1, 88, 13);
            OUT.PrintLine("N°", color.NEGRO, color.DARK_GRIS, 22, 14);
            OUT.PrintLine("nombre sucursal", color.NEGRO, color.DARK_GRIS, 33, 14);
            OUT.PrintLine("codigo", color.NEGRO, color.DARK_GRIS, 92, 14);

            // cargar la lista de sucursales.
            List<Sucursal> listado = new List<Sucursal>();
            FDSucursal sucursales = new FDSucursal("ListSucursales");
            sucursales.LoadFileSucursales(ref listado);
            listado.RemoveAt(0);
            int inicio = 0, tope = 10, k = 0, position = 0;

            bool estado = true, script = true;
            IN key_data = new IN();
            key_data.SetCondIN(INCond._ARROWS);
            key_data.SetCondIN(INCond._ENTER);
            key_data.SetCondIN(INCond._ESCAPE);

            if (listado.Count < 10) { tope = listado.Count; }
            else { tope = 10; }
            while (estado)
            {
                color back;
                color fore;
                if (script)
                {
                    script = false;
                    for (int i = inicio; i < tope; i++)
                    {
                        if (i == position)
                        {
                            back = color.BLANCO;
                            fore = color.ROJO;
                        }
                        else
                        {
                            back = color.NEGRO;
                            fore = color.DARK_VERDE;
                        }
                        IOdata.Selector(back, fore, (i + 1).ToString(), 3, 21, 17 + (k * 3));
                        IOdata.Selector(back, fore, listado[i].NOMSUCURSAL, 58, 27, 17 + (k * 3));
                        IOdata.Selector(back, fore, listado[i].CODIGO, 17, 88, 17 + (k * 3));
                        k++;
                    }
                    k = 0;
                }
                OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                string tecla = key_data.InputMode();
                if (!(tecla.Equals("")))
                {
                    script = true;
                    if ((!(tecla.Equals("ENTER"))) && (!(tecla.Equals("ESC"))))
                    {
                        if ((tecla.Equals("DOWNARROW")) || (tecla.Equals("UPARROW")))
                        {
                            if (tecla.Equals("DOWNARROW"))
                            {
                                position++;
                                if (position == tope) { position = inicio; }
                            }
                            if (tecla.Equals("UPARROW"))
                            {
                                position--;
                                if (position < inicio) { position = tope - 1; }
                            }
                        }
                        if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")))
                        {
                            if (tecla.Equals("RIGHTARROW"))
                            {
                                inicio += 10;
                                tope += 10;
                                if ((tope > listado.Count) && (inicio < listado.Count))
                                {
                                    tope = listado.Count;
                                }
                                else
                                {
                                    if ((tope > listado.Count) && (inicio > listado.Count))
                                    {
                                        inicio = 0;
                                        if (listado.Count < 10) { tope = listado.Count; }
                                        else { tope = 10; }
                                    }
                                }
                                position = inicio;
                            }
                            if (tecla.Equals("LEFTARROW"))
                            {
                                inicio -= 10;
                                tope -= 10;

                                if (((inicio < 0) && (tope == 0)) && (listado.Count > 10))
                                {
                                    tope = listado.Count;
                                    inicio = (tope / 10) * 10;
                                }
                                else
                                {
                                    if (((inicio < 0) && (tope < 0)) && (listado.Count < 10))
                                    {
                                        inicio = 0;
                                        tope = listado.Count;
                                    }
                                    else
                                    {
                                        if (((tope - inicio) < 10) && ((tope % 10) != 0) && ((listado.Count - tope) == 10))
                                        {
                                            tope = inicio + 10;
                                        }
                                    }
                                }

                                position = inicio;
                            }
                            DRAW.CuadradoSolid(color.NEGRO, 3, 28, 21, 17);
                            DRAW.CuadradoSolid(color.NEGRO, 58, 28, 27, 17);
                            DRAW.CuadradoSolid(color.NEGRO, 17, 28, 88, 17);
                        }
                    }
                    else
                    {
                        if (tecla.Equals("ESC"))
                        {
                            estado = false;
                            dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._VOLVER);
                        }
                        else
                        {
                            if (tecla.Equals("ENTER"))
                            {
                                dt.SUCURSALCREATE = listado[position];
                                dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._VERIF_PRODUCTO);
                                estado = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
