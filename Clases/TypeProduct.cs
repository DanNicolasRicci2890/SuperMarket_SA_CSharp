using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class TypeProduct
    {
        private string _productName;
        private string _code;
        public TypeProduct()
        {
            this._productName = "";
            this._code = "";
        }
        public string ProductName
        {
            set => this._productName = value; 
            get => this._productName;
        }
        public string Code
        {
            set => this._code = value;
            get => this._code;
        }
        public void Desconcatenar(string d)
        {
            string[] lit = d.Split('*');
            this._code = lit[0];
            this._productName = lit[1];            
        }
        public string Concatenar()
        {
            string lit = "";
            for(int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0: lit = String.Concat(this._code, "*"); break;
                    case 1: lit = String.Concat(lit, this._productName); break;
                }
            }
            return (lit);
        }        
    }
}
