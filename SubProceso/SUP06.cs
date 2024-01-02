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
using PCD_CodEnigma;

namespace SuperMarket_SA
{
    public class SUP06
    {
        public static void RemoveUser(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdminLister, SysAdminLister._none);
            dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdminRemove, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdminRemove, SysAdminRemove._MENUOPCION);
            dt.SetMState(TypeState._SysAdmin, SysAdmin._REMOVE_USER);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_ELIMINAR);
            dt.CONDICION_LISTA = LiveProgram._ACTIVATED;
            dt.CONDCREATE = true;
        }
        public static void RolesYPermisos(ref BDState dt)
        {
            if (dt.USERCREATE.UserID.Equals("no posee ID"))
            {
                dt.SetMState(TypeState._SysAdminLister, SysAdminLister._MENSAGE3);
            }
            else
            {
                dt.SetMState(TypeState._SysAdminLister, SysAdminLister._none);
                dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._LiveSysAdminRolesPer, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._SysAdmin, SysAdmin._ROLES_PERMISOS);
                dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_ROLESPER);
                dt.CONDICION_LISTA = LiveProgram._ACTIVATED;
            }
        }
        public static void Mensage03(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   E L    U S U A R I O    ", "   S E L E C C I O N A D O   ", "   N O   E S T A    H A B I L I T A D O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SysAdminLister, SysAdminLister._LISTADO);
        }
        public static void EstadoUsuario(ref BDState dt)
        {
            if (dt.USERCREATE.UserID.Equals("no posee ID"))
            {
                dt.SetMState(TypeState._SysAdminLister, SysAdminLister._MENSAGE3);                
            }
            else 
            {
                dt.SetMState(TypeState._SysAdminLister, SysAdminLister._none);
                dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._LiveSysAdminEstado, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._SysAdmin, SysAdmin._STATE_USER);
                dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_STATEUSER);
                dt.CONDICION_LISTA = LiveProgram._ACTIVATED;
            }
        }
        public static void ModificarUser(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdminLister, SysAdminLister._none);
            dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdminCreate, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_CREATE);
            dt.CONDICION_LISTA = LiveProgram._ACTIVATED;    
            dt.CONDCREATE = true;
        }
        public static void Mensage02(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   E L    U S U A R I O    ", "   S E L E C C I O N A D O   ", "   E S T A    H A B I L I T A D O   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SysAdminLister, SysAdminLister._LISTADO);
        }
        public static void IngresarUsuario(ref BDState dt)
        {
            if (dt.USERCREATE.UserID.Equals("no posee ID"))
            {
                dt.SetMState(TypeState._SysAdminLister, SysAdminLister._none);
                dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._LiveSysAdminIngreso, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._IN_USER_ID);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_INGRESO);
                dt.CONDICION_LISTA = LiveProgram._ACTIVATED;
            }
            else { dt.SetMState(TypeState._SysAdminLister, SysAdminLister._MENSAGE2); }
        }
        public static void AgregarUsuario(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdminLister, SysAdminLister._none);
            dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdminCreate, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_CREATE);
            dt.USERCREATE = new Usuario();
            dt.CONDCREATE = false;
            dt.CONDICION_LISTA = LiveProgram._ACTIVATED;
        }
        public static void VolverAlMenu(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdminLister, SysAdminLister._none);
            dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdmin, SysAdmin._MENU);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN);
        }
        public static void ListadoUsuario(ref BDState dt)
        {
            int inicio = 0, tope = 0, nivel = 0, index = 0, t = 0;
            bool estado = true, script = false;
            string tecla = "";
            IN key_data = new IN();
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();            
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);

            IOdata.Selector(color.BLANCO, color.AZUL, "    SysAdmin - Listado de Usuarios ", 40, 90, 8);
            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 60 , 20 , 20 , 30 , 40 }, new int[] { 4 }, 20, 12);
            Tablausuario(color.BLANCO, color.AZUL);
            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 174 }, new int[] { 31 }, 20, 17);

            key_data.SetCondIN(INCond._ARROWS);
            key_data.SetCondIN(INCond._ENTER);
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._CTRL);

            List<Usuario> Lister = new List<Usuario>();
            FDUsuario condicion = new FDUsuario("ListUserProgram");
            condicion.LoadListUser(ref Lister);
            Lister.RemoveAt(0);

            color[] backtitulo2 = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };

            IOBUTTON btn_AGREGAR_ =   new IOBUTTON("  AGREGAR USUARIOS  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 197, 10);
            IOBUTTON btn_INGRESAR_ =  new IOBUTTON(" INGRESAR USUARIOS  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 197, 16);
            IOBUTTON btn_MODIFICAR_ = new IOBUTTON(" MODIFICAR USUARIOS ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 197, 22);
            IOBUTTON btn_ESTADOCUE_ = new IOBUTTON("  ESTADO DE CUENTA  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 197, 28);
            IOBUTTON btn_ROLYPERMI_ = new IOBUTTON("  ROLES Y PERMISOS  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 197, 34);
            IOBUTTON btn_REMOVEUSE_ = new IOBUTTON(" ELIMINAR USUARIOS  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 197, 40);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("   VOLVER AL MENU   ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 197, 46);
            btn_AGREGAR_.SetDataInfo(false);
            btn_INGRESAR_.SetDataInfo(false);
            btn_MODIFICAR_.SetDataInfo(false);
            btn_ESTADOCUE_.SetDataInfo(false);
            btn_ROLYPERMI_.SetDataInfo(false);
            btn_REMOVEUSE_.SetDataInfo(false);
            btn_VOLVER_.SetDataInfo(false);

            inicio = 0;
            tope = Lister.Count;
            if (Lister.Count > 10) { tope = 10; }
            index = 0;
            while (estado)
            {
                if (nivel == 0)
                {
                    btn_AGREGAR_.SetInactivated();
                    btn_INGRESAR_.SetInactivated();
                    btn_MODIFICAR_.SetInactivated();
                    btn_ESTADOCUE_.SetInactivated();
                    btn_ROLYPERMI_.SetInactivated();
                    btn_REMOVEUSE_.SetInactivated();
                    btn_VOLVER_.SetInactivated();

                    btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                    btn_INGRESAR_.Display(color.NEGRO, color.NEGRO);
                    btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
                    btn_ESTADOCUE_.Display(color.NEGRO, color.NEGRO);
                    btn_ROLYPERMI_.Display(color.NEGRO, color.NEGRO);
                    btn_REMOVEUSE_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);

                    Tablausuario(color.DARK_AZUL, color.BLANCO);
                    t = 0;
                    for (int i = inicio; i < tope; i++)
                    {
                        color back = color.none;
                        color fore = color.none;
                        if (index == i)
                        {
                            back = color.BLANCO;
                            fore = color.AZUL;
                        } else
                        {
                            back = color.NEGRO;
                            fore = color.DARK_GRIS;
                        }
                        Lister[i].ImprimirUserList(back, fore, 21, 18 + t);
                        t += 3;
                    }
                }
                if (nivel == 1)
                {
                    Tablausuario(color.DARK_GRIS, color.NEGRO);                    
                    btn_INGRESAR_.SetInactivated();
                    btn_MODIFICAR_.SetInactivated();
                    btn_ESTADOCUE_.SetInactivated();
                    btn_ROLYPERMI_.SetInactivated();
                    btn_REMOVEUSE_.SetInactivated();
                    btn_VOLVER_.SetInactivated();

                    switch(script)
                    {
                        case false: btn_AGREGAR_.SetSemiInactivated(); break;
                        case true: btn_AGREGAR_.SetActivated(); break;
                    }
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_INGRESAR_.Display(color.NEGRO, color.NEGRO);
                    btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
                    btn_ESTADOCUE_.Display(color.NEGRO, color.NEGRO);
                    btn_ROLYPERMI_.Display(color.NEGRO, color.NEGRO);
                    btn_REMOVEUSE_.Display(color.NEGRO, color.NEGRO);
                    btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 2)
                {
                    Tablausuario(color.DARK_GRIS, color.NEGRO);
                    btn_AGREGAR_.SetInactivated();
                    btn_MODIFICAR_.SetInactivated();
                    btn_ESTADOCUE_.SetInactivated();
                    btn_ROLYPERMI_.SetInactivated();
                    btn_REMOVEUSE_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_INGRESAR_.SetSemiInactivated(); break;
                        case true: btn_INGRESAR_.SetActivated(); break;
                    }
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
                    btn_ESTADOCUE_.Display(color.NEGRO, color.NEGRO);
                    btn_ROLYPERMI_.Display(color.NEGRO, color.NEGRO);
                    btn_REMOVEUSE_.Display(color.NEGRO, color.NEGRO);
                    btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                    btn_INGRESAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 3)
                {
                    Tablausuario(color.DARK_GRIS, color.NEGRO);
                    btn_AGREGAR_.SetInactivated();
                    btn_INGRESAR_.SetInactivated();
                    btn_ESTADOCUE_.SetInactivated();
                    btn_ROLYPERMI_.SetInactivated();
                    btn_REMOVEUSE_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_MODIFICAR_.SetSemiInactivated(); break;
                        case true: btn_MODIFICAR_.SetActivated(); break;
                    }
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_ESTADOCUE_.Display(color.NEGRO, color.NEGRO);
                    btn_ROLYPERMI_.Display(color.NEGRO, color.NEGRO);
                    btn_REMOVEUSE_.Display(color.NEGRO, color.NEGRO);
                    btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                    btn_INGRESAR_.Display(color.NEGRO, color.NEGRO);
                    btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 4)
                {
                    Tablausuario(color.DARK_GRIS, color.NEGRO);
                    btn_AGREGAR_.SetInactivated();
                    btn_INGRESAR_.SetInactivated();
                    btn_MODIFICAR_.SetInactivated();
                    btn_ROLYPERMI_.SetInactivated();
                    btn_REMOVEUSE_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_ESTADOCUE_.SetSemiInactivated(); break;
                        case true: btn_ESTADOCUE_.SetActivated(); break;
                    }
                    btn_ROLYPERMI_.Display(color.NEGRO, color.NEGRO);
                    btn_REMOVEUSE_.Display(color.NEGRO, color.NEGRO);
                    btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                    btn_INGRESAR_.Display(color.NEGRO, color.NEGRO);
                    btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
                    btn_ESTADOCUE_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 5)
                {
                    Tablausuario(color.DARK_GRIS, color.NEGRO);
                    btn_AGREGAR_.SetInactivated();
                    btn_INGRESAR_.SetInactivated();
                    btn_MODIFICAR_.SetInactivated();
                    btn_ESTADOCUE_.SetInactivated();
                    btn_REMOVEUSE_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_ROLYPERMI_.SetSemiInactivated(); break;
                        case true: btn_ROLYPERMI_.SetActivated(); break;
                    }
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_REMOVEUSE_.Display(color.NEGRO, color.NEGRO);
                    btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                    btn_INGRESAR_.Display(color.NEGRO, color.NEGRO);
                    btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
                    btn_ESTADOCUE_.Display(color.NEGRO, color.NEGRO);
                    btn_ROLYPERMI_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 6)
                {
                    Tablausuario(color.DARK_GRIS, color.NEGRO);
                    btn_AGREGAR_.SetInactivated();
                    btn_INGRESAR_.SetInactivated();
                    btn_MODIFICAR_.SetInactivated();
                    btn_ESTADOCUE_.SetInactivated();
                    btn_ROLYPERMI_.SetInactivated();
                    btn_VOLVER_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_REMOVEUSE_.SetSemiInactivated(); break;
                        case true: btn_REMOVEUSE_.SetActivated(); break;
                    }
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                    btn_INGRESAR_.Display(color.NEGRO, color.NEGRO);
                    btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
                    btn_ESTADOCUE_.Display(color.NEGRO, color.NEGRO);
                    btn_ROLYPERMI_.Display(color.NEGRO, color.NEGRO);
                    btn_REMOVEUSE_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 7)
                {
                    Tablausuario(color.DARK_GRIS, color.NEGRO);
                    btn_AGREGAR_.SetInactivated();
                    btn_INGRESAR_.SetInactivated();
                    btn_MODIFICAR_.SetInactivated();
                    btn_ESTADOCUE_.SetInactivated();
                    btn_ROLYPERMI_.SetInactivated();
                    btn_REMOVEUSE_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_VOLVER_.SetSemiInactivated(); break;
                        case true: btn_VOLVER_.SetActivated(); break;
                    }
                    btn_AGREGAR_.Display(color.NEGRO, color.NEGRO);
                    btn_INGRESAR_.Display(color.NEGRO, color.NEGRO);
                    btn_MODIFICAR_.Display(color.NEGRO, color.NEGRO);
                    btn_ESTADOCUE_.Display(color.NEGRO, color.NEGRO);
                    btn_ROLYPERMI_.Display(color.NEGRO, color.NEGRO);
                    btn_REMOVEUSE_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                }
                if ((bool)(btn_AGREGAR_.GetDataInfo()))
                {
                    estado = false;
                    script = true;
                    dt.SetMState(TypeState._SysAdminLister, SysAdminLister._AGREGAR);
                }
                if ((bool)(btn_INGRESAR_.GetDataInfo()))
                {
                    estado = false;
                    script = true;
                    dt.USERCREATE = Lister[index];
                    dt.POSITION = index + 1;
                    dt.SetMState(TypeState._SysAdminLister, SysAdminLister._INGRESAR);
                }
                if ((bool)(btn_MODIFICAR_.GetDataInfo()))
                {
                    estado = false;
                    script = true;
                    dt.USERCREATE = Lister[index];
                    dt.POSITION = index + 1;
                    dt.CONDCREATE = true;
                    dt.SetMState(TypeState._SysAdminLister, SysAdminLister._MODIFICAR);
                }
                if ((bool)(btn_ESTADOCUE_.GetDataInfo()))
                {
                    estado = false;
                    script = true;
                    dt.USERCREATE = Lister[index];
                    dt.POSITION = index + 1;
                    dt.CONDCREATE = true;
                    dt.SetMState(TypeState._SysAdminLister, SysAdminLister._ESTADOCUE);
                }
                if ((bool)(btn_ROLYPERMI_.GetDataInfo()))
                {
                    estado = false;
                    script = true;
                    dt.USERCREATE = Lister[index];
                    dt.POSITION = index + 1;
                    dt.CONDCREATE = true;
                    dt.SetMState(TypeState._SysAdminLister, SysAdminLister._ROLYPERM);
                }
                if ((bool)(btn_REMOVEUSE_.GetDataInfo()))
                {
                    estado = false;
                    script = true;
                    dt.USERCREATE = Lister[index];
                    dt.POSITION = index + 1;
                    dt.CONDCREATE = true;
                    dt.SetMState(TypeState._SysAdminLister, SysAdminLister._REMOVEUSER);
                }
                if ((bool)(btn_VOLVER_.GetDataInfo()))
                {
                    estado = false;
                    script = true;
                    dt.SetMState(TypeState._SysAdminLister, SysAdminLister._VOLVER);
                }
                if (!script)
                {
                    OUT.PrintLine("", color.NEGRO, color.NEGRO, 0, 0);
                    tecla = key_data.InputMode();
                    if (((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")) || (tecla.Equals("UPARROW")) || (tecla.Equals("DOWNARROW"))) && (nivel == 0))
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
                                if (index < inicio) { index = tope - 1; }
                            }
                        }
                        if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")))
                        {
                            DRAW.CuadradoSolid(color.NEGRO, 171, 28, 21, 18);
                            if (tecla.Equals("RIGHTARROW"))
                            {
                                inicio += 10;
                                tope += 10;
                                if ((tope > Lister.Count) && (inicio < Lister.Count))
                                {
                                    tope = Lister.Count;
                                } else
                                {
                                    if ((tope >= Lister.Count) && (inicio >= Lister.Count))
                                    {
                                        inicio = 0;
                                        tope = 10;
                                        if (Lister.Count < 10) { tope = Lister.Count; }
                                    }
                                }
                            }
                            if (tecla.Equals("LEFTARROW"))
                            {
                                inicio -= 10;
                                tope -= 10;
                                if (((inicio < 0) && (tope == 0)) && (Lister.Count > 10))
                                {
                                    tope = Lister.Count;
                                    inicio = (tope / 10) * 10;
                                }
                                else
                                {
                                    if (((inicio < 0) && (tope < 0)) && (Lister.Count < 10))
                                    {
                                        inicio = 0;
                                        tope = Lister.Count;
                                    }
                                    else
                                    {
                                        if (((tope - inicio) < 10) && ((tope % 10) != 0) && ((Lister.Count - tope) == 10))
                                        {
                                            tope = inicio + 10;
                                        }
                                    }
                                }
                            }
                            index = inicio;
                        }
                    } 
                    else
                    {
                        if (tecla.Equals("TAB"))
                        {
                            nivel++;
                            if (nivel == 8) { nivel = 0; }
                        }
                        else  
                        {
                            if (tecla.Equals("CTRL + TAB"))
                            {
                                nivel--;
                                if (nivel <= -1) { nivel = 7; }
                            }
                            else
                            {
                                if ((tecla.Equals("ENTER")) && (nivel != 0)) { script = true; }
                            }                            
                        }
                    }
                } else { script = false; }  
            }
        }
        public static void Mensage(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   B A S E   D E   D A T O S   ", "   V A C I A   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            mensaje = new string[4];
            mensaje[0] = "   N O    P O S E E   ";
            mensaje[1] = "   U S U A R I O S   ";
            mensaje[2] = "   E N   L A   ";
            mensaje[3] = "   B A S E   D E   D A T O S   ";
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SysAdminLister, SysAdminLister._none);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdmin, SysAdmin._MENU);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN);
        }
        public static void VerificarListadoUsuario(ref BDState dt)
        {
            FDUsuario condicion = new FDUsuario("ListUserProgram");
            int cont = condicion.CountListUser();

            if (cont > 1) { dt.SetMState(TypeState._SysAdminLister, SysAdminLister._LISTADO); }
            if (cont == 1) { dt.SetMState(TypeState._SysAdminLister, SysAdminLister._MENSAGE); }
        }
        private static void Tablausuario(color back, color fore)
        {
            DRAW.CuadradoSolid(back, 58, 1, 21, 13);
            DRAW.CuadradoSolid(back, 18, 1, 82, 13);
            DRAW.CuadradoSolid(back, 18, 1, 103, 13);
            DRAW.CuadradoSolid(back, 28, 1, 124, 13);
            DRAW.CuadradoSolid(back, 37, 1, 155, 13);

            OUT.PrintLine("Nombre y Apellido", fore, back, 23, 14);
            OUT.PrintLine("Legajo", fore, back, 84, 14);
            OUT.PrintLine("D.N.I.", fore, back, 105, 14);
            OUT.PrintLine("User-ID", fore, back, 126, 14);
            OUT.PrintLine("Estado de Cuenta", fore, back, 157, 14);
        }
    }
}
