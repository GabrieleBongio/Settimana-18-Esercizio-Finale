using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Settimana_18_Esercizio_Finale.Models
{
    public class RicercaPrenotazione
    {
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(
            16,
            MinimumLength = 16,
            ErrorMessage = "la lunghezza deve essere esattamente di 16 caratteri"
        )]
        [Display(Name = "Codice Fiscale")]
        public string CF { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Display(Name = "Numero Prenotazione")]
        [Remote(
            "CheckNumeroPrenotazione",
            "Validation",
            ErrorMessage = "Nessuna Prenotazione con questo Numero"
        )]
        public int Numero_Prenotazione { get; set; }

        public RicercaPrenotazione() { }

        public RicercaPrenotazione(string cF, int numero_Prenotazione)
        {
            CF = cF;
            Numero_Prenotazione = numero_Prenotazione;
        }
    }
}
