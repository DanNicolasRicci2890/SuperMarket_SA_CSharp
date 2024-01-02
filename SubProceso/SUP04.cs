using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ScreemDisplay;
using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;
using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class SUP04
    {
        public static void Mensage05(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   L A    C O N T R A S E Ñ A   ", "   D E   S U   U S U A R I O   " , "   H A   S I D O    M O D I F I C A D A   "};
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.ROJO, color.AZUL, 100, 20);
            dt.SetMState(TypeState._UserPerfil, UserPerfil._VOLVER);
        }
        public static void SaveUser(ref BDState dt)
        {
            FDUsuario opus_data = new FDUsuario("ListUserProgram");
            opus_data.LoadListUser();
            int index = opus_data.SeekUserList(dt.USERSESION.Legajo);
            if (index != -1)
            {
                dt.USERSESION.Password = dt.PASSWORD_DATA.PASSWORD_NEW1;
            }
            opus_data.ReplaceListUser(dt.USERSESION, index);
            opus_data.BurbujaListUser();
            opus_data.SaveListUser();
            dt.SetMState(TypeState._UserPerfil, UserPerfil._MENSAGE05);
        }
        public static void Mensage04(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O R R E C T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[3];
            mensaje[0] = "  L A S    C O N T R A S E Ñ A S    ";
            mensaje[1] = "   N U E V A S    N O    S O N     ";
            mensaje[2] = "   I G U A L E S   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._UserPerfil, UserPerfil._VOLVER);
        }
        public static void Mensage03(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O R R E C T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[3];
            mensaje[0] = "  L A    C O N T R A S E Ñ A   ";
            mensaje[1] = "   N U E V A   N O   C U M P L E   ";
            mensaje[2] = "   C O N    L O S    P A R A M E T R O S   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._UserPerfil, UserPerfil._VOLVER);
        }
        public static void Mensage02(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O R R E C T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje= new string[3];
            mensaje[0] = "  L A    C O N T R A S E Ñ A   ";
            mensaje[1] = "   A C T U A L    N O   E S   ";
            mensaje[2] = "   C O R R E C T A   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._UserPerfil, UserPerfil._VOLVER);
        }
        public static void Mensage01(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje[0] = "   F A L T A   C A M P O S    ";
            mensaje[1] = "   P A R A    C O M P L E T A R   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._UserPerfil, UserPerfil._VOLVER);
        }
        public static void VerificarContenido(ref BDState dt)
        {
            int count = 0;

            dt.SetMState(TypeState._UserPerfil, UserPerfil._MENSAGE01);
            if ((dt.PASSWORD_DATA.PASSWORD_ACTUAL.Length) != 0)
            {
                if ((dt.PASSWORD_DATA.PASSWORD_NEW1.Length) != 0)
                {
                    if ((dt.PASSWORD_DATA.PASSWORD_NEW2.Length) != 0)
                    {
                        count = 1;
                    }
                }
            }
            if (count == 1)
            {
                dt.SetMState(TypeState._UserPerfil, UserPerfil._MENSAGE02);
                bool est = dt.PASSWORD_DATA.PASSWORD_ACTUAL.Equals(dt.USERSESION.Password);
                if (est) { count = 2; }
            }
            if (count == 2)
            {
                dt.SetMState(TypeState._UserPerfil, UserPerfil._MENSAGE03);
                string pot1 = dt.PASSWORD_DATA.PASSWORD_NEW1;
                string pot2 = dt.PASSWORD_DATA.PASSWORD_NEW2;
                if ((FUNCTION.passwordcorrecto(pot1)) && (FUNCTION.passwordcorrecto(pot2))) { count = 3; }
            }
            if (count == 3)
            {
                dt.SetMState(TypeState._UserPerfil, UserPerfil._MENSAGE04);
                bool est = dt.PASSWORD_DATA.PASSWORD_NEW1.Equals(dt.PASSWORD_DATA.PASSWORD_NEW2);
                if (est)
                {
                    dt.SetMState(TypeState._UserPerfil, UserPerfil._SAVE_PASS);
                }
            }
        }
        public static void VolverMenu(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveUserPerfil, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._UserPerfil, UserPerfil._none);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SystemUser, SystemUser._PRESENTADOR);
            dt.SetMState(TypeState._StateMain, StateMain._SYSTEM_USER);
        }
        public static void Visualizacion(ref BDState dt)
        {
            FUNCTION.UsuarioPerfilado(ref dt);
            bool estado = true, script = false;
            int nivel = 0;
            IN key_data = new IN();
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };            
            color[] backtitulo2 = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            key_data.SetCondIN(INCond._ARROWS);
            key_data.SetCondIN(INCond._ENTER);

            IODATAINFO PasswordActual_ = new IODATAINFO("           Password Actual ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 30, 25, 80, 25);
            IODATAINFO PasswordNew1_ = new IODATAINFO("           Password Nueva  ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 30, 25, 80, 30);
            IODATAINFO PasswordNew2_ = new IODATAINFO("   Repetir Password Nueva  ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 30, 25, 80, 35);
            IOBUTTON btn_ACEPTAR_ = new IOBUTTON("       GUARDAR        ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 80, 40);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("         SALIR        ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 113, 40);

            PasswordActual_.SetDataInfo("");
            PasswordNew1_.SetDataInfo("");
            PasswordNew2_.SetDataInfo("");
            btn_ACEPTAR_.SetDataInfo(false);
            btn_VOLVER_.SetDataInfo(false);

            PasswordActual_.SetTypeDataIN(TypeDataIN._LETTER);
            PasswordActual_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            PasswordActual_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            PasswordActual_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);
            PasswordNew1_.SetTypeDataIN(TypeDataIN._LETTER);
            PasswordNew1_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            PasswordNew1_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            PasswordNew1_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);
            PasswordNew2_.SetTypeDataIN(TypeDataIN._LETTER);
            PasswordNew2_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            PasswordNew2_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            PasswordNew2_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);

            while (estado)
            {
                if (nivel == 0)
                {
                    switch(script)
                    {
                        case false: PasswordActual_.SetSemiInactivated(); break;
                        case true: PasswordActual_.SetActivated(); break;
                    }
                    PasswordNew1_.SetInactivated();
                    PasswordNew2_.SetInactivated();
                    btn_ACEPTAR_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    PasswordNew1_.Display(color.NEGRO, color.NEGRO);
                    PasswordNew2_.Display(color.NEGRO, color.NEGRO);
                    btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    PasswordActual_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 1)
                {
                    PasswordActual_.SetInactivated();
                    switch (script)
                    {
                        case false: PasswordNew1_.SetSemiInactivated(); break;
                        case true: PasswordNew1_.SetActivated(); break;
                    }
                    PasswordNew2_.SetInactivated();
                    btn_ACEPTAR_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    PasswordActual_.Display(color.NEGRO, color.NEGRO);
                    PasswordNew2_.Display(color.NEGRO, color.NEGRO);
                    btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    PasswordNew1_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 2)
                {
                    PasswordActual_.SetInactivated();
                    PasswordNew1_.SetInactivated();
                    switch (script)
                    {
                        case false: PasswordNew2_.SetSemiInactivated(); break;
                        case true: PasswordNew2_.SetActivated(); break;
                    }
                    btn_ACEPTAR_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    PasswordActual_.Display(color.NEGRO, color.NEGRO);
                    PasswordNew1_.Display(color.NEGRO, color.NEGRO);                    
                    btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    PasswordNew2_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 3)
                {
                    PasswordActual_.SetInactivated();
                    PasswordNew1_.SetInactivated();
                    PasswordNew2_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_ACEPTAR_.SetSemiInactivated(); break;
                        case true: btn_ACEPTAR_.SetActivated(); break;
                    }
                    btn_VOLVER_.SetInactivated();
                    PasswordActual_.Display(color.NEGRO, color.NEGRO);
                    PasswordNew1_.Display(color.NEGRO, color.NEGRO);
                    PasswordNew2_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 4)
                {
                    PasswordActual_.SetInactivated();
                    PasswordNew1_.SetInactivated();
                    PasswordNew2_.SetInactivated();
                    btn_ACEPTAR_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_VOLVER_.SetSemiInactivated(); break;
                        case true: btn_VOLVER_.SetActivated(); break;
                    }
                    PasswordActual_.Display(color.NEGRO, color.NEGRO);
                    PasswordNew1_.Display(color.NEGRO, color.NEGRO);
                    PasswordNew2_.Display(color.NEGRO, color.NEGRO);
                    btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)(btn_ACEPTAR_.GetDataInfo()))
                {
                    estado = false;
                    script = true;
                    dt.PASSWORD_DATA.PASSWORD_ACTUAL = PasswordActual_.GetDataInfo().ToString();
                    dt.PASSWORD_DATA.PASSWORD_NEW1 = PasswordNew1_.GetDataInfo().ToString();
                    dt.PASSWORD_DATA.PASSWORD_NEW2 = PasswordNew2_.GetDataInfo().ToString();
                    dt.SetMState(TypeState._UserPerfil, UserPerfil._VERIF_CONTENIDO);
                }
                if ((bool)(btn_VOLVER_.GetDataInfo()))
                {
                    estado = false;
                    script = true;
                    dt.SetMState(TypeState._UserPerfil, UserPerfil._VOLVER);
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();

                    if ((tecla.Equals("DOWNARROW")) || (tecla.Equals("UPARROW")) || (tecla.Equals("ENTER")))
                    {
                        if ((tecla.Equals("DOWNARROW")) || (tecla.Equals("UPARROW")))
                        {
                            if (tecla.Equals("DOWNARROW")) 
                            {
                                nivel++;
                                if (nivel == 5) { nivel = 0; }
                            }
                            if (tecla.Equals("UPARROW"))
                            {
                                nivel--;
                                if (nivel == -1) { nivel = 4; }
                            }
                        } 
                        else 
                        {
                            if (tecla.Equals("ENTER"))
                            {
                                script = true;
                            }
                        }
                    }
                } else { script = false; }
            }
        }
    }
}
