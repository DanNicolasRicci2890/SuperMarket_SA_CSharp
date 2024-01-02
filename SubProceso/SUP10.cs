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
    public class SUP10
    {
        public static void GuardarDatosUsuario(ref BDState dt)
        {
            FDUsuario condicion = new FDUsuario("ListUserProgram");
            condicion.LoadListUser();
            condicion.ReplaceListUser(dt.USERCREATE, dt.POSITION);
            condicion.BurbujaListUser();
            condicion.SaveListUser();   
            FUNCTION.Mensagedatatime(new string[] { "    L O S    D A T O S    ", "    D E L    U S U A R I O    " , "    H A N    S I D O    M O D I F I C A D O    " }, color.BLANCO, color.AZUL, color.AZUL, 4, 90, 20);
            dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
        }
        public static void ResetPasswordAcount(ref BDState dt)
        {
            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.ROJO };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            int cont_pos = 0;
            bool kscript = false;
            string tecla = "";

            FUNCTION.UsuarioPerfilado(ref dt);
            IOdata.Selector(color.BLANCO, color.AZUL, "SysAdmin - Estado de Cuenta de Usuarios", 40, 90, 25);
            IOdata.Selector(color.BLANCO, color.MAGENTA, "   Resetar de Contraseña de Usuario    ", 40, 90, 27);

            IODATAINFO Password_ = new IODATAINFO(" Ingrese el Password ", backCorral, foreCorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 21, 20, 85, 33);
            IODATAINFO Password_2 = new IODATAINFO("  Reingrese Password ", backCorral, foreCorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 21, 20, 85, 38);
            IOBUTTON btn_Aceptar_ = new IOBUTTON("   ACEPTAR   ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 140, 33);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER    ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 140, 38);
            IN key_data = new IN();
            Password_.SetTypeDataIN(TypeDataIN._LETTER);
            Password_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Password_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Password_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);

            Password_2.SetTypeDataIN(TypeDataIN._LETTER);
            Password_2.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Password_2.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Password_2.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);

            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            while(cont_pos != 4)
            {
                if (cont_pos == 0)
                {
                    btn_Volver_.SetInactivated();
                    if (((dt.USERSESION.SystemSysAdmin >> 11) & 1) == 1)
                    {
                        switch(kscript)
                        {
                            case false: Password_.SetSemiInactivated(); break;
                            case true: Password_.SetActivated(); break;
                        }
                    }
                    else
                    {
                        Password_.SetInactivated();
                        cont_pos = 3;
                    }
                }
                if (cont_pos == 1)
                {
                    Password_.SetInactivated();
                    if (((dt.USERSESION.SystemSysAdmin >> 11) & 1) == 1)
                    {
                        switch (kscript)
                        {
                            case false: Password_2.SetSemiInactivated(); break;
                            case true: Password_2.SetActivated(); break;
                        }
                    }
                    else
                    {
                        Password_2.SetInactivated();
                        cont_pos = 3;
                    }
                }
                if (cont_pos == 2)
                {
                    Password_2.SetInactivated();
                    if (((dt.USERSESION.SystemSysAdmin >> 11) & 1) == 1)
                    {
                        switch (kscript)
                        {
                            case false: btn_Aceptar_.SetSemiInactivated(); break;
                            case true: btn_Aceptar_.SetActivated(); break;
                        }
                    }
                    else
                    {
                        btn_Aceptar_.SetInactivated();
                        cont_pos = 3;
                    }
                }
                if (cont_pos == 3)
                {
                    btn_Aceptar_.SetInactivated();
                    switch (kscript)
                    {
                        case false: btn_Volver_.SetSemiInactivated(); break;
                        case true: btn_Volver_.SetActivated(); break;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (i != cont_pos)
                    {
                        switch (i)
                        {
                            case 0: Password_.Display(color.NEGRO, color.NEGRO); break;
                            case 1: Password_2.Display(color.NEGRO, color.NEGRO); break;
                            case 2: btn_Aceptar_.Display(color.NEGRO, color.NEGRO); break;
                            case 3: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                        }
                    }
                }
                switch (cont_pos)
                {
                    case 0: Password_.Display(color.NEGRO, color.NEGRO); break;
                    case 1: Password_2.Display(color.NEGRO, color.NEGRO); break;
                    case 2: btn_Aceptar_.Display(color.NEGRO, color.NEGRO); break;
                    case 3: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                }
                if ((bool)btn_Volver_.GetDataInfo())
                {
                    cont_pos = 4;
                    kscript = true;
                    dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
                }
                if ((bool)btn_Aceptar_.GetDataInfo())
                {
                    kscript = true;
                    string pw1 = Password_.GetDataInfo().ToString();
                    string pw2 = Password_2.GetDataInfo().ToString();
                    if (FUNCTION.passwordcorrecto(pw1))
                    {
                        if (FUNCTION.passwordcorrecto(pw2))
                        {
                            if ((String.Compare(pw2, pw1)) == 0)
                            {
                                dt.USERCREATE.Password = pw1;
                                FUNCTION.Mensagedatatime(new string[] { "   C O N T R A S E Ñ A   ", "   M O D I F I C A D A   " }, color.BLANCO, color.AZUL, color.AZUL, 4, 90, 20);
                                cont_pos = 4;
                                kscript = true;
                                dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
                            }
                            else { FUNCTION.Mensagedatatime(new string[] { "Contraseña", "Incorrecta" }, color.BLANCO, color.ROJO, color.ROJO, 4, 90, 20); }
                        }
                        else { FUNCTION.Mensagedatatime(new string[] { "Contraseña", "Incorrecta" }, color.BLANCO, color.ROJO, color.ROJO, 4, 90, 20); }
                    }
                    else { FUNCTION.Mensagedatatime(new string[] { "Contraseña", "Incorrecta" }, color.BLANCO, color.ROJO, color.ROJO, 4, 90, 20); }
                    cont_pos = 4;
                }
                if (!kscript)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    tecla = key_data.InputMode();
                    if (tecla.Equals("TAB"))
                    {
                        cont_pos++;
                        if (cont_pos == 4) { cont_pos = 0; }
                    }
                    else
                    {
                        if (tecla.Equals("ENTER")) { kscript = true; }
                    }
                }
                else { kscript = false; }
            }
        }
        public static void BloqueoAcount(ref BDState dt)
        {
            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.ROJO };
            color[] backSelect2 = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO };
            color[] foreSelect2 = { color.DARK_GRIS, color.GRIS, color.DARK_CYAN, color.DARK_ROJO, color.BLANCO, color.ROJO, color.AZUL };
            color[] backOption = { color.NEGRO, color.DARK_GRIS, color.NEGRO, color.DARK_VERDE, color.NEGRO, color.VERDE };
            color[] foreOption = { color.GRIS, color.CYAN, color.DARK_AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            int cont_pos = 0;
            bool kscript = false;
            string tecla = "";

            FUNCTION.UsuarioPerfilado(ref dt);
            IOdata.Selector(color.BLANCO, color.AZUL, "SysAdmin - Estado de Cuenta de Usuarios", 40, 90, 25);
            IOdata.Selector(color.BLANCO, color.MAGENTA, "     Bloqueo de Cuenta de Usuario      ", 40, 90, 27);

            string[] blockopcion = { "Bloqueado", "Desbloqueado" };

            IORADIO BloqueoAcount_ = new IORADIO("Estado de Cuenta", blockopcion, backCorral, foreCorral, backtitulo, foretitulo, backSelect2, foreSelect2, backOption, foreOption, TypeLine._DOUBLE, 1, 55, 33);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER    ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 100, 33);
            IN key_data = new IN();
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);
            BloqueoAcount_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.StBlocked()) + 1);

            while (cont_pos != 2)
            {
                if (cont_pos == 0)
                {
                    btn_Volver_.SetInactivated();
                    if (((dt.USERSESION.SystemSysAdmin >> 10) & 1) == 1)
                    {
                        switch (kscript)
                        {
                            case (false): BloqueoAcount_.SetSemiInactivated(); break;
                            case (true): BloqueoAcount_.SetActivated(); break;
                        }
                    } else
                    {
                        BloqueoAcount_.SetInactivated();
                        cont_pos = 1;
                    }
                }
                if (cont_pos == 1)
                {
                    BloqueoAcount_.SetInactivated();
                    switch (kscript)
                    {
                        case (false): btn_Volver_.SetSemiInactivated(); break;
                        case (true): btn_Volver_.SetActivated(); break;
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    if (i != cont_pos)
                    {
                        switch (i)
                        {
                            case 0: BloqueoAcount_.Display(color.NEGRO, color.NEGRO); break;
                            case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                        }
                    }
                }
                switch (cont_pos)
                {
                    case 0: BloqueoAcount_.Display(color.NEGRO, color.NEGRO); break;
                    case 1: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                }
                if ((bool)btn_Volver_.GetDataInfo())
                {
                    cont_pos = 2;
                    kscript = true;
                    switch((Convert.ToInt32(BloqueoAcount_.GetDataInfo())) - 1)
                    {
                        case 0: dt.USERCREATE.ResetStBlockON(); break;
                        case 1: dt.USERCREATE.ResetStBlockOFF(); break;
                    }
                    dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
                }
                if (!kscript)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
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
        public static void BloqueoPassword(ref BDState dt)
        {
            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.ROJO };
            color[] backSelect2 = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO };
            color[] foreSelect2 = { color.DARK_GRIS, color.GRIS, color.DARK_CYAN, color.DARK_ROJO, color.BLANCO, color.ROJO, color.AZUL };
            color[] backOption = { color.NEGRO, color.DARK_GRIS, color.NEGRO, color.DARK_VERDE, color.NEGRO, color.VERDE };
            color[] foreOption = { color.GRIS, color.CYAN, color.DARK_AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            int cont_pos = 0;
            bool kscript = false;
            string tecla = "";

            FUNCTION.UsuarioPerfilado(ref dt);
            IOdata.Selector(color.BLANCO, color.AZUL, "SysAdmin - Estado de Cuenta de Usuarios", 40, 90, 25);
            IOdata.Selector(color.BLANCO, color.MAGENTA, "   Bloqueo de Contraseña de Usuario    ", 40, 90, 27);

            string[] blockopcion = { "Bloqueado" , "Desbloqueado" };

            IORADIO BloqueoPass_ = new IORADIO("Estado de Cuenta", blockopcion, backCorral, foreCorral, backtitulo, foretitulo, backSelect2, foreSelect2, backOption, foreOption, TypeLine._DOUBLE, 1, 55, 33);
            IODATAINFO Password_ = new IODATAINFO(" Ingrese el Password ", backCorral, foreCorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 21, 20, 85, 33);
            IODATAINFO Password_2 = new IODATAINFO("  Reingrese Password ", backCorral, foreCorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 21, 20, 85, 38);
            IOBUTTON btn_Aceptar_ = new IOBUTTON("   ACEPTAR   ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 140, 33);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER    ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 140, 38);
            IN key_data = new IN();
            Password_.SetTypeDataIN(TypeDataIN._LETTER);
            Password_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Password_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Password_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);

            Password_2.SetTypeDataIN(TypeDataIN._LETTER);
            Password_2.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Password_2.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Password_2.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);

            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            BloqueoPass_.SetSemiInactivated();
            while (cont_pos != 4)
            {
                BloqueoPass_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.StBlockPass()) + 1);
                if (cont_pos == 0)
                {
                    btn_Volver_.SetInactivated();
                    if (((dt.USERSESION.SystemSysAdmin >> 9) & 1) == 1)
                    {
                        switch (kscript)
                        {
                            case (false): Password_.SetSemiInactivated(); break;
                            case (true): Password_.SetActivated(); break;
                        }
                    }
                    else
                    {
                        cont_pos = 3;
                        Password_.SetInactivated();
                    }
                }
                if (cont_pos == 1)
                {
                    Password_.SetInactivated();
                    if (((dt.USERSESION.SystemSysAdmin >> 9) & 1) == 1)
                    {
                        switch (kscript)
                        {
                            case (false): Password_2.SetSemiInactivated(); break;
                            case (true): Password_2.SetActivated(); break;
                        }
                    }
                    else
                    {
                        cont_pos = 3;
                        Password_2.SetInactivated();
                    }
                }
                if (cont_pos == 2)
                {
                    Password_2.SetInactivated();
                    if (((dt.USERSESION.SystemSysAdmin >> 9) & 1) == 1)
                    {
                        switch (kscript)
                        {
                            case (false): btn_Aceptar_.SetSemiInactivated(); break;
                            case (true): btn_Aceptar_.SetActivated(); break;
                        }
                    }
                    else
                    {
                        cont_pos = 3;
                        btn_Aceptar_.SetInactivated();
                    }
                }
                if (cont_pos == 3)
                {
                    btn_Aceptar_.SetInactivated();
                    switch (kscript)
                    {
                        case (false): btn_Volver_.SetSemiInactivated(); break;
                        case (true): btn_Volver_.SetActivated(); break;
                    }
                }
                BloqueoPass_.Display(color.NEGRO, color.NEGRO);
                for (int i = 0; i < 4; i++)
                {
                    if (i != cont_pos)
                    {
                        switch (i)
                        {
                            case 0: Password_.Display(color.NEGRO, color.NEGRO); break;
                            case 1: Password_2.Display(color.NEGRO, color.NEGRO); break;
                            case 2: btn_Aceptar_.Display(color.NEGRO, color.NEGRO); break;
                            case 3: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;                            
                        }
                    }                    
                }
                switch (cont_pos)
                {
                    case 0: Password_.Display(color.NEGRO, color.NEGRO); break;
                    case 1: Password_2.Display(color.NEGRO, color.NEGRO); break;
                    case 2: btn_Aceptar_.Display(color.NEGRO, color.NEGRO); break;
                    case 3: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                }
                if ((bool)btn_Volver_.GetDataInfo())
                {
                    cont_pos = 4;
                    kscript = true;
                    dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
                }
                if ((bool)btn_Aceptar_.GetDataInfo())
                {
                    kscript = true;
                    string pw1 = Password_.GetDataInfo().ToString();
                    string pw2 = Password_2.GetDataInfo().ToString();
                    if (FUNCTION.passwordcorrecto(pw1))
                    {
                        if (FUNCTION.passwordcorrecto(pw2))
                        {
                            if ((String.Compare(pw2, pw1)) == 0)
                            {
                                dt.USERCREATE.ResetStBlockPass();
                                dt.USERCREATE.Password = pw1;
                                FUNCTION.Mensagedatatime(new string[] { "   C O N T R A S E Ñ A   ", "   D E S B L O Q U E A D A   " }, color.BLANCO, color.AZUL, color.AZUL, 4, 90, 20);
                            }
                            else { FUNCTION.Mensagedatatime(new string[] { "Contraseña", "Incorrecta" }, color.BLANCO, color.ROJO, color.ROJO, 4, 90, 20); }
                        }
                        else { FUNCTION.Mensagedatatime(new string[] { "Contraseña", "Incorrecta" }, color.BLANCO, color.ROJO, color.ROJO, 4, 90, 20); }
                    } else { FUNCTION.Mensagedatatime(new string[] { "Contraseña", "Incorrecta" }, color.BLANCO, color.ROJO, color.ROJO, 4, 90, 20); }
                    cont_pos = 4;
                }
                if (!kscript)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    tecla = key_data.InputMode();   
                    if (tecla.Equals("TAB"))
                    {
                        cont_pos++;
                        if (cont_pos == 4) { cont_pos = 0; }
                    } else
                    {
                        if (tecla.Equals("ENTER")) { kscript = true; }
                    }
                } else { kscript = false; }  
            }            
        }
        public static void ConfigExpiracionPassword(ref BDState dt)
        {
            int cont_pos = 0;
            bool kscript = false;
            string tecla = "";
            FUNCTION.UsuarioPerfilado(ref dt);
            IOdata.Selector(color.BLANCO, color.AZUL,    "SysAdmin - Estado de Cuenta de Usuarios", 40, 90, 25);
            IOdata.Selector(color.BLANCO, color.MAGENTA, "  Expiracion de Contraseña de Usuario  ", 40, 90, 27);

            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.DARK_GRIS };
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] backSelect = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO, color.NEGRO };
            color[] foreSelect = { color.DARK_GRIS, color.GRIS, color.DARK_CYAN, color.DARK_ROJO, color.BLANCO, color.ROJO, color.AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };

            IN key_data = new IN();
            IODATETIME PasswordExpiracion_ = new IODATETIME(" Fecha de Expiracion ", backCorral, foreCorral, backtitulo, foretitulo, backSelect, foreSelect, TypeLine._DOUBLE, 20, 34);
            IODATAINFO Password_ = new IODATAINFO(" Ingrese el Password ", backCorral, foreCorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 21, 20, 85, 33);
            IODATAINFO Password_2 = new IODATAINFO("  Reingrese Password ", backCorral, foreCorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 21, 20, 85, 38);
            IOBUTTON btn_Aceptar_ = new IOBUTTON("   ACEPTAR   ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 140, 33);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER    ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 140, 38);

            Password_.SetTypeDataIN(TypeDataIN._LETTER);
            Password_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Password_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Password_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);

            Password_2.SetTypeDataIN(TypeDataIN._LETTER);
            Password_2.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Password_2.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Password_2.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);

            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            PasswordExpiracion_.SetDataInfo(dt.USERCREATE.FechNacExpPass);

            PasswordExpiracion_.SetInactivated();
            Password_.SetInactivated();
            Password_2.SetInactivated();
            btn_Volver_.SetInactivated();
            btn_Aceptar_.SetInactivated();


            if (dt.USERCREATE.SWExpPassword == 0)
            {
                while (cont_pos != 5)
                {
                    if (cont_pos == 0)
                    {
                        btn_Volver_.SetInactivated();
                        if (((dt.USERSESION.SystemSysAdmin >> 8) & 1) == 1)
                        {
                            switch(kscript)
                            {
                                case (false): PasswordExpiracion_.SetSemiInactivated(); break;
                                case (true): PasswordExpiracion_.SetActivated(); break;
                            }
                        } 
                        else 
                        {
                            PasswordExpiracion_.SetInactivated();
                            cont_pos = 4;
                        }                        
                    }
                    if (cont_pos == 1)
                    {
                        PasswordExpiracion_.SetInactivated();
                        if (((dt.USERSESION.SystemSysAdmin >> 8) & 1) == 1)
                        {
                            switch (kscript)
                            {
                                case (false): Password_.SetSemiInactivated(); break;
                                case (true): Password_.SetActivated(); break;
                            }
                        }
                        else
                        {
                            Password_.SetInactivated();
                            cont_pos = 4;
                        }
                    }
                    if (cont_pos == 2)
                    {
                        Password_.SetInactivated();
                        if (((dt.USERSESION.SystemSysAdmin >> 8) & 1) == 1)
                        {
                            switch (kscript)
                            {
                                case (false): Password_2.SetSemiInactivated(); break;
                                case (true): Password_2.SetActivated(); break;
                            }
                        }
                        else
                        {
                            Password_2.SetInactivated();
                            cont_pos = 4;
                        }
                    }
                    if (cont_pos == 3)
                    {
                        Password_2.SetInactivated();
                        if (((dt.USERSESION.SystemSysAdmin >> 8) & 1) == 1)
                        {
                            switch (kscript)
                            {
                                case (false): btn_Aceptar_.SetSemiInactivated(); break;
                                case (true): btn_Aceptar_.SetActivated(); break;
                            }
                        }
                        else
                        {
                            btn_Aceptar_.SetInactivated();
                            cont_pos = 4;
                        }
                    }
                    if (cont_pos == 4)
                    {
                        btn_Aceptar_.SetInactivated();
                        switch (kscript)
                        {
                            case (false): btn_Volver_.SetSemiInactivated(); break;
                            case (true): btn_Volver_.SetActivated(); break;
                        }
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if (i != cont_pos)
                        {
                            switch(i)
                            {
                                case 0: PasswordExpiracion_.Display(color.NEGRO, color.NEGRO); break;
                                case 1: Password_.Display(color.NEGRO, color.NEGRO); break;
                                case 2: Password_2.Display(color.NEGRO, color.NEGRO); break;
                                case 3: btn_Aceptar_.Display(color.NEGRO, color.NEGRO); break;
                                case 4: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                            }
                        }
                    }
                    switch (cont_pos)
                    {
                        case 0: PasswordExpiracion_.Display(color.NEGRO, color.NEGRO); break;
                        case 1: Password_.Display(color.NEGRO, color.NEGRO); break;
                        case 2: Password_2.Display(color.NEGRO, color.NEGRO); break;
                        case 3: btn_Aceptar_.Display(color.NEGRO, color.NEGRO); break;
                        case 4: btn_Volver_.Display(color.NEGRO, color.NEGRO); break;
                    }
                    if ((bool)btn_Volver_.GetDataInfo())
                    {
                        cont_pos = 5;
                        kscript = true;
                        dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
                    }
                    if ((bool)btn_Aceptar_.GetDataInfo())
                    {
                        bool pot = false;
                        cont_pos = 5;
                        kscript = true;
                        string pw1 = Password_.GetDataInfo().ToString();
                        string pw2 = Password_2.GetDataInfo().ToString();
                        if (FUNCTION.passwordcorrecto(pw1))
                        {
                            if (FUNCTION.passwordcorrecto(pw2))
                            {
                                if ((String.Compare(pw2, pw1)) == 0)
                                {
                                    int fechahoy = (DateTime.Now.Year * 10000) + (DateTime.Now.Month * 100) + (DateTime.Now.Day);
                                    if ((Convert.ToInt32(PasswordExpiracion_.GetDataInfo())) > fechahoy)
                                    {
                                        dt.USERCREATE.FechNacExpPass = Convert.ToInt32(PasswordExpiracion_.GetDataInfo());
                                        dt.USERCREATE.Password = pw1;
                                        pot = true;
                                    }
                                    else { FUNCTION.Mensagedatatime(new string[] { "Fecha de Expiracion", "Incorrecta" }, color.BLANCO, color.ROJO, color.DARK_CYAN, 4, 90, 20); }
                                    switch (pot)
                                    {
                                        case true: dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION); break;
                                        case false: dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._EXPIRACION_PASSW); break;
                                    }
                                }
                                else { FUNCTION.Mensagedatatime(new string[] { "Contraseña", "Incorrecta" }, color.BLANCO, color.ROJO, color.DARK_CYAN, 4, 90, 20); }                                
                            } else { FUNCTION.Mensagedatatime(new string[] { "Contraseña", "Incorrecta" }, color.BLANCO, color.ROJO, color.DARK_CYAN, 4, 90, 20); }
                        } else { FUNCTION.Mensagedatatime(new string[] { "Contraseña", "Incorrecta" }, color.BLANCO, color.ROJO, color.DARK_CYAN, 4, 90, 20); }                       
                    }
                    if (!kscript)
                    {
                        OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                        tecla = key_data.InputMode();
                        if (tecla.Equals("TAB"))
                        {
                            cont_pos++;
                            if (cont_pos == 5) { cont_pos = 0; }
                        }
                        else
                        {
                            if (tecla.Equals("ENTER")) { kscript = true; }
                        }
                    } else { kscript = false; }
                }
            } else
            {
                FUNCTION.Mensagedatatime(new string[] { "La Contraseña", "Nunca Expira" }, color.BLANCO, color.ROJO, color.DARK_CYAN, 4, 90, 20);
                dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
            }            
        }
        public static void ConfigExpiracionCuenta(ref BDState dt)
        {
            int cont_p = 0;
            bool kscript = false;
            color[] backCorral = { color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreCorral = { color.DARK_GRIS, color.DARK_VERDE, color.AZUL };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.DARK_GRIS }; ;
            color[] foretitulo = { color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] backSelect = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO, color.NEGRO };
            color[] foreSelect = { color.DARK_GRIS , color.GRIS , color.DARK_CYAN , color.DARK_ROJO , color.BLANCO , color.ROJO , color.AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            FUNCTION.UsuarioPerfilado(ref dt);
            IOdata.Selector(color.BLANCO, color.AZUL,    "SysAdmin - Estado de Cuenta de Usuarios", 40, 90, 25);
            IOdata.Selector(color.BLANCO, color.MAGENTA, "    Expiracion de Cuenta de Usuario    ", 40, 90, 27);

            IODATETIME CountExpiracion_ = new IODATETIME(" Fecha de Expiracion ", backCorral, foreCorral, backtitulo, foretitulo, backSelect, foreSelect, TypeLine._DOUBLE, 40, 34);            
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER   ", backCorral, foreCorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 110, 38);
            IN key_data = new IN();
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);
            string tecla = "";
            CountExpiracion_.SetDataInfo(dt.USERCREATE.FechNacExp);
            CountExpiracion_.SetInactivated();
            btn_Volver_.SetInactivated();

            if (dt.USERCREATE.SWExpirated == 0)
            {
                while(cont_p != 2)
                {
                    if (cont_p == 0)
                    {
                        btn_Volver_.SetInactivated();
                        if (((dt.USERSESION.SystemSysAdmin >> 7) & 1) == 1)
                        {
                            switch(kscript)
                            {
                                case (false): CountExpiracion_.SetSemiInactivated(); break;
                                case (true): CountExpiracion_.SetActivated(); break;
                            }
                        } else
                        {
                            CountExpiracion_.SetInactivated();
                            cont_p = 1;
                        }
                        btn_Volver_.Display(color.NEGRO, color.NEGRO);
                        CountExpiracion_.Display(color.NEGRO, color.NEGRO);
                    }
                    if (cont_p == 1)
                    {
                        CountExpiracion_.SetInactivated();
                        switch (kscript)
                        {
                            case (false): btn_Volver_.SetSemiInactivated(); break;
                            case (true): btn_Volver_.SetActivated(); break;
                        }
                        CountExpiracion_.Display(color.NEGRO, color.NEGRO);
                        btn_Volver_.Display(color.NEGRO, color.NEGRO);                        
                    }
                    if ((bool)btn_Volver_.GetDataInfo())
                    {
                        cont_p = 2;
                        kscript = true;
                        dt.USERCREATE.FechNacExp = Convert.ToInt32(CountExpiracion_.GetDataInfo());
                        dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);                         
                    }
                    if (!kscript)
                    {
                        OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                        tecla = key_data.InputMode();
                        if (tecla.Equals("TAB"))
                        {
                            cont_p++;
                            if (cont_p == 2) { cont_p = 0; }
                        } else
                        {
                            if (tecla.Equals("ENTER")) { kscript = true; }
                        }
                    } else { kscript = false; }
                }
            } else
            {
                FUNCTION.Mensagedatatime(new string[] { "La Cuenta", "Nunca Expira" }, color.BLANCO, color.ROJO, color.DARK_CYAN, 4, 90, 20);                
            }
            dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
        }
        public static void ConfiguracionAvanzada(ref BDState dt)
        {
            int cont_event = 0;
            bool kscript = false;
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backSelect2 = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO };
            color[] foreSelect2 = { color.DARK_GRIS, color.GRIS, color.DARK_CYAN, color.DARK_ROJO, color.BLANCO, color.ROJO, color.AZUL };
            color[] backOption = { color.NEGRO, color.DARK_GRIS, color.NEGRO, color.DARK_VERDE, color.NEGRO, color.VERDE };
            color[] foreOption = { color.GRIS, color.CYAN, color.DARK_AZUL };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            FUNCTION.UsuarioPerfilado(ref dt);
            IOdata.Selector(color.BLANCO, color.AZUL, "SysAdmin - Estado de Cuenta de Usuarios", 40, 90, 25);
            IOdata.Selector(color.BLANCO, color.MAGENTA, "        Configuracion Avanzada         ", 40, 90, 27);

            string[] estadocuenta = { "Habilitado", "Deshabilitado" };
            string[] estadosw = { "OFF" , "ON" };

            int estado_condicion = 0;
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 5, 0);
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 6, 1);
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 7, 2);

            IORADIO Habilitador_ = new IORADIO("Estado de Cuenta", estadocuenta, backcorral, forecorral, backtitulo, foretitulo, backSelect2, foreSelect2, backOption, foreOption, TypeLine._DOUBLE, 1, 55, 33);
            IORADIO SWExpiracionCount_ = new IORADIO("Switch de Expiracion", estadosw, backcorral, forecorral, backtitulo, foretitulo, backSelect2, foreSelect2, backOption, foreOption, TypeLine._DOUBLE, 1, 100, 33);
            IORADIO SWExpiracionPassw_ = new IORADIO("Switch de Exp. Pass", estadosw, backcorral, forecorral, backtitulo, foretitulo, backSelect2, foreSelect2, backOption, foreOption, TypeLine._DOUBLE, 1, 135, 33);
            IOBUTTON btn_Volver_ = new IOBUTTON("   VOLVER   ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 168, 38);
            IN key_data = new IN();

            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            Habilitador_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.StHabilitacion()) + 1);
            SWExpiracionCount_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.SWExpirated) + 1);
            SWExpiracionPassw_.SetDataInfo(Convert.ToInt32(dt.USERCREATE.SWExpPassword) + 1);

            Habilitador_.SetInactivated();
            SWExpiracionCount_.SetInactivated();
            SWExpiracionPassw_.SetInactivated();
            btn_Volver_.SetInactivated();

            while (cont_event != 4)
            {
                if (cont_event == 0)
                {
                    btn_Volver_.SetInactivated();
                    if (((estado_condicion >> 0) & 1) == 1)
                    {
                        switch(kscript)
                        {
                            case (false): Habilitador_.SetSemiInactivated(); break;
                            case (true): Habilitador_.SetActivated(); break;
                        }
                    } else
                    {
                        Habilitador_.SetInactivated();
                        cont_event = 1;
                    }
                    SWExpiracionCount_.Display(color.NEGRO, color.NEGRO);
                    SWExpiracionPassw_.Display(color.NEGRO, color.NEGRO);
                    btn_Volver_.Display(color.NEGRO, color.NEGRO);
                    Habilitador_.Display(color.NEGRO, color.NEGRO);
                }

                if (cont_event == 1)
                {
                    Habilitador_.SetInactivated();
                    if (((estado_condicion >> 1) & 1) == 1)
                    {
                        switch (kscript)
                        {
                            case (false): SWExpiracionCount_.SetSemiInactivated(); break;
                            case (true): SWExpiracionCount_.SetActivated(); break;
                        }
                    }
                    else
                    {
                        SWExpiracionCount_.SetInactivated();
                        cont_event = 2;
                    }
                    Habilitador_.Display(color.NEGRO, color.NEGRO);
                    SWExpiracionPassw_.Display(color.NEGRO, color.NEGRO);
                    btn_Volver_.Display(color.NEGRO, color.NEGRO);
                    SWExpiracionCount_.Display(color.NEGRO, color.NEGRO);
                }

                if (cont_event == 2)
                {
                    SWExpiracionCount_.SetInactivated();                    
                    if (((estado_condicion >> 2) & 1) == 1)
                    {
                        switch (kscript)
                        {
                            case (false): SWExpiracionPassw_.SetSemiInactivated(); break;
                            case (true): SWExpiracionPassw_.SetActivated(); break;
                        }
                    }
                    else
                    {
                        SWExpiracionPassw_.SetInactivated();
                        cont_event = 3;
                    }
                    Habilitador_.Display(color.NEGRO, color.NEGRO);
                    SWExpiracionCount_.Display(color.NEGRO, color.NEGRO);
                    btn_Volver_.Display(color.NEGRO, color.NEGRO);
                    SWExpiracionPassw_.Display(color.NEGRO, color.NEGRO);
                }

                if (cont_event == 3)
                {
                    SWExpiracionPassw_.SetInactivated();
                    switch (kscript)
                    {
                        case (false): btn_Volver_.SetSemiInactivated(); break;
                        case (true): btn_Volver_.SetActivated(); break;
                    }
                    Habilitador_.Display(color.NEGRO, color.NEGRO);
                    SWExpiracionCount_.Display(color.NEGRO, color.NEGRO);
                    SWExpiracionPassw_.Display(color.NEGRO, color.NEGRO);
                    btn_Volver_.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)btn_Volver_.GetDataInfo())
                {
                    kscript = true;
                    cont_event = 4;
                    switch(Convert.ToInt32(Habilitador_.GetDataInfo()) - 1)
                    {
                        case 0: dt.USERCREATE.StHabilitadorON(); break;
                        case 1: dt.USERCREATE.StHabilitadorOFF(); break;
                    }
                    switch (Convert.ToInt32(SWExpiracionCount_.GetDataInfo()) - 1)
                    {
                        case 0: dt.USERCREATE.SWExpiratedON(); break;
                        case 1: dt.USERCREATE.SWExpiratedOFF(); break;
                    }
                    switch (Convert.ToInt32(SWExpiracionPassw_.GetDataInfo()) - 1)
                    {
                        case 0: dt.USERCREATE.SWExpPasswordON(); break;
                        case 1: dt.USERCREATE.SWExpPasswordOFF(); break;                        
                    }
                    dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
                }
                if (!kscript)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if (tecla.Equals("TAB"))
                    {
                        cont_event++;
                        if (cont_event == 4) { cont_event = 0; }
                    } else
                    {
                        if (tecla.Equals("ENTER"))
                        {
                            kscript = true;
                        }
                    }
                } else { kscript = false; }
            }
        }
        public static void volvermenu(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._none);
            dt.SetMState(TypeState._LiveSysAdminEstado, LiveProgram._INACTIVATED);
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
            dt.CONDICION_LISTA = LiveProgram._none;
            dt.POSITION = -1;
            dt.USERCREATE = new Usuario();
        }
        public static void MenuOpcion(ref BDState dt)
        {
            FUNCTION.UsuarioPerfilado(ref dt);            

            string[] select_menu = { "Configuracion avanzada" , //1
                                     "Expiracion de Cuenta" ,  //2
                                     "Expiracion de Contraseña" , //4 
                                     "Bloqueos de Contraseña" ,  //8
                                     "Bloqueos de Cuenta" ,  //16
                                     "Reseteo de Contraseña" , //32
                                     "Guardar Actualizaciones" , //64
                                     "Volver al Menu" }; //128
            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };
            Console.ResetColor();
            IOMENU menuavanzado = new IOMENU("SysAdmin - Estado de Cuenta de Usuarios", select_menu, 4, color.NEGRO, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 23, 25);
            int estado_condicion = 0;
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, new int[] { 5 , 6 , 7 }, 0);
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 8, 1);
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 9, 2);
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 10, 3);
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 11, 4);
            FUNCTION.StateBit(ref estado_condicion, dt.USERSESION.SystemSysAdmin, 12, 5);
            menuavanzado.SetDataInfo(estado_condicion + 192);
            menuavanzado.Display(color.NEGRO, color.NEGRO);
            int opcion = (int)menuavanzado.GetDataInfo();

            switch(opcion)
            {
                case 0: dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._CONFIG_AVANZADO); break;
                case 1: dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._EXPIRACION_COUNT); break;
                case 2: dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._EXPIRACION_PASSW); break;
                case 3: dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._BLOQUEO_PASS); break;
                case 4: dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._BLOQUEO_ACOUNT); break;
                case 5: dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._RESET_PASSWORD); break;
                case 6: dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._SAVE_USER); break;
                case 7: dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._VOLVER); break;
            }
        }
    }
}
