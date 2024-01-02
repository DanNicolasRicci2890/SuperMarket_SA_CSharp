using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;

namespace SuperMarket_SA
{
    public class SUP37
    {
        public static void MensageRemove(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S U A R I O    E L I M I N A D O   ", "   D E   L A   ", "   B A S E   D E   D A T O S   " };
            FUNCTION.Mensagedata(mensaje, color.BLANCO, color.AZUL, color.VERDE, 100, 20);
            dt.SetMState(TypeState._SysAdminRemove, SysAdminRemove._VOLVER);
        }
        public static void RemoveUser(ref BDState dt)
        {
            // crear la lectura/escritura de la base de dato "ListUserProgram.dat"
            FDUsuario opus_user = new FDUsuario("ListUserProgram");

            // cargar los usuarios en la lista de usuarios
            opus_user.LoadListUser();

            // eliminar el usuario seleccionado en la lista
            opus_user.RemoveUser(dt.POSITION);

            // ordenar la lista de usuarios.
            opus_user.BurbujaListUser();

            // guardar la lista de usuarios sin el usuario eliminado
            opus_user.SaveListUser();

            dt.USERCREATE = new Usuario();
            dt.POSITION = -1;

            dt.SetMState(TypeState._SysAdminRemove, SysAdminRemove._MENSAGE);
        }
        public static void VolverMenu(ref BDState dt)
        {
            dt.SetMState(TypeState._SysAdminRemove, SysAdminRemove._none);
            dt.SetMState(TypeState._LiveSysAdminRemove, LiveProgram._none);
            if (dt.CONDICION_LISTA == LiveProgram._INACTIVATED)
            {
                dt.SetMState(TypeState._SysAdmin, SysAdmin._MENU);
                dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN);
            }
            if (dt.CONDICION_LISTA == LiveProgram._ACTIVATED)
            {
                dt.SetMState(TypeState._SysAdminLister, SysAdminLister._VERIFICAR);
                dt.SetMState(TypeState._LiveSysAdminLister, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_LISTER);
            }
            dt.CONDICION_LISTA = LiveProgram._none;
            dt.USERCREATE = new Usuario();
            dt.POSITION = -1;
        }
        public static void MenuOpcion(ref BDState dt)
        {
            int index = 0, indice = -1, count = 0, nivel = 0, inicio = 0, tope = 0, k = 0;
            bool est = true, script = false;
            string titulo = "";
            List<string> lister = new List<string>();
            FUNCTION.UsuarioPerfilado(ref dt);
            IN key_data = new IN();
            string tecla = "";
            color[] backtitulo2 = { color.NEGRO, color.BLANCO, color.DARK_AMARILLO, color.NEGRO };
            color[] foretitulo2 = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.MAGENTA };
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            key_data.SetCondIN(INCond._ARROWS);
            key_data.SetCondIN(INCond._TAB);
            key_data.SetCondIN(INCond._ENTER);
            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 50 }, new int[] { 4 }, 15, 26);
            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 50 }, new int[] { 16 }, 15, 31);

            IOBUTTON btn_BORRAR_ = new IOBUTTON(" BORRAR USUARIO ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 103, 26);
            IOBUTTON btn_VOLVER_ = new IOBUTTON("   VOLVER MENU  ", backcorral, forecorral, backtitulo2, foretitulo2, TypeLine._DOUBLE, 103, 33);
            if (dt.USERCREATE.SystemRoles != 0)
            {
                while (count == 0)
                {
                    indice++;
                    if (indice == 5) { indice = 0; }
                    Calibrador(ref titulo, ref lister, ref indice, dt.USERCREATE);
                    count = lister.Count;                                                            
                }
                inicio = 0;
                tope = lister.Count;
                if (tope > 7) { tope = 7; }
            } 
            else 
            { 
                titulo = "                                  "; 
                lister = new List<string>();
            }

            btn_VOLVER_.SetDataInfo(false);
            btn_BORRAR_.SetDataInfo(false);
            index = 0;
            while (est)
            {
                if (nivel == 0)
                {
                    IOdata.Selector(color.BLANCO, color.ROJO, titulo, 47, 16, 27);
                    btn_VOLVER_.SetInactivated();
                    btn_BORRAR_.SetInactivated();
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_BORRAR_.Display(color.NEGRO, color.NEGRO);
                    k = 0;
                    for(int i = inicio; i < tope; i++)
                    {
                        color fore = color.none;
                        if (i == index) { fore = color.ROJO; }
                        else { fore = color.BLANCO; }
                        OUT.PrintLine(lister[i], fore, color.NEGRO, 17, 33 + (k * 2));
                        k++;
                    }
                }     
                if (nivel == 1)
                {
                    IOdata.Selector(color.DARK_GRIS, color.NEGRO, titulo, 47, 16, 27);
                    btn_VOLVER_.SetInactivated();
                    switch(script)
                    {
                        case false: btn_BORRAR_.SetSemiInactivated(); break;
                        case true: btn_BORRAR_.SetActivated(); break;
                    }
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);
                    btn_BORRAR_.Display(color.NEGRO, color.NEGRO);
                }
                if (nivel == 2)
                {
                    IOdata.Selector(color.DARK_GRIS, color.NEGRO, titulo, 47, 16, 27);
                    btn_BORRAR_.SetInactivated();
                    switch (script)
                    {
                        case false: btn_VOLVER_.SetSemiInactivated(); break;
                        case true: btn_VOLVER_.SetActivated(); break;
                    }
                    btn_BORRAR_.Display(color.NEGRO, color.NEGRO);
                    btn_VOLVER_.Display(color.NEGRO, color.NEGRO);                    
                }
                if ((bool)(btn_VOLVER_.GetDataInfo()))
                {
                    script = true;
                    est = false;
                    dt.SetMState(TypeState._SysAdminRemove, SysAdminRemove._VOLVER);
                }
                if ((bool)(btn_BORRAR_.GetDataInfo()))
                {
                    script = true;
                    est = false;
                    dt.SetMState(TypeState._SysAdminRemove, SysAdminRemove._REMOVE);
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
                                if (index == tope)
                                {
                                    Borrartabla();
                                    inicio += 7;
                                    tope += 7;
                                    if ((tope >= lister.Count) && (inicio < lister.Count))
                                    {
                                        tope = lister.Count;
                                    } else
                                    {
                                        if ((tope >= lister.Count) && (inicio > lister.Count))
                                        {
                                            inicio = 0;
                                            tope = lister.Count;
                                            if (lister.Count > 7) { tope = 7; }
                                        }
                                    }
                                    index = inicio;
                                }
                            }
                            if (tecla.Equals("UPARROW"))
                            {
                                index--;
                                
                                if (index < 0)
                                {
                                    Borrartabla();
                                    inicio -= 7;
                                    tope -= 7;
                                    if ((inicio < 0) && (tope == 0))
                                    {
                                        tope = lister.Count;
                                        inicio = (tope / 7) * 7;
                                        index = inicio;
                                    }
                                }
                                else
                                {
                                    if (index < inicio)
                                    {
                                        Borrartabla();
                                        inicio -= 7;
                                        tope -= 7;
                                        if ((tope - inicio) < 7)
                                        {
                                            tope = inicio + 7;
                                        }
                                    }
                                }

                            }
                        }
                        if ((tecla.Equals("RIGHTARROW")) || (tecla.Equals("LEFTARROW")))
                        {
                            if (tecla.Equals("RIGHTARROW"))
                            {
                                Borrartabla();
                                count = 0;
                                lister.Clear();
                                while(count == 0)
                                {
                                    indice++;
                                    if (indice == 5) { indice = 0; }
                                    Calibrador(ref titulo, ref lister, ref indice, dt.USERCREATE);
                                    count = lister.Count;
                                    
                                }
                            }
                            if (tecla.Equals("LEFTARROW"))
                            {
                                Borrartabla();
                                count = 0;
                                lister.Clear();
                                while (count == 0)
                                {
                                    indice--;
                                    if (indice == -1) { indice = 4; }
                                    Calibrador(ref titulo, ref lister, ref indice, dt.USERCREATE);
                                    count = lister.Count;
                                }                                
                            }
                            index = 0;
                            inicio = 0;
                            tope = lister.Count;
                            if (tope > 7) { tope = 7; }                            
                        }
                    }
                    else
                    {
                        if (tecla.Equals("TAB"))
                        {
                            nivel++;
                            if (nivel == 3) { nivel = 0; }
                        }
                        else
                        {
                            if ((tecla.Equals("ENTER")) && ((nivel == 1) || (nivel == 2))) 
                            {
                                script = true;
                            }
                        }
                    }
                }
                else { script = false; }
            }
        }
        private static void Borrartabla()
        {
            for(int i = 0; i < 14; i++)
            {
                for(int j = 0; j < 49; j++)
                {
                    OUT.PrintLine(" ", color.NEGRO, color.NEGRO, 16 + j, 32 + i);
                }                
            }
        }
        private static void Calibrador(ref string titulo, ref List<string> listerhigh, ref int index, Usuario user)
        {
            List<string> lister = new List<string>();
            int tope = 0, roles = 0;
            if (((user.SystemRoles >> index) & 1) == 1)
            {
                if (index == 0)
                {
                    titulo = "               Roles de SysAdmin         ";
                    tope = 15;
                    roles = user.SystemSysAdmin;
                    lister.Add("Perfil de Usuario");
                    lister.Add("Visualizar Lista");
                    lister.Add("Crear Usuarios");
                    lister.Add("Ingresar Usuarios al Sistema");
                    lister.Add("Modificar Usuarios");
                    lister.Add("Habilitar/Deshabilitar Usuarios");
                    lister.Add("Switch de Expiracion de Cuenta");
                    lister.Add("Switch de Expiracion de Contraseñas");
                    lister.Add("Expiracion de Cuenta");
                    lister.Add("Expiracion de Contraseñas");
                    lister.Add("Desbloqueo de Contraseñas");
                    lister.Add("Bloqueo/Desbloqueo de Cuentas");
                    lister.Add("Reseteo de Contraseñas");
                    lister.Add("Agregar o Modificar Roles y Permisos");
                    lister.Add("Eliminar Usuarios");
                } 
                else
                {
                    if (index == 1)
                    {
                        titulo = "            Roles de Administracion       ";
                        tope = 12;
                        roles = user.SystemAdministrador;
                        lister.Add("Visualizar Lista de Sucursales");
                        lister.Add("Visualizar Sucursal");
                        lister.Add("Crear Sucursales");
                        lister.Add("Modificar Sucursales");
                        lister.Add("Eliminar Sucursales");
                        lister.Add("Lista de Tipos de Productos");
                        lister.Add("Agregar Tipo de Producto");
                        lister.Add("Eliminar Tipo de Producto");
                        lister.Add("Ver Lista de un Tipo de Producto");
                        lister.Add("Agregar Productos");
                        lister.Add("Modificar Productos");
                        lister.Add("Eliminar Productos");
                    }
                    else
                    {
                        if (index == 2)
                        {
                            titulo = "            Roles de Contaduria         ";                            
                            tope = 6;
                            roles = user.SystemContaduria;
                            lister.Add("Compra de Productos ");
                            lister.Add("Visualizar/Eliminar Stock Central ");
                            lister.Add("Configurar Dolar/Peso ");
                            lister.Add("Visualizar Ganancias ");
                            lister.Add("Borrar Items de Ganancias ");
                            lister.Add("Borrar todos los items de ganancias ");
                        }
                        else
                        {
                            if (index == 3)
                            {
                                titulo = "            Roles de Cajero             ";
                                tope = 1;
                                roles = user.SystemCajero;
                                lister.Add("Cajero");
                            }
                            else
                            {
                                if (index == 4)
                                {
                                    titulo = "       Roles de Deposito y Logistica      ";
                                    tope = 3;
                                    roles = user.SystemDepositLogic;
                                    lister.Add("Logistica de Transporte");
                                    lister.Add("Muestreo de Gondolas");
                                    lister.Add("Eliminar Stock de Sucursal");
                                }
                            }
                        }
                    }                    
                }                
            }
            for(int bit = 0; bit < tope; bit++)
            {
                if (((roles >> bit) & 1) == 1)
                {
                    string rol = lister[bit];
                    listerhigh.Add(rol);
                }
            }
        }
    }
}
