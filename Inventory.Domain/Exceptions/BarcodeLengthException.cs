﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Exceptions
{
    public class BarcodeLengthException : Exception
    {
        public BarcodeLengthException()
            : base($"Barcode Length should be 4 digits.")
        {
        }
    }
    
    
}
