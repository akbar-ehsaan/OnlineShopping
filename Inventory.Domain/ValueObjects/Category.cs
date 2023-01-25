using Inventory.Domain.Common;
using Inventory.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.ValueObjects
{
    public class Category: ValueObject
    {
        public Category()
        {


        }
        public string Name { get; private set; } = "";

        public Category(string name)
        {

            if (!SupportedCategory.ToList().Contains(name))
                throw new UnsupportedCategoryException(name);
            else
            {
                Name = name;

            }
        }

        protected static IEnumerable<string> SupportedCategory
        {
            get
            {
                //this list can be fetched from database but here for simple present I use static category
                yield return "Book";
                yield return "Computer";
                yield return "Food";
                yield return "Gadget";
                yield return "Media";


            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
