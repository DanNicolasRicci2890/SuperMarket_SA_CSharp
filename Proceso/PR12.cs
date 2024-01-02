using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR12
    {
        /*
                PR12: (FINALIZADO)
                    Operar como "ADMINISTRADOR":
                        _ Sucursales
                        _ Productos                        
        */
        public static void PerfilAdministrador(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveAdministrador, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((Administrador)(dt.GetMState(TypeState._Administrador)))
                {
                    case (Administrador._MENUOPCION): SUP12.MenuOpcion(ref dt); break;
                    case (Administrador._VOLVER): SUP12.Volver(ref dt); break;
                    case (Administrador._SUCURSALES): SUP12.Sucursales(ref dt); break;
                    case (Administrador._PRODUCTOS): SUP12.Productos(ref dt); break;
                }
            }
        }
    }
}
