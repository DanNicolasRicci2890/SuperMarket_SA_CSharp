using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR04
    {
        /*
            PR04: (FINALIZADO)
                Visualizacion de perfiles de usuarios.
        */
        public static void UsuarioPerfil(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveUserPerfil, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((UserPerfil)(dt.GetMState(TypeState._UserPerfil)))
                {
                    case (UserPerfil._VIEW): SUP04.Visualizacion(ref dt); break;
                    case (UserPerfil._VOLVER): SUP04.VolverMenu(ref dt); break;
                    case (UserPerfil._VERIF_CONTENIDO): SUP04.VerificarContenido(ref dt); break;
                    case (UserPerfil._MENSAGE01): SUP04.Mensage01(ref dt); break;
                    case (UserPerfil._MENSAGE02): SUP04.Mensage02(ref dt); break;
                    case (UserPerfil._MENSAGE03): SUP04.Mensage03(ref dt); break;
                    case (UserPerfil._MENSAGE04): SUP04.Mensage04(ref dt); break;
                    case (UserPerfil._SAVE_PASS): SUP04.SaveUser(ref dt); break;
                    case (UserPerfil._MENSAGE05): SUP04.Mensage05(ref dt); break;
                }
            }
        }
    }
}
