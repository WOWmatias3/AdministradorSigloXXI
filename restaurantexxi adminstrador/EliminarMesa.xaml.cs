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
    /// Lógica de interacción para EliminarMesa.xaml
    /// </summary>
    public partial class EliminarMesa : MetroWindow
    {
        public EliminarMesa()
        {
            InitializeComponent();
        }



        private void Btn_deletemesa_Click(object sender, RoutedEventArgs e)
        {
            Generic gen = new Generic();
            MesaBLL mb = new MesaBLL();
            if (txt_numeromesa.Text.Trim() == "")
            {
                lb1.Content = "Debe seleccionar un numero de mesa";
            }
            else
            {
                DataTable da = mb.GetmesaNum(Int32.Parse(txt_numeromesa.Text));
                DataRow row = da.Rows[0];
                string rutt = row[0].ToString();
                gen.ACCION.Content = "deletemesa";
                gen.ACCION.Visibility = Visibility.Hidden;
                gen.lb_titulo.FontSize = 18;
                gen.lb_confirmacion.FontSize = 16;
                gen.lb_contenido.FontSize = 16;
                gen.lb_titulo.Content = "¿Desea eliminar esta mesa?";
                gen.lb_confirmacion.Content = "Al realizar esta accion, se eliminará la mesa:";
                gen.lb_contenido.Content = "Número : " + rutt;
                gen.Title = "Confirmación";
                gen.btn_Cancelar.Content = "Volver";
                gen.btn_Confirmar.Content = "Eliminar";
                gen.lb_rut.Content = txt_numeromesa.Text;
                gen.Owner = this;
                gen.ShowDialog();
                DataTable dt = mb.GetAllmesas();
                dtg_mesadelete.ItemsSource = dt.DefaultView;

            }
        }

        private void Windeletemesa_Loaded(object sender, RoutedEventArgs e)
        {
            MesaBLL mb = new MesaBLL();
            DataTable dt = mb.GetAllmesas();
            dtg_mesadelete.ItemsSource = dt.DefaultView;
        }

        private void Txt_numeromesa_GotFocus(object sender, RoutedEventArgs e)
        {
            lb1.Content = "";
        }

        private void Dtg_mesadelete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView item = (dtg_mesadelete as DataGrid).SelectedItem as DataRowView;
                txt_numeromesa.Text = item.Row.ItemArray[0].ToString();
            }
            catch
            {

            }

        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
