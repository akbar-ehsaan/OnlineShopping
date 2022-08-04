using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Exceptions
{
    public class ProductSoldException : Exception
    {
        public ProductSoldException()
            : base($"Product Is Sold.You can't buy it.")
        {
        }
    }
    
    
}
