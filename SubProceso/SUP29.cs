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
    public class SUP29
    {
        public static void Mensage02(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   S T O C K   ", "   E L I M I N A D O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._VERIF_STOCK);
        }
        public static void RemoveStock(ref BDState dt)
        {
            FDStockProduct opus_stock = new FDStockProduct("CASA_CENTRAL", "");
            opus_stock.LoadStockProduct();
            int producto = opus_stock.SeekStockProduct(dt.STOCKPRO.CodigoProducto);
            opus_stock.RemoveStockProduct(producto);
            opus_stock.OrdenamientoBurbuja();
            opus_stock.SaveStockProduct();
            dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._MENSAGE02);
        }
        public static void QuestionStock(ref BDState dt)
        {
            string titulo = " CASA CENTRAL - Lista de Stock ";
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            DRAW.CuadradoSolid(color.BLANCO, 34, 1, 80, 10);
            OUT.PrintLine(titulo, color.ROJO, color.BLANCO, 82, 11);
            Console.ResetColor();

            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

            OUT.PrintLine(" Tipo de Producto: ", color.BLANCO, color.NEGRO, 20, 15);
            OUT.PrintLine(" Producto: ", color.BLANCO, color.NEGRO, 28, 17);
            OUT.PrintLine(" tipo de unidad: ", color.BLANCO, color.NEGRO, 22, 19);
            OUT.PrintLine(" Stock en Deposito: ", color.BLANCO, color.NEGRO, 19, 21);

            string hg = String.Concat("(", dt.STOCKPRO.Codigo, ") ", dt.STOCKPRO.TipoProducto);            
            OUT.PrintLine(hg, color.ROJO, color.NEGRO, 40, 15);
            hg = String.Concat(dt.STOCKPRO.Marca," - ", dt.STOCKPRO.NombreProducto, " (", dt.STOCKPRO.CodigoProducto, ")");
            OUT.PrintLine(hg, color.ROJO, color.NEGRO, 40, 17);
            OUT.PrintLine(dt.STOCKPRO.TipoUnidad, color.ROJO, color.NEGRO, 40, 19);
            OUT.PrintLine(dt.STOCKPRO.StockDeposito.ToString(), color.ROJO, color.NEGRO, 40, 21);

            string[] selopcion = { " Eliminar Stock" ,
                                   " Volver a la lista " ,
                                   " Volver al Menu Anterior "};
                       
            IOMENU menuopcion = new IOMENU("¿desea eliminar el Stock seleccionado ?", selopcion, 3, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 20, 25);
            menuopcion.SetDataInfo(7);
            menuopcion.Display(color.NEGRO, color.NEGRO);
            
            int opcion = (int)(menuopcion.GetDataInfo());

            switch (opcion)
            {
                case 2: dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._VOLVER); break;
                case 1: dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._LISTER); break;
                case 0: dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._REMOVE); break;
            }
        }
        public static void ListerStock(ref BDState dt)
        {
            List<StockProduct> lister_stock = new List<StockProduct>();
            List<TypeProduct> lister_typep = new List<TypeProduct>();

            FDStockProduct opus_stock = new FDStockProduct("CASA_CENTRAL","");
            FDTypeProduct opus_typep = new FDTypeProduct("ListTypeProduct");
            dt.STOCKPRO = new StockProduct();
            opus_typep.LoadTypeProductList(ref lister_typep);

            IN key_data = new IN();

            key_data.SetCondIN(INCond._ARROWS);
            key_data.SetCondIN(INCond._ESCAPE);
            key_data.SetCondIN(INCond._ENTER);

            string titulo = " CASA CENTRAL - Lista de Stock ";
            string tecla = "";
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            DRAW.CuadradoSolid(color.BLANCO, 34, 1, 80, 10);
            OUT.PrintLine(titulo, color.ROJO, color.BLANCO, 82, 11);

            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.BLANCO, new int[] { 30 , 20 , 40 , 20 , 15 , 25 }, new int[] { 3 , 30 }, 10, 15);

            DRAW.CuadradoSolid(color.AZUL, 28, 1, 11, 16);
            DRAW.CuadradoSolid(color.AZUL, 18, 1, 42, 16);
            DRAW.CuadradoSolid(color.AZUL, 38, 1, 63, 16);
            DRAW.CuadradoSolid(color.AZUL, 18, 1, 104, 16);
            DRAW.CuadradoSolid(color.AZUL, 13, 1, 125, 16);
            DRAW.CuadradoSolid(color.AZUL, 22, 1, 141, 16);
            OUT.PrintLine("    Grupo de Producto ", color.BLANCO, color.AZUL, 12, 17);
            OUT.PrintLine("   Marca ", color.BLANCO, color.AZUL, 45, 17);
            OUT.PrintLine(" Nombre del Producto ", color.BLANCO, color.AZUL, 73, 17);
            OUT.PrintLine("    Codigo ", color.BLANCO, color.AZUL, 105, 17);
            OUT.PrintLine(" Tipo Unidad ", color.BLANCO, color.AZUL, 126, 17);
            OUT.PrintLine(" STOCK EN DEPOSITO ", color.BLANCO, color.AZUL, 144, 17);

            color back = color.none;
            color fore = color.none;

            bool estado = true, comod = true;
            int i = 0, inicio = 0, tope = 0, k = 0, index = 0;

            while (estado)
            {
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
                    IOdata.Selector(back, fore, lister_stock[j].StockDeposito.ToString(), 22, 141, 20 + (k * 3));
                    k++;
                }
                OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                tecla = key_data.InputMode();
                if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")) || (tecla.Equals("UPARROW")) || (tecla.Equals("DOWNARROW")))
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
                        DRAW.CuadradoSolid(color.NEGRO, 28, 27, 11, 20);
                        DRAW.CuadradoSolid(color.NEGRO, 18, 27, 42, 20);
                        DRAW.CuadradoSolid(color.NEGRO, 38, 27, 63, 20);
                        DRAW.CuadradoSolid(color.NEGRO, 18, 27, 104, 20);
                        DRAW.CuadradoSolid(color.NEGRO, 13, 27, 125, 20);
                        DRAW.CuadradoSolid(color.NEGRO, 22, 27, 141, 20);

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
                } else
                {
                    if (tecla.Equals("ENTER"))
                    {
                        dt.STOCKPRO = lister_stock[index];
                        dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._QUESTION);
                        estado = false;
                    } else
                    {
                        if (tecla.Equals("ESC"))
                        {
                            estado = false;
                            dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._VOLVER);
                        }
                    }                    
                } 
            }
        }
        public static void VolverContaduria(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveContaduriaStockST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._none);
            dt.SetMState(TypeState._LiveContaduriaST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._VERIF_USER);
            dt.SetMState(TypeState._StateMain, StateMain._CONTADURIA);
            dt.STOCKPRO = new StockProduct();
        }
        public static void Mensage01(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O S   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[3];
            mensaje[0] = "   N O    P O S E E   ";
            mensaje[1] = "   S T O C K   E N   L A   ";
            mensaje[2] = "   C A S A   C E N T R A L   ";            
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._VOLVER);
        }
        public static void VerificarStockCentral(ref BDState dt)
        {
            FDStockProduct opus = new FDStockProduct("CASA_CENTRAL", "");
            opus.LoadStockProduct();
            int count = opus.CountStockProduct();
            
            if (count > 0) { dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._LISTER); }
            if (count == 0) { dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._MENSAGE01); }
        }
        
    }
}
