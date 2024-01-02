using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class FDGanancia
    {
        private string _Kdload;
        private string _Kdsave;
        private List<SucursalGain> _ListadoOP;
        public FDGanancia(string archivo)
        {
            this._ListadoOP = new List<SucursalGain>();
            this._Kdload = FUNCTION.ConcatenadorFile(archivo, ".dat");
            this._Kdsave = FUNCTION.ConcatenadorFile(archivo, "-temp.dat");
        }
        public int SizeCountList()
        {
            int count = 0;
            string valorf = "";
            StreamReader srtp = new StreamReader(this._Kdload);
            while (valorf != null)
            {
                valorf = srtp.ReadLine();
                if (valorf != null)
                {
                    count++;
                }
            }
            srtp.Close();
            return (count);
        }
        public int CountSizeList() => this._ListadoOP.Count;
        public void LoadListGain()
        {
            string valorf = "";
            StreamReader sr = new StreamReader(this._Kdload);
            while(valorf != null)
            {
                valorf = sr.ReadLine();
                if (valorf != null)
                {
                    CodigoEnigma cod = new CodigoEnigma();
                    string des = cod.Desencriptador(valorf);
                    SucursalGain obj = new SucursalGain();
                    obj.Desconcatenar(des);
                    this._ListadoOP.Add(obj);
                }
            }
            sr.Close();
        }
        public void LoadListGain(ref List<SucursalGain> listado)
        {
            string valorf = "";
            StreamReader sr = new StreamReader(this._Kdload);
            while (valorf != null)
            {
                valorf = sr.ReadLine();
                if (valorf != null)
                {
                    CodigoEnigma cod = new CodigoEnigma();
                    string des = cod.Desencriptador(valorf);
                    SucursalGain obj = new SucursalGain();
                    obj.Desconcatenar(des);
                    listado.Add(obj);
                }
            }
            sr.Close();
        }
        public void ClearData() => this._ListadoOP.Clear();
        public void RemoveAtList(int index) => this._ListadoOP.RemoveAt(index);
        public void BurbujaOrdenamiento()
        {
            bool est = true;
            do 
            {
                est = false;
                for(int i = 0; i < (this._ListadoOP.Count - 1); i++)
                {
                    SucursalGain A = this._ListadoOP[i];
                    SucursalGain B = this._ListadoOP[i + 1];
                    int k = (A == B);
                    if (k > 0)
                    {
                        SucursalGain aux = this._ListadoOP[i];
                        this._ListadoOP[i] = this._ListadoOP[i + 1];
                        this._ListadoOP[i + 1] = aux;
                        est = true;
                    }
                }
            } while (est);
        }
        public void AddSucursalGain(SucursalGain A)
        {
            int i = 0;
            while ((i < this._ListadoOP.Count) && ((this._ListadoOP[i] == A) != 0))
            {
                i++;
            }
            if (i == this._ListadoOP.Count) { this._ListadoOP.Add(A); }
            else
            {
                this._ListadoOP[i].MDolar += A.MDolar;
                this._ListadoOP[i].MPesos += A.MPesos;
            }
        }
        public float CalcularMonto(Moneda fit)
        {
            float monto = 0;

            for(int i = 0; i < this._ListadoOP.Count; i++)
            {
                if (fit == Moneda._DOLARES)
                {
                    monto += this._ListadoOP[i].MDolar;
                }
                if (fit == Moneda._PESOS)
                {
                    monto += this._ListadoOP[i].MPesos;
                }
            }

            return (monto);
        }
        public void SaveListGanancias()
        {
            StreamWriter sw = new StreamWriter(this._Kdsave);
            for (int i = 0; i < this._ListadoOP.Count; i++)
            {
                SucursalGain seek = new SucursalGain();
                seek = this._ListadoOP[i];
                string h1 = seek.Concatenador();
                CodigoEnigma cod = new CodigoEnigma();
                string h2 = cod.Encriptador(h1);
                sw.WriteLine(h2);
            }
            sw.Close();
            File.Delete(this._Kdload);
            File.Move(this._Kdsave, this._Kdload);
            this._ListadoOP.Clear();
        }
        public void ClearListGanancias()
        {
            StreamWriter sw = new StreamWriter(this._Kdsave);
            sw.Close();

        }
    }
}
