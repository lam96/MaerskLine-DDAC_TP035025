using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MaerskLine.Models
{
    public class Container
    {
        [Key]
        public int ContainerId { get; set; }

        [Required]
        [Display(Name = "Items Type")]
        public string ItemsType { get; set; }


        [Required]
        [Range(1, 35)]
        [Display(Name = "Weight (Tonne/t")]
        public int WeightInTonne { get; set; }

        public Booking Bookings { get; set; }
        public int BookingId { get; set; }
    }
}