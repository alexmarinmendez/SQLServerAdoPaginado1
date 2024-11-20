using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApplication1.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Dao
{
    public class ClientesDao
    {
        string cadena = ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString;

        public List<Clientes> ListarClientes()
        {
            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT IdCliente, NombreCliente, Direccion, Telefono, Pais FROM Clientes", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Clientes> lista = new List<Clientes>();
            Clientes obj;
            while (reader.Read())
            {
                obj = new Clientes()
                {
                    IdCliente = reader.GetString(0),
                    NombreCliente = reader.GetString(1),
                    Direccion = reader.GetString(2),
                    Telefono = reader.GetString(3),
                    Pais = reader.GetString(4),
                };
                lista.Add(obj);
            }
            reader.Close();
            conn.Close();
            return lista;
        }
    }
}