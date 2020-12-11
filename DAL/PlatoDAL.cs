using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlatoDAL
    {

        public int Id_plato { get; set; }
        public String Nombre_plato { get; set; }
        public int Precio { get; set; }
        public String Categoria { get; set; }
        public Byte[] Imagen { get; set; }
        public String Habilitado { get; set; }
        public double cantidad { get; set; }
        public int ing_id { get; set; }
        public string descripcion { get; set; }

        public static PlatoDAL instance = null;

        public PlatoDAL()
        {

        }

        public static PlatoDAL Getinstancia()
        {
            if (instance == null)
            {
                instance = new PlatoDAL();
            }
            return instance;
        }

        public PlatoDAL(int id_plato, String nombre_plato, int precio, String categoria, Byte[] imagen, String habilitado, string descripcion)
        {
            this.Id_plato = id_plato;
            this.Nombre_plato = nombre_plato;
            this.Precio = precio;
            this.Categoria = categoria;
            this.Imagen = imagen;
            this.Habilitado = habilitado;
            this.descripcion = descripcion;
        }

        public bool insertPlato(byte[] image, string nombre, int precio, string categoria, string habilitado, string descripcion,int cant)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("insert_plato", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("image", OracleDbType.Blob).Value = image;
                    cm.Parameters.Add("nombre", OracleDbType.Varchar2).Value = nombre;
                    cm.Parameters.Add("precio", OracleDbType.Int32).Value = precio;
                    cm.Parameters.Add("categoria", OracleDbType.Varchar2).Value = categoria;
                    cm.Parameters.Add("habilitado", OracleDbType.Varchar2).Value = habilitado;
                    cm.Parameters.Add("descripcion", OracleDbType.Varchar2).Value = descripcion;
                    cm.Parameters.Add("cantidad", OracleDbType.Int32).Value = cant;
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
                return false;
            }



        }
        public bool CreaRelacion(double cantidad, int ing_id)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("crea_relacion_plato_ing", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("cantidad", OracleDbType.Double).Value = cantidad;
                    cm.Parameters.Add("ing_id", OracleDbType.Int32).Value = ing_id;
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
                return false;
            }


        }
        public void DesPlato(PlatoDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("DeshabilitarPlato", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("id_", OracleDbType.Varchar2).Value = Id_plato;
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
        public DataTable GetPlatoByNombre(String Nombre_plato)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("GetPlatoByNombre", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;

                cm.Parameters.Add("nomb", OracleDbType.Varchar2).Value = Nombre_plato;

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
        public DataTable GetPlatoByID(int id_pla)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("GetPlatoByID", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;

                cm.Parameters.Add("id_pl", OracleDbType.Int32).Value = id_pla;

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



        public DataTable DATOSDeshablitarPlato(int id_pla)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("DATOSDeshabilitarPlato", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("id_pl", OracleDbType.Int32).Value = id_pla;

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



        public DataTable GetAllplatos()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_allplatos", con);
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
        public DataTable GetRelacionIngredientes(int idpla)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("GetRelacionIngredientes", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;

                cm.Parameters.Add("id_plato", OracleDbType.Varchar2).Value = idpla;
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
        public void alter_infoplato(PlatoDAL plato)
        {

            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("alter_infoplato", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = Nombre_plato;
                    cm.Parameters.Add("p_precio", OracleDbType.Int32).Value = Precio;
                    cm.Parameters.Add("p_categoria", OracleDbType.Varchar2).Value = Categoria;
                    cm.Parameters.Add("p_habilitado", OracleDbType.Varchar2).Value = Habilitado;
                    cm.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = descripcion;
                    cm.Parameters.Add("id_", OracleDbType.Int32).Value = Id_plato;
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
        public void Eliminar_Ing(PlatoDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("Eliminar_Ing", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("ide", OracleDbType.Varchar2).Value = Id_plato;
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
        public bool Modifica_relacion_ing(int idplato, double cantidad, int ing_id)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("Modifica_relacion_ing", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("id_plato", OracleDbType.Int32).Value = idplato;
                    cm.Parameters.Add("cantidad", OracleDbType.Double).Value = cantidad;
                    cm.Parameters.Add("ing_id", OracleDbType.Int32).Value = ing_id;
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
                return false;
            }
        }
        public bool Getplatobyid(int idpla)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                try
                {
                    OracleCommand cm = new OracleCommand("Getplatobyid", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("id_pl", OracleDbType.Int32).Value = idpla;
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
                        int num = dt.Rows.Count;
                        if (num > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("" + ex);
                    return false;
                }

            }
            
        }
    }
}
