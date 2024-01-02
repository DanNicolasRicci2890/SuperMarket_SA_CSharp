using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class BoxProduct
    {
        private TypeProduct _Tipoproducto;
        private string _Codigo;
        private string _Marca;
        private string _NombreProducto;        

        private TipoMoneda _Tipomoneda;
        private float _Precio;

        private int _Cantidad;
        private float _SubPrecio;

        public BoxProduct(StockProduct obj)
        {
            this._Tipoproducto = new TypeProduct();
            this._Tipoproducto.ProductName = obj.TipoProducto;
            this._Tipoproducto.Code = obj.Codigo;
            this._Codigo = obj.CodigoProducto;
            this._Marca = obj.Marca;    
            this._NombreProducto = obj.NombreProducto;              
        }
        public BoxProduct()
        {
            this._Tipoproducto = new TypeProduct();
            this._Tipoproducto.ProductName = "";
            this._Tipoproducto.Code = "";
            this._Codigo = "";
            this._Marca = "";
            this._NombreProducto = "";
        }
        public string GetTipoProducto() => String.Concat(" ", this._Tipoproducto.ProductName, "(", this._Tipoproducto.Code, ")");        
        public string GetProducto() => String.Concat(" ", this._NombreProducto, "(", this._Codigo, ")");
        public string GetCodigoPro() => this._Codigo;
        public void SetPrecio(TipoMoneda tm, float precio)
        {
            this._Tipomoneda = tm;
            this._Precio = precio;
        }
        public string GetPrecioStr()
        {
            string ht = "";
            switch(this._Tipomoneda)
            {
                case (TipoMoneda._DOLAR): ht = String.Concat("u$s ", this._Precio); break;
                case (TipoMoneda._PESOS): ht = String.Concat("  $ ", this._Precio); break;
            }
            return ht;
        }
        public float GetPrecioFlt() => this._Precio;
        public string GetMarca() => this._Marca;
        public int CANTIDAD
        {
            set => this._Cantidad = value;
            get => this._Cantidad;
        }
        public void SetSubPrecio() => this._SubPrecio = CalcularSubPrecio();
        public float GetSubPrecio() => this._SubPrecio;
        public string GetSubPrecioStr()
        {
            string ht = "";
            switch (this._Tipomoneda)
            {
                case (TipoMoneda._DOLAR): ht = String.Concat("u$s ", this._SubPrecio); break;
                case (TipoMoneda._PESOS): ht = String.Concat("  $ ", this._SubPrecio); break;
            }
            return ht;
        }
        public override bool Equals(object o)
        {  
            return true;  
        }
        public override int GetHashCode()
        {  
            return 0;  
        } 
        public static int operator == (BoxProduct A, BoxProduct B)
        {
            int k = 0, i = 0;
            string a = "", b = "";

            while ((i < 4) && (k == 0))
            {
                switch(i)
                {
                    case 0: a = A._Tipoproducto.Code; b = B._Tipoproducto.Code; break;
                    case 1: a = A._Marca; b = B._Marca; break;
                    case 2: a = A._Codigo; b = B._Codigo; break;
                    case 3: a = A._NombreProducto; b = B._NombreProducto; break;
                }
                k = String.Compare(a, b);
                i++;
            }
            return k;
        }
        public static int operator != (BoxProduct A, BoxProduct B)
        {
            int k = 0, i = 0;
            string a = "", b = "";

            while ((i < 4) && (k == 0))
            {
                switch (i)
                {
                    case 0: a = A._Tipoproducto.Code; b = B._Tipoproducto.Code; break;
                    case 1: a = A._Marca; b = B._Marca; break;
                    case 2: a = A._Codigo; b = B._Codigo; break;
                    case 3: a = A._NombreProducto; b = B._NombreProducto; break;
                }
                k = String.Compare(a, b);
                i++;
            }
            return k;
        }
        private float CalcularSubPrecio() => (((float)this._Cantidad) * this._Precio);                
    }
}
