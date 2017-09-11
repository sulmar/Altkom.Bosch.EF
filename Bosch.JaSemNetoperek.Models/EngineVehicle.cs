using System;
using System.Collections.Generic;
using System.Text;

namespace Bosch.JaSemNetoperek.Models
{
    public abstract class EngineVehicle : Vehicle
    {
        public float EngineCapacity { get; set; }

        public int MaxSpeed { get; set; }

        public EngineType EngineType { get; set; }


    }
}
