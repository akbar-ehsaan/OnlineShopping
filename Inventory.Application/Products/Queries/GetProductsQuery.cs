using Inventory.Application.Common.Exceptions;
using Inventory.Application.Common.Interfaces;
using Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Application.Products.Queries
{
    public sealed class GetProductsQuery : IRequest<GetProductsQueryResponse>
    {
        public Guid? ProductId { set; get; }
        public GetProductsQuery()
        {
            this.ProductId = string.IsNullOrEmpty(ProductId.ToString()) ||
                     ProductId.ToString() == "00000000-0000-0000-0000-000000000000" ? null : ProductId;
        }

    }

    public class GetProductsHandler : IRequestHandler<GetProductsQuery, GetProductsQueryResponse>
    {
        private readonly IApplicationContext _context;

        public GetProductsHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetProductsQueryResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products=new List<Product>();
            products = (request.ProductId ==null) ? _context.Products.ToList(): _context.Products.Where(i => i.Id == request.ProductId).ToList();
            if (products.Count == 0) throw new NotFoundException("", request.ProductId);
            else
            {
                return GetProductsQueryResponse.Create(products);
            }

        }
    }
}
public record GetProductsQueryResponse(List<GetProductsQueryItem> products)
{
    public static GetProductsQueryResponse Create(List<Product> products)
    {
        var items = products.Select(p =>
        {
            return new GetProductsQueryItem
            {
                Description = p.Description,
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,

            };
        });
        return new GetProductsQueryResponse(items.ToList());

    }

}

public class GetProductsQueryItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { set; get; }
}
