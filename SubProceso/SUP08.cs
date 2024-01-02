using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PCD_CodEnigma;
using PCD_ColorFull;
using PCD_INOUT_INFO;
using PCD_EVENT_DATA;

namespace SuperMarket_SA
{
    public class SUP08
    {       
        public static void DireccionAplicacion(ref BDState dt)
        {
            if (dt.EqualsMState(TypeState._SysAdmin, SysAdmin._INGRESO_USER))
            {
                dt.SetMState(TypeState._SysAdmin, SysAdmin._none);  //<---
                dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._none);
                dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._SysAdminIngreso, SysAdminIngreso._IN_USER_ID);
                dt.SetMState(TypeState._LiveSysAdminIngreso, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_INGRESO);
            }
            if (dt.EqualsMState(TypeState._SysAdmin, SysAdmin._MODIFI_USER))
            {
                dt.SetMState(TypeState._SysAdmin, SysAdmin._none);  //<---
                dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._none);
                dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._SysAdminCreate, SysAdminCreate._PRESENTACION);
                dt.SetMState(TypeState._LiveSysAdminCreate, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_CREATE);
            }
            if (dt.EqualsMState(TypeState._SysAdmin, SysAdmin._STATE_USER))
            {
                dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._none);
                dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._SysAdminEstado, SysAdminEstado._MENUOPCION);
                dt.SetMState(TypeState._LiveSysAdminEstado, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_STATEUSER);
            }
            if (dt.EqualsMState(TypeState._SysAdmin, SysAdmin._ROLES_PERMISOS))
            {
                dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._none);
                dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._SysAdminRolesPer, SysAdminRolesPerm._MENUOPCION);
                dt.SetMState(TypeState._LiveSysAdminRolesPer, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_ROLESPER);                
            }
            if (dt.EqualsMState(TypeState._SysAdmin, SysAdmin._REMOVE_USER))
            {
                dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._none);
                dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._INACTIVATED);
                dt.SetMState(TypeState._SysAdminRemove, SysAdminRemove._MENUOPCION);
                dt.SetMState(TypeState._LiveSysAdminRemove, LiveProgram._ACTIVATED);
                dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN_ELIMINAR);
            }
        }
        public static void UsuarioInexistente(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            string[] mensaje = { "   U S U A R I O   ", "   I N E X I S T E N T E   " };
            FUNCTION.Mensagedata(mensaje, color.DARK_AMARILLO, color.AZUL, color.ROJO, 100, 20);
            dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._VOLVER);
        }
        public static void Busqueda(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();
            color[] backcorral = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] forecorral = { color.DARK_GRIS, color.DARK_AZUL, color.AZUL, color.DARK_MAGENTA };
            color[] backtitulo = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foretitulo = { color.DARK_GRIS, color.DARK_ROJO, color.ROJO, color.DARK_ROJO };
            color[] backData = { color.GRIS, color.DARK_GRIS, color.BLANCO, color.DARK_GRIS, color.DARK_AMARILLO };
            color[] foreData = { color.NEGRO, color.DARK_MAGENTA, color.MAGENTA, color.MAGENTA, color.ROJO };
            
            string leg = "";
            int posicion_usuario = 0, tamaño = 0;
            string titulo = "SysAdmin - ";

            switch ((SysAdmin)(dt.GetMState(TypeState._SysAdmin)))
            {
                case (SysAdmin._INGRESO_USER): titulo = String.Concat(titulo, "Ingresar Usuarios al Sistema"); tamaño = 40;  break;
                case (SysAdmin._MODIFI_USER): titulo = String.Concat(titulo, "Modificar Usuarios al Sistema"); tamaño = 42; break;
                case (SysAdmin._STATE_USER): titulo = String.Concat(titulo, "Modificar Estado de Usuarios al Sistema"); tamaño = 54; break;
                case (SysAdmin._ROLES_PERMISOS): titulo = String.Concat(titulo, "Agrear o Modificar Roles y Permisos a Usuarios"); tamaño = 57; break;
                case (SysAdmin._REMOVE_USER): titulo = String.Concat(titulo, "Borrar Usuarios del Sistema"); tamaño = 39; break;
            }
            
            IOdata.Selector(color.BLANCO, color.AZUL, titulo, tamaño, 90, 8);
            if (dt.EqualsMState(TypeState._SysAdminSeek, SysAdminSeek._BUSQUEDA_LEGAJO))
            {
                IODATAINFO Legajo_ = new IODATAINFO(" Legajo ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 30, 15);
                Legajo_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
                Legajo_.SetDataInfo((string)"");
                Legajo_.SetActivated();
                Legajo_.Display(color.NEGRO, color.NEGRO);
                leg = (string)Legajo_.GetDataInfo();
            }
            if (dt.EqualsMState(TypeState._SysAdminSeek, SysAdminSeek._BUSQUEDA_DNI))
            {
                IOMULTIDATA Dni_ = new IOMULTIDATA("  DNI ", "...", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, new int[] { 2, 3, 3 }, 30, 15);
                Dni_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
                Dni_.SetDataInfo((string)"");
                Dni_.SetActivated();
                Dni_.Display(color.NEGRO, color.NEGRO);
                leg = (string)Dni_.GetDataInfo();
            }
            if (dt.EqualsMState(TypeState._SysAdminSeek, SysAdminSeek._BUSQUEDA_USERID))
            {
                IODATAINFO user_id_ = new IODATAINFO(" User-ID ", backcorral, forecorral, backtitulo, foretitulo, backData, foreData, TypePost._LEFT, TypeLine._DOUBLE, TypeINFO._NORMAL, 30, 25, 30, 15);
                user_id_.SetTypeDataIN(TypeDataIN._LETTER);
                user_id_.SetTypeDataIN(TypeDataIN._SHIFT_LETTER);
                user_id_.SetTypeDataIN(TypeDataIN._NUMERIC_FILE);
                user_id_.SetDataInfo((string)"");
                user_id_.SetActivated();
                user_id_.Display(color.NEGRO, color.NEGRO);
                leg = ((string)user_id_.GetDataInfo()).ToLower();
            }
            Usuario seek = new Usuario();
            List<Usuario> listadobusqueda = new List<Usuario>();
            FDUsuario condicion = new FDUsuario("ListUserProgram");
            condicion.LoadListUser(ref listadobusqueda);
            bool est = true;
            string code_select = "";
            while((posicion_usuario < listadobusqueda.Count) && (est))
            {
                seek = listadobusqueda[posicion_usuario];

                switch(dt.GetMState(TypeState._SysAdminSeek))
                {
                    case (SysAdminSeek._BUSQUEDA_LEGAJO): code_select = seek.Legajo; break;
                    case (SysAdminSeek._BUSQUEDA_DNI): code_select = seek.DNI; break;
                    case (SysAdminSeek._BUSQUEDA_USERID): code_select = seek.UserID; break;
                }
                
                if (((String.Compare(code_select, leg)) == 0) && (posicion_usuario != 0) && ((String.Compare(leg, dt.USERSESION.UserID)) != 0))
                {
                    est = false;
                } else { posicion_usuario++; }                
            }
            dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._NODETECT);
            if (!est)
            {
                dt.POSITION = posicion_usuario;
                dt.USERCREATE = listadobusqueda[posicion_usuario];
                dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._DIRECCION);
                dt.CONDICION_LISTA = LiveProgram._INACTIVATED;
            }
            listadobusqueda.Clear();            
        }
        public static void Volver(ref BDState dt)
        {
            dt.SetMState(TypeState._LiveSysAdminSeek, LiveProgram._INACTIVATED);
            dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._none);
            dt.SetMState(TypeState._LiveSysAdmin, LiveProgram._ACTIVATED);
            dt.SetMState(TypeState._SysAdmin, SysAdmin._MENU);
            dt.SetMState(TypeState._StateMain, StateMain._SYSADMIN);
        }
        public static void Selector(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_CYAN, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(dt.USERSESION.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + dt.USERSESION.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);
            Console.ResetColor();

            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

            string[] selopcion = { " Busqueda por Legajo " ,
                                   " Busqueda por D.N.I. " ,
                                   " Volver al Menu " };

            Console.ResetColor();
            string titulo = "SysAdmin - ";
            switch ((SysAdmin)(dt.GetMState(TypeState._SysAdmin)))
            {
                case (SysAdmin._INGRESO_USER): titulo = String.Concat(titulo, "Ingresar Usuarios al Sistema"); break;
                case (SysAdmin._MODIFI_USER): titulo = String.Concat(titulo, "Modificar Usuarios al Sistema"); break;
                case (SysAdmin._REMOVE_USER): titulo = String.Concat(titulo, "Eliminar Usuarios al Sistema"); break;
            }
            IOMENU menuopcion = new IOMENU(titulo, selopcion, 3, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 42, 10);
            menuopcion.SetDataInfo(7);
            menuopcion.Display(color.NEGRO, color.NEGRO);
            int opcion = (int)menuopcion.GetDataInfo();
            switch (opcion) 
            {
                case 0: dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._BUSQUEDA_LEGAJO); break;
                case 1: dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._BUSQUEDA_DNI); break;
                case 2: dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._VOLVER); break;
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
            dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._VOLVER);
        }
        public static void VerificacionUser(ref BDState dt)
        {
            FDUsuario condicion = new FDUsuario("ListUserProgram");
            int cont = condicion.CountListUser();
            if (cont > 1) { 
                dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._PRESENTACION);
                if ((dt.EqualsMState(TypeState._SysAdmin, SysAdmin._STATE_USER)) 
                    || (dt.EqualsMState(TypeState._SysAdmin, SysAdmin._ROLES_PERMISOS))
                    || (dt.EqualsMState(TypeState._SysAdmin, SysAdmin._REMOVE_USER)))
                {
                    dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._BUSQUEDA_USERID);
                }
            }
            if (cont == 1) { dt.SetMState(TypeState._SysAdminSeek, SysAdminSeek._MENSAGE01); }
        }
    }
}
