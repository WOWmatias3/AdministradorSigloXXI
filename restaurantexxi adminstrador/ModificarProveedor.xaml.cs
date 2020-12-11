using System;
using System.Collections.Generic;
using System.Data;
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
using BLL;
using MahApps.Metro.Controls;
using Tulpep.NotificationWindow;

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para ModificarProveedor.xaml
    /// </summary>
    public partial class ModificarProveedor : MetroWindow
    {
        public ModificarProveedor()
        {
            InitializeComponent();
        }

        private void Btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            ProveedorBLL pb = new ProveedorBLL();
            bool id = true;

            if (txt_id.Text.Trim() == "")
            {
                id = false;
                lbid.Content = "Debe ingresar una id";
            }


            if (id)
            {
                int idd = Int32.Parse(txt_id.Text);
                bool existe = pb.GetProvIdEXISTE(idd);
                if (existe)
                {
                    try
                    {
                        DataTable da = pb.GETALLP(idd);
                        DataRow row = da.Rows[0];
                        txt_nombre.Text = row[1].ToString();
                        txt_fono.Text = row[2].ToString();
                        txt_mail.Text = row[3].ToString();
                        txt_direccion.Text = row[4].ToString();
                        txt_descripcion.Text = row[5].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                }
                else
                {
                    lbid.Content = "Esta id no existe en el sistema";
                }
            }
            else
            {
                lbid.Content = "Debe ingresar una id";
            }


        }




        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {

            ProveedorBLL pb = new ProveedorBLL();


            bool id = true;
            bool nombre = true;
            bool fono = true;
            bool email = true;
            bool direccion = true;
            bool descripcion = true;

            if (txt_id.Text.Trim() == "")
            {
                id = false;
                lbid.Content = "Debe ingresar una id";
            }
            if (txt_nombre.Text.Trim() == "")
            {
                nombre = false;
                lb1.Content = "Debe ingresar un nombre";
            }
            if (txt_fono.Text.Trim() == "")
            {
                email = false;
                lb2.Content = "Debe ingresar un numero";
            }
            if (txt_mail.Text.Trim() == "")
            {
                email = false;
                lb3.Content = "Dbe ingresar un correo";
            }
            if (txt_direccion.Text.Trim() == "")
            {
                direccion = false;
                lb4.Content = "Debe ingresar una dirección";
            }
            if (txt_descripcion.Text.Trim() == "")
            {
                descripcion = false;
                lb5.Content = "Debe ingresar una descripcion ";
            }

            if (id && nombre && fono && email && direccion && descripcion)
            {
                bool existe = pb.GetProvIdEXISTE(Int32.Parse(txt_id.Text));
                if (existe)
                {
                    pb.id_proveedor = Int32.Parse(txt_id.Text);
                    pb.nombre_proveedor = txt_nombre.Text;
                    pb.fono_proveedor = Int32.Parse(txt_fono.Text);
                    pb.mail_proveedor = txt_mail.Text;
                    pb.direccion_proveedor = txt_direccion.Text;
                    pb.descripcion = txt_descripcion.Text;
                    pb.AlterProv(pb);
                    PopupNotifier popup = new PopupNotifier();
                    popup.TitleText = "Aviso";
                    popup.Image = Properties.Resources.add;
                    popup.ContentText = "Se ha Modificado al Proveedor: " + txt_nombre.Text;
                    popup.AnimationDuration = 500;
                    popup.Delay = 2500;
                    popup.Popup();
                    txt_id.Text = "";
                    txt_nombre.Text = "";
                    txt_fono.Text = "";
                    txt_direccion.Text = "";
                    txt_mail.Text = "";
                    txt_descripcion.Text = "";
                }
                else
                {
                    lb1.Content = "Esta id no existe en el sistema";
                }
            }

        }






        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Txt_id_GotFocus(object sender, RoutedEventArgs e)
        {
            lbid.Content = "";
        }

        private void Txt_nombre_GotFocus(object sender, RoutedEventArgs e)
        {
            lb1.Content = "";
        }

        private void Txt_fono_GotFocus(object sender, RoutedEventArgs e)
        {
            lb2.Content = "";
        }

        private void Txt_mail_GotFocus(object sender, RoutedEventArgs e)
        {
            lb3.Content = "";
        }

        private void Txt_direccion_GotFocus(object sender, RoutedEventArgs e)
        {
            lb4.Content = "";
        }

        private void Txt_descripcion_GotFocus(object sender, RoutedEventArgs e)
        {
            lb5.Content = "";
        }

        private void Dtg_provaux_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dtg_provaux.SelectedItem;
            if (item != null)
            {
                string rut = (dtg_provaux.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_id.Text = rut;
            }
            else
            {

            }
        }


        private void Win_modificarprov_Loaded(object sender, RoutedEventArgs e)
        {
            ProveedorBLL pb = new ProveedorBLL();
            DataTable dt = pb.Get_provaux();
            dtg_provaux.ItemsSource = dt.DefaultView;
        }


    }
}
