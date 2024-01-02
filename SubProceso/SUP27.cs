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
    public class SUP27
    {
        public static void Ganancia(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveContaduriaST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._none);
            dt.SetMState(TypeState._LiveContaduriaGanancia, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ContaduriaGanancia, ContaduriaGanancia._VIEW);
            dt.SetMState(TypeState._StateMain, StateMain._CONTADURIA_GANANCIA);
        }
        public static void ConfiguracionDolarPesos(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveContaduriaST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._none);
            dt.SetMState(TypeState._LiveContaduriaDolarPeso, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ContaduriaDolarPesos, ContaduriaDolarPesos._CONFIG);
            dt.SetMState(TypeState._StateMain, StateMain._CONTADURIA_DOLAR);
        }
        public static void VisualizarDepositoCentral(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveContaduriaST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._none);
            dt.SetMState(TypeState._LiveContaduriaStockST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ContaduriaStockST, ContaduriaStockST._VERIF_STOCK);
            dt.SetMState(TypeState._StateMain, StateMain._CONTADURIA_STOCK);
        }
        public static void ComprarProducto(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveContaduriaST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._none);            
            dt.SetMState(TypeState._LiveContaduriaProductST, LiveProgram._ACTIVATED);            
            dt.SetMState(TypeState._ContaduriaProductST, ContaduriaCompraST._TIPO_PRODUCT);            
            dt.SetMState(TypeState._StateMain, StateMain._CONTADURIA_COMPRA_PROD);
        }
        public static void Volver(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveContaduriaST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._none);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SystemUser, SystemUser._PRESENTADOR);
            dt.SetMState(TypeState._StateMain, StateMain._SYSTEM_USER);
        }
        public static void MenuOpcion(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);

            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

            string[] selopcion = { " Compra de Productos " , 
                                   " Visualizar/Eliminar Stock Central " ,
                                   " Configurar Dolar/Peso " ,
                                   " Visualizar Ganancias " ,                                       
                                   " Volver al Menu Principal " }; 

            Console.ResetColor();
            int estado_condicion = 0;
            IOMENU menuopcion = new IOMENU("Contaduria - Menu de Opciones", selopcion, 3, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 20, 15);
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemContaduria, 0, 0);  
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemContaduria, 1, 1);  
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemContaduria, 2, 2);
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemContaduria, 3, 3);

            menuopcion.SetDataInfo(estado_condicion + 16);
            menuopcion.Display(color.NEGRO, color.NEGRO);

            int opcion = (int)menuopcion.GetDataInfo();

            switch (opcion) 
            {
                case 0: dt.SetMState(TypeState._ContaduriaST, ContaduriaST._COMPRAR_PRODUCT); break;
                case 1: dt.SetMState(TypeState._ContaduriaST, ContaduriaST._STOCK_CENTRAL); break;
                case 2: dt.SetMState(TypeState._ContaduriaST, ContaduriaST._CONFIG_DOLARPESO); break;
                case 3: dt.SetMState(TypeState._ContaduriaST, ContaduriaST._GANANCIA); break;
                case 4: dt.SetMState(TypeState._ContaduriaST, ContaduriaST._VOLVER); break;
            }
        }
        public static void Mensage03(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O S   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[4];
            mensaje[0] = "   N O    P O S E E   ";
            mensaje[1] = "   P R O D U C T O S   ";
            mensaje[2] = "   E N   L A   ";
            mensaje[3] = "   B A S E   D E   D A T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._VOLVER);            
        }
        public static void VerificadorProducto(ref BDState dt)
        {
            // buscar si poseemos tipo de productos
            FDTypeProduct opus23 = new FDTypeProduct("ListTypeProduct");

            // contar la cantidad de tipo de productos
            int counter_Type = opus23.Count_ListTypeProduct();

            // verificar la cantidad de tipos de productos
            if (counter_Type > 0) 
            {
                // si posee tipo de productos cargar un lista
                List<TypeProduct> lister = new List<TypeProduct>();
                opus23.LoadTypeProductList(ref lister);
                int i = 0, counter_product = 0;               
                while ((i < lister.Count) && (counter_product == 0))
                {
                    FDProducto opus27 = new FDProducto(lister[i].ProductName, lister[i].Code);
                    counter_product = opus27.CountListProducto();
                    i++;
                }
                if (counter_product > 0) { dt.SetMState(TypeState._ContaduriaST, ContaduriaST._MENUOPTION); }
                if (counter_product == 0) { dt.SetMState(TypeState._ContaduriaST, ContaduriaST._MENSAGE03); }
            }
            // si no posee tipos de productos emimir un mensaje de falta de productos.
            if (counter_Type == 0) { dt.SetMState(TypeState._ContaduriaST, ContaduriaST._MENSAGE03); }
        }
        public static void Mensage02(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O S   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[4];
            mensaje[0] = "   N O    P O S E E   ";
            mensaje[1] = "   S U C U R S A L E S   ";
            mensaje[2] = "   E N   L A   ";
            mensaje[3] = "   B A S E   D E   D A T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._VOLVER);
        }
        public static void VerificadorSucursales(ref BDState dt)
        {
            FDSucursal condicion = new FDSucursal("ListSucursales");
            int cont = condicion.CountListSucursal();

            if (cont > 1) { dt.SetMState(TypeState._ContaduriaST, ContaduriaST._VERIF_PRODUCT); }
            if (cont == 1) { dt.SetMState(TypeState._ContaduriaST, ContaduriaST._MENSAGE02); }
        }
        public static void Mensage01(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O S   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[4];
            mensaje[0] = "   N O    P O S E E   ";
            mensaje[1] = "   U S U A R I O S   ";
            mensaje[2] = "   E N   L A   ";
            mensaje[3] = "   B A S E   D E   D A T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._VOLVER);
        }
        public static void VerificadorUser(ref BDState dt)
        {
            FDUsuario condicion = new FDUsuario("ListUserProgram");
            int cont = condicion.CountListUser();

            if (cont > 1) { dt.SetMState(TypeState._ContaduriaST, ContaduriaST._VERIF_PRODUCT); }
            if (cont == 1) { dt.SetMState(TypeState._ContaduriaST, ContaduriaST._MENSAGE01); }
        }
    }
}
