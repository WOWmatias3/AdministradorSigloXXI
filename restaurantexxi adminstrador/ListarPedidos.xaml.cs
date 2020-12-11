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
    /// Lógica de interacción para ListarPedidos.xaml
    /// </summary>
    public partial class ListarPedidos : MetroWindow
    {
        string tipoc="";
        string estadoc = "";
        string rangoc = "";
        DataTable dt = new DataTable();
        public ListarPedidos()
        {
            InitializeComponent();
        }

        private void Rdb_ingrediente_Checked(object sender, RoutedEventArgs e)
        {
            tipoc = "INGREDIENTE";
        }

        private void Rdb_bebestible_Checked(object sender, RoutedEventArgs e)
        {
            tipoc = "BEBESTIBLE";
        }

        private void Rdb_anulada_Checked(object sender, RoutedEventArgs e)
        {
            estadoc = "ANULADO";
        }

        private void Rdb_aceptadas_Checked(object sender, RoutedEventArgs e)
        {
            estadoc = "ACEPTADO";
        }

        private void Rdb_este_mes_Checked(object sender, RoutedEventArgs e)
        {
            rangoc = "MES";
        }

        private void Btn_listar_Click(object sender, RoutedEventArgs e)
        {
            bool estado = true;
            bool tipo = true;
            bool rango = true;
            PedidoBLL pb = new PedidoBLL();
            if (rdb_ingrediente.IsChecked == false && rdb_bebestible.IsChecked == false)
            {
                tipo = false;
            }

            if (rdb_aceptadas.IsChecked == false && rdb_anulada.IsChecked == false)
            {
                estado = false;
            }

            if (rdb_este_mes.IsChecked == false)
            {
                rango = false;
            }

            if (tipo)
            {

                if (tipo && estado == false && rango == false)
                {
                    estadoc = "TODOS";
                    rangoc = "TODO";
                    dt = pb.Master_pedido(tipoc, estadoc, rangoc);
                    dtg_listas.ItemsSource = dt.DefaultView;
                }
                else if (tipo && estado && rango == false)
                {
                    rangoc = "TODO";
                    dt = pb.Master_pedido(tipoc, estadoc, rangoc);
                    dtg_listas.ItemsSource = dt.DefaultView;
                }
                else if (tipo && estado && rango)
                {
                    dt = pb.Master_pedido(tipoc, estadoc, rangoc);
                    dtg_listas.ItemsSource = dt.DefaultView;
                }
            }
            else
            {
                lb1.Content = "Seleccione un tipo de pedido";
            }
        }

        private void Btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            rdb_aceptadas.IsChecked = false;
            rdb_anulada.IsChecked = false;
            rdb_ingrediente.IsChecked = false;
            rdb_bebestible.IsChecked = false;
            rdb_este_mes.IsChecked = false;
        }

        private void Btn_atras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
