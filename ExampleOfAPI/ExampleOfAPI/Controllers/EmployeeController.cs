using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Configuration;
using System.Xml.Linq;
using ExampleOfAPI.Model;
using System.Data.SqlClient;
using ExampleOfAPI.Controllers;

namespace ExampleOfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // to get the employee details.
        [HttpGet]
        public JsonResult Get()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MasterDataBase")))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Employee";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    employees.Add(new Employee
                    {
                        EmpID = Convert.ToInt32(dr["EmpID"]),
                        EmpName = dr["EmpName"].ToString(),
                        Emp_Email = dr["Emp_Email"].ToString(),
                    });
                }
            }
            return new JsonResult(employees);

        }

        //insert
        [HttpPut]
        public JsonResult insert(Employee employee)
        {
            int id = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MasterDataBase")))
                {
                    SqlCommand sqlCommand = new SqlCommand("InsertData", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@EmpID", SqlDbType.Int).Value = employee.EmpID;
                    sqlCommand.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = employee.EmpName.ToString();
                    sqlCommand.Parameters.Add("@Emp_Email", SqlDbType.VarChar).Value = employee.Emp_Email.ToString();
                    connection.Open();
                    id = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    if (id > 0)
                    {
                        return new JsonResult(employee);
                    }
                    else
                    {
                        return new JsonResult("no records");
                    }
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        //update
        [HttpPost]
        public JsonResult update(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MasterDataBase")))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@EmpID", SqlDbType.Int).Value = employee.EmpID;
                    command.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = employee.EmpName;
                    command.Parameters.Add("@Emp_Email", SqlDbType.VarChar).Value = employee.Emp_Email;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return new JsonResult(employee);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        //delete
        [HttpDelete]
        public JsonResult delemp(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MasterDataBase")))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@EmpID", SqlDbType.Int).Value = employee.EmpID;
                    command.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = employee.EmpName;
                    command.Parameters.Add("@Emp_Email", SqlDbType.VarChar).Value = employee.Emp_Email;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return new JsonResult(employee);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }
    }
}        
