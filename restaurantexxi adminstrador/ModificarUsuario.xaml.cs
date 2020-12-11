using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using BLL;
using System.Data;
using Tulpep.NotificationWindow;

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para ModificarUsuario.xaml
    /// </summary>
    public partial class ModificarUsuario : MetroWindow
    {
        public ModificarUsuario()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            usuarioBLL ub = new usuarioBLL();

            bool nombre = true;
            bool apellido = true;
            bool rut = true;
            bool rol = true;
            bool fono = true;
            bool direccion = true;
            bool clave = true;
            bool estado = true;
            if (coc.IsSelected || bart.IsSelected || Admin.IsSelected || Gar.IsSelected || fina.IsSelected || caja.IsSelected ||bodega.IsSelected)
            {
                rol = true;
            }
            else
            {
                rol = false;
                lb2.Content = "Ingrese un rol";

            }
            if (txt_Contrasena.Text == "")
            {
                clave = false;
                lb7.Content = "Ingrese una contraseña";
            }
            if (txt_apellido.Text == "")
            {
                nombre = false;
                lb4.Content = "Ingrese un apellido";
            }

            if (txt_nombre.Text == "")
            {
                apellido = false;
                lb3.Content = "Ingrese un nombre";
            }

            if (txt_rut.Text == "")
            {
                rut = false;
                lb1.Content = "Ingrese un rut";
            }

            if (txt_direccion.Text == "")
            {
                direccion = false;
                lb6.Content = "Ingrese una dirección";
            }

            if (txt_fono.Text == "")
            {
                fono = false;
                lb5.Content = "Ingrese un número";
            }


            if (clave == true && nombre == true && rut == true && apellido == true && rol == true && fono == true && direccion == true && estado == true)
            {
                bool existe = ub.GetUserByRut(Int32.Parse(txt_rut.Text));
                if (existe)
                {
                    if (existe == true)
                        ub.id_usuario = Int32.Parse(txt_rut.Text);
                    string roll = "";
                    if (coc.IsSelected)
                    {
                        roll = "Cocinero";
                    }
                    else if (bart.IsSelected)
                    {
                        roll = "Bartender";
                    }
                    else if (Gar.IsSelected)
                    {
                        roll = "Garzón";
                    }
                    else if (fina.IsSelected)
                    {
                        roll = "Finanzas";
                    }
                    else if (Admin.IsSelected)
                    {
                        roll = "Administrador";
                    }
                    else if (caja.IsSelected)
                    {
                        roll = "caja";
                    }
                    else if (bodega.IsSelected)
                    {
                        roll = "Bodeguero";
                    }
                    else
                    {
                        lb2.Content = "Debe seleccionar un rol";
                    }

                    ub.rol = roll;
                    ub.nom_usuario = txt_nombre.Text;
                    ub.apellido_usuario = txt_apellido.Text;
                    ub.fono = Int32.Parse(txt_fono.Text);
                    ub.direccion = txt_direccion.Text;
                    ub.rut = Int32.Parse(txt_rut.Text);
                    ub.clave = txt_Contrasena.Text;
                    string[] partesnom = txt_nombre.Text.Split(' ');
                    string[] partesape = txt_apellido.Text.Split(' ');
                    string primera = partesnom[0];
                    string segunda = partesape[0];

                    string nick = (primera + "." + segunda).ToString();
                    bool nickexist = ub.Getnick(nick);
                    string namefinal = "";
                    if (nickexist)
                    {
                        namefinal = nick;
                    }
                    else
                    {
                        namefinal = nick;
                    }

                    string habilitado = "";
                    if (rdb_habilitar.IsChecked == true)
                    {
                        habilitado = "Si";
                    }
                    else
                    {
                        habilitado = lb_estado.Content.ToString();
                    }
                    int rutt = Int32.Parse(txt_rut.Text);
                    string nom = namefinal;
                    string pass = txt_Contrasena.Text;
                    ub.AlterInfoUser(ub);
                    ub.AlterUser(rutt, namefinal, roll, pass, habilitado);
                    PopupNotifier popup = new PopupNotifier();
                    popup.TitleText = "Aviso";
                    popup.Image = Properties.Resources.add;
                    popup.ContentText = "El usuario con RUT: " + txt_rut.Text + " Fue modificado de forma exitosa";
                    popup.AnimationDuration = 1000;
                    popup.Delay = 1500;
                    popup.Popup();
                    txt_rut.Text = "";
                    txt_nombre.Text = "";
                    txt_apellido.Text = "";
                    cbb_rol.SelectedIndex = -1;
                    txt_fono.Text = "";
                    txt_direccion.Text = "";
                    txt_Contrasena.Text = "";
                    rdb_habilitar.IsEnabled = false;
                    txt_nombre.IsEnabled = false;
                    txt_apellido.IsEnabled = false;
                    cbb_rol.IsEnabled = false;
                    txt_fono.IsEnabled = false;
                    txt_direccion.IsEnabled = false;
                    txt_Contrasena.IsEnabled = false;
                    rdb_habilitar.IsChecked = false;
                }
                else
                {
                    lb1.Content = "Este rut no está registrado en el sistema";
                }
            }
            else
            {
            }
        }

        private void Btn_suser_Click(object sender, RoutedEventArgs e)
        {

            usuarioBLL us = new usuarioBLL();
            if (txt_rut.Text == "")
            {
                lb1.Content = "Debe ingresar un rut para buscar";
            }
            else if (txt_rut.Text != "")
            {
                bool existe = us.GetUserByRut(Int32.Parse(txt_rut.Text));
                if (existe == true)
                {
                    int rut = Int32.Parse(txt_rut.Text);
                    DataTable da = us.userList(rut);
                    DataRow row = da.Rows[0];
                    txt_nombre.Text = row[1].ToString();
                    txt_apellido.Text = row[2].ToString();
                    string estado = row[3].ToString();
                    string rol = row[4].ToString();
                    if (rol == "Cocinero")
                    {
                        coc.IsSelected = true;
                    }
                    else if (rol == "Bartender")
                    {
                        bart.IsSelected = true;
                    }
                    else if (rol == "Garzón")
                    {
                        Gar.IsSelected = true;
                    }
                    else if (rol == "Finanzas")
                    {
                        fina.IsSelected = true;
                    }
                    else if (rol == "Administrador")
                    {
                        Admin.IsSelected = true;

                    }
                    else if (rol == "caja")
                    {
                        caja.IsSelected = true;
                    }
                    else if (rol=="Bodeguero")
                    {
                        bodega.IsSelected = true;
                    }
                    else
                    {

                    }
                    txt_fono.Text = row[5].ToString();
                    txt_direccion.Text = row[6].ToString();
                    txt_Contrasena.Text = row[8].ToString();
                    if (estado == "No")
                    {
                        rdb_habilitar.IsEnabled = true;
                    }
                    else
                    {
                        lb_estado.Content = estado;
                    }

                    txt_nombre.IsEnabled = true;
                    txt_apellido.IsEnabled = true;
                    cbb_rol.IsEnabled = true;
                    txt_fono.IsEnabled = true;
                    txt_direccion.IsEnabled = true;
                    txt_Contrasena.IsEnabled = true;
                }
                else
                {
                    lb1.Content = "Este rut no está registrado en el sistema";
                }
            }
        }

        private void Txt_rut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_rut.Text.Length;
            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 48 && ascii <= 57)
            {
                if (tamanio < 9)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_nombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_nombre.Text.Length;
            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 65 && ascii <= 90 || ascii >= 97 && ascii <= 122)
            {
                if (tamanio < 100)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_apellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_apellido.Text.Length;
            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 65 && ascii <= 90 || ascii >= 97 && ascii <= 122)
            {
                if (tamanio < 100)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_fono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_fono.Text.Length;
            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 48 && ascii <= 57)
            {
                if (tamanio < 9)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_direccion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_direccion.Text.Length;
            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 65 && ascii <= 90 || ascii >= 97 && ascii <= 122)
            {
                if (tamanio < 100)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = true;
            }
        }

        private void Btn_atras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Txt_rut_GotFocus(object sender, RoutedEventArgs e)
        {
            lb1.Content = "";
        }

        private void Txt_nombre_GotFocus(object sender, RoutedEventArgs e)
        {
            lb2.Content = "";
        }

        private void Txt_apellido_GotFocus(object sender, RoutedEventArgs e)
        {
            lb3.Content = "";
        }

        private void ComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            lb4.Content = "";
        }

        private void Txt_fono_GotFocus(object sender, RoutedEventArgs e)
        {
            lb5.Content = "";
        }

        private void Txt_direccion_GotFocus(object sender, RoutedEventArgs e)
        {
            lb6.Content = "";
        }

        private void Txt_Contrasena_GotFocus(object sender, RoutedEventArgs e)
        {
            lb7.Content = "";
        }

        private void Winmodificaruser_Loaded(object sender, RoutedEventArgs e)
        {
            txt_nombre.IsEnabled = false;
            txt_apellido.IsEnabled = false;
            cbb_rol.IsEnabled = false;
            txt_fono.IsEnabled = false;
            txt_direccion.IsEnabled = false;
            txt_Contrasena.IsEnabled = false;
        }
    }
}
