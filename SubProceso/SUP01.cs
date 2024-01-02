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
    public class SUP01
    {
        public static void SalidaVerificacion(ref BDState dt)
        {
            dt.SetMState(TypeState._VerificInicio, VerificInicio._none);
            dt.SetMState(TypeState._LiveVerifcacion, LiveProgram._INACTIVATED);            
            dt.SetMState(TypeState._LiveLoginUserPass, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._StateMain, StateMain._LOGIN_USER_PASS);
            dt.SetMState(TypeState._LoginUserPass, LoginUser._DISPLAY);
        }
        public static void CreateListUser(ref BDState dt)
        {
            string kt = Directory.GetCurrentDirectory();
            string kt1 = kt.Replace(@"\bin\Debug", @"\BaseData");
            string kt2 = kt.Replace(@"\bin\Debug", @"\BaseData\Sucursales\");
            string kt3 = kt.Replace(@"\bin\Debug", @"\BaseData\Productos\");
            Directory.CreateDirectory(kt1);
            Directory.CreateDirectory(kt2);
            Directory.CreateDirectory(kt3);

            string listuser = String.Concat(kt1, "\\ListUserProgram.dat");
            string listroles = String.Concat(kt1, "\\ListSucursales.dat");
            string listtypeprd = String.Concat(kt1, "\\ListTypeProduct.dat");
            string dolarpeso = String.Concat(kt1, "\\DolarPeso.dat");
            string ganancias = String.Concat(kt1, "\\Ganancias.dat");

            Usuario usergod = new Usuario("Usuario", "", "Dios", "", 00000, 20230101, "00.000.000");
            usergod.SetUserID("usergod", "DiosSupremo7");
            usergod.StHabilitadorON();
            usergod.SWExpiratedOFF();
            usergod.SWExpPasswordOFF();
            usergod.FechNacExp = 20231221; 
            usergod.FechNacExpPass = 20240104;            
            CorreoElectronico mail = new CorreoElectronico();
            mail.Direct = "x";
            mail.Dominio = "x";
            usergod.SetLocalizacion("Argentina", "Buenos Aires", "Capital Federal", "Lugar", 0, CasaDepto._Depto, "", 1430, "0000-0000", "0000000000", mail);
            usergod.SystemRoles = 63;
            usergod.SystemSysAdmin = 32766;
            usergod.SystemAdministrador = 32767;
            usergod.SystemCajero = 32767;
            usergod.SystemContaduria = 32767;
            usergod.SystemDepositLogic = 32767;

            Sucursal sucursal = new Sucursal("1", "CASA_CENTRAL", "", 0, 0, "", "", "");
            CodigoEnigma tr = new CodigoEnigma();
            string user_encriptado = tr.Encriptador(usergod.Concatenar());
            string sucur_encriptado = tr.Encriptador(sucursal.Concatenar());
            string dolar = tr.Encriptador("1");

            StreamWriter sw_listuser = new StreamWriter(listuser);
            StreamWriter sw_listroles = new StreamWriter(listroles);
            StreamWriter sw_listtypeP = new StreamWriter(listtypeprd);
            StreamWriter sw_dolarpeso = new StreamWriter(dolarpeso);
            StreamWriter sw_ganancias = new StreamWriter(ganancias);

            sw_listuser.WriteLine(user_encriptado);
            sw_listroles.WriteLine(sucur_encriptado);
            sw_dolarpeso.WriteLine(dolar);

            sw_listuser.Close();
            sw_listroles.Close();
            sw_listtypeP.Close();
            sw_dolarpeso.Close();
            sw_ganancias.Close();

            string htp = String.Concat(kt2, "CASA_CENTRAL.dat");

            StreamWriter sw = new StreamWriter(htp);
            sw.Close();

            dt.SetMState(TypeState._VerificInicio, VerificInicio._READ02);
        }
        public static void VerifListUser(ref BDState dt)
        {
            string kt = @Directory.GetCurrentDirectory();
            kt = kt.Replace(@"\bin\Debug", @"\BaseData\ListUserProgram.dat");
            bool verif = File.Exists(@kt);
            
            if (verif)
            {
                dt.SetMState(TypeState._VerificInicio, VerificInicio._READ02);
            }
            else { dt.SetMState(TypeState._VerificInicio, VerificInicio._BORN01); }
        }
        public static void InitVerif(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveVerifcacion, (LiveProgram)LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._VerificInicio, (VerificInicio)VerificInicio._READ01);
        }
    }
}
