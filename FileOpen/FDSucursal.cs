using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class FDSucursal
    {
        private string _Kdload;
        private string _Kdsave;
        private List<Sucursal> _ListadoOP;

        public FDSucursal(string archivo)
        {
            this._ListadoOP = new List<Sucursal>();
            this._Kdload = FUNCTION.ConcatenadorFile(archivo, ".dat");
            this._Kdsave = FUNCTION.ConcatenadorFile(archivo, "-temp.dat");
        }
        public FDSucursal(string sucursal, string codigo)
        {
            string kt = @Directory.GetCurrentDirectory();
            string kt_save = kt.Replace(@"\bin\Debug", @"\BaseData\Sucursales\");
            string archivo = String.Concat(sucursal, "_", codigo, ".dat"); 
            this._Kdsave = String.Concat(kt_save, archivo);
        }
        public int CountListSucursal()
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
        public void LoadFileSucursales(ref List<Sucursal> listado)
        {
            string codigo_encriptado = "";
            StreamReader sr = new StreamReader(this._Kdload);
            while (codigo_encriptado != null)
            {
                codigo_encriptado = sr.ReadLine();
                if (codigo_encriptado != null)
                {
                    CodigoEnigma cod1 = new CodigoEnigma();
                    Sucursal sucursal = new Sucursal();
                    string codigo_descencriptado = cod1.Desencriptador(codigo_encriptado);
                    sucursal.Desconcatenar(codigo_descencriptado);
                    listado.Add(sucursal);
                }
            }
            sr.Close();
        }
        public void LoadFileSucursales()
        {
            string codigo_encriptado = "";
            StreamReader sr = new StreamReader(this._Kdload);
            while(codigo_encriptado != null)
            {
                codigo_encriptado = sr.ReadLine();
                if (codigo_encriptado != null)
                {
                    CodigoEnigma cod1 = new CodigoEnigma();
                    Sucursal sucursal = new Sucursal();
                    string codigo_descencriptado = cod1.Desencriptador(codigo_encriptado);
                    sucursal.Desconcatenar(codigo_descencriptado);
                    this._ListadoOP.Add(sucursal);
                }
            }
            sr.Close();
        }
        public void AgregarSucursal(Sucursal dato)
        {
            this._ListadoOP.Add(dato);
        }
        public void OrdenamientoSucursal()
        {
            bool t = true;

            while(t)
            {
                t = false;
                for(int i = 0; i < this._ListadoOP.Count - 1; i++)
                {
                    Sucursal A = this._ListadoOP[i];
                    Sucursal B = this._ListadoOP[i + 1];

                    if ((Sucursal.Comparador(A, B)) > 0)
                    {
                        Sucursal aux = this._ListadoOP[i];
                        this._ListadoOP[i] = this._ListadoOP[i + 1];
                        this._ListadoOP[i + 1] = aux;
                        t = true;
                    }
                }
            }
        }
        public int SeekNomSucursal(string nombre)
        {
            int i = 0;

            while ((i < this._ListadoOP.Count) && ((String.Compare(this._ListadoOP[i].NOMSUCURSAL, nombre)) != 0))
            {
                i++;
            }
            if (i == this._ListadoOP.Count) { i = -1; }
            return (i);
        }
        public int SeekCodSucursal(string codigo)
        {
            int i = 0;

            while ((i < this._ListadoOP.Count) && ((String.Compare(this._ListadoOP[i].CODIGO, codigo)) != 0))
            {
                i++;
            }
            if (i == this._ListadoOP.Count) { i = -1; }
            return (i);
        }
        public int IndexListSucursal(Sucursal dato)
        {
            int index = 0;

            while ((index < this._ListadoOP.Count) && ((Sucursal.Comparador(this._ListadoOP[index], dato)) != 0))
            {
                index++;
            }
            if (index == this._ListadoOP.Count)
            {
                index = -1;
            }
            return (index);
        }
        public void ReplaceListSucursal(int index, Sucursal dato)
        {
            this._ListadoOP.RemoveAt(index);
            this._ListadoOP.Insert(index, dato);    
        }
        public void RemoveListSucursal(int index)
        {
            this._ListadoOP.RemoveAt(index);
        }
        public void SaveFileSucursales()
        {
            StreamWriter sw = new StreamWriter(this._Kdsave);
            for(int i = 0; i < this._ListadoOP.Count; i++)
            {
                Sucursal seek = new Sucursal();
                seek = this._ListadoOP[i];
                string hp1 = seek.Concatenar();
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
        public void CrearSucursal()
        {
            StreamWriter sw = new StreamWriter(this._Kdsave);
            sw.Close();
        }
        public void EliminarSucursal()
        {
            File.Delete(this._Kdsave);
        }
        public Sucursal GetSucursal(int index)
        {
            return this._ListadoOP[index];
        }
    }
}
