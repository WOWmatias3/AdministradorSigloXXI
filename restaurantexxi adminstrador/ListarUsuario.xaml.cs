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

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para ListarUsuario.xaml
    /// </summary>
    public partial class ListarUsuario : MetroWindow
    {
        public ListarUsuario()
        {
            InitializeComponent();
        }

        private void Btn_filtrar_Click(object sender, RoutedEventArgs e)
        {

            bool rol = true;

            if (coc.IsSelected || bart.IsSelected || Gar.IsSelected || fina.IsSelected || Admin.IsSelected || caja.IsSelected)
            {
                rol = true;
            }
            else
            {
                rol = false;
            }

            if (txt_rut.Text.Trim() == "")
            {
                lb1.Content = "Debe ingresar un rut para filtrar";
            }
            else
            {
                usuarioBLL ub = new usuarioBLL();
                bool existe = ub.GetUserByRut(Int32.Parse(txt_rut.Text));
                if (existe)
                {
                    int rut = Int32.Parse(txt_rut.Text);
                    System.Data.DataTable dt = ub.userList(rut);
                    dtg_Usuarios.ItemsSource = dt.DefaultView;
                }
                else
                {
                    lb1.Content = "Este rut no existe en el sistema";
                }

            }

        }

        private void Btn_listartodos_Click(object sender, RoutedEventArgs e)
        {
            cbb_listarusuarios.SelectedIndex = -1;
            txt_rut.Text = "";
            usuarioBLL ub = new usuarioBLL();
            System.Data.DataTable dt = ub.AllUserList();
            dtg_Usuarios.ItemsSource = dt.DefaultView;
            lb1.Content = "";

        }

        private void Cbb_listarusuarios_QueryCursor(object sender, QueryCursorEventArgs e)
        {


        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Txt_rut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_rut.Text.Length;
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

        private void Btn_atras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Cbb_listarusuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usuarioBLL ub = new usuarioBLL();

            txt_rut.Text = "";
            lb1.Content = "";
            string rol = "";
            if (coc.IsSelected)
            {
                rol = "Cocinero";
            }
            else if (bart.IsSelected)
            {
                rol = "Bartender";
            }
            else if (Gar.IsSelected)
            {
                rol = "Garzon";
            }
            else if (fina.IsSelected)
            {
                rol = "Finanzas";
            }
            else if (Admin.IsSelected)
            {
                rol = "Administrador";
            }
            else if (caja.IsSelected)
            {
                rol = "caja";
            }
            System.Data.DataTable dt = ub.UserRolList(rol);
            dtg_Usuarios.ItemsSource = dt.DefaultView;
        }

        private void Txt_rut_GotFocus(object sender, RoutedEventArgs e)
        {
            cbb_listarusuarios.SelectedIndex = -1;
            txt_rut.Text = "";
        }
    }
}
