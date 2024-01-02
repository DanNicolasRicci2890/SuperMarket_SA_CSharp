using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PasswordData
    {
        private string _PasswordActual;
        private string _PasswordNew1;
        private string _PasswordNew2;

        public PasswordData()
        {
            this._PasswordActual = "";
            this._PasswordNew1 = "";
            this._PasswordNew2 = "";
        }
        public string PASSWORD_ACTUAL
        {
            set => this._PasswordActual = value;
            get => this._PasswordActual;
        }
        public string PASSWORD_NEW1
        {
            set => this._PasswordNew1 = value;
            get => this._PasswordNew1;
        }
        public string PASSWORD_NEW2
        {
            set => this._PasswordNew2 = value;
            get => this._PasswordNew2;
        }
    }
}
