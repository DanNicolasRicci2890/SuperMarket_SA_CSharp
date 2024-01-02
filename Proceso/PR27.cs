using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR27
    {
        /*
            PR27: (FINALIZADO)
                Ingresamos al usuario de tipo CONTADURIA, procesa la compra de productos hacia la CASA CENTRAL
                y administra el dinero ingresado por los cajeros de venta.
        */
        public static void Contaduria(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveContaduriaST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ContaduriaST)(dt.GetMState(TypeState._ContaduriaST)))
                {
                    case (ContaduriaST._VERIF_USER): SUP27.VerificadorUser(ref dt); break;
                    case (ContaduriaST._MENSAGE01): SUP27.Mensage01(ref dt); break;
                    case (ContaduriaST._VERIF_SUCURSAL): SUP27.VerificadorSucursales(ref dt); break;
                    case (ContaduriaST._MENSAGE02): SUP27.Mensage02(ref dt); break;
                    case (ContaduriaST._VERIF_PRODUCT): SUP27.VerificadorProducto(ref dt); break;
                    case (ContaduriaST._MENSAGE03): SUP27.Mensage03(ref dt); break;
                    case (ContaduriaST._MENUOPTION): SUP27.MenuOpcion(ref dt); break;
                    case (ContaduriaST._VOLVER): SUP27.Volver(ref dt); break;
                    case (ContaduriaST._COMPRAR_PRODUCT): SUP27.ComprarProducto(ref dt); break;
                    case (ContaduriaST._STOCK_CENTRAL): SUP27.VisualizarDepositoCentral(ref dt); break;
                    case (ContaduriaST._CONFIG_DOLARPESO): SUP27.ConfiguracionDolarPesos(ref dt); break;
                    case (ContaduriaST._GANANCIA): SUP27.Ganancia(ref dt); break;
                }
            }
        }
    }
}
