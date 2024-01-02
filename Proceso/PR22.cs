using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR22
    {
        /*
            PR22: (FINALIZADO)
                Administra el ingreso de tipos de Productos.
        */
        public static void AddTypeProduct(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveProductosAddTypeST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ProductosAddTypeST)(dt.GetMState(TypeState._ProductosAddTypeST)))
                {
                    case (ProductosAddTypeST._PRESENT): SUP22.Presentador(ref dt); break;
                    case (ProductosAddTypeST._IN_DATA): SUP22.IngresarTipoProducto(ref dt); break;
                    case (ProductosAddTypeST._VOLVER): SUP22.VolverMenu(ref dt); break;
                    case (ProductosAddTypeST._VERIF_CONT): SUP22.VerifContenido(ref dt); break;
                    case (ProductosAddTypeST._MENSAGE1): SUP22.MensageP1(ref dt); break;
                    case (ProductosAddTypeST._MENSAGE2): SUP22.MensageP2(ref dt); break;
                    case (ProductosAddTypeST._VERIF_NOM): SUP22.VerifExitNom(ref dt); break;
                    case (ProductosAddTypeST._MENSAGE3): SUP22.MensageP3(ref dt); break;
                    case (ProductosAddTypeST._VERIF_COD): SUP22.VerifExitCode(ref dt); break;
                    case (ProductosAddTypeST._MENSAGE4): SUP22.MensageP4(ref dt); break;
                    case (ProductosAddTypeST._SAVE_TYPEPROD): SUP22.SaveTypeProduct(ref dt); break;
                    case (ProductosAddTypeST._SAVE_FILETP): SUP22.SaveFileProduct(ref dt); break;
                    case (ProductosAddTypeST._MENSAGE5): SUP22.MensageP5(ref dt); break;
                }
            }
        }
    }
}
