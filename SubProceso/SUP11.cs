using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PCD_CodEnigma;
using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;

namespace SuperMarket_SA
{
    public class SUP11
    {
        public static void SaveRolesPermisos(ref BDState dt)
        {
            FDUsuario opus_user = new FDUsuario("ListUserProgram");
            opus_user.LoadListUser();
            opus_user.ReplaceListUser(dt.USERCREATE, dt.POSITION);
            opus_user.BurbujaListUser();
            opus_user.SaveListUser();
            string[] mensaje = { "    L O S    R O L E S   Y   P E R M I S O S    ", "    D E L    U S U A R I O    ", "    H A N    S I D O    M O D I F I C A D O    " };
            FUNCTION.Mensagedatatime(mensaje, color.BLANCO, color.AZUL, color.AZUL, 4, 90, 20);            
            dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
        }
        public static void PerfilesCajero(ref BDState dt)
        {
            int cont_pos = 0;
            bool kscript = false;
            string tecla = "";
            FUNCTION.UsuarioPerfilado(ref dt);
            string[] select_menu = { "          Cajero          " };
            
            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.DARK_GRIS };
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] backSelect = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO };
            color[] foreSelect = { color.DARK_GRIS, color.GRIS, color.DARK_CYAN, color.DARK_ROJO, color.BLANCO, color.ROJO, color.AZUL };
            color[] backOption = { color.NEGRO, color.DARK_GRIS, color.NEGRO, color.DARK_VERDE, color.NEGRO, color.VERDE };
            color[] foreOption = { color.GRIS, color.CYAN, color.DARK_AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            IN key_data = new IN();
            IOCHECKINFO rolesperfiles_ = new IOCHECKINFO("   ROLES DE USUARIO DE CAJERO DE SUCURSAL   ", select_menu, backCorral, foreCorral, backtitulo, foretitulo, backSelect, foreSelect, backOption, foreOption, TypeLine._DOUBLE, 1, 30, 28);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER   ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 80, 30);
            rolesperfiles_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.SystemCajero));
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            if (((dt.USERCREATE.SystemRoles >> 3) & 1) == 1)
            {
                while (cont_pos != 2)
                {
                    if (cont_pos == 0)
                    {
                        btn_Volver_.SetInactivated();
                        switch (kscript)
                        {
                            case false: rolesperfiles_.SetSemiInactivated(); break;
                            case true: rolesperfiles_.SetActivated(); break;
                        }
                    }
                    if (cont_pos == 1)
                    {
                        rolesperfiles_.SetInactivated();
                        switch (kscript)
                        {
                            case false: btn_Volver_.SetSemiInactivated(); break;
                            case true: btn_Volver_.SetActivated(); break;
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (i != cont_pos)
                        {
                            switch (i)
                            {
                                case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                                case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                            }
                        }
                    }
                    switch (cont_pos)
                    {
                        case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                        case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                    }
                    if ((bool)btn_Volver_.GetDataInfo())
                    {
                        dt.USERCREATE.SystemCajero = Convert.ToInt32(rolesperfiles_.GetDataInfo());
                        dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
                        kscript = true;
                        cont_pos = 2;
                    }
                    if (!kscript)
                    {
                        tecla = key_data.InputMode();
                        if (tecla.Equals("TAB"))
                        {
                            cont_pos++;
                            if (cont_pos == 2) { cont_pos = 0; }
                        }
                        else
                        {
                            if (tecla.Equals("ENTER")) { kscript = true; }
                        }
                    }
                    else { kscript = false; }
                }
            }
            else
            {
                string[] mensaje = { "   E L   U S U A R I O   " ,
                                     "   N O   P O S E E   ",
                                     "   P E R F I L   " ,
                                     "   D E   " ,
                                     "   C A J E R O   " ,
                                     "   D E   " ,
                                     "   S U C U R S A L   " };
                FUNCTION.Mensagedata(mensaje, color.BLANCO, color.DARK_GRIS, color.AZUL, 110, 15);
                dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
            }
        }
        public static void PerfilesDepositoLogica(ref BDState dt)
        {
            int cont_pos = 0;
            bool kscript = false;
            string tecla = "";
            FUNCTION.UsuarioPerfilado(ref dt);
            string[] select_menu = { "   Logistica de Transporte   " ,
                                     "   Muestreo de Gondolas  " ,  // 2F
                                     "   Eliminar Stock de Sucursal  " };

            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.DARK_GRIS };
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] backSelect = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO };
            color[] foreSelect = { color.DARK_GRIS, color.GRIS, color.DARK_CYAN, color.DARK_ROJO, color.BLANCO, color.ROJO, color.AZUL };
            color[] backOption = { color.NEGRO, color.DARK_GRIS, color.NEGRO, color.DARK_VERDE, color.NEGRO, color.VERDE };
            color[] foreOption = { color.GRIS, color.CYAN, color.DARK_AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            IN key_data = new IN();
            IOCHECKINFO rolesperfiles_ = new IOCHECKINFO("   ROLES DE USUARIO DE DEPOSITO Y LOGISTICA   ", select_menu, backCorral, foreCorral, backtitulo, foretitulo, backSelect, foreSelect, backOption, foreOption, TypeLine._DOUBLE, 3, 8, 24);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER   ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 200, 30);
            rolesperfiles_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.SystemDepositLogic));
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            if (((dt.USERCREATE.SystemRoles >> 4) & 1) == 1)
            {
                while (cont_pos != 2)
                {
                    if (cont_pos == 0)
                    {
                        btn_Volver_.SetInactivated();
                        switch (kscript)
                        {
                            case false: rolesperfiles_.SetSemiInactivated(); break;
                            case true: rolesperfiles_.SetActivated(); break;
                        }
                    }
                    if (cont_pos == 1)
                    {
                        rolesperfiles_.SetInactivated();
                        switch (kscript)
                        {
                            case false: btn_Volver_.SetSemiInactivated(); break;
                            case true: btn_Volver_.SetActivated(); break;
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (i != cont_pos)
                        {
                            switch (i)
                            {
                                case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                                case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                            }
                        }
                    }
                    switch (cont_pos)
                    {
                        case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                        case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                    }
                    if ((bool)btn_Volver_.GetDataInfo())
                    {
                        dt.USERCREATE.SystemDepositLogic = Convert.ToInt32(rolesperfiles_.GetDataInfo());
                        dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
                        kscript = true;
                        cont_pos = 2;
                    }
                    if (!kscript)
                    {
                        tecla = key_data.InputMode();
                        if (tecla.Equals("TAB"))
                        {
                            cont_pos++;
                            if (cont_pos == 2) { cont_pos = 0; }
                        }
                        else
                        {
                            if (tecla.Equals("ENTER")) { kscript = true; }
                        }
                    }
                    else { kscript = false; }
                }
            }
            else
            {
                string[] mensaje = { "   E L   U S U A R I O   " ,
                                     "   N O   P O S E E   ",
                                     "   P E R F I L   " ,
                                     "   D E   " ,
                                     "   D E P O S I T O   " ,
                                     "   Y   " ,
                                     "   L O G I S T I C A   "};

                FUNCTION.Mensagedata(mensaje, color.BLANCO, color.DARK_GRIS, color.AZUL, 110, 15);
                dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
            }
        }
        public static void PerfilesContaduria(ref BDState dt)
        {
            int cont_pos = 0;
            bool kscript = false;
            string tecla = "";
            FUNCTION.UsuarioPerfilado(ref dt);
            string[] select_menu = { " Compra de Productos " ,
                                   " Visualizar/Eliminar Stock Central " ,
                                   " Configurar Dolar/Peso " ,
                                   " Visualizar Ganancias " ,
                                   " Borrar Items de Ganancias " , 
                                   " Borrar todos los items de ganancias "};

            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.DARK_GRIS };
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] backSelect = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO };
            color[] foreSelect = { color.DARK_GRIS, color.GRIS, color.DARK_CYAN, color.DARK_ROJO, color.BLANCO, color.ROJO, color.AZUL };
            color[] backOption = { color.NEGRO, color.DARK_GRIS, color.NEGRO, color.DARK_VERDE, color.NEGRO, color.VERDE };
            color[] foreOption = { color.GRIS, color.CYAN, color.DARK_AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            IN key_data = new IN();
            IOCHECKINFO rolesperfiles_ = new IOCHECKINFO("   ROLES DE USUARIO DE CONTADURIA   ", select_menu, backCorral, foreCorral, backtitulo, foretitulo, backSelect, foreSelect, backOption, foreOption, TypeLine._DOUBLE, 2, 8, 24);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER   ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 200, 30);
            rolesperfiles_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.SystemContaduria));
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            if (((dt.USERCREATE.SystemRoles >> 2) & 1) == 1)
            {
                while (cont_pos != 2)
                {
                    if (cont_pos == 0)
                    {
                        btn_Volver_.SetInactivated();
                        switch (kscript)
                        {
                            case false: rolesperfiles_.SetSemiInactivated(); break;
                            case true: rolesperfiles_.SetActivated(); break;
                        }
                    }
                    if (cont_pos == 1)
                    {
                        rolesperfiles_.SetInactivated();
                        switch (kscript)
                        {
                            case false: btn_Volver_.SetSemiInactivated(); break;
                            case true: btn_Volver_.SetActivated(); break;
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (i != cont_pos)
                        {
                            switch (i)
                            {
                                case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                                case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                            }
                        }
                    }
                    switch (cont_pos)
                    {
                        case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                        case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                    }
                    if ((bool)btn_Volver_.GetDataInfo())
                    {
                        dt.USERCREATE.SystemContaduria = Convert.ToInt32(rolesperfiles_.GetDataInfo());
                        dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
                        kscript = true;
                        cont_pos = 2;
                    }
                    if (!kscript)
                    {
                        tecla = key_data.InputMode();
                        if (tecla.Equals("TAB"))
                        {
                            cont_pos++;
                            if (cont_pos == 2) { cont_pos = 0; }
                        }
                        else
                        {
                            if (tecla.Equals("ENTER")) { kscript = true; }
                        }
                    }
                    else { kscript = false; }
                }
            }
            else
            {
                string[] mensaje = { "   E L   U S U A R I O   " ,
                                     "   N O   P O S E E   ",
                                     "   P E R F I L   " ,
                                     "   D E   " ,
                                     "   C O N T A D U R I A   " };

                FUNCTION.Mensagedata(mensaje, color.BLANCO, color.DARK_GRIS, color.AZUL, 110, 15);
                dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
            }
        }
        public static void PerfilesAdministrativo(ref BDState dt)
        {
            int cont_pos = 0;
            bool kscript = false;
            string tecla = "";
            FUNCTION.UsuarioPerfilado(ref dt);
            string[] select_menu = { "Visualizar Lista de Sucursales" ,
                                     "Visualizar Sucursal" ,
                                     "Crear Sucursales" ,
                                     "Modificar Sucursales" ,
                                     "Eliminar Sucursales" ,
                                     "Lista de Tipos de Productos",
                                     "Agregar Tipo de Producto",
                                     "Eliminar Tipo de Producto",
                                     "Ver Lista de un Tipo de Producto",
                                     "Agregar Productos",
                                     "Modificar Productos",
                                     "Eliminar Productos" };

            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.DARK_GRIS };
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] backSelect = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO };
            color[] foreSelect = { color.DARK_GRIS, color.GRIS, color.DARK_CYAN, color.DARK_ROJO, color.BLANCO, color.ROJO, color.AZUL };
            color[] backOption = { color.NEGRO, color.DARK_GRIS, color.NEGRO, color.DARK_VERDE, color.NEGRO, color.VERDE };
            color[] foreOption = { color.GRIS, color.CYAN, color.DARK_AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            IN key_data = new IN();
            IOCHECKINFO rolesperfiles_ = new IOCHECKINFO("   ROLES DE USUARIO ADMINISTRATIVO   ", select_menu, backCorral, foreCorral, backtitulo, foretitulo, backSelect, foreSelect, backOption, foreOption, TypeLine._DOUBLE, 5, 8, 24);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER   ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 200, 30);
            rolesperfiles_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.SystemAdministrador));
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            if (((dt.USERCREATE.SystemRoles >> 1) & 1) == 1)
            {
                while (cont_pos != 2)
                {
                    if (cont_pos == 0)
                    {
                        btn_Volver_.SetInactivated();
                        switch (kscript)
                        {
                            case false: rolesperfiles_.SetSemiInactivated(); break;
                            case true: rolesperfiles_.SetActivated(); break;
                        }
                    }
                    if (cont_pos == 1)
                    {
                        rolesperfiles_.SetInactivated();
                        switch (kscript)
                        {
                            case false: btn_Volver_.SetSemiInactivated(); break;
                            case true: btn_Volver_.SetActivated(); break;
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (i != cont_pos)
                        {
                            switch (i)
                            {
                                case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                                case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                            }
                        }
                    }
                    switch (cont_pos)
                    {
                        case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                        case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                    }
                    if ((bool)btn_Volver_.GetDataInfo())
                    {
                        dt.USERCREATE.SystemAdministrador = Convert.ToInt32(rolesperfiles_.GetDataInfo());
                        dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
                        kscript = true;
                        cont_pos = 2;
                    }
                    if (!kscript)
                    {
                        tecla = key_data.InputMode();
                        if (tecla.Equals("TAB"))
                        {
                            cont_pos++;
                            if (cont_pos == 2) { cont_pos = 0; }
                        }
                        else
                        {
                            if (tecla.Equals("ENTER")) { kscript = true; }
                        }
                    }
                    else { kscript = false; }
                }
            }
            else
            {
                string[] mensaje = { "   E L   U S U A R I O   " ,
                                     "   N O   P O S E E   ",
                                     "   P E R F I L   " ,
                                     "   D E   " ,
                                     "   A D M I N I S T R A D O R   " };

                FUNCTION.Mensagedata(mensaje, color.BLANCO, color.DARK_GRIS, color.AZUL, 110, 15);
                dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
            }
        }

        public static void PerfilesSysAdmin(ref BDState dt)
        {
            int cont_pos = 0;
            bool kscript = false;
            string tecla = "";
            FUNCTION.UsuarioPerfilado(ref dt);
            string[] select_menu = { "Perfil de Usuario" ,
                                     "Visualizar Lista" ,
                                     "Crear Usuarios" ,
                                     "Ingresar Usuarios al Sistema" ,
                                     "Modificar Usuarios" ,
                                     "Habilitar/Deshabilitar Usuarios" ,
                                     "Switch de Expiracion de Cuenta" ,
                                     "Switch de Expiracion de Contraseñas" ,                                      
                                     "Expiracion de Cuenta" , 
                                     "Expiracion de Contraseñas" ,
                                     "Desbloqueo de Contraseñas" , 
                                     "Bloqueo/Desbloqueo de Cuentas" , 
                                     "Reseteo de Contraseñas" ,
                                     "Agregar o Modificar Roles y Permisos" ,
                                     "Eliminar Usuarios" };

            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.DARK_GRIS };
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] backSelect = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO };
            color[] foreSelect = { color.DARK_GRIS, color.GRIS, color.DARK_CYAN, color.DARK_ROJO, color.BLANCO, color.ROJO, color.AZUL };
            color[] backOption = { color.NEGRO, color.DARK_GRIS, color.NEGRO, color.DARK_VERDE, color.NEGRO, color.VERDE };
            color[] foreOption = { color.GRIS, color.CYAN, color.DARK_AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            IN key_data = new IN();
            IOCHECKINFO rolesperfiles_ = new IOCHECKINFO("   ROLES DE USUARIO SYSADMIN   ", select_menu, backCorral, foreCorral, backtitulo, foretitulo, backSelect, foreSelect, backOption, foreOption, TypeLine._DOUBLE, 4, 8, 24);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER   ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 190, 30);
            rolesperfiles_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.SystemSysAdmin));
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);
            
            if (((dt.USERCREATE.SystemRoles >> 0) & 1) == 1)
            {
                while (cont_pos != 2)
                {
                    if (cont_pos == 0)
                    {
                        btn_Volver_.SetInactivated();
                        switch (kscript)
                        {
                            case false: rolesperfiles_.SetSemiInactivated(); break;
                            case true: rolesperfiles_.SetActivated(); break;
                        }
                    }
                    if (cont_pos == 1)
                    {
                        rolesperfiles_.SetInactivated();
                        switch (kscript)
                        {
                            case false: btn_Volver_.SetSemiInactivated(); break;
                            case true: btn_Volver_.SetActivated(); break;
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (i != cont_pos)
                        {
                            switch (i)
                            {
                                case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                                case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                            }
                        }
                    }
                    switch (cont_pos)
                    {
                        case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                        case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                    }
                    if ((bool)btn_Volver_.GetDataInfo())
                    {                        
                        dt.USERCREATE.SystemSysAdmin = Convert.ToInt32(rolesperfiles_.GetDataInfo());
                        dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
                        kscript = true;
                        cont_pos = 2;
                    }
                    if (!kscript)
                    {
                        tecla = key_data.InputMode();
                        if (tecla.Equals("TAB"))
                        {
                            cont_pos++;
                            if (cont_pos == 2) { cont_pos = 0; }
                        }
                        else
                        {
                            if (tecla.Equals("ENTER")) { kscript = true; }
                        }
                    }
                    else { kscript = false; }
                }
            } else
            {
                string[] mensaje = { "   E L   U S U A R I O   " , 
                                     "   N O   P O S E E   ", 
                                     "   P E R F I L   " , 
                                     "   D E   " , 
                                     "   S Y S A D M I N   " };
                
                FUNCTION.Mensagedata(mensaje, color.BLANCO, color.DARK_GRIS, color.AZUL, 110, 15);
                dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
            }                            
        }
        public static void Perfiles(ref BDState dt)
        {
            int cont_pos = 0;
            bool kscript = false;
            string tecla = "";
            FUNCTION.UsuarioPerfilado(ref dt);
            string[] select_menu = { "SysAdmin" ,
                                     "Administrativo" ,
                                     "Contaduria" ,
                                     "Sector de Caja" ,
                                     "Deposito y Logistica" };
            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.DARK_GRIS }; ;
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] backSelect = { color.NEGRO , color.NEGRO , color.NEGRO , color.NEGRO , color.NEGRO , color.NEGRO , color.BLANCO };
            color[] foreSelect = { color.DARK_GRIS , color.GRIS , color.DARK_CYAN , color.DARK_ROJO , color.BLANCO , color.ROJO , color.AZUL };
            color[] backOption = { color.NEGRO , color.DARK_GRIS , color.NEGRO , color.DARK_VERDE , color.NEGRO , color.VERDE };
            color[] foreOption = { color.GRIS, color.CYAN, color.DARK_AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            IN key_data = new IN();
            IOCHECKINFO rolesperfiles_ = new IOCHECKINFO("   PERFILES  DE  USUARIOS   ", select_menu, backCorral, foreCorral, backtitulo, foretitulo, backSelect, foreSelect, backOption, foreOption, TypeLine._DOUBLE, 3, 20, 30);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER   ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 110, 30);
            rolesperfiles_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.SystemRoles));
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            while (cont_pos != 2)
            {
                if (cont_pos == 0)
                {
                    btn_Volver_.SetInactivated();
                    switch(kscript)
                    {
                        case false: rolesperfiles_.SetSemiInactivated(); break;
                        case true: rolesperfiles_.SetActivated(); break;
                    }
                }
                if (cont_pos == 1)
                {
                    rolesperfiles_.SetInactivated();
                    switch (kscript)
                    {
                        case false: btn_Volver_.SetSemiInactivated(); break;
                        case true: btn_Volver_.SetActivated(); break;
                    }
                }
                for(int i = 0; i < 2; i++)
                {
                    if (i != cont_pos)
                    {
                        switch(i)
                        {
                            case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                            case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                        }
                    }
                }
                switch (cont_pos)
                {
                    case 0: rolesperfiles_.Display(color.NEGRO, color.NEGRO); break;
                    case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                }
                if ((bool)btn_Volver_.GetDataInfo())
                {
                    dt.USERCREATE.SystemRoles = Convert.ToInt32(rolesperfiles_.GetDataInfo());
                    dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
                    kscript = true;
                    cont_pos = 2;
                }
                if (!kscript)
                {
                    tecla = key_data.InputMode();
                    if (tecla.Equals("TAB"))
                    {
                        cont_pos++;
                        if (cont_pos == 2) { cont_pos = 0; }
                    } else 
                    {
                        if (tecla.Equals("ENTER")) { kscript = true; }
                    }
                } else { kscript = false; }
            }
        }
        public static void Volver(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSysAdminRolesPer, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._none);

            if (dt.CONDICION_LISTA == LiveProgram._ACTIVATED)
            {
                dt.SetMState(TypeState._SysAdminLister, SysAdminLister._LISTADO);
                dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_LISTER);
            }
            if (dt.CONDICION_LISTA == LiveProgram._INACTIVATED)
            {
                dt.SetMState(TypeState._SysAdmin, SysAdmin._MENU);
                dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN);
            }            
            dt.USERCREATE = new Usuario();
            dt.POSITION = -1;
            dt.CONDICION_LISTA = LiveProgram._none;
        }
        public static void MenuOpcion(ref BDState dt)
        {
            FUNCTION.UsuarioPerfilado(ref dt);

            string[] select_menu = { "Perfiles de Usuario" , 
                                     "Roles de SysAdmin" ,
                                     "Roles de Administrativo" ,
                                     "Roles de Contaduria" ,
                                     "Roles de Sector de Caja" ,
                                     "Roles de Deposito y Logistica" ,
                                     "Guardar Datos" ,
                                     "Volver al Menu" }; //128
            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };
            Console.ResetColor();
            IOMENU menuavanzado = new IOMENU("SysAdmin - Agregar y Modificar Roles y Permisos", select_menu, 4, color.NEGRO, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 10, 25);
            menuavanzado.SetDataInfo(255);
            menuavanzado.Display(color.NEGRO, color.NEGRO);
            int opcion = (int)menuavanzado.GetDataInfo();

            switch (opcion)
            {
                case 0: dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._PERFILES); break;
                case 1: dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._PERF_SYSADMIN); break;
                case 2: dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._PERF_ADMINISTRATIVO); break;
                case 3: dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._PERF_CONTADURIA); break;
                case 4: dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._PERF_CAJERO); break;
                case 5: dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._PERF_DEPOSLOGIC); break;
                case 6: dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._SAVE_ROLES); break;
                case 7: dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._VOLVER); break;         
            }
        }
    }
}
