using Inventory.Domain.Enums;
using Inventory.Domain.Exceptions;
using Inventory.Domain.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{

    public class OrderDetail
    {
        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public double Price { get; private set; }
        public double Off { get; private set; }
        public Order Order { get; private set; }

        public OrderDetail()
        {
            this.Id = string.IsNullOrEmpty(Id.ToString()) ||
                            Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : Id;

        }
        public OrderDetail BuildOrderDetail(Product product)
        {
            IOffStrategy offStrategy = null;
            if (product.Price > 500000) offStrategy = new ExpensiveOffStrategy();
            else if (product.Price < 500000) offStrategy = new CheapOffStrategy();
            this.Price = (offStrategy == null) ? product.Price : offStrategy.Off(product.Price);
            this.Off = product.Price - this.Price;
            this.Product = product;
            
         
            return this;
        }
    }
    public class Order
    {
        public Guid Id { private set; get; }
        public DeliveryType DeliveryType { private set; get; }
        public DateTime SubmitDate { private set; get; } = DateTime.Now;
        public User User { private set; get; }
 
        public List<OrderDetail> OrderDetails { get; private set; }
        public Order()
        {
            this.Id = string.IsNullOrEmpty(Id.ToString()) ||
                            Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : Id;
            if (OrderDetails is null) OrderDetails = new List<OrderDetail>();


        }
        public Order OrderedBy(User user)
        {
            this.User = user;
            return this;
        }
       public Order AddProductToBasket(Product product)
        {
            var order = new OrderDetail();
            OrderDetails.Add(order.BuildOrderDetail(product));
            return this;
        }

        public Order Build()
        {
            if(SubmitDate.Hour<8 || SubmitDate.Hour>17)
                throw new OrderTimeException();
            if (OrderDetails.Sum(i => i.Price) < 50000)
                throw new PriceLimitException();

            IDeliveryStrategy deliveryStrategy = null;
            if (OrderDetails.Any(i=>i.Product.ProductType==ProductType.fragile)) 
                deliveryStrategy = new ImmediatelyDelivery();
            else 
                deliveryStrategy = new NormalDelivery();
            this.DeliveryType = deliveryStrategy.SetDelivermethod();

            return this;
        }



    }





    
}
