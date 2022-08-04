using Inventory.Domain.Common;
using Inventory.Domain.Enums;
using Inventory.Domain.Exceptions;
using Inventory.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Product
    {
        public Guid Id { get;private set; }
        public string Name { get; private set; }
        public Barcode? Barcode { get; private set; }
        public string Description { get; private set; }
        public double Price { private set; get; }//this property can be a list because of changing price in product
        public Weight? Weight { get; private set; }
        public Category? Category { get; private set; }
        public List<OrderDetail> OrderDetails {private set; get; }
        public ProductType ProductType { get; private set; }
        public List<DomainEvent> DomainEvents { get; private set; } = new List<DomainEvent>();
        private Product()
        {
            
        }
        public Product(string name,Barcode barcode, string description, Weight weight,
            Category category, ProductType productType,double Price)
        {
            this.Id = string.IsNullOrEmpty(Id.ToString()) ||
                 Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : Id; this.Name = name;
            this.Barcode = barcode;
            this.Description = description;
            this.Weight = weight;
            this.Category = category;
            ProductType = productType;
            this.Price = Price;
        }
    }
    
}
