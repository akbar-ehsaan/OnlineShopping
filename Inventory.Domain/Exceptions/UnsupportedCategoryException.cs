using System;

namespace Inventory.Domain.Exceptions
{


    public class UnsupportedCategoryException : Exception
    {
        public UnsupportedCategoryException(string name)
            : base($"Category \"{name}\" is unsupported.")
        {
        }
    }
}
