using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDA.Models
{
    public class Clienti
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        [Display(Name = "Codice Fiscale")]
        public string CodiceFiscale { get; set; }
        [Display(Name = "Luogo di Nascita")]
        public string LuogoNascita { get; set; }
        public string Residenza { get; set; }
        [Display(Name ="Data di Nascita")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascita { get; set; }
        [Display(Name = "Nome Azienda")]
        public string NomeAzienda { get; set; }
        [Display(Name = "Partita IVA")]
        public string PartitaIva { get; set; }
        [Display(Name = "Indirizzo Sede")]
        public string IndirizzoSede { get; set; }
        [Display(Name = "Citta Sede")]
        public string CittaSede { get; set; }

    }
}