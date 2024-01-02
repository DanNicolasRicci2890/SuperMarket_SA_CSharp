using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR34
    {
        /*
            PR34:(FINALIZADO)
                 Administras los stock para eliminar cada contenido.
        */
        public static void DeposLogicRemove(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveDepotLogicRemoveST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((DepotLogicRemoveST)(dt.GetMState(TypeState._DepotLogicRemoveST))) 
                {
                    case (DepotLogicRemoveST._LISTER_SUCURSAL): SUP34.SeccionSucursal(ref dt); break;
                    case (DepotLogicRemoveST._VOLVER): SUP34.VolverMenu(ref dt); break;
                    case (DepotLogicRemoveST._MENSAGE01): SUP34.Mensage01(ref dt); break;
                    case (DepotLogicRemoveST._VERIF_PRODUCTO): SUP34.VerifSucursal(ref dt); break;
                    case (DepotLogicRemoveST._LISTER_PRODUCTO): SUP34.SeccionProducto(ref dt); break;
                    case (DepotLogicRemoveST._SELECT_PRODUCTO): SUP34.DespositoRemove(ref dt); break;
                    case (DepotLogicRemoveST._REMOVE): SUP34.RemoveStock(ref dt); break;
                    case (DepotLogicRemoveST._MENSAGE02): SUP34.Mensage02(ref dt); break;
                }
            }
        }
    }
}
