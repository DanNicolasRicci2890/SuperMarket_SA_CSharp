using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR37
    {
        /*
                PR37: (FINALIZADO)
                    Administra la eliminacion de usuarios en la base de datos.
         */
        public static void RemoveUserSysAdmin(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSysAdminRemove, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SysAdminRemove)(dt.GetMState(TypeState._SysAdminRemove)))
                {
                    case (SysAdminRemove._MENUOPCION): SUP37.MenuOpcion(ref dt); break;
                    case (SysAdminRemove._VOLVER): SUP37.VolverMenu(ref dt); break;
                    case (SysAdminRemove._REMOVE): SUP37.RemoveUser(ref dt); break;
                    case (SysAdminRemove._MENSAGE): SUP37.MensageRemove(ref dt); break;
                }
            }
        }
    }
}
