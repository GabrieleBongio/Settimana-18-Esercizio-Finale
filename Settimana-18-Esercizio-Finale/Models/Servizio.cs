using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Settimana_18_Esercizio_Finale.Models
{
    public class Servizio
    {
        [ScaffoldColumn(false)]
        public int IdServizi { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Remote(
            "CheckIdPrenotazione",
            "Validation",
            ErrorMessage = "Nessuna Prenotazione con questo Id"
        )]
        public int IdPrenotazione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Remote("CheckTipoServizio", "Validation", ErrorMessage = "Valore non valido")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int Quantità { get; set; }

        [ScaffoldColumn(false)]
        public double Prezzo { get; set; }

        public Servizio() { }

        public Servizio(
            int idServizi,
            int idPrenotazione,
            string tipo,
            DateTime data,
            int quantità,
            double prezzo
        )
        {
            IdServizi = idServizi;
            IdPrenotazione = idPrenotazione;
            Tipo = tipo;
            Data = data;
            Quantità = quantità;
            Prezzo = prezzo;
        }
    }
}
