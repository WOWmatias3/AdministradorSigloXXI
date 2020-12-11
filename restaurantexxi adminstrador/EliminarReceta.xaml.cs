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
    /// Lógica de interacción para EliminarReceta.xaml
    /// </summary>
    public partial class EliminarReceta : MetroWindow
    {
        public EliminarReceta()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            bool idre = true;
            Generic gen = new Generic();

            gen.ACCION.Content = "deshabilitar";
            gen.ACCION.Visibility = Visibility.Hidden;
            PlatoBLL us = new PlatoBLL();
            if (txt_id_receta.Text.Trim() == "")
            {
                idre = false;
                lbl1.Content = "Debe ingresar una ID";
            }
            if (idre)
            {


                int idplato = Int32.Parse(txt_id_receta.Text);
                try
                {

                    DataTable da = us.DatosDesPlato(idplato);
                    DataRow row = da.Rows[0];
                    string id = row[0].ToString();
                    string Nombre = row[1].ToString();
                    gen.lb_titulo.FontSize = 18;
                    gen.lb_confirmacion.FontSize = 16;
                    gen.lb_contenido.FontSize = 16;
                    gen.lb_titulo.Content = "¿Desea deshabilitar este plato?";
                    gen.lb_confirmacion.Content = "Al realizar esta accion, se deshabilitara el plato:";
                    gen.lb_contenido.Content = "id : " + id + "\n" +
                                               "Nombre: " + Nombre;

                    gen.Title = "Confirmación";
                    gen.btn_Cancelar.Content = "Volver";
                    gen.btn_Confirmar.Content = "Deshabilitar";
                    gen.lb_rut.Content = txt_id_receta.Text;
                    gen.Owner = this;
                    gen.ShowDialog();
                    PlatoBLL pb = new PlatoBLL();
                    dtg_receta.ItemsSource = pb.AllplatosList().DefaultView;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Este plato no existe en el sistema");
                    MessageBox.Show("" + ex);
                }
            }


        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PlatoBLL pb = new PlatoBLL();
            dtg_receta.ItemsSource = pb.AllplatosList().DefaultView;
        }

        private void dtg_receta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dtg_receta.SelectedItem; //probably you find this object
            if (item != null)
            {
                string rut = (dtg_receta.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_id_receta.Text = rut;
            }
            else
            {
            }
        }

        private void txt_id_receta_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl1.Content = "";
        }

        private void Txt_id_receta_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_id_receta.Text.Length;

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
