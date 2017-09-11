﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bosch.JaSemNetoperek.Models
{
    public class User : Base
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        
    }
}