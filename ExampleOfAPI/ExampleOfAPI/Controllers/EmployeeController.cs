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

        [HttpGet]
        public JsonResult Get()
        {
            List<Employee>employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MasterDataBase")))
            {
                SqlCommand command= connection.CreateCommand();
                command.CommandType= CommandType.Text;
                command.CommandText = "select * from Employee";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
                foreach(DataRow dr in dt.Rows)
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
    }
}
