using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BebestibleBLL
    {
        public int id_bebestible { get; set; }
        public string nombre_beb { get; set; }
        public string marca { get; set; }
        public int precio { get; set; }
        public int stock { get; set; }
        public int stock_bar { get; set; }
        public Byte[] imagen { get; set; }
        public string habilitado { get; set; }
        public string con_prep { get; set; }

        public int stock_critico { get; set; }


        public BebestibleBLL()
        {
        }
        public BebestibleBLL(int id_bebestible,
                             string nombre_beb,
                             string marca,
                             int precio,
                             int stock,
                             int stock_bar,
                             Byte[] imagen,
                             string habilitado,
                             string con_prep,
                             int stock_critico)
        {
            this.id_bebestible = id_bebestible;
            this.nombre_beb = nombre_beb;
            this.marca = marca;
            this.precio = precio;
            this.stock = stock;
            this.stock_bar = stock_bar;
            this.imagen = imagen;
            this.habilitado = habilitado;
            this.con_prep = con_prep;
            this.stock_critico = stock_critico;
        }

        public bool AddBebestible(BebestibleBLL objaux)
        {
            BebestibleDAL bd = new BebestibleDAL();
            bd.nombre_beb = this.nombre_beb;
            bd.marca = this.marca;
            bd.precio = this.precio;
            bd.stock = this.stock;
            bd.stock_bar = this.stock_bar;
            bd.imagen = this.imagen;
            bd.habilitado = this.habilitado;
            bd.con_prep = this.con_prep;
            bd.stock_critico = this.stock_critico;
            return bd.AgregarBebestible(bd);

        }
        public DataTable Allbebestible()
        {
            BebestibleDAL li = new BebestibleDAL();
            DataTable dt = li.Get_allbebestible();
            return dt;
        }

        public DataTable NombreBebestibleList(string nombre_beb)
        {
            BebestibleDAL bebe = new BebestibleDAL();
            DataTable dt = bebe.BusarBebestiblenombre(nombre_beb);
            return dt;
        }

        public DataTable listarmodificar(int id_bebestible)
        {
            BebestibleDAL li = new BebestibleDAL();
            DataTable dt = li.listarparamodi(id_bebestible);
            return dt;
        }

        public void AlterinBebestible(BebestibleBLL objaux)
        {
            BebestibleDAL aiu = new BebestibleDAL();
            aiu.nombre_beb = this.nombre_beb;
            aiu.marca = this.marca;
            aiu.precio = this.precio;
            aiu.stock = this.stock;
            aiu.stock_bar = this.stock_bar;
            aiu.habilitado = this.habilitado;
            aiu.con_prep = this.con_prep;
            aiu.id_bebestible = this.id_bebestible;
            aiu.stock_critico = this.stock_critico;
            aiu.AlterBebestible(aiu);
        }

        public void Alterinhabilitado(BebestibleBLL objaux)
        {
            BebestibleDAL aiu = new BebestibleDAL();
            aiu.id_bebestible = this.id_bebestible;
            aiu.Altereliminar(aiu);
        }

        public int Get_bebyid(string nom)
        {
            BebestibleDAL pd = new BebestibleDAL();
            return pd.Get_bebyid(nom);
        }
    }
}
