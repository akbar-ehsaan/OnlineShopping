using Inventory.Application.Products.Queries;
using Inventory.Domain.Entities;
using Inventory.Domain.Exceptions;
using Inventory.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Inventory.Tests
{
    public  class OrderTest : IClassFixture<TestHostBuilder>
    {
      
        private readonly TestHostBuilder _fixture;

        public OrderTest(TestHostBuilder fixture)
        {
            _fixture = fixture;

        }
        [Fact]
        public void GetProducts()
        {
            var context = _fixture.GetApplicationContext();

            var newProduct = new Product(
                "Test", new Domain.ValueObjects.Barcode("1111"), "desc"
                , new Domain.ValueObjects.Weight(1), new Domain.ValueObjects.Category("Media")
                , Domain.Enums.ProductType.normal,50000);
            context.Products.Add(newProduct);
            context.SaveChangesAsync(new System.Threading.CancellationToken());
            GetProductsHandler handler = new GetProductsHandler(_fixture.GetApplicationContext());
            var res=handler.Handle(new GetProductsQuery() { ProductId = newProduct.Id }, new System.Threading.CancellationToken());
            Assert.True(res.Result.products.Count> 0, "Expected res to be greater than 0");
        }

        [Fact]
        public void create_order_with_priceLimitException()
        {
            var user = new User("Ehsan Akbar", "Tehran");
            var product = new Product("LCD", new Barcode("1111"), "LG LCD", new Weight(10),
                new Category("Media"), Domain.Enums.ProductType.fragile, 10000);
            var order = new Order();

            if (DateTime.Now.Hour < 8 || DateTime.Now.Hour >17)
            {
                var res = Assert.Throws<OrderTimeException>(() => order.OrderedBy(user).AddProductToBasket(product).Build());
                Assert.IsType<OrderTimeException>(res);
            }
            else
            {
                var result = Assert.Throws<PriceLimitException>(() => order.OrderedBy(user).AddProductToBasket(product).Build());
                Assert.IsType<PriceLimitException>(result);
            }
           

        }
        [Fact]
        public void create_order_with_cheap_off()
        {
            var user = new User("Ehsan Akbar", "Tehran");
            var product = new Product("LCD", new Barcode("1111"), "LG LCD", new Weight(10),
                new Category("Media"), Domain.Enums.ProductType.fragile, 100000);
            var order = new Order();
            if (DateTime.Now.Hour < 8 || DateTime.Now.Hour > 17)
            {
                var res = Assert.Throws<OrderTimeException>(() => order.OrderedBy(user).AddProductToBasket(product).Build());
                Assert.IsType<OrderTimeException>(res);
            }
            else
            {
                var result = order.OrderedBy(user).AddProductToBasket(product).Build();
                Assert.Equal(result.OrderDetails[0].Off, 10000);
            }
         

        }
        [Fact]
        public void create_order_with_expensive_off()
        {
            var user = new User("Ehsan Akbar", "Tehran");
            var product = new Product("LCD", new Barcode("1111"), "LG LCD", new Weight(10),
                new Category("Media"), Domain.Enums.ProductType.fragile,1000000);
            var order = new Order();
            if (DateTime.Now.Hour < 8 || DateTime.Now.Hour > 17)
            {
                var res = Assert.Throws<OrderTimeException>(() => order.OrderedBy(user).AddProductToBasket(product).Build());
                Assert.IsType<OrderTimeException>(res);
            }
            else
            {
                var result = order.OrderedBy(user).AddProductToBasket(product).Build();
                Assert.Equal(result.OrderDetails[0].Off, 200000);

            }
  

        }
        [Fact]
        public void create_order_with_fragile_ProductType()
        {
            var user = new User("Ehsan Akbar", "Tehran");
            var product = new Product("LCD", new Barcode("1111"), "LG LCD", new Weight(10),
                new Category("Media"), Domain.Enums.ProductType.fragile, 1000000);
            var order = new Order();
            if (DateTime.Now.Hour < 8 || DateTime.Now.Hour > 17)
            {
                var res = Assert.Throws<OrderTimeException>(() => order.OrderedBy(user).AddProductToBasket(product).Build());
                Assert.IsType<OrderTimeException>(res);
            }
            else
            {
                var result = order.OrderedBy(user).AddProductToBasket(product).Build();
                Assert.Equal(result.DeliveryType, Domain.Enums.DeliveryType.immediately);
            }


        }
        [Fact]
        public void create_order_with_normal_ProductType()
        {
            var user = new User("Ehsan Akbar", "Tehran");
            var product = new Product("LCD", new Barcode("1111"), "LG LCD", new Weight(10),
                new Category("Media"), Domain.Enums.ProductType.normal, 1000000);
            var order = new Order();
            if (DateTime.Now.Hour < 8 || DateTime.Now.Hour > 17)
            {
                var res = Assert.Throws<OrderTimeException>(() => order.OrderedBy(user).AddProductToBasket(product).Build());
                Assert.IsType<OrderTimeException>(res);
            }
            else
            {
                var result = order.OrderedBy(user).AddProductToBasket(product).Build();
                Assert.Equal(result.DeliveryType, Domain.Enums.DeliveryType.normal);
            }
     

        }
        [Fact]
        public void create_order_with_two_products()
        {
            var user = new User("Ehsan Akbar", "Tehran");
            var product = new Product("LCD", new Barcode("1111"), "LG LCD", new Weight(10),
                new Category("Media"), Domain.Enums.ProductType.normal, 1000000);
            var product2 = new Product("LED", new Barcode("1112"), "LG LED", new Weight(11),
               new Category("Media"), Domain.Enums.ProductType.normal, 2000000);
            var order = new Order();
            if (DateTime.Now.Hour < 8 || DateTime.Now.Hour > 17)
            {
                var res = Assert.Throws<OrderTimeException>(() => order.OrderedBy(user).AddProductToBasket(product).AddProductToBasket(product2).Build());
                Assert.IsType<OrderTimeException>(res);
            }
            else
            {
                var result = order.OrderedBy(user).AddProductToBasket(product).AddProductToBasket(product2).Build();
                Assert.Equal(result.OrderDetails.Count(), 2);

            }
    

        }
    }
}
