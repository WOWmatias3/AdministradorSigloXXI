using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class MesaBLL
    {

        public int Id_mesa { get; set; }
        public String Nombre_sala { get; set; }
        public int Capacidad { get; set; }

        public static MesaBLL instance = null;

        public MesaBLL()
        {

        }

        public static MesaBLL Getinstancia()
        {
            if (instance == null)
            {
                instance = new MesaBLL();
            }
            return instance;
        }

        public MesaBLL(int id_mesa,
        String nombre_sala,
        int capacidad)

        {
            this.Id_mesa = id_mesa;
            this.Nombre_sala = nombre_sala;
            this.Capacidad = capacidad;
        }



        public void AddMesa(MesaBLL objmesa)
        {
            MesaDAL md = new MesaDAL();
            md.Id_mesa = this.Id_mesa;
            md.Nombre_sala = this.Nombre_sala;
            md.Capacidad = this.Capacidad;
            md.AddMesa(md);
        }

        public bool Get_nume(int id)
        {
            MesaDAL md = new MesaDAL();
            bool existe = md.Getnume(id);
            return existe;
        }

        public DataTable GetAllmesas()
        {
            MesaDAL md = new MesaDAL();
            DataTable dt = md.Getallmesas();
            return dt;
        }

        public DataTable Getmesasala(string sala)
        {
            MesaDAL md = new MesaDAL();
            DataTable dt = md.Getmesasala(sala);
            return dt;
        }

        public DataTable GetmesaNum(int num)
        {
            MesaDAL md = new MesaDAL();
            DataTable dt = md.GetMesaNum(num);
            return dt;
        }

        public void DeleteMesa(int id)
        {
            MesaDAL md = new MesaDAL();
            md.DeleteMesa(id);
        }

        public DataTable GetMesaterra()
        {
            MesaDAL md = new MesaDAL();
            DataTable dt = md.Getmesaterra();
            return dt;
        }
        public DataTable GetMesaTerra2()
        {
            MesaDAL md = new MesaDAL();
            DataTable dt = md.Getmesaterra2();
            return dt;
        }
        public DataTable GetMesaComedor()
        {
            MesaDAL md = new MesaDAL();
            DataTable dt = md.GetmesaComedor();
            return dt;
        }

        public void Alter_Mesa(MesaBLL objmesa)
        {
            MesaDAL md = new MesaDAL();
            md.Id_mesa = this.Id_mesa;
            md.Nombre_sala = this.Nombre_sala;
            md.Capacidad = this.Capacidad;
            md.AlterMesa(md);
        }
    }
}
