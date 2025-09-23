using Microsoft.AspNetCore.Mvc;
using WebCrud.Models;
using MySql.Data.MySqlClient;

namespace WebCrud.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IConfiguration _configuration;
        public ProdutoController (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
       public IActionResult Cadastrar()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
          string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

                string sql = "INSERT INTO produto (Prodnome,Proddescr) VALUES (@Prodnome, @Proddescr)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Prodnome", produto.Prodnome);
                command.Parameters.AddWithValue("@Proddescr", produto.Proddescr);
                command.ExecuteNonQuery();
            
            return RedirectToAction("Index", "Home");
        }
    }
}
