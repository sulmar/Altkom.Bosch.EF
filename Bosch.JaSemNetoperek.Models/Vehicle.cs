using System;
using System.Collections.Generic;
using System.Text;

namespace Bosch.JaSemNetoperek.Models
{
    public abstract class Vehicle : Base
    {
        public int VehicleId { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public Station Station { get; set; }

    }
}
