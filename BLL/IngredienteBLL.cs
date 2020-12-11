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
    public class IngredienteBLL
    {
        public int id_ingrediente { get; set; }
        public string nombre_ingrediente { get; set; }
        public string proveedor { get; set; }
        public string habilitado { get; set; }
        public float stock { get; set; }
        public float stock_cocina { get; set; }
        public int stock_critico { get; set; }


        public IngredienteBLL()
        {
        }
        public IngredienteBLL(int id_ingrediente,
                              string nombre_ingrediente,
                              string proveedor,
                              string habilitado,
                              float stock,
                              float stock_cocina,
                              int stock_critico)
        {
            this.id_ingrediente = id_ingrediente;
            this.nombre_ingrediente = nombre_ingrediente;
            this.proveedor = proveedor;
            this.habilitado = habilitado;
            this.stock = stock;
            this.stock_cocina = stock_cocina;
            this.stock_critico = stock_critico;
        }



        public DataTable getalling()
        {
            IngredienteDAL ingDAL = new IngredienteDAL();
            DataTable dt = ingDAL.GetAllIng();
            return dt;
        }
        public bool AddIngrediente(IngredienteBLL objaux)
        {
            IngredienteDAL ai = new IngredienteDAL();
            ai.nombre_ingrediente = this.nombre_ingrediente;
            ai.proveedor = this.proveedor;
            ai.habilitado = this.habilitado;
            ai.stock = this.stock;
            ai.stock_cocina = this.stock_cocina;
            ai.stock_critico = this.stock_critico;
            return ai.AgregarIngrediente(ai);
        }


        public DataTable AllingredientesList()
        {
            IngredienteDAL li = new IngredienteDAL();
            DataTable dt = li.Get_allingredientes();
            return dt;
        }

        public DataTable NombreIngredienteList(string nombre_ingrediente)
        {
            IngredienteDAL li = new IngredienteDAL();
            DataTable dt = li.BusarINGnombre(nombre_ingrediente);
            return dt;
        }

        public DataTable listarmodificar(int id_ingrediente)
        {
            IngredienteDAL li = new IngredienteDAL();
            DataTable dt = li.listarparamodi(id_ingrediente);
            return dt;
        }

        public void AlterinIngrediente(IngredienteBLL objaux)
        {
            IngredienteDAL aiu = new IngredienteDAL();
            aiu.nombre_ingrediente = this.nombre_ingrediente;
            aiu.proveedor = this.proveedor;
            aiu.habilitado = this.habilitado;
            aiu.stock = this.stock;
            aiu.stock_cocina = this.stock_cocina;
            aiu.id_ingrediente = this.id_ingrediente;
            aiu.stock_critico = this.stock_critico;
            aiu.AlterIngrediente(aiu);
        }

        public void Alterinhabilitadoing(IngredienteBLL objaux)
        {
            IngredienteDAL aiu = new IngredienteDAL();
            aiu.id_ingrediente = this.id_ingrediente;
            aiu.Altereliminaring(aiu);
        }


        public int Get_idbynom(string nom)
        {
            IngredienteDAL pd = new IngredienteDAL();
            return pd.Get_iding_nomb(nom);
        }

    }
}
