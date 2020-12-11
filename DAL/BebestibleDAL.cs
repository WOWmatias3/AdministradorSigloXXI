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
    public class BebestibleDAL
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


        public BebestibleDAL()
        {
        }
        public BebestibleDAL(int id_bebestible,
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


        public bool AgregarBebestible(BebestibleDAL objUserdal)
        {
            try
            {

                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleCommand objCmd = new OracleCommand();
                    objCmd.Connection = con;
                    objCmd.CommandText = "InsertarBebestible";
                    objCmd.BindByName = true;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nombre_beb;
                    objCmd.Parameters.Add("p_marc", OracleDbType.Varchar2).Value = marca;
                    objCmd.Parameters.Add("p_preci", OracleDbType.Int32).Value = precio;
                    objCmd.Parameters.Add("p_stock", OracleDbType.Int32).Value = stock;
                    objCmd.Parameters.Add("p_stock_bar", OracleDbType.Int32).Value = stock_bar;
                    objCmd.Parameters.Add("p_imag", OracleDbType.Blob).Value = imagen;
                    objCmd.Parameters.Add("p_habilit", OracleDbType.Varchar2).Value = habilitado;
                    objCmd.Parameters.Add("con_prep", OracleDbType.Varchar2).Value = con_prep;
                    objCmd.Parameters.Add("stockcr", OracleDbType.Int32).Value = stock_critico;
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

        public DataTable Get_allbebestible()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_all_bebestible", con);
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

        public DataTable BusarBebestiblenombre(string nombre_beb)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_nomBebestible", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;

                cm.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nombre_beb;

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

        public DataTable listarparamodi(int id_bebestible)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_IDbebestible", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;

                cm.Parameters.Add("p_id", OracleDbType.Int32).Value = id_bebestible;

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

        public void AlterBebestible(BebestibleDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("alter_bebestible", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nombre_beb;
                    cm.Parameters.Add("p_marca", OracleDbType.Varchar2).Value = marca;
                    cm.Parameters.Add("p_precio", OracleDbType.Int32).Value = precio;
                    cm.Parameters.Add("p_stock", OracleDbType.Int32).Value = stock;
                    cm.Parameters.Add("p_stock_bar", OracleDbType.Int32).Value = stock_bar;
                    cm.Parameters.Add("p_habilitado", OracleDbType.Varchar2).Value = habilitado;
                    cm.Parameters.Add("p_con_prep", OracleDbType.Varchar2).Value = con_prep;
                    cm.Parameters.Add("p_stock_critico", OracleDbType.Int32).Value = stock_critico;
                    cm.Parameters.Add("ide", OracleDbType.Int32).Value = id_bebestible;
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

        public void Altereliminar(BebestibleDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("alter_estadobebestible", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("ide", OracleDbType.Varchar2).Value = id_bebestible;
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




        public int Get_bebyid(string nom)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_bebyid", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("nomb", OracleDbType.Varchar2).Value = nom;
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
