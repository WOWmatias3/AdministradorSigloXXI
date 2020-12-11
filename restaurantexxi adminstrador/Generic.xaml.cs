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
using System.Windows.Threading;
using System.Threading;
using Tulpep.NotificationWindow;

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para Generic.xaml
    /// </summary>
    public partial class Generic : MetroWindow
    {
        public Generic()
        {
            InitializeComponent();
        }






        private void Btn_Confirmar_Click(object sender, RoutedEventArgs e)
        {
            usuarioBLL us = new usuarioBLL();
            string act = ACCION.Content.ToString();
            if (act == "eliminar")
            {
                int rut = Int32.Parse(lb_rut.Content.ToString());
                lb_titulo.VerticalAlignment = VerticalAlignment.Center;
                us.rut = rut;
                us.DeleteUser(us);
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Aviso";
                popup.Image = Properties.Resources.delete;
                popup.ContentText = "Se ha Eliminado el usuario con rut: " + rut;
                popup.AnimationDuration = 800;
                popup.Delay = 1400;
                popup.Popup();
                Close();
            }
            else if (act == "eliminarprov")
            {
                ProveedorBLL pb = new ProveedorBLL();
                int id = Int32.Parse(lb_rut.Content.ToString());
                pb.deleteprov(id);
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Aviso";
                popup.Image = Properties.Resources.delete;
                popup.ContentText = "Se ha Eliminado el Proveedor con id: " + id;
                popup.AnimationDuration = 500;
                popup.Delay = 2500;
                popup.Popup();
                Close();
            }
            else if (act == "deletemesa")
            {
                MesaBLL mb = new MesaBLL();
                int num = Int32.Parse(lb_rut.Content.ToString());
                mb.DeleteMesa(num);
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Aviso";
                popup.Image = Properties.Resources.delete;
                popup.ContentText = "Se ha Eliminado la mesa número: " + num;
                popup.AnimationDuration = 500;
                popup.Delay = 2500;
                popup.Popup();
                Close();

            }
            else if (act == "Modificarbebi")
            {
                int id = Int32.Parse(lb_rut.Content.ToString());
                BebestibleBLL bb = new BebestibleBLL();
                lb_titulo.VerticalAlignment = VerticalAlignment.Center;
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Aviso";
                popup.Image = Properties.Resources.add;
                popup.ContentText = "Se ha Deshabilitado el bebestible con id: " + id;
                popup.AnimationDuration = 500;
                popup.Delay = 2000;
                popup.Popup();
                bb.id_bebestible = id;
                bb.Alterinhabilitado(bb);
                Close();
            }
            else if (act == "Modificaring")
            {
                int id = Int32.Parse(lb_rut.Content.ToString());
                lb_titulo.VerticalAlignment = VerticalAlignment.Center;
                IngredienteBLL ib = new IngredienteBLL();
                ib.id_ingrediente = id;
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Aviso";
                popup.Image = Properties.Resources.add;
                popup.ContentText = "Se ha Deshabilitado el ingrediente con id: " + id;
                popup.AnimationDuration = 500;
                popup.Delay = 2000;
                popup.Popup();
                ib.Alterinhabilitadoing(ib);
                Close();
            }
            else if (act == "deshabilitar")
            {
                PlatoBLL pb = new PlatoBLL();
                pb.Id_plato = Int32.Parse(lb_rut.Content.ToString());
                pb.DesPlato(pb);
                Close();
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Aviso";
                popup.Image = Properties.Resources.delete;
                popup.ContentText = "Se ha Deshabilitado el plato con id: " + Int32.Parse(lb_rut.Content.ToString());
                popup.AnimationDuration = 500;
                popup.Delay = 2000;
                popup.Popup();
                Close();
            }
            else if (act == "go_list")
            {
                ListarMesas lm = new ListarMesas();
                lm.Owner = this;
                lm.rdb_todas.IsChecked = true;
                lm.ShowDialog();
                Close();
            }
            else
            {
            }
        }

        private void Btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Generica_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            Close();
        }
    }
}
