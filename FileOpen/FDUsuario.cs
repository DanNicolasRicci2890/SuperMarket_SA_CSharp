using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class FDUsuario
    {
        private string _Kdload;
        private string _Kdsave;
        private List<Usuario> _ListadoOP;

        public FDUsuario(string archivo)
        {
            this._ListadoOP = new List<Usuario>();
            this._Kdload = FUNCTION.ConcatenadorFile(archivo, ".dat");
            this._Kdsave = FUNCTION.ConcatenadorFile(archivo, "-temp.dat");
        }
        ~FDUsuario()
        {
            this._ListadoOP = null;
            this._Kdload = null;
            this._Kdsave = null;
        }
        public int CountListUser()
        {
            int count = 0;
            string valorf = "";

            StreamReader sr = new StreamReader(this._Kdload);

            while(valorf != null)
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
        public void SaveListUser()
        {
            CodigoEnigma cod1 = new CodigoEnigma();
            string valor_encriptado = "", valor_concatenado = "";
            Usuario seek = new Usuario();

            StreamWriter sw = new StreamWriter(this._Kdsave);
            for(int i = 0; i < this._ListadoOP.Count; i++)
            {
                seek = this._ListadoOP[i];
                valor_concatenado = seek.Concatenar();
                valor_encriptado = cod1.Encriptador(valor_concatenado);
                sw.WriteLine(valor_encriptado);
            }
            sw.Close();
            File.Delete(this._Kdload);
            File.Move(this._Kdsave, this._Kdload);
            this._ListadoOP.Clear();   
        }
        public void BurbujaListUser()
        {
            bool t = true;

            while(t)
            {
                t = false;
                for(int i = 0; i < (this._ListadoOP.Count - 1); i++)
                {
                    Usuario A = this._ListadoOP[i];
                    Usuario B = this._ListadoOP[i + 1];
                    if (((Usuario.ComparadorUsuarios(A, B)) > 0) && (i != 0))
                    {
                        Usuario aux = this._ListadoOP[i];
                        this._ListadoOP[i] = this._ListadoOP[i + 1]; 
                        this._ListadoOP[i + 1] = aux;
                        t = true;
                    }
                }
            }
        }
        public void AddListUser(Usuario dato)
        {
            this._ListadoOP.Add(dato);
        }
        public void ReplaceListUser(Usuario dato, int pos)
        {
            this._ListadoOP.RemoveAt(pos);
            this._ListadoOP.Insert(pos, dato);
        }
        public void LoadListUser(ref List<Usuario> listado)
        {
            CodigoEnigma cod1 = new CodigoEnigma();
            string valor_encriptado = "", valor_descencriptado = "";            
            StreamReader sr = new StreamReader(this._Kdload);

            while (valor_encriptado != null)
            {
                valor_encriptado = sr.ReadLine();
                if (valor_encriptado != null)
                {
                    Usuario seek = new Usuario();
                    valor_descencriptado = cod1.Desencriptador(valor_encriptado);
                    seek.Desconcatenar(valor_descencriptado);
                    listado.Add(seek);
                }
            }
            sr.Close();
        }
        public void LoadListUser()
        {
            CodigoEnigma cod1 = new CodigoEnigma();
            string valor_encriptado = "", valor_descencriptado = "";
            StreamReader sr = new StreamReader(this._Kdload);

            while(valor_encriptado != null)
            {
                valor_encriptado = sr.ReadLine();
                if (valor_encriptado != null)
                {
                    Usuario seek = new Usuario();
                    valor_descencriptado = cod1.Desencriptador(valor_encriptado);
                    seek.Desconcatenar(valor_descencriptado);
                    this._ListadoOP.Add(seek);
                }
            }
            sr.Close();
        }
        public void RemoveUser(int index) => this._ListadoOP.RemoveAt(index);
        public int SeekUserList(string legajo)
        {
            int index = 0;
            
            while((index < this._ListadoOP.Count) && (this._ListadoOP[index].Legajo != legajo))
            {
                index++;
            }
            if (index == this._ListadoOP.Count) { index = -1; }
            return index;
        }
//-----------------------------------------------------------------------------------------------
    }
}
