using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public enum CondStock
    {
        _INCREMENTO = 0,
        _DECREMENTO = 1,
    }
    public class FDStockProduct
    {
        private string _Kdload;
        private string _Kdsave;
        private List<StockProduct> _Listado;  

        public FDStockProduct(string sucursal, string cod)
        {
            this._Listado = new List<StockProduct>();
            this._Kdload = FUNCTION.ConcatenadorFile3(sucursal, cod, ".dat");
            this._Kdsave = FUNCTION.ConcatenadorFile3(sucursal, cod, "-temp.dat");
        }
        public int CountStockProduct()
        {
            return (this._Listado.Count);
        }
        public void LoadStockProduct(ref List<StockProduct> lt, string cond)
        {
            string valorf = "";
            StreamReader sr = new StreamReader(this._Kdload);
            while (valorf != null)
            {
                valorf = sr.ReadLine();
                if (valorf != null)
                {
                    CodigoEnigma cod = new CodigoEnigma();
                    string valorg = cod.Desencriptador(valorf);
                    StockProduct sp = new StockProduct();
                    sp.Desconcatenar(valorg);

                    if (sp.Codigo.Equals(cond)) { lt.Add(sp); }                    
                }
            }
            sr.Close();
        }
        public void LoadStockProduct(ref List<StockProduct> lt)
        {
            string valorf = "";
            StreamReader sr = new StreamReader(this._Kdload);
            while (valorf != null)
            {
                valorf = sr.ReadLine();
                if (valorf != null)
                {
                    CodigoEnigma cod = new CodigoEnigma();
                    string valorg = cod.Desencriptador(valorf);
                    StockProduct sp = new StockProduct();
                    sp.Desconcatenar(valorg);
                    lt.Add(sp);
                }
            }
            sr.Close();
        }
        public void LoadStockProduct()
        {
            string valorf = "";
            StreamReader sr = new StreamReader(this._Kdload);
            while(valorf != null)
            {
                valorf = sr.ReadLine();
                if (valorf != null)
                {
                    CodigoEnigma cod = new CodigoEnigma();
                    string valorg = cod.Desencriptador(valorf);
                    StockProduct sp = new StockProduct();
                    sp.Desconcatenar(valorg);
                    this._Listado.Add(sp);
                }
            }
            sr.Close();
        }
        public StockProduct GetStockProducto(int index)
        {
            return (this._Listado[index]);
        }
        public int SeekStockProduct(string code)
        {
            int i = 0;
            while ((i < this._Listado.Count) && (this._Listado[i].CodigoProducto != code))
            {
                i++;
            }
            if (i == this._Listado.Count) { i = -1; }
            return (i);
        }
        public void RemoveStockProduct(int index)
        {
            this._Listado.RemoveAt(index);
        }
        public void AddStockProduct(StockProduct vot, CondStock cond)
        {
            int i = 0;

            while ((i < this._Listado.Count) && (this._Listado[i].CodigoProducto != vot.CodigoProducto))
            {
                i++;
            }
            
            if (i == this._Listado.Count) { this._Listado.Add(vot); }
            else
            {
                if (i < this._Listado.Count) 
                { 
                    switch(cond)
                    {
                        case (CondStock._INCREMENTO): this._Listado[i].StockDeposito += vot.StockDeposito; break;
                        case (CondStock._DECREMENTO): this._Listado[i].StockDeposito -= vot.StockDeposito; break;
                    }
                    
                }
            }            
        }
        public void OrdenamientoBurbuja()
        {
            bool t = true;
            do 
            {
                t = false;
                for(int i = 0; i < (this._Listado.Count - 1); i++)
                {
                    StockProduct A = this._Listado[i];
                    StockProduct B = this._Listado[i + 1];
                    if ((StockProduct.Comparador(A, B)) > 0)
                    {
                        StockProduct aux = this._Listado[i];
                        this._Listado[i] = this._Listado[i + 1];
                        this._Listado[i + 1] = aux;
                        t = true;   
                    }
                }
            } while (t);
        }
        public void SaveStockProduct()
        {
            StreamWriter sw = new StreamWriter(this._Kdsave);
            for (int i = 0; i < this._Listado.Count; i++)
            {
                StockProduct seek = new StockProduct();
                seek = this._Listado[i];
                string hp1 = seek.Concatenador();
                CodigoEnigma cod1 = new CodigoEnigma();
                string hp2 = cod1.Encriptador(hp1);
                sw.WriteLine(hp2);
            }
            sw.Close();
            // eliminar el archivo original
            File.Delete(this._Kdload);
            // modificar el archivo temporario a archivo original
            File.Move(this._Kdsave, this._Kdload);
        }
    }
}
