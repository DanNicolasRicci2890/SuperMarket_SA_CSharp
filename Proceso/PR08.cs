using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;
using PCD_CodEnigma;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;

namespace SuperMarket_SA
{
    public class PR08
    {
        /*
            PR08: (FINALIZADO)
                Realiza busqueda de usuarios existente por medio:
                        _ de LEGAJO
                        _ de DNI
                        _ de USER-ID

                para direccionar a:
                        _ Modificacion de usuarios
                        _ Ingreso al sistema a usuarios
                        _ Verificar Estado de usuario
                        _ Roles y permisos de usuarios.


        */
        public static void SysAdminBusqueda(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSysAdminSeek, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SysAdminSeek)(dt.GetMState(TypeState._SysAdminSeek)))
                {
                    case (SysAdminSeek._VERIFICAR): SUP08.VerificacionUser(ref dt); break;
                    case (SysAdminSeek._MENSAGE01): SUP08.Mensage(ref dt); break;
                    case (SysAdminSeek._PRESENTACION): SUP08.Selector(ref dt); break;
                    case (SysAdminSeek._VOLVER): SUP08.Volver(ref dt); break;
                    case (SysAdminSeek._BUSQUEDA_LEGAJO): SUP08.Busqueda(ref dt); break;
                    case (SysAdminSeek._BUSQUEDA_DNI): SUP08.Busqueda(ref dt); break;
                    case (SysAdminSeek._BUSQUEDA_USERID): SUP08.Busqueda(ref dt); break;
                    case (SysAdminSeek._NODETECT): SUP08.UsuarioInexistente(ref dt); break;
                    case (SysAdminSeek._DIRECCION): SUP08.DireccionAplicacion(ref dt); break;
                }
            }
        }
    }
}
