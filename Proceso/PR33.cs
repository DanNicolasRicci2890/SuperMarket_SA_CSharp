using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR33
    {
        /*
            PR33: (FINALIZADO)
                Administra el Stock de cada Sucursal, pasando mercaderia del deposito a la gondola
            en cada sucursal.
        */
        public static void DepositoGondola(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveDepotLogicGondolaST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((DepotLogicGondolaST)(dt.GetMState(TypeState._DepotLogicGondolaST)))
                {
                    case (DepotLogicGondolaST._LISTER_SUCURSAL): SUP33.SeccionSucursal(ref dt); break;
                    case (DepotLogicGondolaST._VOLVER): SUP33.VolverMenu(ref dt); break;
                    case (DepotLogicGondolaST._MENSAGE01): SUP33.Mensage01(ref dt); break;
                    case (DepotLogicGondolaST._VERIF_PRODUCTO): SUP33.VerifSucursal(ref dt); break;
                    case (DepotLogicGondolaST._LISTER_PRODUCTO): SUP33.SeccionProducto(ref dt); break;
                    case (DepotLogicGondolaST._SELECT_PRODUCTO): SUP33.DespositoGondola(ref dt); break;
                    case (DepotLogicGondolaST._MENSAGE02): SUP33.Mensage02(ref dt); break;
                    case (DepotLogicGondolaST._SAVESTOCK): SUP33.SaveListProduct(ref dt); break;
                    case (DepotLogicGondolaST._MENSAGE03): SUP33.Mensage03(ref dt); break;
                }
            }
        }
    }
}
