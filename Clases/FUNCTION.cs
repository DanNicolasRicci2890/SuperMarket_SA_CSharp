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
    public class FUNCTION
    {
        public static string SeparadorEspacio(string nom)
        {
            string po = "";
            string[] lp = nom.Split(' ');
            
            for(int i = 0; i < lp.Length; i++)
            {
                lp[i] = lp[i].ToUpper();
                char[] chars = lp[i].ToCharArray();
                for(int j = 0; j < chars.Length; j++)
                {
                    po += (chars[j].ToString());
                    if (i != chars.Length - 1) { po += " "; }
                }
                if (i != lp.Length - 1) { po += "  "; }
            }
            po = po.PadLeft(po.Length + 3, ' ');
            po = po.PadRight(po.Length + 3, ' ');
            return (po);
        }
        public static string SeekCodeTipoProduct(string nom)
        {
            FDTypeProduct op = new FDTypeProduct("ListTypeProduct");
            op.LoadTypeProductList();
            int index = op.SeekNomTypeProduct(nom);
            string valor = op.GetTypeProducto(index).Code;
            return (valor);
        }
        public static int PosicionVector(string pos)
        {
            double valor = Convert.ToDouble(pos);            
            double resultado = (Math.Log(valor)) / (Math.Log(2));
            return (Convert.ToInt32(resultado));
        }
        public static string[] ListTipoProducto()
        {
            FDTypeProduct op = new FDTypeProduct("ListTypeProduct");
            op.LoadTypeProductList();
            int count = op.CountListTypeProduct();            
            string[] lister = new string[count];
            for(int i = 0; i < count; i++)
            {
                lister[i] = op.GetTypeProducto(i).ProductName;
            }
            return (lister);
        }
        public static string ConcatenadorFile3(string nom, string cod, string extension)
        {
            string kt = @Directory.GetCurrentDirectory();
            string kt_save = kt.Replace(@"\bin\Debug", @"\BaseData\Sucursales\");
            string archivo = "";
            if (cod.Length > 0) { archivo = String.Concat(nom, "_", cod, extension); }
            if (cod.Length == 0) { archivo = String.Concat(nom, extension); }
            string salida = String.Concat(kt_save, archivo);            
            return salida;
        }
        public static string ConcatenadorFile2(string nom, string cod, string extension)
        {
            string kp = @Directory.GetCurrentDirectory();
            string kd = String.Concat(@"\BaseData\Productos\", nom, "_", cod, extension);
            string salida = kp.Replace(@"\bin\Debug", @kd);
            return salida;
        }
        public static string ConcatenadorFile(string archivo, string extension)
        {
            string kp = @Directory.GetCurrentDirectory();
            string kd = String.Concat(@"\BaseData\", archivo, extension);
            string salida = kp.Replace(@"\bin\Debug", @kd);
            return salida;
        }
        public static void StateBit(ref int kl, int km, int[] bits, int bit)
        {
            int i = 0;
            bool estado = true;

            while ((i < bits.Length) && (estado))
            {
                if (((km >> bits[i]) & 1) == 1)
                {
                    kl |= (1 << bit);
                    estado = false;
                }
                i++;
            }            
        }
        public static void StateBit(ref int kl, int km, int bit1, int bit2)
        {
            if (((km >> bit1) & 1) == 1)
            {
                kl |= (1 << bit2);
            }
        }
        public static bool passwordcorrecto(string k)
        {
            bool lp = false;
            char[] p = k.ToCharArray();
            int cont_M = 0, cont_m = 0, cont_num = 0, cont_esp = 0;

            for(int i = 0; i < k.Length; i++)
            {
                int pl = (int)(p[i]);
                if ((pl >= 65) && (pl <= 90)) { cont_M++; }
                else
                {
                    if ((pl >= 97) && (pl <= 122)) { cont_m++; }
                    else
                    {
                        if ((pl >= 48) && (pl <= 57)) { cont_num++; }
                        else
                        {
                            if ((pl == 33) || (pl == 64) || ((pl >= 35) && (pl <= 38)) || (pl == 47) || (pl == 40) || (pl == 41) || (pl == 61))
                            {
                                cont_esp++;
                            }
                        }
                    }
                }
            }
            if ((cont_M > 0) && (cont_m > 0) && (cont_num > 0) && (cont_esp > 0)) { lp = true; }
            return lp;
        }
        public static string usuariominuscula(string k)
        {
            string h = "";
            char[] cadena = k.ToCharArray();
            for(int i = 0; i < k.Length; i++)
            {
                char p = cadena[i];

                if ((((int)p) >= 65) && (((int)p) <= 90))
                {
                    p = (char)(((int)p) + 32);                    
                }
                h += p.ToString();
            }
            return h;
        }
        public static void Mensagedatatime(string[] mensaje, color bcorral, color fcorral, color titulo, int time, int x, int y)
        {
            int max = 0;
            for (int i = 0; i < mensaje.Length; i++)
            {
                if (max < mensaje[i].Length)
                {
                    max = mensaje[i].Length;
                }
            }
            max += 12;
            for (int i = 0; i < mensaje.Length; i++)
            {
                int k = (max - mensaje[i].Length) / 2;
                mensaje[i] = mensaje[i].PadLeft(k + mensaje[i].Length, ' ');
                k = max - mensaje[i].Length;
                mensaje[i] = mensaje[i].PadRight(k + mensaje[i].Length, ' ');
            }
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            for(int k = 0; k < time; k++)
            {
                DRAW.CuadradoSolid(fcorral, max, mensaje.Length + (mensaje.Length - 1) + 4, x, y);
                DRAW.CuadradoSolid(bcorral, max - 2, mensaje.Length + (mensaje.Length - 1) + 2, x + 1, y + 1);
                for (int i = 0; i < mensaje.Length; i++)
                {
                    OUT.PrintLine(mensaje[i], titulo, bcorral, x + ((max - mensaje[i].Length) / 2) + 1, y + 3 + (i * 2));
                }
                System.Threading.Thread.Sleep(500);
                COLOR.ColorFondo(color.NEGRO);
                System.Threading.Thread.Sleep(500);
            }            
        }
        public static void Mensagedata(string[] mensaje, color bcorral, color fcorral, color titulo, int x, int y)
        {
            int max = 0;
            for (int i = 0; i < mensaje.Length; i++)
            {
                if (max < mensaje[i].Length)
                {
                    max = mensaje[i].Length;
                }
            }
            max += 12;
            for (int i = 0; i < mensaje.Length; i++)
            {
                int k = (max - mensaje[i].Length) / 2;
                mensaje[i] = mensaje[i].PadLeft(k + mensaje[i].Length, ' ');
                k = max - mensaje[i].Length;
                mensaje[i] = mensaje[i].PadRight(k + mensaje[i].Length, ' ');
            }
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(fcorral, max, mensaje.Length + (mensaje.Length - 1) + 4, x, y);
            DRAW.CuadradoSolid(bcorral, max - 2, mensaje.Length + (mensaje.Length - 1) + 2, x + 1, y + 1);
            for (int i = 0; i < mensaje.Length; i++)
            {
                OUT.PrintLine(mensaje[i], titulo, bcorral, x + ((max - mensaje[i].Length) / 2) + 1, y + 3 + (i * 2));
            }
            System.Threading.Thread.Sleep(2000);

        }
        public static void UsuarioPerfilado(ref BDState dt)
        {
            COLOR.ColorFondo(color.NEGRO);
            Console.Clear();
            DRAW.CuadradoSolid(color.DARK_VERDE, dt.WIDTH - 10, dt.HEINGHT - 8, 4, 4);
            DRAW.CuadradoSolid(color.NEGRO, dt.WIDTH - 14, dt.HEINGHT - 10, 6, 5);

            DRAW.CuadradoLineDouble(color.NEGRO, color.DARK_GRIS, 80, 15, 8, 6);
            DRAW.CuadradoLineDouble(color.NEGRO, color.DARK_GRIS, 80, 5, 91, 6);
            DRAW.CuadradoLineDouble(color.NEGRO, color.DARK_GRIS, 25, 5, 91, 13);
            DRAW.CuadradoLineDouble(color.NEGRO, color.DARK_GRIS, 82, 5, 119, 13);

            Usuario usuario_view = new Usuario();
            Usuario usuario_sesion = new Usuario();
            if (dt.EqualsMState(TypeState._UserPerfil, UserPerfil._VIEW)) 
            { 
                usuario_view = usuario_sesion = dt.USERSESION; 
            } else
            {
                if ((dt.EqualsMState(TypeState._SysAdmin, SysAdmin._STATE_USER)) 
                    || (dt.EqualsMState(TypeState._SysAdmin, SysAdmin._ROLES_PERMISOS))
                    || (dt.EqualsMState(TypeState._SysAdmin, SysAdmin._REMOVE_USER))
                    || (dt.EqualsMState(TypeState._SysAdmin, SysAdmin._STATE_USER))) {
                    usuario_sesion = dt.USERSESION;
                    usuario_view = dt.USERCREATE;
                }
            }
            DRAW.CuadradoSolid(color.BLANCO, 50, 2, 177, 5);
            OUT.PrintLine(usuario_sesion.IdentidadConcatenar(), color.DARK_AZUL, color.BLANCO, 179, 6);
            OUT.PrintLine("legajo: " + usuario_sesion.Legajo, color.DARK_AZUL, color.BLANCO, 179, 7);

            color[] back = { color.NEGRO, color.NEGRO };
            color[] fore = { color.GRIS, color.CYAN };

            string[] nombreapellido = { "Nombre y Apellido: ", usuario_view.ConcatenarIdent() };
            string[] legajo = { "Legajo: ", usuario_view.Legajo };
            string[] userid = { "User-ID: ", usuario_view.UserID };
            string[] password = { "Password: " , usuario_view.encriptado() };
            string[] dni = { "Dni: " , usuario_view.DNI};
            string[] fecha_nacimiento = { "Fecha de Nacimiento: " , Usuario.ImprimirFechaNac(usuario_view.FechNac)};
            string[] edad = { "Edad: ", String.Concat(usuario_view.calcularedad().ToString(), " años ") };
            string[] telef = { "Telefono: ", usuario_view.Telefono };
            string[] celu = { "Celular: ", usuario_view.Celular };
            string[] email = { "Email: ", usuario_view.ImprimirEmail() };

            string[] direccion1 = { "Direccion: " , usuario_view.ConcatenarDireccion1() };
            string direccion2 = usuario_view.ConcatenarDireccion2();
            
            string condicion = CondicionUsuario1(usuario_view);

            string[] fechaexpira = { "Fecha Expiracion: ", CondicionUsuario2(usuario_view) };
            string[] fechaexpirapass = { "Fecha Expiracion de Contraseña: ", CondicionUsuario3(usuario_view) };

            OUT.PrintLine(nombreapellido, fore, back, 10, 8);
            OUT.PrintLine(legajo, fore, back, 21, 10);
            OUT.PrintLine(userid, fore, back, 20, 12);
            OUT.PrintLine(password, fore, back, 51, 12);
            OUT.PrintLine(dni, fore, back, 24, 14);
            OUT.PrintLine(fecha_nacimiento, fore, back, 14, 16);
            OUT.PrintLine(edad, fore, back, 64, 16);
            OUT.PrintLine(telef, fore, back, 14, 18);
            OUT.PrintLine(celu, fore, back, 64, 18);
            OUT.PrintLine(email, fore, back, 14, 20);

            OUT.PrintLine(direccion1, fore, back, 94, 8);
            OUT.PrintLine(direccion2, fore[1], back[1], 105, 10);

            OUT.PrintLine("estado de cuenta", fore[0], back[0], 96, 15);
            OUT.PrintLine(condicion, fore[1], back[1], 94, 17);

            OUT.PrintLine(fechaexpira, fore, back, 122, 15);
            OUT.PrintLine(fechaexpirapass, fore, back, 122, 17);            
        }
        public static void UsuarioRoles(ref BDState dt)
        {
            int i = 0, j = 0, k = 0, roles = 0;
            List<string> select = new List<string>();
            bool str = false;
            for (i = 0; i < 5; i++)
            {
                if (((dt.USERCREATE.SystemRoles >> i) & 1) == 1)
                {
                    if (i == 0)
                    {
                        roles = dt.USERCREATE.SystemSysAdmin;
                        RecargaRoles(ref select, i);
                        int cantidad = ContadorRoles(roles);
                        if (cantidad > 7) {
                            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 80 }, new int[] { 21 }, 8, 23);
                            IOdata.Selector(color.BLANCO, color.AZUL, "      Roles de SysAdmin      ", 28, 33, 24);
                            str = true;
                        } else
                        {
                            DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 40 }, new int[] { 21 }, 8, 23);
                            IOdata.Selector(color.BLANCO, color.AZUL, " Roles de SysAdmin ", 19, 18, 24);
                            str = false;
                        }                        
                    }
                    if (i == 1)
                    {
                        roles = dt.USERCREATE.SystemAdministrador;
                        RecargaRoles(ref select, i);
                        int cantidad = ContadorRoles(roles);
                        if(str)
                        {
                            if (cantidad > 7)
                            {
                                DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 80 }, new int[] { 21 }, 89, 23);
                                IOdata.Selector(color.BLANCO, color.AZUL, "    Roles de Administrador    ", 28, 100, 24);
                                str = true;
                            }
                            else
                            {
                                DRAW.TablaLine(TypeLine._DOUBLE, color.NEGRO, color.GRIS, new int[] { 40 }, new int[] { 21 }, 8, 23);
                                IOdata.Selector(color.BLANCO, color.AZUL, " Roles de Administrador ", 19, 18, 24);
                                str = false;
                            }
                        }
                    }
                    k = 0;
                    for(j = 0; j < select.Count; j++)
                    {
                        if (j <= 7)
                        {
                            OUT.PrintLine(select[j], color.DARK_VERDE, color.NEGRO, 10, 28 + (k * 2));
                            if (j == 7) { k = -1; }
                        }
                        if (j > 7)
                        {
                            OUT.PrintLine(select[j], color.DARK_VERDE, color.NEGRO, 51, 28 + (k * 2));
                        }
                        k++;
                    }
                    select.Clear();
                }
                

            }

            //usuario_view.SystemRoles


            /*
             36

            */
        }
        public static string CondicionUsuario3(Usuario valor)
        {
            int timenow = (DateTime.Now.Year * 10000) + (DateTime.Now.Month * 100) + (DateTime.Now.Day);
            string h = "";
            if ((valor.SWExpPassword) == 1) { h = " La Contraseña Nunca Expira."; }
            else { 
                h = Usuario.ImprimirFechaNac(valor.FechNacExpPass);
                h = String.Concat(h, " ~ (");
                if (timenow < valor.FechNacExpPass) { h = String.Concat(h, "Contraseña Activa)"); }
                else
                {
                    if (timenow >= valor.FechNacExpPass) { h = String.Concat(h, "Contraseña Expirada)"); }
                }
            }
            return (h);
        }
        public static string CondicionUsuario2(Usuario valor)
        {
            int timenow = (DateTime.Now.Year * 10000) + (DateTime.Now.Month * 100) + (DateTime.Now.Day);
            string h = "";
            if ((valor.SWExpirated) == 1) { h = " La Cuenta NO EXPIRA."; }
            else { 
                h = Usuario.ImprimirFechaNac(valor.FechNacExp);
                h = String.Concat(h, " ~ (");
                if (timenow < valor.FechNacExp) { h = String.Concat(h, " Cuenta Activa )"); }
                else
                {
                    if (timenow >= valor.FechNacExp) { h = String.Concat(h, " Cuenta Expirada )"); }
                }            
            }
            return (h);
        }
        public static string CondicionUsuario1(Usuario valor)
        {
            string st = "";

            if ((valor.StHabilitacion()) == 1)
            {
                st = "Cuenta Deshabilitada";
            }            
            else
            {
                st = "  Cuenta Habilitada";
                if (!(valor.StExpirated()))
                {
                    st = "  cuenta expirada";
                } else
                {
                    if (!(valor.StExpPassword())) { st = "  contraseña expirada"; } 
                    else
                    {
                        if (!(valor.StBlockPass())) { st = "  contraseña Bloqueada"; }
                        else
                        {
                            if (!(valor.StBlocked())) { st = "  cuenta Bloqueada"; }
                        }
                    }
                }
            }
            return (st);
        }
        public static void MostrarProducto(StockProduct producto, FDProducto opus_product, int k)
        {
            string hp = String.Concat(" ", producto.TipoProducto, "(", producto.Codigo, ")");
            IOdata.Selector(color.BLANCO, color.AZUL, hp, 23, 17, 16 + (k * 3));
            IOdata.Selector(color.BLANCO, color.AZUL, producto.Marca, 23, 43, 16 + (k * 3));
            hp = String.Concat(" ", producto.NombreProducto, "(", producto.CodigoProducto, ")");
            IOdata.Selector(color.BLANCO, color.AZUL, hp, 38, 69, 16 + (k * 3));


            int klp = opus_product.SeekProducto(producto.CodigoProducto);
            Producto gf = opus_product.GetProducto(klp);
            switch (gf.Moneda)
            {
                case (TipoMoneda._PESOS): hp = "  $ "; break;
                case (TipoMoneda._DOLAR): hp = "u$s "; break;
            }
            hp = String.Concat(hp, gf.Precio.ToString());
            IOdata.Selector(color.BLANCO, color.AZUL, hp, 23, 110, 16 + (k * 3));
        }
        public static void MostrarComprar(BoxProduct comprar, color back, color fore, int index, int k)
        {
            IOdata.Selector(back, fore, index.ToString(), 3, 11, 16 + (k * 3));
            IOdata.Selector(back, fore, comprar.GetTipoProducto(), 23, 17, 16 + (k * 3));
            IOdata.Selector(back, fore, comprar.GetMarca(), 23, 43, 16 + (k * 3));
            IOdata.Selector(back, fore, comprar.GetProducto(), 38, 69, 16 + (k * 3));
            IOdata.Selector(back, fore, comprar.GetPrecioStr(), 23, 110, 16 + (k * 3));
            IOdata.Selector(back, fore, comprar.CANTIDAD.ToString(), 18, 136, 16 + (k * 3));
            comprar.SetSubPrecio();
            IOdata.Selector(back, fore, comprar.GetSubPrecioStr(), 17, 157, 16 + (k * 3));
        }
        public static void MostrarGanancia(SucursalGain gn, int index, int col, int k, float dolar)
        {
            color[] colorfore = { color.DARK_GRIS, color.DARK_CYAN, color.MAGENTA, color.NEGRO };
            color[] colorback = { color.NEGRO, color.BLANCO };

            IOdata.Selector(colorback[col * 1], colorfore[col * 1], (index + 1).ToString(), 3, 13, 17 + (k * 3));
            IOdata.Selector(colorback[col * 1], colorfore[col * 1], gn.NombreSucursal, 48, 19, 17 + (k * 3));
            IOdata.Selector(colorback[col * 1], colorfore[col * 1], gn.Codigo, 18, 70, 17 + (k * 3));
            IOdata.Selector(colorback[col * 1], colorfore[col * 2], String.Concat(" u$s ", gn.MDolar.ToString()), 18, 91, 17 + (k * 3));
            IOdata.Selector(colorback[col * 1], colorfore[col * 2], String.Concat(" $ ", gn.MPesos.ToString()), 18, 112, 17 + (k * 3));
            float suma = gn.MDolar + (gn.MPesos / dolar);
            IOdata.Selector(colorback[col * 1], colorfore[col * 3], String.Concat(" u$s ", suma.ToString()), 28, 133, 17 + (k * 3));
            suma = gn.MPesos + (gn.MDolar * dolar);
            IOdata.Selector(colorback[col * 1], colorfore[col * 3], String.Concat(" $ ", suma.ToString()), 27, 164, 17 + (k * 3));
        }
        public static void TableClear()
        {
            DRAW.CuadradoSolid(color.NEGRO, 3, 28, 11, 16);
            DRAW.CuadradoSolid(color.NEGRO, 23, 28, 17, 16);
            DRAW.CuadradoSolid(color.NEGRO, 23, 28, 43, 16);
            DRAW.CuadradoSolid(color.NEGRO, 38, 28, 69, 16);
            DRAW.CuadradoSolid(color.NEGRO, 23, 28, 110, 16);
            DRAW.CuadradoSolid(color.NEGRO, 18, 28, 136, 16);
            DRAW.CuadradoSolid(color.NEGRO, 17, 28, 157, 16);
        }
        public static void TableClear2()
        {
            DRAW.CuadradoSolid(color.NEGRO, 3, 29, 13, 17);
            DRAW.CuadradoSolid(color.NEGRO, 48, 29, 19, 17);
            DRAW.CuadradoSolid(color.NEGRO, 18, 29, 70, 17);
            DRAW.CuadradoSolid(color.NEGRO, 18, 29, 91, 17);
            DRAW.CuadradoSolid(color.NEGRO, 18, 29, 112, 17);
            DRAW.CuadradoSolid(color.NEGRO, 28, 29, 133, 17);
            DRAW.CuadradoSolid(color.NEGRO, 27, 29, 164, 17);
        }
        public static void Limpiador()
        {
            for (int m = 0; m < 8; m++)
                for (int n = 0; n < 35; n++)
                    OUT.PrintLine(" ", color.NEGRO, color.NEGRO, 190 + n, 21 + m);
        }
        public static void Ordenamiento(ref List<BoxProduct> listado)
        {
            // ordenamiento x burbuja
            bool td = true;
            int i = 0;
            BoxProduct aux = new BoxProduct();

            do
            {
                td = false;
                for (i = 0; i < (listado.Count - 1); i++)
                {
                    int vtv = listado[i] == listado[i + 1];
                    if (vtv < 0)
                    {
                        aux = listado[i];
                        listado[i] = listado[i + 1];
                        listado[i + 1] = aux;
                        td = true;
                    }
                }
            } while (td);
        }
        public static void CorteDeControl(ref List<BoxProduct> listado)
        {
            // Corte de Control
            int index = 0;

            while (index != (listado.Count - 1))
            {
                if ((listado[index] == listado[index + 1]) == 0)
                {
                    listado[index].CANTIDAD += listado[index + 1].CANTIDAD;
                    listado[index].SetSubPrecio();
                    listado.RemoveAt(index + 1);
                }
                else { index++; }
            }
        }
        public static void ProcesodePago(ref BDState dt, ref IODATAINFO infodata)
        {
            infodata.SetActivated();
            infodata.Display(color.NEGRO, color.NEGRO);
            string th = infodata.GetDataInfo().ToString();

            if ((th.Length) != 0)
            {

                try
                {
                    th = th.Replace('.', ',');
                    int count = 0;
                    char[] lt = th.ToCharArray();
                    for(int i = 0; i < lt.Length; i++)
                    {
                        if (lt[i].Equals(','))
                        {
                            count++;
                        }
                    }
                    if ((count == 0) || (count == 1))
                    {
                        
                        float pago = Convert.ToSingle(th);
                        float importe = 0;
                        switch(dt.CONDICION_PAGO)
                        {
                            case (Moneda._PESOS): th = "Pesos"; importe = dt.COMPRAPESOS + (dt.COMPRADOLARES * dt.DOLARPESOS); break;
                            case (Moneda._DOLARES): th = "Dolares"; importe = dt.COMPRADOLARES + (dt.COMPRAPESOS / dt.DOLARPESOS); break;
                        }
                        if (pago >= importe)
                        {
                            OUT.PrintLine(new String[] { "              Moneda: ", th }, new color[] { color.BLANCO, color.ROJO }, new color[] { color.NEGRO, color.NEGRO }, 20, 25);
                            
                            if (dt.CONDICION_PAGO == Moneda._PESOS)
                            {
                                OUT.PrintLine(new String[] { "   Importe ingresado: $ ", pago.ToString() }, new color[] { color.BLANCO, color.ROJO }, new color[] { color.NEGRO, color.NEGRO }, 20, 27);
                                OUT.PrintLine(new String[] { "              Vuelto: $ ", (pago - importe).ToString() }, new color[] { color.BLANCO, color.ROJO }, new color[] { color.NEGRO, color.NEGRO }, 20, 29);
                            }
                            if (dt.CONDICION_PAGO == Moneda._DOLARES)
                            {
                                OUT.PrintLine(new String[] { "   Importe ingresado: u$s ", pago.ToString() }, new color[] { color.BLANCO, color.ROJO }, new color[] { color.NEGRO, color.NEGRO }, 20, 27);
                                OUT.PrintLine(new String[] { "              Vuelto: u$s ", (pago - importe).ToString() }, new color[] { color.BLANCO, color.ROJO }, new color[] { color.NEGRO, color.NEGRO }, 20, 29);
                            }
                            color[] backboxline = { color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO, color.NEGRO };
                            color[] foreboxline = { color.DARK_GRIS, color.DARK_GRIS, color.DARK_ROJO, color.DARK_CYAN, color.MAGENTA };
                            color[] backselect = { color.NEGRO, color.GRIS, color.NEGRO, color.BLANCO, color.DARK_AMARILLO };
                            color[] foreselect = { color.DARK_GRIS, color.NEGRO, color.DARK_CYAN, color.MAGENTA, color.AZUL };

                            string[] selopcion = { " Realizar la Operacion " ,
                                                    " Anular el Pago " };

                            Console.ResetColor();
                            IOMENU menuopcion = new IOMENU(" Proceso de Pago ", selopcion, 2, color.none, color.DARK_AZUL, color.BLANCO, color.MAGENTA, backboxline, foreboxline, backselect, foreselect, 20, 34);
                            menuopcion.SetDataInfo(3);
                            menuopcion.Display(color.NEGRO, color.NEGRO);
                            int menu = (int)menuopcion.GetDataInfo();
                            switch(menu)
                            {
                                case 0: dt.SetMState(TypeState._CajeroST, CajeroST._PROCESO_PAGO); break;
                                case 1: dt.SetMState(TypeState._CajeroST, CajeroST._CAJERO); break;
                            }
                        }
                        else { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE13); }
                    }
                    else { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE12); }
                }
                catch { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE12); }
            } else { dt.SetMState(TypeState._CajeroST, CajeroST._MENSAGE12); }
        }
        private static int ContadorRoles(int roles)
        {
            int contador = 0;
            for(int i = 0; i < 16; i++)
            {
                if (((roles >> i) & 1) == 1)
                {
                    contador++;
                }
            }
            return (contador);
        }
        private static void RecargaRoles(ref List<string> lister, int index)
        {
            if (index == 0)
            {
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
            if (index == 1)
            {
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
        }
    }
}
