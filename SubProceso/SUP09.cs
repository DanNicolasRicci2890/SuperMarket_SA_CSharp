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
    public class SUP09
    {
        public static void Mensage4(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S U A R I O   ", "   M O D I F I C A D O   " };
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._VOLVER);
        }
        public static void ProcessUserPass(ref BDState dt)
        {
            FDUsuario condicion = new FDUsuario("ListUserProgram");
            condicion.LoadListUser();
            dt.USERCREATE.UserID = FUNCTION.usuariominuscula(dt.USER_FUTURE);
            dt.USERCREATE.Password = dt.PASS_FUTURE;
            dt.USERCREATE.StHabilitadorON();
            dt.USERCREATE.FechNacExp = Usuario.IncrementadorExpiracion(6);
            dt.USERCREATE.FechNacExpPass = Usuario.IncrementadorExpiracion(2);
            dt.USERCREATE.ResetearBloqueos();
            condicion.ReplaceListUser(dt.USERCREATE, dt.POSITION);
            condicion.SaveListUser();           
            dt.USER_FUTURE = "";
            dt.PASS_FUTURE = "";
            dt.POSITION = -1;
            dt.USERCREATE = new Usuario();
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._MENSAGE4);
        }
        public static void IngresoUSER_PASSWORD(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();

            IOdata.Selector(color.BLANCO, color.AZUL, "SysAdmin - Ingresar Usuarios al Sistema", 40, 90, 8);

            string[] identificacion = { " nombre y apellido: ", dt.USERCREATE.IdentidadConcatenar() };
            string[] direccion = { "         direccion: ", dt.USERCREATE.ConcatenarDireccion1() };
            string[] direccion2 = { "                    ", dt.USERCREATE.ConcatenarDireccion2() };
            
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS };
            color[] backData = { color.GRIS };
            color[] foreData = { color.NEGRO };
            color[] backtitulobtn = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulobtn = { color.DARK_GRIS, color.DARK_ROJO, color.AZUL };

            color[] back = { color.NEGRO, color.NEGRO };
            color[] fore = { color.CYAN, color.AZUL };
            OUT.PrintLine(identificacion, fore, back, 24, 14);
            OUT.PrintLine(direccion, fore, back, 24, 16);
            OUT.PrintLine(direccion2, fore, back, 24, 17);
            IODATAINFO userid_ = new IODATAINFO("   usuario ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 120, 13);
            IODATAINFO password_ = new IODATAINFO("  password ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 30, 25, 120, 18);
            IOBUTTON aceptar_ = new IOBUTTON("    ACEPTAR    ", backcorral, forecorral, backtitulobtn, foretitulobtn, TypeLine._DOUBLE, 120, 24);
            IOBUTTON salir_ = new IOBUTTON("     SALIR     ", backcorral, forecorral, backtitulobtn, foretitulobtn, TypeLine._DOUBLE, 145, 24);
            IN key_data = new IN();
            userid_.SetDataInfo(dt.USER_FUTURE.ToString());
            password_.SetDataInfo(dt.PASS_FUTURE.ToString());
            userid_.SetInactivated();
            password_.SetInactivated();
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);
            int cont_event = 0;
            bool kscript = false;
            string tecla = "";

            userid_.Display(color.NEGRO, color.NEGRO);
            password_.Display(color.NEGRO, color.NEGRO);
            aceptar_.SetInactivated();
            salir_.SetInactivated();

            while (cont_event != 2)
            {
                if (cont_event == 0)
                {
                    salir_.SetInactivated();
                    switch(kscript)
                    {
                        case (false): aceptar_.SetSemiInactivated(); break;
                        case (true): aceptar_.SetActivated(); break;
                    }
                    salir_.Display(color.NEGRO, color.NEGRO);
                    aceptar_.Display(color.NEGRO, color.NEGRO);
                }
                if (cont_event == 1)
                {
                    aceptar_.SetInactivated();
                    switch (kscript)
                    {
                        case (false): salir_.SetSemiInactivated(); break;
                        case (true): salir_.SetActivated(); break;
                    }                    
                    aceptar_.Display(color.NEGRO, color.NEGRO);
                    salir_.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)salir_.GetDataInfo())
                {
                    dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._VOLVER);
                    kscript = true;
                    cont_event = 2;
                }
                if ((bool)aceptar_.GetDataInfo())
                {
                    dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._ING_USER_PASS);
                    kscript = true;
                    cont_event = 2;
                }
                if (!(kscript))
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    tecla = key_data.InputMode();
                    if (tecla.Equals("TAB"))
                    {
                        cont_event++;
                        if (cont_event == 2) { cont_event = 0; }
                    } else
                    {
                        if (tecla.Equals("ENTER")) { kscript = true; }
                    }
                } else { kscript = true; }
            }
        }
        public static void Mensage3(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   P A S S W O R D   ", "   N O   V A L I D O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[7];
            mensaje[0] = "   E L   P A S S W O R D   ";
            mensaje[1] = "   D E B E   T E N E R   ";
            mensaje[2] = "   M A Y U S C U L A S ,  ";
            mensaje[3] = "   M I N U S C U L A S ,  ";
            mensaje[4] = "   N U M E R O S   ";
            mensaje[5] = "   Y   C A R A C T E R E S   ";
            mensaje[6] = "   E S P E C I A L E S   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.ROJO, 100, 20);
            dt.PASS_FUTURE = "";
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._IN_PASSWORD);
        }
        public static void UsuarioIngPassword(ref BDState dt)
        {
            int cont_event = 0;
            bool kscript = false;
            string tecla = "";
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();

            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backtitulobtn = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulobtn = { color.DARK_GRIS, color.DARK_ROJO, color.AZUL };

            IOdata.Selector(color.BLANCO, color.AZUL, "SysAdmin - Ingresar Usuarios al Sistema", 40, 90, 8);

            string[] identificacion = { " nombre y apellido: ", dt.USERCREATE.IdentidadConcatenar() };
            string[] direccion = { "         direccion: ", dt.USERCREATE.ConcatenarDireccion1() };
            string[] direccion2 = { "                    ", dt.USERCREATE.ConcatenarDireccion2() };
            color[] back = { color.NEGRO, color.NEGRO };
            color[] fore = { color.CYAN, color.AZUL };
            OUT.PrintLine(identificacion, fore, back, 24, 14);
            OUT.PrintLine(direccion, fore, back, 24, 16);
            OUT.PrintLine(direccion2, fore, back, 24, 17);

            IODATAINFO password1_ = new IODATAINFO("   ingrese el password ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 30, 25, 120, 13);
            IODATAINFO password2_ = new IODATAINFO(" reingrese el password ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 30, 25, 120, 18);
            IOBUTTON aceptar_ = new IOBUTTON("    ACEPTAR    ", backcorral, forecorral, backtitulobtn, foretitulobtn, TypeLine._DOUBLE, 120, 23);
            IOBUTTON salir_ = new IOBUTTON("     SALIR     ", backcorral, forecorral, backtitulobtn, foretitulobtn, TypeLine._DOUBLE, 156, 23);
            IN key_data = new IN();
            password1_.SetTypeDataIN(TypeDataIN._LETTER);
            password1_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            password1_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            password1_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);
            password2_.SetTypeDataIN(TypeDataIN._LETTER);
            password2_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            password2_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            password2_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);

            password1_.SetInactivated();
            password2_.SetInactivated();
            aceptar_.SetInactivated();
            salir_.SetInactivated();

            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            while (cont_event != 4)
            {
                if (cont_event == 0)
                {
                    salir_.SetInactivated();
                    switch (kscript)
                    {
                        case false: password1_.SetSemiInactivated(); break;
                        case true: password1_.SetActivated(); break;
                    }
                    salir_.Display(color.NEGRO, color.NEGRO);
                    aceptar_.Display(color.NEGRO, color.NEGRO);
                    password2_.Display(color.NEGRO, color.NEGRO);
                    password1_.Display(color.NEGRO, color.NEGRO);
                }
                if (cont_event == 1)
                {
                    password1_.SetInactivated();
                    switch (kscript)
                    {
                        case false: password2_.SetSemiInactivated(); break;
                        case true: password2_.SetActivated(); break;
                    }
                    salir_.Display(color.NEGRO, color.NEGRO);
                    aceptar_.Display(color.NEGRO, color.NEGRO);
                    password1_.Display(color.NEGRO, color.NEGRO);
                    password2_.Display(color.NEGRO, color.NEGRO);
                }
                if (cont_event == 2)
                {
                    password2_.SetInactivated();
                    switch (kscript)
                    {
                        case false: salir_.SetSemiInactivated(); break;
                        case true: salir_.SetActivated(); break;
                    }
                    password1_.Display(color.NEGRO, color.NEGRO);
                    password2_.Display(color.NEGRO, color.NEGRO);
                    aceptar_.Display(color.NEGRO, color.NEGRO);
                    salir_.Display(color.NEGRO, color.NEGRO);
                }
                if (cont_event == 3)
                {
                    salir_.SetInactivated();
                    switch (kscript)
                    {
                        case false: aceptar_.SetSemiInactivated(); break;
                        case true: aceptar_.SetActivated(); break;
                    }
                    password1_.Display(color.NEGRO, color.NEGRO);
                    password2_.Display(color.NEGRO, color.NEGRO);
                    salir_.Display(color.NEGRO, color.NEGRO);
                    aceptar_.Display(color.NEGRO, color.NEGRO);                    
                }
                if ((bool)salir_.GetDataInfo())
                {
                    dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._VOLVER);
                    kscript = true;
                    cont_event = 4;
                }
                if ((bool)aceptar_.GetDataInfo())
                {
                    string p1 = (string)password1_.GetDataInfo();
                    string p2 = (string)password2_.GetDataInfo();
                    bool k1 = FUNCTION.passwordcorrecto(p1);
                    bool k2 = FUNCTION.passwordcorrecto(p2);
                    bool k3 = p1.Equals(p2);
                    if (k1 && k2 && k3)
                    {
                        dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._PROCESS);
                        dt.PASS_FUTURE = p1;
                    } else { dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._MENSAGE3); }
                    kscript = true;
                    cont_event = 4;
                }
                if (!(kscript))
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    tecla = key_data.InputMode();
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
        public static void Mensage2(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S E R - I D   I N G R E S A D O   ", "   N O   V A L I D O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   U S E R - I D   ";
            mensaje[1] = "   E X I S T E N T E   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.ROJO, 100, 20);
            dt.USER_FUTURE = "";
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._IN_USER_ID);
        }
        public static void Volver(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._none);
            dt.SetMState(TypeState._LiveSysAdminIngreso, LiveProgram._INACTIVATED);
            if (dt.CONDICION_LISTA == LiveProgram._ACTIVATED)
            {
                dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._SysAdminLister, SysAdminLister._LISTADO);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_LISTER);
            }
            if (dt.CONDICION_LISTA == LiveProgram._INACTIVATED)
            {
                dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._SysAdmin, SysAdmin._MENU);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN);
            }
            dt.CONDICION_LISTA = LiveProgram._none;
            dt.POSITION = -1;
            dt.USER_FUTURE = "";
            dt.PASS_FUTURE = "";
            dt.USERCREATE = new Usuario();
            dt.CONDICION_LISTA = LiveProgram._none;
        }
        public static void Mensage1(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S E R - I D   I N G R E S A D O   ", "   N O   V A L I D O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[3];
            mensaje[0] = "   I N G R E S E   U N   ";
            mensaje[1] = "   U S E R - I D   ";
            mensaje[2] = "   C O R R E C T O   ";          
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._IN_USER_ID);
        }
        public static void UsuarioIngUser(ref BDState dt)
        {
            int kcount = 0;
            bool kscript = false;
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            IN key_data = new IN();
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backtitulobtn = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulobtn = { color.DARK_GRIS, color.DARK_ROJO, color.AZUL };

            IOdata.Selector(color.BLANCO, color.AZUL, "SysAdmin - Ingresar Usuarios al Sistema", 40, 90, 8);

            string[] identificacion = { " nombre y apellido: ", dt.USERCREATE.IdentidadConcatenar() };
            string[] direccion = { "         direccion: ", dt.USERCREATE.ConcatenarDireccion1() };
            string[] direccion2 = { "                    ", dt.USERCREATE.ConcatenarDireccion2() };
            color[] back = { color.NEGRO, color.NEGRO };
            color[] fore = { color.CYAN, color.AZUL };
            OUT.PrintLine(identificacion, fore, back, 24, 14);
            OUT.PrintLine(direccion, fore, back, 24, 16);
            OUT.PrintLine(direccion2, fore, back, 24, 17);

            IODATAINFO userid_ = new IODATAINFO(" USER-ID ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 120, 13);
            IOBUTTON aceptar_ = new IOBUTTON("    ACEPTAR    ", backcorral, forecorral, backtitulobtn, foretitulobtn, TypeLine._DOUBLE, 120, 22);
            IOBUTTON salir_ = new IOBUTTON("     SALIR     ", backcorral, forecorral, backtitulobtn, foretitulobtn, TypeLine._DOUBLE, 150, 22);
            userid_.SetTypeDataIN(TypeDataIN._LETTER);
            userid_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);            
            userid_.SetDataInfo((string)"");

            userid_.SetInactivated();
            aceptar_.SetInactivated();
            salir_.SetInactivated();

            
            while(kcount != 3)
            {
                if (kcount == 0)
                {
                    salir_.SetInactivated();
                    switch(kscript)
                    {
                        case false: userid_.SetSemiInactivated(); break;
                        case true: userid_.SetActivated(); break;
                    }
                    salir_.Display(color.NEGRO, color.NEGRO);
                    aceptar_.Display(color.NEGRO, color.NEGRO);
                    userid_.Display(color.NEGRO, color.NEGRO);
                }
                if (kcount == 1)
                {
                    userid_.SetInactivated();
                    switch (kscript)
                    {
                        case false: aceptar_.SetSemiInactivated(); break;
                        case true: aceptar_.SetActivated(); break;
                    }
                    userid_.Display(color.NEGRO, color.NEGRO);
                    salir_.Display(color.NEGRO, color.NEGRO);
                    aceptar_.Display(color.NEGRO, color.NEGRO);                    
                }
                if (kcount == 2)
                {
                    aceptar_.SetInactivated();
                    switch (kscript)
                    {
                        case false: salir_.SetSemiInactivated(); break;
                        case true: salir_.SetActivated(); break;
                    }
                    userid_.Display(color.NEGRO, color.NEGRO);
                    aceptar_.Display(color.NEGRO, color.NEGRO);
                    salir_.Display(color.NEGRO, color.NEGRO);                                        
                }
                if ((bool)salir_.GetDataInfo())
                {
                    dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._VOLVER);
                    kscript = true;
                    kcount = 3;
                }
                if ((bool)aceptar_.GetDataInfo())
                {
                    dt.USER_FUTURE = FUNCTION.usuariominuscula((string)userid_.GetDataInfo());
                    kscript = true;
                    kcount = 3;
                    if (dt.USER_FUTURE.Length > 5)
                    {
                        dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._IN_PASSWORD);
                        Usuario seek = new Usuario();
                        CodigoEnigma cod = new CodigoEnigma();
                        string valor = "0";
                        string kt = @Directory.GetCurrentDirectory();
                        string kt_load = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram.dat");
                        StreamReader sr = new StreamReader(kt_load);
                        bool script = false;

                        while (valor != null)
                        {
                            valor = sr.ReadLine();
                            if (valor != null)
                            {
                                if (!(script))
                                {
                                    string coddesencriptado = cod.Desencriptador(valor);
                                    seek.Desconcatenar(coddesencriptado);
                                    if ((String.Compare(seek.UserID, dt.USER_FUTURE)) == 0)
                                    {
                                        dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._MENSAGE2);
                                        script = true;
                                        dt.USER_FUTURE = "";
                                    }
                                }
                            }
                        }
                        sr.Close();
                    }
                    else
                    {
                        dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._MENSAGE1);
                        dt.USER_FUTURE = "";
                    }
                }
                if (!(kscript))
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if (tecla.Equals("TAB"))
                    {
                        kcount++;
                        if (kcount == 4) { kcount = 0; }
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
    }
}
