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
    public class SUP26
    {
        public static void RemoveProductos(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveProductosListST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ProductosListST, ProductosListST._none);
            dt.SetMState(TypeState._LiveProductosAddST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ADD);
            dt.CONDPRODUCTCREATE = 8;
            dt.POSITION = 2;
        }
        public static void ModifProductos(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveProductosListST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ProductosListST, ProductosListST._none);
            dt.SetMState(TypeState._LiveProductosAddST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ADD);
            dt.CONDPRODUCTCREATE = 6;
            dt.POSITION = 2;
        }
        public static void AddProductos(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveProductosListST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ProductosListST, ProductosListST._none);
            dt.SetMState(TypeState._LiveProductosAddST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ADD);
            dt.CONDPRODUCTCREATE = 1;
            dt.POSITION = 2;
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

            string titulo = " Administracion - Lista de Productos de " + dt.PRODUCTCREATE.TProduct.ProductName + " (" + dt.PRODUCTCREATE.TProduct.Code + ")";
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
            
            IOBUTTON btn_AGREGAR_ = new IOBUTTON("    AGREGAR    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 15);
            IOBUTTON btn_MODIFICAR_ = new IOBUTTON("   MODIFICAR   ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 23);
            IOBUTTON btn_ELIMINAR_ = new IOBUTTON("   ELIMINAR    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 31);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("     VOLVER    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 39);

            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.BLANCO, new int[] { 20 , 50 , 20 , 20 , 30 }, new int[] { 3 , 31 }, 10, 15);
            
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
            btn_MODIFICAR_.SetInactivated();
            btn_ELIMINAR_.SetInactivated();
            btn_VOLVER_.SetInactivated();

            btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
            btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
            btn_ELIMINAR_.Display(color.NEGRO, color.NEGRO);
            btn_VOLVER_.Display(color.NEGRO, color.NEGRO);

            inicio = 0;
            if (lister.Count < 10) { tope = lister.Count; }
            else { tope = 10; }
            color back = color.none;
            color fore = color.none;
            while (estado)
            {
                btn_AGREGAR_.SetInactivated();
                btn_MODIFICAR_.SetInactivated();
                btn_ELIMINAR_.SetInactivated();
                btn_VOLVER_.SetInactivated();
                btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
                btn_ELIMINAR_.Display(color.NEGRO, color.NEGRO);
                btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                if (contador == 0)
                {
                    for(int i = inicio; i < tope; i++)
                    {
                        if (i == index)
                        {
                            back = color.BLANCO;
                            fore = color.MAGENTA;
                        } else
                        {
                            back = color.NEGRO;
                            fore = color.GRIS;
                        }
                        
                        IOdata.Selector(back, fore, lister[i].Marca, 18, 11, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister[i].NombreProducto, 48, 32, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister[i].Codigo, 18, 83, 20 + (k * 3));
                        IOdata.Selector(back, fore, lister[i].TipoCantidad, 18, 104, 20 + (k * 3));

                        string ht = "";
                        switch(lister[i].Moneda)
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
                    if ((((dt.USERSESION.SystemAdministrador) >> 9) & 1) == 1)
                    {
                        switch(script)
                        {
                            case false: btn_AGREGAR_.SetSemiInactivated(); break;
                            case true: btn_AGREGAR_.SetActivated(); break;
                        }
                        btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                    } else { contador = 2; }                 
                }
                if (contador == 2)
                {
                    if ((((dt.USERSESION.SystemAdministrador) >> 10) & 1) == 1)
                    {
                        switch (script)
                        {
                            case false: btn_MODIFICAR_.SetSemiInactivated(); break;
                            case true: btn_MODIFICAR_.SetActivated(); break;
                        }
                        btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
                    }
                    else { contador = 3; }
                }
                if (contador == 3)
                {
                    if ((((dt.USERSESION.SystemAdministrador) >> 11) & 1) == 1)
                    {
                        switch (script)
                        {
                            case false: btn_ELIMINAR_.SetSemiInactivated(); break;
                            case true: btn_ELIMINAR_.SetActivated(); break;
                        }
                        btn_ELIMINAR_.Display(color.NEGRO, color.NEGRO);
                    }
                    else { contador = 4; }
                }
                if (contador == 4)
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
                    dt.SetMState(TypeState._ProductosListST, ProductosListST._ADD_PRODUCT);                    
                    estado = false;
                    script = true;
                }
                if ((bool)btn_MODIFICAR_.GetDataInfo())
                {
                    dt.SetMState(TypeState._ProductosListST, ProductosListST._MODIF_PRODUCT);
                    dt.PRODUCTCREATE = lister[index];
                    estado = false;
                    script = true;
                }
                if ((bool)btn_ELIMINAR_.GetDataInfo())
                {
                    dt.SetMState(TypeState._ProductosListST, ProductosListST._REMOVE_PRODUCT);
                    dt.PRODUCTCREATE = lister[index];
                    estado = false;
                    script = true;
                }
                if ((bool)btn_VOLVER_.GetDataInfo())
                {
                    if (dt.POSITION == 1)
                    {
                        dt.SetMState(TypeState._ProductosListST, ProductosListST._SEEK_LISTER);
                    }
                    if (dt.POSITION == 2)
                    {
                        dt.SetMState(TypeState._LiveProductosListST, LiveProgram._INACTIVATED);
                        dt.SetMState(TypeState._ProductosListST, ProductosListST._none);
                        dt.SetMState(TypeState._LiveProductosListTypeST, LiveProgram._ACTIVATED);
                        dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._VERIF);
                        dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_LISTER_TYPE);
                        dt.PRODUCTCREATE = new Producto();
                        dt.POSITION = -1;
                    }
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
                                DRAW.CuadradoSolid(color.NEGRO, 18, 28, 11, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 48, 28, 32, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 18, 28, 83, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 18, 28, 104, 20);
                                DRAW.CuadradoSolid(color.NEGRO, 27, 28, 125, 20);
                                if (tecla.Equals("RIGHTARROW"))
                                {
                                    inicio += 10;
                                    tope += 10;
                                    if ((tope > lister.Count) && (inicio < lister.Count))
                                    {
                                        tope = lister.Count;
                                    } else
                                    {
                                        if ((tope >= lister.Count) && (inicio >= lister.Count))
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
                                    } else
                                    {
                                        if ((inicio < 0) && (tope < 0) && (lister.Count < 10))
                                        {
                                            inicio = 0;
                                            tope = lister.Count;
                                        } else
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
                    } else
                    {
                        if (tecla.Equals("TAB"))
                        {
                            contador++;
                            if (contador == 5) { contador = 0; }
                        } else
                        {
                            if (tecla.Equals("ENTER"))
                            {
                                if ((contador >= 1) && (contador <= 4))
                                {
                                    script = true;
                                }
                            }
                        }
                    }
                } else { script = false; }                
            } 
        }
        public static void Mensage02(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O S   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[5];
            mensaje[0] = "   N O    P O S E E   ";            
            mensaje[1] = "   P R O D U C T O S   D E   ";
            mensaje[2] = FUNCTION.SeparadorEspacio(dt.PRODUCTCREATE.TProduct.ProductName);
            mensaje[3] = "   E N   L A   ";
            mensaje[4] = "   B A S E   D E   D A T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosListST, ProductosListST._VOLVER);
        }
        public static void VerifTypeListProduct(ref BDState dt)
        {
            FDProducto op = new FDProducto(dt.PRODUCTCREATE.TProduct.ProductName, dt.PRODUCTCREATE.TProduct.Code);
            int cont = op.CountListProducto();
            if (cont > 0) { dt.SetMState(TypeState._ProductosListST, ProductosListST._LISTER_PRODUCT); }
            if (cont == 0) { dt.SetMState(TypeState._ProductosListST, ProductosListST._MENSAGE2); }
        }
        public static void Volver(ref BDState dt)
        {

            dt.SetMState(TypeState._LiveProductosListST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ProductosListST, ProductosListST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosST, ProductosST._MENUOPTION);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ST);
            dt.CONDPRODUCTCREATE = -1;
            dt.PRODUCTCREATE = new Producto();
        }
        public static void ListerTypeProduct(ref BDState dt)
        {
            string titulo = " Administracion - Lista de Productos ";
            int fr = 41;
            
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
            
            IN key_data = new IN();
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backSelect = { color.DARK_GRIS, color.AMARILLO, color.DARK_GRIS, color.BLANCO };
            color[] foreSelect = { color.NEGRO, color.AZUL, color.NEGRO, color.VERDE };
            
            string[] switchSelect = FUNCTION.ListTipoProducto();
            
            key_data.SetCondIN(INCond._SPACEBAR);
            key_data.SetCondIN(INCond._ESCAPE);
            key_data.SetCondIN(INCond._ENTER);

            IOSWICHT TipoProducto_ = new IOSWICHT(" tipo de Producto ", switchSelect, backcorral, forecorral, backtitulo, foretitulo, backSelect, foreSelect, TypeLine._DOUBLE, TypePost._LEFT, 20, 16);
            TipoProducto_.SetDataInfo(1);

            while (estado)
            {
                if (!(script))
                {
                    TipoProducto_.SetSemiInactivated();
                    TipoProducto_.Display(color.NEGRO, color.NEGRO);
                }
                if (script)
                {
                    TipoProducto_.SetActivated();
                    TipoProducto_.Display(color.NEGRO, color.NEGRO);
                }
                if (!(script))
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();

                    if (tecla.Equals("ENTER"))
                    {
                        script = true;
                    }
                    else
                    {
                        if (tecla.Equals("ESC"))
                        {
                            dt.SetMState(TypeState._ProductosListST, ProductosListST._VOLVER);
                            estado = false;
                        } else
                        {
                            if (tecla.Equals("SPACEBAR"))
                            {
                                int posicion = FUNCTION.PosicionVector(TipoProducto_.GetDataInfo().ToString());
                                string nom = switchSelect[posicion];
                                string cod = FUNCTION.SeekCodeTipoProduct(nom);
                                dt.PRODUCTCREATE.TProduct.ProductName = nom;
                                dt.PRODUCTCREATE.TProduct.Code = cod;
                                dt.POSITION = 1;
                                dt.SetMState(TypeState._ProductosListST, ProductosListST._VERIF_LISTER);
                                estado = false;
                            }
                        }                   
                    }
                } else { script = false; }
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
            mensaje[1] = "   T I P O   D E   P R O D U C T O S   ";
            mensaje[2] = "   E N   L A   ";
            mensaje[3] = "   B A S E   D E   D A T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosListST, ProductosListST._VOLVER);
        }
        public static void Verificador(ref BDState dt)
        {      
            FDTypeProduct op = new FDTypeProduct("ListTypeProduct");
            int cont = op.Count_ListTypeProduct();
            if (cont > 0) 
            { 
                if (dt.POSITION == 2)
                {
                    dt.SetMState(TypeState._ProductosListST, ProductosListST._VERIF_LISTER);
                } else { dt.SetMState(TypeState._ProductosListST, ProductosListST._SEEK_LISTER); }                 
            }
            if (cont == 0) { dt.SetMState(TypeState._ProductosListST, ProductosListST._MENSAGE1); }
        }
    }
}

