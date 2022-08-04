using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Exceptions
{
    public class PriceLimitException:Exception
    {
        public PriceLimitException()
            : base($"this invoice has price limitation please add more product ")
        {
        }
    
    
    }
}
