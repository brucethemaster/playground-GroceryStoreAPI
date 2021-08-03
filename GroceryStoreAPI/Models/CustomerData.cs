using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Model
{
    public class CustomerData
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
