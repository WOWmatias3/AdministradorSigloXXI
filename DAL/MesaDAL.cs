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
    public class MesaDAL
    {

        public int Id_mesa { get; set; }
        public String Nombre_sala { get; set; }
        public int Capacidad { get; set; }

        public static MesaDAL instance = null;

        public MesaDAL()
        {

        }

        public static MesaDAL Getinstancia()
        {
            if (instance == null)
            {
                instance = new MesaDAL();
            }
            return instance;
        }

        public MesaDAL(int id_mesa,
        String nombre_sala,
        int capacidad)

        {
            this.Id_mesa = id_mesa;
            this.Nombre_sala = nombre_sala;
            this.Capacidad = capacidad;
        }


        public void AddMesa(MesaDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("AddMesa", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("p_id", OracleDbType.Varchar2).Value = Id_mesa;
                    cm.Parameters.Add("p_sala", OracleDbType.Varchar2).Value = Nombre_sala;
                    cm.Parameters.Add("p_cap", OracleDbType.Int32).Value = Capacidad;

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


        public void AlterMesa(MesaDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("Altermesa", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("sala", OracleDbType.Varchar2).Value = Nombre_sala;
                    cm.Parameters.Add("cap", OracleDbType.Int32).Value = Capacidad;
                    cm.Parameters.Add("id_", OracleDbType.Int32).Value = Id_mesa;

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

        public void DeleteMesa(int id)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("deletemesa", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("ID_", OracleDbType.Varchar2).Value = id;
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




        public bool Getnume(int rut)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Getnume", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;

                cm.Parameters.Add("ID_", OracleDbType.Int32).Value = rut;

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
                    int contador = dt.Rows.Count;
                    bool existe = true;
                    if (contador > 0)
                    {
                        DataRow row = dt.Rows[0];
                        string num = row[0].ToString();
                        if (num != "")
                        {
                            existe = true;
                        }
                        return existe;
                    }
                    else
                    {
                        existe = false;
                        return existe;
                    }

                }
            }
        }


        public DataTable Getallmesas()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_allmesas", con);
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


        public DataTable Getmesasala(string sala)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_Mesasala", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("sala", OracleDbType.Varchar2).Value = sala;
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


        public DataTable GetMesaNum(int num)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_mesaid", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("ID_", OracleDbType.Int32).Value = num;
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

        public DataTable Getmesaterra()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_mesaterraza", con);
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
        public DataTable Getmesaterra2()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Getmesaterra2", con);
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



        public DataTable GetmesaComedor()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("GetMesacomedor", con);
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
