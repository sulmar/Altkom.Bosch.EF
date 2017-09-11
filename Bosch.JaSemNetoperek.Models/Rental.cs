using System;
using System.Collections.Generic;
using System.Text;

namespace Bosch.JaSemNetoperek.Models
{
    public class Rental : Base
    {
        public int RentalId { get; set; }

        public User Rentee { get; set; }

        public Station FromStation { get; set; }

        public DateTime FromDate { get; set; }

        public Vehicle Vehicle { get; set; }

        public Station ToStation { get; set; }

        public DateTime? ToDate { get; set; }

        public decimal? Cost { get; set; }
    }
}
