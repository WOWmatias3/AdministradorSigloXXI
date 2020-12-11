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
    /// Lógica de interacción para AgregarProveedor.xaml
    /// </summary>
    public partial class AgregarProveedor : MetroWindow
    {
        public AgregarProveedor()
        {
            InitializeComponent();
        }

        private void Btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            ProveedorBLL pb = new ProveedorBLL();
            bool nombre = true;
            bool fon = true;
            bool email = true;
            bool direccion = true;
            bool descripcion = true;

            if (txt_nombre.Text.Trim() == "")
            {
                nombre = false;
                lb1.Content = "Debe ingresar un nombre";
            }

            if (Fono.Text.Trim() == "")
            {
                fon = false;
                lb2.Content = "Debe ingresar un número teléfonico";
            }

            if (txt_correo.Text.Trim() == "")
            {
                email = false;
                lb3.Content = "Debe ingresar un correo";
            }

            if (Direccion.Text.Trim() == "")
            {
                direccion = false;
                lb4.Content = "Debe ingresar una dirección";
            }
            if (txt_desc.Text.Trim() == "")
            {
                descripcion = false;
                lb5.Content = "Debe ingresar una descripcion";
            }

            if (nombre == true && fon == true && email == true && direccion == true && descripcion == true)
            {
                bool existe = pb.Get_provnomexiste(txt_nombre.Text);
                if (existe)
                {
                    lb1.Content = "Ya existe un proveedor con este nombre";
                }
                else
                {
                    pb.nombre_proveedor = txt_nombre.Text;
                    pb.fono_proveedor = Int32.Parse(Fono.Text);
                    pb.mail_proveedor = txt_correo.Text;
                    pb.direccion_proveedor = Direccion.Text;
                    pb.descripcion = txt_desc.Text;
                    pb.add_prov(pb);
                    PopupNotifier popup = new PopupNotifier();
                    popup.TitleText = "Aviso";
                    popup.Image = Properties.Resources.add;
                    popup.ContentText = "Se ha Agragado al Proveedor: " + txt_nombre.Text;
                    popup.AnimationDuration = 500;
                    popup.Delay = 2500;
                    popup.Popup();
                    txt_nombre.Text = "";
                    Fono.Text = "";
                    txt_correo.Text = "";
                    Direccion.Text = "";
                    txt_desc.Text = "";
                }

            }


        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Txt_nombre_GotFocus(object sender, RoutedEventArgs e)
        {
            lb1.Content = "";
        }

        private void Fono_GotFocus(object sender, RoutedEventArgs e)
        {
            lb2.Content = "";
        }

        private void Txt_correo_GotFocus(object sender, RoutedEventArgs e)
        {
            lb3.Content = "";
        }

        private void Direccion_GotFocus(object sender, RoutedEventArgs e)
        {
            lb4.Content = "";
        }

        private void Txt_desc_GotFocus(object sender, RoutedEventArgs e)
        {
            lb5.Content = "";
        }

        private void Fono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = Fono.Text.Length;

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
    }
}
