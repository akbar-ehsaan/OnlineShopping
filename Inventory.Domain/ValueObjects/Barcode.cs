using Inventory.Domain.Common;
using Inventory.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.ValueObjects
{
    public class Barcode:ValueObject
    {
        public Barcode()
        {


        }
        public string Value { get; private set; } = "0000";

        public Barcode(string value)
        {

            if (value.Length != 4) throw new BarcodeLengthException();
            else Value = value;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
