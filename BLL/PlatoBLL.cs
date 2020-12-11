using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PlatoBLL
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
        public static PlatoBLL instance = null;

        public PlatoBLL()
        {

        }

        public static PlatoBLL Getinstancia()
        {
            if (instance == null)
            {
                instance = new PlatoBLL();
            }
            return instance;
        }

        public PlatoBLL(int id_plato,
        String nombre_plato,
        int precio,
        String categoria,
        Byte[] imagen,
        String habilitado)

        {
            this.Id_plato = id_plato;
            this.Nombre_plato = nombre_plato;
            this.Precio = precio;
            this.Categoria = categoria;
            this.Imagen = imagen;
            this.Habilitado = habilitado;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.ing_id = ing_id;
        }

        public bool insert_plato(PlatoBLL objaux,int cant)
        {
            PlatoDAL plDAL = new PlatoDAL();
            return plDAL.insertPlato(this.Imagen, this.Nombre_plato, this.Precio, this.Categoria, this.Habilitado, this.descripcion,cant);
        }
        public bool crea_relacion_plato_ing(int id, int cant)
        {
            PlatoDAL plDAL = new PlatoDAL();
            return plDAL.CreaRelacion(cant, id);
        }
        public void DesPlato(PlatoBLL objaux)
        {
            PlatoDAL aiu = new PlatoDAL();
            aiu.Id_plato = this.Id_plato;
            aiu.DesPlato(aiu);
        }
        public DataTable platoList(string Nombre_plato)
        {
            PlatoDAL li = new PlatoDAL();
            DataTable dt = li.GetPlatoByNombre(Nombre_plato);
            return dt;
        }
        public DataTable platoByID(int idplato)
        {
            PlatoDAL li = new PlatoDAL();
            DataTable dt = li.GetPlatoByID(idplato);
            return dt;
        }

        public DataTable AllplatosList()
        {
            PlatoDAL li = new PlatoDAL();
            DataTable dt = li.GetAllplatos();
            return dt;
        }
        public DataTable platoRela(int idpla)
        {
            PlatoDAL li = new PlatoDAL();
            DataTable dt = li.GetRelacionIngredientes(idpla);
            return dt;
        }


        public DataTable DatosDesPlato(int idpla)
        {
            PlatoDAL li = new PlatoDAL();
            return li.DATOSDeshablitarPlato(idpla);
        }
        public void alter_plato(PlatoBLL objaux)
        {
            PlatoDAL aiu = new PlatoDAL();
            aiu.Nombre_plato = this.Nombre_plato;
            aiu.Precio = this.Precio;
            aiu.Categoria = this.Categoria;
            aiu.Habilitado = this.Habilitado;
            aiu.descripcion = this.descripcion;
            aiu.Id_plato = this.Id_plato;
            aiu.alter_infoplato(aiu);
        }
        public void Eliminar_Ing(PlatoBLL objaux)
        {
            PlatoDAL pd = new PlatoDAL();
            pd.Id_plato = this.Id_plato;
            pd.Eliminar_Ing(pd);
        }
        public bool Modifica_relacion_ing(int idplato, int id, double cant)
        {
            PlatoDAL plDAL = new PlatoDAL();
            return plDAL.Modifica_relacion_ing(idplato, cant, id);
        }
        public bool Getplatobyid(int idpla)
        {
            PlatoDAL plDAL = new PlatoDAL();
            bool existe = plDAL.Getplatobyid(idpla);
            return existe;
        }
    }
}
