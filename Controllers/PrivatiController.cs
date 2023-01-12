using SDA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDA.Controllers
{
    public class PrivatiController : Controller
    {
        // GET: Privati
        public ActionResult Index()
        {
            List<Clienti> ListaClienti = new List<Clienti>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SDADB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select IdCliente, Nome, Cognome, CodiceFiscale, LuogoNascita, Residenza, DataNascita " +
                " from Clienti where CodiceFiscale is not null";
            cmd.Connection= con;
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Clienti Cliente = new Clienti();
                Cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                Cliente.Nome = reader["Nome"].ToString();
                Cliente.Cognome = reader["Cognome"].ToString();
                Cliente.CodiceFiscale = reader["CodiceFiscale"].ToString();
                Cliente.LuogoNascita = reader["LuogoNascita"].ToString();
                Cliente.Residenza = reader["Residenza"].ToString();
                Cliente.DataNascita = Convert.ToDateTime(reader["DataNascita"]);
                ListaClienti.Add(Cliente);
            }
            con.Close();
            return View(ListaClienti);
        }
        public ActionResult AggiungiNuovo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AggiungiNuovo(Clienti c)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SDADB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Cognome", c.Cognome);
            cmd.Parameters.AddWithValue("@CodiceFiscale", c.CodiceFiscale);
            cmd.Parameters.AddWithValue("@LuogoNascita", c.LuogoNascita);
            cmd.Parameters.AddWithValue("@Residenza", c.Residenza);
            cmd.Parameters.AddWithValue("@DataNascita", c.DataNascita);
            cmd.CommandText = "insert into clienti (Nome, Cognome, CodiceFiscale, LuogoNascita, Residenza, DataNascita)" +
                                " values(@Nome, @Cognome, @CodiceFiscale, @LuogoNascita, @Residenza, @DataNascita)";
            cmd.Connection= con;
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }
        public ActionResult Modifica(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SDADB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "select * from clienti where IdCliente = @id";
            cmd.Connection= con;
            SqlDataReader reader = cmd.ExecuteReader();
            Clienti Cliente = new Clienti();
            while (reader.Read())
            {
                Cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                Cliente.Nome = reader["Nome"].ToString();
                Cliente.Cognome = reader["Cognome"].ToString();
                Cliente.CodiceFiscale = reader["CodiceFiscale"].ToString();
                Cliente.LuogoNascita = reader["LuogoNascita"].ToString();
                Cliente.Residenza = reader["Residenza"].ToString();
                Cliente.DataNascita = Convert.ToDateTime(reader["DataNascita"]);
            }
            con.Close();
            return View(Cliente);
        }
        [HttpPost]
        public ActionResult Modifica(Clienti c,int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SDADB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IdCliente", id);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Cognome", c.Cognome);
            cmd.Parameters.AddWithValue("@CodiceFiscale", c.CodiceFiscale);
            cmd.Parameters.AddWithValue("@LuogoNascita", c.LuogoNascita);
            cmd.Parameters.AddWithValue("@Residenza", c.Residenza);
            cmd.Parameters.AddWithValue("@DataNascita", c.DataNascita);
            cmd.CommandText = "update clienti set Nome = @Nome, Cognome = @Cognome, CodiceFiscale = @CodiceFiscale, LuogoNascita = @LuogoNascita," +
                "Residenza = @Residenza, DataNascita = @DataNascita where IdCliente = @IdCliente";
            cmd.Connection= con;
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }
        public ActionResult Elimina(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SDADB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from clienti where IdCliente= @id";
            cmd.Connection= con;
            cmd.ExecuteNonQuery();
            con.Close();
            TempData["messaggio"] = "Il cliente è stato cancellato";
            return RedirectToAction("Index");
        }
    }
}