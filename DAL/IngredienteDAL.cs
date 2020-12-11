using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IngredienteDAL
    {
        public int id_ingrediente { get; set; }
        public string nombre_ingrediente { get; set; }
        public string proveedor { get; set; }
        public string habilitado { get; set; }
        public float stock { get; set; }
        public float stock_cocina { get; set; }

        public int stock_critico { get; set; }


        public IngredienteDAL()
        {
        }
        public IngredienteDAL(int id_ingrediente,
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

        public DataTable GetAllIng()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_alling", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter output = cm.Parameters.Add("my_cursor", OracleDbType.RefCursor);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                con.Open();
                cm.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
                con.Close();
                using (DataTable dt = new DataTable())
                {
                    OracleDataAdapter adapter = new OracleDataAdapter(cm);
                    adapter.Fill(dt);
                    return dt;

                }
            }
        }
        public bool AgregarIngrediente(IngredienteDAL objUserdal)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleCommand objCmd = new OracleCommand();
                    objCmd.Connection = con;
                    objCmd.CommandText = "InsertarIngrediente";
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nombre_ingrediente;
                    objCmd.Parameters.Add("p_provee", OracleDbType.Varchar2).Value = proveedor;
                    objCmd.Parameters.Add("p_habilitado", OracleDbType.Varchar2).Value = habilitado;
                    objCmd.Parameters.Add("p_stock", OracleDbType.Decimal).Value = stock;
                    objCmd.Parameters.Add("p_stock_coci", OracleDbType.Decimal).Value = stock_cocina;
                    objCmd.Parameters.Add("p_stockcr", OracleDbType.Decimal).Value = stock_critico;

                    con.Open();
                    objCmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
                return false;
            }

        }

        public DataTable Get_allingredientes()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_allingredientes", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter output = cm.Parameters.Add("my_cursor", OracleDbType.RefCursor);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                con.Open();
                cm.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
                con.Close();
                using (DataTable dt = new DataTable())
                {
                    OracleDataAdapter adapter = new OracleDataAdapter(cm);
                    adapter.Fill(dt);
                    return dt;

                }
            }
        }

        public DataTable BusarINGnombre(string nombre_ingrediente)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_nomingrediente", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;

                cm.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nombre_ingrediente;

                OracleParameter output = cm.Parameters.Add("my_cursor", OracleDbType.RefCursor);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                con.Open();
                cm.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
                con.Close();
                using (DataTable dt = new DataTable())
                {
                    OracleDataAdapter adapter = new OracleDataAdapter(cm);
                    adapter.Fill(dt);
                    return dt;

                }
            }
        }

        public DataTable listarparamodi(int id_ingrediente)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_IDingrediente", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;

                cm.Parameters.Add("p_id", OracleDbType.Int32).Value = id_ingrediente;

                OracleParameter output = cm.Parameters.Add("my_cursor", OracleDbType.RefCursor);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                con.Open();
                cm.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
                con.Close();
                using (DataTable dt = new DataTable())
                {
                    OracleDataAdapter adapter = new OracleDataAdapter(cm);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void AlterIngrediente(IngredienteDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("alter_Ingrediente", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nombre_ingrediente;
                    cm.Parameters.Add("p_proveedor", OracleDbType.Varchar2).Value = proveedor;
                    cm.Parameters.Add("p_habilitado", OracleDbType.Varchar2).Value = habilitado;
                    cm.Parameters.Add("p_stock", OracleDbType.Double).Value = stock;
                    cm.Parameters.Add("p_stock_cocina", OracleDbType.Int32).Value = stock_cocina;
                    cm.Parameters.Add("p_stock_critico", OracleDbType.Int32).Value = stock_critico;
                    cm.Parameters.Add("ide", OracleDbType.Double).Value = id_ingrediente;
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }
        }


        public void Altereliminaring(IngredienteDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("alter_estadoingrediente", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("ide", OracleDbType.Varchar2).Value = id_ingrediente;
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }
        }

        public int Get_iding_nomb(string nombre_ins)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_idingbynombre", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("nomb", OracleDbType.Varchar2).Value = nombre_ins;
                OracleParameter output = cm.Parameters.Add("my_cursor", OracleDbType.Int32);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                con.Open();
                try
                {
                    cm.ExecuteNonQuery();
                    return Int32.Parse(output.Value.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("" + ex);
                    return 0;
                }


            }
        }

    }
}
