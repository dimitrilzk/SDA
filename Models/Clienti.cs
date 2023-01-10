using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDA.Models
{
    public class Clienti
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string LuogoNascita { get; set; }
        public string Residenza { get; set; }
        public DateTime DataNascita { get; set; }
        public string PartitaIva { get; set; }
        public string IndirizzoSede { get; set; }
        public string CittaSede { get; set; }

    }
}