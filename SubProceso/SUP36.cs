using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;
using PCD_EVENT_DATA;
using PCD_INOUT_INFO;

namespace SuperMarket_SA
{
    public class SUP36
    {
        public static void VolverMenu(ref BDState dt)
        {
            dt.SetMState(TypeState._ContaduriaGanancia, ContaduriaGanancia._none);
            dt.SetMState(TypeState._LiveContaduriaGanancia, LiveProgram._none);
            dt.SetMState(TypeState._LiveContaduriaST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._MENUOPTION);
            dt.SetMState(TypeState._StateMain, StateMain._CONTADURIA);
        }
        public static void ViewGain(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            IOdata.Selector(color.BLANCO, color.AZUL, "  Contaduria - Ganancias  ", 26, (dt.WIDTH - 26) / 2, 8);
            color[] backtitulo2 = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 5, 50, 20 , 20 , 20 , 30 , 30 }, new int[] { 3 , 32 }, 12, 12);

            DRAW.CuadradoSolid(color.DARK_GRIS, 3, 1, 13, 13);
            DRAW.CuadradoSolid(color.DARK_GRIS, 48, 1, 19, 13);
            DRAW.CuadradoSolid(color.DARK_GRIS, 18, 1, 70, 13);
            DRAW.CuadradoSolid(color.DARK_AMARILLO, 18, 1, 91, 13);
            DRAW.CuadradoSolid(color.DARK_AMARILLO, 18, 1, 112, 13);
            DRAW.CuadradoSolid(color.DARK_ROJO, 28, 1, 133, 13);
            DRAW.CuadradoSolid(color.DARK_ROJO, 27, 1, 164, 13);

            OUT.PrintLine("N°", color.CYAN, color.DARK_GRIS, 14, 14);
            OUT.PrintLine("nombre sucursal", color.CYAN, color.DARK_GRIS, 33, 14);
            OUT.PrintLine("codigo", color.CYAN, color.DARK_GRIS, 76, 14);
            OUT.PrintLine("Monto en Dolares", color.MAGENTA, color.DARK_AMARILLO, 93, 14);
            OUT.PrintLine(" Monto en Pesos ", color.MAGENTA, color.DARK_AMARILLO, 114, 14);
            OUT.PrintLine(" SubCalculo en Dolares ", color.NEGRO, color.DARK_ROJO, 136, 14);
            OUT.PrintLine("  SubCalculo en Pesos  ", color.NEGRO, color.DARK_ROJO, 166, 14);

            IOBUTTON btn_CLEARITEM_ = new IOBUTTON(" BORRAR ITEM ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 203, 12);
            IOBUTTON btn_CLEARALL_ = new IOBUTTON(" BORRAR TODO ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 203, 19);
            IOBUTTON btn_VOLVER_ = new   IOBUTTON(" VOLVER MENU ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 203, 26);
            IN key_data = new IN();

            btn_CLEARITEM_.SetDataInfo(false);
            btn_CLEARALL_.SetDataInfo(false);
            btn_VOLVER_.SetDataInfo(false);

            key_data.SetCondIN(INCond._ARROWS);
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            List<SucursalGain> listado = new List<SucursalGain>();
            FDGanancia opus_gain = new FDGanancia("Ganancias");
            opus_gain.LoadListGain(ref listado);

            float totaldolar = opus_gain.CalcularMonto(Moneda._DOLARES);
            float totalpesos = opus_gain.CalcularMonto(Moneda._PESOS);

            bool estado = true, script = false;
            int inicio = 0, tope = 0, nivel = 0, index = 0, k = 0, cl = 0;

            tope = listado.Count;
            if (listado.Count > 10) { tope = 10; }

            while (estado)
            {
                if (nivel == 0)
                {
                    btn_CLEARITEM_.SetInactivated();
                    btn_CLEARALL_.SetInactivated();
                    btn_VOLVER_.SetInactivated();

                    btn_CLEARITEM_.Display(color.NEGRO, color.NEGRO);
                    btn_CLEARALL_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    k = 0;
                    for(int i = inicio; i < tope; i++)
                    {
                        if (index == i) { cl = 1; }
                        else { cl = 0; }
                        FUNCTION.MostrarGanancia(listado[i], i, cl, k, dt.DOLARPESOS);
                        k++;
                    }
                }
                if (nivel == 1)
                {
                    if (((dt.USERSESION.SystemContaduria >> 4) & 1) == 1)
                    {
                        btn_CLEARALL_.SetInactivated();
                        btn_VOLVER_.SetInactivated();

                        switch(script)
                        {
                            case false: btn_CLEARITEM_.SetSemiInactivated(); break;
                            case true: btn_CLEARITEM_.SetActivated(); break;
                        }
                        btn_CLEARALL_.Display(color.NEGRO, color.NEGRO);
                        btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                        btn_CLEARITEM_.Display(color.NEGRO, color.NEGRO);
                    } else { nivel = 2; }
                }
                if (nivel == 2)
                {
                    if (((dt.USERSESION.SystemContaduria >> 5) & 1) == 1)
                    {
                        btn_CLEARITEM_.SetInactivated();
                        btn_VOLVER_.SetInactivated();

                        switch (script)
                        {
                            case false: btn_CLEARALL_.SetSemiInactivated(); break;
                            case true: btn_CLEARALL_.SetActivated(); break;
                        }
                        btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                        btn_CLEARITEM_.Display(color.NEGRO, color.NEGRO);
                        btn_CLEARALL_.Display(color.NEGRO, color.NEGRO);
                    }
                    else { nivel = 3; }
                }
                if (nivel == 3)
                {
                    btn_CLEARITEM_.SetInactivated();
                    btn_CLEARALL_.SetInactivated();

                    switch (script)
                    {
                        case false: btn_VOLVER_.SetSemiInactivated(); break;
                        case true: btn_VOLVER_.SetActivated(); break;
                    }
                    btn_CLEARITEM_.Display(color.NEGRO, color.NEGRO);
                    btn_CLEARALL_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)(btn_CLEARALL_.GetDataInfo()))
                {
                    btn_CLEARALL_.SetDataInfo(false);
                    if ((listado.Count) > 0)
                    {
                        FUNCTION.TableClear2();
                        listado.Clear();
                        opus_gain.LoadListGain();
                        opus_gain.ClearListGanancias();
                        opus_gain.SaveListGanancias();
                        tope = inicio = index = 0;
                        nivel = 0;
                    }
                }
                if ((bool)(btn_CLEARITEM_.GetDataInfo()))
                {
                    btn_CLEARITEM_.SetDataInfo(false);
                    if ((listado.Count) > 0)
                    {
                        FUNCTION.TableClear2();
                        listado.RemoveAt(index);
                        opus_gain.LoadListGain();
                        opus_gain.RemoveAtList(index);
                        opus_gain.BurbujaOrdenamiento();
                        opus_gain.SaveListGanancias();
                        tope = listado.Count;
                        if (listado.Count > 10) { tope = 10; }
                        inicio = nivel = index = 0;
                    }
                }
                if ((bool)(btn_VOLVER_.GetDataInfo()))
                {
                    btn_VOLVER_.SetDataInfo(false);
                    script = true;
                    estado = false;
                    dt.SetMState(TypeState._ContaduriaGanancia, ContaduriaGanancia._VOLVER);
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if (((tecla.Equals("DOWNARROW")) || (tecla.Equals("UPARROW")) || (tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW"))) && (nivel == 0))
                    {
                        if ((tecla.Equals("UPARROW")) || (tecla.Equals("DOWNARROW")))
                        {
                            if (tecla.Equals("DOWNARROW"))
                            {
                                index++;
                                if (index == tope) { index = inicio; }
                            }
                            if (tecla.Equals("UPARROW"))
                            {
                                index--;
                                if (index == -1) { index = tope - 1; }
                            }
                        }
                        if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")))
                        {
                            FUNCTION.TableClear2();
                            if (tecla.Equals("RIGHTARROW"))
                            {
                                inicio += 10;
                                tope += 10;
                                if ((tope > listado.Count) && (inicio < listado.Count))
                                {
                                    tope = listado.Count;
                                }
                                else
                                {
                                    if ((tope >= listado.Count) && (inicio >= listado.Count))
                                    {
                                        inicio = 0;
                                        if (listado.Count > 10) { tope = 10; }
                                        else { tope = listado.Count; }
                                    }
                                }
                            }
                            if (tecla.Equals("LEFTARROW"))
                            {
                                inicio -= 10;
                                tope -= 10;
                                if ((inicio < 0) && (tope == 0) && (listado.Count > 10))
                                {
                                    tope = listado.Count;
                                    inicio = (tope / 10) * 10;
                                    if ((tope - inicio) == 0)
                                    {
                                        inicio = tope - 10;
                                    }
                                }
                                else
                                {
                                    if ((inicio < 0) && (tope < 0) && (listado.Count < 10))
                                    {
                                        inicio = 0;
                                        tope = listado.Count;
                                    }
                                    else
                                    {
                                        if (((tope - inicio) < 10) && ((tope % 10) != 0) && ((listado.Count - tope) == 10))
                                        {
                                            tope = inicio + 10;
                                        }
                                    }
                                }
                            }
                            index = inicio;
                        }
                    } else
                    {
                        if (tecla.Equals("TAB"))
                        {
                            nivel++;
                            if (nivel == 4) { nivel = 0; }
                        } else
                        {
                            if (tecla.Equals("ENTER"))
                            {
                                script = true;
                            }
                        }
                    }
                } else { script = false; }                
            }            
        }
    }
}
