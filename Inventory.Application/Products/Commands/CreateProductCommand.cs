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
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get;  set; }
        public string Barcode { get;  set; }
        public string Description { get;  set; }
        public double Price {  set; get; }

        //public Product(string name, Barcode barcode, string description, Weight weight,
        //     Category category, ProductType productType, double Price)
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationContext _context;

        public CreateProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var newProduct = new Product(
                request.Name, new Domain.ValueObjects.Barcode(request.Barcode), request.Description
                , new Domain.ValueObjects.Weight(1), new Domain.ValueObjects.Category("Media")
                , Domain.Enums.ProductType.normal, request.Price);
            _context.Products.Add(newProduct);
            return await _context.SaveChangesAsync(cancellationToken);

            //Here we can publish an event for adding new product

        }

    }
}
