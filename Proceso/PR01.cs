using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PCD_ScreemDisplay;
using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;

namespace SuperMarket_SA
{
    public class PR01
    {
        /*
            PR01: (FINALIZADO)
               Se realiza el proceso de inicio del programa:
                    _ Verifica si existe el usuario "usergod" con sus permisos especiales
                    _ Crea la carpeta de "BaseData".
                    _ Crea los Archivos "ListUserProgram.dat" y "ListSucursales.dat"
        */
        public static void VerificarSaved(ref BDState dt)
        {
            SUP01.InitVerif(ref dt);
            while (dt.EqualsMState(TypeState._LiveVerifcacion, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((VerificInicio)(dt.GetMState(TypeState._VerificInicio)))
                {
                    case (VerificInicio._READ01): SUP01.VerifListUser(ref dt); break;
                    case (VerificInicio._BORN01): SUP01.CreateListUser(ref dt); break;
                    case (VerificInicio._READ02): SUP01.SalidaVerificacion(ref dt); break;
                }
            }                        
        }        
    }
}
