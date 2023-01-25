using System;

namespace Inventory.Application.Common.Exceptions {
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base() { }
    }
}
