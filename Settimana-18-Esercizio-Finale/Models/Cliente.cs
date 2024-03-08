using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Settimana_18_Esercizio_Finale.Models
{
    public class Cliente
    {
        [ScaffoldColumn(false)]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(
            16,
            MinimumLength = 16,
            ErrorMessage = "la lunghezza deve essere esattamente di 16 caratteri"
        )]
        [Display(Name = "Codice Fiscale")]
        [Remote(
            "CheckCF",
            "Validation",
            ErrorMessage = "Questo Codice Fascale è già stato registrato"
        )]
        public string CF { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lungezza massima 50 caratteri")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lungezza massima 50 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lungezza massima 50 caratteri")]
        public string Città { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lungezza massima 50 caratteri")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lungezza massima 50 caratteri")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(
            10,
            MinimumLength = 10,
            ErrorMessage = "la lunghezza deve essere esattamente di 10 caratteri"
        )]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(
            10,
            MinimumLength = 10,
            ErrorMessage = "la lunghezza deve essere esattamente di 10 caratteri"
        )]
        public string Cellulare { get; set; }

        public Cliente() { }

        public Cliente(
            int idCliente,
            string cF,
            string cognome,
            string nome,
            string città,
            string provincia,
            string email,
            string telefono,
            string cellulare
        )
        {
            IdCliente = idCliente;
            CF = cF;
            Cognome = cognome;
            Nome = nome;
            Città = città;
            Provincia = provincia;
            Email = email;
            Telefono = telefono;
            Cellulare = cellulare;
        }
    }
}
