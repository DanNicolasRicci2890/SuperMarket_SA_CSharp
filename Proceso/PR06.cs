using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR06
    {
        /*
            PR06: (FINALIZADO)
                Visualiza la lista de usuarios, que puede proceder con el
                menu de acciones en el archivo PR05.
        */
        public static void SysAdminSegLister(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveSysAdminLister, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((SysAdminLister)(dt.GetMState(TypeState._SysAdminLister))) 
                {
                    case (SysAdminLister._VERIFICAR): SUP06.VerificarListadoUsuario(ref dt); break;
                    case (SysAdminLister._MENSAGE): SUP06.Mensage(ref dt); break;
                    case (SysAdminLister._LISTADO): SUP06.ListadoUsuario(ref dt); break;
                    case (SysAdminLister._VOLVER): SUP06.VolverAlMenu(ref dt); break;
                    case (SysAdminLister._AGREGAR): SUP06.AgregarUsuario(ref dt); break;
                    case (SysAdminLister._INGRESAR): SUP06.IngresarUsuario(ref dt); break;
                    case (SysAdminLister._MENSAGE2): SUP06.Mensage02(ref dt); break;
                    case (SysAdminLister._MODIFICAR): SUP06.ModificarUser(ref dt); break;
                    case (SysAdminLister._ESTADOCUE): SUP06.EstadoUsuario(ref dt); break;
                    case (SysAdminLister._MENSAGE3): SUP06.Mensage03(ref dt); break;
                    case (SysAdminLister._ROLYPERM): SUP06.RolesYPermisos(ref dt); break;
                    case (SysAdminLister._REMOVEUSER): SUP06.RemoveUser(ref dt); break;
                }
            }
        }        
    }
}
