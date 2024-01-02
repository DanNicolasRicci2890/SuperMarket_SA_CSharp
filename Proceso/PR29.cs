using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR29
    {
        /*
            PR29: (FINALIZADO)
                Se visualiza la lista de Stock de la sucursal Central.
        */
        public static void ContaduriaStock(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveContaduriaStockST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ContaduriaStockST)(dt.GetMState(TypeState._ContaduriaStockST)))
                {
                    case (ContaduriaStockST._VERIF_STOCK): SUP29.VerificarStockCentral(ref dt); break;
                    case (ContaduriaStockST._MENSAGE01): SUP29.Mensage01(ref dt); break;
                    case (ContaduriaStockST._VOLVER): SUP29.VolverContaduria(ref dt); break;
                    case (ContaduriaStockST._LISTER): SUP29.ListerStock(ref dt); break;
                    case (ContaduriaStockST._QUESTION): SUP29.QuestionStock(ref dt); break;
                    case (ContaduriaStockST._REMOVE): SUP29.RemoveStock(ref dt); break;
                    case (ContaduriaStockST._MENSAGE02): SUP29.Mensage02(ref dt); break;
                }
            }
        }
    }
}
