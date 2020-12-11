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
using restaurantexxi_adminstrador;
using MahApps.Metro.Controls;

namespace AplicacionBar
{
    /// <summary>
    /// Lógica de interacción para prueba4.xaml
    /// </summary>
    public partial class prueba4 : MetroWindow
    {
        public prueba4()
        {
            InitializeComponent();
        }

        private void btn_eli_Click(object sender, RoutedEventArgs e)
        {
            bool idid = true;
            Generic gen = new Generic();

            gen.ACCION.Content = "deshabilitar";
            gen.ACCION.Visibility = Visibility.Hidden;
            BebestibleBLL us = new BebestibleBLL();
            IngredienteBLL ig = new IngredienteBLL();

            if (txt_id_eli_bebi.Text == "" && txt_id_eli_ing.Text == "")
            {
                idid = false;
                lbl_1.Content = "El Debe selecionar una ID";
            }


            if (idid)
            {
                if (rbt_bebi.IsChecked == true)
                {
                    int idbebestible = Int32.Parse(txt_id_eli_bebi.Text);
                    try
                    {
                        DataTable da = us.listarmodificar(idbebestible);
                        DataRow row = da.Rows[0];
                        string id = row[0].ToString();
                        string Nombre = row[1].ToString();
                        gen.lb_titulo.FontSize = 18;
                        gen.lb_confirmacion.FontSize = 16;
                        gen.lb_contenido.FontSize = 16;
                        gen.lb_titulo.Content = "¿Desea deshabilitar este Bebestible?";
                        gen.lb_confirmacion.Content = "Al realizar esta accion, se deshabilitara el Bebestible:";
                        gen.lb_contenido.Content = "id : " + id + "\n" +
                                           "Nombre: " + Nombre;

                        gen.Title = "Confirmación";
                        gen.btn_Cancelar.Content = "Volver";
                        gen.btn_Confirmar.Content = "Deshabilitar";
                        gen.ACCION.Content = "Modificarbebi";
                        gen.lb_rut.Content = txt_id_eli_bebi.Text;
                        gen.Owner = this;
                        gen.ShowDialog();
                        BebestibleBLL ib = new BebestibleBLL();
                        System.Data.DataTable dt = ib.Allbebestible();
                        dtg_eli.ItemsSource = dt.DefaultView;
                    }

                    catch (Exception ex)

                    {
                        Console.WriteLine(ex);
                        MessageBox.Show("Este Bebestible no existe en el sistema");
                    }

                }
                else if (rbt_ing.IsChecked == true)
                {
                    int idingrediente = Int32.Parse(txt_id_eli_ing.Text);
                    try
                    {
                        int id = Int32.Parse(txt_id_eli_ing.Text);
                        DataTable da = ig.listarmodificar(idingrediente);
                        DataRow row = da.Rows[0];

                        string Nombre = row[0].ToString();
                        gen.lb_titulo.FontSize = 18;
                        gen.lb_confirmacion.FontSize = 16;
                        gen.lb_contenido.FontSize = 16;
                        gen.lb_titulo.Content = "¿Desea deshabilitar este Ingrediente?";
                        gen.lb_confirmacion.Content = "Al realizar esta accion, se deshabilitara el Ingrediente:";
                        gen.lb_contenido.Content = "id : " + id + "\n" +
                                           "Nombre: " + Nombre;

                        gen.Title = "Confirmación";
                        gen.btn_Cancelar.Content = "Volver";
                        gen.btn_Confirmar.Content = "Deshabilitar";
                        gen.ACCION.Content = "Modificaring";
                        gen.lb_rut.Content = txt_id_eli_ing.Text;
                        gen.Owner = this;
                        gen.ShowDialog();

                        IngredienteBLL ib = new IngredienteBLL();
                        System.Data.DataTable dt = ib.AllingredientesList();
                        dtg_eli.ItemsSource = dt.DefaultView;

                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        MessageBox.Show("Este Ingrediente no existe en el sistema");
                    }
                }

            }
        }

        private void rbt_ing_Checked(object sender, RoutedEventArgs e)
        {
            IngredienteBLL ib = new IngredienteBLL();
            System.Data.DataTable dt = ib.AllingredientesList();
            dtg_eli.ItemsSource = dt.DefaultView;
            txt_id_eli_ing.Visibility = Visibility.Visible;
            txt_id_eli_bebi.Visibility = Visibility.Hidden;
            txt_id_eli_ing.IsEnabled = true;
        }

        private void rbt_bebi_Checked(object sender, RoutedEventArgs e)
        {
            BebestibleBLL ib = new BebestibleBLL();
            System.Data.DataTable dt = ib.Allbebestible();
            dtg_eli.ItemsSource = dt.DefaultView;
            txt_id_eli_ing.Visibility = Visibility.Hidden;
            txt_id_eli_bebi.Visibility = Visibility.Visible;
            txt_id_eli_bebi.IsEnabled = true;
        }

        private void txt_id_eli_bebi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_id_eli_bebi.Text.Length;
            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 48 && ascii <= 57)
            {
                if (tamanio < 10)
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

        private void txt_id_eli_ing_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_id_eli_ing.Text.Length;
            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 48 && ascii <= 57)
            {
                if (tamanio < 10)
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

        private void Btn_atras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Dtg_eli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dtg_eli.SelectedItem;
            if (item != null)
            {

                if (rbt_ing.IsChecked == true)
                {
                    string rut = (dtg_eli.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    txt_id_eli_ing.Text = rut;
                }
                else if (rbt_bebi.IsChecked == true)
                {
                    string rut = (dtg_eli.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    txt_id_eli_bebi.Text = rut;
                }
            }
            else
            {

            }

        }
    }
}
