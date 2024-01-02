using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;

namespace SuperMarket_SA
{
    public class SUP00
    {
        public static void Init(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveProgram, (LiveProgram)LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._StateMain, (StateMain)StateMain._DATABASE);
        }
        public static void Exits(ref BDState dt)
        {
            dt.SetMState(TypeState._StateMain, (StateMain)StateMain._none);
            dt.SetMState(TypeState._LiveProgram, (LiveProgram)LiveProgram._INACTIVATED);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
        }
    }
}
