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

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para ListarProveedor.xaml
    /// </summary>
    public partial class ListarProveedor : MetroWindow
    {
        public ListarProveedor()
        {
            InitializeComponent();
        }

        private void Btn_listar_Click(object sender, RoutedEventArgs e)
        {
            ProveedorBLL pb = new ProveedorBLL();
            string nombre = txt_Nombreprov.Text;

            bool nom = true;
            if (txt_Nombreprov.Text.Trim() == "")
            {
                nom = false;
                lb1.Content = "Ingrese un nombre";
            }

            if (nom)
            {
                bool existe = pb.Get_provnomexiste(txt_Nombreprov.Text);
                if (existe)
                {
                    System.Data.DataTable dt = pb.Get_provnom(nombre);
                    dtg_proveedores.ItemsSource = dt.DefaultView;
                    int rows = dtg_proveedores.Items.Count;
                    txt_Nombreprov.Text = "";
                }

                else
                {
                    lb1.Content = "El nombre de proveedor no existe";
                }
            }
        }

        private void Btn_listar_todos_Click(object sender, RoutedEventArgs e)
        {
            ProveedorBLL pb = new ProveedorBLL();
            System.Data.DataTable dt = pb.Getallprov();
            dtg_proveedores.ItemsSource = dt.DefaultView;
            txt_Nombreprov.Text = "";
            lb1.Content = "";
        }

        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Txt_Nombreprov_GotFocus(object sender, RoutedEventArgs e)
        {
            lb1.Content = "";
        }
    }
}
