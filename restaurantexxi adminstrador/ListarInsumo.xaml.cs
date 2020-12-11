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

namespace AplicacionBar
{
    /// <summary>
    /// Lógica de interacción para prueba2.xaml
    /// </summary>
    public partial class prueba2 : MetroWindow
    {
        public prueba2()
        {
            InitializeComponent();
        }

        private void rbt_ing_Checked(object sender, RoutedEventArgs e)
        {
            IngredienteBLL ib = new IngredienteBLL();
            System.Data.DataTable dt = ib.AllingredientesList();
            dtg_ingredientes.ItemsSource = dt.DefaultView;

            txt_buscar_bebi.Visibility = Visibility.Hidden;
            txt_buscar_ing.Visibility = Visibility.Visible;
            txt_buscar_ing.IsEnabled = true;
        }

        private void rbt_bebi_Checked(object sender, RoutedEventArgs e)
        {
            BebestibleBLL ib = new BebestibleBLL();
            System.Data.DataTable dt = ib.Allbebestible();
            dtg_ingredientes.ItemsSource = dt.DefaultView;

            txt_buscar_ing.Visibility = Visibility.Hidden;
            txt_buscar_bebi.Visibility = Visibility.Visible;
            txt_buscar_bebi.IsEnabled = true;
        }

        private void btn_listar_ingrediente_Click(object sender, RoutedEventArgs e)
        {
            if (rbt_ing.IsChecked == true)
            {
                IngredienteBLL ib = new IngredienteBLL();
                System.Data.DataTable dt = ib.AllingredientesList();
                dtg_ingredientes.ItemsSource = dt.DefaultView;
            }
            else if (rbt_bebi.IsChecked == true)
            {
                BebestibleBLL ib = new BebestibleBLL();
                System.Data.DataTable dt = ib.Allbebestible();
                dtg_ingredientes.ItemsSource = dt.DefaultView;
            }
        }


        private void txt_buscar_ing_PreviewTextInput(object sender, TextCompositionEventArgs e)

        {
            int tamanio = txt_buscar_ing.Text.Length;
            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 65 && ascii <= 90 || ascii >= 97 && ascii <= 122)
            {
                if (tamanio < 100)
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

            {
                IngredienteBLL ib = new IngredienteBLL();
                string nombre_ingrediente = txt_buscar_ing.Text;
                System.Data.DataTable dt = ib.NombreIngredienteList(nombre_ingrediente);
                dtg_ingredientes.ItemsSource = dt.DefaultView;
            }
        }



        private void txt_buscar_bebi_PreviewTextInput(object sender, TextCompositionEventArgs e)

        {
            int tamanio = txt_buscar_bebi.Text.Length;
            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 65 && ascii <= 90 || ascii >= 97 && ascii <= 122)
            {
                if (tamanio < 100)
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
            {
                BebestibleBLL ib = new BebestibleBLL();
                string nombre_beb = txt_buscar_bebi.Text;
                System.Data.DataTable dt = ib.NombreBebestibleList(nombre_beb);
                dtg_ingredientes.ItemsSource = dt.DefaultView;
            }

        }

        private void Btn_atras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
