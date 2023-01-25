using Inventory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Strategy
{
    public interface IDeliveryStrategy
    {
        DeliveryType SetDelivermethod();
    }
    public class NormalDelivery : IDeliveryStrategy
    {
        public DeliveryType SetDelivermethod() => DeliveryType.normal;

    }
    public class ImmediatelyDelivery : IDeliveryStrategy
    {
        public DeliveryType SetDelivermethod() => DeliveryType.immediately;
    }

}
