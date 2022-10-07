using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;
using System.IO;
using APICSarp.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace APICSarp.Controllers
{
    // route

    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    [ApiController]
    public class KomentarController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public KomentarController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        [HttpGet]
        public string Get()
        {
            string query = @"
                SELECT * FROM komentar
            ";
            DataTable table = new DataTable();
            string tabletext = "";
            string sqlDataSource = _configuration.GetConnectionString("DBConn");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return JsonConvert.SerializeObject(table); 
        }
        [HttpPost]
        public JsonResult Post(Komentar k)
        {
            string query = @"
                INSERT INTO komentar(nama,komentar) values(@nama,@komentar)
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DBConn");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@nama", k.nama);
                    myCommand.Parameters.AddWithValue("@komentar", k.komentar);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Komentar ditambahkan!");
        }
        [HttpPut]
        public JsonResult Put(Komentar k)
        {
            string query = @"
                UPDATE komentar
                SET nama = @nama, komentar = @komentar
                WHERE id = @id
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DBConn");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@nama", k.nama);
                    myCommand.Parameters.AddWithValue("@komentar", k.komentar);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Update Sukses");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                DELETE FROM komentar
                WHERE id = @id
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DBConn");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Komentar Dihapus!");
        }
    }
}