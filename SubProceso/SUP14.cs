using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;
using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class SUP14
    {
        public static void VisualSucursales(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSucursListST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursListST, SucursalesListST._none);
            dt.SetMState(TypeState._LiveSucursalVisual, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalVisual, SucursalVisual._VISUAL);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES_VISUAL);
            dt.COND_SUCURSAL = 5;
        }
        public static void VolverSucursales(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSucursListST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursListST, SucursalesListST._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalST, SucursalesST._MENUOPCION);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES);
        }
        public static void ListadoSucursalesSt(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            IOdata.Selector(color.BLANCO, color.AZUL, " Administracion - SUCURSALES - Listado de Sucursales ", 54, 78, 8);
            
            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 5, 60, 20 }, new int[] { 3 , 31 }, 20, 12);
            DRAW.CuadradoSolid(color.DARK_GRIS, 3, 1, 21, 13);
            DRAW.CuadradoSolid(color.DARK_GRIS, 58, 1, 27, 13);
            DRAW.CuadradoSolid(color.DARK_GRIS, 17, 1, 88, 13);
            OUT.PrintLine("N°", color.NEGRO, color.DARK_GRIS, 22, 14);
            OUT.PrintLine("nombre sucursal", color.NEGRO, color.DARK_GRIS, 33, 14);
            OUT.PrintLine("codigo", color.NEGRO, color.DARK_GRIS, 92, 14);
            
            // cargar la lista de sucursales.
            List<Sucursal> listado = new List<Sucursal>();
            FDSucursal sucursales = new FDSucursal("ListSucursales");
            sucursales.LoadFileSucursales(ref listado);
                        
            int inicio = 0, tope = 10, k = 0, position = 0;
            
            bool estado = true, script = true;
            IN key_data = new IN();
            key_data.SetCondIN(INCond._ARROWS);
            key_data.SetCondIN(INCond._ENTER);
            key_data.SetCondIN(INCond._ESCAPE);

            if (listado.Count < 10) { tope = listado.Count; }
            else { tope = 10; }
            while(estado)
            {
                color back;
                color fore;
                if (script)
                {
                    script = false;
                    for (int i = inicio; i < tope; i++)
                    {
                        if (i == position)
                        {
                            back = color.BLANCO;
                            fore = color.ROJO;
                        }
                        else
                        {
                            back = color.NEGRO;
                            fore = color.DARK_VERDE;
                        }
                        IOdata.Selector(back, fore, (i + 1).ToString(), 3, 21, 17 + (k * 3));
                        IOdata.Selector(back, fore, listado[i].NOMSUCURSAL, 58, 27, 17 + (k * 3));
                        IOdata.Selector(back, fore, listado[i].CODIGO, 17, 88, 17 + (k * 3));
                        k++;
                    }
                    k = 0;
                }                
                OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                string tecla = key_data.InputMode();
                if (!(tecla.Equals("")))
                {
                    script = true;
                    if ((!(tecla.Equals("ENTER"))) && (!(tecla.Equals("ESC"))))
                    {
                        if ((tecla.Equals("DOWNARROW")) || (tecla.Equals("UPARROW")))
                        {
                            if (tecla.Equals("DOWNARROW"))
                            {
                                position++;
                                if (position == tope) { position = inicio; }
                            }
                            if (tecla.Equals("UPARROW"))
                            {
                                position--;
                                if (position < inicio) { position = tope - 1; }
                            }
                        }
                        if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")))
                        {
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
                                    if ((tope > listado.Count) && (inicio > listado.Count))
                                    {
                                        inicio = 0;
                                        if (listado.Count < 10) { tope = listado.Count; }
                                        else { tope = 10; }
                                    }
                                }
                                position = inicio;
                            }
                            if (tecla.Equals("LEFTARROW"))
                            {
                                inicio -= 10;
                                tope -= 10;

                                if (((inicio < 0) && (tope == 0)) && (listado.Count > 10))
                                {
                                    tope = listado.Count;
                                    inicio = (tope / 10) * 10;
                                } else
                                {
                                    if (((inicio < 0) && (tope < 0)) && (listado.Count < 10))
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
                                
                                position = inicio;
                            }
                            DRAW.CuadradoSolid(color.NEGRO, 3, 28, 21, 17);
                            DRAW.CuadradoSolid(color.NEGRO, 58, 28, 27, 17);
                            DRAW.CuadradoSolid(color.NEGRO, 17, 28, 88, 17);
                        }                        
                    } else
                    {
                        if (tecla.Equals("ESC"))
                        {
                            estado = false;
                            dt.SetMState(TypeState._SucursListST, SucursalesListST._VOLVER);                            
                        }
                        else
                        {
                            if (tecla.Equals("ENTER"))
                            {
                                dt.SUCURSALCREATE = listado[position];
                                dt.SetMState(TypeState._SucursListST, SucursalesListST._VISUAL);
                                estado = false;
                            }
                        }
                    }
                }                                
            }
        }
        public static void Mensage01(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O S   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[4];
            mensaje[0] = "   N O    P O S E E   ";
            mensaje[1] = "   S U C U R S A L E S   ";
            mensaje[2] = "   E N   L A   ";
            mensaje[3] = "   B A S E   D E   D A T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);

            dt.SetMState(TypeState._LiveSucursListST, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SucursListST, SucursalesListST._none);
            dt.SetMState(TypeState._LiveSucursalST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SucursalST, SucursalesST._MENUOPCION);
            dt.SetMState(TypeState._StateMain, StateMain._SUCURSALES);
        }
        public static void VerificarListadoSucursales(ref BDState dt)
        {
            FDSucursal condicion = new FDSucursal("ListSucursales");
            int cont = condicion.CountListSucursal();
            
            if (cont > 1) { dt.SetMState(TypeState._SucursListST, SucursalesListST._LISTER); }
            if (cont == 1) { dt.SetMState(TypeState._SucursListST, SucursalesListST._MENSAGE01); }
        }
    }
}
