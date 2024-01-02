using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class SucursalGain
    {
        private string _NombreSucursal;
        private string _Codigo;
        private float _MontoDolares;
        private float _MontoPesos;

        public SucursalGain() 
        {
            this._NombreSucursal = "";
            this._Codigo = "";
            this._MontoDolares = 0;
            this._MontoPesos = 0;
        }
        public string NombreSucursal
        {
            set => this._NombreSucursal = value;
            get => this._NombreSucursal;
        }
        public string Codigo
        {
            set => this._Codigo = value;
            get => this._Codigo;
        }
        public float MDolar
        {
            set => this._MontoDolares = value;
            get => this._MontoDolares;
        }
        public float MPesos
        {
            set => this._MontoPesos = value;
            get => this._MontoPesos;
        }
        public string Concatenador()
        {
            string h = "";
            for(int i = 0; i < 4; i++)
            {
                switch(i)
                {
                    case 0: h = String.Concat(this._NombreSucursal,"*"); break;
                    case 1: h = String.Concat(h, this._Codigo, "*"); break;
                    case 2: h = String.Concat(h, this._MontoDolares, "*"); break;
                    case 3: h = String.Concat(h, this._MontoPesos); break;
                }
            }            
            return h;
        }
        public void Desconcatenar(string ft)
        {
            string[] lit = ft.Split(new char[] { '*' });
            this._NombreSucursal = lit[0];
            this._Codigo = lit[1];
            this._MontoDolares = Convert.ToSingle(lit[2]);
            this._MontoPesos = Convert.ToSingle(lit[3]);
        }
        public static int operator ==(SucursalGain a, SucursalGain b)
        {            
            string A = String.Concat(a.NombreSucursal, "_", a.Codigo);
            string B = String.Concat(b.NombreSucursal, "_", b.Codigo);
            int resultado = String.Compare(A, B);
            return resultado;
        }
        public static int operator !=(SucursalGain a, SucursalGain b)
        {
            int resultado = 0;
            return resultado;
        }
        public override bool Equals(object o)
        {
            return true;
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
