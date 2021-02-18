using System;
using System.ComponentModel.DataAnnotations;

namespace oef01.Models
{
    public class Vaccinatie
    {
        public Guid VaccinatieRegistratieId { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(18,120)]
        public int Leeftijd { get; set; }

        public string PrikDatum { get; set; }

        [Required]
        public Guid VaccinatieTypeId { get; set; }

        [Required]
        public Guid VaccinatieLocatieId { get; set; }

    }
}
