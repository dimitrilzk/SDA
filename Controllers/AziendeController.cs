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
    public class AziendeController : Controller
    {
        // GET: Aziende
        public ActionResult Index()
        {
            List<Clienti> ListaAziende = new List<Clienti>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SDADB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select IdCliente, NomeAzienda, PartitaIva, IndirizzoSede, CittaSede from Clienti where PartitaIva is not null";
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Clienti Azienda = new Clienti();
                Azienda.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                Azienda.NomeAzienda = reader["NomeAzienda"].ToString();
                Azienda.PartitaIva = reader["PartitaIva"].ToString();
                Azienda.IndirizzoSede = reader["IndirizzoSede"].ToString();
                Azienda.CittaSede = reader["CittaSede"].ToString();
                ListaAziende.Add(Azienda);
            }
            con.Close();
            return View(ListaAziende);
        }
        public ActionResult AggiungiAzienda() 
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult AggiungiAzienda(Clienti Azienda)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SDADB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@NomeAzienda", Azienda.NomeAzienda);
            cmd.Parameters.AddWithValue("@PartitaIva", Azienda.PartitaIva);
            cmd.Parameters.AddWithValue("@IndirizzoSede", Azienda.IndirizzoSede);
            cmd.Parameters.AddWithValue("@CittaSede", Azienda.CittaSede);
            cmd.CommandText = "insert into clienti (NomeAzienda, PartitaIva, IndirizzoSede, CittaSede)" +
                                " values(@NomeAzienda, @PartitaIva, @IndirizzoSede, @CittaSede)";
            cmd.Connection = con;
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
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            Clienti Azienda = new Clienti();
            while (reader.Read())
            {
                Azienda.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                Azienda.NomeAzienda = reader["NomeAzienda"].ToString();
                Azienda.PartitaIva = reader["PartitaIva"].ToString();
                Azienda.IndirizzoSede = reader["IndirizzoSede"].ToString();
                Azienda.CittaSede = reader["CittaSede"].ToString();
            }
            con.Close();
            return View(Azienda);
        }
        [HttpPost]
        public ActionResult Modifica(Clienti Azienda, int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SDADB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IdCliente", id);
            cmd.Parameters.AddWithValue("@NomeAzienda", Azienda.NomeAzienda);
            cmd.Parameters.AddWithValue("@PartitaIva", Azienda.PartitaIva);
            cmd.Parameters.AddWithValue("@IndirizzoSede", Azienda.IndirizzoSede);
            cmd.Parameters.AddWithValue("@CittaSede", Azienda.CittaSede);
            cmd.CommandText = "update clienti set NomeAzienda = @NomeAzienda, PartitaIva = @PartitaIva, IndirizzoSede = @IndirizzoSede," +
                " CittaSede = @CittaSede where IdCliente = @IdCliente";
            cmd.Connection = con;
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
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            TempData["messaggio"] = "Il cliente è stato cancellato";
            return RedirectToAction("Index");
        }

    }
}