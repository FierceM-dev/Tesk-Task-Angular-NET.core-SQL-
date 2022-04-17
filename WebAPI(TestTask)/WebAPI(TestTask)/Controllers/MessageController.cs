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
    public class MessageController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MessageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select MessageId, NameUser, EmailUser, Phone, Theme, MessageText from dbo.Message";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ReportAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
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
        public JsonResult Post(Message mes)
        {
            string query = @"
                    insert into dbo.Message 
                    (MessageText, EmailUser, Phone, Theme, NameUser) 
                    values
                    (
                    '" + mes.NameUser + @"',
                    '" + mes.EmailUser + @"',
                    '" + mes.Phone + @"',
                    '" + mes.Theme + @"',
                    '" + mes.MessageText + @"'
                    )
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
        public JsonResult Put(Message mes)
        {
            string query = @"
                    update dbo.Message set MessageText = '" + mes.NameUser + @"',
                    EmailUser = '" + mes.EmailUser + @"',
                    Phone = '" + mes.Phone + @"',
                    Theme = '" + mes.Theme + @"',
                    NameUser = '" + mes.MessageText + @"'
                    where MessageId = " + mes.MessageId + @"";
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
