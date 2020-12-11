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

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para ListarReceta.xaml
    /// </summary>
    public partial class ListarReceta : MetroWindow
    {
        public ListarReceta()
        {
            InitializeComponent();
        }

        private void btnvolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void win_list_rec_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void btn_listar_Click(object sender, RoutedEventArgs e)
        {
            PlatoBLL ub = new PlatoBLL();
            System.Data.DataTable dt = ub.AllplatosList();
            dtg_rec.ItemsSource = dt.DefaultView;
            dtg_rec.Visibility = Visibility.Visible;
        }

        private void dtg_rece_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dtg_rec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id_plato = 0;
            try
            {
                PlatoBLL ub = new PlatoBLL();
                DataGrid gd = (DataGrid)sender;
                DataRowView drv = gd.SelectedItem as DataRowView;

                if (drv != null)
                {
                    id_plato = int.Parse(drv["ID"].ToString());

                }


                DataTable dte = new DataTable();

                dte = ub.platoRela(id_plato);
                dtg_rece_list.ItemsSource = dte.DefaultView;
                dtg_rece_list.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void txt_nom_rec_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            PlatoBLL ub = new PlatoBLL();
            string Nombre = (txt_nom_rec.Text);
            dtg_rec.Visibility = Visibility.Visible;
            System.Data.DataTable dt = ub.platoList(Nombre);
            dtg_rec.ItemsSource = dt.DefaultView;
        }
    }
}
