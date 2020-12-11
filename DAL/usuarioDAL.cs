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
    public class usuarioDAL
    {
        public int id_usuario { get; set; }
        public string nom_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public string clave { get; set; }
        public string rol { get; set; }

        public int fono { get; set; }
        public string direccion { get; set; }
        public int rut { get; set; }


        public usuarioDAL()
        {
        }
        public usuarioDAL(int id_usuario, string nom_usuario, string clave, string rol, string apellido_usuario, int fono, string direccion, int rut)
        {
            this.id_usuario = id_usuario;
            this.nom_usuario = nom_usuario;
            this.clave = clave;
            this.rol = rol;
            this.apellido_usuario = apellido_usuario;
            this.fono = fono;
            this.direccion = direccion;
            this.rut = rut;
        }

        private string encriptador(string palabra)
        {
            SHA256 sha = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha.ComputeHash(encoding.GetBytes(palabra));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public bool getLogin(string nomuser, string pass)
        {
            try
            {

                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("get_userpass", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("USERNAME", OracleDbType.Varchar2).Value = nomuser;
                OracleParameter output = com.Parameters.Add("my_cursor", OracleDbType.RefCursor);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                com.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
                string shaword = encriptador(pass);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        nom_usuario = reader[1].ToString();
                        clave = reader[2].ToString();
                        rol = reader[3].ToString();
                        if (nom_usuario == nomuser && clave == shaword && rol == "Administrador")
                        {
                            con.Close();
                            return true;
                        }

                    }
                }
                con.Close();

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int Getrut(string nomuser, string pass)
        {
            try
            {

                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("get_userpass", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("USERNAME", OracleDbType.Varchar2).Value = nomuser;
                OracleParameter output = com.Parameters.Add("my_cursor", OracleDbType.RefCursor);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                com.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
                string shaword = encriptador(pass);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rut = Int32.Parse(reader[0].ToString());
                        nom_usuario = reader[1].ToString();
                        clave = reader[2].ToString();
                        rol = reader[3].ToString();
                        if (nom_usuario == nomuser && clave == shaword && rol == "Administrador")
                        {
                            con.Close();
                            return rut;
                        }

                    }
                }
                con.Close();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
                return 0;
            }
        }






        public void AddInfoUser(usuarioDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("USER_INFO_INSERT", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nom_usuario;
                    cm.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = apellido_usuario;
                    cm.Parameters.Add("p_fono", OracleDbType.Int32).Value = fono;
                    cm.Parameters.Add("p_direccion", OracleDbType.Varchar2).Value = direccion;
                    cm.Parameters.Add("p_id_usuario", OracleDbType.Int32).Value = rut;
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




        public void AgregarUsuario(int rut, string nom, string pass, string rol, string estado)
        {
            try
            {

                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleCommand objCmd = new OracleCommand();
                    objCmd.Connection = con;
                    objCmd.CommandText = "INSERTARUSUARIO";
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("p_id", OracleDbType.Int32).Value = rut;
                    objCmd.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nom;
                    string encriptada = encriptador(pass);
                    objCmd.Parameters.Add("p_clave", OracleDbType.Varchar2).Value = encriptada;
                    objCmd.Parameters.Add("p_rol", OracleDbType.Varchar2).Value = rol;
                    objCmd.Parameters.Add("p_estado", OracleDbType.Varchar2).Value = estado;

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


        public void DeleteUser(usuarioDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {

                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("EliminarUsuario", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("rut", OracleDbType.Varchar2).Value = rut;
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


        public void AlterInfoUser(usuarioDAL objaux)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("alter_infouser", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nom_usuario;
                    cm.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = apellido_usuario;
                    cm.Parameters.Add("p_fono", OracleDbType.Int32).Value = fono;
                    cm.Parameters.Add("p_dir", OracleDbType.Varchar2).Value = direccion;
                    cm.Parameters.Add("rut", OracleDbType.Int32).Value = rut;
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


        public void AlterUser(int rutt, string nom, string roll, string pass, string estado)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cm = new OracleCommand("alter_user", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = nom;
                    cm.Parameters.Add("rut", OracleDbType.Int32).Value = rutt;
                    cm.Parameters.Add("p_rol", OracleDbType.Varchar2).Value = roll;
                    string encriptada = encriptador(pass);
                    cm.Parameters.Add("pass", OracleDbType.Varchar2).Value = encriptada;
                    cm.Parameters.Add("estado", OracleDbType.Varchar2).Value = estado;
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



        public DataTable Getuser(int rut)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_infouser", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;

                cm.Parameters.Add("rut", OracleDbType.Int32).Value = rut;

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


        public string Get_nombrecompleto(int rut)
        {
            try
            {
                using (OracleConnection con = new Conexion().conexion())
                {
                    OracleCommand cm = new OracleCommand("Get_nombre_usuarioby_Rut", con);
                    cm.BindByName = true;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add("p_rut", OracleDbType.Int32).Value = rut;
                    OracleParameter output = cm.Parameters.Add("my_cursor", OracleDbType.Varchar2,40);
                    output.Direction = System.Data.ParameterDirection.ReturnValue;
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    return output.Value.ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(""+ex);
                return "";
            }
        }



        public bool GetuserByRut(int rut)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_infouser", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("rut", OracleDbType.Int32).Value = rut;
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




        public bool GetNick(string nick)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_nickuser", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add("nick", OracleDbType.Varchar2).Value = nick;
                OracleParameter output = cm.Parameters.Add("my_cursor", OracleDbType.RefCursor);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                con.Open();
                try
                {
                    cm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("" + ex);
                }
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



        public DataTable GetAllUser()
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_allusers", con);
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


        public DataTable GetUserForRol(string rol)
        {
            using (OracleConnection con = new Conexion().conexion())
            {
                OracleCommand cm = new OracleCommand("Get_roluser", con);
                cm.BindByName = true;
                cm.CommandType = System.Data.CommandType.StoredProcedure;

                cm.Parameters.Add("p_rol", OracleDbType.Varchar2).Value = rol;

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