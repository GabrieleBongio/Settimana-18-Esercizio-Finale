using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Settimana_18_Esercizio_Finale.Models
{
    public class Dipendente
    {
        [ScaffoldColumn(false)]
        public int IdDipendente { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lungezza massima 50 caratteri")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lungezza massima 50 caratteri")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Dipendente() { }

        public Dipendente(int idDipendente, string username, string password)
        {
            IdDipendente = idDipendente;
            Username = username;
            Password = password;
        }
    }
}
