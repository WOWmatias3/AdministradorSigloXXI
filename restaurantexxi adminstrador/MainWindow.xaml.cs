using System.Windows;
using BLL;
using MahApps.Metro.Controls;
using Tulpep.NotificationWindow;

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            /*Administracion adm = new Administracion();
            adm.Owner = this;
            adm.ShowDialog();*/

          // MessageBox.Show("Bienvenido " + txtnombre.Text);
            usuarioBLL usrbll = new usuarioBLL();
			bool check = usrbll.getLogin(txtnombre.Text, txtclave.Password);
			if (check)
			{
                int rut = usrbll.Getrut(txtnombre.Text,txtclave.Password);
                string nombre = usrbll.Get_nombrecompleto(rut);
                
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Aviso";
                popup.Image = Properties.Resources.add;
                popup.ContentText = "Bienvenido" + nombre;
                popup.AnimationDuration = 500;
                popup.Delay = 3500;
                popup.Popup();
                Administracion adm = new Administracion();
                adm.lb_nombreusuario.Content = nombre;
				Close();
				adm.ShowDialog();
			}
			else
			{
				lb1.Content="Credenciales o Rol Incorrectos, Intente nuevamente";
			}

        }
    }
}
