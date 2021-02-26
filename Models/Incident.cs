using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GbcSport.Models
{
    
    public class Incident
    {
        [Range(1,20, ErrorMessage ="Please select a Client")]
        public int CustomerId { get; set; }

       public int IncidentId { get; set; }

        public Customer Customer { get; set; }

        [Range(1,20, ErrorMessage ="Please select the product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage ="Enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Enter a description")]
        public string Description { get; set; }

        [Range(1,20, ErrorMessage ="Enter a technician")]
        public int TechnicianId { get; set; }

        public Technician Technician { get; set; }

        public DateTime DateAdded { get; set; }


    }
}
