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
    public class SUP21
    {
        public static void RemoveTypeProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._none);
            dt.SetMState(TypeState._LiveProductosListTypeST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosRemoveTypeST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._VIEW_TP);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_REMOVE_TYPE);
            dt.POSITION = 2;
        }
        public static void VisualTypeProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._none);
            dt.SetMState(TypeState._LiveProductosListTypeST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosListST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosListST, ProductosListST._VERIF);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_LISTER);
            dt.POSITION = 2;
        }
        public static void AddTypeProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._none);
            dt.SetMState(TypeState._LiveProductosListTypeST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosAddTypeST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._PRESENT);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ADD_TYPE);
            dt.POSITION = 2;
        }
        public static void VolverTypeProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._none);
            dt.SetMState(TypeState._LiveProductosListTypeST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosST, ProductosST._MENUOPTION);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ST);
            dt.POSITION = -1;
        }
        public static void ListerTypeProduct(ref BDState dt)
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

            string titulo = " Administracion - Lista de Tipos de Productos ";
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
            IOBUTTON btn_VISUAL_ = new IOBUTTON("   VISUALIZAR  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 23);
            IOBUTTON btn_ELIMINAR_ = new IOBUTTON("   ELIMINAR    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 31);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("     VOLVER    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 39);

            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.BLANCO, new int[] { 50, 20 , 25 }, new int[] { 3, 30 }, 10, 15);

            DRAW.CuadradoSolid(color.AZUL, 48, 1, 11, 16);
            DRAW.CuadradoSolid(color.AZUL, 18, 1, 62, 16);
            DRAW.CuadradoSolid(color.AZUL, 22, 1, 83, 16);
            OUT.PrintLine(" Tipo de Producto ", color.BLANCO, color.AZUL, 25, 17);
            OUT.PrintLine("     Codigo ", color.BLANCO, color.AZUL, 63, 17);
            OUT.PrintLine(" Cant/Producto ", color.BLANCO, color.AZUL, 85, 17);


            btn_AGREGAR_.SetInactivated();
            btn_VISUAL_.SetInactivated();
            btn_ELIMINAR_.SetInactivated();
            btn_VOLVER_.SetInactivated();

            btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
            btn_VISUAL_.Display(color.NEGRO, color.NEGRO);
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
                btn_VISUAL_.SetInactivated();
                btn_ELIMINAR_.SetInactivated();
                btn_VOLVER_.SetInactivated();
                btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                btn_VISUAL_.Display(color.NEGRO, color.NEGRO);
                btn_ELIMINAR_.Display(color.NEGRO, color.NEGRO);
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
                    if ((((dt.USERSESION.SystemAdministrador) >> 6) & 1) == 1)
                    {
                        switch (script)
                        {
                            case false: btn_AGREGAR_.SetSemiInactivated(); break;
                            case true: btn_AGREGAR_.SetActivated(); break;
                        }
                        btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                    }
                    else { contador = 2; }
                }
                if (contador == 2)
                {
                    if ((((dt.USERSESION.SystemAdministrador) >> 8) & 1) == 1)
                    {
                        switch (script)
                        {
                            case false: btn_VISUAL_.SetSemiInactivated(); break;
                            case true: btn_VISUAL_.SetActivated(); break;
                        }
                        btn_VISUAL_.Display(color.NEGRO, color.NEGRO);
                    }
                    else { contador = 3; }
                }
                if (contador == 3)
                {
                    if ((((dt.USERSESION.SystemAdministrador) >> 7) & 1) == 1)
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
                    dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._ADD);                 
                    estado = false;
                    script = true;
                }
                if ((bool)btn_VISUAL_.GetDataInfo())
                {
                    dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._VISUAL);
                    dt.PRODUCTCREATE.TProduct = lister[index];
                    dt.POSITION = 2;
                    estado = false;
                    script = true;
                }
                if ((bool)btn_ELIMINAR_.GetDataInfo())
                {
                    dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._REMOVE);
                    dt.PRODUCTCREATE.TProduct = lister[index];
                    dt.POSITION = 2;
                    estado = false;
                    script = true;
                }
                if ((bool)btn_VOLVER_.GetDataInfo())
                {
                    dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._VOLVER);
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
                            if (contador == 5) { contador = 0; }
                        }
                        else
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
            mensaje[1] = "   T I P O   D E   P R O D U C T O S   ";
            mensaje[2] = "   E N   L A   ";
            mensaje[3] = "   B A S E   D E   D A T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._LiveProductosListTypeST, LiveProgram._INACTIVATED);            
            dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._none);            
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._ACTIVATED);            
            dt.SetMState(TypeState._ProductosST, ProductosST._MENUOPTION);            
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ST);
        }
        public static void VerifTypeListProductos(ref BDState dt)
        {
            FDTypeProduct lister = new FDTypeProduct("ListTypeProduct");
            int count = lister.Count_ListTypeProduct();
            if (count > 0) { dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._LISTER); }
            if (count == 0) { dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._MENSAGE1); }
        }
    }
}
