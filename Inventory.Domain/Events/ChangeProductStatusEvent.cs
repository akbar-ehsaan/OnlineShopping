using Inventory.Domain.Common;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Events
{
    public class ChangeProductStatusEvent : DomainEvent
    {

        public ChangeProductStatusEvent(Product product)
        {
            Product = product;
        }

        public Product Product { get; }

    }
}
