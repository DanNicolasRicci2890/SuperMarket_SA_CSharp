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
    public class SUP35
    {
        public static void Mensage14(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   C O M P R A    R E A L I Z A D A    " };
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.CYAN, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO);
        }
        public static void ProcesoPago(ref BDState dt)
        {
            // restar productos de la gondola de la sucursal
            FDStockProduct opus_sucursal = new FDStockProduct(dt.SUCURSALCREATE.NOMSUCURSAL, dt.SUCURSALCREATE.CODIGO);
            opus_sucursal.LoadStockProduct();

            for(int i = 0; i < dt.COMPRACAJA.Count; i++)
            {
                BoxProduct producto = dt.COMPRACAJA[i];
                int index = opus_sucursal.SeekStockProduct(producto.GetCodigoPro());
                StockProduct sp = opus_sucursal.GetStockProducto(index);
                sp.StockGondola -= producto.CANTIDAD;
                opus_sucursal.RemoveStockProduct(index);
                opus_sucursal.AddStockProduct(sp, CondStock._INCREMENTO);
            }            
            opus_sucursal.OrdenamientoBurbuja();
            opus_sucursal.SaveStockProduct();

            // implementar la ganancia al archivo de ganancia.
            FDGanancia opus_gain = new FDGanancia("Ganancias");
            opus_gain.LoadListGain();
            SucursalGain p = new SucursalGain();
            p.NombreSucursal = dt.SUCURSALCREATE.NOMSUCURSAL;
            p.Codigo = dt.SUCURSALCREATE.CODIGO;
            switch(dt.CONDICION_PAGO)
            {
                case Moneda._DOLARES: p.MDolar = dt.COMPRADOLARES + (dt.COMPRAPESOS / dt.DOLARPESOS); break;
                case Moneda._PESOS: p.MPesos = dt.COMPRAPESOS + (dt.COMPRADOLARES * dt.DOLARPESOS); break;
            }
            opus_gain.AddSucursalGain(p);
            opus_gain.BurbujaOrdenamiento();
            opus_gain.SaveListGanancias();

            // limpiar la lista realizada y otros datos
            dt.COMPRACAJA = new List<BoxProduct>();
            dt.COMPRADOLARES = 0;
            dt.COMPRAPESOS = 0;
            dt.CONDICION_PAGO = Moneda._none;

            // volver a la caja de venta para futura compra.
            dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE14);
        }
        public static void Mensage13(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   I M P O R T E   I N G R E S A D O   ", "   E R R O N E O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            Console.Clear();
            mensaje = new string[4];
            mensaje[0] = "   E L    I M P O R T E   ";
            mensaje[1] = "   I N G R E S A D O   ";
            mensaje[2] = "   N O    S U P E R A   ";
            mensaje[3] = "   A L    P A G O    T O T A L   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._ABONAR);
        }
        public static void Mensage12(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   N O   I N G R E S O    ", "   U N    I M P O R T E   ", "   C O R R E C T O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._ABONAR);
        }
        public static void AbonarImporte(ref BDState dt)
        {
            float suma = 0;
            int nivel = 0;
            bool estado = true, script = false;

            IN key_data = new IN();
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);

            string titulo = String.Concat("  Sector CAJERO / Abonar Importe => ", dt.SUCURSALCREATE.NOMSUCURSAL, "_", dt.SUCURSALCREATE.CODIGO, "  ");
            IOdata.Selector(color.BLANCO, color.AZUL, titulo, titulo.Length, (((dt.WIDTH - 10) - titulo.Length) / 2), 8);

            color[] backtitulo2 = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };

            IOdata.Selector(color.GRIS, color.NEGRO, "   TOTAL - DOLAR ", 16, 40, 15);
            IOdata.Selector(color.DARK_AMARILLO, color.AZUL, "", 25, 58, 15);
            suma = dt.COMPRADOLARES + (dt.COMPRAPESOS / dt.DOLARPESOS);
            OUT.PrintLine("u$s " + suma.ToString(), color.AZUL, color.DARK_AMARILLO, 60, 16);

            IOdata.Selector(color.GRIS, color.NEGRO, "   TOTAL - PESOS ", 16, 40, 20);
            IOdata.Selector(color.DARK_AMARILLO, color.AZUL, "", 25, 58, 20);
            suma = dt.COMPRAPESOS + (dt.COMPRADOLARES * dt.DOLARPESOS);
            OUT.PrintLine("  $ " + suma.ToString(), color.AZUL, color.DARK_AMARILLO, 60, 21);

            IODATAINFO Importe_ = new IODATAINFO(" Ingrese el Importe  ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._UP_CENTER, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 140, 15);
            IOBUTTON btn_AbPesos_ = new IOBUTTON("   ABONAR EN PESOS   ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 100, 14);
            IOBUTTON btn_AbDolar_ = new IOBUTTON("  ABONAR EN DOLARES  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 100, 20);
            IOBUTTON btn_AVolver_ = new IOBUTTON("        VOLVER       ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 100, 26);

            btn_AbPesos_.SetDataInfo(false);
            btn_AbDolar_.SetDataInfo(false);
            btn_AVolver_.SetDataInfo(false);
            Importe_.SetDataInfo("");
            Importe_.SetTypeDataIN(TypeDataIN._NUMERIC_PAD);
            Importe_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Importe_.SetTypeDataIN(TypeDataIN._CARACTER_SPECIAL);

            while (estado)
            {
                if (nivel == 0)
                {
                    btn_AbDolar_.SetInactivated();
                    btn_AVolver_.SetInactivated();
                    switch(script)
                    {
                        case false: btn_AbPesos_.SetSemiInactivated(); break;
                        case true: btn_AbPesos_.SetActivated(); break;
                    }
                    btn_AbDolar_.Display(color.NEGRO, color.NEGRO);
                    btn_AVolver_.Display(color.NEGRO, color.NEGRO);
                    btn_AbPesos_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 1)
                {
                    btn_AbPesos_.SetInactivated();
                    btn_AVolver_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_AbDolar_.SetSemiInactivated(); break;
                        case true: btn_AbDolar_.SetActivated(); break;
                    }                    
                    btn_AVolver_.Display(color.NEGRO, color.NEGRO);
                    btn_AbPesos_.Display(color.NEGRO, color.NEGRO);
                    btn_AbDolar_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 2)
                {
                    btn_AbPesos_.SetInactivated();
                    btn_AbDolar_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_AVolver_.SetSemiInactivated(); break;
                        case true: btn_AVolver_.SetActivated(); break;
                    }
                    btn_AbPesos_.Display(color.NEGRO, color.NEGRO);
                    btn_AbDolar_.Display(color.NEGRO, color.NEGRO);
                    btn_AVolver_.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)(btn_AbPesos_.GetDataInfo()))
                {
                    dt.CONDICION_PAGO = Moneda._PESOS;
                    FUNCTION.ProcesodePago(ref dt, ref Importe_);
                    estado = false;
                }
                if ((bool)(btn_AbDolar_.GetDataInfo()))
                {
                    dt.CONDICION_PAGO = Moneda._DOLARES;
                    FUNCTION.ProcesodePago(ref dt, ref Importe_);
                    estado = false;
                }
                if ((bool)(btn_AVolver_.GetDataInfo()))
                {
                    script = true;
                    estado = false;
                    dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO_FINALY);
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();

                    if (tecla.Equals("TAB"))
                    {
                        nivel++;
                        if (nivel == 3) { nivel = 0; }
                    } else { if (tecla.Equals("ENTER")) { script = true; } }
                } else { script = true; }
            }
        }
        public static void Mensage11(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   N O   P O S E E    ", "   L I S T A D O   ", "   D E   C O M P R A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO);
        }
        public static void CajeroFinally(ref BDState dt)
        {
            string tecla = "";
            bool estado = true, script = false;
            int nivel = 0, i = 0, inicio = 0, tope = 0, k = 0;
            IN keydata = new IN();
            keydata.SetCondIN(INCond._ARROWS);
            keydata.SetCondIN(INCond._TAB);
            keydata.SetCondIN(INCond._ENTER);

            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);

            string titulo = String.Concat("  Sector CAJERO / Finalizar Compras => ", dt.SUCURSALCREATE.NOMSUCURSAL, "_", dt.SUCURSALCREATE.CODIGO, "  ");
            IOdata.Selector(color.BLANCO, color.AZUL, titulo, titulo.Length, (((dt.WIDTH - 10) - titulo.Length) / 2), 8);

            color[] backtitulo2 = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };

            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 5, 25, 25, 40, 25, 20, 20 }, new int[] { 3, 34 }, 10, 11);
            DRAW.CuadradoSolid(color.DARK_GRIS, 3, 1, 11, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 23, 1, 17, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 23, 1, 43, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 38, 1, 69, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 23, 1, 110, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 18, 1, 136, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 17, 1, 157, 12);

            OUT.PrintLine("N°", color.BLANCO, color.DARK_GRIS, 12, 13);
            OUT.PrintLine("Tipo Producto", color.BLANCO, color.DARK_GRIS, 22, 13);
            OUT.PrintLine("Marca", color.BLANCO, color.DARK_GRIS, 52, 13);
            OUT.PrintLine("Producto", color.BLANCO, color.DARK_GRIS, 83, 13);
            OUT.PrintLine("Costo/unidad", color.BLANCO, color.DARK_GRIS, 116, 13);
            OUT.PrintLine("Cantidad", color.BLANCO, color.DARK_GRIS, 142, 13);
            OUT.PrintLine("SubPrecio", color.BLANCO, color.DARK_GRIS, 162, 13);

            IOdata.Selector(color.GRIS, color.NEGRO, "   TOTAL - DOLAR ", 16, 180, 40);
            IOdata.Selector(color.DARK_AMARILLO, color.AZUL, "", 25, 198, 40);

            IOdata.Selector(color.GRIS, color.NEGRO, "   TOTAL - PESOS ", 16, 180, 44);
            IOdata.Selector(color.DARK_AMARILLO, color.AZUL, "", 25, 198, 44);

            IOBUTTON btn_FINALY_ = new IOBUTTON("   ABONAR IMPORTE   ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 191, 15);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("       VOLVER       ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 191, 23);

            keydata.SetCondIN(INCond._ARROWS);
            keydata.SetCondIN(INCond._TAB);
            keydata.SetCondIN(INCond._ENTER);

            List<BoxProduct> CompraProduct = dt.COMPRACAJA;

            btn_FINALY_.SetDataInfo(false);
            btn_VOLVER_.SetDataInfo(false);

            
            if (CompraProduct.Count > 0) 
            {
                // Suprimir items de la lista de compra.
                FUNCTION.Ordenamiento(ref CompraProduct);
                FUNCTION.CorteDeControl(ref CompraProduct);

                if (CompraProduct.Count > 10) { tope = 10; }
                else { tope = CompraProduct.Count; }
                inicio = 0;

                while (estado)
                {
                    if (nivel == 0)
                    {
                        btn_FINALY_.SetInactivated();
                        btn_VOLVER_.SetInactivated();

                        btn_FINALY_.Display(color.NEGRO, color.NEGRO);
                        btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                        float suma = dt.COMPRADOLARES + (dt.COMPRAPESOS / dt.DOLARPESOS);
                        OUT.PrintLine("u$s " + suma.ToString(), color.AZUL, color.DARK_AMARILLO, 200, 41);

                        suma = dt.COMPRAPESOS + (dt.COMPRADOLARES * dt.DOLARPESOS); 
                        OUT.PrintLine("  $ " + suma.ToString(), color.AZUL, color.DARK_AMARILLO, 200, 45);


                        k = 0;
                        for (i = inicio; i < tope; i++)
                        {
                            FUNCTION.MostrarComprar(CompraProduct[i], color.NEGRO, color.DARK_CYAN, i + 1, k);
                            k++;
                        }
                    }
                    if (nivel == 1)
                    {
                        btn_VOLVER_.SetInactivated();
                        switch(script)
                        {
                            case false: btn_FINALY_.SetSemiInactivated(); break;
                            case true: btn_FINALY_.SetActivated(); break;
                        }
                        btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                        btn_FINALY_.Display(color.NEGRO, color.NEGRO);                        
                    }
                    if (nivel == 2)
                    {
                        btn_FINALY_.SetInactivated();
                        switch (script)
                        {
                            case false: btn_VOLVER_.SetSemiInactivated(); break;
                            case true: btn_VOLVER_.SetActivated(); break;
                        }
                        btn_FINALY_.Display(color.NEGRO, color.NEGRO);
                        btn_VOLVER_.Display(color.NEGRO, color.NEGRO);                        
                    }
                    if ((bool)(btn_VOLVER_.GetDataInfo()))
                    {
                        script = true;
                        estado = false;
                        dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO);
                    }
                    if ((bool)(btn_FINALY_.GetDataInfo()))
                    {
                        script = true;
                        estado = false;
                        dt.SetMState(TypeState._CajeroST, CajeroST._ABONAR);
                    }
                    if (!script)
                    {
                        OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                        tecla = keydata.InputMode();
                        if (((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW"))) && (nivel == 0))
                        {
                            FUNCTION.TableClear();
                            if (tecla.Equals("RIGHTARROW"))
                            {
                                inicio += 10;
                                tope += 10;
                                if ((tope > CompraProduct.Count) && (inicio < CompraProduct.Count))
                                {
                                    tope = CompraProduct.Count;
                                }
                                else
                                {
                                    if ((tope > CompraProduct.Count) && (inicio > CompraProduct.Count))
                                    {
                                        inicio = 0;
                                        if (CompraProduct.Count > 10) { tope = 10; }
                                        else { tope = CompraProduct.Count; }
                                    }
                                }
                            }
                            if (tecla.Equals("LEFTARROW"))
                            {
                                inicio -= 10;
                                tope -= 10;
                                if ((inicio < 0) && (tope == 0) && (CompraProduct.Count > 10))
                                {
                                    tope = CompraProduct.Count;
                                    inicio = (tope / 10) * 10;
                                }
                                else
                                {
                                    if ((inicio < 0) && (tope < 0) && (CompraProduct.Count < 10))
                                    {
                                        inicio = 0;
                                        tope = CompraProduct.Count;
                                    }
                                    else
                                    {
                                        if (((tope - inicio) < 10) && ((tope % 10) != 0) && ((CompraProduct.Count - tope) == 10))
                                        {
                                            tope = inicio + 10;
                                        }
                                    }
                                }
                            }
                        } else
                        {
                            if (tecla.Equals("TAB"))
                            {
                                nivel++;
                                if (nivel == 3) { nivel = 0; }
                            } else
                            {
                                if (tecla.Equals("ENTER"))
                                {
                                    script = true;
                                }
                            }
                        }
                    } else { script = false; }
                }
            }
            else { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE11); }            
        }
        public static void CajeroVerQuitar(ref BDState dt)
        {
            string tecla = "";
            bool estado = true, script = false;
            int nivel = 0, i = 0, inicio = 0, tope = 0, k = 0, index = 0;
            IN keydata = new IN();
            keydata.SetCondIN(INCond._ARROWS);
            keydata.SetCondIN(INCond._TAB);
            keydata.SetCondIN(INCond._ENTER);

            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);

            string titulo = String.Concat("  Sector CAJERO / Quitar Compras => ", dt.SUCURSALCREATE.NOMSUCURSAL, "_", dt.SUCURSALCREATE.CODIGO, "  ");
            IOdata.Selector(color.BLANCO, color.AZUL, titulo, titulo.Length, (((dt.WIDTH - 10) - titulo.Length) / 2), 8);

            color[] backtitulo2 = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };

            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 5, 25, 25, 40, 25, 20, 20 }, new int[] { 3, 34 }, 10, 11);
            DRAW.CuadradoSolid(color.DARK_GRIS, 3, 1, 11, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 23, 1, 17, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 23, 1, 43, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 38, 1, 69, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 23, 1, 110, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 18, 1, 136, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 17, 1, 157, 12);

            OUT.PrintLine("N°", color.BLANCO, color.DARK_GRIS, 12, 13);
            OUT.PrintLine("Tipo Producto", color.BLANCO, color.DARK_GRIS, 22, 13);
            OUT.PrintLine("Marca", color.BLANCO, color.DARK_GRIS, 52, 13);
            OUT.PrintLine("Producto", color.BLANCO, color.DARK_GRIS, 83, 13);
            OUT.PrintLine("Costo/unidad", color.BLANCO, color.DARK_GRIS, 116, 13);
            OUT.PrintLine("Cantidad", color.BLANCO, color.DARK_GRIS, 142, 13);
            OUT.PrintLine("SubPrecio", color.BLANCO, color.DARK_GRIS, 162, 13);

            IOdata.Selector(color.GRIS, color.NEGRO, "   TOTAL - DOLAR ", 16, 180, 40);
            IOdata.Selector(color.DARK_AMARILLO, color.AZUL, "", 25, 198, 40);

            IOdata.Selector(color.GRIS, color.NEGRO, "   TOTAL - PESOS ", 16, 180, 44);
            IOdata.Selector(color.DARK_AMARILLO, color.AZUL, "", 25, 198, 44);

            IOBUTTON btn_QUITAR_ = new IOBUTTON("    QUITAR    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 191, 15);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("    VOLVER    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 191, 23);

            keydata.SetCondIN(INCond._ARROWS);
            keydata.SetCondIN(INCond._TAB);
            keydata.SetCondIN(INCond._ENTER);

            List<BoxProduct> CompraProduct = dt.COMPRACAJA;
            
            btn_QUITAR_.SetDataInfo(false);
            btn_VOLVER_.SetDataInfo(false);
            if (CompraProduct.Count > 10) { tope = 10; }
            else { tope = CompraProduct.Count; }
            inicio = 0;
            index = 0;
            while (estado)
            {
                if (nivel == 0)
                {
                    btn_QUITAR_.SetInactivated();
                    btn_VOLVER_.SetInactivated();

                    btn_QUITAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    float suma = dt.COMPRAPESOS + (dt.COMPRADOLARES * dt.DOLARPESOS);
                    OUT.PrintLine("  $ " + suma.ToString(), color.AZUL, color.DARK_AMARILLO, 200, 41);

                    suma = dt.COMPRADOLARES + (dt.COMPRAPESOS / dt.DOLARPESOS);
                    OUT.PrintLine("u$s " + suma.ToString(), color.AZUL, color.DARK_AMARILLO, 200, 45);
                    
                    
                    k = 0;
                    for (i = inicio; i < tope; i++)
                    {
                        color back = color.none;
                        color fore = color.none;
                        if (i == index)
                        {
                            back = color.BLANCO;
                            fore = color.ROJO;
                        } else
                        {
                            back = color.NEGRO;
                            fore = color.DARK_CYAN;
                        }

                        FUNCTION.MostrarComprar(CompraProduct[i], back, fore, i + 1, k);
                        k++;
                    }                    
                }
                if (nivel == 1)
                {
                    btn_VOLVER_.SetInactivated();
                    switch(script)
                    {
                        case (false): btn_QUITAR_.SetSemiInactivated(); break;
                        case (true): btn_QUITAR_.SetActivated(); break;
                    }
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_QUITAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 2)
                {
                    btn_QUITAR_.SetInactivated();
                    switch (script)
                    {
                        case (false): btn_VOLVER_.SetSemiInactivated(); break;
                        case (true): btn_VOLVER_.SetActivated(); break;
                    }                    
                    btn_QUITAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)(btn_QUITAR_.GetDataInfo()))
                {
                    BoxProduct pro = CompraProduct[index];
                    string kp = (pro.GetSubPrecioStr()).Substring(0, 3);
                    switch (kp)
                    {
                        case ("  $"): dt.COMPRAPESOS -= pro.GetSubPrecio(); break;
                        case ("u$s"): dt.COMPRADOLARES -= pro.GetSubPrecio(); break;
                    }
                    CompraProduct.RemoveAt(index);
                    nivel = 0;  
                    index = 0;
                    FUNCTION.TableClear();
                    btn_QUITAR_.SetDataInfo(false);
                }
                if ((bool)(btn_VOLVER_.GetDataInfo()))
                {
                    estado = false;
                    dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO);
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    tecla = keydata.InputMode();
                    if (((tecla.Equals("DOWNARROW")) || (tecla.Equals("UPARROW")) || (tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW"))) && (nivel == 0))
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
                                if (index == -1) { index = tope - 1; }
                            }
                        }
                        if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")))
                        {
                            FUNCTION.TableClear();
                            if (tecla.Equals("RIGHTARROW")) 
                            {
                                inicio += 10;
                                tope += 10;
                                if ((tope > CompraProduct.Count) && (inicio < CompraProduct.Count))
                                {
                                    tope = CompraProduct.Count;
                                }
                                else
                                {
                                    if ((tope >= CompraProduct.Count) && (inicio >= CompraProduct.Count))
                                    {
                                        inicio = 0;
                                        if (CompraProduct.Count > 10) { tope = 10; }
                                        else { tope = CompraProduct.Count; }
                                    }
                                }
                            }
                            if (tecla.Equals("LEFTARROW")) 
                            {
                                inicio -= 10;
                                tope -= 10;
                                if ((inicio < 0) && (tope == 0) && (CompraProduct.Count > 10))
                                {
                                    tope = CompraProduct.Count;
                                    inicio = (tope / 10) * 10;
                                    if ((tope - inicio) == 0)
                                    {
                                        inicio = tope - 10;
                                    }
                                }
                                else
                                {
                                    if ((inicio < 0) && (tope < 0) && (CompraProduct.Count < 10))
                                    {
                                        inicio = 0;
                                        tope = CompraProduct.Count;
                                    }
                                    else
                                    {
                                        if (((tope - inicio) < 10) && ((tope % 10) != 0) && ((CompraProduct.Count - tope) == 10))
                                        {
                                            tope = inicio + 10;
                                        }                                            
                                    }
                                }
                            }
                            index = inicio;
                        }
                    }
                    else
                    {
                        if (tecla.Equals("TAB"))
                        {
                            nivel++;
                            if (nivel == 3) { nivel = 0; }
                        } else
                        {
                            if (tecla.Equals("ENTER"))
                            {
                                if ((nivel == 1) || (nivel == 2)) { script = true; }                                
                            }
                        }
                    } 
                }
                else { script = false; }
            }
        }
        public static void Mensage10(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   I N G R E S O    ", "   U N    V A L O R   ", "   I N C O R R E C T O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   N O   S E   P E R M I T E   ";
            mensaje[1] = "   E L   V A L O R   N U L O   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO);
        }
        public static void Mensage09(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   I N G R E S O    ", "   U N    V A L O R   ", "   I N C O R R E C T O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[3];
            mensaje[0] = "   I N G R E S E   ";
            mensaje[1] = "   U N   V A L O R   ";
            mensaje[2] = "   N U M E R I C O   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO);
        }
        public static void Mensage08(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   I N G R E S O    ", "   U N    V A L O R   ", "   I N C O R R E C T O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[5];
            mensaje[0] = "   I N G R E S E   ";
            mensaje[1] = "   U N   V A L O R   ";
            mensaje[2] = "   Q U E   N O   S U P E R E   ";
            mensaje[3] = "   E L   T O T A L    D E L    ";
            mensaje[4] = "   D E P O S I T O    ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO);
        }
        public static void Mensage07(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   N O   I N G R E S O    ", "   U N    V A L O R   ", "   C O R R E C T O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO);
        }
        public static void CajeroVenta(ref BDState dt)
        {
            string tecla = "";
            bool estado = true, falt = true, script = false, incremento = true, decremento = false, tabla = true;   
            int nivel = 0, i = 0, type = -1, inicio = 0, tope = 0, count = 0, index = 0, k = 0;
            IN keydata = new IN();
            keydata.SetCondIN(INCond._ARROWS);
            keydata.SetCondIN(INCond._TAB);
            keydata.SetCondIN(INCond._ENTER);

            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);

            string titulo = String.Concat("  Sector CAJERO => ", dt.SUCURSALCREATE.NOMSUCURSAL, "_", dt.SUCURSALCREATE.CODIGO, "  ");            
            IOdata.Selector(color.BLANCO, color.AZUL, titulo, titulo.Length, (((dt.WIDTH - 10) - titulo.Length) / 2), 8);

            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backtitulo2 = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };

            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 5, 25 , 25 , 40 , 25 , 20 , 20 }, new int[] { 3 , 34 }, 10, 11);
            DRAW.CuadradoSolid(color.DARK_GRIS, 3, 1, 11, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 23, 1, 17, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 23, 1, 43, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 38, 1, 69, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 23, 1, 110, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 18, 1, 136, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 17, 1, 157, 12);

            OUT.PrintLine("N°", color.BLANCO, color.DARK_GRIS, 12, 13);
            OUT.PrintLine("Tipo Producto", color.BLANCO, color.DARK_GRIS, 22, 13);
            OUT.PrintLine("Marca", color.BLANCO, color.DARK_GRIS, 52, 13);
            OUT.PrintLine("Producto", color.BLANCO, color.DARK_GRIS, 83, 13);
            OUT.PrintLine("Costo/unidad", color.BLANCO, color.DARK_GRIS, 116, 13);
            OUT.PrintLine("Cantidad", color.BLANCO, color.DARK_GRIS, 142, 13);
            OUT.PrintLine("SubPrecio", color.BLANCO, color.DARK_GRIS, 162, 13);

            IOdata.Selector(color.BLANCO, color.AZUL, "SUBTOTAL - DOLAR ", 16, 180, 30);
            IOdata.Selector(color.DARK_AMARILLO, color.AZUL, "", 25, 198, 30);

            IOdata.Selector(color.BLANCO, color.AZUL, "SUBTOTAL - PESOS ", 16, 180, 34);
            IOdata.Selector(color.DARK_AMARILLO, color.AZUL, "", 25, 198, 34);

            IOdata.Selector(color.GRIS, color.NEGRO, "   TOTAL - DOLAR ", 16, 180, 40);
            IOdata.Selector(color.DARK_AMARILLO, color.AZUL, "", 25, 198, 40);

            IOdata.Selector(color.GRIS, color.NEGRO, "   TOTAL - PESOS ", 16, 180, 44);
            IOdata.Selector(color.DARK_AMARILLO, color.AZUL, "", 25, 198, 44);

            IODATAINFO Cantidad_ = new IODATAINFO(" Cantidad a Comprar ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._UP_CENTER, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 190, 21);
            IOBUTTON btn_QUITAR_ = new IOBUTTON(" VER / QUITAR ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 178, 9);
            IOBUTTON btn_FINALY_ = new IOBUTTON("   FINALIZAR  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 203, 9);
            IOBUTTON btn_BORRAR_ = new IOBUTTON("  BORRAR TODO ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 178, 15);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("    VOLVER    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 203, 15);

            List<BoxProduct> CompraProduct = dt.COMPRACAJA;
            FDStockProduct opus_stock = new FDStockProduct(dt.SUCURSALCREATE.NOMSUCURSAL, dt.SUCURSALCREATE.CODIGO);
            FDTypeProduct opus_typep = new FDTypeProduct("ListTypeProduct");
            List<TypeProduct> listtype = new List<TypeProduct>();
            List<StockProduct> liststock = new List<StockProduct>();
            opus_typep.LoadTypeProductList(ref listtype);
            FDProducto opus_product = new FDProducto("ListTypeProduct");

            btn_QUITAR_.SetDataInfo(false);
            btn_FINALY_.SetDataInfo(false);
            btn_VOLVER_.SetDataInfo(false);

            while (estado)
            {
                if (nivel == 0)
                {
                    btn_QUITAR_.SetInactivated();
                    btn_FINALY_.SetInactivated();
                    btn_BORRAR_.SetInactivated();
                    btn_VOLVER_.SetInactivated();

                    btn_QUITAR_.Display(color.NEGRO, color.NEGRO);
                    btn_FINALY_.Display(color.NEGRO, color.NEGRO);
                    btn_BORRAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);

                    OUT.PrintLine("u$s " + dt.COMPRADOLARES.ToString(), color.AZUL, color.DARK_AMARILLO, 200, 31);
                    OUT.PrintLine("  $ " + dt.COMPRAPESOS.ToString(), color.AZUL, color.DARK_AMARILLO, 200, 35);


                    float suma = dt.COMPRADOLARES + (dt.COMPRAPESOS / dt.DOLARPESOS); 
                    OUT.PrintLine("u$s " + suma.ToString(), color.AZUL, color.DARK_AMARILLO, 200, 41);

                    suma = dt.COMPRAPESOS + (dt.COMPRADOLARES * dt.DOLARPESOS);
                    OUT.PrintLine("  $ " + suma.ToString(), color.AZUL, color.DARK_AMARILLO, 200, 45);

                    if (falt)
                    {
                        falt = false;
                        count = 0;
                        if (incremento)
                        {
                            type++;
                            if (type == listtype.Count) { type = 0; }
                        }
                        if (decremento)
                        {
                            type--;
                            if (type == -1) { type = listtype.Count - 1; }
                        }
                        liststock.Clear();
                        while (count == 0)
                        {
                            opus_stock.LoadStockProduct(ref liststock, listtype[type].Code);
                            count = liststock.Count;                            
                            if (count == 0) { 
                                if (incremento)
                                {
                                    type++; 
                                    if (type == listtype.Count) { type = 0; }
                                }
                                if (decremento)
                                {
                                    type--;
                                    if (type == -1) { type = listtype.Count - 1; }
                                }
                            }                            
                        }           
                        incremento = decremento = false;
                        opus_product = new FDProducto(listtype[type].ProductName, listtype[type].Code);
                        opus_product.LoadListProduct();
                        index = 0;
                    }
                    if (tabla)
                    {
                        tabla = false;
                        FUNCTION.TableClear();
                        tope = CompraProduct.Count;
                        if (CompraProduct.Count > 10) { inicio = tope - 10; }
                        else { inicio = 0; }
                        k = 0;
                        for (i = inicio; i < tope; i++)
                        {
                            FUNCTION.MostrarComprar(CompraProduct[i], color.NEGRO, color.CYAN, i + 1, k);
                            k++;
                        }
                    }
                    if (!script)
                    {
                        FUNCTION.MostrarProducto(liststock[index], opus_product, k);
                    }                                             
                    if (script)
                    {
                        Cantidad_.SetTypeDataIN(TypeDataIN._NUMERIC_PAD);
                        Cantidad_.SetActivated();
                        Cantidad_.Display(color.NEGRO, color.NEGRO);
                        string ty = Cantidad_.GetDataInfo().ToString();
                        Cantidad_.SetDataInfo("");

                        FUNCTION.Limpiador();

                        try
                        {
                            if (ty.Length != 0)
                            {
                                int numero = Convert.ToInt32(ty);
                                if (numero != 0)
                                {
                                    if (numero <= liststock[index].StockGondola)
                                    {
                                        opus_product.LoadListProduct();
                                        int klp = opus_product.SeekProducto(liststock[index].CodigoProducto);
                                        BoxProduct compra = new BoxProduct(liststock[index]);
                                        compra.SetPrecio(opus_product.GetProducto(klp).Moneda, opus_product.GetProducto(klp).Precio);
                                        compra.CANTIDAD = numero;
                                        compra.SetSubPrecio();
                                        CompraProduct.Add(compra);

                                        switch(opus_product.GetProducto(klp).Moneda)
                                        {
                                            case TipoMoneda._PESOS: dt.COMPRAPESOS += compra.GetSubPrecio(); break;
                                            case TipoMoneda._DOLAR: dt.COMPRADOLARES += compra.GetSubPrecio(); break;
                                        }

                                        
                                        tabla = true;
                                    }
                                    else
                                    {
                                        dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE08);
                                        estado = false;
                                    }
                                } else
                                {
                                    dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE10);
                                    estado = false;
                                }                                
                            } 
                            else 
                            { 
                                dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE07); 
                                estado = false;
                            }
                        }
                        catch
                        {
                            dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE09);
                            estado = false;
                        }                        
                    }
                }
                if (nivel == 1)
                {
                    btn_BORRAR_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    btn_FINALY_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_QUITAR_.SetSemiInactivated(); break;
                        case true: btn_QUITAR_.SetActivated(); break;
                    }
                    btn_FINALY_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_BORRAR_.Display(color.NEGRO, color.NEGRO);
                    btn_QUITAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 2)
                {
                    btn_BORRAR_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    btn_QUITAR_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_FINALY_.SetSemiInactivated(); break;
                        case true: btn_FINALY_.SetActivated(); break;
                    }
                    btn_BORRAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_QUITAR_.Display(color.NEGRO, color.NEGRO);
                    btn_FINALY_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 3)
                {
                    btn_QUITAR_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    btn_FINALY_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_BORRAR_.SetSemiInactivated(); break;
                        case true: btn_BORRAR_.SetActivated(); break;
                    }
                    btn_QUITAR_.Display(color.NEGRO, color.NEGRO);
                    btn_FINALY_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_BORRAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 4)
                {
                    btn_BORRAR_.SetInactivated();
                    btn_QUITAR_.SetInactivated();
                    btn_FINALY_.SetInactivated();
                    switch(script)
                    {
                        case false: btn_VOLVER_.SetSemiInactivated(); break;
                        case true: btn_VOLVER_.SetActivated(); break;
                    }
                    btn_BORRAR_.Display(color.NEGRO, color.NEGRO);
                    btn_QUITAR_.Display(color.NEGRO, color.NEGRO);
                    btn_FINALY_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)(btn_QUITAR_.GetDataInfo()))
                {
                    script = true;
                    estado = false;
                    dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO_QUITAR);
                }
                if ((bool)(btn_VOLVER_.GetDataInfo()))
                {
                    script = true;
                    estado = false;
                    dt.SetMState(TypeState._CajeroST, CajeroST._VOLVER);
                }
                if ((bool)(btn_FINALY_.GetDataInfo()))
                {
                    script = true;
                    estado = false;
                    dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO_FINALY);
                }
                if ((bool)(btn_BORRAR_.GetDataInfo()))
                {
                    script = true;
                    CompraProduct.Clear();
                    btn_BORRAR_.SetDataInfo(false);
                    nivel = 0;
                    tabla = true;
                    dt.COMPRAPESOS = 0;
                    dt.COMPRADOLARES = 0;
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    tecla = keydata.InputMode();

                    if (((tecla.Equals("DOWNARROW")) || (tecla.Equals("UPARROW")) || (tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW"))) && (nivel == 0))
                    {
                        if ((tecla.Equals("UPARROW")) || (tecla.Equals("DOWNARROW")))
                        {
                            if (tecla.Equals("DOWNARROW"))
                            {
                                index++;
                                if (index == liststock.Count) { index = 0; }
                            }
                            if (tecla.Equals("UPARROW"))
                            {
                                index--;
                                if (index == -1) { index = liststock.Count - 1; }
                            }
                        }
                        if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")))
                        {
                            falt = true;
                            if (tecla.Equals("RIGHTARROW")) { incremento = true; }
                            if (tecla.Equals("LEFTARROW")) { decremento = true; }
                        }
                    }
                    else
                    {
                        if (tecla.Equals("TAB"))
                        {
                            nivel++;
                            if (nivel == 5) { nivel = 0; }
                        } 
                        else 
                        {
                            if (tecla.Equals("ENTER"))
                            {
                                script = true;
                            }
                        }                        
                    }
                }
                else { script = false; }                
            }            
        }
        public static void Mensage06(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   S U C U R S A L    S E L E C C I O N A D A   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._VOLVER);
        }
        public static void VerifStock(ref BDState dt)
        {
            FDStockProduct stock = new FDStockProduct(dt.SUCURSALCREATE.NOMSUCURSAL, dt.SUCURSALCREATE.CODIGO);
            stock.LoadStockProduct();
            int count = stock.CountStockProduct();
            if (count > 0) { dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO); }
            if (count == 0) { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE06); }
        }
        public static void MenuSucursal(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            IOdata.Selector(color.BLANCO, color.AZUL, "  Sector CAJERO y VENTAS  ", 36, 84, 8);

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
                            dt.SetMState(TypeState._CajeroST, CajeroST._VOLVER);
                        }
                        else
                        {
                            if (tecla.Equals("ENTER"))
                            {
                                dt.SUCURSALCREATE = listado[position];
                                dt.SetMState(TypeState._CajeroST, CajeroST._VERIFSTOCK);
                                estado = false;
                            }
                        }
                    }
                }
            }
        }
        public static void Mensage05(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   N O   P O S E E    S T O C K   ", "   E N   L A   ", "   B A S E   D E   D A T O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._VOLVER);
        }
        public static void ListerStock(ref BDState dt)
        {
            List<Sucursal> listado_sucursal = new List<Sucursal>();
            FDSucursal sucursal = new FDSucursal("ListSucursales");
            sucursal.LoadFileSucursales(ref listado_sucursal);
            int i = 1;
            int count = 0;
            while ((i < listado_sucursal.Count) && (count == 0))
            {
                Sucursal scr = listado_sucursal[i];
                FDStockProduct stock = new FDStockProduct(scr.NOMSUCURSAL, scr.CODIGO);
                stock.LoadStockProduct();
                count = stock.CountStockProduct();
                i++;
            }
            if (count == 0) { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE05); }
            if (count > 0) { dt.SetMState(TypeState._CajeroST, CajeroST._MENUOPTION); }
        }
        public static void Mensage04(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   N O   P O S E E    S U C U R S A L E S   ", "   E N   L A   ", "   B A S E   D E   D A T O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._VOLVER);
        }
        public static void ListerSucursal(ref BDState dt)
        {
            FDSucursal list_sucursal = new FDSucursal("ListSucursales");
            int count = list_sucursal.CountListSucursal();
            if (count > 1) { dt.SetMState(TypeState._CajeroST, CajeroST._LISTER_STOCK); }
            if (count == 1) { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE04); }
        }
        public static void Mensage03(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   N O   P O S E E    P R O D U C T O S   ", "   E N   L A   ", "   B A S E   D E   D A T O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._VOLVER);
        }
        public static void ListerProduct(ref BDState dt)
        {
            List<TypeProduct> Listado = new List<TypeProduct>();
            FDTypeProduct list_typeprod = new FDTypeProduct("ListTypeProduct");
            list_typeprod.LoadTypeProductList(ref Listado);
            int i = 0, count = 0;
            
            while ((i < Listado.Count) && (count == 0))
            {
                TypeProduct tp = Listado[i];
                FDProducto stock = new FDProducto(tp.ProductName, tp.Code);
                count = stock.CountListProducto();
                i++;
            }
            if (count > 0) { dt.SetMState(TypeState._CajeroST, CajeroST._LISTER_SUCURSAL); }
            if (count == 0) { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE02); } 
        }
        public static void Mensage02(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   N O   P O S E E    T I P O   D E   P R O D U C T O   ", "   E N   L A   ", "   B A S E   D E   D A T O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._VOLVER);
        }
        public static void ListerTypeProduct(ref BDState dt)
        {
            FDTypeProduct list_stock = new FDTypeProduct("ListTypeProduct");
            int count = list_stock.Count_ListTypeProduct();
            if (count == 0) { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE02); }
            if (count > 0) { dt.SetMState(TypeState._CajeroST, CajeroST._LISTER_PRODUCT); }
        }
        public static void Mensage01(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   N O   P O S E E    U S U A R I O S   " , "   E N   L A   " , "   B A S E   D E   D A T O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._CajeroST, CajeroST._VOLVER);
        }
        public static void VolverMenu(ref BDState dt)
        {
            dt.SetMState(TypeState._CajeroST, CajeroST._none);
            dt.SetMState(TypeState._LiveCajeroST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SystemUser, SystemUser._PRESENTADOR);
            dt.SetMState(TypeState._StateMain, StateMain._SYSTEM_USER);
        }
        public static void ListerUser(ref BDState dt)
        {
            FDUsuario list_user = new FDUsuario("ListUserProgram");
            int count = list_user.CountListUser();

            if (count == 1) { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE01); }
            if (count > 1) { dt.SetMState(TypeState._CajeroST, CajeroST._LISTER_TYPE_PRODUCT); }
        }

    }
}
