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
    public class SUP20
    {
        public static void ListerProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosST, ProductosST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosListST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosListST, ProductosListST._VERIF);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_LISTER);
            dt.CONDPRODUCTCREATE = -1;
            dt.PRODUCTCREATE = new Producto();
        }
        public static void RemoveProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosST, ProductosST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosSeekST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosSeekST, ProductosSeekST._SEEK_CODE);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_SEEK);
            dt.CONDPRODUCTCREATE = 8;
            dt.PRODUCTCREATE = new Producto();
        }
        public static void ModifProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosST, ProductosST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosSeekST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosSeekST, ProductosSeekST._SEEK_CODE);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_SEEK);
            dt.CONDPRODUCTCREATE = 6;
            dt.PRODUCTCREATE = new Producto();
        }
        public static void AddProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosST, ProductosST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosAddST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosAddST, ProductosAddST._VERIF_TP);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ADD);
            dt.CONDPRODUCTCREATE = 0;
            dt.PRODUCTCREATE = new Producto();
        }
        public static void RemoveTypeProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosST, ProductosST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosRemoveTypeST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosRemoveTypeST, ProductosRemoveTypeST._VERIF);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_REMOVE_TYPE);
        }
        public static void AddTypeProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosST, ProductosST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosAddTypeST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosAddTypeST, ProductosAddTypeST._PRESENT);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_ADD_TYPE);
        }
        public static void ListTypeProduct(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosST, ProductosST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveProductosListTypeST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ProductosListTypeST, ProductosListTypeST._VERIF);
            dt.SetMState(TypeState._StateMain, StateMain._PRODUCTOS_LISTER_TYPE);
        }
        public static void Volver(ref BDState dt)
        {
            dt.SetMState(TypeState._ProductosST, ProductosST._none);
            dt.SetMState(TypeState._LiveProductosST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveAdministrador, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._Administrador, Administrador._MENUOPCION);
            dt.SetMState(TypeState._StateMain, StateMain._ADMINISTRADOR);
        }
        public static void MenuOpcion(ref BDState dt)
        {
            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

            string[] selection = { "   Lista de tipos de Productos   " , // 1 
                                   "   Agregar Tipo de Producto   " ,  // 2F
                                   "   Eliminar tipos de Productos   " , // 4F
                                   "   Visualizar un tipo de Producto    " , // 8F
                                   "   Agregar Productos    " , // 16F 
                                   "   Modificar Productos    " , // 32F
                                   "   Eliminar Productos   " , // 64F
                                   "   Volver   " };  // 128F

            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            IOMENU menuopcion = new IOMENU("Administracion - Menu de Opciones", selection, 3, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 20, 10);
            int roles = 0;
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 5, 0); // 1
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 6, 1); // 2 
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 7, 2); // 4
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 8, 3); // 8
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 9, 4); // 16
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 10, 5); // 32
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemAdministrador, 11, 6); // 64
            
            menuopcion.SetDataInfo(roles + 128);
            menuopcion.Display(color.NEGRO, color.NEGRO);
            int opcion = Convert.ToInt32(menuopcion.GetDataInfo());
            switch(opcion)
            {
                case 0: dt.SetMState(TypeState._ProductosST, ProductosST._LIST_TYPEPRODUCT); break;
                case 1: dt.SetMState(TypeState._ProductosST, ProductosST._ADD_TYPEPRODUCT); break;
                case 2: dt.SetMState(TypeState._ProductosST, ProductosST._REMOVE_TYPEPRODUCT); break;
                case 3: dt.SetMState(TypeState._ProductosST, ProductosST._LIST_PRODUCT); break;
                case 4: dt.SetMState(TypeState._ProductosST, ProductosST._ADD_PRODUCT); break;
                case 5: dt.SetMState(TypeState._ProductosST, ProductosST._MODIF_PRODUCT); break;
                case 6: dt.SetMState(TypeState._ProductosST, ProductosST._REMOVE_PRODUCT); break;
                case 7: dt.SetMState(TypeState._ProductosST, ProductosST._VOLVER); break;
            }
        }
    }
}
