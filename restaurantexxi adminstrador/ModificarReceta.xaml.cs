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
using Tulpep.NotificationWindow;

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para ModificarReceta.xaml
    /// </summary>
    public partial class ModificarReceta : MetroWindow
    {
        DataTable dtl = new DataTable();

        public ModificarReceta()
        {
            InitializeComponent();

            dtl.Clear();
            dtl.Columns.Add("id");
            dtl.Columns.Add("nombre");
            dtl.Columns.Add("cantidad");

        }


        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void modi_rece_Loaded(object sender, RoutedEventArgs e)
        {
            IngredienteBLL ingBLL = new IngredienteBLL();
            DataTable dt = ingBLL.getalling();
            cbb_ingres.ItemsSource = dt.DefaultView;

            cbb_ingres.DisplayMemberPath = "NOMBRE_INGREDIENTE";
            cbb_ingres.SelectedValuePath = "ID_INGREDIENTE";
        }

        private void btn_agre_Click(object sender, RoutedEventArgs e)
        {
            dtg_ing.Visibility = Visibility.Visible;
            if (txt_cant_ing.Text.Length > 0)
            {

                bool coincide = false;
                foreach (DataRow line in dtl.Rows)
                {
                    int id = int.Parse(line["id"].ToString());
                    int cant = int.Parse(line["cantidad"].ToString());

                    PlatoBLL ptbll = new PlatoBLL();
                    if (cbb_ingres.SelectedValue.ToString() == line["id"].ToString())
                    {
                        line["cantidad"] = int.Parse(line["cantidad"].ToString()) + int.Parse(txt_cant_ing.Text);
                        dtg_ing.ItemsSource = dtl.DefaultView;
                        coincide = true;
                        break;
                    }
                    else { }
                }
                if (coincide == false)
                {
                    DataRow row = dtl.NewRow();
                    row["id"] = cbb_ingres.SelectedValue;
                    row["nombre"] = cbb_ingres.Text;
                    row["cantidad"] = txt_cant_ing.Text;

                    dtl.Rows.Add(row);

                    dtg_ing.ItemsSource = dtl.DefaultView;
                }
                dtl.AcceptChanges();

            }
            else
            {
                MessageBox.Show("Por Favor Ingrese todos los Campos al Agregar un ingrediente.");
            }
        }

        private void btn_quitar_Click(object sender, RoutedEventArgs e)
        {
            {
                DataRowView row = dtg_ing.SelectedItem as DataRowView;
                if (row != null)
                {
                    foreach (DataRow dr in dtl.Rows)
                    {
                        if (dr["id"].ToString() == row.Row.ItemArray[0].ToString())
                        {
                            dr.Delete();
                            dtl.AcceptChanges();
                            dtg_ing.ItemsSource = dtl.DefaultView;
                            break;
                        }

                    }

                }
            }
        }

        private void btn_list_todo_Click(object sender, RoutedEventArgs e)
        {
            PlatoBLL ub = new PlatoBLL();
            System.Data.DataTable dt = ub.AllplatosList();
            dtg_list_todo.ItemsSource = dt.DefaultView;
            dtg_list_todo.Visibility = Visibility.Visible;

        }

        private void btn_mod_Click(object sender, RoutedEventArgs e)
        {
            bool idrec = true;
            bool nomb = true;
            bool habili = true;
            bool selec = true;
            bool canti = true;
            bool prec = true;
            bool cat = true;
            bool des = true;
            lb1.Content = "";
            lb2.Content = "";
            lb3.Content = "";
            lb4.Content = "";
            lb5.Content = "";
            lb6.Content = "";
            lb7.Content = "";

            PlatoBLL ub = new PlatoBLL();


            if (txt_id_rec.Text.Trim() == "")
            {
                idrec = false;
                lb1.Content = "Debe ingresar la ID";
            }
            if (txt_nom_rec.Text.Trim() == "")
            {
                nomb = false;
                lb2.Content = "Debe ingresar el Nombre del Plato";
            }

            if (cbb_habili.Text == "")
            {
                habili = false;
                lb3.Content = "Debe ingresar el Estado del Plato";
            }
            if (rb_cons.IsChecked == false)
            {
                if (cbb_ingres.Text == "")
                {
                    selec = false;
                    lb4.Content = "Debe Seleccionar el/los Ingredientes del Plato";
                }
                if (txt_cant_ing.Text.Trim() == "")
                {
                    canti = false;
                    lb5.Content = "Debe ingresar la Cantidad del Ingrediente a ingresar";
                }
            }


            if (txt_prec.Text.Trim() == "")
            {
                prec = false;
                lb6.Content = "Debe ingresar el Precio del Plato";
            }
            if (cbb_catego.Text.Trim() == "")
            {
                cat = false;
                lb7.Content = "Debe ingresar la Categoria del Plato";
            }
            if (txt_desc_mod.Text.Trim() == "")
            {
                des = false;
                lb8.Content = "Debe ingresar la Descripcion del Plato";
            }



            if (idrec && nomb && habili && selec && canti && prec && cat && des)
            {

                ub.Id_plato = Int32.Parse(txt_id_rec.Text);
                ub.Nombre_plato = txt_nom_rec.Text;
                /*ub.cantidad = Int32.Parse(txt_cant_ing.Text);*/
                ub.Precio = Int32.Parse(txt_prec.Text);
                ub.Categoria = cbb_catego.Text;
                ub.descripcion = txt_desc_mod.Text;
                ub.Habilitado = cbb_habili.Text;

                bool existe = ub.Getplatobyid(Int32.Parse(txt_id_rec.Text));


                if (existe)
                {
                    ub.Eliminar_Ing(ub);
                    ub.alter_plato(ub);

                    PopupNotifier popup = new PopupNotifier();
                    popup.TitleText = "Aviso";
                    popup.Image = Properties.Resources.delete;
                    popup.ContentText = "Plato modificado correctamente";
                    popup.AnimationDuration = 500;
                    popup.Delay = 2500;
                    popup.Popup();
                    Close();
                }
                else
                {
                    MessageBox.Show("La id del plato ingresado no existe");
                }

                if (rb_elim.IsChecked == true)
                {

                    foreach (DataRow line in dtl.Rows)
                    {
                        int idplato = Int32.Parse(txt_id_rec.Text);
                        int id = int.Parse(line["id"].ToString());
                        int cant = int.Parse(line["cantidad"].ToString());

                        PlatoBLL ptbll = new PlatoBLL();
                        try
                        {

                            ptbll.Modifica_relacion_ing(idplato, id, cant);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }

                    }


                }

            }

        }

        private void rb_cons_Checked(object sender, RoutedEventArgs e)
        {
            txt_cant_ing.Visibility = Visibility.Hidden;
            cbb_ingres.Visibility = Visibility.Hidden;
            btn_quitar.Visibility = Visibility.Hidden;
            btn_agre.Visibility = Visibility.Hidden;
            lbl_cant.Visibility = Visibility.Hidden;
            lbl_selec_ing.Visibility = Visibility.Hidden;
            lb4.Content = "";
            lb5.Content = "";

        }

        private void rb_elim_Checked(object sender, RoutedEventArgs e)
        {
            txt_cant_ing.Visibility = Visibility.Visible;
            cbb_ingres.Visibility = Visibility.Visible;
            btn_quitar.Visibility = Visibility.Visible;
            btn_agre.Visibility = Visibility.Visible;
            lbl_cant.Visibility = Visibility.Visible;
            lbl_selec_ing.Visibility = Visibility.Visible;

            txt_cant_ing.IsEnabled = true;
            cbb_ingres.IsEnabled = true;
            btn_agre.IsEnabled = true;
            btn_quitar.IsEnabled = true;

        }

        private void txt_id_rec_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_id_rec.Text.Length;
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

        private void txt_cant_ing_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_cant_ing.Text.Length;
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

        private void txt_prec_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_prec.Text.Length;
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

        private void txt_id_rec_GotFocus(object sender, RoutedEventArgs e)
        {
            lb1.Content = "";
        }

        private void txt_nom_rec_GotFocus(object sender, RoutedEventArgs e)
        {
            lb2.Content = "";
        }

        private void cbb_habili_GotFocus(object sender, RoutedEventArgs e)
        {
            lb3.Content = "";
        }

        private void cbb_ingres_GotFocus(object sender, RoutedEventArgs e)
        {
            lb4.Content = "";
        }

        private void txt_cant_ing_GotFocus(object sender, RoutedEventArgs e)
        {
            lb5.Content = "";
        }

        private void txt_prec_GotFocus(object sender, RoutedEventArgs e)
        {
            lb6.Content = "";
        }

        private void cbb_catego_GotFocus(object sender, RoutedEventArgs e)
        {
            lb7.Content = "";
        }

        private void txt_desc_mod_GotFocus(object sender, RoutedEventArgs e)
        {
            lb8.Content = "";
        }

        private void Txt_desc_mod_SelectionChanged(object sender, RoutedEventArgs e)
        {
          
        }

        private void Dtg_list_todo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                object item = dtg_list_todo.SelectedItem; //probably you find this object
                if (item != null)
                {
                    string id = (dtg_list_todo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string nombre = (dtg_list_todo.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    string precio = (dtg_list_todo.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    string categoria = (dtg_list_todo.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                    string habilitado = (dtg_list_todo.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                    string desc = (dtg_list_todo.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                    txt_id_rec.Text = id;
                    txt_nom_rec.Text = nombre;
                    txt_prec.Text = precio;
                    cbb_catego.Text = categoria;
                    cbb_habili.Text = habilitado;
                    txt_desc_mod.Text = desc;
                }
                else
                {
                }
            }
            catch
            {

            }
        }
    }
}
