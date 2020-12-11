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
using System.Diagnostics;
using System.IO;
using MahApps.Metro.Controls;
using Tulpep.NotificationWindow;

namespace AplicacionBar
{
    /// <summary>
    /// Lógica de interacción para pruebas.xaml
    /// </summary>
    public partial class pruebas : MetroWindow
    {
        byte[] imageBt = null;

        public pruebas()
        {
            InitializeComponent();
        }

        private void rbt_bebestibles_Checked(object sender, RoutedEventArgs e)
        {

            txt_insumo_alimento.Focus();
            txt_habili_ingre.Visibility = Visibility.Hidden;
            txt_insumo_alimento.Visibility = Visibility.Hidden;
            txt_stock_alimento.Visibility = Visibility.Hidden;
            txt_stock_coci_alimento.Visibility = Visibility.Hidden;
            lbl_insumo_alimento.Visibility = Visibility.Hidden;
            lbl_stock_alimento.Visibility = Visibility.Hidden;
            lbl_stock_coci_alimento.Visibility = Visibility.Hidden;
            txt_marca_bebi.Visibility = Visibility.Hidden;
            lbl_habi_ing.Visibility = Visibility.Hidden;
            lbl_marca_bebi.Visibility = Visibility.Hidden;

            txt_insumo_bebi.Visibility = Visibility.Visible;
            txt_stock_bebi.Visibility = Visibility.Visible;
            txt_stock_coci_bebi.Visibility = Visibility.Visible;
            txt_precio_bebi.Visibility = Visibility.Visible;
            btn_imagen.Visibility = Visibility.Visible;
            txt_habili_bebi.Visibility = Visibility.Visible;
            txt_conpre_bebi.Visibility = Visibility.Visible;
            lbl_insumo_bebi.Visibility = Visibility.Visible;
            lbl_stock_bebi.Visibility = Visibility.Visible;
            lbl_stock_coci_bebi.Visibility = Visibility.Visible;
            lbl_precio_bebi.Visibility = Visibility.Visible;
            lbl_imagen_bebi.Visibility = Visibility.Visible;
            lbl_habili_bebi.Visibility = Visibility.Visible;
            lbl_alimento.Visibility = Visibility.Visible;
            lbl_conpre_bebi.Visibility = Visibility.Visible;
            txt_stock_critico.Visibility = Visibility.Visible;
            lbstock_critico.Visibility = Visibility.Visible;
            cmb_proveedor.Visibility = Visibility.Visible;


            btn_crear.IsEnabled = true;

            lbl1.Content = "";
            lbl2.Content = "";
            lbl3.Content = "";
            lbl4.Content = "";
            lbl5.Content = "";

            txt_insumo_alimento.Clear();
            txt_stock_alimento.Clear();
            txt_stock_coci_alimento.Clear();
            cmb_proveedor.SelectedIndex = -1;
            txt_habili_ingre.SelectedIndex = -1;

        }

        private void rbt_alimentos_Checked(object sender, RoutedEventArgs e)
        {

            txt_insumo_bebi.Visibility = Visibility.Hidden;
            txt_stock_bebi.Visibility = Visibility.Hidden;
            txt_stock_coci_bebi.Visibility = Visibility.Hidden;
            txt_marca_bebi.Visibility = Visibility.Hidden;
            txt_precio_bebi.Visibility = Visibility.Hidden;
            btn_imagen.Visibility = Visibility.Hidden;
            txt_habili_bebi.Visibility = Visibility.Hidden;
            txt_conpre_bebi.Visibility = Visibility.Hidden;
            lbl_insumo_bebi.Visibility = Visibility.Hidden;
            lbl_stock_bebi.Visibility = Visibility.Hidden;
            lbl_stock_coci_bebi.Visibility = Visibility.Hidden;
            lbl_marca_bebi.Visibility = Visibility.Hidden;
            lbl_precio_bebi.Visibility = Visibility.Hidden;
            lbl_imagen_bebi.Visibility = Visibility.Hidden;
            lbl_habili_bebi.Visibility = Visibility.Hidden;
            lbl_conpre_bebi.Visibility = Visibility.Hidden;

            txt_insumo_alimento.Visibility = Visibility.Visible;
            txt_stock_alimento.Visibility = Visibility.Visible;
            txt_stock_coci_alimento.Visibility = Visibility.Visible;
            cmb_proveedor.Visibility = Visibility.Visible;
            txt_habili_ingre.Visibility = Visibility.Visible;
            lbl_insumo_alimento.Visibility = Visibility.Visible;
            lbl_stock_alimento.Visibility = Visibility.Visible;
            lbl_stock_coci_alimento.Visibility = Visibility.Visible;
            lbl_alimento.Visibility = Visibility.Visible;
            lbl_habi_ing.Visibility = Visibility.Visible;
            txt_stock_critico.Visibility = Visibility.Visible;
            lbstock_critico.Visibility = Visibility.Visible;

            btn_crear.IsEnabled = true;

            lbl1.Content = "";
            lbl2.Content = "";
            lbl3.Content = "";
            lbl4.Content = "";
            lbl5.Content = "";
            lbl6.Content = "";
            lbl7.Content = "";

            txt_insumo_bebi.Clear();
            txt_stock_bebi.Clear();
            txt_stock_coci_bebi.Clear();
            txt_marca_bebi.Clear();
            txt_precio_bebi.Clear();
            txt_habili_bebi.SelectedIndex = -1;
            txt_conpre_bebi.SelectedIndex = -1;
        }

        private void btn_crear_Click(object sender, RoutedEventArgs e)
        {
            bool txtcampo1 = true;
            bool txtcampo2 = true;
            bool txtcampo3 = true;
            bool txtcampo4 = true;
            bool txtcampo5 = true;
            bool txtcampo6 = true;
            bool txtcampo7 = true;
            bool critico = true;

            if (rbt_alimentos.IsChecked == true)
            {
                if (txt_insumo_alimento.Text.Trim() == "" && txt_insumo_bebi.Text.Trim() == "")
                {
                    txtcampo1 = false;
                    lbl1.Content = "Debe Completar el campo";
                }

                if (txt_stock_alimento.Text.Trim() == "" && txt_stock_bebi.Text.Trim() == "")
                {
                    txtcampo2 = false;
                    lbl2.Content = "Debe Completar el campo";
                }

                if (txt_stock_coci_alimento.Text.Trim() == "" && txt_stock_coci_bebi.Text.Trim() == "")
                {
                    txtcampo3 = false;
                    lbl3.Content = "Debe Completar el campo";
                }

                if (cmb_proveedor.Text.Trim() == "" && txt_marca_bebi.Text.Trim() == "")
                {
                    txtcampo4 = false;
                    lbl4.Content = "Debe Completar el campo";
                }

                if (txt_precio_bebi.Text.Trim() == "" && txt_habili_ingre.Text.Trim() == "")
                {
                    txtcampo5 = false;
                    lbl5.Content = "Debe Completar el campo";
                }

                if (txt_stock_critico.Text == "")
                {
                    critico = false;
                    lb8.Content = "Debe Completar el campo";
                }

                if (txtcampo1 && txtcampo2 && txtcampo3 && txtcampo4 && txtcampo5 && critico)

                {

                    IngredienteBLL ib = new IngredienteBLL();
                    ib.nombre_ingrediente = txt_insumo_alimento.Text;
                    ib.proveedor = cmb_proveedor.Text;
                    ib.habilitado = txt_habili_ingre.Text;
                    ib.stock = Int32.Parse(txt_stock_alimento.Text);
                    ib.stock_cocina = Int32.Parse(txt_stock_coci_alimento.Text);
                    ib.stock_critico = Int32.Parse(txt_stock_critico.Text);
                    bool estado = ib.AddIngrediente(ib);

                    if (estado)
                    {
                        PopupNotifier popup = new PopupNotifier();
                        popup.TitleText = "Aviso";
                        popup.Image = restaurantexxi_adminstrador.Properties.Resources.add;
                        popup.ContentText = "Se ha Creado el ingrediente: " + txt_insumo_alimento.Text;
                        popup.AnimationDuration = 800;
                        popup.Delay = 1700;
                        popup.Popup();

                        txt_insumo_alimento.Clear();
                        txt_stock_alimento.Clear();
                        txt_stock_coci_alimento.Clear();
                        cmb_proveedor.SelectedIndex = -1;
                        txt_habili_ingre.SelectedIndex = -1;


                    }
                    else
                    {
                        MessageBox.Show("Bebestible no fue creado");
                    }

                }
            }

            else if (rbt_bebestibles.IsChecked == true)
            {
                if (txt_insumo_alimento.Text.Trim() == "" && txt_insumo_bebi.Text.Trim() == "")
                {
                    txtcampo1 = false;
                    lbl1.Content = "Debe Completar el campo";
                }

                if (txt_stock_alimento.Text.Trim() == "" && txt_stock_bebi.Text.Trim() == "")
                {
                    txtcampo2 = false;
                    lbl2.Content = "Debe Completar el campo";
                }

                if (txt_stock_coci_alimento.Text.Trim() == "" && txt_stock_coci_bebi.Text.Trim() == "")
                {
                    txtcampo3 = false;
                    lbl3.Content = "Debe Completar el campo";
                }

                if (cmb_proveedor.Text.Trim() == "" && txt_marca_bebi.Text.Trim() == "")
                {
                    txtcampo4 = false;
                    lbl4.Content = "Debe Completar el campo";
                }

                if (txt_precio_bebi.Text.Trim() == "" && txt_habili_ingre.Text.Trim() == "")
                {
                    txtcampo5 = false;
                    lbl5.Content = "Debe Completar el campo";
                }

                if (txt_habili_bebi.Text.Trim() == "")
                {
                    txtcampo6 = false;
                    lbl6.Content = "Debe Completar el campo";
                }

                if (txt_conpre_bebi.Text.Trim() == "")
                {
                    txtcampo7 = false;
                    lbl7.Content = "Debe Completar el campo";
                }

                if (txt_stock_critico.Text == "")
                {
                    critico = false;
                    lb8.Content = "Debe Completar el campo";
                }

                if (txtcampo1 && txtcampo2 && txtcampo3 && txtcampo4 && txtcampo5 && txtcampo6 && txtcampo7 && critico)

                {
                    BebestibleBLL ib = new BebestibleBLL();
                    ib.nombre_beb = txt_insumo_bebi.Text;
                    ib.marca = cmb_proveedor.Text;
                    ib.precio = Int32.Parse(txt_precio_bebi.Text);
                    ib.stock = Int32.Parse(txt_stock_bebi.Text);
                    ib.stock_bar = Int32.Parse(txt_stock_coci_bebi.Text);
                    ib.stock_critico = Int32.Parse(txt_stock_critico.Text);
                    ib.imagen = imageBt;
                    string habilitado = "";
                    if (si_habilitado.IsSelected)
                    {
                        habilitado = "Si";
                    }
                    else if (no_habilitado.IsSelected)
                    {
                        habilitado = "No";
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un estado para el Insumo");
                    }
                    ib.habilitado = habilitado;
                    string con_prep = "";
                    if (si_con.IsSelected)
                    {
                        con_prep = "Si";
                    }
                    else if (no_con.IsSelected)
                    {
                        con_prep = "No";
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un estadi para el Insumo");
                    }
                    ib.con_prep = con_prep;
                    bool estado = ib.AddBebestible(ib);
                    if (estado)
                    {
                        PopupNotifier popup = new PopupNotifier();
                        popup.TitleText = "Aviso";
                        popup.Image = restaurantexxi_adminstrador.Properties.Resources.add;
                        popup.ContentText = "Se ha Creado el bebestible: " + txt_insumo_alimento.Text;
                        popup.AnimationDuration = 800;
                        popup.Delay = 1700;
                        popup.Popup();

                        txt_insumo_bebi.Clear();
                        txt_stock_bebi.Clear();
                        txt_stock_coci_bebi.Clear();
                        txt_marca_bebi.Clear();
                        txt_precio_bebi.Clear();
                        txt_habili_bebi.SelectedIndex = -1;
                        txt_conpre_bebi.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Insumo no fue creado");
                    }
                }
            }
        }



        private void btn_imagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.DefaultExt = ".txt";
            openFileDlg.Filter = "Archivos de Imagen|*.png;*.jpg;*.jpeg|All files(*.*)|*.*";
            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock

            if (result == true)
            {
                string picLoc = openFileDlg.FileName.ToString();

                img_bebi.Source = new BitmapImage(new Uri(picLoc));


                FileStream fstream = new FileStream(picLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProveedorBLL ingBLL = new ProveedorBLL();
            DataTable dt = ingBLL.getallBebi();
            cmb_proveedor.ItemsSource = dt.DefaultView;

            cmb_proveedor.DisplayMemberPath = "NOMBRE_PROVEEDOR";
            cmb_proveedor.SelectedValuePath = "ID_PROVEEDOR";
        }

        private void txt_stock_coci_bebi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_stock_coci_bebi.Text.Length;
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

        private void txt_stock_alimento_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_stock_alimento.Text.Length;
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

        private void txt_insumo_bebi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_insumo_bebi.Text.Length;
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

        private void txt_insumo_alimento_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_insumo_alimento.Text.Length;
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

        private void txt_insumo_alimento_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl1.Content = "";
        }

        private void txt_insumo_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl1.Content = "";
        }

        private void txt_stock_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl2.Content = "";
        }

        private void txt_stock_alimento_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl2.Content = "";
        }

        private void txt_stock_coci_alimento_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl3.Content = "";
        }

        private void txt_stock_coci_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl3.Content = "";
        }

        private void cmb_proveedor_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl4.Content = "";
        }

        private void txt_marca_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl4.Content = "";
        }

        private void txt_habili_ingre_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl5.Content = "";
        }

        private void txt_precio_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl5.Content = "";
        }

        private void txt_habili_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl6.Content = "";
        }

        private void txt_conpre_bebi_GotFocus(object sender, RoutedEventArgs e)
        {
            lbl7.Content = "";
        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
