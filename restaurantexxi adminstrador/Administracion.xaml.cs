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
using System.Windows.Threading;
using AplicacionBar;
using MahApps.Metro.Controls;
using Tulpep.NotificationWindow;

namespace restaurantexxi_adminstrador
{
    /// <summary>
    /// Lógica de interacción para Administracion.xaml
    /// </summary>
    public partial class Administracion : MetroWindow
    {
        public Administracion()
        {
            InitializeComponent();
        }

        private void Button_Salir(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Close();
            mw.ShowDialog();
        }

        private void TileUser_Click(object sender, RoutedEventArgs e)
        {
            Usuarios.IsOpen = true;
            Recetas.IsOpen = false;
            Insumos.IsOpen = false;
            Proveedores.IsOpen = false;
            Pedido.IsOpen = false;
            Mesas.IsOpen = false;
        }

        private void Tilreceta_Click(object sender, RoutedEventArgs e)
        {
            Usuarios.IsOpen = false;
            Recetas.IsOpen = true;
            Insumos.IsOpen = false;
            Proveedores.IsOpen = false;
            Pedido.IsOpen = false;
            Mesas.IsOpen = false;
        }

        private void Tilinsumos_Click(object sender, RoutedEventArgs e)
        {
            Usuarios.IsOpen = false;
            Recetas.IsOpen = false;
            Insumos.IsOpen = true;
            Proveedores.IsOpen = false;
            Pedido.IsOpen = false;
            Mesas.IsOpen = false;
        }

        private void Tilproveedores_Click(object sender, RoutedEventArgs e)
        {
            Usuarios.IsOpen = false;
            Recetas.IsOpen = false;
            Insumos.IsOpen = false;
            Proveedores.IsOpen = true;
            Pedido.IsOpen = false;
            Mesas.IsOpen = false;
        }

        private void Tilpedido_Click(object sender, RoutedEventArgs e)
        {
            Usuarios.IsOpen = false;
            Recetas.IsOpen = false;
            Insumos.IsOpen = false;
            Proveedores.IsOpen = false;
            Pedido.IsOpen = true;
            Mesas.IsOpen = false;
        }



        private void Tile_Add_User_Click(object sender, RoutedEventArgs e)
        {
            AgregarUsuario au = new AgregarUsuario();
            au.Owner = this;
            au.lb_nombreusuario.Content = lb_nombreusuario.Content;
            au.ShowDialog();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            EliminarUsuario eu = new EliminarUsuario();
            eu.Owner = this;
            eu.lb_nombreusuario.Content = this.lb_nombreusuario.Content;
            eu.ShowDialog();
        }

        private void Tile_AlterUser_Click(object sender, RoutedEventArgs e)
        {
            ModificarUsuario mu = new ModificarUsuario();
            mu.Owner = this;
            mu.lb_nombreusuario.Content = lb_nombreusuario.Content;
            mu.ShowDialog();
        }

        private void Tile_Listar_Click(object sender, RoutedEventArgs e)
        {
            ListarUsuario lu = new ListarUsuario();
            lu.Owner = this;
            lu.lb_nombreusuario.Content = lb_nombreusuario.Content;
            lu.ShowDialog();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {


        }
        private void tile_abrir(object sender, RoutedEventArgs e)
        {
            AgregarProveedor au = new AgregarProveedor();
            au.Owner = this;
            au.lb_nombreusuario.Content = lb_nombreusuario.Content;
            au.ShowDialog();

        }

        private void Tile_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            EliminarProveedor ep = new EliminarProveedor();
            ep.Owner = this;
            ep.lb_nombreusuario.Content = lb_nombreusuario.Content;
            ep.ShowDialog();
        }

        private void Tile_Filtrar_Prov_Click(object sender, RoutedEventArgs e)
        {
            ListarProveedor lp = new ListarProveedor();
            lp.Owner = this;
            lp.lb_nombreusuario.Content = lb_nombreusuario.Content;
            lp.ShowDialog();
        }

        private void Tile_Alter_Prov_Click(object sender, RoutedEventArgs e)
        {
            ModificarProveedor mp = new ModificarProveedor();
            mp.Owner = this;
            mp.lb_nombreusuario.Content = lb_nombreusuario.Content;
            mp.ShowDialog();
        }

        private void Tile_AddMesa_Click(object sender, RoutedEventArgs e)
        {
            AgregarMesa am = new AgregarMesa();
            am.Owner = this;
            am.lb_nombreusuario.Content = lb_nombreusuario.Content;
            am.ShowDialog();

        }

        private void Tile_Filtrar_Click(object sender, RoutedEventArgs e)
        {
            ListarMesas lm = new ListarMesas();
            lm.Owner = this;
            lm.lb_nombreusuario.Content = lb_nombreusuario.Content;
            lm.ShowDialog();
        }

        private void Tile_DeleteMesa_Click(object sender, RoutedEventArgs e)
        {
            EliminarMesa em = new EliminarMesa();
            em.Owner = this;
            em.lb_nombreusuario.Content = lb_nombreusuario.Content;
            em.ShowDialog();
        }




        private void Tile_Altermesa_Click(object sender, RoutedEventArgs e)
        {
            ModificarMesa mm = new ModificarMesa();
            mm.Owner = this;
            mm.lb_nombreusuario.Content = lb_nombreusuario.Content;
            mm.ShowDialog();

        }




        private void Tile_Add_Receta_Click(object sender, RoutedEventArgs e)
        {
            Agregar_Recetas ar = new Agregar_Recetas();
            ar.Owner = this;
            ar.lb_nombreusuario.Content = lb_nombreusuario.Content;
            ar.ShowDialog();
        }

        private void Tile_Delete_Receta_Click(object sender, RoutedEventArgs e)
        {
            EliminarReceta dr = new EliminarReceta();
            dr.Owner = this;
            dr.lb_nombreusuario.Content = lb_nombreusuario.Content;
            dr.ShowDialog();
        }

        private void Tile_Mod_Receta_Click(object sender, RoutedEventArgs e)
        {
            ModificarReceta mr = new ModificarReceta();
            mr.Owner = this;
            mr.lb_nombreusuario.Content = lb_nombreusuario.Content;
            mr.ShowDialog();
        }

        private void Tile_List_Recetas_Click(object sender, RoutedEventArgs e)
        {
            ListarReceta lr = new ListarReceta();
            lr.Owner = this;
            lr.lb_nombreusuario.Content = lb_nombreusuario.Content;
            lr.ShowDialog();
        }

        private void Tile_addinsumo_Click(object sender, RoutedEventArgs e)
        {
            pruebas p = new pruebas();
            p.Owner = this;
            p.lb_nombreusuario.Content = lb_nombreusuario.Content;
            p.ShowDialog();
        }

        private void Tile_deleteins_Click(object sender, RoutedEventArgs e)
        {
            prueba4 p = new prueba4();
            p.Owner = this;
            p.lb_nombreusuario.Content = lb_nombreusuario.Content;
            p.ShowDialog();
        }

        private void Tile_alterins_Click(object sender, RoutedEventArgs e)
        {
            prueba3 p = new prueba3();
            p.Owner = this;
            p.lb_nombreusuario.Content = lb_nombreusuario.Content;
            p.ShowDialog();
        }

        private void Tile_filtrarins_Click(object sender, RoutedEventArgs e)
        {
            prueba2 p = new prueba2();
            p.Owner = this;
            p.lb_nombreusuario.Content = lb_nombreusuario.Content;
            p.ShowDialog();
        }


        private void Tile_conf_pedido_Click(object sender, RoutedEventArgs e)
        {
            ConfirmarPedido cp = new ConfirmarPedido();
            cp.Owner = this;
            cp.lb_nombreusuario.Content = lb_nombreusuario.Content;
            cp.ShowDialog();
        }

        private void Tile_alter_mesa_Click(object sender, RoutedEventArgs e)
        {
            ModificarMesa am = new ModificarMesa();
            am.Owner = this;
            am.lb_nombreusuario.Content = lb_nombreusuario.Content;
            am.ShowDialog();
        }

        private void Tile_add_mesa_Click(object sender, RoutedEventArgs e)
        {
            AgregarMesa am = new AgregarMesa();
            am.Owner = this;
            am.lb_nombreusuario.Content = lb_nombreusuario.Content;
            am.ShowDialog();
        }

        private void Tile_deletemesa_Click_1(object sender, RoutedEventArgs e)
        {
            EliminarMesa em = new EliminarMesa();
            em.Owner = this;
            em.lb_nombreusuario.Content = lb_nombreusuario.Content;
            em.ShowDialog();
        }

        private void Tile_filtrar_mesa_Click(object sender, RoutedEventArgs e)
        {
            ListarMesas lm = new ListarMesas();
            lm.Owner = this;
            lm.lb_nombreusuario.Content = lb_nombreusuario.Content;
            lm.ShowDialog();
        }

        private void Tilmesa_Click(object sender, RoutedEventArgs e)
        {
            Usuarios.IsOpen = false;
            Recetas.IsOpen = false;
            Insumos.IsOpen = false;
            Proveedores.IsOpen = false;
            Pedido.IsOpen = false;
            Mesas.IsOpen = true;
        }

        private void Tile_filtrar_pedidos_Click(object sender, RoutedEventArgs e)
        {
            ListarPedidos lp = new ListarPedidos();
            lp.Owner = this;
            lp.ShowDialog();
        }
    }
}
