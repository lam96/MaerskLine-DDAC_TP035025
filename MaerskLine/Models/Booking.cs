using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MaerskLine.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        [Display(Name = "Booking Agent")]
        public string BookedAgent { get; set; }

        public Schedule Schedule { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public Ship Ship { get; set; }

        public int ShipId { get; set; }

        public int ScheduleId { get; set; }
    }
}