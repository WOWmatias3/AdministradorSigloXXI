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

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para ListarMesas.xaml
    /// </summary>
    public partial class ListarMesas : MetroWindow
    {
        public ListarMesas()
        {
            InitializeComponent();
        }

        private void Rdb_num_Checked(object sender, RoutedEventArgs e)
        {
            if (rdb_num.IsChecked == true)
            {
                txt_num.Visibility = Visibility.Visible;
                cbb_sala.Visibility = Visibility.Hidden;
                btn_buscar.Visibility = Visibility.Visible;
                lb1.Content = "";
            }
            else
            {

            }
        }

        private void Rdb_sala_Checked(object sender, RoutedEventArgs e)
        {
            if (rdb_sala.IsChecked == true)
            {
                txt_num.Visibility = Visibility.Hidden;
                cbb_sala.Visibility = Visibility.Visible;
                btn_buscar.Visibility = Visibility.Visible;
                lb1.Content = "";
            }
            else
            {

            }
        }





        private void Btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            MesaBLL mb = new MesaBLL();
            if (rdb_num.IsChecked == true)
            {
                bool num = true;
                if (txt_num.Text.Trim() == "")
                {
                    lb1.Content = "Ingrese un numero para filtrar";
                    num = false;
                }
                if (num == true)
                {
                    int nume = Int32.Parse(txt_num.Text);
                    bool existe = mb.Get_nume(nume);
                    if (existe == true)
                    {
                        DataTable dt = mb.GetmesaNum(nume);
                        dtg_mesas.ItemsSource = dt.DefaultView;
                    }
                    else
                    {
                        lb1.Content = "Esta mesa no existe";
                    }

                }
            }
            else if (rdb_sala.IsChecked == true)
            {
                string sala = "";
                bool sal = true;
                if (ComedorPrincipal.IsSelected || Terraza.IsSelected || Terraza2.IsSelected)
                {
                    sal = true;
                }
                else
                {
                    sal = false;
                }
                if (sal == true)
                {
                    if (ComedorPrincipal.IsSelected)
                    {
                        sala = "Comedor Principal";
                    }
                    else if (Terraza.IsSelected)
                    {
                        sala = "Terraza";
                    }
                    else if (Terraza2.IsSelected)
                    {
                        sala = "Terraza 2";
                    }
                    DataTable dt = mb.Getmesasala(sala);
                    dtg_mesas.ItemsSource = dt.DefaultView;

                }
                else
                {
                    lb1.Content = "Debe ingresar una sala para filtrar";
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Rdb_todas(object sender, RoutedEventArgs e)
        {

            if (rdb_todas.IsChecked == true)
            {
                MesaBLL mb = new MesaBLL();
                txt_num.Visibility = Visibility.Hidden;
                cbb_sala.Visibility = Visibility.Hidden;
                btn_buscar.Visibility = Visibility.Hidden;
                DataTable dt = mb.GetAllmesas();
                dtg_mesas.ItemsSource = dt.DefaultView;
            }
            else
            {

            }
        }

        private void Btn_buscar_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_buscar_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lb1.Content = "";
        }
    }
}
