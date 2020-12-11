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
    public class usuarioBLL
    {
        public int id_usuario { get; set; }
        public string nom_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public string clave { get; set; }
        public string rol { get; set; }
        public int fono { get; set; }
        public string direccion { get; set; }
        public int rut { get; set; }


        public usuarioBLL()
        {
        }
        public usuarioBLL(int id_usuario, string nom_usuario, string clave, string rol, string apellido_usuario, int fono, string direccion, int rut)
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

        public bool getLogin(string nombreuser, string password)
        {
            usuarioDAL usrdal = new usuarioDAL();
            return usrdal.getLogin(nombreuser, password);
        }

        public int Getrut(string nombreuser, string password)
        {
            usuarioDAL usrdal = new usuarioDAL();
            return usrdal.Getrut(nombreuser, password);
        }

        public string Get_nombrecompleto(int rut)
        {
            usuarioDAL usrdal = new usuarioDAL();
            return usrdal.Get_nombrecompleto(rut);
        }


        public void AddUser(int rut, string nom, string pass, string rol, string estado)
        {
            usuarioDAL au = new usuarioDAL();
            au.AgregarUsuario(rut, nom, pass, rol, estado);
        }

        public void AddinfoUser(usuarioBLL objaux)
        {
            usuarioDAL aiu = new usuarioDAL();
            aiu.nom_usuario = this.nom_usuario;
            aiu.apellido_usuario = this.apellido_usuario;
            aiu.fono = this.fono;
            aiu.direccion = this.direccion;
            aiu.rut = this.rut;
            aiu.AddInfoUser(aiu);
        }

        public void DeleteUser(usuarioBLL objaux)
        {
            usuarioDAL aiu = new usuarioDAL();
            aiu.rut = this.rut;
            aiu.DeleteUser(aiu);
        }

        public void AlterInfoUser(usuarioBLL objaux)
        {
            usuarioDAL aiu = new usuarioDAL();
            aiu.nom_usuario = this.nom_usuario;
            aiu.apellido_usuario = this.apellido_usuario;
            aiu.fono = this.fono;
            aiu.direccion = this.direccion;
            aiu.rut = this.rut;
            aiu.AlterInfoUser(aiu);
        }


        public void AlterUser(int rutt, string nom, string roll, string pass, string estado)
        {
            usuarioDAL aiu = new usuarioDAL();
            aiu.AlterUser(rutt, nom, roll, pass, estado);
        }


        public DataTable userList(int rut)
        {
            usuarioDAL li = new usuarioDAL();
            DataTable dt = li.Getuser(rut);
            return dt;
        }


        public DataTable AllUserList()
        {
            usuarioDAL li = new usuarioDAL();
            DataTable dt = li.GetAllUser();
            return dt;
        }

        public DataTable UserRolList(string rol)
        {
            usuarioDAL li = new usuarioDAL();
            DataTable dt = li.GetUserForRol(rol);
            return dt;
        }

        public bool GetUserByRut(int rut)
        {
            usuarioDAL li = new usuarioDAL();
            bool existe = li.GetuserByRut(rut);
            return existe;

        }
        public bool Getnick(string nick)
        {
            usuarioDAL li = new usuarioDAL();
            return li.GetNick(nick);
        }
    }
}