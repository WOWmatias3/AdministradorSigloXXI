using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProveedorDAL
    {

        public int id_proveedor { get; set; }
        public String nombre_proveedor { get; set; }
        public int fono_proveedor { get; set; }
        public String mail_proveedor { get; set; }
        public String direccion_proveedor { get; set; }
        public String descripcion { get; set; }

        public static ProveedorDAL instance = null;

        public ProveedorDAL()
        {

        }

        public static ProveedorDAL Getinstancia()
        {
            if (instance == null)
            {
                instance = new ProveedorDAL();
            }
            return instance;
        }

        public ProveedorDAL(int id_proveedor,
        String nombre_proveedor,
        int fono_proveedor,
        String mail_proveedor,
        String direccion_proveedor,
        String descripcion)

        {
            this.id_proveedor = id_proveedor;
            this.nombre_proveedor = nombre_proveedor;
            this.fono_proveedor = fono_proveedor;
            this.mail_proveedor = mail_proveedor;
            this.direccion_proveedor = direccion_proveedor;
            this.descripcion = descripcion;
        }




        public void AgregarProv(ProveedorDAL objprov)
        {
            try
            {

                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleCommand objCmd = new OracleCommand();
                    objCmd.Connection = con;
                    objCmd.CommandText = "InsertarProveedor";
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nombre_proveedor;
                    objCmd.Parameters.Add("p_fono", OracleDbType.Int32).Value = fono_proveedor;
                    objCmd.Parameters.Add("p_mail", OracleDbType.Varchar2).Value = mail_proveedor;
                    objCmd.Parameters.Add("p_direccion", OracleDbType.Varchar2).Value = direccion_proveedor;
                    objCmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = descripcion;


                    con.Open();
                    objCmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }

        }


        public void DeleteProv(int id)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("EliminarProveedor", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("id_", OracleDbType.Varchar2).Value = id;
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

        public DataTable Getallproveedores()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_allproveedores", con);
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




        public DataTable Getprovid(int id)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_provId", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("ID_", OracleDbType.Varchar2).Value = id;
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



        public DataTable Get_provaux()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("get_provaux", con);
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



        public DataTable Get_AllProvCbb()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_allprov_CBB", con);
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


        public bool Getprovidexiste(int id)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_provId", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("ID_", OracleDbType.Varchar2).Value = id;
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
        }

        public bool GetprovidExiste(int id)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_provId", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("ID_", OracleDbType.Varchar2).Value = id;
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
        }



        public DataTable Getprovnom(string nombre)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("get_provnom", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("nombre_", OracleDbType.Varchar2).Value = nombre;
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


        public bool Getprovnomexist(string nombre)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("get_provnom", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("nombre_", OracleDbType.Varchar2).Value = nombre;
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
        }


        public DataTable Get_allprov()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_allprov", con);
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



        public void AlterInfoProv(ProveedorDAL objProv)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("alter_prov", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nombre_proveedor;
                    cm.Parameters.Add("p_fono", OracleDbType.Int32).Value = fono_proveedor;
                    cm.Parameters.Add("p_mail", OracleDbType.Varchar2).Value = mail_proveedor;
                    cm.Parameters.Add("p_dir", OracleDbType.Varchar2).Value = direccion_proveedor;
                    cm.Parameters.Add("p_desc", OracleDbType.Varchar2).Value = descripcion;
                    cm.Parameters.Add("id_", OracleDbType.Int32).Value = id_proveedor;
                    con.Open();
                    int num = cm.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }
        }


        public DataTable GETALLP(int id)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("GET_ALLP", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("id_", OracleDbType.Varchar2).Value = id;
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


        public DataTable GetAllBebi()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("get_allproveedor", con);
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

    }
}