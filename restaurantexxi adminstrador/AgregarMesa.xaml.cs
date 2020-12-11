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
    /// Lógica de interacción para AgregarMesa.xaml
    /// </summary>
    public partial class AgregarMesa : MetroWindow
    {
        public AgregarMesa()
        {
            InitializeComponent();
        }

        private void Btn_addmesa_Click(object sender, RoutedEventArgs e)
        {
            MesaBLL mb = new MesaBLL();
            bool sal = true;
            bool num = true;
            bool capacidad = true;
            if (ComedorPrincipal.IsSelected || Terraza.IsSelected || Terraza2.IsSelected)
            {
                sal = true;
            }
            else
            {
                sal = false;
            }

            if (txt_numeromesa.Text.Trim() == "")
            {
                num = false;
            }

            if (txt_capacidad.Text.Trim() == "")
            {
                capacidad = false;
            }

            if (num == false)
            {
                lb1.Content = "Ingrese número de mesa";
                lb1.FontSize = 12;
            }
            if (sal == false)
            {
                lb2.Content = "Seleccione una sala para la mesa";
            }
            if (capacidad == false)
            {
                lb3.Content = "Debe darle una capacidad a la mesa";
            }


            if (num == true && sal == true && capacidad == true)
            {
                mb.Id_mesa = Int32.Parse(txt_numeromesa.Text);

                string sala = "";
                if (ComedorPrincipal.IsSelected)
                {
                    sala = "Comedor Principal";
                }
                else if (Terraza.IsSelected)
                {
                    sala = "Terraza";
                }
                else if (Terraza2.IsSelected)
                {
                    sala = "Terraza 2";
                }

                mb.Nombre_sala = sala;
                mb.Capacidad = Int32.Parse(txt_capacidad.Text);
                bool existe = mb.Get_nume(Int32.Parse(txt_numeromesa.Text));
                if (existe == true)
                {
                    Generic g = new Generic();
                    g.Owner = this;
                    g.lb_titulo.Content = "Advertencia";
                    g.lb_confirmacion.Content = "Ya existe una mesa con este número. Lo que puede hacer es:";
                    g.lb_contenido.Content = "* Volver atrás y probar un número distinto" + "\n" +
                                             "* Ver la lista de mesas Existentes";
                    g.btn_Confirmar.Content = "";
                    g.ACCION.Content = "go_list";
                    g.ACCION.Visibility = Visibility.Hidden;
                    g.btn_Confirmar.Content = "Ver listas";
                    g.ShowDialog();
                }
                else
                {
                    mb.AddMesa(mb);
                    DataTable dt1 = mb.GetMesaComedor();
                    dtg_ComedorPrincipal.ItemsSource = dt1.DefaultView;
                    DataTable dt2 = mb.GetMesaterra();
                    dtg_Terra.ItemsSource = dt2.DefaultView;
                    DataTable dt3 = mb.GetMesaTerra2();
                    dtg_Terra2.ItemsSource = dt3.DefaultView;
                    txt_capacidad.Text = "";
                    txt_numeromesa.Text = "";
                    cbb_sala.SelectedIndex = -1;
                }


            }
        }

        private void Txt_numeromesa_GotFocus(object sender, RoutedEventArgs e)
        {
            lb1.Content = "";
        }

        private void ComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            lb2.Content = "";
        }

        private void Txt_capacidad_GotFocus(object sender, RoutedEventArgs e)
        {
            lb3.Content = "";
        }

        private void Txt_rut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Txt_nombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Txt_numeromesa_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Winaddmesa_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                MesaBLL mb = new MesaBLL();
                DataTable dt1 = mb.GetMesaComedor();
                dtg_ComedorPrincipal.ItemsSource = dt1.DefaultView;
                DataTable dt2 = mb.GetMesaterra();
                dtg_Terra.ItemsSource = dt2.DefaultView;
                DataTable dt3 = mb.GetMesaTerra2();
                dtg_Terra2.ItemsSource = dt3.DefaultView;

            }
            catch (Exception ex)
            { MessageBox.Show("" + ex); }



        }
    }
}
