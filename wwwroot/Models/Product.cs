using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GbcSport.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Enter appropriate code")]
        public string Code { get; set; }
        
        [Required(ErrorMessage ="Enter valid product name")]
        public string Productname { get; set; }

        [Required(ErrorMessage = "Enter a valid price")]
        public string Price { get; set; }


        [Required(ErrorMessage ="Enter the release date")]
        public string Releasedate { get; set; }


    }
}
