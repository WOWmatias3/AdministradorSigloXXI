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
using MahApps.Metro.Controls;
using Tulpep.NotificationWindow;

namespace AplicacionBar
{
    /// <summary>
    /// Lógica de interacción para prueba3.xaml
    /// </summary>
    public partial class prueba3 : MetroWindow
    {
        public prueba3()
        {
            InitializeComponent();
        }

        private void Buscar_ID_Click(object sender, RoutedEventArgs e)
        {

            if (rbt_ing.IsChecked == true)
            {
                IngredienteBLL us = new IngredienteBLL();
                bool id = true;
                if (txt_id_alimento.Text == "")
                {
                    id = false;
                    lbl1.Content = "Debe ingresar una id";
                }

                if (id)
                {
                    int id_ingrediente = Int32.Parse(txt_id_alimento.Text);
                    try
                    {
                        DataTable da = us.listarmodificar(id_ingrediente);
                        DataRow row = da.Rows[0];
                        txt_nombre_ali.Text = row[0].ToString();
                        txt_proveedor.Text = row[1].ToString();
                        txt_stock_ali.Text = row[2].ToString();
                        txt_stock_coci_alimento.Text = row[3].ToString();
                        cmb_habili_ing.Text = row[4].ToString();
                        txt_stock_critico.Text = row[5].ToString();



                        txt_id_alimento.IsEnabled = true;
                        txt_nombre_ali.IsEnabled = true;
                        txt_stock_ali.IsEnabled = true;
                        txt_stock_coci_alimento.IsEnabled = true;
                        txt_proveedor.IsEnabled = true;
                        cmb_habili_ing.IsEnabled = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                }
            }
            else if (rbt_bebi.IsChecked == true)
            {
                BebestibleBLL us = new BebestibleBLL();
                if (txt_id_bebida.Text == "")
                {
                    MessageBox.Show("Debe ingresar un ID para poder buscar a un Insumo");
                }
                else if (txt_id_bebida.Text != "")
                {
                    int id_bebestible = Int32.Parse(txt_id_bebida.Text);
                    us.listarmodificar(id_bebestible);
                    try
                    {
                        DataTable da = us.listarmodificar(id_bebestible);
                        DataRow row = da.Rows[0];
                        txt_nombre_bebi.Text = row[1].ToString();
                        txt_proveedor.Text = row[2].ToString();
                        txt_precio_bebi.Text = row[3].ToString();
                        txt_stock_bebi.Text = row[4].ToString();
                        txt_stock_bar_bebi.Text = row[5].ToString();
                        cmb_habili_bebi.Text = row[6].ToString();
                        cmb_conpre_bebi.Text = row[7].ToString();
                        txt_stock_critico.Text = row[8].ToString();

                        txt_id_bebida.IsEnabled = true;
                        txt_nombre_bebi.IsEnabled = true;
                        txt_stock_bebi.IsEnabled = true;
                        txt_stock_bar_bebi.IsEnabled = true;
                        txt_precio_bebi.IsEnabled = true;
                        cmb_habili_bebi.IsEnabled = true;
                        txt_proveedor.IsEnabled = true;
                        cmb_conpre_bebi.IsEnabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Esta ID no existe en el sistema");
                    }
                }
            }

        }



        private void Modificar_id_Click(object sender, RoutedEventArgs e)
        {
            bool txtcampo1 = true;
            bool txtcampo2 = true;
            bool txtcampo3 = true;
            bool txtcampo4 = true;
            bool txtcampo5 = true;
            bool txtcampo6 = true;
            bool txtcampo7 = true;
            bool txtcampo8 = true;
            bool scv = true;

            if (rbt_ing.IsChecked == true)
            {
                if (txt_id_bebida.Text.Trim() == "" && txt_id_alimento.Text.Trim() == "")
                {
                    txtcampo1 = false;
                    lbl1.Content = "Debe Completar el campo";
                }

                if (txt_stock_critico.Text == "")
                {
                    scv = false;
                    lb_stock_critico.Content = "Complete el campo";

                }

                if (txt_nombre_ali.Text.Trim() == "" && txt_nombre_bebi.Text.Trim() == "")
                {
                    txtcampo2 = false;
                    lbl2.Content = "Debe Completar el campo";
                }

                if (txt_stock_ali.Text.Trim() == "" && txt_stock_bebi.Text.Trim() == "")
                {
                    txtcampo3 = false;
                    lbl3.Content = "Debe Completar el campo";
                }

                if (txt_stock_coci_alimento.Text.Trim() == "" && txt_stock_bar_bebi.Text.Trim() == "")
                {
                    txtcampo4 = false;
                    lbl4.Content = "Debe Completar el campo";
                }

                if (txt_proveedor.Text.Trim() == "" && txt_marca_bebi.Text.Trim() == "")
                {
                    txtcampo5 = false;
                    lbl5.Content = "Debe Completar el campo";
                }

                if (txt_precio_bebi.Text.Trim() == "" && cmb_habili_ing.Text.Trim() == "")
                {
                    txtcampo6 = false;
                    lbl6.Content = "Debe Completar el campo";
                }

                if (txtcampo1 && txtcampo2 && txtcampo3 && txtcampo4 && txtcampo5 && txtcampo6)

                {
                    IngredienteBLL ub = new IngredienteBLL();
                    ub.id_ingrediente = Int32.Parse(txt_id_alimento.Text);
                    ub.nombre_ingrediente = txt_nombre_ali.Text;
                    ub.proveedor = txt_proveedor.Text;
                    ub.habilitado = cmb_habili_ing.Text;
                    ub.stock = Int32.Parse(txt_stock_ali.Text);
                    ub.stock_cocina = Int32.Parse(txt_stock_coci_alimento.Text);
                    ub.stock_critico = Int32.Parse(txt_stock_critico.Text);
                    ub.AlterinIngrediente(ub);


                    System.Data.DataTable dt = ub.AllingredientesList();

                    dtg_modi.ItemsSource = dt.DefaultView;



                    PopupNotifier popup = new PopupNotifier();
                    popup.TitleText = "Aviso";
                    popup.Image = restaurantexxi_adminstrador.Properties.Resources.add;
                    popup.ContentText = "Se ha modificado el Ingrediente: " + txt_nombre_ali.Text;
                    popup.AnimationDuration = 800;
                    popup.Delay = 1700;
                    popup.Popup();

                    IngredienteBLL ib = new IngredienteBLL();
                    System.Data.DataTable dtt = ib.AllingredientesList();
                    dtg_modi.ItemsSource = dtt.DefaultView;

                }

            }
            else if (rbt_bebi.IsChecked == true)
            {
                if (txt_id_bebida.Text.Trim() == "" && txt_id_alimento.Text.Trim() == "")
                {
                    txtcampo1 = false;
                    lbl1.Content = "Debe Completar el campo";
                }

                if (txt_nombre_ali.Text.Trim() == "" && txt_nombre_bebi.Text.Trim() == "")
                {
                    txtcampo2 = false;
                    lbl2.Content = "Debe Completar el campo";
                }

                if (txt_stock_ali.Text.Trim() == "" && txt_stock_bebi.Text.Trim() == "")
                {
                    txtcampo3 = false;
                    lbl3.Content = "Debe Completar el campo";
                }

                if (txt_stock_critico.Text == "")
                {
                    scv = false;
                    lb_stock_critico.Content = "Complete el campo";

                }

                if (txt_stock_coci_alimento.Text.Trim() == "" && txt_stock_bar_bebi.Text.Trim() == "")
                {
                    txtcampo4 = false;
                    lbl4.Content = "Debe Completar el campo";
                }

                if (txt_proveedor.Text.Trim() == "" && txt_marca_bebi.Text.Trim() == "")
                {
                    txtcampo5 = false;
                    lbl5.Content = "Debe Completar el campo";
                }

                if (txt_precio_bebi.Text.Trim() == "" && cmb_habili_ing.Text.Trim() == "")
                {
                    txtcampo6 = false;
                    lbl6.Content = "Debe Completar el campo";
                }

                if (cmb_habili_bebi.Text.Trim() == "")
                {
                    txtcampo7 = false;
                    lbl7.Content = "Debe Completar el campo";
                }

                if (cmb_conpre_bebi.Text.Trim() == "")
                {
                    txtcampo8 = false;
                    lbl8.Content = "Debe Completar el campo";
                }

                if (txtcampo1 && txtcampo2 && txtcampo3 && txtcampo4 && txtcampo5 && txtcampo6 && txtcampo7 && txtcampo8)
                {
                    BebestibleBLL ub = new BebestibleBLL();
                    ub.id_bebestible = Int32.Parse(txt_id_bebida.Text);
                    ub.nombre_beb = txt_nombre_bebi.Text;
                    ub.marca = txt_proveedor.Text;
                    ub.precio = Int32.Parse(txt_precio_bebi.Text);
                    ub.stock = Int32.Parse(txt_stock_bebi.Text);
                    ub.stock_bar = Int32.Parse(txt_stock_bar_bebi.Text);
                    ub.stock_critico = Int32.Parse(txt_stock_critico.Text);
                    ub.habilitado = cmb_habili_bebi.Text;
                    ub.con_prep = cmb_conpre_bebi.Text;

                    ub.AlterinBebestible(ub);


                    System.Data.DataTable dt = ub.Allbebestible();
                    dtg_modi.ItemsSource = dt.DefaultView;
                    PopupNotifier popup = new PopupNotifier();
                    popup.TitleText = "Aviso";
                    popup.Image = restaurantexxi_adminstrador.Properties.Resources.add;
                    popup.ContentText = "Se ha modificado el bebestible: " + txt_nombre_bebi.Text;
                    popup.AnimationDuration = 800;
                    popup.Delay = 1700;
                    popup.Popup();

                    BebestibleBLL ib = new BebestibleBLL();
                    System.Data.DataTable dtt = ib.Allbebestible();
                    dtg_modi.ItemsSource = dtt.DefaultView;
                }
            }
        }


        private void rbt_ing_Checked(object sender, RoutedEventArgs e)
        {

            txt_id_alimento.Visibility = Visibility.Visible;
            txt_nombre_ali.Visibility = Visibility.Visible;
            txt_stock_ali.Visibility = Visibility.Visible;
            txt_stock_coci_alimento.Visibility = Visibility.Visible;
            txt_proveedor.Visibility = Visibility.Visible;
            cmb_habili_ing.Visibility = Visibility.Visible;
            txt_proveedor.SelectedIndex = -1;

            lbl_iding.Visibility = Visibility.Visible;
            lbl_insumo_alimento.Visibility = Visibility.Visible;
            lbl_stock_alimento.Visibility = Visibility.Visible;
            lbl_stock_coci_alimento.Visibility = Visibility.Visible;
            lbl_alimento.Visibility = Visibility.Visible;
            lbl_habili_ing.Visibility = Visibility.Visible;
            lb_stock_critico.Visibility = Visibility.Visible;
            txt_stock_critico.Visibility = Visibility.Visible;
            Buscar_ID.Visibility = Visibility.Visible;
            dtg_modi.Visibility = Visibility.Visible;

            lbl_idbebi.Visibility = Visibility.Hidden;
            lbl_insumo_bebi.Visibility = Visibility.Hidden;
            lbl_stock_bebi.Visibility = Visibility.Hidden;
            lbl_stock_coci_bebi.Visibility = Visibility.Hidden;
            lbl_marca_bebi.Visibility = Visibility.Hidden;
            lbl_precio_bebi.Visibility = Visibility.Hidden;
            lbl_habili_bebi.Visibility = Visibility.Hidden;
            lbl_conpre_bebi.Visibility = Visibility.Hidden;

            txt_id_bebida.Visibility = Visibility.Hidden;
            txt_nombre_bebi.Visibility = Visibility.Hidden;
            txt_stock_bebi.Visibility = Visibility.Hidden;
            txt_stock_bar_bebi.Visibility = Visibility.Hidden;
            txt_marca_bebi.Visibility = Visibility.Hidden;
            txt_precio_bebi.Visibility = Visibility.Hidden;
            cmb_habili_bebi.Visibility = Visibility.Hidden;
            cmb_conpre_bebi.Visibility = Visibility.Hidden;

            Modificar_id.IsEnabled = true;

            lbl1.Content = "";
            lbl2.Content = "";
            lbl3.Content = "";
            lbl4.Content = "";
            lbl5.Content = "";
            lbl6.Content = "";
            lbl7.Content = "";
            lbl8.Content = "";

            txt_id_bebida.Clear();
            txt_nombre_bebi.Clear();
            txt_stock_bebi.Clear();
            txt_stock_bar_bebi.Clear();
            txt_marca_bebi.Clear();
            txt_precio_bebi.Clear();
            cmb_habili_bebi.SelectedIndex = -1;
            cmb_conpre_bebi.SelectedIndex = -1;

            IngredienteBLL ib = new IngredienteBLL();
            System.Data.DataTable dt = ib.AllingredientesList();
            dtg_modi.ItemsSource = dt.DefaultView;
        }

        private void rbt_bebi_Checked(object sender, RoutedEventArgs e)
        {


            txt_id_alimento.Visibility = Visibility.Hidden;
            txt_nombre_ali.Visibility = Visibility.Hidden;
            txt_stock_ali.Visibility = Visibility.Hidden;
            txt_stock_coci_alimento.Visibility = Visibility.Hidden;
            txt_proveedor.Visibility = Visibility.Visible;
            cmb_habili_ing.Visibility = Visibility.Hidden;

            Buscar_ID.Visibility = Visibility.Visible;
            dtg_modi.Visibility = Visibility.Visible;

            lbl_iding.Visibility = Visibility.Hidden;
            lbl_insumo_alimento.Visibility = Visibility.Hidden;
            lbl_stock_alimento.Visibility = Visibility.Hidden;
            lbl_stock_coci_alimento.Visibility = Visibility.Hidden;
            lbl_alimento.Visibility = Visibility.Visible;
            lbl_habili_ing.Visibility = Visibility.Hidden;
            lbl_marca_bebi.Visibility = Visibility.Hidden;



            lbl_idbebi.Visibility = Visibility.Visible;
            lbl_insumo_bebi.Visibility = Visibility.Visible;
            lbl_stock_bebi.Visibility = Visibility.Visible;
            lbl_stock_coci_bebi.Visibility = Visibility.Visible;
            lbl_marca_bebi.Visibility = Visibility.Hidden;
            lbl_precio_bebi.Visibility = Visibility.Visible;
            lbl_habili_bebi.Visibility = Visibility.Visible;
            lbl_conpre_bebi.Visibility = Visibility.Visible;
            lb_stock_critico.Visibility = Visibility.Visible;
            txt_stock_critico.Visibility = Visibility.Visible;



            txt_id_bebida.Visibility = Visibility.Visible;
            txt_nombre_bebi.Visibility = Visibility.Visible;
            txt_stock_bebi.Visibility = Visibility.Visible;
            txt_stock_bar_bebi.Visibility = Visibility.Visible;
            txt_marca_bebi.Visibility = Visibility.Hidden;
            txt_precio_bebi.Visibility = Visibility.Visible;
            cmb_habili_bebi.Visibility = Visibility.Visible;
            cmb_conpre_bebi.Visibility = Visibility.Visible;
            txt_proveedor.SelectedIndex = -1;

            Modificar_id.IsEnabled = true;

            lbl1.Content = "";
            lbl2.Content = "";
            lbl3.Content = "";
            lbl4.Content = "";
            lbl5.Content = "";
            lbl6.Content = "";

            txt_id_alimento.Clear();
            txt_nombre_ali.Clear();
            txt_stock_ali.Clear();
            txt_stock_coci_alimento.Clear();
            txt_proveedor.SelectedIndex = -1;
            cmb_habili_ing.SelectedIndex = -1;

            BebestibleBLL ib = new BebestibleBLL();
            System.Data.DataTable dt = ib.Allbebestible();
            dtg_modi.ItemsSource = dt.DefaultView;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProveedorBLL ingBLL = new ProveedorBLL();
            DataTable dt = ingBLL.getallBebi();
            txt_proveedor.ItemsSource = dt.DefaultView;

            txt_proveedor.DisplayMemberPath = "NOMBRE_PROVEEDOR";
            txt_proveedor.SelectedValuePath = "ID_PROVEEDOR";
        }

        private void txt_id_bebida_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_id_bebida.Text.Length;
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

        private void txt_id_alimento_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_id_alimento.Text.Length;
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

        private void txt_nombre_bebi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_nombre_bebi.Text.Length;
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
        }

        private void txt_nombre_ali_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_nombre_ali.Text.Length;
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
        }

        private void txt_stock_bebi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_stock_bebi.Text.Length;
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

        private void txt_stock_ali_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_stock_ali.Text.Length;
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

        private void txt_stock_coci_alimento_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_stock_coci_alimento.Text.Length;
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

        private void txt_stock_bar_bebi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_stock_bar_bebi.Text.Length;
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

        private void txt_marca_bebi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_marca_bebi.Text.Length;
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
        }

        private void txt_precio_bebi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_precio_bebi.Text.Length;
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

        private void txt_id_bebida_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl1.Content = "";
        }

        private void txt_id_alimento_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl1.Content = "";
        }

        private void txt_nombre_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl2.Content = "";
        }

        private void txt_nombre_ali_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl2.Content = "";
        }

        private void txt_stock_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl3.Content = "";
        }

        private void txt_stock_ali_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl3.Content = "";
        }

        private void txt_stock_coci_alimento_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl4.Content = "";
        }

        private void txt_stock_bar_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl4.Content = "";
        }

        private void txt_marca_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl5.Content = "";
        }

        private void txt_proveedor_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl5.Content = "";
        }

        private void txt_precio_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl6.Content = "";
        }

        private void cmb_habili_ing_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl6.Content = "";
        }

        private void cmb_habili_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl7.Content = "";
        }

        private void cmb_conpre_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl8.Content = "";
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
