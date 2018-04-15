using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MaerskLine.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MobilePhoneNumber { get; set; }

    }
}