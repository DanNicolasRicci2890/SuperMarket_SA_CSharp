using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_SA
{
    public class PR23
    {
        /*
            PR23: (FINALIZADO)
                Elimina el tipos de Productos.
        */
        public static void RemoveTypeProductList(ref BDState dt)
        {
            while (dt.EqualsMState(TypeState._LiveProductosRemoveTypeST, (LiveProgram)LiveProgram._ACTIVATED))
            {
                switch ((ProductosRemoveTypeST)(dt.GetMState(TypeState._ProductosRemoveTypeST))) 
                {
                    case (ProductosRemoveTypeST._VERIF): SUP23.VerificarTypeProducts(ref dt); break;
                    case (ProductosRemoveTypeST._VOLVER): SUP23.VolverTipoProducto(ref dt); break;
                    case (ProductosRemoveTypeST._MENSAGE1): SUP23.MensageP1(ref dt); break;
                    case (ProductosRemoveTypeST._NOMTP): SUP23.BuscadorNom(ref dt); break;
                    case (ProductosRemoveTypeST._MENSAGE2): SUP23.MensageP2(ref dt); break;
                    case (ProductosRemoveTypeST._VERIF_NOM): SUP23.SeekForNomTypeProduct(ref dt); break;
                    case (ProductosRemoveTypeST._MENSAGE3): SUP23.MensageP3(ref dt); break;
                    case (ProductosRemoveTypeST._VIEW_TP): SUP23.VisualizarTipoProducto(ref dt); break;
                    case (ProductosRemoveTypeST._REMOVE_TP): SUP23.RemoveTipoProducto1(ref dt); break;
                    case (ProductosRemoveTypeST._REMOVE_TP2): SUP23.RemoveTipoProducto2(ref dt); break;
                    case (ProductosRemoveTypeST._MENSAGE4): SUP23.MensageP4(ref dt); break;
                }
            }
        }
    }
}
