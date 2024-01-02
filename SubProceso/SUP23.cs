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
    public class SUP23
    {
        public static void MensageP4(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   L O S   D A T O S   ",
                                 "   D E L   T I P O   D E   P R O D U C T O   " ,
                                 "   H A   S I D O   E L I M I N A D O   ",
                                 "   E N   L A   B A S E   ",
                                 "   D  E   D  A  T  O  S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.MAGENTA, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._VOLVER);
        }
        public static void RemoveTipoProducto2(ref BDState dt)
        {
            FDTypeProduct tipoproducto = new FDTypeProduct(dt.TIPRODUCTCREATE.Code, dt.TIPRODUCTCREATE.ProductName);
            tipoproducto.RemoveTypeProducto2();
            dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._MENSAGE4);
        }
        public static void RemoveTipoProducto1(ref BDState dt)
        {
            FDTypeProduct tipoproducto = new FDTypeProduct("ListTypeProduct");
            tipoproducto.LoadTypeProductList();
            int indice = tipoproducto.SeekNomTypeProduct(dt.TIPRODUCTCREATE.ProductName);
            tipoproducto.RemoveTypeProducto(indice);
            tipoproducto.SaveTypeProductList();
            dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._REMOVE_TP2);
        }
        public static void VisualizarTipoProducto(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            IOdata.Selector(color.BLANCO, color.AZUL, " Administracion - Eliminar Tipo de Productos ", 45, 90, 8);
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

            TipoProducto_.SetDataInfo(dt.TIPRODUCTCREATE.ProductName);
            Codigo_.SetDataInfo(dt.TIPRODUCTCREATE.Code);

            while (estado)
            {
                TipoProducto_.SetInactivated();
                Codigo_.SetInactivated();
                btn_ACEPTAR_.SetInactivated();
                btn_ESCAPE_.SetInactivated();
                TipoProducto_.Display(color.NEGRO, color.NEGRO);
                Codigo_.Display(color.NEGRO, color.NEGRO);
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
                    case 0: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO);     break;
                    case 1: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                }
                if ((bool)btn_ACEPTAR_.GetDataInfo())
                {
                    dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._REMOVE_TP);
                    estado = false;
                }
                if ((bool)btn_ESCAPE_.GetDataInfo())
                {                    
                    dt.TIPRODUCTCREATE = new TypeProduct();
                    dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._VOLVER);
                    estado = false;
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if (tecla.Equals("TAB"))
                    {
                        contador++;
                        if (contador == 2) { contador = 0; }
                    }
                    else { if (tecla.Equals("ENTER")) { script = true; } }
                }
                else { script = false; }
            }
        }
        public static void MensageP3(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   N O M B R E   D E L    T I P O   ",
                                 "   D E   P R O D U C T O   " ,
                                 "   E S   I N E X I S T E N T E   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.MAGENTA, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._VOLVER);
        }
        public static void SeekForNomTypeProduct(ref BDState dt)
        {
            FDTypeProduct tipoproducto = new FDTypeProduct("ListTypeProduct");
            tipoproducto.LoadTypeProductList();
            int valor = tipoproducto.SeekNomTypeProduct(dt.TIPRODUCTCREATE.ProductName);
            if (valor != -1) {
                dt.TIPRODUCTCREATE = tipoproducto.GetTypeProducto(valor);
                dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._VIEW_TP); 
            }
            if (valor == -1) { dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._MENSAGE3); }
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
            mensaje[1] = "   E L   N O M B R E  ";
            mensaje[2] = "   D E L   ";
            mensaje[3] = "   T I P O    D E   P R O D U C T O   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._VOLVER);
        }
        public static void BuscadorNom(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
                
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };

            string leg = "";           
            IOdata.Selector(color.BLANCO, color.AZUL, " Administracion - Eliminar Tipo de Productos ", 45, 90, 8);
            IODATAINFO TypeNum_ = new IODATAINFO(" Tipo de producto ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 30, 15);
            TypeNum_.SetTypeDataIN(TypeDataIN._LETTER);
            TypeNum_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            TypeNum_.SetTypeDataIN(TypeDataIN._SPACE);
            TypeNum_.SetDataInfo((string)"");
            TypeNum_.SetActivated();
            TypeNum_.Display(color.NEGRO, color.NEGRO);
            leg = (string)TypeNum_.GetDataInfo();

            if (leg.Length != 0) {
                dt.TIPRODUCTCREATE.ProductName = leg;
                dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._VERIF_NOM); 
            }
            else { dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._MENSAGE2); }
        }
        public static void VolverTipoProducto(ref BDState dt)
        {
            dt.TIPRODUCTCREATE = new TypeProduct();
            if (dt.POSITION == 2)
            {
                dt.POSITION = -1;
                dt.SetMState(TypeState._LiveProductosRemoveTypeST, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._none);
                dt.SetMState(TypeState._LiveProductosListST, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._VERIF);
                dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_LISTER_TYPE);
            } else
            {
                dt.SetMState(TypeState._LiveProductosRemoveTypeST, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._none);
                dt.SetMState(TypeState._LiveProductosST, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._ProductosST, ProductosST._MENUOPTION);
                dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ST);
            }
            
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
            dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._VOLVER);            
        }
        public static void VerificarTypeProducts(ref BDState dt)
        {
            FDTypeProduct tipoproducto = new FDTypeProduct("ListTypeProduct");
            tipoproducto.LoadTypeProductList();
            int count = tipoproducto.Count_ListTypeProduct();
            if (count >= 1) { dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._NOMTP); }
            if (count == 0) { dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._MENSAGE1); }
        }
    }
}
