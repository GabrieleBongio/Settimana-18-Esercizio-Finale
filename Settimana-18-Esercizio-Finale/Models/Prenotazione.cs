using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Settimana_18_Esercizio_Finale.Models
{
    public class Prenotazione
    {
        [ScaffoldColumn(false)]
        public int IdPrenotazione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Remote("CheckIdCliente", "Validation", ErrorMessage = "Nessun Cliente con questo Id")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Remote("CheckIdCamera", "Validation", ErrorMessage = "Nessuna Camera con questo Id")]
        public int IdCamera { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Data_Prenotazione { get; set; }

        [ScaffoldColumn(false)]
        public int Numero_Prenotazione { get; set; }

        [ScaffoldColumn(false)]
        public string Anno { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [DataType(DataType.Date)]
        public DateTime Inizio_Soggiorno { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [DataType(DataType.Date)]
        public DateTime Fine_Soggiorno { get; set; }

        [ScaffoldColumn(false)]
        public double Caparra { get; set; }

        [ScaffoldColumn(false)]
        public double Tariffa { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Remote("CheckTipoPrenotazione", "Validation", ErrorMessage = "Valore non valido")]
        public string Tipo { get; set; }

        public Prenotazione() { }

        public Prenotazione(
            int idPrenotazione,
            int idCliente,
            int idCamera,
            DateTime data_Prenotazione,
            int numero_Prenotazione,
            string anno,
            DateTime inizio_Soggiorno,
            DateTime fine_Soggiorno,
            double caparra,
            double tariffa,
            string tipo
        )
        {
            IdPrenotazione = idPrenotazione;
            IdCliente = idCliente;
            IdCamera = idCamera;
            Data_Prenotazione = data_Prenotazione;
            Numero_Prenotazione = numero_Prenotazione;
            Anno = anno;
            Inizio_Soggiorno = inizio_Soggiorno;
            Fine_Soggiorno = fine_Soggiorno;
            Caparra = caparra;
            Tariffa = tariffa;
            Tipo = tipo;
        }
    }
}
