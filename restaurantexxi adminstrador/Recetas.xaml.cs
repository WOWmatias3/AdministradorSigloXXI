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
	/// Lógica de interacción para Recetas.xaml
	/// </summary>
	public partial class Recetas : Window
	{
		public Recetas()
		{
			InitializeComponent();
		}

		private void btnagregar_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void btneliminar_Click(object sender, RoutedEventArgs e)
		{
			EliminarReceta elire = new EliminarReceta();
			elire.ShowDialog();
		}

		private void btnmodificar_Click(object sender, RoutedEventArgs e)
		{
			ModificarReceta modire = new ModificarReceta();
			modire.ShowDialog();
		}

		private void btnlistar_Click(object sender, RoutedEventArgs e)
		{
			ListarReceta lisre = new ListarReceta();
			lisre.ShowDialog();
		}
	}
}
