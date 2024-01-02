using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;

namespace SuperMarket_SA
{
    public class MAIN
    {
        public static void MachineState()
        {
            BDState bdstate = new BDState();
            SUP00.Init(ref bdstate);
            while (bdstate.EqualsMState(TypeState._LiveProgram, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((StateMain)(bdstate.GetMState(TypeState._StateMain)))
                {
                    case (StateMain._DATABASE): PR01.VerificarSaved(ref bdstate); break;
                    case (StateMain._LOGIN_USER_PASS): PR02.LoginUserPassword(ref bdstate); break;
                    case (StateMain._SALIDA): SUP00.Exits(ref bdstate); break;
                    case (StateMain._SYSTEM_USER): PR03.SystemUserData(ref bdstate); break;
                    case (StateMain._USER_PERFIL): PR04.UsuarioPerfil(ref bdstate); break;
                    case (StateMain._SYSADMIN): PR05.SysAdminSeg(ref bdstate); break;
                    case (StateMain._SYSADMIN_LISTER): PR06.SysAdminSegLister(ref bdstate); break;
                    case (StateMain._SYSADMIN_CREATE): PR07.SysAdminCreateModif(ref bdstate); break;
                    case (StateMain._SYSADMIN_SEEK): PR08.SysAdminBusqueda(ref bdstate); break;
                    case (StateMain._SYSADMIN_INGRESO): PR09.IngresoUsuarioSistema(ref bdstate); break;
                    case (StateMain._SYSADMIN_STATEUSER): PR10.EstadoUsuarioSistema(ref bdstate); break;
                    case (StateMain._SYSADMIN_ROLESPER): PR11.OtorgarRolesPermisosUsuario(ref bdstate); break;
                    case (StateMain._SYSADMIN_ELIMINAR): PR37.RemoveUserSysAdmin(ref bdstate); break;
                    case (StateMain._ADMINISTRADOR): PR12.PerfilAdministrador(ref bdstate); break;
                    case (StateMain._SUCURSALES): PR13.MenuSucursales(ref bdstate); break;
                    case (StateMain._SUCURSALES_LISTER): PR14.ListaSucursales(ref bdstate); break;
                    case (StateMain._SUCURSALES_ADD): PR15.IngresoSucursales(ref bdstate); break;
                    case (StateMain._SUCURSALES_SEEK): PR16.BuscarSucursales(ref bdstate); break;
                    case (StateMain._SUCURSALES_MODIF): PR17.ModificarSucursales(ref bdstate); break;
                    case (StateMain._SUCURSALES_REMOVE): PR18.EliminarSucursales(ref bdstate); break;
                    case (StateMain._SUCURSALES_VISUAL): PR19.VisualizarSucursales(ref bdstate); break;
                    case (StateMain._PRODUCTOS_ST): PR20.AdministrarProductos(ref bdstate); break;
                    case (StateMain._PRODUCTOS_LISTER_TYPE): PR21.ListTypeProduct(ref bdstate); break;
                    case (StateMain._PRODUCTOS_ADD_TYPE): PR22.AddTypeProduct(ref bdstate); break;
                    case (StateMain._PRODUCTOS_REMOVE_TYPE): PR23.RemoveTypeProductList(ref bdstate); break;
                    case (StateMain._PRODUCTOS_ADD): PR24.AgregarProductos(ref bdstate); break;
                    case (StateMain._PRODUCTOS_SEEK): PR25.BuscadorProducto(ref bdstate); break;
                    case (StateMain._PRODUCTOS_LISTER): PR26.ListerProductos(ref bdstate); break;
                    case (StateMain._CONTADURIA): PR27.Contaduria(ref bdstate); break;
                    case (StateMain._CONTADURIA_COMPRA_PROD): PR28.CompraProductoStockCentral(ref bdstate); break;
                    case (StateMain._CONTADURIA_STOCK): PR29.ContaduriaStock(ref bdstate); break;
                    case (StateMain._CONTADURIA_DOLAR): PR30.ConfiguracionDolarPesos(ref bdstate); break;
                    case (StateMain._CONTADURIA_GANANCIA): PR36.ContaduriaGain(ref bdstate); break;
                    case (StateMain._DEPOTLOGIC): PR31.DepositoyLogica(ref bdstate); break;
                    case (StateMain._DEPOTLOGICLOGISTICAST): PR32.DepositoCasaCentral(ref bdstate); break;
                    case (StateMain._DEPOTLOGICGONDOLAST): PR33.DepositoGondola(ref bdstate); break;
                    case (StateMain._DEPOTLOGICREMOVEST): PR34.DeposLogicRemove(ref bdstate); break;
                    case (StateMain._CAJEROST): PR35.PerfilCajero(ref bdstate); break;  
                }
            }            
        }
    }
}
