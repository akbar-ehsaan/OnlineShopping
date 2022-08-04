using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.ValueObjects
{
    public class Weight:ValueObject
    {
        public Weight()
        {


        }
        public double Value { get; private set; } = 0;

        public Weight(double value)
        {

            if (value < 0) value = 0;
            else Value = value;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
