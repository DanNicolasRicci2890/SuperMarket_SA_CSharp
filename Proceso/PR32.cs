using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR32
    {
        /*
            PR32:(FINALIZADO)
                    Realiza los depositos de stock a las sucursales
        */
        public static void DepositoCasaCentral(ref BDState dt) 
        {
            while (dt.EqualsMState(TypeState._LiveDepotLogicLogisticaST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((DepotLogicLogisticaST)(dt.GetMState(TypeState._DepotLogicLogisticaST))) 
                {
                    case (DepotLogicLogisticaST._LISTER): SUP32.ListerDeposito(ref dt); break;
                    case (DepotLogicLogisticaST._VOLVER): SUP32.VolverMenu(ref dt); break;
                    case (DepotLogicLogisticaST._SECTION): SUP32.SelectionSucursal(ref dt); break;
                    case (DepotLogicLogisticaST._DEPOS): SUP32.DepositoLogic(ref dt); break;
                    case (DepotLogicLogisticaST._MENSAGE01): SUP32.Mensage01(ref dt); break;
                    case (DepotLogicLogisticaST._MENSAGE02): SUP32.Mensage02(ref dt); break;
                    case (DepotLogicLogisticaST._DEPOSITO): SUP32.DepositoStockData(ref dt); break;
                    case (DepotLogicLogisticaST._MENSAGE03): SUP32.Mensage03(ref dt); break;
                }
            }
        }
    }
}
