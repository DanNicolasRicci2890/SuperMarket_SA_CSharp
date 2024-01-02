using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    /*
            PR25: (FINALIZADO)
                Busqueda para modificacion o eliminacion de mercaderia Para ingresar al "ProductAddST".
    */
    public class PR25
    {
        public static void BuscadorProducto(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveProductosSeekST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ProductosSeekST)(dt.GetMState(TypeState._ProductosSeekST))) 
                {
                    case (ProductosSeekST._SEEK_CODE): SUP25.SeekCode(ref dt); break;
                    case (ProductosSeekST._MENSAGE1): SUP25.MensageP1(ref dt); break;
                    case (ProductosSeekST._MENSAGE2): SUP25.MensageP2(ref dt); break;
                    case (ProductosSeekST._DIRECTOR): SUP25.Director(ref dt); break;
                }
            }
        }
    }
}
