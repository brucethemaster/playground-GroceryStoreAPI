using GroceryStoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services.Customer
{
   public interface ICustomerService
    {
        Task<List<CustomerData>> GetAllCustomer();
        Task<CustomerData> GetCustomerById(int id);

        Task<List<CustomerData>> AddCustomer(CustomerData customer);

        Task<List<CustomerData>> UpdateCustomer(CustomerData customer);

        Task<List<CustomerData>> DeleteCustomerById(int id);
    }
}
