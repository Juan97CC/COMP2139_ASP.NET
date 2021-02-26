using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GbcSport.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Enter a valid name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage ="Enter a valid last name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage ="Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter a valid phone number")]
        public string Phone { get; set; }

        public string slug => Firstname?.Replace(' ', '-') +'-' + Lastname?.Replace(' ', '-');


    }
}
