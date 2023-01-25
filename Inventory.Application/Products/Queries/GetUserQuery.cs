using Inventory.Application.Common.Exceptions;
using Inventory.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Inventory.Application.Products.Queries.GetUserQueryHandler;

namespace Inventory.Application.Products.Queries
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
        public Guid UserId { set; get; }

    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        private readonly IApplicationContext _context;

        public GetUserQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {

            var user = _context.Users.Where(i=>i.Id==request.UserId).First();
            if (user == null) throw new NotFoundException(user.GetType().ToString(), request.UserId);
            return new GetUserResponse()
            {
                Address = user.Address,
                Name = user.Address
            };

        }
        public class GetUserResponse
        {
            public string Name { get;  set; }
            public string Address { set;  get; }
        }
    }
}
