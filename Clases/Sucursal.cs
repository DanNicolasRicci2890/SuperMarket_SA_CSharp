using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class Sucursal 
    {
        private string _Codigo;
        private string _NombreSucursal;
        private string _Direccion;
        private int _Numero;
        private int _CodPost;
        private string _Provincia;
        private string _Localidad;
        private string _Pais;

        public Sucursal(string codigo, string nombreSucursal, string direccion, int numero, int codPost, string provincia, string localidad, string pais)
        {
            this._Codigo = codigo;
            this._NombreSucursal = nombreSucursal;
            this._Direccion = direccion;
            this._Numero = numero;
            this._CodPost = codPost;
            this._Provincia = provincia;
            this._Localidad = localidad;
            this._Pais = pais;
        }
        public Sucursal()
        {
            this._Codigo = "";
            this._NombreSucursal = "";
            this._Direccion = "";
            this._Numero = 0;
            this._CodPost = 0;
            this._Provincia = "";
            this._Localidad = "";
            this._Pais = "";
        }
        public string CODIGO
        {
            set { this._Codigo = value; }
            get { return this._Codigo; }
        }
        public string NOMSUCURSAL
        {
            set { this._NombreSucursal = value; }
            get { return this._NombreSucursal; }
        }
        public string DIRECCION
        {
            set { this._Direccion = value; }
            get { return this._Direccion; }
        }
        public int NUMERO
        {
            set { this._Numero = value; }
            get { return this._Numero; }
        }
        public int CODPOST
        {
            set { this._CodPost = value; }
            get { return this._CodPost; }
        }
        public string PROVINCIA
        {
            set { this._Provincia = value; }
            get { return this._Provincia; }
        }
        public string LOCALIDAD
        {
            set { this._Localidad = value; }
            get { return this._Localidad; }
        }
        public string PAIS
        {
            set { this._Pais = value; }
            get { return this._Pais; }
        }
        public string Concatenar()
        {
            string res = "";
            for(int i = 0; i < 8; i++)
            {
                switch(i)
                {
                    case 0: res = this._NombreSucursal.ToString(); break;
                    case 1: res = String.Concat(res, this._Codigo.ToString()); break;
                    case 2: res = String.Concat(res, this._Direccion.ToString()); break;
                    case 3: res = String.Concat(res, this._Numero.ToString()); break;
                    case 4: res = String.Concat(res, this._CodPost.ToString()); break;
                    case 5: res = String.Concat(res, this._Provincia.ToString()); break;
                    case 6: res = String.Concat(res, this._Localidad.ToString()); break;
                    case 7: res = String.Concat(res, this._Pais.ToString()); break;
                }
                if (i < 7) { res = String.Concat(res, ","); }
            }
            return res;
        }
        public void Desconcatenar(string valor)
        {
            string[] lir = valor.Split(',');
            this._NombreSucursal = lir[0];
            this._Codigo = lir[1];
            this._Direccion = lir[2];
            this._Numero = Convert.ToInt32(lir[3]);
            this._CodPost = Convert.ToInt32(lir[4]);
            this._Provincia = lir[5];
            this._Localidad = lir[6];
            this._Pais = lir[7];
        }
        public static int Comparador(Sucursal A, Sucursal B)
        {
            int resultado = 0;
            resultado = String.Compare(A.NOMSUCURSAL, B.NOMSUCURSAL);

            return (resultado);
        } 
    }
}
