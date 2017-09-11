using System;
using System.Collections.Generic;
using System.Text;

namespace Bosch.JaSemNetoperek.Models
{
    public class Station : Base
    {
        public int StationId { get; set; }

        public string Name { get; set; }

        public byte Capacity { get; set; }

        public Location Location { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
