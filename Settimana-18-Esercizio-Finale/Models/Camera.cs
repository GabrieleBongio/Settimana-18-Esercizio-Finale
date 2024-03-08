using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Settimana_18_Esercizio_Finale.Models
{
    public class Camera
    {
        [ScaffoldColumn(false)]
        public int IdCamera { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Remote("CheckTipologiaCamera", "Validation", ErrorMessage = "Valore non valido")]
        public string Tipologia { get; set; }

        public Camera() { }

        public Camera(int idCamera, int numero, string descrizione, string tipologia)
        {
            IdCamera = idCamera;
            Numero = numero;
            Descrizione = descrizione;
            Tipologia = tipologia;
        }
    }
}
