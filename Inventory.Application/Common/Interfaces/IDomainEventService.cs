
using Inventory.Domain.Common;
using System.Threading.Tasks;

namespace Inventory.Application.Common.Interfaces
{

    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }

}