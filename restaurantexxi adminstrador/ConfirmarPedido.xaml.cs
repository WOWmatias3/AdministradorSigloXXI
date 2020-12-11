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
    /// Lógica de interacción para ConfirmarPedido.xaml
    /// </summary>
    public partial class ConfirmarPedido : MetroWindow
    {
        int id_pedido_aux = 0;
        public ConfirmarPedido()
        {
            InitializeComponent();

        }

        private void Rdb_todos_Checked(object sender, RoutedEventArgs e)
        {


            PedidoBLL pb = new PedidoBLL();
            DataTable dt = pb.Get_all_pedidos();

            dtg_pedidos.ItemsSource = dt.DefaultView;
        }

        private void Rdb_todos_hoy_Checked(object sender, RoutedEventArgs e)
        {
            PedidoBLL pb = new PedidoBLL();
            DataTable dt = pb.Get_all_pedidos_hoy();
            dtg_pedidos.ItemsSource = dt.DefaultView;
        }

        private void Rdb_todos_senana_Checked(object sender, RoutedEventArgs e)
        {
            PedidoBLL pb = new PedidoBLL();
            DataTable dt = pb.Get_all_pedidos_semana();
            dtg_pedidos.ItemsSource = dt.DefaultView;
        }

        private void Rdb_todos_mes_Checked(object sender, RoutedEventArgs e)
        {
            PedidoBLL pb = new PedidoBLL();
            DataTable dt = pb.Get_all_pedidos_mes();
            dtg_pedidos.ItemsSource = dt.DefaultView;
        }

        private void Dtg_pedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                PedidoBLL pb = new PedidoBLL();
                DataTable dt = new DataTable();

                object item = dtg_pedidos.SelectedItem;
                if (item != null)
                {
                    int id = Int32.Parse((dtg_pedidos.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    id_pedido_aux = id;
                    string tipo_pedido = pb.Get_tipo_pedido(id);
                    if (tipo_pedido == "Pedido de bebestibles")
                    {
                        dt = pb.Get_detaPediById_bebestible(id);
                        dtg_detalle.ItemsSource = dt.DefaultView;
                    }
                    else if (tipo_pedido == "Pedido de ingredientes")
                    {
                        dt = pb.Get_detPediById_ingredientes(id);
                        dtg_detalle.ItemsSource = dt.DefaultView;
                    }
                }
                else
                {

                }
            }
            catch
            {

            }
        }

        private void Dtg_detalle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                object item = dtg_detalle.SelectedItem;
                if (item != null)
                {
                    string id = (dtg_detalle.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string nombre_insumo = (dtg_detalle.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    string cantidad = (dtg_detalle.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    string nombre_proveedor = (dtg_detalle.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                    string stock = (dtg_detalle.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                    string stock_cocina = (dtg_detalle.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                    string stock_total = (dtg_detalle.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                    string stockcritico = (dtg_detalle.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                    string monto = (dtg_detalle.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
                    string estado = (dtg_detalle.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;

                    txt_id_pedido.Text = id;
                    txt_nombreInsumo.Text = nombre_insumo;
                    txt_cant.Text = cantidad;
                    cbb_proveedor.Text = nombre_proveedor;
                    txt_stock_bodega.Text = stock;
                    txt_stockcocina_bar.Text = stock_cocina;
                    txt_stock_total.Text = stock_total;
                    txt_stock_critico.Text = stockcritico;
                    txt_monto.Text = monto;
                    txt_estado.Text = estado;

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void Win_aceptar_pedido_Loaded(object sender, RoutedEventArgs e)
        {
            ProveedorBLL ingBLL = new ProveedorBLL();
            DataTable dt = ingBLL.Getallprovcbb();
            cbb_proveedor.ItemsSource = dt.DefaultView;

            cbb_proveedor.DisplayMemberPath = "NOMBRE_PROVEEDOR";
            cbb_proveedor.SelectedValuePath = "ID_PROVEEDOR";
        }

        private void Btn_Aceptar_pedido_Click(object sender, RoutedEventArgs e)
        {

            bool cantidad = true;
            bool id_prov = true;
            bool monto_total = true;


            if (txt_cant.Text.Trim() == "")
            {
                cantidad = false;
                lb1.Content = "Debe ingresar una cantidad";
            }

            if (cbb_proveedor.SelectedIndex == -1)
            {
                id_prov = false;
                lb2.Content = "Debe seleccionar un proveedor";
            }

            if (txt_monto.Text.Trim() == "")
            {
                monto_total = false;
                lb3.Content = "Ingrese un monto";
            }

            if (cantidad && id_prov && monto_total)
            {
                PedidoBLL pb = new PedidoBLL();
                BebestibleBLL bb = new BebestibleBLL();
                IngredienteBLL ib = new IngredienteBLL();
                DataTable dt = new DataTable();
                int id_pedido = Int32.Parse(txt_id_pedido.Text);
                int monto = Int32.Parse(txt_monto.Text);
                int id_provee = Int32.Parse(cbb_proveedor.SelectedValue.ToString());
                string ni = txt_nombreInsumo.Text;
                string tipo = pb.Get_tipo_pedido(id_pedido);
                int idinsumo = -1;
                if (tipo == "Pedido de ingredientes")
                {
                    idinsumo = ib.Get_idbynom(ni);
                }
                else if (tipo == "Pedido de bebestibles")
                {
                    idinsumo = bb.Get_bebyid(ni);
                }
                int canti = Int32.Parse(txt_cant.Text);
                pb.Alter_detalle_pedido(canti, id_provee, monto, idinsumo, id_pedido);
                pb.Alter_montototalporboleta(id_pedido);
                txt_id_pedido.Text = "";
                txt_cant.Text = "";
                txt_monto.Text = "";
                txt_nombreInsumo.Text = "";
                txt_stockcocina_bar.Text = "";
                txt_stock_bodega.Text = "";
                txt_stock_critico.Text = "";
                txt_stock_total.Text = "";
                if (rdb_todos.IsChecked == true)
                {
                    DataTable dtt = pb.Get_all_pedidos();
                    dtg_pedidos.ItemsSource = dtt.DefaultView;
                }
                else if (rdb_todos_hoy.IsChecked == true)
                {
                    DataTable dth = pb.Get_all_pedidos_hoy();
                    dtg_pedidos.ItemsSource = dth.DefaultView;
                }
                else if (rdb_todos_senana.IsChecked == true)
                {
                    
                    DataTable dts = pb.Get_all_pedidos_semana();
                    dtg_pedidos.ItemsSource = dts.DefaultView;

                }
                else if (rdb_todos_mes.IsChecked == true)
                {
                   
                    DataTable dtm = pb.Get_all_pedidos_mes();
                    dtg_pedidos.ItemsSource = dtm.DefaultView;
                }
                //cbb_proveedor.SelectedIndex = -1;

                if (tipo == "Pedido de bebestibles")
                {
                    dt = pb.Get_detaPediById_bebestible(id_pedido);
                    dtg_detalle.ItemsSource = dt.DefaultView;
                }
                else if (tipo == "Pedido de ingredientes")
                {
                    dt = pb.Get_detPediById_ingredientes(id_pedido);
                    dtg_detalle.ItemsSource = dt.DefaultView;
                }
            }

        }

        private void Btn_anular_Click(object sender, RoutedEventArgs e)
        {
            PedidoBLL pb = new PedidoBLL();
            IngredienteBLL ib = new IngredienteBLL();
            BebestibleBLL bb = new BebestibleBLL();
            DataTable dt = new DataTable();

            int id_pe = Int32.Parse(txt_id_pedido.Text);

            string tipo = pb.Get_tipo_pedido(id_pe);
            string ni = txt_nombreInsumo.Text;
            int idinsumo = -1;
            if (tipo == "Pedido de ingredientes")
            {
                idinsumo = ib.Get_idbynom(ni);
            }
            else if (tipo == "Pedido de bebestibles")
            {
                idinsumo = bb.Get_bebyid(ni);
            }
            pb.Anularpedido(id_pe, idinsumo);
            txt_id_pedido.Text = "";
            txt_cant.Text = "";
            txt_monto.Text = "";
            txt_nombreInsumo.Text = "";
            txt_stockcocina_bar.Text = "";
            txt_stock_bodega.Text = "";
            txt_stock_critico.Text = "";
            txt_stock_total.Text = "";
            cbb_proveedor.SelectedIndex = -1;

            if (tipo == "Pedido de bebestibles")
            {
                dt = pb.Get_detaPediById_bebestible(id_pe);
                dtg_detalle.ItemsSource = dt.DefaultView;
            }
            else if (tipo == "Pedido de ingredientes")
            {
                dt = pb.Get_detPediById_ingredientes(id_pe);
                dtg_detalle.ItemsSource = dt.DefaultView;
            }
        }

        private void Btn_atras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
