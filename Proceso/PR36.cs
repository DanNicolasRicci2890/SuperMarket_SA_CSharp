using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    /*
            PR36: (FINALIZADO)
                Lectura de ganancias.
    */
    public class PR36
    {
        public static void ContaduriaGain(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveContaduriaGanancia, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ContaduriaGanancia)(dt.GetMState(TypeState._ContaduriaGanancia))) 
                {
                    case (ContaduriaGanancia._VIEW): SUP36.ViewGain(ref dt); break;
                    case (ContaduriaGanancia._VOLVER): SUP36.VolverMenu(ref dt); break;
                }
            }
        }
        
    }
}
