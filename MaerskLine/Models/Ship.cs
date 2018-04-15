using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MaerskLine.Models
{
    public class Ship
    {
        [Key]
        public int ShipId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Ship Name")]
        public string ShipName { get; set; }


        [Required]
        public int ShipContainerNo { get; set; }
    }
}