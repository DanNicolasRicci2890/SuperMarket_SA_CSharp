using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public enum CajeroST
    {
        _none = 0,
        _VOLVER = 1,
        _LISTER_USER = 2,
        _MENSAGE01 = 3,
        _LISTER_SUCURSAL = 4,
        _MENSAGE02 = 5,
        _LISTER_TYPE_PRODUCT = 6,
        _MENSAGE03 = 7,
        _LISTER_PRODUCT = 8,
        _MENSAGE04 = 9,
        _LISTER_STOCK = 10,
        _MENSAGE05 = 11,
        _MENUOPTION = 12,
        _VERIFSTOCK = 13,
        _MENSAGE06 = 14,
        _CAJERO = 15,
        _MENSAGE07 = 16,
        _MENSAGE08 = 17,
        _MENSAGE09 = 18,
        _MENSAGE10 = 19,
        _CAJERO_QUITAR = 20,
        _MENSAGE11 = 21,
        _CAJERO_FINALY = 22,
        _ABONAR = 23,
        _MENSAGE12 = 24,
        _MENSAGE13 = 25,
        _PROCESO_PAGO = 26,
        _MENSAGE14 = 27,
    }
    public enum DepotLogicRemoveST
    {
        _none = 0,
        _LISTER_SUCURSAL = 1,
        _VOLVER = 2,
        _VERIF_PRODUCTO = 3,
        _LISTER_PRODUCTO = 4,
        _SELECT_PRODUCTO = 5,
        _MENSAGE01 = 6,
        _REMOVE = 7,
        _MENSAGE02 = 8,
    }
    public enum DepotLogicGondolaST
    {
        _none = 0,
        _LISTER_SUCURSAL = 1,
        _VOLVER = 2,
        _VERIF_PRODUCTO = 3,
        _LISTER_PRODUCTO = 4,
        _SELECT_PRODUCTO = 5,
        _MENSAGE01 = 6,
        _MENSAGE02 = 7,
        _SAVESTOCK = 8,
        _MENSAGE03 = 9,
    }
    public enum DepotLogicLogisticaST
    {
        _none = 0,
        _LISTER = 1,
        _VOLVER = 2,
        _SECTION = 3,
        _DEPOS = 4,
        _MENSAGE01 = 5,
        _MENSAGE02 = 6,
        _DEPOSITO = 7,
        _MENSAGE03 = 8,
    }
    public enum DepotLogicST
    {
        _none = 0,
        _VOLVER = 1,
        _VERIF_TIPOPRODUCTO = 2,
        _MENSAGE01 = 3,
        _VERIF_PRODUCTO = 4,
        _MENSAGE02 = 5,
        _VERIF_SUCURSALES = 6,
        _MENSAGE03 = 7,
        _VERIF_STOCK = 8,
        _MENSAGE04 = 9,
        _MENUOPTION = 10,
        _LOGISTICA = 11,
        _GONDOLAS = 12,
        _REMOVE = 13,
    }
    public enum ContaduriaGanancia
    {
        _none = 0,
        _VIEW = 1,
        _MENSAGE01 = 2,
        _VOLVER = 3,
        _REMOVE = 4,
        _MENSAGE02 = 5,
    }
    public enum ContaduriaDolarPesos
    {
        _none = 0,
        _CONFIG = 1,
        _VOLVER = 2,
        _MENSAGE_ERROR = 3,
        _SAVE = 4,
        _MENSAGE = 5,
    }
    public enum ContaduriaStockST
    {
        _none = 0,
        _VERIF_STOCK = 1,
        _MENSAGE01 = 2,
        _LISTER = 3,
        _VOLVER = 4,
        _QUESTION = 5,
        _REMOVE = 6,
        _MENSAGE02 = 7,
    }
    public enum ContaduriaCompraST
    {
        _none = 0, 
        _TIPO_PRODUCT = 1,
        _VOLVER = 2,
        _VERIF_TIPO_PRODUCT = 3,
        _MENSAGE01 = 4,
        _PRODUCT = 5,
        _INCREMENT_PRODUCT = 6,
        _MENSAGE02 = 7,
        _SAVE_PRODUCT = 8,
        _MENSAGE03 = 9,
    }
    public enum ContaduriaST
    {
        _none = 0,
        _VERIF_USER = 1,
        _MENSAGE01 = 2,
        _VERIF_SUCURSAL = 3,
        _MENSAGE02 = 4,
        _VERIF_PRODUCT = 5,
        _MENSAGE03 = 6,
        _MENUOPTION = 7,
        _VOLVER = 8,
        _COMPRAR_PRODUCT = 9,
        _STOCK_CENTRAL = 10,
        _CONFIG_DOLARPESO = 11,
        _GANANCIA = 12,
    }

    public enum ProductosListST
    {
        _none = 0,
        _VERIF = 1,
        _MENSAGE1 = 2,
        _VOLVER = 3,
        _SEEK_LISTER = 4,
        _VERIF_LISTER = 5,
        _MENSAGE2 = 6,
        _LISTER_PRODUCT = 7,
        _ADD_PRODUCT = 8,
        _MODIF_PRODUCT = 9, 
        _REMOVE_PRODUCT = 10,   
    }
    public enum ProductosSeekST
    {
        _none = 0,
        _SEEK_CODE = 1,
        _MENSAGE1 = 2,
        _MENSAGE2 = 3,
        _DIRECTOR = 4,
    }
    public enum ProductosAddST
    {
        _none = 0,
        _VERIF_TP = 1,
        _MENSAGE1 = 2,
        _VOLVER = 3,
        _ADD_PRODUCT = 4,
        _VERIF_DATO = 5, // <--- Verifica si los datos son completos.
        _MENSAGE2 = 6,   // <--- mensaje de error de precio.
        _MENSAGE3 = 7,   // <--- mensaje de faltante de codigo de producto.
        _MENSAGE4 = 8,   // <--- mensaje de faltante de marca del producto.
        _MENSAGE5 = 9,   // <--- mensaje de faltante de nombre del producto.
        _MENSAGE6 = 10,  // <--- mensaje de faltante de tipo de cantidad.
        _MENSAGE7 = 11,  // <--- mensaje de faltante de cantidad de venta.
        _MENSAGE8 = 12,  // <--- mensaje de faltante de precio.
        _VERIF_CODIGO = 13, // <--- 
        _SAVE_ADD = 14,  // guardar el dato ingresado
        _MENSAGE9 = 15,
        _MODIF_ADD = 16,
        _MENSAGE10 = 17,
    }
    public enum ProductosRemoveTypeST
    {
        _none = 0,
        _VERIF = 1,
        _MENSAGE1 = 2,
        _NOMTP = 3,
        _VOLVER = 4,
        _VERIF_NOM = 5,
        _MENSAGE2 = 6,
        _VIEW_TP = 7,
        _REMOVE_TP = 8,
        _REMOVE_TP2 = 9,
        _MENSAGE3 = 10,
        _MENSAGE4 = 11,
    }
    public enum ProductosAddTypeST
    {
        _none = 0,
        _PRESENT = 1,
        _IN_DATA = 2,   
        _VOLVER = 3,
        _VERIF_CONT = 4,
        _MENSAGE1 = 5,
        _MENSAGE2 = 6,
        _VERIF_NOM = 7,
        _MENSAGE3 = 8,
        _VERIF_COD = 9,
        _MENSAGE4 = 10,
        _SAVE_TYPEPROD = 11,
        _SAVE_FILETP = 12,
        _MENSAGE5 = 13        
    }
    public enum ProductosListTypeST
    {
        _none = 0,
        _VERIF = 1,
        _MENSAGE1 = 2,
        _LISTER = 3,
        _VOLVER = 4,
        _ADD = 5,
        _VISUAL = 6,
        _REMOVE = 7,
    }
    public enum ProductosST
    {
        _none = 0,
        _MENUOPTION = 1,
        _VOLVER = 2,
        _LIST_TYPEPRODUCT = 3,
        _ADD_TYPEPRODUCT = 4,
        _REMOVE_TYPEPRODUCT = 5,
        _ADD_PRODUCT = 6,
        _MODIF_PRODUCT = 7,
        _REMOVE_PRODUCT = 8,
        _LIST_PRODUCT = 9,
    }
    public enum SucursalVisual
    {
        _none = 0,
        _VISUAL = 1,
        _MENU = 2,
        _MODIF = 3,
        _REMOVE = 4,
        _VOLVER = 5,
    }
    public enum SucursalRemove
    {
        _none = 0,
        _REMOVE = 1,
        _MENSAGE01 = 2,
        _VOLVER = 3,
        _ELIMINAR_SUCURSAL = 4,
        _ELIMINAR_SUCURSAL2 = 5,
        _MENSAGE02 = 6,
    }
    public enum SucursalModif
    {
        _none = 0,
        _MODIF = 1,
        _VOLVER = 2,
        _VERIF_DATOS = 3,
        _MENSAGE01 = 4, // <--- Direccion de la sucursal incompleto
        _MENSAGE02 = 5, // <--- Numero de la sucursal incompleto
        _MENSAGE03 = 6, // <--- Codigo Postal de la sucursal incompleto
        _MENSAGE04 = 7, // <--- Provincia de la sucursal incompleto
        _MENSAGE05 = 8, // <--- Localidad de la sucursal incompleto
        _MENSAGE06 = 9, // <--- Pais de la sucursal incompleto
        _SAVE_SUCURSAL = 10, // guardar la sucursal creada.
        _MODIF_SUCURSAL = 11, // Modifica el archivo de la sucursal.
        _MENSAGE07 = 12, //<--- indica que la sucursal ha sido guardada

    }
    public enum SucursalesSeek
    {
        _none = 0,
        _VERIF_SUCUR = 1, // verifica si hay sucursales.
        _MENSAGE01 = 2, // en caso que no hay emite un mensaje y vuelve al menu de sucursales
        _SEEK_SUCURSAL = 3, // en caso que tenga sucursales procede a la busqueda 
                            // de la sucursal a trabajar.
        _MENSAGE02 = 4,  // en caso que la sucursal no exista emite un mensaje y vuelve al 
                         // menu de sucursales.
        _CALIFICAR = 5,  // en caso que la busqueda sea exitosa, calificar si es: Visualizar, Modificar o Eliminar
        _VISUALIZAR = 6,
        _MODIFICAR = 7,
        _ELIMINAR = 8,
    }
    public enum SucursalesAddST
    {
        _none = 0,
        _ADD = 1,
        _VOLVER = 2,
        _VERIF_DATOS = 3,
        _MENSAGE01 = 4, // <--- nombre de la sucursal incompleto
        _MENSAGE02 = 5, // <--- Codigo de la sucursal incompleto
        _MENSAGE03 = 6, // <--- Direccion de la sucursal incompleto
        _MENSAGE04 = 7, // <--- Numero de la sucursal incompleto
        _MENSAGE05 = 8, // <--- Codigo Postal de la sucursal incompleto
        _MENSAGE06 = 9, // <--- Provincia de la sucursal incompleto
        _MENSAGE07 = 10, // <--- Localidad de la sucursal incompleto
        _MENSAGE08 = 11, // <--- Pais de la sucursal incompleto
        _VERIF_NOMB = 12,
        _MENSAGE09 = 13, //<--- indica que el nombre ya existe
        _VERIF_CODE = 14,
        _MENSAGE10 = 15, //<--- indica que el codigo ya existe
        _SAVE_SUCURSAL = 16, // guardar la sucursal creada.
        _CREATE_SUCURSAL = 17, // crea el archivo de la sucursal.
        _MENSAGE11 = 18, //<--- indica que la sucursal ha sido guardada
    }
    public enum SucursalesListST
    {
        _none = 0,
        _VERIF_SUCURS = 1,
        _MENSAGE01 = 2,
        _LISTER = 3,
        _VOLVER = 4,
        _VISUAL = 5,
    }
    public enum SucursalesST
    {
        _none = 0,
        _MENUOPCION = 1,
        _VOLVER = 2,
        _LISTA = 3,
        _VISUALIZAR = 4,
        _AGREGAR = 5,
        _MODIFICAR = 6, 
        _ELIMINAR = 7,
    }
    public enum Administrador
    {
        _none = 0,
        _MENUOPCION = 1,
        _VOLVER = 2,
        _SUCURSALES = 3,    
        _PRODUCTOS = 4, 
    }
    public enum SysAdminRemove
    {
        _none = 0,
        _MENUOPCION = 1,
        _VOLVER = 2,
        _REMOVE = 3,
        _MENSAGE = 4,
    }
    public enum SysAdminRolesPerm
    {
        _none = 0,
        _MENUOPCION = 1,
        _VOLVER = 2,
        _PERFILES = 3,
        _PERF_SYSADMIN = 4,
        _PERF_ADMINISTRATIVO = 5,
        _PERF_CONTADURIA = 6,
        _PERF_DEPOSLOGIC = 7,
        _PERF_CAJERO = 8,
        _SAVE_ROLES = 9,
    }
    public enum SysAdminEstado
    {
        _none = 0,
        _MENUOPCION = 1,
        _VOLVER = 2,
        _CONFIG_AVANZADO = 3,
        _EXPIRACION_COUNT = 4,
        _EXPIRACION_PASSW = 5,
        _BLOQUEO_PASS = 6,
        _BLOQUEO_ACOUNT = 7,
        _RESET_PASSWORD = 8,    
        _SAVE_USER = 9,
    }
    public enum SysAdminIngreso
    {
        _none = 0,  
        _VOLVER = 1,
        _IN_USER_ID = 2,
        _MENSAGE1 = 3,
        _MENSAGE2 = 4,
        _IN_PASSWORD = 5,
        _MENSAGE3 = 6,
        _ING_USER_PASS = 7,
        _PROCESS = 8,
        _MENSAGE4 = 9,
    }
    public enum SysAdminSeek
    {
        _none = 0,
        _VERIFICAR = 1,
        _MENSAGE01 = 2,
        _PRESENTACION = 3,
        _VOLVER = 4,
        _BUSQUEDA_LEGAJO = 5,
        _BUSQUEDA_DNI = 6,
        _BUSQUEDA_USERID = 7,
        _NODETECT = 8,
        _DIRECCION = 9,
    }
    public enum SysAdminCreate 
    {
        _none = 0,
        _PRESENTACION = 1,
        _DATA_INFO = 2,
        _VOLVER = 3,
        _VERIFICACION1 = 4,
        _MENSAGE1 = 5,
        _MENSAGE2 = 6,
        _MENSAGE3 = 7,
        _MENSAGE4 = 8,
        _VERIFICACION2_1 = 9,
        _VERIFICACION2_2 = 10,
        _MENSAGE5 = 11,
        _VERIFICACION3_1 = 12,
        _VERIFICACION3_2 = 13,
        _MENSAGE6 = 14,
        _SAVE1 = 15,
        _SAVE2 = 16,
        _MENSAGE7 = 17,
        _MENSAGE8 = 18,
    }
    public enum SysAdminLister
    {
        _none = 0,
        _VERIFICAR = 1,
        _MENSAGE = 2,
        _LISTADO = 3,
        _VOLVER = 4,
        _AGREGAR = 5,        
        _INGRESAR = 6,
        _MENSAGE2 = 7,
        _MODIFICAR = 8,        
        _ESTADOCUE = 9,
        _MENSAGE3 = 10,        
        _ROLYPERM = 11,
        _REMOVEUSER = 12        
    }
    public enum SysAdmin
    {
        _none = 0,
        _MENU = 1,
        _VOLVER = 2, 
        _LISTA_USER = 3, 
        _CREATE_USER = 4,   
        _INGRESO_USER = 5,
        _MODIFI_USER = 6,
        _STATE_USER = 7,
        _ROLES_PERMISOS = 8,
        _REMOVE_USER = 9,
    }
    public enum UserPerfil
    {
        _none = 0,
        _VIEW = 1,
        _VOLVER = 2,
        _VERIF_CONTENIDO = 3,
        _MENSAGE01 = 4,  // <---- falta un campo a completar
        _MENSAGE02 = 5,  // <---- La contraseña actual no es la correcta
        _MENSAGE03 = 6,  // <---- La contraseña nueva no es correcta
        _MENSAGE04 = 7,  // <---- La contraseña nuevas no son iguales.
        _SAVE_PASS = 8,
        _MENSAGE05 = 9,  // <---- la contraseña ha sido modificada.
    }
    public enum SystemUser
    {
        _none = 0,
        _PRESENTADOR = 1,
        _CERRAR_SESION = 2, 
        _PERFIL_USER = 3,
        _SYSADMIN = 4,
        _ADMINISTRADOR = 5,
        _CONTADURIA = 6,
        _CAJERO = 7,
        _DEPOSITO_LOGISTICA = 8,        
    }
    public enum LoginUser
    {
        _none = 0,
        _DISPLAY = 1,
        _PRESENT = 2,
        _LOGIN = 3,
        _SALIR = 4,
        _VERIFICAR = 5,
        _USER_INEXIT = 6,
        _USER_INHABILITARY = 7,
        _USER_EXPIRATED = 8,
        _USER_EXPIRATED_PASS = 9,
        _USER_BLOCKED = 10,
        _USER_BLOCKED_PASS = 11,
        _ACCESS_DENEGATED = 12,
        _ACCESS_ACEPTADED = 13,
        _PASS = 14 
    }
    public enum VerificInicio
    {
        _none = 0,
        _READ01 = 1, //verifica existencia de base de datos de "USUARIOS"
        _BORN01 = 2, //crea el archivo "ListUserProgram.dat"
        _READ02 = 3  //verificar si existe el archivo "List 
    }
    public enum StateMain
    {
        _none = 0,
        _DATABASE = 1,
        _LOGIN_USER_PASS = 2,
        _SALIDA = 3,
        _SYSTEM_USER = 4, 
        _USER_PERFIL = 5,
        _SYSADMIN = 6,
        _SYSADMIN_LISTER = 7,
        _SYSADMIN_CREATE = 8,
        _SYSADMIN_SEEK = 9,
        _SYSADMIN_INGRESO = 10,
        _SYSADMIN_STATEUSER = 11,
        _SYSADMIN_ROLESPER = 12,
        _SYSADMIN_ELIMINAR = 13,
        _ADMINISTRADOR = 14,
        _SUCURSALES = 15,
        _SUCURSALES_LISTER = 16,
        _SUCURSALES_ADD = 17,
        _SUCURSALES_SEEK = 18,
        _SUCURSALES_MODIF = 19,        
        _SUCURSALES_REMOVE = 20,
        _SUCURSALES_VISUAL = 21,
        _PRODUCTOS_ST = 22,
        _PRODUCTOS_LISTER_TYPE = 23,
        _PRODUCTOS_ADD_TYPE = 24,
        _PRODUCTOS_REMOVE_TYPE = 25,
        _PRODUCTOS_ADD = 26,
        _PRODUCTOS_SEEK = 27,
        _PRODUCTOS_LISTER = 28,
        _CONTADURIA = 29,
        _CONTADURIA_COMPRA_PROD = 30,
        _CONTADURIA_STOCK = 31,
        _CONTADURIA_DOLAR = 32,
        _CONTADURIA_GANANCIA = 33,
        _DEPOTLOGIC = 34,
        _DEPOTLOGICLOGISTICAST = 35,
        _DEPOTLOGICGONDOLAST = 36, 
        _DEPOTLOGICREMOVEST = 37,
        _CAJEROST = 38,
    }
    public enum LiveProgram
    {
        _none = 0,
        _ACTIVATED = 1,
        _INACTIVATED = 2 
    }
    public enum TypeState
    {
        _LiveProgram = 0,
        _StateMain = 1, 

        _LiveVerifcacion = 2,
        _VerificInicio = 3,

        _LiveLoginUserPass = 4,
        _LoginUserPass = 5,

        _LiveSystemUser = 6,
        _SystemUser = 7,

        _LiveUserPerfil = 8,
        _UserPerfil = 9,    

        _LiveSysAdmin = 10,
        _SysAdmin = 11,

        _LiveSysAdminLister = 12,
        _SysAdminLister = 13,

        _LiveSysAdminCreate = 14,
        _SysAdminCreate = 15,

        _LiveSysAdminSeek = 16,
        _SysAdminSeek = 17,

        _LiveSysAdminIngreso = 18,
        _SysAdminIngreso = 19,

        _LiveSysAdminEstado = 20,
        _SysAdminEstado = 21,

        _LiveSysAdminRolesPer = 22,
        _SysAdminRolesPer = 23,

        _LiveSysAdminRemove = 24,
        _SysAdminRemove = 25,

        _LiveAdministrador = 26,
        _Administrador = 27,

        _LiveSucursalST = 28,
        _SucursalST = 29,

        _LiveSucursListST = 30,
        _SucursListST = 31,

        _LiveSucursAddST = 32,
        _SucursAddST = 33,

        _LiveSucursalSeek = 34,
        _SucursalSeek = 35,

        _LiveSucursalModif = 36,
        _SucursalModif = 37,

        _LiveSucursalRemove = 38,
        _SucursalRemove = 39,

        _LiveSucursalVisual = 40,
        _SucursalVisual = 41,

        _LiveProductosST = 42,
        _ProductosST = 43,

        _LiveProductosListTypeST = 44,
        _ProductosListTypeST = 45,

        _LiveProductosAddTypeST = 46,
        _ProductosAddTypeST = 47,

        _LiveProductosRemoveTypeST = 48,
        _ProductosRemoveTypeST = 49,

        _LiveProductosAddST = 50,
        _ProductosAddST = 51,

        _LiveProductosSeekST = 52,
        _ProductosSeekST = 53,

        _LiveProductosListST = 54,
        _ProductosListST = 55,

        _LiveContaduriaST = 56,
        _ContaduriaST = 57,

        _LiveContaduriaProductST = 58,
        _ContaduriaProductST = 59,

        _LiveContaduriaStockST = 60,
        _ContaduriaStockST = 61,

        _LiveContaduriaDolarPeso = 62,
        _ContaduriaDolarPesos = 63,

        _LiveContaduriaGanancia = 64,
        _ContaduriaGanancia = 65,

        _LiveDepotLogicST = 66,
        _DepotLogicST = 67,

        _LiveDepotLogicLogisticaST = 68,
        _DepotLogicLogisticaST = 69,

        _LiveDepotLogicGondolaST = 70,
        _DepotLogicGondolaST = 71,

        _LiveDepotLogicRemoveST = 72,
        _DepotLogicRemoveST = 73,

        _LiveCajeroST = 74,
        _CajeroST = 75,
    }
    public enum Moneda
    {
        _none = 0,
        _PESOS = 1,
        _DOLARES = 2,
    }
    public class BDState
    {
        private LiveProgram _liveprogram;
        private StateMain _statemain;

        // Verificacion
        private LiveProgram _liveverificacion;
        private VerificInicio _VerificInicio;

        // Logueo de usuario/contraseña
        private LiveProgram _liveloginuserpass;
        private LoginUser _loginuser;

        private LiveProgram _livesystemuser;
        private SystemUser _systemuser;

        private LiveProgram _liveperfiluser;
        private UserPerfil _userperfil;

        private LiveProgram _livesysadmin;
        private SysAdmin _sysadmin;

        private LiveProgram _livesysadminlister;
        private SysAdminLister _sysadminlister;

        private LiveProgram _livesysadmincreate;
        private SysAdminCreate _sysadmincreate;

        private LiveProgram _livesysadminseek;
        private SysAdminSeek _sysadminseek;

        private LiveProgram _livesysadminingreso;
        private SysAdminIngreso _sysadminingreso;

        private LiveProgram _livesysadminestado;
        private SysAdminEstado _sysadminestado;
        
        private LiveProgram _livesysadminrolesperm;
        private SysAdminRolesPerm _sysadminrolesperm;

        private LiveProgram _livesysadminremove;
        private SysAdminRemove _sysadminremove;

        //---------------------------------------------------------------------------------

        private LiveProgram _liveadministrador;
        private Administrador _administrador;
        
        private LiveProgram _livesucursalst;
        private SucursalesST _sucursalst;

        private LiveProgram _livesucurslistst;
        private SucursalesListST _sucurslistst;

        private LiveProgram _livesucursaddst;
        private SucursalesAddST _sucursaddst;

        private LiveProgram _livesucursalseek;
        private SucursalesSeek _sucursalseek;

        private LiveProgram _livesucursalmodif;
        private SucursalModif _sucursalmodif;

        private LiveProgram _livesucursalremove;
        private SucursalRemove _sucursalremove;

        private LiveProgram _livesucursalvisual;
        private SucursalVisual _sucursalvisual;

        private LiveProgram _liveproductosst;
        private ProductosST _productosst;

        private LiveProgram _liveproductoslisttypest;
        private ProductosListTypeST _productoslisttypest;

        private LiveProgram _liveproductosaddtypesst;
        private ProductosAddTypeST _productosaddtypesst;

        private LiveProgram _liveproductosremovetypesst;
        private ProductosRemoveTypeST _productosremovetypesst;

        private LiveProgram _liveproductosaddst;
        private ProductosAddST _productosaddst;

        private LiveProgram _liveproductosseekst;
        private ProductosSeekST _productosseekst;

        private LiveProgram _liveproductoslistst;
        private ProductosListST _productoslistst;

        private LiveProgram _livecontaduriast;
        private ContaduriaST _contaduriast;

        private LiveProgram _livecontaduriacomprast;
        private ContaduriaCompraST _contaduriacomprast;

        private LiveProgram _livecontaduriastockst;
        private ContaduriaStockST _contaduriastockst;

        private LiveProgram _livecontaduriadolarpeso;
        private ContaduriaDolarPesos _contaduriadolarpesos;

        private LiveProgram _livecontaduriaganancia;
        private ContaduriaGanancia _contaduriaganancia;

        private LiveProgram _livedepotlogicst;
        private DepotLogicST _depotlogicst;

        private LiveProgram _livedepotlogiclogisticast;
        private DepotLogicLogisticaST _depotlogicLogisticast;

        private LiveProgram _livedepotlogicgondolast;
        private DepotLogicGondolaST _depotlogicgondolast;

        private LiveProgram _livedepotlogicremoveast;
        private DepotLogicRemoveST _depotlogicremovest;

        private LiveProgram _livecajerost;
        private CajeroST _cajerost;

        private int _CondicionSucursal;
        private int _POSITION;
        private int _WIDTH;
        private int _HEINGHT;
        private Usuario _UserSesion;
        private Usuario _UserCreate;
        private Sucursal _SucursalCreate;
        private TypeProduct _TipoProductoCreate;
        private Producto _ProductoCreate;
        private StockProduct _StockProduct;
        private int _CondProductoCreate;
        private bool _CondCreate;
        private string _usuariofuturo;
        private string _passwordfuturo;
        private float _DolarPeso;
        private float _CompraDolares;
        private float _CompraPesos;
        private List<BoxProduct> _CompraCaja;
        private Moneda _CondicionPago;
        private LiveProgram _CondicionLista;
        private PasswordData _PasswordData;
        public BDState()
        {
            this._liveprogram = LiveProgram._none;
            this._statemain = StateMain._none;

            this._liveverificacion = LiveProgram._none;
            this._VerificInicio = VerificInicio._none;

            this._liveloginuserpass = LiveProgram._none;
            this._loginuser = LoginUser._none;

            this._livesystemuser = LiveProgram._none;
            this._systemuser = SystemUser._none;

            this._liveperfiluser = LiveProgram._none;
            this._userperfil = UserPerfil._none;

            this._livesysadmin = LiveProgram._none;
            this._sysadmin = SysAdmin._none;

            this._livesysadminlister = LiveProgram._none;
            this._sysadminlister = SysAdminLister._none;

            this._livesysadmincreate = LiveProgram._none;
            this._sysadmincreate = SysAdminCreate._none;

            this._livesysadminseek = LiveProgram._none;
            this._sysadminseek = SysAdminSeek._none;

            this._livesysadminingreso = LiveProgram._none;
            this._sysadminingreso = SysAdminIngreso._none;

            this._livesysadminestado = LiveProgram._none;
            this._sysadminestado = SysAdminEstado._none;
            
            this._livesysadminrolesperm = LiveProgram._none;
            this._sysadminrolesperm = SysAdminRolesPerm._none;

            this._livesysadminremove = LiveProgram._none;
            this._sysadminremove = SysAdminRemove._none;

//-------------------------------------------------------------------------------------

            this._liveadministrador = LiveProgram._none;
            this._administrador = Administrador._none;

            this._livesucursalst = LiveProgram._none;
            this._sucursalst = SucursalesST._none;

            this._livesucurslistst = LiveProgram._none;
            this._sucurslistst = SucursalesListST._none;

            this._livesucursaddst = LiveProgram._none;
            this._sucursaddst = SucursalesAddST._none;

            this._livesucursalseek = LiveProgram._none;
            this._sucursalseek = SucursalesSeek._none;

            this._livesucursalmodif = LiveProgram._none;
            this._sucursalmodif = SucursalModif._none;

            this._livesucursalremove = LiveProgram._none;
            this._sucursalremove = SucursalRemove._none;

            this._livesucursalvisual = LiveProgram._none;
            this._sucursalvisual = SucursalVisual._none;

            this._liveproductosst = LiveProgram._none;
            this._productosst = ProductosST._none;

            this._liveproductoslisttypest = LiveProgram._none;
            this._productoslisttypest = ProductosListTypeST._none;

            this._liveproductosaddtypesst = LiveProgram._none;
            this._productosaddtypesst = ProductosAddTypeST._none;

            this._liveproductosremovetypesst = LiveProgram._none;
            this._productosremovetypesst = ProductosRemoveTypeST._none;

            this._liveproductosaddst = LiveProgram._none;
            this._productosaddst = ProductosAddST._none;

            this._liveproductosseekst = LiveProgram._none;
            this._productosseekst = ProductosSeekST._none;

            this._liveproductoslistst = LiveProgram._none;
            this._productoslistst = ProductosListST._none;

            this._livecontaduriast = LiveProgram._none;
            this._contaduriast = ContaduriaST._none;

            this._livecontaduriacomprast = LiveProgram._none;
            this._contaduriacomprast = ContaduriaCompraST._none;

            this._livecontaduriastockst = LiveProgram._none;
            this._contaduriastockst = ContaduriaStockST._none;

            this._livecontaduriadolarpeso = LiveProgram._none;
            this._contaduriadolarpesos = ContaduriaDolarPesos._none;

            this._livecontaduriaganancia = LiveProgram._none;
            this._contaduriaganancia = ContaduriaGanancia._none;

            this._livedepotlogicst = LiveProgram._none;
            this._depotlogicst = DepotLogicST._none;

            this._livedepotlogiclogisticast = LiveProgram._none;
            this._depotlogicLogisticast = DepotLogicLogisticaST._none;

            this._livedepotlogicgondolast = LiveProgram._none;
            this._depotlogicgondolast = DepotLogicGondolaST._none;

            this._livedepotlogicremoveast = LiveProgram._none;
            this._depotlogicremovest = DepotLogicRemoveST._none;

            this._livecajerost = LiveProgram._none;
            this._cajerost = CajeroST._none;

            this._CondicionSucursal = 0; // 1 visualizacion // 2 modificacion // 3 eliminacion
            this._POSITION = 0;
            this._WIDTH = 0;
            this._HEINGHT = 0;
            this._UserSesion = new Usuario();
            this._UserCreate = new Usuario();
            this._SucursalCreate = new Sucursal();
            this._TipoProductoCreate = new TypeProduct();
            this._ProductoCreate = new Producto();
            this._StockProduct = new StockProduct();
            this._CondProductoCreate = -1;
            this._CondCreate = false;
            this._usuariofuturo = "";
            this._passwordfuturo = "";

            this._DolarPeso = 0;
            this._CompraDolares = 0;
            this._CompraPesos = 0;
            this._CompraCaja = new List<BoxProduct>();
            this._CondicionPago = Moneda._none;
            this._CondicionLista = LiveProgram._none;
            this._PasswordData = new PasswordData();
        }
        public PasswordData PASSWORD_DATA
        {
            set => this._PasswordData = value;
            get => this._PasswordData;
        }
        public LiveProgram CONDICION_LISTA 
        {
            set => this._CondicionLista = value;
            get => this._CondicionLista;
        }
        public Moneda CONDICION_PAGO
        {
            set => this._CondicionPago = value;
            get => this._CondicionPago;
        }
        public List<BoxProduct> COMPRACAJA
        {
            set => this._CompraCaja = value;
            get => this._CompraCaja;
        }
        public float COMPRADOLARES
        {
            set => this._CompraDolares = value;
            get => this._CompraDolares;
        }
        public float COMPRAPESOS
        {
            set => this._CompraPesos = value;
            get => this._CompraPesos;
        }
        public float DOLARPESOS
        {
            set => this._DolarPeso = value;
            get => this._DolarPeso;
        }
        public int COND_SUCURSAL
        {
            set => this._CondicionSucursal = value;
            get => this._CondicionSucursal;
        }
        public string USER_FUTURE
        {
            set => this._usuariofuturo = value;
            get => this._usuariofuturo;
        }
        public string PASS_FUTURE
        {
            set => this._passwordfuturo = value;
            get => this._passwordfuturo;
        }
        public int POSITION
        {
            set => this._POSITION = value;
            get => this._POSITION;
        }
        public int WIDTH
        {
            set => this._WIDTH = value;
            get => this._WIDTH;
        }
        public int HEINGHT
        {
            set => this._HEINGHT = value;
            get => this._HEINGHT;
        }
        public Usuario USERSESION
        {
            set => this._UserSesion = value;
            get => this._UserSesion;
        }
        public Usuario USERCREATE
        {
            set => this._UserCreate = value;
            get => this._UserCreate;
        }
        public Sucursal SUCURSALCREATE
        {
            set => this._SucursalCreate = value;
            get => this._SucursalCreate;
        }
        public TypeProduct TIPRODUCTCREATE
        {
            set => this._TipoProductoCreate = value;
            get => this._TipoProductoCreate;
        }
        public Producto PRODUCTCREATE
        {
            set => this._ProductoCreate = value;
            get => this._ProductoCreate;
        }
        public StockProduct STOCKPRO
        {
            set => this._StockProduct = value;
            get => this._StockProduct;
        }
        public int CONDPRODUCTCREATE
        {
            set => this._CondProductoCreate = value;
            get => this._CondProductoCreate;
        }
        public bool CONDCREATE
        {
            set => this._CondCreate = value;
            get => this._CondCreate;
        }
        public object GetMState(TypeState ts)
        {
            object dato = new object();
            switch(ts)
            {
                case (TypeState._LiveProgram): dato = this._liveprogram; break;
                case (TypeState._StateMain): dato = this._statemain; break;
                case (TypeState._LiveVerifcacion): dato = this._liveverificacion; break;
                case (TypeState._VerificInicio): dato = this._VerificInicio; break;
                case (TypeState._LiveLoginUserPass): dato = this._liveverificacion; break;
                case (TypeState._LoginUserPass): dato = this._loginuser; break;
                case (TypeState._LiveSystemUser): dato = this._livesystemuser; break;
                case (TypeState._SystemUser): dato = this._systemuser; break;                    
                case (TypeState._LiveUserPerfil): dato = this._liveperfiluser; break;
                case (TypeState._UserPerfil): dato = this._userperfil; break;
                case (TypeState._LiveSysAdmin): dato = this._livesysadmin; break;
                case (TypeState._SysAdmin): dato = this._sysadmin; break;
                case (TypeState._LiveSysAdminLister): dato = this._livesysadminlister; break;
                case (TypeState._SysAdminLister): dato = this._sysadminlister; break;
                case (TypeState._LiveSysAdminCreate): dato = this._livesysadmincreate; break;
                case (TypeState._SysAdminCreate): dato = this._sysadmincreate; break;
                case (TypeState._LiveSysAdminSeek): dato = this._livesysadminseek; break;
                case (TypeState._SysAdminSeek): dato = this._sysadminseek; break;
                case (TypeState._LiveSysAdminIngreso): dato = this._livesysadminingreso; break;
                case (TypeState._SysAdminIngreso): dato = this._sysadminingreso; break;
                case (TypeState._LiveSysAdminEstado): dato = this._livesysadminestado; break;
                case (TypeState._SysAdminEstado): dato = this._sysadminestado; break;
                case (TypeState._LiveSysAdminRolesPer): dato = this._livesysadminrolesperm; break;
                case (TypeState._SysAdminRolesPer): dato = this._sysadminrolesperm; break;
                case (TypeState._LiveSysAdminRemove): dato = this._livesysadminremove; break;
                case (TypeState._SysAdminRemove): dato = this._sysadminremove; break;
                case (TypeState._LiveAdministrador): dato = this._liveadministrador; break;
                case (TypeState._Administrador): dato = this._administrador; break;
                case (TypeState._LiveSucursalST): dato = this._livesucursalst; break;
                case (TypeState._SucursalST): dato = this._sucursalst; break;
                case (TypeState._LiveSucursListST): dato = this._livesucurslistst; break;
                case (TypeState._SucursListST): dato = this._sucurslistst; break;
                case (TypeState._LiveSucursAddST): dato = this._livesucursaddst; break;
                case (TypeState._SucursAddST): dato = this._sucursaddst; break;
                case (TypeState._LiveSucursalSeek): dato = this._livesucursalseek; break;
                case (TypeState._SucursalSeek): dato = this._sucursalseek; break;
                case (TypeState._LiveSucursalModif): dato = this._livesucursalmodif; break;
                case (TypeState._SucursalModif): dato = this._sucursalmodif; break;
                case (TypeState._LiveSucursalRemove): dato = this._livesucursalremove; break;
                case (TypeState._SucursalRemove): dato = this._sucursalremove; break;
                case (TypeState._LiveSucursalVisual): dato = this._livesucursalvisual; break;
                case (TypeState._SucursalVisual): dato = this._sucursalvisual; break;
                case (TypeState._LiveProductosST): dato = this._liveproductosst; break;
                case (TypeState._ProductosST): dato = this._productosst; break;
                case (TypeState._LiveProductosListTypeST): dato = this._liveproductoslisttypest; break;
                case (TypeState._ProductosListTypeST): dato = this._productoslisttypest; break;
                case (TypeState._LiveProductosAddTypeST): dato = this._liveproductosaddtypesst; break;
                case (TypeState._ProductosAddTypeST): dato = this._productosaddtypesst; break;
                case (TypeState._LiveProductosRemoveTypeST): dato = this._liveproductosremovetypesst; break;
                case (TypeState._ProductosRemoveTypeST): dato = this._productosremovetypesst; break;
                case (TypeState._LiveProductosAddST): dato = this._liveproductosaddst; break;
                case (TypeState._ProductosAddST): dato = this._productosaddst; break;
                case (TypeState._LiveProductosSeekST): dato = this._liveproductosseekst; break;
                case (TypeState._ProductosSeekST): dato = this._productosseekst; break;
                case (TypeState._LiveProductosListST): dato = this._liveproductoslistst; break;
                case (TypeState._ProductosListST): dato = this._productoslistst; break;
                case (TypeState._LiveContaduriaST): dato = this._livecontaduriast; break;
                case (TypeState._ContaduriaST): dato = this._contaduriast; break;
                case (TypeState._LiveContaduriaProductST): dato = this._livecontaduriacomprast; break;
                case (TypeState._ContaduriaProductST): dato = this._contaduriacomprast; break;
                case (TypeState._LiveContaduriaStockST): dato = this._livecontaduriastockst; break;
                case (TypeState._ContaduriaStockST): dato = this._contaduriastockst; break;
                case (TypeState._LiveContaduriaDolarPeso): dato = this._livecontaduriadolarpeso; break;
                case (TypeState._ContaduriaDolarPesos): dato = this._contaduriadolarpesos; break;
                case (TypeState._LiveContaduriaGanancia): dato = this._livecontaduriaganancia; break;
                case (TypeState._ContaduriaGanancia): dato = this._contaduriaganancia; break;
                case (TypeState._LiveDepotLogicST): dato = this._livedepotlogicst; break;
                case (TypeState._DepotLogicST): dato = this._depotlogicst; break;
                case (TypeState._LiveDepotLogicLogisticaST): dato = this._livedepotlogiclogisticast; break;
                case (TypeState._DepotLogicLogisticaST): dato = this._depotlogicLogisticast; break;
                case (TypeState._LiveDepotLogicGondolaST): dato = this._livedepotlogicgondolast; break;
                case (TypeState._DepotLogicGondolaST): dato = this._depotlogicgondolast; break;
                case (TypeState._LiveDepotLogicRemoveST): dato = this._livedepotlogicremoveast; break;
                case (TypeState._DepotLogicRemoveST): dato = this._depotlogicremovest; break;
                case (TypeState._LiveCajeroST): dato = this._livecajerost; break;
                case (TypeState._CajeroST): dato = this._cajerost; break;
            }
            return (dato);                   
        }
        public void SetMState(TypeState ts, object st)
        {
            switch (ts)
            {
                case (TypeState._LiveProgram): this._liveprogram = (LiveProgram)st; break;
                case (TypeState._StateMain): this._statemain = (StateMain)st; break;
                case (TypeState._LiveVerifcacion): this._liveverificacion = (LiveProgram)st; break;
                case (TypeState._VerificInicio): this._VerificInicio = (VerificInicio)st; break;
                case (TypeState._LiveLoginUserPass): this._liveloginuserpass = (LiveProgram)st; break;
                case (TypeState._LoginUserPass): this._loginuser = (LoginUser)st; break;
                case (TypeState._LiveSystemUser): this._livesystemuser = (LiveProgram)st; break;
                case (TypeState._SystemUser): this._systemuser = (SystemUser)st; break;
                case (TypeState._LiveUserPerfil): this._liveperfiluser = (LiveProgram)st; break;
                case (TypeState._UserPerfil): this._userperfil = (UserPerfil)st; break;
                case (TypeState._LiveSysAdmin): this._livesysadmin = (LiveProgram)st; break;
                case (TypeState._SysAdmin): this._sysadmin = (SysAdmin)st; break;
                case (TypeState._LiveSysAdminLister): this._livesysadminlister = (LiveProgram)st; break;
                case (TypeState._SysAdminLister): this._sysadminlister = (SysAdminLister)st; break;
                case (TypeState._LiveSysAdminCreate): this._livesysadmincreate = (LiveProgram)st; break;
                case (TypeState._SysAdminCreate): this._sysadmincreate = (SysAdminCreate)st; break;
                case (TypeState._LiveSysAdminSeek): this._livesysadminseek = (LiveProgram)st; break;
                case (TypeState._SysAdminSeek): this._sysadminseek = (SysAdminSeek)st; break;
                case (TypeState._LiveSysAdminIngreso): this._livesysadminingreso = (LiveProgram)st; break;
                case (TypeState._SysAdminIngreso): this._sysadminingreso = (SysAdminIngreso)st; break;
                case (TypeState._LiveSysAdminEstado): this._livesysadminestado = (LiveProgram)st; break;
                case (TypeState._SysAdminEstado): this._sysadminestado = (SysAdminEstado)st; break;
                case (TypeState._LiveSysAdminRolesPer): this._livesysadminrolesperm = (LiveProgram)st; break;
                case (TypeState._SysAdminRolesPer): this._sysadminrolesperm = (SysAdminRolesPerm)st; break;
                case (TypeState._LiveSysAdminRemove): this._livesysadminremove = (LiveProgram)st; break;
                case (TypeState._SysAdminRemove): this._sysadminremove = (SysAdminRemove)st; break;
                case (TypeState._LiveAdministrador): this._liveadministrador = (LiveProgram)st; break;
                case (TypeState._Administrador): this._administrador = (Administrador)st; break;
                case (TypeState._LiveSucursalST): this._livesucursalst = (LiveProgram)st; break;
                case (TypeState._SucursalST): this._sucursalst = (SucursalesST)st; break;
                case (TypeState._LiveSucursListST): this._livesucurslistst = (LiveProgram)st; break;
                case (TypeState._SucursListST): this._sucurslistst = (SucursalesListST)st; break;
                case (TypeState._LiveSucursAddST): this._livesucursaddst = (LiveProgram)st; break;
                case (TypeState._SucursAddST): this._sucursaddst = (SucursalesAddST)st; break;
                case (TypeState._LiveSucursalSeek): this._livesucursalseek = (LiveProgram)st; break;
                case (TypeState._SucursalSeek): this._sucursalseek = (SucursalesSeek)st; break;
                case (TypeState._LiveSucursalModif): this._livesucursalmodif = (LiveProgram)st; break;
                case (TypeState._SucursalModif): this._sucursalmodif = (SucursalModif)st; break;
                case (TypeState._LiveSucursalRemove): this._livesucursalremove = (LiveProgram)st; break;
                case (TypeState._SucursalRemove): this._sucursalremove = (SucursalRemove)st; break;
                case (TypeState._LiveSucursalVisual): this._livesucursalvisual = (LiveProgram)st; break;
                case (TypeState._SucursalVisual): this._sucursalvisual = (SucursalVisual)st; break;
                case (TypeState._LiveProductosST): this._liveproductosst = (LiveProgram)st; break;
                case (TypeState._ProductosST): this._productosst = (ProductosST)st; break;
                case (TypeState._LiveProductosListTypeST): this._liveproductoslisttypest = (LiveProgram)st; break;
                case (TypeState._ProductosListTypeST): this._productoslisttypest = (ProductosListTypeST)st; break;
                case (TypeState._LiveProductosAddTypeST): this._liveproductosaddtypesst = (LiveProgram)st; break;
                case (TypeState._ProductosAddTypeST): this._productosaddtypesst = (ProductosAddTypeST)st; break;
                case (TypeState._LiveProductosRemoveTypeST): this._liveproductosremovetypesst = (LiveProgram)st; break;
                case (TypeState._ProductosRemoveTypeST): this._productosremovetypesst = (ProductosRemoveTypeST)st; break;
                case (TypeState._LiveProductosAddST): this._liveproductosaddst = (LiveProgram)st; break;
                case (TypeState._ProductosAddST): this._productosaddst = (ProductosAddST)st; break;
                case (TypeState._LiveProductosSeekST): this._liveproductosseekst = (LiveProgram)st; break;
                case (TypeState._ProductosSeekST): this._productosseekst = (ProductosSeekST)st; break;
                case (TypeState._LiveProductosListST): this._liveproductoslistst = (LiveProgram)st; break;
                case (TypeState._ProductosListST): this._productoslistst = (ProductosListST)st; break;
                case (TypeState._LiveContaduriaST): this._livecontaduriast = (LiveProgram)st; break;
                case (TypeState._ContaduriaST): this._contaduriast = (ContaduriaST)st; break;
                case (TypeState._LiveContaduriaProductST): this._livecontaduriacomprast = (LiveProgram)st; break;
                case (TypeState._ContaduriaProductST): this._contaduriacomprast = (ContaduriaCompraST)st; break;
                case (TypeState._LiveContaduriaStockST): this._livecontaduriastockst = (LiveProgram)st; break;
                case (TypeState._ContaduriaStockST): this._contaduriastockst = (ContaduriaStockST)st; break;
                case (TypeState._LiveContaduriaDolarPeso): this._livecontaduriadolarpeso = (LiveProgram)st; break;
                case (TypeState._ContaduriaDolarPesos): this._contaduriadolarpesos = (ContaduriaDolarPesos)st; break;
                case (TypeState._LiveContaduriaGanancia): this._livecontaduriaganancia = (LiveProgram)st; break;
                case (TypeState._ContaduriaGanancia): this._contaduriaganancia = (ContaduriaGanancia)st; break;
                case (TypeState._LiveDepotLogicST): this._livedepotlogicst = (LiveProgram)st; break;
                case (TypeState._DepotLogicST): this._depotlogicst = (DepotLogicST)st; break;
                case (TypeState._LiveDepotLogicLogisticaST): this._livedepotlogiclogisticast = (LiveProgram)st; break;
                case (TypeState._DepotLogicLogisticaST): this._depotlogicLogisticast = (DepotLogicLogisticaST)st; break;
                case (TypeState._LiveDepotLogicGondolaST): this._livedepotlogicgondolast = (LiveProgram)st; break;
                case (TypeState._DepotLogicGondolaST): this._depotlogicgondolast = (DepotLogicGondolaST)st; break;
                case (TypeState._LiveDepotLogicRemoveST): this._livedepotlogicremoveast = (LiveProgram)st; break;
                case (TypeState._DepotLogicRemoveST): this._depotlogicremovest = (DepotLogicRemoveST)st; break;
                case (TypeState._LiveCajeroST): this._livecajerost = (LiveProgram)st; break;
                case (TypeState._CajeroST): this._cajerost = (CajeroST)st; break;
            }
        }
        public bool EqualsMState(TypeState ts, object st)
        {
            bool valor = false;

            switch (ts)
            {
                case (TypeState._LiveProgram): valor = (this._liveprogram == (LiveProgram)st); break;
                case (TypeState._StateMain): valor = (this._statemain == (StateMain)st); break;
                case (TypeState._LiveVerifcacion): valor = (this._liveverificacion == (LiveProgram)st); break;
                case (TypeState._VerificInicio): valor = (this._VerificInicio == (VerificInicio)st); break;
                case (TypeState._LiveLoginUserPass): valor = (this._liveloginuserpass == (LiveProgram)st); break;
                case (TypeState._LoginUserPass): valor = (this._loginuser == (LoginUser)st); break;
                case (TypeState._LiveSystemUser): valor = (this._livesystemuser == (LiveProgram)st); break;
                case (TypeState._SystemUser): valor = (this._systemuser == (SystemUser)st); break;
                case (TypeState._LiveUserPerfil): valor = (this._liveperfiluser == (LiveProgram)st); break;
                case (TypeState._UserPerfil): valor = (this._userperfil == (UserPerfil)st); break;
                case (TypeState._LiveSysAdmin): valor = (this._livesysadmin == (LiveProgram)st); break;
                case (TypeState._SysAdmin): valor = (this._sysadmin == (SysAdmin)st); break;
                case (TypeState._LiveSysAdminLister): valor = (this._livesysadminlister == (LiveProgram)st); break;
                case (TypeState._SysAdminLister): valor = (this._sysadminlister == (SysAdminLister)st); break;
                case (TypeState._LiveSysAdminCreate): valor = (this._livesysadmincreate == (LiveProgram)st); break;
                case (TypeState._SysAdminCreate): valor = (this._sysadmincreate == (SysAdminCreate)st); break;
                case (TypeState._LiveSysAdminSeek): valor = (this._livesysadminseek == (LiveProgram)st); break;
                case (TypeState._SysAdminSeek): valor = (this._sysadminseek == (SysAdminSeek)st); break;
                case (TypeState._LiveSysAdminIngreso): valor = (this._livesysadminingreso == (LiveProgram)st); break;
                case (TypeState._SysAdminIngreso): valor = (this._sysadminingreso == (SysAdminIngreso)st); break;
                case (TypeState._LiveSysAdminEstado): valor = (this._livesysadminestado == (LiveProgram)st); break;
                case (TypeState._SysAdminEstado): valor = (this._sysadminestado == (SysAdminEstado)st); break;
                case (TypeState._LiveSysAdminRolesPer): valor = (this._livesysadminrolesperm == (LiveProgram)st); break;
                case (TypeState._SysAdminRolesPer): valor = (this._sysadminrolesperm == (SysAdminRolesPerm)st); break;
                case (TypeState._LiveSysAdminRemove): valor = (this._livesysadminremove == (LiveProgram)st); break;
                case (TypeState._SysAdminRemove): valor = (this._sysadminremove == (SysAdminRemove)st); break;
                case (TypeState._LiveAdministrador): valor = (this._liveadministrador == (LiveProgram)st); break;
                case (TypeState._Administrador): valor = (this._administrador == (Administrador)st); break;
                case (TypeState._LiveSucursalST): valor = (this._livesucursalst == (LiveProgram)st); break;
                case (TypeState._SucursalST): valor = (this._sucursalst == (SucursalesST)st); break;
                case (TypeState._LiveSucursListST): valor = (this._livesucurslistst == (LiveProgram)st); break;
                case (TypeState._SucursListST): valor = (this._sucurslistst == (SucursalesListST)st); break;
                case (TypeState._LiveSucursAddST): valor = (this._livesucursaddst == (LiveProgram)st); break;
                case (TypeState._SucursAddST): valor = (this._sucursaddst == (SucursalesAddST)st); break;
                case (TypeState._LiveSucursalSeek): valor = (this._livesucursalseek == (LiveProgram)st); break;
                case (TypeState._SucursalSeek): valor = (this._sucursalseek == (SucursalesSeek)st); break;
                case (TypeState._LiveSucursalModif): valor = (this._livesucursalmodif == (LiveProgram)st); break;
                case (TypeState._SucursalModif): valor = (this._sucursalmodif == (SucursalModif)st); break;
                case (TypeState._LiveSucursalRemove): valor = (this._livesucursalremove == (LiveProgram)st); break;
                case (TypeState._SucursalRemove): valor = (this._sucursalremove == (SucursalRemove)st); break;
                case (TypeState._LiveSucursalVisual): valor = (this._livesucursalvisual == (LiveProgram)st); break;
                case (TypeState._SucursalVisual): valor = (this._sucursalvisual == (SucursalVisual)st); break;
                case (TypeState._LiveProductosST): valor = (this._liveproductosst == (LiveProgram)st); break;
                case (TypeState._ProductosST): valor = (this._productosst == (ProductosST)st); break;
                case (TypeState._LiveProductosListTypeST): valor = (this._liveproductoslisttypest == (LiveProgram)st); break;
                case (TypeState._ProductosListTypeST): valor = (this._productoslisttypest == (ProductosListTypeST)st); break;
                case (TypeState._LiveProductosAddTypeST): valor = (this._liveproductosaddtypesst == (LiveProgram)st); break;
                case (TypeState._ProductosAddTypeST): valor = (this._productosaddtypesst == (ProductosAddTypeST)st); break;
                case (TypeState._LiveProductosRemoveTypeST): valor = (this._liveproductosremovetypesst == (LiveProgram)st); break;
                case (TypeState._ProductosRemoveTypeST): valor = (this._productosremovetypesst == (ProductosRemoveTypeST)st); break;
                case (TypeState._LiveProductosAddST): valor = (this._liveproductosaddst == (LiveProgram)st); break;
                case (TypeState._ProductosAddST): valor = (this._productosaddst == (ProductosAddST)st); break;
                case (TypeState._LiveProductosSeekST): valor = (this._liveproductosseekst == (LiveProgram)st); break;
                case (TypeState._ProductosSeekST): valor = (this._productosseekst == (ProductosSeekST)st); break;
                case (TypeState._LiveProductosListST): valor = (this._liveproductoslistst == (LiveProgram)st); break;
                case (TypeState._ProductosListST): valor = (this._productoslistst == (ProductosListST)st); break;
                case (TypeState._LiveContaduriaST): valor = (this._livecontaduriast == (LiveProgram)st); break;
                case (TypeState._ContaduriaST): valor = (this._contaduriast == (ContaduriaST)st); break;
                case (TypeState._LiveContaduriaProductST): valor = (this._livecontaduriacomprast == (LiveProgram)st); break;
                case (TypeState._ContaduriaProductST): valor = (this._contaduriacomprast == (ContaduriaCompraST)st); break;
                case (TypeState._LiveContaduriaStockST): valor = (this._livecontaduriastockst == (LiveProgram)st); break;
                case (TypeState._ContaduriaStockST): valor = (this._contaduriastockst == (ContaduriaStockST)st); break;
                case (TypeState._LiveContaduriaDolarPeso): valor = (this._livecontaduriadolarpeso == (LiveProgram)st); break;
                case (TypeState._ContaduriaDolarPesos): valor = (this._contaduriadolarpesos == (ContaduriaDolarPesos)st); break;
                case (TypeState._LiveContaduriaGanancia): valor = (this._livecontaduriaganancia == (LiveProgram)st); break;
                case (TypeState._ContaduriaGanancia): valor = (this._contaduriaganancia == (ContaduriaGanancia)st); break;
                case (TypeState._LiveDepotLogicST): valor = (this._livedepotlogicst == (LiveProgram)st); break;
                case (TypeState._DepotLogicST): valor = (this._depotlogicst == (DepotLogicST)st); break;
                case (TypeState._LiveDepotLogicLogisticaST): valor = (this._livedepotlogiclogisticast == (LiveProgram)st); break;
                case (TypeState._DepotLogicLogisticaST): valor = (this._depotlogicLogisticast == (DepotLogicLogisticaST)st); break;
                case (TypeState._LiveDepotLogicGondolaST): valor = (this._livedepotlogicgondolast == (LiveProgram)st); break;
                case (TypeState._DepotLogicGondolaST): valor = (this._depotlogicgondolast == (DepotLogicGondolaST)st); break;
                case (TypeState._LiveDepotLogicRemoveST): valor = (this._livedepotlogicremoveast == (LiveProgram)st); break;
                case (TypeState._DepotLogicRemoveST): valor = (this._depotlogicremovest == (DepotLogicRemoveST)st); break;
                case (TypeState._LiveCajeroST): valor = (this._livecajerost == (LiveProgram)st); break;
                case (TypeState._CajeroST): valor = (this._cajerost == (CajeroST)st); break;
            }  
            return (valor);
        }
    }
}