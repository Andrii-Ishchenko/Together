﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Exceptions
{
    public class RouteFullException : Exception
    {

        public override string ToString()
        {
            return "Route is full";
        }

    }
}