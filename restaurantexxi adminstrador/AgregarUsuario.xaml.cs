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
using Tulpep.NotificationWindow;

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para AgregarUsuario.xaml
    /// </summary>
    public partial class AgregarUsuario : MetroWindow
    {
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_adduser_Click(object sender, RoutedEventArgs e)
        {
            usuarioBLL ub = new usuarioBLL();
            Generic g = new Generic();
            verificar();

            bool nombre = true;
            bool apellido = true;
            bool rut = true;
            bool rol = true;
            bool fono = true;
            bool direccion = true;
            bool contrasena = true;
            if (coc.IsSelected || bart.IsSelected || Admin.IsSelected || Gar.IsSelected || fina.IsSelected || caja.IsSelected || bodega.IsSelected)
            {
                rol = true;
            }
            else
            {
                rol = false;
                lb2.Content = "Ingrese un rol";

            }

            if (txt_apellido.Text.Trim() == "")
            {
                nombre = false;
                lb4.Content = "Ingrese un apellido";
            }

            if (txt_pass.Text == "")
            {
                contrasena = false;
                lb7.Content = "Ingrese una contraseña";
            }

            if (txt_nombre.Text.Trim() == "")
            {
                apellido = false;
                lb3.Content = "Ingrese un nombre";
            }

            if (txt_rut.Text.Trim() == "")
            {
                rut = false;
                lb1.Content = "Ingrese un rut";
            }

            if (txt_direccion.Text.Trim() == "")
            {
                direccion = false;
                lb6.Content = "Ingrese una dirección";
            }

            if (txt_fono.Text.Trim() == "")
            {
                fono = false;
                lb5.Content = "Ingrese un número";
            }



            if (nombre == true && rut == true && apellido == true && rol == true && fono == true && direccion == true && contrasena == true)
            {
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
                    roll = "Garzon";
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
                    roll = "Caja";
                }
                else if (bodega.IsSelected)
                {
                    roll = "Bodeguero";
                }
                else
                {
                    lb2.Content = "Ingrese un rol";
                }
                ub.rol = roll;

                string[] partesnom = txt_nombre.Text.Split(' ');
                string[] partesape = txt_apellido.Text.Split(' ');
                string primera = partesnom[0];
                string segunda = partesape[0];

                string nick = (primera + "." + segunda).ToString();
                bool nickexist = ub.Getnick(nick);
                string namefinal = "";
                if (nickexist)
                {
                    string primera1 = partesnom[1];
                    string name = primera + primera1 + segunda;
                    namefinal = name;
                }
                else
                {
                    namefinal = nick;
                }
                ub.nom_usuario = txt_nombre.Text;
                ub.apellido_usuario = txt_apellido.Text;
                ub.fono = Int32.Parse(txt_fono.Text);
                ub.direccion = txt_direccion.Text;
                ub.rut = Int32.Parse(txt_rut.Text);
                string nomb = txt_nombre.Text + " " + txt_apellido.Text;
                string ru = txt_rut.Text;
                string ro = roll;
                ub.clave = txt_pass.Text;
                bool existe = ub.GetUserByRut(Int32.Parse(txt_rut.Text));
                if (existe)
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.TitleText = "Aviso";
                    popup.Image = Properties.Resources.add;
                    popup.ContentText = "El usuario con RUT: " + ru + " Ya existe en sistema";
                    popup.AnimationDuration = 500;
                    popup.Delay = 3500;
                    popup.Popup();
                }
                else
                {
                    ub.AddUser(Int32.Parse(txt_rut.Text), namefinal, txt_pass.Text, roll, "Si");
                    ub.AddinfoUser(ub);
                    PopupNotifier popup = new PopupNotifier();
                    popup.TitleText = "Aviso";
                    popup.Image = Properties.Resources.add;
                    popup.ContentText = "Se ha Creado el usuario: " + nomb + "\n" +
                                        "RUT: " + ru + "\n" +
                                        "ROL: " + roll;
                    popup.AnimationDuration = 800;
                    popup.Delay = 1000;
                    popup.Popup();
                    txt_rut.Clear();
                    txt_nombre.Clear();
                    txt_apellido.Clear();
                    cbb_rol.SelectedIndex = -1;
                    txt_fono.Clear();
                    txt_direccion.Clear();
                    txt_pass.Clear();
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

            if (ascii == 35 || ascii >= 48 && ascii <= 57 || ascii >= 65 && ascii <= 90 || ascii >= 97 && ascii <= 122)
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

        private void verificar()
        {
            if (txt_nombre.Text == "")
            {
                lb1.Content = "Debe ingresar un nombre";
            }
        }

        private void Txt_rut_GotFocus(object sender, RoutedEventArgs e)
        {
            lb1.Content = "";
        }

        private void Cbb_rol_GotFocus(object sender, RoutedEventArgs e)
        {
            lb2.Content = "";
        }

        private void Txt_nombre_GotFocus(object sender, RoutedEventArgs e)
        {
            lb3.Content = "";
        }

        private void Txt_apellido_GotFocus(object sender, RoutedEventArgs e)
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
    }
}
