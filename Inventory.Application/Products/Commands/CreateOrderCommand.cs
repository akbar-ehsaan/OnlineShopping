using Inventory.Application.Common.Exceptions;
using Inventory.Application.Common.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Application.Products.Commands
{
    public class CreateOrderCommand: IRequest<int>
    {
        public Guid ProductId { get; set; }
        public Guid UserId { set; get; }
    }
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IApplicationContext _context;

        public CreateOrderCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var product = _context.Products.Find(request.ProductId);
            if (product == null) throw new NotFoundException("", request.ProductId);

            var user = _context.Users.Find(request.UserId);
            if (user == null) throw new NotFoundException(user.GetType().ToString(), request.ProductId);

            var currentOrder = new Order();
            currentOrder.OrderedBy(user).AddProductToBasket(product).Build();

            return  await _context.SaveChangesAsync(cancellationToken);
            //this event can be sent to kafka or other brokers in microservice architecture
            product.DomainEvents.Add(new OrderSubmittedEvent(product));


        }
    }
}
