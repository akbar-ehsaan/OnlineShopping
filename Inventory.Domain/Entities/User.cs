using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public  class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { private set;  get; }
        public List<Order> Orders { private set;  get; }      
        public User(string name, string address)
        {
            this.Id = string.IsNullOrEmpty(Id.ToString()) || 
                Id.ToString()=="00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : Id;
            Name = name;
            Address = address;  
        }
    }
}
