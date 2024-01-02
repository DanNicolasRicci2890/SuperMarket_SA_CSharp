using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR07
    {
        /*
            PR07: (FINALIZADO)
                Crea un usuario con los atributos solicitados.
        */
        public static void SysAdminCreateModif(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSysAdminCreate, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SysAdminCreate)(dt.GetMState(TypeState._SysAdminCreate)))
                {
                    case (SysAdminCreate._PRESENTACION): SUP07.Presentador(ref dt); break;
                    case (SysAdminCreate._DATA_INFO): SUP07.DataInfoUser(ref dt); break;
                    case (SysAdminCreate._VOLVER): SUP07.Volver(ref dt); break;
                    case (SysAdminCreate._VERIFICACION1): SUP07.Verificacion1(ref dt); break;
                    case (SysAdminCreate._MENSAGE1): SUP07.MensageP1(ref dt); break;
                    case (SysAdminCreate._MENSAGE2): SUP07.MensageP2(ref dt); break;
                    case (SysAdminCreate._MENSAGE3): SUP07.MensageP3(ref dt); break;
                    case (SysAdminCreate._MENSAGE4): SUP07.MensageP4(ref dt); break;
                    case (SysAdminCreate._VERIFICACION2_1): SUP07.Verificacion2_1(ref dt); break;
                    case (SysAdminCreate._VERIFICACION2_2): SUP07.Verificacion2_2(ref dt); break;
                    case (SysAdminCreate._MENSAGE5): SUP07.MensageP5(ref dt); break;
                    case (SysAdminCreate._VERIFICACION3_1): SUP07.Verificacion3_1(ref dt); break;
                    case (SysAdminCreate._VERIFICACION3_2): SUP07.Verificacion3_2(ref dt); break;
                    case (SysAdminCreate._MENSAGE6): SUP07.MensageP6(ref dt); break;
                    case (SysAdminCreate._SAVE1): SUP07.SaveUsers1(ref dt); break;
                    case (SysAdminCreate._SAVE2): SUP07.SaveUsers2(ref dt); break;
                    case (SysAdminCreate._MENSAGE7): SUP07.MensageP7(ref dt); break;
                    case (SysAdminCreate._MENSAGE8): SUP07.MensageP8(ref dt); break;
                }
            }
        }
    }
}
