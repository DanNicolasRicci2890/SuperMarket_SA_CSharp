using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class FDTypeProduct
    {
        private string _Kdload;
        private string _Kdsave;
        private List<TypeProduct> _ListadoOP;
        public FDTypeProduct(string archivo)
        {
            this._ListadoOP = new List<TypeProduct>();
            this._Kdload = FUNCTION.ConcatenadorFile(archivo, ".dat");
            this._Kdsave = FUNCTION.ConcatenadorFile(archivo, "-temp.dat");
        }
        public FDTypeProduct(string codigo, string tipoproducto)
        {
            string kt = @Directory.GetCurrentDirectory();
            string kt_save = kt.Replace(@"\bin\Debug", @"\BaseData\Productos\");
            if (!Directory.Exists(kt_save))
            {
                Directory.CreateDirectory(kt_save);
            }
            string archivo = tipoproducto.Replace(' ','_');

            archivo = String.Concat(codigo, "_", archivo, ".dat");
            this._Kdsave = String.Concat(kt_save, archivo);            
        }
        public void RemoveTypeProducto2()
        {
            File.Delete(this._Kdsave);
        }
        public int CountListTypeProduct()
        {
            return (this._ListadoOP.Count);
        }
        public int Count_ListTypeProduct()
        {
            int count = 0;
            string valorf = "";            
            StreamReader sr = new StreamReader(this._Kdload);
            while (valorf != null)
            {
                valorf = sr.ReadLine();
                if (valorf != null)
                {
                    count++;
                }
            }
            sr.Close();

            return (count);
        }
        public void LoadTypeProductList(ref List<TypeProduct> lister)
        {
            string valorf = "";
            CodigoEnigma cod1 = new CodigoEnigma();
            StreamReader sr = new StreamReader(this._Kdload);
            while (valorf != null)
            {
                valorf = sr.ReadLine();
                if (valorf != null)
                {
                    valorf = cod1.Desencriptador(valorf);
                    TypeProduct seek = new TypeProduct();
                    seek.Desconcatenar(valorf);
                    lister.Add(seek);
                }
            }
            sr.Close();
        }
        public void LoadTypeProductList()
        {
            string valorf = "";
            CodigoEnigma cod1 = new CodigoEnigma();
            StreamReader sr = new StreamReader(this._Kdload);
            while(valorf != null)
            {
                valorf = sr.ReadLine();
                if (valorf != null)
                {
                    valorf = cod1.Desencriptador(valorf);
                    TypeProduct seek = new TypeProduct();
                    seek.Desconcatenar(valorf);
                    this._ListadoOP.Add(seek);
                }
            }
            sr.Close();
        }
        public int SeekNomTypeProduct(string nombre)
        {
            int i = 0;
            
            while ((i < this._ListadoOP.Count) && ((String.Compare(this._ListadoOP[i].ProductName, nombre)) != 0))
            {
                i++;
            }
            if (i == this._ListadoOP.Count) { i = -1; }
            return i;
        }
        public int SeekCodeTypeProduct(string code)
        {
            int i = 0;

            while ((i < this._ListadoOP.Count) && ((String.Compare(this._ListadoOP[i].Code, code)) != 0))
            {
                i++;
            }
            if (i == this._ListadoOP.Count) { i = -1; }
            this._ListadoOP.Clear();
            return i;
        }
        public void AddTypeProductList(TypeProduct dato)
        {
            this._ListadoOP.Add(dato);  
        }
        public void SaveTypeProductList()
        {
            StreamWriter sw = new StreamWriter(this._Kdsave);
            for (int i = 0; i < this._ListadoOP.Count; i++)
            {
                TypeProduct seek = new TypeProduct();
                seek = this._ListadoOP[i];
                string h1 = seek.Concatenar();
                CodigoEnigma cod1 = new CodigoEnigma();
                string h2 = cod1.Encriptador(h1);
                sw.WriteLine(h2);
            }
            sw.Close();
            // eliminar el archivo original
            File.Delete(this._Kdload);
            // modificar el archivo temporario a archivo original
            File.Move(this._Kdsave, this._Kdload);
            this._ListadoOP.Clear();                     
        }
        public void SaveProductFile()
        {
            StreamWriter sw = new StreamWriter(this._Kdsave);
            sw.Close();
        }
        public void OrdenamientoTypeProducto()
        {
            bool t = true;
            while(t)
            {
                t = false;
                for(int i = 0; i < (this._ListadoOP.Count - 1); i++)
                {
                    TypeProduct A = this._ListadoOP[i];
                    TypeProduct B = this._ListadoOP[i + 1];

                    if ((String.Compare(A.ProductName, B.ProductName)) > 0)
                    {
                        TypeProduct aux = this._ListadoOP[i];
                        this._ListadoOP[i] = this._ListadoOP[i + 1];
                        this._ListadoOP[i + 1] = aux;
                        t = true;
                    }
                }
            }
        }
        public void RemoveTypeProducto(int index)
        {
            this._ListadoOP.RemoveAt(index);
        }
        public TypeProduct GetTypeProducto(int index)
        {
            return (this._ListadoOP[index]);
        }
    }
}
