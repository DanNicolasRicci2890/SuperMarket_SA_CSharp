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
    public  class SUP07
    {
        public static void MensageP8(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   L O S   D A T O S   ",
                                 "   H A N   S I D O   ",
                                 "   M O D I F I C A D O   ",
                                 "   E N   L A   B A S E   ",
                                 "   D  E   ",
                                 "   D  A  T  O  S   " };
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.DARK_CYAN, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._VOLVER);
        }
        public static void MensageP7(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   L O S   D A T O S   ", 
                                 "   H A N   S I D O   ", 
                                 "   G U A R D A D O   ", 
                                 "   E N   L A   B A S E   ", 
                                 "   D  E   ", 
                                 "   D  A  T  O  S   " };
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.DARK_CYAN, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);
        }
        public static void SaveUsers2(ref BDState dt)
        {
            FDUsuario cond = new FDUsuario("ListUserProgram");

            // cargar la lista de usuarios
            cond.LoadListUser();

            // ingresar el usuario modificado a la lista
            cond.ReplaceListUser(dt.USERCREATE, dt.POSITION);

            // ordenar la lista de usuario
            cond.BurbujaListUser();

            // guardar la lista de usuario al archivo
            cond.SaveListUser();
            
            dt.USERCREATE = new Usuario();
            dt.POSITION = -1;
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._MENSAGE8);
        }
        public static void SaveUsers1(ref BDState dt)
        {
            FDUsuario cond = new FDUsuario("ListUserProgram");

            // cargar la lista de usuarios
            cond.LoadListUser();

            // ingresar el nuevo usuario a la lista
            cond.AddListUser(dt.USERCREATE);

            // ordenar la lista de usuario
            cond.BurbujaListUser();

            // guardar la lista de usuario al archivo
            cond.SaveListUser();
            dt.USERCREATE = new Usuario();
            dt.POSITION = -1;
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._MENSAGE7);
        }
        public static void MensageP6(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O R R E C T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[4];
            mensaje[0] = "   E L   L E G A J O   ";
            mensaje[1] = "   I N G R E S A D O   ";
            mensaje[2] = "   S E    E N C U E N T R A   ";
            mensaje[3] = "   E X I S T E N T E   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje[0] = "   I N G R E S E   ";
            mensaje[1] = "   O T R O   ";
            mensaje[2] = "   L E G A J O   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);
        }
        public static void Verificacion3_2(ref BDState dt)
        {
            string kt = @Directory.GetCurrentDirectory();
            string kt_load = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram.dat");
            string kt_save = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram-temp.dat");
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._SAVE2);
            StreamReader sr = new StreamReader(kt_load);
            StreamWriter sw = new StreamWriter(kt_save);
            string valor = "0";
            int contador_legajo = -1;
            CodigoEnigma cod = new CodigoEnigma();
            Usuario seek = new Usuario();

            while (valor != null)
            {
                valor = sr.ReadLine();
                if (valor != null)
                {
                    contador_legajo++;
                    seek.Desconcatenar(cod.Desencriptador(valor));                    
                    if ((seek.Legajo.Equals(dt.USERCREATE.Legajo)) && (contador_legajo != dt.POSITION))
                    {
                        dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._MENSAGE6);
                    }
                    valor = cod.Encriptador(seek.Concatenar());
                    sw.WriteLine(valor);
                }
            }
            sr.Close();
            sw.Close();
            File.Delete(kt_load);
            File.Move(kt_save, kt_load);
        }
        public static void Verificacion3_1(ref BDState dt)
        {
            string kt = @Directory.GetCurrentDirectory();
            string kt_load = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram.dat");
            string kt_save = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram-temp.dat");
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._SAVE1);
            StreamReader sr = new StreamReader(kt_load);
            StreamWriter sw = new StreamWriter(kt_save);
            string valor = "0";            
            CodigoEnigma cod = new CodigoEnigma();
            Usuario seek = new Usuario();

            while (valor != null)
            {
                valor = sr.ReadLine(); 
                if (valor != null)
                {
                    seek.Desconcatenar(cod.Desencriptador(valor));                    
                    if (seek.Legajo.Equals(dt.USERCREATE.Legajo))
                    {
                        dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._MENSAGE6);
                    }
                    valor = cod.Encriptador(seek.Concatenar());
                    sw.WriteLine(valor);
                }
            }
            sr.Close();
            sw.Close();
            File.Delete(kt_load);
            File.Move(kt_save, kt_load);
        }
        public static void MensageP5(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O R R E C T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje = new string[4];
            mensaje[0] = "   E L   D . N . I .   ";
            mensaje[1] = "   I N G R E S A D O   ";
            mensaje[2] = "   S E    E N C U E N T R A   ";
            mensaje[3] = "   E X I S T E N T E   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje[0] = "   I N G R E S E   ";
            mensaje[1] = "   O T R O   ";
            mensaje[2] = "   D . N . I .   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);
        }
        public static void Verificacion2_1(ref BDState dt)
        {
            string kt = @Directory.GetCurrentDirectory();
            string kt_load = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram.dat");
            string kt_save = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram-temp.dat");
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._VERIFICACION3_1);
            StreamReader sr = new StreamReader(kt_load);
            StreamWriter sw = new StreamWriter(kt_save);
            string valor = "0";
            
            CodigoEnigma cod = new CodigoEnigma();
            Usuario seek = new Usuario();

            while (valor != null)
            {
                valor = sr.ReadLine();
                if (valor != null)
                {
                    seek.Desconcatenar(cod.Desencriptador(valor));
                    if (seek.DNI.Equals(dt.USERCREATE.DNI))
                    {
                        dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._MENSAGE5);
                    }
                    valor = cod.Encriptador(seek.Concatenar());
                    sw.WriteLine(valor);
                }
            }
            sr.Close();
            sw.Close();
            File.Delete(kt_load);
            File.Move(kt_save, kt_load);
        }
        public static void Verificacion2_2(ref BDState dt) 
        {
            string kt = @Directory.GetCurrentDirectory();
            string kt_load = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram.dat");
            string kt_save = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram-temp.dat");
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._VERIFICACION3_2);
            StreamReader sr = new StreamReader(kt_load);
            StreamWriter sw = new StreamWriter(kt_save);
            string valor = "0";
            int contador_dni = -1;
            CodigoEnigma cod = new CodigoEnigma();
            Usuario seek = new Usuario();

            while (valor != null)
            {
                valor = sr.ReadLine();
                if (valor != null)
                {
                    contador_dni++;
                    seek.Desconcatenar(cod.Desencriptador(valor));
                    if ((seek.DNI.Equals(dt.USERCREATE.DNI)) && (contador_dni != dt.POSITION))
                    {
                        dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._MENSAGE5);
                    }
                    valor = cod.Encriptador(seek.Concatenar());
                    sw.WriteLine(valor);
                }                
            }
            sr.Close();
            sw.Close();
            File.Delete(kt_load);
            File.Move(kt_save, kt_load);           
        }
        public static void MensageP4(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   E L   L E G A J O   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);
        }
        public static void MensageP3(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   E L   D . N . I .   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);
        }
        public static void MensageP2(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   E L   N O M B R E   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);            
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);
        }
        public static void MensageP1(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   D A T O S   ", "   I N C O M P L E T O S   " };
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            mensaje[0] = "   F A L T A   ";
            mensaje[1] = "   E L   A P E L L I D O   ";
            FUNCTION.Mensagedata(mensaje, color.AMARILLO, color.ROJO, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);            
        }
        public static void Verificacion1(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._MENSAGE1);
            if (!(dt.USERCREATE.ApellidoP.Equals("")))
            {
                dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._MENSAGE2);
                if (!(dt.USERCREATE.Nombre.Equals("")))
                {
                    dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._MENSAGE3);
                    if (!(dt.USERCREATE.DNI.Equals("")))
                    {
                        dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._MENSAGE4);
                        if (!(dt.USERCREATE.Legajo.Equals("0")))
                        {
                            switch(dt.CONDCREATE)
                            {
                                case (false): dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._VERIFICACION2_1); break;
                                case (true): dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._VERIFICACION2_2); break;
                            }                            
                        }
                    }
                }
            }
        }
        public static void Volver(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._none);
            dt.SetMState(TypeState._LiveSysAdminCreate, LiveProgram._INACTIVATED);
            if (dt.CONDICION_LISTA == LiveProgram._INACTIVATED)
            {
                dt.SetMState(TypeState._SysAdmin, SysAdmin._MENU);
                dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN);
            }
            if (dt.CONDICION_LISTA == LiveProgram._ACTIVATED)
            {
                dt.SetMState(TypeState._SysAdminLister, SysAdminLister._LISTADO);
                dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_LISTER);
            }
            dt.CONDICION_LISTA = LiveProgram._none;
        }
        public static void DataInfoUser(ref BDState dt)
        {
            bool estado = true, script = false;
            int contador = 0, tope = 20;
            IN key_data = new IN();
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backSelect = { color.DARK_GRIS, color.AMARILLO, color.DARK_GRIS, color.BLANCO };
            color[] backSelect2 = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.BLANCO };
            color[] foreSelect = { color.NEGRO, color.AZUL, color.NEGRO, color.VERDE };
            color[] foreSelect2 = { color.DARK_GRIS, color.GRIS, color.DARK_CYAN, color.DARK_ROJO, color.BLANCO, color.ROJO, color.AZUL };
            color[] backPointer = { color.NEGRO, color.BLANCO };
            color[] forePointer = { color.DARK_VERDE, color.MAGENTA };
            color[] backOption = { color.NEGRO, color.DARK_GRIS, color.NEGRO, color.DARK_VERDE, color.NEGRO, color.VERDE };
            color[] foreOption = { color.GRIS, color.CYAN, color.DARK_AZUL };

            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
                

            string[] SelectHome = { "Casa", "Depto" };

            key_data.SetCondIN(INCond._ENTER);
            key_data.SetCondIN(INCond._ARROWS);

            IODATAINFO ApelPa_ = new IODATAINFO(" Apellido Paterno ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 10, 10);
            IODATAINFO ApelMa_ = new IODATAINFO(" Apellido Materno ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 10, 15);
            IODATAINFO Nombre_ = new IODATAINFO("     Nombre ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 10, 20);
            IODATAINFO Nombre2do_ = new IODATAINFO("  2do Nombre ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 10, 25);
            IODATAINFO Legajo_ = new IODATAINFO("  Legajo ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 15, 12, 10, 30);
            IOMULTIDATA Dni_ = new IOMULTIDATA("  DNI ", "...", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, new int[] { 2, 3, 3 }, 42, 30);
            IOMULTIDATA Telefono_ = new IOMULTIDATA("  Telefono ", "-", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, new int[] { 4, 4 }, 10, 35);
            IOMULTIDATA Celular_ = new IOMULTIDATA("  Celular ", "--", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, new int[] { 2, 4, 4 }, 10, 40);
            
            IOCALENDAR FechNac_ = new IOCALENDAR("  Fecha de Nacimiento  ", backcorral, forecorral, backtitulo, foretitulo, backSelect, foreSelect, backPointer, forePointer, TypeLine._DOUBLE, 71, 10);

            IOMULTIDATA Email_ = new IOMULTIDATA("  Email ", "@", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, new int[] { 30, 30 }, 110, 10);
            IODATAINFO Direccion_ = new IODATAINFO(" Direccion ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 110, 15);
            IODATAINFO Nro_ = new IODATAINFO(" Nro ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 7, 5, 159, 15);
            IORADIO Home_ = new IORADIO("Casa o Depto", SelectHome, backcorral, forecorral, backtitulo, foretitulo, backSelect2, foreSelect2, backOption, foreOption, TypeLine._DOUBLE, 1, 179, 15);
            IODATAINFO Depto_ = new IODATAINFO("  Depto ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 5, 7, 196, 15);
            IODATAINFO CodPost_ = new IODATAINFO("  Cod. Postal ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 5, 7, 196, 20);
            IODATAINFO Provincia_ = new IODATAINFO(" Provincia ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 110, 20);
            IODATAINFO Localidad_ = new IODATAINFO(" Localidad ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 110, 25);
            IODATAINFO Pais_ = new IODATAINFO(" Pais ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 110, 30);

            IODATAINFO UserID_ = new IODATAINFO(" userid ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 20, 18, 71, 20);

            IOBUTTON btn_ACEPTAR_ = new IOBUTTON("   GUARDAR   ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 71, 45);
            IOBUTTON btn_ESCAPE_ = new IOBUTTON("    SALIR    ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 111, 45);

            if (dt.USERCREATE.UserID.Equals(""))
            {
                dt.USERCREATE.UserID = "no posee ID";
            }
            UserID_.SetDataInfo(dt.USERCREATE.UserID);

            ApelPa_.SetDataInfo(dt.USERCREATE.ApellidoP);
            ApelMa_.SetDataInfo(dt.USERCREATE.ApellidoM);
            Nombre_.SetDataInfo(dt.USERCREATE.Nombre);
            Nombre2do_.SetDataInfo(dt.USERCREATE.Nombre2do);
            Legajo_.SetDataInfo(dt.USERCREATE.Legajo);
            Dni_.SetDataInfo(dt.USERCREATE.DNI);
            Telefono_.SetDataInfo(dt.USERCREATE.Telefono);
            Celular_.SetDataInfo(dt.USERCREATE.Celular);
            Email_.SetDataInfo(dt.USERCREATE.ImprimirEmail());

            
            if (dt.USERCREATE.FechNac == 0)
            {
                dt.USERCREATE.FechNac = (DateTime.Now.Year * 10000) + 101;
            }
            FechNac_.SetDataInfo(dt.USERCREATE.FechNac);
            Direccion_.SetDataInfo(dt.USERCREATE.Direccion);
            Nro_.SetDataInfo(dt.USERCREATE.Nro);            
            Home_.SetDataInfo((CasaDepto)dt.USERCREATE.CasaDepto);
            Depto_.SetDataInfo(dt.USERCREATE.Depto);
            Provincia_.SetDataInfo(dt.USERCREATE.Provincia);
            Localidad_.SetDataInfo(dt.USERCREATE.Localidad);
            Pais_.SetDataInfo(dt.USERCREATE.Pais);
            CodPost_.SetDataInfo(dt.USERCREATE.CodPostal);
            btn_ACEPTAR_.SetDataInfo(false);
            btn_ESCAPE_.SetDataInfo(false);

            ApelPa_.SetTypeDataIN(TypeDataIN._LETTER);
            ApelPa_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            ApelPa_.SetTypeDataIN(TypeDataIN._SPACE);

            ApelMa_.SetTypeDataIN(TypeDataIN._LETTER);
            ApelMa_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            ApelMa_.SetTypeDataIN(TypeDataIN._SPACE);

            Nombre_.SetTypeDataIN(TypeDataIN._LETTER);
            Nombre_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Nombre_.SetTypeDataIN(TypeDataIN._SPACE);

            Nombre2do_.SetTypeDataIN(TypeDataIN._LETTER);
            Nombre2do_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Nombre2do_.SetTypeDataIN(TypeDataIN._SPACE);

            Legajo_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);

            Dni_.SetTypeDataIN(TypeDataIN._NUMERIC_PAD);

            Telefono_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);

            Celular_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);

            Email_.SetTypeDataIN(TypeDataIN._LETTER);
            Email_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Email_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Email_.SetTypeDataIN(TypeDataIN._SHIFT_NUMERIC_FILE);
            Email_.SetTypeDataIN(TypeDataIN._CARACTER_SPECIAL);
            Email_.SetTypeDataIN(TypeDataIN._SHIFT_CARACTER_SPECIAL);

            Direccion_.SetTypeDataIN(TypeDataIN._LETTER);
            Direccion_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Direccion_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Direccion_.SetTypeDataIN(TypeDataIN._SPACE);

            Nro_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);

            Depto_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Depto_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Depto_.SetTypeDataIN(TypeDataIN._SPACE);

            CodPost_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);

            Provincia_.SetTypeDataIN(TypeDataIN._LETTER);
            Provincia_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Provincia_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Provincia_.SetTypeDataIN(TypeDataIN._SPACE);

            Localidad_.SetTypeDataIN(TypeDataIN._LETTER);
            Localidad_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Localidad_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
            Localidad_.SetTypeDataIN(TypeDataIN._SPACE);

            Pais_.SetTypeDataIN(TypeDataIN._LETTER);
            Pais_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
            Pais_.SetTypeDataIN(TypeDataIN._SPACE);

            while (estado)
            {
                UserID_.SetInactivated();
                ApelPa_.SetInactivated();
                ApelMa_.SetInactivated();
                Nombre_.SetInactivated();
                Nombre2do_.SetInactivated();
                Legajo_.SetInactivated();
                Dni_.SetInactivated();
                Telefono_.SetInactivated();
                Celular_.SetInactivated();
                Email_.SetInactivated();
                FechNac_.SetInactivated();
                Direccion_.SetInactivated();
                Nro_.SetInactivated();
                Home_.SetInactivated();
                Depto_.SetInactivated();
                CodPost_.SetInactivated();
                Provincia_.SetInactivated();
                Localidad_.SetInactivated();
                Pais_.SetInactivated();
                btn_ACEPTAR_.SetInactivated();
                btn_ESCAPE_.SetInactivated();

                if (!script)
                {
                    switch (contador)
                    {
                        case 0: ApelPa_.SetSemiInactivated(); break;
                        case 1: ApelMa_.SetSemiInactivated(); break;
                        case 2: Nombre_.SetSemiInactivated(); break;
                        case 3: Nombre2do_.SetSemiInactivated(); break;
                        case 4: Legajo_.SetSemiInactivated(); break;
                        case 5: Dni_.SetSemiInactivated(); break;
                        case 6: Telefono_.SetSemiInactivated(); break;
                        case 7: Celular_.SetSemiInactivated(); break;
                        case 8: FechNac_.SetSemiInactivated(); break; 
                        case 9: Email_.SetSemiInactivated(); break;
                        case 10: Direccion_.SetSemiInactivated(); break;
                        case 11: Nro_.SetSemiInactivated(); break;
                        case 12: Home_.SetSemiInactivated(); break;
                        case 13: Depto_.SetSemiInactivated(); break;
                        case 14: CodPost_.SetSemiInactivated(); break;
                        case 15: Provincia_.SetSemiInactivated(); break;
                        case 16: Localidad_.SetSemiInactivated(); break;
                        case 17: Pais_.SetSemiInactivated(); break;
                        case 18: btn_ACEPTAR_.SetSemiInactivated(); break;
                        case 19: btn_ESCAPE_.SetSemiInactivated(); break;
                    }
                }
                if (script)
                {
                    switch (contador)
                    {
                        case 0: ApelPa_.SetActivated(); break;
                        case 1: ApelMa_.SetActivated(); break;
                        case 2: Nombre_.SetActivated(); break;
                        case 3: Nombre2do_.SetActivated(); break;
                        case 4: Legajo_.SetActivated(); break;
                        case 5: Dni_.SetActivated(); break;
                        case 6: Telefono_.SetActivated(); break;
                        case 7: Celular_.SetActivated(); break;
                        case 8: FechNac_.SetActivated(); break;
                        case 9: Email_.SetActivated(); break;                        
                        case 10: Direccion_.SetActivated(); break;
                        case 11: Nro_.SetActivated(); break;
                        case 12: Home_.SetActivated(); break;
                        case 13: Depto_.SetActivated(); break;
                        case 14: CodPost_.SetActivated(); break;
                        case 15: Provincia_.SetActivated(); break;
                        case 16: Localidad_.SetActivated(); break;
                        case 17: Pais_.SetActivated(); break;
                        case 18: btn_ACEPTAR_.SetActivated(); break;
                        case 19: btn_ESCAPE_.SetActivated(); break;
                    }
                }
                UserID_.Display(color.NEGRO, color.NEGRO);
                for (int i = 0; i < tope; i++)
                {
                    if (i != contador)
                    {
                        switch (i)
                        {
                            case 0: ApelPa_.Display(color.NEGRO, color.NEGRO); break;
                            case 1: ApelMa_.Display(color.NEGRO, color.NEGRO); break;
                            case 2: Nombre_.Display(color.NEGRO, color.NEGRO); break;
                            case 3: Nombre2do_.Display(color.NEGRO, color.NEGRO); break;
                            case 4: Legajo_.Display(color.NEGRO, color.NEGRO); break;
                            case 5: Dni_.Display(color.NEGRO, color.NEGRO); break;
                            case 6: Telefono_.Display(color.NEGRO, color.NEGRO); break;
                            case 7: Celular_.Display(color.NEGRO, color.NEGRO); break;
                            case 8: FechNac_.Display(color.NEGRO, color.NEGRO); break;
                            case 9: Email_.Display(color.NEGRO, color.NEGRO); break;
                            case 10: Direccion_.Display(color.NEGRO, color.NEGRO); break;
                            case 11: Nro_.Display(color.NEGRO, color.NEGRO); break;
                            case 12: Home_.Display(color.NEGRO, color.NEGRO); break;
                            case 13: Depto_.Display(color.NEGRO, color.NEGRO); break;
                            case 14: CodPost_.Display(color.NEGRO, color.NEGRO); break;
                            case 15: Provincia_.Display(color.NEGRO, color.NEGRO); break;
                            case 16: Localidad_.Display(color.NEGRO, color.NEGRO); break;
                            case 17: Pais_.Display(color.NEGRO, color.NEGRO); break;
                            case 18: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                            case 19: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                        }
                    }
                }
                switch (contador)
                {
                    case 0: ApelPa_.Display(color.NEGRO, color.NEGRO); break;
                    case 1: ApelMa_.Display(color.NEGRO, color.NEGRO); break;
                    case 2: Nombre_.Display(color.NEGRO, color.NEGRO); break;
                    case 3: Nombre2do_.Display(color.NEGRO, color.NEGRO); break;
                    case 4: Legajo_.Display(color.NEGRO, color.NEGRO); break;
                    case 5: Dni_.Display(color.NEGRO, color.NEGRO); break;
                    case 6: Telefono_.Display(color.NEGRO, color.NEGRO); break;
                    case 7: Celular_.Display(color.NEGRO, color.NEGRO); break;
                    case 8: FechNac_.Display(color.NEGRO, color.NEGRO); break;
                    case 9: Email_.Display(color.NEGRO, color.NEGRO); break;
                    case 10: Direccion_.Display(color.NEGRO, color.NEGRO); break;
                    case 11: Nro_.Display(color.NEGRO, color.NEGRO); break;
                    case 12: Home_.Display(color.NEGRO, color.NEGRO); break;
                    case 13: Depto_.Display(color.NEGRO, color.NEGRO); break;
                    case 14: CodPost_.Display(color.NEGRO, color.NEGRO); break;
                    case 15: Provincia_.Display(color.NEGRO, color.NEGRO); break;
                    case 16: Localidad_.Display(color.NEGRO, color.NEGRO); break;
                    case 17: Pais_.Display(color.NEGRO, color.NEGRO); break;
                    case 18: btn_ACEPTAR_.Display(color.NEGRO, color.NEGRO); break;
                    case 19: btn_ESCAPE_.Display(color.NEGRO, color.NEGRO); break;
                }

                if ((bool)btn_ACEPTAR_.GetDataInfo())
                {
                    dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._VERIFICACION1);
                    dt.USERCREATE.ApellidoP = ApelPa_.GetDataInfo().ToString();
                    dt.USERCREATE.ApellidoM = ApelMa_.GetDataInfo().ToString();
                    dt.USERCREATE.Nombre = Nombre_.GetDataInfo().ToString();
                    dt.USERCREATE.Nombre2do = Nombre2do_.GetDataInfo().ToString();
                    dt.USERCREATE.Legajo = Legajo_.GetDataInfo().ToString();
                    dt.USERCREATE.DNI = Dni_.GetDataInfo().ToString();
                    if ((Telefono_.GetDataInfo().ToString()).Equals("-"))
                    {
                        dt.USERCREATE.Telefono = "";                        
                    } else { dt.USERCREATE.Telefono = Telefono_.GetDataInfo().ToString(); }
                    if ((Celular_.GetDataInfo().ToString()).Equals("--"))
                    {
                        dt.USERCREATE.Celular = "";
                    }
                    else { dt.USERCREATE.Celular = Celular_.GetDataInfo().ToString(); }
                    dt.USERCREATE.FechNac = (int)FechNac_.GetDataInfo();
                    dt.USERCREATE.Email = Usuario.DesconcatenarEmail(Email_.GetDataInfo().ToString());
                    dt.USERCREATE.Direccion = Direccion_.GetDataInfo().ToString();
                    dt.USERCREATE.Nro = Convert.ToInt32(Nro_.GetDataInfo().ToString());
                    dt.USERCREATE.CasaDepto = (CasaDepto)Home_.GetDataInfo();
                    dt.USERCREATE.Depto = Depto_.GetDataInfo().ToString();
                    dt.USERCREATE.CodPostal = Convert.ToInt32(CodPost_.GetDataInfo().ToString());
                    dt.USERCREATE.Provincia = Provincia_.GetDataInfo().ToString();
                    dt.USERCREATE.Localidad = Localidad_.GetDataInfo().ToString();
                    dt.USERCREATE.Pais = Pais_.GetDataInfo().ToString();

                    // verificar si es crear o modificar
                    if (!(dt.CONDCREATE))
                    {
                        dt.USERCREATE.StHabilitadorOFF();
                    }                    
                    estado = false;
                    script = true;
                }
                if ((bool)btn_ESCAPE_.GetDataInfo())
                {
                    dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._VOLVER);                    
                    estado = false;
                    script = true;
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();

                    if (tecla.Equals("RIGHTARROW"))
                    {
                        contador++;
                        if (contador == tope) { contador = 0; }
                    }
                    else
                    {
                        if (tecla.Equals("LEFTARROW"))
                        {
                            contador--;
                            if (contador < 0) { contador = tope - 1; }
                        }
                        else
                        {
                            if (tecla.Equals("ENTER")) { script = true; }
                        }                        
                    }
                } else { script = false; }                                
            }                        
        }
        public static void Presentador(ref BDState dt)
        {
            string deg = "SysAdmin - Seguridad Informatica - ";
            int front = 0, direct = 0;
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            switch(dt.CONDCREATE) 
            {
                case (true): deg = String.Concat(deg, "Modificar"); front = 54; direct = 87; break;
                case (false): deg = String.Concat(deg, "Crear"); front = 50; direct = 87; break;
            }
            deg = String.Concat(deg, " Usuario");
            DRAW.CuadradoSolid(color.BLANCO, front, 1, direct, 6);
            OUT.PrintLine(deg, color.ROJO, color.BLANCO, direct + 2, 7);
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._DATA_INFO);
        }
    }
}
