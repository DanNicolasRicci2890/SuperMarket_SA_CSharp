using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;
using PCD_EVENT_DATA;
using PCD_INOUT_INFO;

namespace SuperMarket_SA
{
    public class SUP31
    {
        public static void Remove(ref BDState dt)
        {
            dt.SetMState(TypeState._DepotLogicST, DepotLogicST._none);
            dt.SetMState(TypeState._LiveDepotLogicST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveDepotLogicRemoveST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._DepotLogicRemoveST, DepotLogicRemoveST._LISTER_SUCURSAL);
            dt.SetMState(TypeState._StateMain, StateMain._DEPOTLOGICREMOVEST);
        }
        public static void Gondola(ref BDState dt)
        {
            dt.SetMState(TypeState._DepotLogicST, DepotLogicST._none);
            dt.SetMState(TypeState._LiveDepotLogicST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveDepotLogicGondolaST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._DepotLogicGondolaST, DepotLogicGondolaST._LISTER_SUCURSAL);
            dt.SetMState(TypeState._StateMain, StateMain._DEPOTLOGICGONDOLAST);
        }
        public static void Logistica(ref BDState dt)
        {
            dt.SetMState(TypeState._DepotLogicST, DepotLogicST._none);
            dt.SetMState(TypeState._LiveDepotLogicST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveDepotLogicLogisticaST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._DepotLogicLogisticaST, DepotLogicLogisticaST._LISTER);
            dt.SetMState(TypeState._StateMain, StateMain._DEPOTLOGICLOGISTICAST);
        }
        public static void MenuOpcion(ref BDState dt)
        {
            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

            string[] selection = { "   Logistica de Transporte   " ,
                                   "   Muestreo de Gondolas  " ,  // 2F
                                   "   Eliminar Stock de Sucursal  " ,  // 
                                   "   Volver al Menu Principal  " };  // 

            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            IOMENU menuopcion = new IOMENU("Deposito y Logistica - Menu de Opciones", selection, 3, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 20, 10);
            int roles = 0;
            
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemDepositLogic, 0, 0); // 1
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemDepositLogic, 1, 1); // 2 
            FUNCTION.StateBit(ref roles, dt.USERSESION.SystemDepositLogic, 2, 2); // 4 

            menuopcion.SetDataInfo(roles + 8);
            menuopcion.Display(color.NEGRO, color.NEGRO);
            int opcion = Convert.ToInt32(menuopcion.GetDataInfo());
            switch (opcion)
            {
                case 0: dt.SetMState(TypeState._DepotLogicST, DepotLogicST._LOGISTICA); break;
                case 1: dt.SetMState(TypeState._DepotLogicST, DepotLogicST._GONDOLAS); break;
                case 2: dt.SetMState(TypeState._DepotLogicST, DepotLogicST._REMOVE); break;
                case 3: dt.SetMState(TypeState._DepotLogicST, DepotLogicST._VOLVER); break;
            }
        }
        public static void Mensage04(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[3];
            mensaje[0] = "   N O   P O S E E   ";
            mensaje[1] = "   S T O C K   E N   L A   ";
            mensaje[2] = "   C A S A   C E N T R A L   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._DepotLogicST, DepotLogicST._VOLVER);
        }
        public static void VerificarStock(ref BDState dt)
        {
            FDStockProduct stock = new FDStockProduct("CASA_CENTRAL", "");
            stock.LoadStockProduct();
            int count = stock.CountStockProduct();
            if (count > 0) { dt.SetMState(TypeState._DepotLogicST, DepotLogicST._MENUOPTION); }
            if (count == 0) { dt.SetMState(TypeState._DepotLogicST, DepotLogicST._MENSAGE04); }
        }
        public static void Mensage03(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   N O   P O S E E   ";
            mensaje[1] = "   S U C U R S A L E S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._DepotLogicST, DepotLogicST._VOLVER);
        }
        public static void VerificarSucursal(ref BDState dt)
        {
            FDSucursal sucursal = new FDSucursal("ListSucursales");
            sucursal.LoadFileSucursales();
            int count = sucursal.CountListSucursal();
            if (count > 1) { dt.SetMState(TypeState._DepotLogicST, DepotLogicST._VERIF_STOCK); }
            if (count == 1) { dt.SetMState(TypeState._DepotLogicST, DepotLogicST._MENSAGE03); }
        }
        public static void Mensage02(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   N O   P O S E E   ";
            mensaje[1] = "   P R O D U C T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._DepotLogicST, DepotLogicST._VOLVER);
        }
        public static void VerificarProducto(ref BDState dt)
        {
            List<TypeProduct> list_type = new List<TypeProduct>();
            FDTypeProduct tipoproducto = new FDTypeProduct("ListTypeProduct");            
            tipoproducto.LoadTypeProductList(ref list_type);
            bool estado = false;
            int i = 0;

            while ((i < list_type.Count) && (!estado))
            {
                FDProducto producto = new FDProducto(list_type[i].ProductName, list_type[i].Code);
                producto.LoadListProduct();
                estado = (producto.CountListProducto() > 0);
                i++;
            }
            switch(estado)
            {
                case false: dt.SetMState(TypeState._DepotLogicST, DepotLogicST._MENSAGE02); break;
                case true: dt.SetMState(TypeState._DepotLogicST, DepotLogicST._VERIF_SUCURSALES); break;
            }
        }
        public static void Mensage01(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O   " , "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   N O   P O S E E   ";
            mensaje[1] = "   T I P O S    D E   P R O D U C T O   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._DepotLogicST, DepotLogicST._VOLVER);
        }
        public static void VerificarTipoProductos(ref BDState dt)
        {
            FDTypeProduct tipoproducto = new FDTypeProduct("ListTypeProduct");
            tipoproducto.LoadTypeProductList();
            int count = tipoproducto.Count_ListTypeProduct();
            if (count >= 1) { dt.SetMState(TypeState._DepotLogicST, DepotLogicST._VERIF_PRODUCTO); }
            if (count == 0) { dt.SetMState(TypeState._DepotLogicST, DepotLogicST._MENSAGE01); }
        }
        public static void VolverMenu(ref BDState dt)
        {
            dt.SetMState(TypeState._DepotLogicST, DepotLogicST._none);
            dt.SetMState(TypeState._LiveDepotLogicST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SystemUser, SystemUser._PRESENTADOR);
            dt.SetMState(TypeState._StateMain, StateMain._SYSTEM_USER);
        }
    }
}
