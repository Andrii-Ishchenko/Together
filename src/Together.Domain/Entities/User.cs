﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Together.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual List<Passenger> Passengers { get; set; }
    }
}
