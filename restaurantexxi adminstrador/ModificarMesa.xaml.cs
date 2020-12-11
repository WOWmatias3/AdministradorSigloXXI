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
    /// Lógica de interacción para ModificarMesa.xaml
    /// </summary>
    public partial class ModificarMesa : MetroWindow
    {
        public ModificarMesa()
        {
            InitializeComponent();
        }

        private void WindModmesa_Loaded(object sender, RoutedEventArgs e)
        {
            MesaBLL mb = new MesaBLL();
            dtg_ComedorPrincipal.IsReadOnly = true;
            dtg_Terra.IsReadOnly = true;
            dtg_Terra2.IsReadOnly = true;
            mb.Alter_Mesa(mb);
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

        private void Btn_altermesa_Click(object sender, RoutedEventArgs e)
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
                if (existe == false)
                {
                    Generic g = new Generic();
                    g.Owner = this;
                    g.lb_titulo.Content = "Advertencia";
                    g.lb_confirmacion.Content = "No existe una mesa con este número. Lo que puede hacer es:";
                    g.lb_contenido.Content = "* Volver atrás y probar con una mesa existente" + "\n" +
                                             "* Ver la lista de mesas Existentes";
                    g.btn_Confirmar.Content = "";
                    g.ACCION.Content = "go_list";
                    g.ACCION.Visibility = Visibility.Hidden;
                    g.btn_Confirmar.Content = "Ver listas";
                    g.ShowDialog();
                }
                else
                {
                    mb.Alter_Mesa(mb);
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
        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        private void Dtg_ComedorPrincipal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView item = (dtg_ComedorPrincipal as DataGrid).SelectedItem as DataRowView;
                txt_numeromesa.Text = item.Row.ItemArray[0].ToString();
                string sala = item.Row.ItemArray[1].ToString();
                if (sala == "Comedor Principal")
                {
                    ComedorPrincipal.IsSelected = true;
                }
                else if (sala == "Terraza")
                {
                    Terraza.IsSelected = true;
                }
                else if (sala == "Terraza 2")
                {
                    Terraza2.IsSelected = true;
                }
                txt_capacidad.Text = item.Row.ItemArray[2].ToString();
            }
            catch
            {

            }

        }

        private void Dtg_Terra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView item = (dtg_Terra as DataGrid).SelectedItem as DataRowView;
                txt_numeromesa.Text = item.Row.ItemArray[0].ToString();
                string sala = item.Row.ItemArray[1].ToString();
                if (sala == "Comedor Principal")
                {
                    ComedorPrincipal.IsSelected = true;
                }
                else if (sala == "Terraza")
                {
                    Terraza.IsSelected = true;
                }
                else if (sala == "Terraza 2")
                {
                    Terraza2.IsSelected = true;
                }
                txt_capacidad.Text = item.Row.ItemArray[2].ToString();
            }
            catch
            {

            }

        }

        private void Dtg_Terra2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            try
            {
                DataRowView item = (dtg_Terra2 as DataGrid).SelectedItem as DataRowView;
                txt_numeromesa.Text = item.Row.ItemArray[0].ToString();

                string sala = item.Row.ItemArray[1].ToString();

                if (sala == "Comedor Principal")
                {
                    ComedorPrincipal.IsSelected = true;
                }
                else if (sala == "Terraza")
                {
                    Terraza.IsSelected = true;
                }
                else if (sala == "Terraza 2")
                {
                    Terraza2.IsSelected = true;
                }
                txt_capacidad.Text = item.Row.ItemArray[2].ToString();
            }
            catch
            {

            }

        }
    }
}
