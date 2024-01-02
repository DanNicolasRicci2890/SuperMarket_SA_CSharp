using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;
using PCD_INOUT_INFO;

namespace SuperMarket_SA
{
    public enum TipoMoneda
    {
        _none = 0,
        _PESOS = 1,
        _DOLAR = 2,        
    }
    public class Producto
    {
        private TypeProduct _Tipoproducto;
        private string _Codigo;
        private string _Marca;
        private string _NombreProducto;
        private string _TipoCant;
        private int _CantVenta;
        private TipoMoneda _Tipomoneda;
        private float _Precio;

        public Producto(TypeProduct tipoproducto, string codigo, string marca, string nombreProducto, string tipoCant, int cantVenta, TipoMoneda tipomoneda, float precio)
        {
            this._Tipoproducto = tipoproducto;
            this._Codigo = codigo;
            this._Marca = marca;
            this._NombreProducto = nombreProducto;
            this._TipoCant = tipoCant;
            this._CantVenta = cantVenta;
            this._Tipomoneda = tipomoneda;
            this._Precio = precio;            
        }

        public Producto()
        {
            this._Tipoproducto = new TypeProduct();
            this._Codigo = "";
            this._Marca = "";
            this._NombreProducto = "";
            this._TipoCant = "";
            this._CantVenta = 0;
            this._Tipomoneda = TipoMoneda._none;
            this._Precio = 0;
        }
        public TypeProduct TProduct
        {
            set => this._Tipoproducto = value;
            get => this._Tipoproducto; 
        }
        public string Codigo
        {
            set => this._Codigo = value; 
            get => this._Codigo; 
        }
        public string Marca
        {
            set => this._Marca = value;
            get => this._Marca; 
        }
        public string NombreProducto
        {
            set => this._NombreProducto = value;
            get => this._NombreProducto; 
        }
        public string TipoCantidad
        {
            set => this._TipoCant = value;
            get => this._TipoCant;
        }
        public int CantVenta
        {
            set => this._CantVenta = value;
            get => this._CantVenta;
        }
        public TipoMoneda Moneda
        {
            set => this._Tipomoneda = value;
            get => this._Tipomoneda;
        }
        public float Precio
        {
            set => this._Precio = value;
            get => this._Precio;
        }
        public void Desconcatenar(string k)
        {
            string[] lip = k.Split('*');
            this._Tipoproducto.ProductName = lip[0];
            this._Tipoproducto.Code = lip[1];
            this._Codigo = lip[2];
            this._Marca = lip[3];
            this._NombreProducto = lip[4];
            this._TipoCant = lip[5];
            this._CantVenta = Convert.ToInt32(lip[6]);
            switch(lip[7])
            {
                case ("Pesos"): this._Tipomoneda = TipoMoneda._PESOS; break;
                case ("Dolar"): this._Tipomoneda = TipoMoneda._DOLAR; break;
            }
            this._Precio = Convert.ToSingle(lip[8]);
        }
        public string Concatenar()
        {
            string lop = "";
            lop = String.Concat(lop, this._Tipoproducto.ProductName, "*");
            lop = String.Concat(lop, this._Tipoproducto.Code, "*");
            lop = String.Concat(lop, this._Codigo, "*");
            lop = String.Concat(lop, this._Marca, "*");
            lop = String.Concat(lop, this._NombreProducto, "*");
            lop = String.Concat(lop, this._TipoCant, "*");
            lop = String.Concat(lop, this._CantVenta.ToString(), "*");
            switch (this._Tipomoneda)
            {
                case (TipoMoneda._PESOS): lop = String.Concat(lop, "Pesos", "*"); break;
                case (TipoMoneda._DOLAR): lop = String.Concat(lop, "Dolar", "*"); break;
            }
            lop = String.Concat(lop, this._Precio.ToString());
            return (lop);
        }
        public void ImprimirProducto(color bc, color fc, int x, int y)
        {
            OUT.PrintLine(this.Marca, fc, bc, x, y);
            /*
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
            OUT.PrintLine(k, fc, bc, x, y);
            OUT.PrintLine(this._Legajo.ToString(), fc, bc, x + 62, y);
            OUT.PrintLine(this._DNI, fc, bc, x + 83, y);
            OUT.PrintLine(this._UserID, fc, bc, x + 104, y);

            if (!(this._UserID.Equals("no posee ID")))
            {
                k = "Cuenta HABILITADA";
                if ((GetBit(10)) == 1) { k = "Deshabilitado"; }
                if ((GetBit(7)) == 1) { k = "Cuenta Expirada"; }
                if ((GetBit(6)) == 1) { k = "Password Expirado"; }
                if ((GetBit(5)) == 1) { k = "Password Bloqueado"; }
                if ((GetBit(4)) == 1) { k = "Cuenta Bloqueada"; }
            } else { k = "Cuenta NO HABILITADA"; }
            OUT.PrintLine(k, fc, bc, x + 135, y);
            */
        }
        public static int Comparador(Producto A, Producto B)
        {
            int result = 0, i = 0;
            string a = "", b = "";
            while ((i < 2) && (result == 0))
            {
                switch (i)
                {
                    case 0: a = A.Marca; b = B.Marca; break;
                    case 1: a = A.NombreProducto; b = B.NombreProducto; break;
                }
                result = String.Compare(a, b);
                i++;
            }
            return (result);
        }
        
    }
}
