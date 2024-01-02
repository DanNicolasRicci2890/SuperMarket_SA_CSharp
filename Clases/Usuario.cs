using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;

namespace SuperMarket_SA
{
    public class CorreoElectronico
    {
        private string _direct;
        private string _dominio;

        public CorreoElectronico()
        {
            this._direct = "";
            this._dominio = "";
        }

        public string Direct
        {
            get => this._direct; 
            set => this._direct = value;
        }
        public string Dominio
        {
            get => this._dominio;
            set => this._dominio = value;
        }
    }
    public enum CasaDepto
    {
        _none = 0,
        _Casa = 1,
        _Depto = 2
    }
    public class Usuario 
    {
        private string _Nombre;
        private string _Nombre2do;
        private string _ApellidoPa;
        private string _ApellidoMa;
        private uint _Legajo;
        private string _UserID;
        private string _Password;
        private int _FechaNac;
        private string _DNI;

        private int _CondState;     // bit 10: Estado de Habilitacion: 0 -> Habilitado
                                    //                                 1 -> Deshabilitado

                                    // bit 9: Estado Switch de Expiracion: 0 -> Activar Expiracion
                                    //                                     1 -> Desactivar Expiracion

                                    // bit 8: Estado Switch de Expiracion password: 0 -> Activar Expiracion contraseña
                                    //                                              1 -> Desactivar Expiracion contraseña

                                    // bit 7: Estado de Fecha de Expiracion: 0 -> Expiracion deshactivada
                                    //                                       1 -> Expiracion activada

                                    // bit 6: Estado de Fecha de Expiracion password: 0 -> Expiracion deshactivada
                                    //                                                1 -> Expiracion activada

                                    // bit 5: Estado de Bloqueos con Pass: 0 -> Desbloqueado Pass
                                    //                                     1 -> Bloqueado Pass

                                    // bit 4: Estado de Bloqueos Simple: 0 -> Desbloqueado Pass
                                    //                                   1 -> Bloqueado Pass

                                    // bit 3 y 2: Contador de Bloqueos con Pass: 00 -> 0
                                    //                                           01 -> 1
                                    //                                           10 -> 2
                                    //                                           11 -> 3

                                    // bit 1 y 0: Contador de Bloqueos simple: 00 -> 0
                                    //                                         01 -> 1
                                    //                                         10 -> 2
                                    //                                         11 -> 3

        private int _FechaExpiracion;
        private int _FechaExpiracionPass;

        private int _System_Roles;
        private int _System_SysAdmin;
        private int _System_Administrador;
        private int _System_Contaduria;
        private int _System_Cajero;
        private int _System_DepositLogic;

        private string _Pais;
        private string _Provincia;
        private string _Localidad;
        private string _Direccion;
        private int _Nro;
        private CasaDepto _CasaDepto;
        private string _Depto;
        private int _CodPostal;
        private string _Celular;
        private string _Telefono;
        private CorreoElectronico _Email;

        public Usuario(string nom, string nom2, string apelP, string apelM, uint legajo, int fn, string dni)
        {
            this._Nombre = nom;
            this._Nombre2do = nom2;
            this._ApellidoPa = apelP;
            this._ApellidoMa = apelM;
            this._Legajo = legajo;
            this._UserID = "";
            this._Password = "";  
            this._FechaNac = fn;
            this._DNI = dni;
            this._CondState = 1024;
            this._FechaExpiracion = IncrementadorExpiracion(0);
            this._FechaExpiracionPass = IncrementadorExpiracion(0);

            this._System_Roles = 0;
            this._System_SysAdmin = 0;
            this._System_Administrador = 0;
            this._System_Contaduria = 0;
            this._System_Cajero = 0;
            this._System_DepositLogic = 0;            

            this._Pais = "";
            this._Provincia = "";
            this._Localidad = "";
            this._Direccion = "";
            this._Nro = 0;
            this._CasaDepto = CasaDepto._none;
            this._Depto = "";
            this._CodPostal = 0;
            this._Celular = "";
            this._Telefono = "";
            this._Email = new CorreoElectronico();
        }
        public Usuario()
        {
            this._Nombre = "";
            this._Nombre2do = "";
            this._ApellidoPa = "";
            this._ApellidoMa = "";
            this._Legajo = 0;
            this._UserID = "";
            this._Password = "";
            this._FechaNac = 00000000;
            this._DNI = "";
            this._CondState = 1024;
            this._FechaExpiracion = IncrementadorExpiracion(6);
            this._FechaExpiracionPass = IncrementadorExpiracion(2);
            this._System_Roles = 0;
            this._System_SysAdmin = 0;
            this._System_Administrador = 0;
            this._System_Contaduria = 0;
            this._System_Cajero = 0;
            this._System_DepositLogic = 0;
            this._Pais = "";
            this._Provincia = "";
            this._Localidad = "";
            this._Direccion = "";
            this._Nro = 0;
            this._CasaDepto = CasaDepto._none;
            this._Depto = "";
            this._CodPostal = 0;
            this._Celular = "";
            this._Telefono = "";
            this._Email = new CorreoElectronico();
        }
        public void SetUserID(string userid, string password)
        {
            this._UserID = userid;
            this._Password = password;
            StHabilitadorON();
        }
        public void SetLocalizacion(string pais, string provincia, string localidad, string direccion, int nro, CasaDepto cd, string depto, int codpod, string cel, string tel, CorreoElectronico email)
        {
            this._Pais = pais;
            this._Provincia = provincia;
            this._Localidad = localidad;
            this._Direccion = direccion;
            this._Nro = nro;
            this._CasaDepto = cd;
            this._Depto = depto;
            this._CodPostal = codpod;
            this._Celular = cel;
            this._Telefono = tel;
            this._Email = email;
        }
//--------------------------------------------------------------------------------------------
        public string Pais
        {
            set => this._Pais = value;
            get => this._Pais;
        }
        public string Provincia
        {
            set => this._Provincia = value;
            get => this._Provincia;
        }
        public string Localidad
        {
            set => this._Localidad = value;
            get => this._Localidad;
        }
        public string Direccion
        {
            set => this._Direccion = value;
            get => this._Direccion;
        }
        public int Nro
        {
            set => this._Nro = value;
            get => this._Nro;
        }
        public CasaDepto CasaDepto
        {
            set => this._CasaDepto = value;
            get => this._CasaDepto;
        }
        public string Depto
        {
            set => this._Depto = value;
            get => this._Depto;
        }
        public int CodPostal
        {
            set => this._CodPostal = value;
            get => this._CodPostal;
        }
        public string Celular
        {
            set => this._Celular = value;
            get => this._Celular;
        }
        public string Telefono
        {
            set => this._Telefono = value;
            get => this._Telefono;
        }
        public int SystemRoles
        {
            set => this._System_Roles = value;
            get => this._System_Roles;
        }
        public int SystemSysAdmin
        {
            set => this._System_SysAdmin = value;
            get => this._System_SysAdmin;
        }
        public int SystemAdministrador
        {
            set => this._System_Administrador = value;
            get => this._System_Administrador;
        }
        public int SystemContaduria
        {
            set => this._System_Contaduria = value;
            get => this._System_Contaduria;
        }
        public int SystemCajero
        {
            set => this._System_Cajero = value;
            get => this._System_Cajero;
        }
        public int SystemDepositLogic
        {
            set => this._System_DepositLogic = value;
            get => this._System_DepositLogic;
        }
        public CorreoElectronico Email
        {
            set => this._Email = value;
            get => this._Email;
        }
//--------------------------------------------------------------------------------------------
        public string ApellidoP 
        { 
            set => this._ApellidoPa = value;
            get => this._ApellidoPa;
        }
        public string ApellidoM
        {
            set => this._ApellidoMa = value;
            get => this._ApellidoMa;
        }
        public string Nombre
        {
            set => this._Nombre = value;
            get => this._Nombre;
        }
        public string Nombre2do
        {
            set => this._Nombre2do = value;
            get => this._Nombre2do;
        }
        public string DNI
        {
            set => this._DNI = value;
            get => this._DNI;
        }
        public string UserID
        {
            set => this._UserID = value;
            get => this._UserID;
        }
        public string Password
        {
            set => this._Password = value;
            get => this._Password;
        }
        public string Legajo
        {
            set => this._Legajo = Convert.ToUInt32(value);
            get => this._Legajo.ToString();
        }
        public int FechNac
        {
            set => this._FechaNac = value;
            get => this._FechaNac;
        }
        public int FechNacExp
        {
            set => this._FechaExpiracion = value;
            get => this._FechaExpiracion;
        }
        public int FechNacExpPass
        {
            set => this._FechaExpiracionPass = value;
            get => this._FechaExpiracionPass;
        }
        public string ImprimirEmail()
        {
            string h = this._Email.Direct;
            h = String.Concat(h, "@", this._Email.Dominio);
            return (h);
        }
        public static string ImprimirFechaNac(int valor)
        {
            string h = "";
            int j = ((valor % 10000) % 100);
            if (j < 10)
            {
                h = "0";
            }
            h = String.Concat(h, j.ToString(), " /");
            j = ((valor % 10000) / 100);
            switch(j)
            {
                case 1: h = String.Concat(h, " Enero "); break;
                case 2: h = String.Concat(h, " Febrero "); break;
                case 3: h = String.Concat(h, " Marzo "); break;
                case 4: h = String.Concat(h, " Abril "); break;
                case 5: h = String.Concat(h, " Mayo "); break;
                case 6: h = String.Concat(h, " Junio "); break;
                case 7: h = String.Concat(h, " Julio "); break;
                case 8: h = String.Concat(h, " Agosto "); break;
                case 9: h = String.Concat(h, " Septiembre "); break;
                case 10: h = String.Concat(h, " Octubre "); break;
                case 11: h = String.Concat(h, " Noviembre "); break;
                case 12: h = String.Concat(h, " Diciembre "); break;
            }
            j = valor / 10000;
            h = String.Concat(h, "/ ", j.ToString());   
            return (h);
        }
        public string IdentidadConcatenar()
        {
            string k = this._ApellidoPa;
            if (!(this._ApellidoMa.Equals("")))
            {
                k = String.Concat(k, " ", this._ApellidoMa);
            }
            k = String.Concat(k, ", ", this._Nombre);
            if (!(this._Nombre2do.Equals("")))
            {
                k = String.Concat(k, " ", this._Nombre2do);
            }
            k = String.Concat(k, " (", this._UserID,")");
            return (k);
        }
        public string ConcatenarIdent()
        {
            string k = this._ApellidoPa;
            if (!(this._ApellidoMa.Equals("")))
            {
                k = String.Concat(k, " ", this._ApellidoMa);
            }
            k = String.Concat(k, ", ", this._Nombre);
            if (!(this._Nombre2do.Equals("")))
            {
                k = String.Concat(k, " ", this._Nombre2do);
            }

            return (k);
        }
        public void StHabilitadorOFF() => SetBit(true, 10);
        public void StHabilitadorON() => SetBit(false, 10);
        public int StHabilitacion() => GetBit(10);
        public void SWExpiratedON() => SetBit(false, 9);
        public void SWExpiratedOFF() => SetBit(true, 9);
        public int SWExpirated => GetBit(9);
        public void SWExpPasswordON() => SetBit(false, 8);
        public void SWExpPasswordOFF() => SetBit(true, 8);
        public int SWExpPassword => GetBit(8);
        public bool StExpirated()
        {
            bool st = false;
            if (GetBit(9) == 1) { st = true; }
            else
            {                
                int fecha_actual = ((DateTime.Now.Year) * 10000) + ((DateTime.Now.Month) * 100) + DateTime.Now.Day;
                if (this._FechaExpiracion <= fecha_actual)
                {
                    SetBit(true, 7);
                }
                if (GetBit(7) == 1) { st = false; }
                else { st = true; }
            }
            return st;
        }
        public bool StExpPassword()
        {
            bool st = false;
            if (GetBit(8) == 1) { st = true; }
            else
            {
                int fecha_actual = ((DateTime.Now.Year) * 10000) + ((DateTime.Now.Month) * 100) + DateTime.Now.Day;
                if (this._FechaExpiracionPass <= fecha_actual)
                {
                    SetBit(true, 6);
                }
                if (GetBit(6) == 1) { st = false; }
                else { st = true; }
            }
            return st;
        }
        public bool StBlockPass()
        {
            bool st = true;
            if (GetBit(5) == 1) { st = false; }
            return st;
        }
        public void ResetStBlockPass() => SetBit(false, 5);
        public void ResetStBlockOFF() => SetBit(false, 4);
        public void ResetStBlockON() => SetBit(true, 4);
        public bool StBlocked()
        {
            bool st = true;
            if (GetBit(4) == 1) { st = false; }
            return st;
        }
        public void IncrementarBlockeos()
        {
            int contador = GetDoubleBits(0); // obtener cantidad de contadores de bloqueos simples
            contador++; // incrementar el contador de cantidad de bloqueos simples

            if (contador == 3) // verificar si el contador es igual a 3 
            {
                SetDoubleBits(0, 0); //<--- resetear el contador de blockeos simples
                SetBit(true, 4); //<--- activamos el bit de bloqueos simples
                contador = GetDoubleBits(2); // obtener cantidad de contadores de bloqueos con password
                contador++; // incrementamos el contador de bloqueos pass
                if (contador == 3) // verificamos si el contador llego a 3
                {
                    SetDoubleBits(0, 2); //<--- resetear el contador de blockeos password
                    SetBit(false, 4); //<--- desactivamos el bit de bloqueos simples
                    SetBit(true, 5); //<--- activamos el bit de bloqueos password
                } else {
                    SetDoubleBits(contador, 2); // en caso que no llegue a la cantidad de 3
                                                // lo guardamos en los bits 2 y 3.
                }
            } else { 
                SetDoubleBits(contador, 0); // en caso que no llegue a la cantidad de 3
                                            // lo guardamos en los bits 0 y 1.
            }
        }
        public void ResetearBloqueos()
        {
            SetDoubleBits(0, 0);
            SetDoubleBits(0, 2);
            SetBit(false, 4);
            SetBit(false, 5);
        }
        public string Concatenar()
        {
            string res = "";
            int tope = 30;
            for(int i = 0; i < tope; i++)
            {
                switch(i)
                {
                    case 0: res = this._Nombre; break;
                    case 1: res = String.Concat(res, this._Nombre2do); break;
                    case 2: res = String.Concat(res, this._ApellidoPa); break;
                    case 3: res = String.Concat(res, this._ApellidoMa); break;
                    case 4: res = String.Concat(res, this._UserID); break;
                    case 5: res = String.Concat(res, this._Password); break;
                    case 6: res = String.Concat(res, this._Legajo.ToString()); break;
                    case 7: res = String.Concat(res, this._DNI); break;
                    case 8: res = String.Concat(res, this._CondState.ToString()); break;
                    case 9: res = String.Concat(res, this._FechaNac.ToString()); break;
                    case 10: res = String.Concat(res, this._FechaExpiracion.ToString()); break;
                    case 11: res = String.Concat(res, this._FechaExpiracionPass.ToString()); break;
                    case 12: res = String.Concat(res, this._System_Roles.ToString()); break;
                    case 13: res = String.Concat(res, this._System_SysAdmin.ToString()); break;
                    case 14: res = String.Concat(res, this._System_Administrador.ToString()); break;
                    case 15: res = String.Concat(res, this._System_Contaduria.ToString()); break;
                    case 16: res = String.Concat(res, this._System_Cajero.ToString()); break;
                    case 17: res = String.Concat(res, this._System_DepositLogic.ToString()); break;                    
                    case 18: res = String.Concat(res, this._Pais); break;
                    case 19: res = String.Concat(res, this._Provincia); break;
                    case 20: res = String.Concat(res, this._Localidad); break;
                    case 21: res = String.Concat(res, this._Direccion); break;
                    case 22: res = String.Concat(res, this._Nro.ToString()); break;
                    case 23: res = String.Concat(res, ConvertidorCDStr(this._CasaDepto)); break;
                    case 24: res = String.Concat(res, this._Depto); break;
                    case 25: res = String.Concat(res, this._CodPostal.ToString()); break;
                    case 26: res = String.Concat(res, this._Celular); break;
                    case 27: res = String.Concat(res, this._Telefono); break;
                    case 28: res = String.Concat(res, this._Email.Direct); break;
                    case 29: res = String.Concat(res, this._Email.Dominio); break;
                }
                if (i < (tope - 1)) { res = String.Concat(res, ","); }                
            }
            return (res);
        }
        public void Desconcatenar(string valor)
        {
            string[] lir = valor.Split(',');
            
            this._Nombre = lir[0];
            this._Nombre2do = lir[1];
            this._ApellidoPa = lir[2];
            this._ApellidoMa = lir[3];
            this._UserID = lir[4];
            this._Password = lir[5];            
            this._Legajo = Convert.ToUInt32(lir[6]);
            this._DNI = lir[7];
            this._CondState = Convert.ToInt32(lir[8]);
            this._FechaNac = Convert.ToInt32(lir[9]);
            this._FechaExpiracion = Convert.ToInt32(lir[10]);
            this._FechaExpiracionPass = Convert.ToInt32(lir[11]);
            this._System_Roles = Convert.ToInt32(lir[12]);
            this._System_SysAdmin = Convert.ToInt32(lir[13]);
            this._System_Administrador = Convert.ToInt32(lir[14]);
            this._System_Contaduria = Convert.ToInt32(lir[15]);
            this._System_Cajero = Convert.ToInt32(lir[16]);
            this._System_DepositLogic = Convert.ToInt32(lir[17]);            
            this._Pais = lir[18];
            this._Provincia = lir[19];
            this._Localidad = lir[20];
            this._Direccion = lir[21];
            this._Nro = Convert.ToInt32(lir[22]);
            this._CasaDepto = ConvertidorStrCD(lir[23]);
            this._Depto = lir[24];
            this._CodPostal = Convert.ToInt32(lir[25]);
            this._Celular = lir[26];
            this._Telefono = lir[27];
            this._Email.Direct = lir[28];
            this._Email.Dominio = lir[29];
        }
        public string ConcatenarDireccion1()
        {
            string h = this._Direccion;
            h = String.Concat(h, " ", this._Nro.ToString(), "   ");
            if(this._CasaDepto == CasaDepto._Depto)
            {
                h = String.Concat(h, "depto: ", this._Depto, "   ");
            }
            h = String.Concat(h, "codpos: ", this._CodPostal.ToString());
            return (h);
        }
        public string ConcatenarDireccion2()
        {
            string h = this._Localidad;
            h = String.Concat(h, ", ", this._Provincia, ", ");
            h = String.Concat(h, this._Pais);
            
            return (h);
        }
        public static CasaDepto ConvertidorStrCD(string f)
        {
            CasaDepto h = CasaDepto._none;
            switch (f)
            {
                case "none": h = CasaDepto._none; break;
                case "Casa": h = CasaDepto._Casa; break;
                case "Depto": h = CasaDepto._Depto; break;
            }
            return (h);
        }
        public static string ConvertidorCDStr(CasaDepto f)
        {
            string h = "";
            switch(f)
            {
                case CasaDepto._none: h = ""; break;
                case CasaDepto._Casa: h = "Casa"; break;
                case CasaDepto._Depto: h = "Depto"; break;
            }
            return (h);
        }
        public static int Comparador(Usuario A, Usuario B)
        {
            int resultado = 0, i = 0;
            string _A = "", _B = "";
            while((i < 4) && (resultado == 0))
            {
                switch(i)
                {
                    case 0: _A = A.ApellidoP; _B = B.ApellidoP; break;
                    case 1: _A = A.ApellidoM; _B = B.ApellidoM; break;
                    case 2: _A = A.Nombre; _B = B.Nombre; break;
                    case 3: _A = A.Nombre2do; _B = B.Nombre2do; break;
                }
                resultado = String.Compare(_A, _B);
                i++;
            }
            
            return (resultado);
        }
        public int calcularedad()
        {
            int edad = DateTime.Now.Year - (this._FechaNac / 10000);

            if ((DateTime.Now.Month) < ((this._FechaNac % 10000) / 100)) { edad--; }
            else
            {
                if ((DateTime.Now.Month) == ((this._FechaNac % 10000) / 100))
                {
                    if ((DateTime.Now.Day) < ((this._FechaNac % 10000) % 100)) { edad--; }
                }
            }
            return edad;
        }
        public string encriptado()
        {
            string v = "";
            for (int i = 0; i < this._DNI.Length; i++) { v = String.Concat(v, "*"); }
            return v;
        }
        public void ImprimirUserList(color bc, color fc, int x, int y)
        {
            string k = String.Concat(" ", this._ApellidoPa);
            if (!(this._ApellidoMa.Equals("")))
            {
                k = String.Concat(k, " ", this._ApellidoMa);
            }
            k = String.Concat(k, ", ", this._Nombre);
            if (!(this._Nombre2do.Equals("")))
            {
                k = String.Concat(k, " ", this._Nombre2do);
            }
            IOdata.Selector(bc, fc, k, 59, x, y);
            IOdata.Selector(bc, fc, String.Concat(" ", this._Legajo.ToString()), 19, x + 61, y);
            IOdata.Selector(bc, fc, String.Concat(" ", this._DNI.ToString()), 20, x + 81, y);
            IOdata.Selector(bc, fc, String.Concat(" ", this._UserID.ToString()), 29, x + 103, y);

            if (!(this._UserID.Equals("no posee ID")))
            {
                k = "Cuenta HABILITADA";
                if ((GetBit(10)) == 1) { k = "Deshabilitado"; }
                if ((GetBit(7)) == 1) { k = "Cuenta Expirada"; }
                if ((GetBit(6)) == 1) { k = "Password Expirado"; }
                if ((GetBit(5)) == 1) { k = "Password Bloqueado"; }
                if ((GetBit(4)) == 1) { k = "Cuenta Bloqueada"; }
            } else { k = "Cuenta NO HABILITADA"; }            
            IOdata.Selector(bc, fc, String.Concat(" ", k), 37, x + 134, y);
        }
        public static CorreoElectronico DesconcatenarEmail(string em)
        {
            string[] k = em.Split(new char[] { '@' });
            CorreoElectronico p = new CorreoElectronico();
            p.Direct = k[0];
            p.Dominio = k[1];
            return p;
        }
        public static int ComparadorUsuarios(Usuario A, Usuario B)
        {
            int i = 0, comp = 0;

            while((i < 5) && (comp == 0))
            {                
                switch(i)
                {
                    case 0: comp = String.Compare(A.ApellidoP, B.ApellidoP); break;
                    case 1: comp = String.Compare(A.ApellidoM, B.ApellidoM); break;
                    case 2: comp = String.Compare(A.Nombre, B.Nombre); break;
                    case 3: comp = String.Compare(A.Nombre2do, B.Nombre2do); break;
                    case 4: comp = String.Compare(A.DNI, B.DNI); break;
                }
                i++;
            }
            return (comp);
        }        
        public static int IncrementadorExpiracion(int incremento)
        {
            int resultado = 0;
            DateTime pt = DateTime.Now;
            int anio = pt.Year, mes = pt.Month - 1, dia = pt.Day;
            mes += incremento;
            while(mes > 12)
            {
                mes -= 12;
                anio++;
            }
            mes++;
            resultado = (anio * 10000) + (mes * 100) + dia;
            return (resultado);
        }
        private void SetBit(bool cond, int bit)
        {
            if (cond == false)
            {
                if (((this._CondState >> bit) & 1) == 1)
                {
                    this._CondState &= (~(1 << bit));
                }
            }
            if (cond == true)
            {
                if (((this._CondState >> bit) & 1) == 0)
                {
                    this._CondState |= (1 << bit);
                }
            }
        }
        private int GetBit(int bit)
        {
            int res = 0;
            if (((this._CondState >> bit) & 1) == 1) { res = 1; }
            return (res);
        }
        private void SetDoubleBits(int valor, int bit)
        {
            this._CondState &= (~(1 << bit));
            this._CondState &= (~(1 << (bit + 1)));
            if (valor != 0)
            {
                if ((valor == 1) || (valor == 3)) { this._CondState |= (1 << bit); }
                if ((valor == 2) || (valor == 3)) { this._CondState |= (1 << (bit + 1)); }
            }
        }
        private int GetDoubleBits(int bit)
        {
            int valor = 0;
            if (((this._CondState >> bit) & 1) == 1) { valor += 1; }
            if (((this._CondState >> (bit + 1)) & 1) == 1) { valor += 2; }
            return (valor);
        }
    }
}
