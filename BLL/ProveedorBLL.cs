using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ProveedorBLL
    {

        public int id_proveedor { get; set; }
        public String nombre_proveedor { get; set; }
        public int fono_proveedor { get; set; }
        public String mail_proveedor { get; set; }
        public String direccion_proveedor { get; set; }
        public String descripcion { get; set; }

        public static ProveedorBLL instance = null;

        public ProveedorBLL()
        {

        }

        public static ProveedorBLL Getinstancia()
        {
            if (instance == null)
            {
                instance = new ProveedorBLL();
            }
            return instance;
        }

        public ProveedorBLL(int id_proveedor,
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


        public void add_prov(ProveedorBLL objprov)
        {
            ProveedorDAL pd = new ProveedorDAL();
            pd.nombre_proveedor = this.nombre_proveedor;
            pd.fono_proveedor = this.fono_proveedor;
            pd.mail_proveedor = this.mail_proveedor;
            pd.direccion_proveedor = this.direccion_proveedor;
            pd.descripcion = this.descripcion;
            pd.AgregarProv(pd);
        }


        public void deleteprov(int id)
        {
            ProveedorDAL pd = new ProveedorDAL();
            pd.id_proveedor = this.id_proveedor;
            pd.DeleteProv(id);
        }


        public bool GetProvIdEXISTE(int id)
        {
            ProveedorDAL pd = new ProveedorDAL();
            return pd.GetprovidExiste(id);
        }

        public DataTable Allprovlist()
        {
            ProveedorDAL li = new ProveedorDAL();
            DataTable dt = li.Getallproveedores();
            return dt;
        }

        public DataTable Get_provaux()
        {
            ProveedorDAL li = new ProveedorDAL();
            return li.Get_provaux();
        }

        public DataTable Getallprovcbb()
        {
            ProveedorDAL li = new ProveedorDAL();
            return li.Get_AllProvCbb();
        }
        public bool AllprovlistExiste(int id)
        {
            ProveedorDAL li = new ProveedorDAL();
            return li.GetprovidExiste(id);
        }


        public DataTable Allprovid(int id)
        {
            ProveedorDAL li = new ProveedorDAL();
            DataTable dt = li.Getprovid(id);
            return dt;
        }

        public DataTable Get_provnom(string nombre)
        {
            ProveedorDAL pd = new ProveedorDAL();
            DataTable dt = pd.Getprovnom(nombre);
            return dt;

        }

        public bool Get_provnomexiste(string nombre)
        {
            ProveedorDAL pd = new ProveedorDAL();
            return pd.Getprovnomexist(nombre);
        }
        public DataTable Getallprov()
        {
            ProveedorDAL li = new ProveedorDAL();
            DataTable dt = li.Get_allprov();
            return dt;
        }

        public void AlterProv(ProveedorBLL objprov)
        {
            ProveedorDAL pd = new ProveedorDAL();
            pd.id_proveedor = this.id_proveedor;
            pd.nombre_proveedor = this.nombre_proveedor;
            pd.fono_proveedor = this.fono_proveedor;
            pd.mail_proveedor = this.mail_proveedor;
            pd.direccion_proveedor = this.direccion_proveedor;
            pd.descripcion = this.descripcion;
            pd.AlterInfoProv(pd);

        }

        public DataTable GETALLP(int id)
        {
            ProveedorDAL li = new ProveedorDAL();
            DataTable dt = li.GETALLP(id);
            return dt;
        }


        public DataTable getallBebi()
        {
            ProveedorDAL ingDAL = new ProveedorDAL();
            DataTable dt = ingDAL.GetAllBebi();
            return dt;
        }

    }
}
