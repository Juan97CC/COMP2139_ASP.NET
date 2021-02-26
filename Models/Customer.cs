using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GbcSport.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Please enter valid name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter valid name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter valid name")]
        public string Email { get; set; }

        [Range(1,10, ErrorMessage ="Please select a country")]
        public int CountryId { get; set; }


        public Country Country { get; set; }

        [Required(ErrorMessage ="Enter a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Enter a valid city")]
        public string City { get; set; }

        [Required(ErrorMessage ="Enter valid postal code")]
        public string PostalCode { get; set; }

        public string slug => Firstname?.Replace(' ', '-') +'-'+ Lastname?.Replace(' ', '-');
    }
}
