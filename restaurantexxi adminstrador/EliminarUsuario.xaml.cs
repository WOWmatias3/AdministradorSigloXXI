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
using MahApps.Metro.Controls.Dialogs;
using System.Data;

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para EliminarUsuario.xaml
    /// </summary>
    public partial class EliminarUsuario : MetroWindow
    {
        public EliminarUsuario()
        {
            InitializeComponent();
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

            Generic gen = new Generic();

            gen.ACCION.Content = "eliminar";
            gen.ACCION.Visibility = Visibility.Hidden;
            usuarioBLL us = new usuarioBLL();

            bool rute = true;
            if (txt_rut.Text.Trim() == "")
            {
                rute = false;
                lb1.Content = "Ingrese un rut o seleccione el que desea desde la lista";
            }

            if (rute == true)
            {

                int rut = Int32.Parse(txt_rut.Text);
                bool existe = us.GetUserByRut(rut);
                if (existe)
                {
                    try
                    {
                        DataTable da = us.userList(rut);
                        DataRow row = da.Rows[0];
                        string rutt = row[0].ToString();
                        string Nombre = row[1].ToString() + " " + row[2].ToString();
                        string rol = row[4].ToString();
                        gen.lb_titulo.FontSize = 18;
                        gen.lb_confirmacion.FontSize = 16;
                        gen.lb_contenido.FontSize = 16;
                        gen.lb_titulo.Content = "¿Desea deshabilitar a este usuario?";
                        gen.lb_confirmacion.Content = "Al realizar esta accion, se deshabilitará al usuario:";
                        gen.lb_contenido.Content = "Rut : " + rut + "\n" +
                                                   "Nombre: " + Nombre + "\n" +
                                                   "Rol: " + rol;
                        gen.Title = "Confirmación";
                        gen.btn_Cancelar.Content = "Volver";
                        gen.btn_Confirmar.Content = "Eliminar";
                        gen.lb_rut.Content = txt_rut.Text;
                        gen.Owner = this;
                        gen.ShowDialog();

                        usuarioBLL ub = new usuarioBLL();
                        DataTable dt = ub.AllUserList();
                        dtg_eliminar.ItemsSource = dt.DefaultView;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }

                }
                else
                {
                    lb1.Content = "El rut no esta ingresado en el sistema";
                }


            }
            else
            {
                lb1.Content = "Ingrese un rut o seleccione el que desea desde la lista";
            }


        }

        private void Btn_atras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Txt_rut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_rut.Text.Length;

            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii == 75 || ascii == 107 || ascii >= 48 && ascii <= 57)
            {
                if (tamanio < 9)
                {
                    if (tamanio != 8 && ascii == 75 || ascii == 107)
                    {
                        if (tamanio == 8)
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
                        e.Handled = false;
                    }
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

        private void Win_eliminaruser_Loaded(object sender, RoutedEventArgs e)
        {
            usuarioBLL ub = new usuarioBLL();
            DataTable dt = ub.AllUserList();
            dtg_eliminar.ItemsSource = dt.DefaultView;
        }

        private void Dtg_eliminar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dtg_eliminar.SelectedItem; //probably you find this object
            if (item != null)
            {
                string rut = (dtg_eliminar.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                // = (dtg_aux.SelectedCells[4].Column.GetCellContent(item) as );
                //aa.BitmapSourceToByteArray(imagen);
                txt_rut.Text = rut;
            }
            else
            {

            }
        }

        private void Txt_rut_GotFocus(object sender, RoutedEventArgs e)
        {
            lb1.Content = "";
        }
    }
}
