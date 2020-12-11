using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PedidoBLL
    {
        public int id_pedido { get; set; }
        public int cantidad { get; set; }
        public int monto_total { get; set; }
        public DateTime fecha { get; set; }
        public int id_insumo { get; set; }
        public int id_proveedor { get; set; }
        public string estado { get; set; }
        public string tipo { get; set; }

        public PedidoBLL()
        {

        }

        public PedidoBLL(int id_pedido, int cantidad, int monto_total, DateTime fecha, int id_insumo, int id_proveedor, string estado, string tipo)
        {
            this.id_pedido = id_pedido;
            this.cantidad = cantidad;
            this.monto_total = monto_total;
            this.fecha = fecha;
            this.id_insumo = id_insumo;
            this.id_proveedor = id_proveedor;
            this.estado = estado;
            this.tipo = tipo;
        }




        public void InsertarDetallePedido(int id, int monto, string estado_, int id_insumo_, int p_id_prov, string tipo_, int cant)
        {
            PedidoDAL pd = new PedidoDAL();
            pd.Insert_DetallePedido(id, monto, estado_, id_insumo_, p_id_prov, tipo_, cant);
        }

        public void Insert_Pedido(DateTime fecha, int monto)
        {
            PedidoDAL pd = new PedidoDAL();
            pd.Insert_Pedido(fecha, monto);
        }


        public DataTable Get_iding_nomb(string nomb)
        {
            PedidoDAL pd = new PedidoDAL();
            DataTable dt = Get_iding_nomb(nomb);
            return dt;
        }

        public DataTable Get_ultimopedido()
        {
            PedidoDAL pd = new PedidoDAL();
            DataTable dt = pd.Get_ultimopedido();
            return dt;
        }


        public DataTable Get_all_pedidos()
        {
            PedidoDAL pd = new PedidoDAL();
            return pd.Get_allpedidos();
        }

        public DataTable Get_all_pedidos_hoy()
        {
            PedidoDAL pd = new PedidoDAL();
            return pd.Get_allpedidos_hoy();
        }



        public DataTable Get_all_pedidos_semana()
        {
            PedidoDAL pd = new PedidoDAL();
            return pd.Get_allpedidos_semana();
        }

        public DataTable Get_all_pedidos_mes()
        {
            PedidoDAL pd = new PedidoDAL();
            return pd.Get_allpedidos_mes();
        }

        public DataTable Get_detPediById_ingredientes(int id_pe)
        {
            PedidoDAL pd = new PedidoDAL();
            return pd.Get_detPediById_ingredientes(id_pe);
        }


        public void Anularpedido(int id_pe, int id_ins)
        {
            PedidoDAL pd = new PedidoDAL();
            pd.Anular_pedido(id_pe, id_ins);
        }

        public DataTable Get_detaPediById_bebestible(int id_pe)
        {
            PedidoDAL pd = new PedidoDAL();
            return pd.Get_detPediById_bebestible(id_pe);
        }

        public string Get_tipo_pedido(int id_pe)
        {
            PedidoDAL pd = new PedidoDAL();
            return pd.Get_tipo_pedido(id_pe);
        }

        public void Alter_montototalporboleta(int id_pe)
        {
            PedidoDAL pd = new PedidoDAL();
            pd.Alter_montototalporboleta(id_pe);
        }

        public void Alter_detalle_pedido(int cant, int id_prov, int monto, int id_ins, int id_ped)
        {
            PedidoDAL pd = new PedidoDAL();
            pd.Alter_detalle_pedido(cant, id_prov, monto, id_ins, id_ped);
        }

        public DataTable Master_pedido(string tipo, string estado, string rango)
        {
            PedidoDAL pd = new PedidoDAL();
            return pd.MaterPedido(tipo,estado,rango);
        }




        /*-------------------------------------------------------------------------------------------------------------

                                                                               | | | | | 
                                                INSERTAR EN  CLASE PROVEEDOR   | | | | | 
                                                                               V V V V V     

        --------------------------------------------------------------------------------------------------------------*/


        public int get_idprovbyname(string nom)
        {
            PedidoDAL pd = new PedidoDAL();
            return pd.Get_idprovbynom(nom);
        }
    }
}
