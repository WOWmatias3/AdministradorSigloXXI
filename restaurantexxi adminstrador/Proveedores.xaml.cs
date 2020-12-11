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
	/// Lógica de interacción para Proveedores.xaml
	/// </summary>
	public partial class Proveedores : Window
	{
		public Proveedores()
		{
			InitializeComponent();
		}

		private void btnagregar_Click(object sender, RoutedEventArgs e)
		{
			AgregarProveedor agrpro = new AgregarProveedor();
			agrpro.ShowDialog();
		}

		private void btneliminar_Click(object sender, RoutedEventArgs e)
		{
			EliminarProveedor elipro = new EliminarProveedor();
			elipro.ShowDialog();
		}

		private void btnmodificar_Click(object sender, RoutedEventArgs e)
		{
			ModificarProveedor modiopro = new ModificarProveedor();
			modiopro.ShowDialog();
		}

		private void btnlistar_Click(object sender, RoutedEventArgs e)
		{
			ListarProveedor lispro = new ListarProveedor();
			lispro.ShowDialog();
		}
	}
}
