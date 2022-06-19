using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
   
    public class ADOEstatus : ICRUDEstatus
    {  
      string _Conexion = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
        List<Estatus> _list;
        private SqlCommand comando;

        public List<Estatus> Consultar()
        {
            _list = new List<Estatus>();
            string query;
            SqlCommand comando;
            query = $"select * from EstatusAlumnos";

            using (SqlConnection con = new SqlConnection(_Conexion))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader adapter = comando.ExecuteReader();
                while (adapter.Read())
                {
                    _list.Add(
                        new Estatus()
                        {
                            id = Convert.ToInt32(adapter["id"]),
                            clave = adapter["clave"].ToString(),
                            nombre = adapter["Nombre"].ToString(),
                        }
                        );
                }
                con.Close();
                foreach (Estatus item in _list)
                {
                    Console.WriteLine($"ID: {item.id} clave: {item.clave} nombre: {item.nombre}");
                }
            }
            return _list;

        }

        public Estatus Consultar(int id)
        {
           
            string query;
            SqlCommand comando;
            Estatus estatus = new Estatus(); 
            query = $"select * from EstatusAlumnos where id = {id}";

            using (SqlConnection con = new SqlConnection(_Conexion))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader adapter = comando.ExecuteReader();
                while (adapter.Read())
                {
                estatus = new Estatus()
                     {
                    id = Convert.ToInt32(adapter["id"]),
                    clave = adapter["clave"].ToString(),
                    nombre = adapter["Nombre"].ToString(),
                     };
                }
                con.Close();
            }
            return estatus;
        }

        public int Agregar(Estatus estatus)
        {
            string query;
            query = $"agregarEstatus";
            int idEstado;

            using (SqlConnection con = new SqlConnection(_Conexion))
            {
                comando=new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("clave", estatus.clave);
                comando.Parameters.AddWithValue("nombre", estatus.nombre);
                con.Open();
                idEstado = (Int32)comando.ExecuteScalar(); 
                con.Close();
            }
            return idEstado;
        }

        public void Actulizar(Estatus estatus)
        {
            string query;
            query = $"UPDATE  EstatusAlumnos SET clave = '{estatus.clave}',[Nombre] = '{estatus.nombre}' WHERE  id = {estatus.id}";
            using (SqlConnection con = new SqlConnection(_Conexion))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }

        }

        public void Eliminar(Estatus estatus)
        {
            Estatus estat = new Estatus();
            string query;
            query = $" DELETE FROM [dbo].[EstatusAlumnos] WHERE  id =  {estatus.id}";
            using (SqlConnection con = new SqlConnection(_Conexion))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();

            }
        }
        //Estatus Consultar(int id);
        //int Agregar(Estatus estatus);
        //void Actulizar(Estatus estatus);
        //void Eliminar(int id);
    }
}
