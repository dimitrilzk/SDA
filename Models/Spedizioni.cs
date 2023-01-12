using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SDA.Models
{
    public class Spedizioni
    {
        public int IdSpedizione { get; set; }
        public int IdCliente { get; set; }
        public string NomeDestinatario { get; set; }
        public string IndirizzoDestinazione { get; set; }
        public string CittaDesitnazione { get; set; }
        public decimal Costo { get; set; }
        public decimal Peso { get; set; }
        public DateTime DataPartenza { get; set; }
        public DateTime DataArrivo { get; set; }
        public int IdStatoSpedizione { get; set; }
        public string NomeMittente { get; set; }

    }
}