using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Strategy
{
    public interface IOffStrategy
    {
        double Off(double productPrice);
    }
    public class ExpensiveOffStrategy : IOffStrategy
    {
        public double Off(double productPrice)
        {
            return productPrice - 0.2 * productPrice;
        }
    }
    public class CheapOffStrategy : IOffStrategy
    {
        public double Off(double productPrice)
        {
            return productPrice - 0.1 * productPrice;
        }
    }
}
