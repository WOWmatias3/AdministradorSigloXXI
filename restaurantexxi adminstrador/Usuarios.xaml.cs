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

namespace restaurantexxi_adminstrador
{
	/// <summary>
	/// Lógica de interacción para Usuarios.xaml
	/// </summary>
	public partial class Usuarios : Window
	{
		public Usuarios()
		{
			InitializeComponent();
		}

		private void btnagregar_Click(object sender, RoutedEventArgs e)
		{
			AgregarUsuario agus = new AgregarUsuario();
			agus.ShowDialog();
		}

		private void btneliminar_Click(object sender, RoutedEventArgs e)
		{
			EliminarUsuario elius = new EliminarUsuario();
			elius.ShowDialog();
		}

		private void btnmodificar_Click(object sender, RoutedEventArgs e)
		{
			ModificarUsuario modus = new ModificarUsuario();
			modus.ShowDialog();
		}

		private void btnlistar_Click(object sender, RoutedEventArgs e)
		{
			ListarUsuario lisus = new ListarUsuario();
			lisus.ShowDialog();
		}
	}
}
