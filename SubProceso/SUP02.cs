using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PCD_ScreemDisplay;
using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;
using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class SUP02
    {
        public static void Passrouter(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            CodigoEnigma codigoenigma = new CodigoEnigma();
            string kt = @Directory.GetCurrentDirectory();
            string kt_load = kt.Replace(@"\bin\Debug", @"\BaseData\DolarPeso.dat");            
            StreamReader dolar = new StreamReader(kt_load);
            
            string dolar_encriptado = dolar.ReadLine();
            string dolar_decriptado = codigoenigma.Desencriptador(dolar_encriptado);
            
            dolar.Close();

            dt.DOLARPESOS = Convert.ToSingle(dolar_decriptado);

            dt.SetMState(TypeState._LoginUserPass, LoginUser._none);
            dt.SetMState(TypeState._LiveLoginUserPass, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._StateMain, StateMain._SYSTEM_USER);
            dt.SetMState(TypeState._LiveSystemUser, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SystemUser, SystemUser._PRESENTADOR);
        }
        public static void AccesoPermitido(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "     A C C E S O     ", "    P E R M I T I D O    " };
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.DARK_CYAN, 100, 20);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._PASS);
        }
        public static void Verificador(ref BDState dt)
        {
            string kt = @Directory.GetCurrentDirectory();
            string kt_load = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram.dat");
            string kt_save = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram-temp.dat");
            string valor = "0";
            dt.SetMState(TypeState._LoginUserPass, LoginUser._USER_INEXIT);
            StreamReader sr = new StreamReader(kt_load);
            StreamWriter sw = new StreamWriter(kt_save);

            CodigoEnigma cod = new CodigoEnigma();
            Usuario seek = new Usuario();
            bool script = true;
            while (valor != null)
            {
                valor = sr.ReadLine();
                if (valor != null)                 
                {
                    if (script)
                    {
                        seek.Desconcatenar(cod.Desencriptador(valor));  // <---- ingresa el usuario a verificar

                        if ((String.Compare(seek.UserID, dt.USERSESION.UserID)) == 0) //<--- verifica si es el mismo usuario
                        {
                            script = false;
                            // verificar si el usuario esta habilitado.
                            if ((seek.StHabilitacion()) == 0)
                            {
                                // verificar si el usuario posee la cuenta expirada.
                                if (seek.StExpirated())
                                {
                                    // verificar si el usuario posee la contraseña expirada
                                    if (seek.StExpPassword())
                                    {
                                        // verificar si el usuario esta blockeado de password
                                        if (seek.StBlockPass())
                                        {
                                            // verificar si el usuario esta blockeado simple
                                            if (seek.StBlocked())
                                            {
                                                // verificar si la contraseñas son iguales
                                                if ((String.Compare(seek.Password, dt.USERSESION.Password)) == 0)
                                                {
                                                    seek.ResetearBloqueos();
                                                    dt.USERSESION = seek;
                                                    dt.SetMState(TypeState._LoginUserPass, LoginUser._ACCESS_ACEPTADED);                                                    
                                                }
                                                else
                                                {
                                                    // si las contraseñas son distintas se procedo al incremento del contador
                                                    seek.IncrementarBlockeos();
                                                    dt.SetMState(TypeState._LoginUserPass, LoginUser._ACCESS_DENEGATED);
                                                    if (!(seek.StBlockPass())) { dt.SetMState(TypeState._LoginUserPass, LoginUser._USER_BLOCKED_PASS); }
                                                    if (!(seek.StBlocked())) { dt.SetMState(TypeState._LoginUserPass, LoginUser._USER_BLOCKED); }
                                                }
                                            }
                                            else
                                            {
                                                // si el usuario esta bloqueado simple emitimos un mensaje
                                                dt.SetMState(TypeState._LoginUserPass, LoginUser._USER_BLOCKED);
                                            }
                                        }
                                        else
                                        {
                                            // si el usuario esta bloqueado de password emitimos un mensaje
                                            dt.SetMState(TypeState._LoginUserPass, LoginUser._USER_BLOCKED_PASS);
                                        }
                                    }
                                    else
                                    {
                                        // si el usuario posee su cuenta con la contraseña expirada emitira un mensaje
                                        dt.SetMState(TypeState._LoginUserPass, LoginUser._USER_EXPIRATED_PASS);
                                    }
                                }
                                else
                                {
                                    // si el usuario posee su cuenta expirada emitira un mensaje
                                    dt.SetMState(TypeState._LoginUserPass, LoginUser._USER_EXPIRATED);
                                }

                            }
                            else
                            {
                                // si el usuario esta deshabilitado emitimos un mensaje.
                                dt.SetMState(TypeState._LoginUserPass, LoginUser._USER_INHABILITARY);
                            }
                        }
                        valor = cod.Encriptador(seek.Concatenar());
                    }
                    sw.WriteLine(valor);
                }
            }
            sr.Close();
            sw.Close();

            // eliminar el archivo original
            File.Delete(kt_load);
            // modificar el archivo temporario a archivo original
            File.Move(kt_save, kt_load);
        }

        public static void AccesoDenegado(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S U A R I O   o   C O N T R A S E Ñ A   ", "   I N C O R R E C T A   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.MAGENTA, 100, 20);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._PRESENT);
        }
        public static void UsuarioFechaExpPassword(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S U A R I O   ", "   E X P I R A D O   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.AZUL, 100, 20);
            mensaje = new string[5];
            mensaje[0] = "   C O M U N I Q U E S E   ";
            mensaje[1] = "   C O N   ";
            mensaje[2] = "   E L   C E N T R O   D E   ";
            mensaje[3] = "   A T E N C I O N   ";
            mensaje[4] = "   A L   U S U A R I O   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.ROJO, color.AZUL, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   R E N U E V E   L A   C O N T R A S E Ñ A   ";
            mensaje[1] = "   D E   S U   U S U A R I O   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._PRESENT);
        }
        public static void UsuarioFechaExpiracion(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S U A R I O   ", "   E X P I R A D O   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.AZUL, 100, 20);
            mensaje = new string[5];
            mensaje[0] = "   C O M U N I Q U E S E   ";
            mensaje[1] = "   C O N   ";
            mensaje[2] = "   E L   C E N T R O   D E   ";
            mensaje[3] = "   A T E N C I O N   ";
            mensaje[4] = "   A L   U S U A R I O   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.ROJO, color.AZUL, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   R E N U E V E   L A   F E C H A   ";
            mensaje[1] = "   D E   E X P I R A C I O N   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._PRESENT);
        }
        public static void UsuarioBloqueado(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S U A R I O   ", "   B L O Q U E A D O   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.AZUL, 100, 20);
            mensaje = new string[5];
            mensaje[0] = "   C O M U N I Q U E S E   ";
            mensaje[1] = "   C O N   ";
            mensaje[2] = "   E L   C E N T R O   D E   ";
            mensaje[3] = "   A T E N C I O N   ";
            mensaje[4] = "   A L   U S U A R I O   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.ROJO, color.AZUL, 100, 20);
            mensaje = new string[3];
            mensaje[0] = "   R E A L I C E   E L   ";
            mensaje[1] = "   D E S B L O Q U E O   D E   ";
            mensaje[2] = "   S U   U S U A R I O   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._PRESENT);
        }
        public static void UsuarioBloqueadoPassword(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S U A R I O   ", "   B L O Q U E A D O   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.AZUL, 100, 20);
            mensaje = new string[5];
            mensaje[0] = "   C O M U N I Q U E S E   ";
            mensaje[1] = "   C O N   ";
            mensaje[2] = "   E L   C E N T R O   D E   ";
            mensaje[3] = "   A T E N C I O N   ";
            mensaje[4] = "   A L   U S U A R I O   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.ROJO, color.AZUL, 100, 20);
            mensaje = new string[3];
            mensaje[0] = "   R E A L I C E   E L   ";
            mensaje[1] = "   B L A N Q U E O   D E   ";
            mensaje[2] = "   C O N T R A S E Ñ A   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.ROJO, color.AZUL, 100, 20);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._PRESENT);
        }
        public static void UsuarioDeshabilitado(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S U A R I O   ", "   N O   H A B I L I T A D O   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.AZUL, 100, 20);
            mensaje = new string[5];
            mensaje[0] = "   C O M U N I Q U E S E   ";
            mensaje[1] = "   C O N   ";
            mensaje[2] = "   E L   C E N T R O   D E   ";
            mensaje[3] = "   A T E N C I O N   ";
            mensaje[4] = "   A L   U S U A R I O   ";
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.ROJO, color.AZUL, 100, 20);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._PRESENT);
        }
        public static void UsuarioInexistente(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S U A R I O   ", "   I N E X I S T E N T E   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._PRESENT);
        }
        public static void Salida(ref BDState dt)
        {
            dt.SetMState(TypeState._LoginUserPass, LoginUser._none);
            dt.SetMState(TypeState._LiveLoginUserPass, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._StateMain, StateMain._SALIDA);
        }
        public static void IngresoUserPass(ref BDState dt)
        {
            int posicion = 0;
            bool script = false;
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backtitulobtn = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulobtn = { color.DARK_GRIS, color.DARK_ROJO, color.AZUL };
            IN key_data = new IN();
            IODATAINFO userid = new IODATAINFO("  User-ID ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 40, 30, 90, 12);
            IODATAINFO password = new IODATAINFO(" Password ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._PASSWORD, 40, 30, 90, 17);
            IOBUTTON aceptar = new IOBUTTON("    ACEPTAR    ", backcorral, forecorral, backtitulobtn, foretitulobtn, TypeLine._DOUBLE, 90, 22);
            IOBUTTON salir   = new IOBUTTON("     SALIR     ", backcorral, forecorral, backtitulobtn, foretitulobtn, TypeLine._DOUBLE, 123, 22);

            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            userid.SetTypeDataIN(TypeDataIN._LETTER);
            userid.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            userid.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);

            password.SetTypeDataIN(TypeDataIN._LETTER);
            password.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            password.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            password.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);

            while (posicion < 4)
            {
                if (posicion == 0)
                {
                    password.SetInactivated();
                    aceptar.SetInactivated();
                    salir.SetInactivated();
                    switch(script)
                    {
                        case (false): userid.SetSemiInactivated(); break;
                        case (true): userid.SetActivated(); break;
                    }
                    password.Display(color.NEGRO, color.NEGRO);
                    aceptar.Display(color.NEGRO, color.NEGRO);
                    salir.Display(color.NEGRO, color.NEGRO);
                    userid.Display(color.NEGRO, color.NEGRO);
                }
                if (posicion == 1)
                {
                    userid.SetInactivated();
                    aceptar.SetInactivated();
                    salir.SetInactivated();
                    switch (script)
                    {
                        case (false): password.SetSemiInactivated(); break;
                        case (true): password.SetActivated(); break;
                    }
                    userid.Display(color.NEGRO, color.NEGRO);
                    aceptar.Display(color.NEGRO, color.NEGRO);
                    salir.Display(color.NEGRO, color.NEGRO);
                    password.Display(color.NEGRO, color.NEGRO);
                }
                if (posicion == 2)
                {
                    userid.SetInactivated();
                    password.SetInactivated();
                    salir.SetInactivated();
                    switch (script)
                    {
                        case (false): aceptar.SetSemiInactivated(); break;
                        case (true): aceptar.SetActivated(); break;
                    }
                    userid.Display(color.NEGRO, color.NEGRO);
                    password.Display(color.NEGRO, color.NEGRO);
                    salir.Display(color.NEGRO, color.NEGRO);
                    aceptar.Display(color.NEGRO, color.NEGRO);
                }
                if (posicion == 3)
                {
                    userid.SetInactivated();
                    password.SetInactivated();
                    aceptar.SetInactivated();
                    switch (script)
                    {
                        case (false): salir.SetSemiInactivated(); break;
                        case (true): salir.SetActivated(); break;
                    }
                    userid.Display(color.NEGRO, color.NEGRO);
                    password.Display(color.NEGRO, color.NEGRO);
                    aceptar.Display(color.NEGRO, color.NEGRO);
                    salir.Display(color.NEGRO, color.NEGRO);
                }                
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if (tecla.Equals("TAB"))
                    {
                        posicion++;
                        if (posicion == 4) { posicion = 0; }
                    }
                    else { if (tecla.Equals("ENTER")) { script = true; } }
                } else 
                { 
                    if ((posicion == 2) || (posicion == 3))
                    {
                        System.Threading.Thread.Sleep(1000);
                        switch(posicion)
                        {
                            case 2: dt.USERSESION.UserID = UsuarioMinuscula(userid.GetDataInfo().ToString());
                                    dt.USERSESION.Password = password.GetDataInfo().ToString();
                                    dt.SetMState(TypeState._LoginUserPass, LoginUser._VERIFICAR); 
                                    break;
                                
                            case 3: dt.SetMState(TypeState._LoginUserPass, LoginUser._SALIR); break;
                        }
                        posicion = 4;
                    }
                    script = false; 
                }                
            }
        }
        public static void Presentacion(ref BDState dt)
        {            
            Console.Clear();
            COLOR.ColorFondo(color.DARK_GRIS);
            DRAW.CuadradoSolid(color.MAGENTA, dt.WIDTH - 6, dt.HEINGHT - 8, 2, 3);
            DRAW.CuadradoSolid(color.DARK_GRIS, dt.WIDTH - 10, dt.HEINGHT - 10, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, 65, 17, (dt.WIDTH / 2) - 32, (dt.HEINGHT / 2) - 17);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._LOGIN);
        }
        public static void Display(ref BDState dt)
        {
            ScreemDisplay display = new ScreemDisplay();
            display.MonitorSize();
            dt.WIDTH = display.WIDTH;
            dt.HEINGHT = display.HEIGTH;
            dt.SetMState(TypeState._LoginUserPass, LoginUser._PRESENT);
        }
        private static string UsuarioMinuscula(string userid)
        {
            string valor = "";
            Char[] cadena = userid.ToCharArray();
            for(int i = 0; i < cadena.Length; i++)
            {
                if ((cadena[i] >= 65) && (cadena[i] <= 90))
                {
                    valor += ((char)(((int)cadena[i]) + 32)).ToString();
                } else { valor += cadena[i].ToString(); }
            }
            return (valor);
        }
    }

}
