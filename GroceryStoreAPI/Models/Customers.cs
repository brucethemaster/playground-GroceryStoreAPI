using GroceryStoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Customers
    {   
        public IList<CustomerData> customers { get; set; }
    }
}
