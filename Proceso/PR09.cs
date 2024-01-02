using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR09
    {
        /*
            PR09: (FINALIZADO)
                Realiza el ingreso del usuario nuevo al sistema.
                pide el nuevo "USER-ID" con la nueva "CONTRASEÑA".
        */
        public static void IngresoUsuarioSistema(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSysAdminIngreso, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SysAdminIngreso)(dt.GetMState(TypeState._SysAdminIngreso)))
                {
                    case (SysAdminIngreso._IN_USER_ID): SUP09.UsuarioIngUser(ref dt); break;
                    case (SysAdminIngreso._MENSAGE1): SUP09.Mensage1(ref dt); break;
                    case (SysAdminIngreso._VOLVER): SUP09.Volver(ref dt); break;
                    case (SysAdminIngreso._MENSAGE2): SUP09.Mensage2(ref dt); break;
                    case (SysAdminIngreso._IN_PASSWORD): SUP09.UsuarioIngPassword(ref dt); break;
                    case (SysAdminIngreso._MENSAGE3): SUP09.Mensage3(ref dt); break;
                    case (SysAdminIngreso._PROCESS): SUP09.IngresoUSER_PASSWORD(ref dt); break;
                    case (SysAdminIngreso._ING_USER_PASS): SUP09.ProcessUserPass(ref dt); break;
                    case (SysAdminIngreso._MENSAGE4): SUP09.Mensage4(ref dt); break;                    
                }
            }
        }
    }
}
