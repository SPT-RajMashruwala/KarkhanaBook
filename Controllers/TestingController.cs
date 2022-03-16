using KarKhanaBook.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarKhanaBook.Controllers
{
    
    [ApiController]
    public class TestingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        string query;
        public TestingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("Testing")]
        public IActionResult Test() 
        {
            StringBuilder sqlcommand = new StringBuilder("select * from dbo.TakaSheet");
            sqlcommand.Append(" where  dbo.TakaSheet.SlotNumber LIKE '1'");
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(sqlcommand.ToString(), myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return Ok(new Testing().Test(table));
        }
    }
}
