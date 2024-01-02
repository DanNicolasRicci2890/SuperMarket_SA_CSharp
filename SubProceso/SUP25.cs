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
    public class SUP25
    {
        public static void Director(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveProductosSeekST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ProductosSeekST, ProductosSeekST._none);
            dt.SetMState(TypeState._LiveProductosAddST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._ADD_PRODUCT);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ADD);
        }
        public static void MensageP2(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   E R R O N E O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   C O D I G O    D E L    P R O D U C T O   ";
            mensaje[1] = "   I N E X I S T E N T E   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._LiveProductosSeekST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ProductosSeekST, ProductosSeekST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosST, ProductosST._MENUOPTION);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ST);
            dt.CONDPRODUCTCREATE = -1;
        }
        public static void MensageP1(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   E R R O N E O S   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   F A L T A   E L    C O D I G O   ";
            mensaje[1] = "   D E L    P R O D U C T O   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._LiveProductosSeekST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ProductosSeekST, ProductosSeekST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosST, ProductosST._MENUOPTION);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ST);
            dt.CONDPRODUCTCREATE = -1;
        }
        public static void SeekCode(ref BDState dt)
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
            string titulo = "Administracion - ";

            if (dt.CONDPRODUCTCREATE == 6)
            {
                titulo = String.Concat(titulo, "Modificacion de Produccion");
            }
            if (dt.CONDPRODUCTCREATE == 8)
            {
                titulo = String.Concat(titulo, "Eliminacion de Produccion");
            }
            IOdata.Selector(color.BLANCO, color.AZUL, titulo, 45, 90, 8);

            IODATAINFO Codigo_ = new IODATAINFO(" Codigo ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 30, 15);
            Codigo_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Codigo_.SetDataInfo((string)"");
            Codigo_.SetActivated();
            Codigo_.Display(color.NEGRO, color.NEGRO);
            leg = (string)Codigo_.GetDataInfo();

            if (!(leg.Equals("")))
            {
                FDProducto pot = new FDProducto("ListTypeProduct");
                dt.PRODUCTCREATE = pot.BuscadorCodigo(leg);

                switch (dt.PRODUCTCREATE.Codigo.Equals("---"))
                {
                    case (false): dt.SetMState(TypeState._ProductosSeekST, ProductosSeekST._DIRECTOR); break;
                    case (true): dt.SetMState(TypeState._ProductosSeekST, ProductosSeekST._MENSAGE2); break;
                }
            } else { dt.SetMState(TypeState._ProductosSeekST, ProductosSeekST._MENSAGE1); }            
        }
    }
}


