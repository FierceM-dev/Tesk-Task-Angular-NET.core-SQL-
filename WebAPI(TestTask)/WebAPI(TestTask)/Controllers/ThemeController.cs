using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPI_TestTask_.Models;

namespace WebAPI_TestTask_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ThemeController (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select ThemeId, ThemeName from dbo.Theme";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ReportAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Theme theme)
        {
            string query = @"
                    insert into dbo.Theme values
                    ('" + theme.ThemeName + @"')
                    ";
            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("ReportAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added successfully");
        }

        [HttpPut]
        public JsonResult Put(Theme theme)
        {
            string query = @"
                    update dbo.Theme set ThemeName = '" + theme.ThemeName + @"'
                    where ThemeId = " + theme.ThemeId + @"";
            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("ReportAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated successfully");
        }
    }
}
