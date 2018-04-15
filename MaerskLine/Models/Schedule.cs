using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MaerskLine.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        [Required]
        [StringLength(30)]
        public string Origin { get; set; }

        [Required]
        [Display(Name = "Depart Time (MM/DD/YYYY)")]
        public DateTime DepartTime { get; set; }

        [Required]
        [StringLength(30)]
        public string Destination { get; set; }

        [Required]
        [Display(Name = "Arrive Time ( MM/DD/YYYY")]
        public DateTime ArriveTime { get; set; }
    }
}