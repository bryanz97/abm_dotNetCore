using System;    
using System.Collections.Generic;    
using System.Data;        
using System.Linq;    
using System.Threading.Tasks;    
using System.Data.SqlClient;
    
namespace mvc_test.Models    
{    
    public class EmployeeDataAccessLayer     
    {    
        string connectionString = "Data Source=DESKTOP-DPPC2T9;Database=master;Integrated Security=TRUE";    
     
        public void AddClientes(Clientes clientes)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spAddClientes", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@nombre", clientes.nombre);    
                cmd.Parameters.AddWithValue("@apellido", clientes.apellido);    
                cmd.Parameters.AddWithValue("@documento", clientes.documento);    
                cmd.Parameters.AddWithValue("@fecha_nacimiento", clientes.fecha_nacimiento);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }
        
        public void UpdateClientes(Clientes clientes)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spUpdateCliente", con);    
                cmd.CommandType = CommandType.StoredProcedure;    

                cmd.Parameters.AddWithValue("@ClieId", clientes.ID);        
                cmd.Parameters.AddWithValue("@Nombre", clientes.nombre);    
                cmd.Parameters.AddWithValue("@Apellido", clientes.apellido);    
                cmd.Parameters.AddWithValue("@documento", clientes.documento);    
                cmd.Parameters.AddWithValue("@fecha_nacimiento", clientes.fecha_nacimiento);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }

        public Clientes GetClientData(int? id)    
        {    
            Clientes Cliente = new Clientes();// ver como usar un patron de disenho con las instanciaciones    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                string sqlQuery = "SELECT * FROM Clientes WHERE ID= " + id;    
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Cliente.ID = Convert.ToInt32(rdr["ID"]);    
                    Cliente.nombre = rdr["nombre"].ToString();    
                    Cliente.apellido = rdr["apellido"].ToString();
                    Cliente.documento = rdr["documento"].ToString();     
                    Cliente.fecha_nacimiento = DateTime.Parse(rdr["fecha_nacimiento"].ToString());    
                    
                }    
            }    
            return Cliente;    
        }    
        
        //To Delete the record on a particular employee    
        public void DeleteCliente(int? id)    
        {    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spDeleteCliente", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@ClieId", id);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
        
    

        public IEnumerable<Clientes> GetAllClientes()    
        {    
            List<Clientes> lstClientes = new List<Clientes>();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Clientes cliente = new Clientes();    
    
                    cliente.ID = Convert.ToInt32(rdr["ID"]);    
                    cliente.nombre = rdr["nombre"].ToString();    
                    cliente.apellido = rdr["apellido"].ToString();    
                    cliente.documento = rdr["documento"].ToString();    
                    cliente.fecha_nacimiento = DateTime.Parse(rdr["fecha_nacimiento"].ToString());    
    
                    lstClientes.Add(cliente);    
                }    
                con.Close();    
            }    
            return lstClientes;    
        }   
       
    }    
}    