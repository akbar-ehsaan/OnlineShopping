using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Exceptions
{
    public class OrderTimeException:Exception
    {
        public OrderTimeException()
            : base($"The shop is closed please try later")
        {
        }
    }
}
