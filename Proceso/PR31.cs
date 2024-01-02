using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR31
    {
        /*
            PR31:(FINALIZADO)
                Se realiza las opciones que realiza un usuario de DEPOSITO y LOGISTICA.
        */
        public static void DepositoyLogica(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveDepotLogicST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((DepotLogicST)(dt.GetMState(TypeState._DepotLogicST))) 
                {
                    case (DepotLogicST._VERIF_TIPOPRODUCTO): SUP31.VerificarTipoProductos(ref dt); break;
                    case (DepotLogicST._MENSAGE01): SUP31.Mensage01(ref dt); break;
                    case (DepotLogicST._VERIF_PRODUCTO): SUP31.VerificarProducto(ref dt); break;
                    case (DepotLogicST._MENSAGE02): SUP31.Mensage02(ref dt); break;
                    case (DepotLogicST._VERIF_SUCURSALES): SUP31.VerificarSucursal(ref dt); break;
                    case (DepotLogicST._MENSAGE03): SUP31.Mensage03(ref dt); break;
                    case (DepotLogicST._VERIF_STOCK): SUP31.VerificarStock(ref dt); break;
                    case (DepotLogicST._MENSAGE04): SUP31.Mensage04(ref dt); break;
                    case (DepotLogicST._VOLVER): SUP31.VolverMenu(ref dt); break;
                    case (DepotLogicST._MENUOPTION): SUP31.MenuOpcion(ref dt); break;
                    case (DepotLogicST._LOGISTICA): SUP31.Logistica(ref dt); break;
                    case (DepotLogicST._GONDOLAS): SUP31.Gondola(ref dt); break;
                    case (DepotLogicST._REMOVE): SUP31.Remove(ref dt); break;
                }
            }
        }
    }
}
