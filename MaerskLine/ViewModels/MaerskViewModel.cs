using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaerskLine.Models;

namespace MaerskLine.ViewModels
{
    public class MaerskViewModel
    {
        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public List<Customer> Customers { get; set; }

        public Container Container { get; set; }

        public List<Container> Containers { get; set; }

        public Schedule Schedule { get; set; }

        public List<Schedule> Schedules { get; set; }

        public int ScheduleId { get; set; }

        public int ShipId { get; set; }

        public Ship Ship { get; set; }

        public List<Ship> Ships { get; set; }

        public Booking Bookings { get; set; }

        public int BookingId { get; set; }

        public List<Booking> Booking { get; set; }

        public List<int> ContainersIds { get; set; }
    }
}