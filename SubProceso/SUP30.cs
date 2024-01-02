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
    public class SUP30
    {
        public static void Mensage(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   V A L O R   D E L   D O L A R   " , "   M O D I F I C A D O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ContaduriaDolarPesos, ContaduriaDolarPesos._VOLVER);
        }
        public static void Save(ref BDState dt)
        {
            string kt_load = FUNCTION.ConcatenadorFile("DolarPeso", ".dat");
            string kt_save = FUNCTION.ConcatenadorFile("DolarPeso", "-temp.dat");

            StreamWriter sw = new StreamWriter(kt_save);
            CodigoEnigma cod = new CodigoEnigma();
            string dato = dt.DOLARPESOS.ToString();
            string encriptado = cod.Encriptador(dato);
            sw.WriteLine(encriptado);
            sw.Close();
            File.Delete(kt_load);
            File.Move(kt_save, kt_load);
            dt.SetMState(TypeState._ContaduriaDolarPesos, ContaduriaDolarPesos._MENSAGE);
        }
        public static void MensageError(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   E R R O R    D E    V A L O R   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[2];
            mensaje[0] = "   I N G R E S E   U N   V A L O R   ";
            mensaje[1] = "   C O R R E C T O   ";            
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._ContaduriaDolarPesos, ContaduriaDolarPesos._CONFIG);
        }
        public static void VolverContaduria(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveContaduriaDolarPeso, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._ContaduriaDolarPesos, ContaduriaDolarPesos._none);
            dt.SetMState(TypeState._LiveContaduriaST, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._ContaduriaST, ContaduriaST._VERIF_USER);
            dt.SetMState(TypeState._StateMain, StateMain._CONTADURIA);
        }
        public static void ConfigureValue(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            DRAW.CuadradoSolid(color.BLANCO, 54, 1, 80, 10);
            OUT.PrintLine("  Contaduria - Configuracion Dolar/Pesos  ", color.ROJO, color.BLANCO, 87, 11);

            bool estado = true, script = false;
            int contador = 0;

            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            color[] backtitulo2 = { color.NEGRO, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };

            IN key_data = new IN();
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);

            IODATAINFO dolarpeso = new IODATAINFO(" dolar u$s 1 -----> pesos $ ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 10, 8, 60, 20);
            IOBUTTON guardar = new IOBUTTON("  GUARDAR  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 110, 20);
            IOBUTTON salir = new IOBUTTON("  VOLVER   ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 135, 20);

            dolarpeso.SetTypeDataIN(TypeDataIN._NUMERIC_PAD);
            dolarpeso.SetTypeDataIN(TypeDataIN._CARACTER_SPECIAL);

            dolarpeso.SetDataInfo((float)dt.DOLARPESOS);
            guardar.SetDataInfo(false);
            salir.SetDataInfo(false);

            while (estado)
            {
                dolarpeso.SetInactivated();
                guardar.SetInactivated();
                salir.SetInactivated();
                dolarpeso.Display(color.NEGRO, color.NEGRO); 
                guardar.Display(color.NEGRO, color.NEGRO); 
                salir.Display(color.NEGRO, color.NEGRO); 

                if (contador == 0)
                {
                    switch(script)
                    {
                        case false: dolarpeso.SetSemiInactivated(); break;
                        case true: dolarpeso.SetActivated(); break;
                    }
                    dolarpeso.Display(color.NEGRO, color.NEGRO);
                }
                if (contador == 1)
                {
                    switch (script)
                    {
                        case false: guardar.SetSemiInactivated(); break;
                        case true: guardar.SetActivated(); break;
                    }
                    guardar.Display(color.NEGRO, color.NEGRO);
                }
                if (contador == 2)
                {
                    switch (script)
                    {
                        case false: salir.SetSemiInactivated(); break;
                        case true: salir.SetActivated(); break;
                    }
                    salir.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)(salir.GetDataInfo()))
                {
                    script = true;
                    estado = false;
                    dt.SetMState(TypeState._ContaduriaDolarPesos, ContaduriaDolarPesos._VOLVER);                    
                }
                if ((bool)(guardar.GetDataInfo()))
                {
                    try
                    {
                        string ht = (dolarpeso.GetDataInfo().ToString());
                        if (ht.Contains("."))
                        {
                            ht = ht.Replace('.', ',');
                        }
                        float valor = Convert.ToSingle(ht);
                        dt.DOLARPESOS = valor;
                        dt.SetMState(TypeState._ContaduriaDolarPesos, ContaduriaDolarPesos._SAVE);
                    }
                    catch { dt.SetMState(TypeState._ContaduriaDolarPesos, ContaduriaDolarPesos._MENSAGE_ERROR); }
                    script = true;
                    estado = false;
                }
                if (!(script))
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    string tecla = key_data.InputMode();
                    if ((tecla.Equals("TAB")) || (tecla.Equals("ENTER")))
                    {
                        if (tecla.Equals("TAB"))
                        {
                            contador++;
                            if (contador == 3) { contador = 0; }
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
