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

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para Agregar_Recetas.xaml
    /// </summary>
    public partial class Agregar_Recetas : MetroWindow
    {
        DataTable dtl = new DataTable();
        byte[] imageBt = null;
        public Agregar_Recetas()
        {
            InitializeComponent();

            dtl.Clear();
            dtl.Columns.Add("id");
            dtl.Columns.Add("nombre");
            dtl.Columns.Add("cantidad");

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IngredienteBLL ingBLL = new IngredienteBLL();
            DataTable dt = ingBLL.getalling();
            cbb_ingre.ItemsSource = dt.DefaultView;

            cbb_ingre.DisplayMemberPath = "NOMBRE_INGREDIENTE";
            cbb_ingre.SelectedValuePath = "ID_INGREDIENTE";

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_cant.Text.Length > 0)
            {

                bool coincide = false;
                foreach (DataRow line in dtl.Rows)
                {
                    int id = int.Parse(line["id"].ToString());
                    int cant = int.Parse(line["cantidad"].ToString());

                    //PlatoBLL ptbll = new PlatoBLL();
                    if (cbb_ingre.SelectedValue.ToString() == line["id"].ToString())
                    {
                        line["cantidad"] = int.Parse(line["cantidad"].ToString()) + int.Parse(txt_cant.Text);
                        dtg_Receta.ItemsSource = dtl.DefaultView;
                        coincide = true;
                        break;
                    }
                    else { }
                }
                if (coincide == false)
                {
                    DataRow row = dtl.NewRow();
                    row["id"] = cbb_ingre.SelectedValue;
                    row["nombre"] = cbb_ingre.Text;
                    row["cantidad"] = txt_cant.Text;

                    dtl.Rows.Add(row);
                    dtg_Receta.ItemsSource = dtl.DefaultView;
                }
                dtl.AcceptChanges();

            }
            else
            {
                MessageBox.Show("Por Favor Ingrese todos los Campos al Agregar un ingrediente.");
            }
        }

        private void btn_crear_Click(object sender, RoutedEventArgs e)
        {
            bool nombre = true;
            bool precio = true;
            bool seleccionar = true;
            bool cantidad = true;
            bool descripcion = true;
            bool categ = true;
            bool hab = true;
            IngredienteBLL ib = new IngredienteBLL();
            PlatoBLL plbll = new PlatoBLL();

            if (txt_nomb.Text.Trim() == "")
            {
                nombre = false;
                lb12.Content = "Debe ingresar el Nombre del Plato";
            }
            if (txt_precio.Text.Trim() == "")
            {
                precio = false;
                lb13.Content = "Debe ingresar el Precio del Plato";
            }

            if (cbb_ingre.Text == "")
            {
                nombre = false;
                lb14.Content = "Debe ingresar Los Ingredientes del Plato";
            }
            if (txt_cant.Text.Trim() == "")
            {
                cantidad = false;
                lb15.Content = "Debe ingresar la Cantidad del ingrediente";
            }
            if (txt_desc.Text.Trim() == "")
            {
                descripcion = false;
                lb16.Content = "Debe ingresar una Descripcion para el plato";
            }
            if (cbb_catego.Text == "")
            {
                categ = false;
                lb17.Content = "Debe ingresar una Categoria al plato";
            }
            if (cbb_habi.Text.Trim() == "")
            {
                hab = false;
                lb18.Content = "Debe ingresar el estado del Pato";
            }

            if (nombre && precio && seleccionar && cantidad && descripcion && categ && hab)
            {


                plbll.Categoria = cbb_catego.Text;
                plbll.Habilitado = cbb_habi.Text;
                plbll.Nombre_plato = txt_nomb.Text;
                plbll.Precio = int.Parse(txt_precio.Text);
                plbll.Imagen = imageBt;
                plbll.descripcion = txt_desc.Text;
                int cantinicial = Int32.Parse(txt_cantinicial.Text);
                plbll.insert_plato(plbll,cantinicial);


                foreach (DataRow line in dtl.Rows)
                {
                    int id = int.Parse(line["id"].ToString());
                    int cant = int.Parse(line["cantidad"].ToString());
                    PlatoBLL ptbll = new PlatoBLL();
                    ptbll.crea_relacion_plato_ing(id, cant);
                }

                MessageBox.Show("Receta creada correctamente");
            }
        }

        private void Btn_ELIMINAR_ING_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dtg_Receta.SelectedItem as DataRowView;
            if (row != null)
            {
                foreach (DataRow dr in dtl.Rows)
                {
                    if (dr["id"].ToString() == row.Row.ItemArray[0].ToString())
                    {
                        dr.Delete();
                        dtl.AcceptChanges();
                        dtg_Receta.ItemsSource = dtl.DefaultView;
                        break;
                    }

                }

            }

        }

        private void Txt_cant_TextChanged(object sender, TextChangedEventArgs e)
        {



        }

        private void Txt_cant_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_cant.Text.Length;
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

        private void Btn_imagen_Click(object sender, RoutedEventArgs e)
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

                img_plato.Source = new BitmapImage(new Uri(picLoc));


                FileStream fstream = new FileStream(picLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);
            }
        }

        private void txt_precio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_precio.Text.Length;
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

        private void txt_precio_GotFocus(object sender, RoutedEventArgs e)
        {
            lb13.Content = "";
        }

        private void txt_nomb_GotFocus(object sender, RoutedEventArgs e)
        {
            lb12.Content = "";
        }

        private void cbb_ingre_GotFocus(object sender, RoutedEventArgs e)
        {
            lb14.Content = "";
        }

        private void txt_cant_GotFocus(object sender, RoutedEventArgs e)
        {
            lb15.Content = "";
        }

        private void txt_desc_GotFocus(object sender, RoutedEventArgs e)
        {
            lb16.Content = "";
        }

        private void cbb_catego_GotFocus(object sender, RoutedEventArgs e)
        {
            lb17.Content = "";
        }

        private void cbb_habi_GotFocus(object sender, RoutedEventArgs e)
        {
            lb18.Content = "";
        }
    }
}
