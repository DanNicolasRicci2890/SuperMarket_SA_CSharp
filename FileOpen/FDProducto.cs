using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class FDProducto
    {
        private string _Kdload;
        private string _Kdsave;
        private List<TypeProduct> _ListadoOP;
        private List<Producto> _ListadoPRO;
        public FDProducto(string archivo)
        {
            this._ListadoOP = new List<TypeProduct>();            
            this._ListadoPRO = new List<Producto>();
            this._Kdload = FUNCTION.ConcatenadorFile(archivo, ".dat"); 
            this._Kdsave = FUNCTION.ConcatenadorFile(archivo, "-temp.dat");
        }
        public FDProducto(string nom, string cod)
        {
            this._ListadoOP = new List<TypeProduct>();
            this._ListadoPRO = new List<Producto>();
            this._Kdload = FUNCTION.ConcatenadorFile2(nom, cod, ".dat");
            this._Kdsave = FUNCTION.ConcatenadorFile2(nom, cod, "-temp.dat");
        }
        public int CountListProducto()
        {
            int count = 0;
            string valorf = "";
            StreamReader srtp = new StreamReader(this._Kdload);
            while(valorf != null)
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
        public void OrdenarListProductos()
        {
            bool t = true;

            do 
            {
                t = false;
                for(int i = 0; i < this._ListadoPRO.Count - 1; i++)
                {
                    Producto A = this._ListadoPRO[i];
                    Producto B = this._ListadoPRO[i + 1];
                    if ((Producto.Comparador(A, B)) > 0)
                    {
                        Producto aux = this._ListadoPRO[i];
                        this._ListadoPRO[i] = this._ListadoPRO[i + 1];
                        this._ListadoPRO[i + 1] = aux;
                        t = true;
                    }
                }
            } while (t);
        }
        public void AgregarDatos(Producto dot) => this._ListadoPRO.Add(dot);
        public void LoadListProduct(ref List<Producto> lister)
        {
            string valorf = "";
            StreamReader sr = new StreamReader(this._Kdload);
            while (valorf != null)
            {
                valorf = sr.ReadLine();
                if (valorf != null)
                {
                    CodigoEnigma cod = new CodigoEnigma();
                    string h1 = cod.Desencriptador(valorf);
                    Producto po = new Producto();
                    po.Desconcatenar(h1);
                    lister.Add(po);
                }
            }
            sr.Close();
        }
        public void LoadListProduct()
        {
            string valorf = "";
            StreamReader sr = new StreamReader(this._Kdload);
            while(valorf != null)
            {
                valorf = sr.ReadLine();
                if (valorf != null)
                {
                    CodigoEnigma cod = new CodigoEnigma();
                    string h1 = cod.Desencriptador(valorf);
                    Producto po = new Producto();
                    po.Desconcatenar(h1);
                    this._ListadoPRO.Add(po);
                }
            }
            sr.Close();
        }
        public int BuscadorCodigo(string code, string nombre)
        {
            string valortp = "";
            int condicion = 0;
            StreamReader srtp = new StreamReader(this._Kdload);
            while(valortp != null)
            {
                valortp = srtp.ReadLine();
                if (valortp != null)
                {
                    CodigoEnigma codtp = new CodigoEnigma();
                    valortp = codtp.Desencriptador(valortp);
                    TypeProduct tp = new TypeProduct();
                    tp.Desconcatenar(valortp);
                    string kt = @Directory.GetCurrentDirectory();
                    string kt_load = kt.Replace(@"\bin\Debug", @"\BaseData\Productos\");
                    string filetp = String.Concat(kt_load, tp.ProductName, "_", tp.Code, ".dat");
                    string valorp = "";

                    StreamReader srp = new StreamReader(filetp);
                    while(valorp != null)
                    {
                        valorp = srp.ReadLine();
                        if (valorp != null)
                        {
                            CodigoEnigma codp = new CodigoEnigma();
                            valorp= codp.Desencriptador(valorp);
                            Producto pt = new Producto();
                            pt.Desconcatenar(valorp);
                            if (pt.Codigo.Equals(code))
                            {
                                condicion += 1;
                            }
                            if (pt.NombreProducto.Equals(nombre))
                            {
                                condicion += 2;
                            }
                        }
                    }
                    srp.Close();
                }
            }
            srtp.Close();
            return condicion;
        }
        public Producto BuscadorCodigo(string code)
        {
            Producto obj = new Producto();
            obj.Codigo = "---";
            string valortp = "";
            StreamReader srtp = new StreamReader(this._Kdload);
            while (valortp != null)
            {
                valortp = srtp.ReadLine();
                if (valortp != null)
                {
                    CodigoEnigma codtp = new CodigoEnigma();
                    valortp = codtp.Desencriptador(valortp);
                    TypeProduct tp = new TypeProduct();
                    tp.Desconcatenar(valortp);
                    string kt = @Directory.GetCurrentDirectory();
                    string kt_load = kt.Replace(@"\bin\Debug", @"\BaseData\Productos\");
                    string filetp = String.Concat(kt_load, tp.ProductName, "_", tp.Code, ".dat");
                    string valorp = "";

                    StreamReader srp = new StreamReader(filetp);
                    while (valorp != null)
                    {
                        valorp = srp.ReadLine();
                        if (valorp != null)
                        {
                            CodigoEnigma codp = new CodigoEnigma();
                            valorp = codp.Desencriptador(valorp);
                            Producto pt = new Producto();
                            pt.Desconcatenar(valorp);
                            if (pt.Codigo.Equals(code))
                            {
                                obj = pt;
                            }
                        }
                    }
                    srp.Close();
                }
            }
            srtp.Close();
            return obj;
        }
        public void EliminarProducto(int index)
        {
            this._ListadoPRO.RemoveAt(index);
        }
        public void ModificarProducto(Producto pot, int index)
        {
            this._ListadoPRO.RemoveAt(index);
            this._ListadoPRO.Add(pot);
        }
        public int SeekProducto(string Codigo)
        {
            int i = 0;

            while ((i < this._ListadoPRO.Count) && (this._ListadoPRO[i].Codigo != Codigo))
            {
                i++;
            }
            if (i == this._ListadoPRO.Count) { i = -1; }
            return (i);
        }
        public int BuscarProducto(Producto pot)
        {
            int i = 0;

            while ((i < this._ListadoPRO.Count) && (this._ListadoPRO[i].Codigo != pot.Codigo))
            {
                i++;
            }
            if (i == this._ListadoPRO.Count) { i = -1; }
            return (i);
        }
        public Producto GetProducto(int index) => this._ListadoPRO[index];
        public void SaveListProductos()
        {
            StreamWriter sw = new StreamWriter(this._Kdsave);
            for(int i = 0; i < this._ListadoPRO.Count; i++)
            {
                Producto seek = new Producto();
                seek = this._ListadoPRO[i];
                string h1 = seek.Concatenar();
                CodigoEnigma cod = new CodigoEnigma();
                string h2 = cod.Encriptador(h1);
                sw.WriteLine(h2);
            }
            sw.Close();
            File.Delete(this._Kdload);
            File.Move(this._Kdsave, this._Kdload);
            this._ListadoPRO.Clear();
        }
    }
}
