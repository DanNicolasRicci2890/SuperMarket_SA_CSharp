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
    public class SUP24
    {
        public static void MensageP9(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = new string[6];

            mensaje[0] = "   L O S   D A T O S   ";
            mensaje[1] = "   H A N   S I D O   ";
            if ((dt.CONDPRODUCTCREATE == 0) || (dt.CONDPRODUCTCREATE == 1))
            {
                mensaje[2] = "   G U A R D A D O   ";
            }
            if (dt.CONDPRODUCTCREATE == 6)
            {
                mensaje[2] = "   M O D I F I C A D O   ";
            }
            if (dt.CONDPRODUCTCREATE == 8)
            {
                mensaje[2] = "   E L I M I N A D O   ";
            }
            mensaje[3] = "   E N   L A   B A S E   ";
            mensaje[4] = "   D  E   ";
            mensaje[5] = "   D  A  T  O  S   ";           
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.DARK_CYAN, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._VOLVER);
            if (dt.CONDPRODUCTCREATE == 0) { dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT); }
            if (dt.CONDPRODUCTCREATE == 1)
            {
                dt.SetMState(TypeState._LiveProductosAddST, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._ProductosAddST, ProductosAddST._none);
                if (dt.POSITION == 2)
                {
                    dt.SetMState(TypeState._LiveProductosListST, LiveProgram._ACTIVATED);
                    dt.SetMState(TypeState._ProductosListST, ProductosListST._VERIF_LISTER);
                    dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_LISTER);
                } else
                {
                    dt.SetMState(TypeState._LiveProductosSeekST, LiveProgram._ACTIVATED);
                    dt.SetMState(TypeState._ProductosSeekST, ProductosSeekST._SEEK_CODE);
                    dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_SEEK);
                }
            }
        }
        public static void SaveProducto(ref BDState dt)
        {
            // prepara el proceso de archivos y carga de datos
            FDProducto lop = new FDProducto(dt.PRODUCTCREATE.TProduct.ProductName, dt.PRODUCTCREATE.TProduct.Code);

            // ingresa los datos a la lista de productos
            lop.LoadListProduct();

            // ingresar el producto nuevo a la lista.
            if ((dt.CONDPRODUCTCREATE == 0) || (dt.CONDPRODUCTCREATE == 1))
            { 
                lop.AgregarDatos(dt.PRODUCTCREATE); 
            }
            
            // modificar el producto de la lista.
            if (dt.CONDPRODUCTCREATE == 6)
            {
                int index = lop.BuscarProducto(dt.PRODUCTCREATE);
                lop.ModificarProducto(dt.PRODUCTCREATE, index); 
            }

            // eliminar el producto de la lista.
            if (dt.CONDPRODUCTCREATE == 8)
            {
                int index = lop.BuscarProducto(dt.PRODUCTCREATE);
                lop.EliminarProducto(index);
            }

            // ordenar la lista de productos.
            lop.OrdenarListProductos();

            // guardar la lista de productos.
            lop.SaveListProductos();

            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._MENSAGE9);
        }
        public static void VerificarCodigo(ref BDState dt)
        {
            FDProducto kon = new FDProducto("ListTypeProduct");
            int kp = kon.BuscadorCodigo(dt.PRODUCTCREATE.Codigo, dt.PRODUCTCREATE.NombreProducto);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            if (kp > 0)
            {
                string[] mensaje = { "   D A T O S   E R R O N E O S   " };
                FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
                if (kp == 1)
                {
                    mensaje = new string[2];
                    mensaje[0] = "   E L    C O D I G O    I N G R E S A D O   ";
                    mensaje[1] = "   E S    E X I S T E N T E   ";
                }
                if (kp == 2)
                {
                    mensaje = new string[2];
                    mensaje[0] = "   E L    N O M B R E    D E L    P R O D U C T O   ";
                    mensaje[1] = "   I N G R E S A D O   E S    E X I S T E N T E   ";
                }
                if (kp == 3)
                {
                    mensaje = new string[4];
                    mensaje[0] = "   E L    C O D I G O   ";
                    mensaje[1] = "   Y   ";
                    mensaje[2] = "   E L    N O M B R E    D E L    P R O D U C T O   ";
                    mensaje[3] = "   I N G R E S A D O   E S    E X I S T E N T E   ";
                }
                FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
                dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
            } else
            {
                dt.SetMState(TypeState._ProductosAddST, ProductosAddST._SAVE_ADD);
            }
            
        }
        public static void MensageP8(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   E R R O N E O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   I N G R E S A R    L A    P R E C I O   ";
            mensaje[1] = "   D E    V E N T A   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
        }
        public static void MensageP7(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   E R R O N E O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   I N G R E S A R    L A    C A N T I D A D   ";
            mensaje[1] = "   D E    V E N T A   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
        }
        public static void MensageP6(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   E R R O N E O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   I N G R E S A R    U N    T I P O   ";
            mensaje[1] = "   D E    U N I D A D    D E    V E N T A   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
        }
        public static void MensageP5(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   E R R O N E O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   F A L T A   E L    N O M B R E   ";
            mensaje[1] = "   D E L    P R O D U C T O   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
        }
        public static void MensageP4(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   E R R O N E O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   F A L T A   L A    M A R C A   ";
            mensaje[1] = "   D E L    P R O D U C T O   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
        }
        public static void MensageP3(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   E R R O N E O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   F A L T A   E L    C O D I G O   ";
            mensaje[1] = "   D E L    P R O D U C T O   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
        }
        public static void VerificadorDatos(ref BDState dt)
        {
            if (!(dt.PRODUCTCREATE.Codigo.Equals("")))
            {
                if (!(dt.PRODUCTCREATE.Marca.Equals("")))
                {
                    if (!(dt.PRODUCTCREATE.NombreProducto.Equals("")))
                    {
                        if (!(dt.PRODUCTCREATE.TipoCantidad.Equals("")))
                        {
                            if (dt.PRODUCTCREATE.CantVenta != 0)
                            {
                                if (dt.PRODUCTCREATE.Precio != 0)
                                {
                                    if ((dt.CONDPRODUCTCREATE == 0) || (dt.CONDPRODUCTCREATE == 1))
                                    {
                                        dt.SetMState(TypeState._ProductosAddST, ProductosAddST._VERIF_CODIGO);
                                    }
                                    if ((dt.CONDPRODUCTCREATE == 6) || (dt.CONDPRODUCTCREATE == 8))
                                    {
                                        dt.SetMState(TypeState._ProductosAddST, ProductosAddST._SAVE_ADD);
                                    }
                                } else
                                {
                                    // no ingreso el precio.
                                    dt.SetMState(TypeState._ProductosAddST, ProductosAddST._MENSAGE8);
                                }
                            } else
                            {
                                // no ingreso la cantidad por venta
                                dt.SetMState(TypeState._ProductosAddST, ProductosAddST._MENSAGE7);
                            }
                        }
                        else
                        {
                            // no ingreso el tipo de unidad
                            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._MENSAGE6);
                        }
                    }
                    else
                    {
                        // no ingreso el nombre del producto
                        dt.SetMState(TypeState._ProductosAddST, ProductosAddST._MENSAGE5);
                    }
                }
                else
                {
                    // no ingreso la marca del producto
                    dt.SetMState(TypeState._ProductosAddST, ProductosAddST._MENSAGE4);
                }
                
            } else
            {
                // no ingreso el codigo del producto
                dt.SetMState(TypeState._ProductosAddST, ProductosAddST._MENSAGE3);
            }
        }
        public static void MensageP2(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   E R R O N E O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   I N G R E S A R    U N    P R E C I O   ";
            mensaje[1] = "   C O R R E C T O   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
        }
        public static void AgregarProduccion(ref BDState dt)
        {
            string titulo = "", boton = "";
            int fr = 0;
            if ((dt.CONDPRODUCTCREATE == 0) || (dt.CONDPRODUCTCREATE == 1))
            {
                titulo = " Administracion - Ingreso de Productos ";
                boton = "   GUARDAR   ";
                fr = 41;
            }
            if (dt.CONDPRODUCTCREATE == 6)
            {
                titulo = " Administracion - Modificacion de Productos ";
                boton = "   MODIFICAR   ";
                fr = 46;
            }
            if (dt.CONDPRODUCTCREATE == 8)
            {
                titulo = " Administracion - Eliminacion de Productos ";
                boton = "   ELIMINAR   ";
                fr = 46;
            }
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
            int contador = dt.CONDPRODUCTCREATE;
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
            string[] switchMoneda = { "Peso" , "Dolar" };

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
            IOBUTTON btn_ACEPTAR_ = new IOBUTTON(boton, backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 71, 42);            
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

            // Agregar todos los datos de un producto.
            if (dt.CONDPRODUCTCREATE == 0)
            {                
                TipoProducto_.SetDataInfo(1);
                Codigo_.SetDataInfo("");
                Marca_.SetDataInfo("");
                NombreProducto_.SetDataInfo("");
                TipoCant_.SetDataInfo("");
                CantidadVenta_.SetDataInfo(0);
                Moneda_.SetDataInfo(1);
                Precio_.SetDataInfo("");
            }

            // Agregar todos los datos de un producto menos
            // el tipo de producto.
            if (dt.CONDPRODUCTCREATE == 1)
            {
                int pos = 0;
                while ((pos < switchSelect.Length) && (switchSelect[pos] != dt.PRODUCTCREATE.TProduct.ProductName))
                {
                    pos++;
                }
                TipoProducto_.SetDataInfo(Convert.ToInt32(Math.Pow(2, pos)));
                Codigo_.SetDataInfo("");
                Marca_.SetDataInfo("");
                NombreProducto_.SetDataInfo("");
                TipoCant_.SetDataInfo("");
                CantidadVenta_.SetDataInfo(0);
                Moneda_.SetDataInfo(1);
                Precio_.SetDataInfo("");
            }

            // Modificar y Eliminar el producto...solamente el tipo de moneda y el precio
            if ((dt.CONDPRODUCTCREATE == 6) || (dt.CONDPRODUCTCREATE == 8))
            {
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
                switch(dt.PRODUCTCREATE.Moneda)
                {
                    case (TipoMoneda._PESOS): Moneda_.SetDataInfo(1); break;
                    case (TipoMoneda._DOLAR): Moneda_.SetDataInfo(2); break;
                }
                Precio_.SetDataInfo(dt.PRODUCTCREATE.Precio.ToString());
            }

            while(estado)
            {
                TipoProducto_.SetInactivated();
                Codigo_.SetInactivated();
                Marca_.SetInactivated();
                NombreProducto_.SetInactivated();
                TipoCant_.SetInactivated();
                CantidadVenta_.SetInactivated();
                Moneda_.SetInactivated();
                Precio_.SetInactivated();
                btn_ACEPTAR_.SetInactivated();
                btn_ESCAPE_.SetInactivated();

                if (!script)
                {
                    switch(contador)
                    {
                        case 0: TipoProducto_.SetSemiInactivated(); break;
                        case 1: Codigo_.SetSemiInactivated(); break;
                        case 2: Marca_.SetSemiInactivated(); break;
                        case 3: NombreProducto_.SetSemiInactivated(); break;
                        case 4: TipoCant_.SetSemiInactivated(); break;
                        case 5: CantidadVenta_.SetSemiInactivated(); break;
                        case 6: Moneda_.SetSemiInactivated(); break;
                        case 7: Precio_.SetSemiInactivated(); break;
                        case 8: btn_ACEPTAR_.SetSemiInactivated(); break;
                        case 9: btn_ESCAPE_.SetSemiInactivated(); break;
                    }
                }
                if (script)
                {
                    switch (contador)
                    {
                        case 0: TipoProducto_.SetActivated(); break;
                        case 1: Codigo_.SetActivated(); break;
                        case 2: Marca_.SetActivated(); break;
                        case 3: NombreProducto_.SetActivated(); break;
                        case 4: TipoCant_.SetActivated(); break;
                        case 5: CantidadVenta_.SetActivated(); break;
                        case 6: Moneda_.SetActivated(); break;
                        case 7: Precio_.SetActivated(); break;
                        case 8: btn_ACEPTAR_.SetActivated(); break;
                        case 9: btn_ESCAPE_.SetActivated(); break;
                    }
                }
                for(int i = 0; i < 10; i++)
                {
                    if (i != contador)
                    {
                        switch (i)
                        {
                            case 0: TipoProducto_.Display(color.NEGRO, color.NEGRO); break;
                            case 1: Codigo_.Display(color.NEGRO, color.NEGRO); break;
                            case 2: Marca_.Display(color.NEGRO, color.NEGRO); break;
                            case 3: NombreProducto_.Display(color.NEGRO, color.NEGRO); break;
                            case 4: TipoCant_.Display(color.NEGRO, color.NEGRO); break;
                            case 5: CantidadVenta_.Display(color.NEGRO, color.NEGRO); break;
                            case 6: Moneda_.Display(color.NEGRO, color.NEGRO); break;
                            case 7: Precio_.Display(color.NEGRO, color.NEGRO); break;
                            case 8: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                            case 9: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                        }
                    }
                }
                switch (contador)
                {
                    case 0: TipoProducto_.Display(color.NEGRO, color.NEGRO); break;
                    case 1: Codigo_.Display(color.NEGRO, color.NEGRO); break;
                    case 2: Marca_.Display(color.NEGRO, color.NEGRO); break;
                    case 3: NombreProducto_.Display(color.NEGRO, color.NEGRO); break;
                    case 4: TipoCant_.Display(color.NEGRO, color.NEGRO); break;
                    case 5: CantidadVenta_.Display(color.NEGRO, color.NEGRO); break;
                    case 6: Moneda_.Display(color.NEGRO, color.NEGRO); break;
                    case 7: Precio_.Display(color.NEGRO, color.NEGRO); break;
                    case 8: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                    case 9: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                }
                if ((bool)btn_ESCAPE_.GetDataInfo())
                {
                    estado = false;
                    dt.SetMState(TypeState._ProductosAddST, ProductosAddST._VOLVER);
                }
                if ((bool)btn_ACEPTAR_.GetDataInfo())
                {
                    int posicion = FUNCTION.PosicionVector(TipoProducto_.GetDataInfo().ToString());
                    string nom = switchSelect[posicion];
                    string cod = FUNCTION.SeekCodeTipoProduct(nom);
                    dt.PRODUCTCREATE.TProduct.ProductName = nom;
                    dt.PRODUCTCREATE.TProduct.Code = cod;
                    dt.PRODUCTCREATE.Codigo = Codigo_.GetDataInfo().ToString();
                    dt.PRODUCTCREATE.Marca = Marca_.GetDataInfo().ToString();
                    dt.PRODUCTCREATE.NombreProducto = NombreProducto_.GetDataInfo().ToString();
                    dt.PRODUCTCREATE.TipoCantidad = TipoCant_.GetDataInfo().ToString();
                    dt.PRODUCTCREATE.CantVenta = Convert.ToInt32(CantidadVenta_.GetDataInfo().ToString());
                    switch (Convert.ToInt32(Moneda_.GetDataInfo().ToString()))
                    {
                        case 1: dt.PRODUCTCREATE.Moneda = TipoMoneda._PESOS; break;
                        case 2: dt.PRODUCTCREATE.Moneda = TipoMoneda._DOLAR; break;
                    }

                    string ht = Precio_.GetDataInfo().ToString();

                    if (ht.Contains("."))
                    {
                        ht = ht.Replace(".", ",");
                    }

                    if (ht.Length != 0)
                    {
                        try
                        {
                            float valor = Convert.ToSingle(ht);
                            dt.PRODUCTCREATE.Precio = valor;
                            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._VERIF_DATO);
                        }
                        catch (Exception)
                        {
                            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._MENSAGE2);
                        }
                    }
                    estado = false;
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if (tecla.Equals("RIGHTARROW"))
                    {
                        contador++;
                        if (contador == 10) { contador = dt.CONDPRODUCTCREATE; }
                    }
                    else
                    {
                        if (tecla.Equals("LEFTARROW"))
                        {
                            contador--;
                            if (contador < dt.CONDPRODUCTCREATE) { contador = 9; }
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
        public static void VolverTipoProducto(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveProductosAddST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._none);
            if (dt.POSITION == 2)
            {
                dt.SetMState(TypeState._LiveProductosListST, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._ProductosListST, ProductosListST._VERIF_LISTER);
                dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_LISTER);
            } else
            {
                dt.SetMState(TypeState._LiveProductosST, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._ProductosST, ProductosST._MENUOPTION);
                dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ST);
            }
            dt.TIPRODUCTCREATE = new TypeProduct();
            dt.CONDPRODUCTCREATE = -1;            
        }
        public static void MensageP1(ref BDState dt)
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
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._VOLVER);
        }
        public static void VerificarTypeProducts(ref BDState dt)
        {
            FDTypeProduct tipoproducto = new FDTypeProduct("ListTypeProduct");
            tipoproducto.LoadTypeProductList();
            int count = tipoproducto.Count_ListTypeProduct();
            if (count >= 1) { dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT); }
            if (count == 0) { dt.SetMState(TypeState._ProductosAddST, ProductosAddST._MENSAGE1); }
        }
    }
}
