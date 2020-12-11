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
    /// Lógica de interacción para EliminarProveedor.xaml
    /// </summary>
    public partial class EliminarProveedor : MetroWindow
    {
        public EliminarProveedor()
        {
            InitializeComponent();
        }

        private void Btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            ProveedorBLL us = new ProveedorBLL();
            Generic gen = new Generic();
            /*ProveedorBLL pb = new ProveedorBLL();
            int rut = Int32.Parse(txt_id.Text);
            pb.deleteprov(rut);
            txt_id.Text = "";
            dtg_Allprov.Items.Refresh();*/
            bool idprov = true;

            if (txt_id.Text.Trim() == "")
            {
                idprov = false;
                lb1.Content = "Debe ingresar o seleccionar una id";
            }

            if (idprov)
            {
                bool existe = us.AllprovlistExiste(Int32.Parse(txt_id.Text));

                if (existe)
                {

                    gen.ACCION.Content = "eliminarprov";
                    gen.ACCION.Visibility = Visibility.Hidden;
                    int id = Int32.Parse(txt_id.Text);
                    try
                    {
                        DataTable da = us.Allprovid(id);
                        DataRow row = da.Rows[0];
                        string idd = row[0].ToString();
                        string Nombre = row[1].ToString() + " " + row[2].ToString();
                        string rol = row[2].ToString();
                        gen.lb_titulo.FontSize = 18;
                        gen.lb_confirmacion.FontSize = 16;
                        gen.lb_contenido.FontSize = 16;
                        gen.lb_titulo.Content = "¿Desea eliminar a este usuario?";
                        gen.lb_confirmacion.Content = "Al realizar esta accion, se eliminará al proveedor:";
                        gen.lb_contenido.Content = "Id : " + idd + "\n" +
                                                   "Nombre: " + Nombre + "\n" +
                                                   "Descripción: " + rol;
                        gen.Title = "Confirmación";
                        gen.btn_Cancelar.Content = "Volver";
                        gen.btn_Confirmar.Content = "Eliminar";
                        gen.lb_rut.Content = txt_id.Text;
                        gen.Owner = this;
                        gen.ShowDialog();
                        ProveedorBLL pb = new ProveedorBLL();
                        DataTable dt = pb.Allprovlist();
                        dtg_Allprov.ItemsSource = dt.DefaultView;

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Este Usuario no existe en el sistema");
                        MessageBox.Show("" + ex);
                    }
                }
                else
                {
                    lb1.Content = "La id ingresada no existe en el sistema";
                }
            }


        }

        private void Win_eliminar_prov_Loaded(object sender, RoutedEventArgs e)
        {
            ProveedorBLL ub = new ProveedorBLL();
            System.Data.DataTable dt = ub.Allprovlist();
            dtg_Allprov.ItemsSource = dt.DefaultView;


        }

        private void Dtg_Allprov_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            object item = dtg_Allprov.SelectedItem; //probably you find this object
            if (item != null)
            {
                string rut = (dtg_Allprov.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                // = (dtg_aux.SelectedCells[4].Column.GetCellContent(item) as );
                //aa.BitmapSourceToByteArray(imagen);
                txt_id.Text = rut;
            }
            else
            {

            }
        }

        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Txt_id_GotFocus(object sender, RoutedEventArgs e)
        {
            lb1.Content = "";
        }

        private void Txt_id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_id.Text.Length;

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
