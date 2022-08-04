using Inventory.Domain.Common;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Products.EventHandlers
{
    public class ProductSoldEvent : DomainEvent
    {
        public ProductSoldEvent(Product item)
        {
            product = item;
        }

        public Product product { get; }
    }
}
