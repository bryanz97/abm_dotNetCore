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
    
        //To View all employees details      
        public IEnumerable<Employee> GetAllEmployees()    
        {    
            List<Employee> lstemployee = new List<Employee>();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Employee employee = new Employee();    
    
                    employee.ID = Convert.ToInt32(rdr["EmployeeID"]);    
                    employee.Name = rdr["Name"].ToString();    
                    employee.Gender = rdr["Gender"].ToString();    
                    employee.Department = rdr["Department"].ToString();    
                    employee.City = rdr["City"].ToString();    
    
                    lstemployee.Add(employee);    
                }    
                con.Close();    
            }    
            return lstemployee;    
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
    
                cmd.Parameters.AddWithValue("@nombre", clientes.nombre);    
                cmd.Parameters.AddWithValue("@apellido", clientes.apellido);    
                cmd.Parameters.AddWithValue("@documento", clientes.documento);    
                cmd.Parameters.AddWithValue("@fecha_nacimiento", clientes.fecha_nacimiento);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }

        public Clientes GetClientData(int? id)    
        {    
            Clientes Cliente = new Clientes();    
    
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
    
                cmd.Parameters.AddWithValue("@ID", id);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
        
        #region  Employee
        //To Update the records of a particluar employee    
        public void UpdateEmployee(Employee employee)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@EmpId", employee.ID);    
                cmd.Parameters.AddWithValue("@Name", employee.Name);    
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);    
                cmd.Parameters.AddWithValue("@Department", employee.Department);    
                cmd.Parameters.AddWithValue("@City", employee.City);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }

        //Get the details of a particular employee    
        public Employee GetEmployeeData(int? id)    
        {    
            Employee employee = new Employee();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;    
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    employee.ID = Convert.ToInt32(rdr["EmployeeID"]);    
                    employee.Name = rdr["Name"].ToString();    
                    employee.Gender = rdr["Gender"].ToString();    
                    employee.Department = rdr["Department"].ToString();    
                    employee.City = rdr["City"].ToString();    
                }    
            }    
            return employee;    
        }    
    
        //To Delete the record on a particular employee    
        public void DeleteEmployee(int? id)    
        {    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@EmpId", id);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        } 

        //To Add new employee record      
        public void AddEmployee(Employee employee)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@Name", employee.Name);    
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);    
                cmd.Parameters.AddWithValue("@Department", employee.Department);    
                cmd.Parameters.AddWithValue("@City", employee.City);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }   
        #endregion
    }    
}    