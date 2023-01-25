using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Exceptions
{
    public class ProductDamageException : Exception
    {
        public ProductDamageException()
            : base($"Product is damaged.You can't buy it")
        {
        }
    }
    
    
}
