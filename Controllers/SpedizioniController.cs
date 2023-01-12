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
    public class SpedizioniController : Controller
    {
        // GET: Spedizioni
        public ActionResult Index()
        {
            List<Spedizioni> ListaSpedizioni = new List<Spedizioni>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SDADB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Spedizioni.IdSpedizione, Clienti.Nome, Clienti.Cognome, Clienti.NomeAzienda, Clienti.PartitaIva, " +
                              "Clienti.CodiceFiscale, Spedizioni.IndirizzoDestinazione, Spedizioni.CittaDestinazione, Spedizioni.DataPartenza FROM Clienti " +
                              "INNER JOIN Spedizioni ON Clienti.IdCliente = Spedizioni.IdCliente";
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Spedizioni s = new Spedizioni();
                s.IdSpedizione = Convert.ToInt32(reader["IdSpedizione"]);
                s.IndirizzoDestinazione = reader["IndirizzoDestinazione"].ToString();
                s.CittaDesitnazione = reader["CittaDestinazione"].ToString();
                s.DataPartenza = Convert.ToDateTime(reader["DataPartenza"].ToString());
                if (reader["CodiceFiscale"]!= DBNull.Value)
                {
                    s.NomeMittente = $"{reader["Nome"].ToString()} {reader["Cognome"].ToString()} {reader["CodiceFiscale"].ToString()}";
                }
                else
                {
                    s.NomeMittente = $"{reader["NomeAzienda"].ToString()} {reader["PartitaIva"].ToString()}";
                }
                ListaSpedizioni.Add(s);
            }
            con.Close();
            return View(ListaSpedizioni);
        }
    }
}