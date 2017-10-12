using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Login
{
    class ConsultaSQL
    {

        private SqlConnection conexion = new SqlConnection(@"Data Source = (local); Initial Catalog = Pruebaf; Integrated Security = True");
        private DataSet ds;
        public DataTable Mostrar() {

            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Productos", conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds,"tabla");
            conexion.Close();
            return ds.Tables["tabla"];


        }

        public DataTable Buscar(string nombre)
        {

            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Productos WHERE Nombre like '%(0)%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];


        }

        public bool Insertar(string idproducto, string nombre, string edad)
        {
            conexion.Open();

            SqlCommand cmd = new SqlCommand(string.Format("INSERT into Productos VALUES ('{0}',{1})", new string[] {nombre, edad }),conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;

            
        }

        public bool Eliminar(string idproducto)
        {
            conexion.Open();

            SqlCommand cmd = new SqlCommand(string.Format("DELETE from Productos WHERE idproducto = {0}",idproducto),conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;


        }
        public bool Actualizar(string idproducto, string nombre, string edad)
        {
            conexion.Open();

            SqlCommand cmd = new SqlCommand(string.Format("UPDATE Productos set Nombre = '{0}', Edad = '{1}' WHERE idproductos = {2}",new string[] {nombre, edad,idproducto }), conexion);
           int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;


        }



    }
}
