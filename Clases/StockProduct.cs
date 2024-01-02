using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class StockProduct
    {
        private string _Codigo;
        private string _TipoProducto;
        private string _Marca;
        private string _CodigoProducto;
        private string _NombreProducto;
        private string _TipoUnidad;
        private int _StockDeposito;
        private int _StockGondola;

        public StockProduct()
        {
            this._Codigo = "";
            this._TipoProducto = "";
            this._Marca = "";
            this._CodigoProducto = "";
            this._NombreProducto = "";
            this._TipoUnidad = "";
            this._StockDeposito = 0;
            this._StockGondola = 0;
        }
        public void Desconcatenar(string hp)
        {
            string[] ph = hp.Split(new char[]{ '*' });
            this._Codigo = ph[0];
            this._TipoProducto = ph[1];
            this._Marca = ph[2];
            this._CodigoProducto = ph[3];
            this._NombreProducto = ph[4];
            this._TipoUnidad = ph[5];
            this._StockDeposito = Convert.ToInt32(ph[6]);
            this._StockGondola = Convert.ToInt32(ph[7]);
        }
        public string Concatenador()
        {
            string hp = "";
            for (int i = 0; i < 8; i++)
            {
                switch(i)
                {
                    case 0: hp = this._Codigo; break; 
                    case 1: hp += this._TipoProducto; break;
                    case 2: hp += this._Marca; break;
                    case 3: hp += this._CodigoProducto; break;
                    case 4: hp += this._NombreProducto; break;
                    case 5: hp += this._TipoUnidad; break;
                    case 6: hp += this._StockDeposito.ToString(); break;
                    case 7: hp += this._StockGondola.ToString(); break;
                }
                if (i < 7) { hp += "*"; }
            }                       
            return (hp);
        }
        public string Codigo
        {
            set => this._Codigo = value;
            get => this._Codigo;
        }
        public string TipoProducto
        {
            set => this._TipoProducto = value;
            get => this._TipoProducto;
        }
        public string Marca
        {
            set => this._Marca = value;
            get => this._Marca;
        }
        public string CodigoProducto
        {
            set => this._CodigoProducto = value;
            get => this._CodigoProducto;
        }
        public string NombreProducto
        {
            set => this._NombreProducto = value;
            get => this._NombreProducto;
        }        
        public string TipoUnidad
        {
            set => this._TipoUnidad = value;
            get => this._TipoUnidad;
        }
        public int StockDeposito
        {
            set => this._StockDeposito = value;
            get => this._StockDeposito;
        }
        public int StockGondola
        {
            set => this._StockGondola = value;
            get => this._StockGondola;
        }
        public static int Comparador(StockProduct A, StockProduct B)
        {
            int result = 0, i = 0;
            string a = "", b = "";

            while ((i < 4) && (result == 0))
            {
                switch(i)
                {
                    case 0: a = A.TipoProducto; b = B.TipoProducto; break;
                    case 1: a = A.Marca; b = B.Marca; break;
                    case 2: a = A.NombreProducto; b = B.NombreProducto; break;
                    case 3: a = A.CodigoProducto; b = B.CodigoProducto; break;
                }
                result = String.Compare(a, b);
                i++;
            }
            return (result);
        }
    }
}

