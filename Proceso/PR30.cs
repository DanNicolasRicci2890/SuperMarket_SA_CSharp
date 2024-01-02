using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR30
    {
        /*
            PR30: (FINALIZADO)
                configura el valor del dolar en pesos.                
        */
        public static void ConfiguracionDolarPesos(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveContaduriaDolarPeso, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ContaduriaDolarPesos)(dt.GetMState(TypeState._ContaduriaDolarPesos))) 
                {
                    case (ContaduriaDolarPesos._CONFIG): SUP30.ConfigureValue(ref dt); break;
                    case (ContaduriaDolarPesos._VOLVER): SUP30.VolverContaduria(ref dt); break;
                    case (ContaduriaDolarPesos._MENSAGE_ERROR): SUP30.MensageError(ref dt); break;
                    case (ContaduriaDolarPesos._SAVE): SUP30.Save(ref dt); break;
                    case (ContaduriaDolarPesos._MENSAGE): SUP30.Mensage(ref dt); break;
                }
            }
        }
    }
}
