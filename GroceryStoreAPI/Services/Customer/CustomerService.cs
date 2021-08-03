using GroceryStoreAPI.Model;
using GroceryStoreAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services.Customer
{
    public class CustomerService : ICustomerService
    {

        private static Customers _customers = new Customers
        {

        };
        public async Task<List<CustomerData>> AddCustomer(CustomerData newCustomer)
        {
            string jsonRead;
            using (StreamReader readCustomer = new StreamReader(@"./Data/database.json"))
            {


                jsonRead = await readCustomer.ReadToEndAsync();
                jsonRead = jsonRead.ToString();
            }
            var customers = JsonConvert.DeserializeObject<Customers>(jsonRead);
            _customers = customers;
            _customers.customers.Add(newCustomer);
            using (StreamWriter writeCustomer = new StreamWriter(@"./Data/database.json", false))
            {
                await writeCustomer.WriteLineAsync(JsonConvert.SerializeObject(_customers));
            }
            return _customers.customers.ToList();
        }

        public async Task<List<CustomerData>> GetAllCustomer()
        {

            try
            {
                string jsonRead;
                using (StreamReader readCustomer = new StreamReader(@"./Data/database.json"))
                {

                    jsonRead = await readCustomer.ReadToEndAsync();
                    jsonRead = jsonRead.ToString();
                }

                var customers = JsonConvert.DeserializeObject<Customers>(jsonRead);
                _customers = customers;
                return _customers.customers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CustomerData> GetCustomerById(int id)
        {

            try
            {
                string jsonRead;
                using (StreamReader readCustomer = new StreamReader(@"./Data/database.json"))
                {

                    jsonRead = await readCustomer.ReadToEndAsync();
                    jsonRead = jsonRead.ToString();
                }

                var customers = JsonConvert.DeserializeObject<Customers>(jsonRead);
                _customers = customers;
                return _customers.customers.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<CustomerData>> UpdateCustomer(CustomerData updateCustomer)
        {
            try
            {
                string jsonRead;
                using (StreamReader readCustomer = new StreamReader(@"./Data/database.json"))
                {

                    jsonRead = await readCustomer.ReadToEndAsync();
                    jsonRead = jsonRead.ToString();
                }

                var customers = JsonConvert.DeserializeObject<Customers>(jsonRead);
                _customers = customers;


                foreach (var item in _customers.customers)
                {
                    if (item.Id == updateCustomer.Id)
                    {
                        item.Name = updateCustomer.Name;
                    }

                }

                using (StreamWriter writeCustomer = new StreamWriter(@"./Data/database.json", false))
                {
                    await writeCustomer.WriteLineAsync(JsonConvert.SerializeObject(_customers));
                }

                return _customers.customers.ToList();
            }
            catch (Exception)
            {
                throw;
            }


        }

        public async Task<List<CustomerData>> DeleteCustomerById(int id)
        {
            try
            {
                string jsonRead;
                using (StreamReader readCustomer = new StreamReader(@"./Data/database.json"))
                {

                    jsonRead = await readCustomer.ReadToEndAsync();
                    jsonRead = jsonRead.ToString();
                }

                var customers = JsonConvert.DeserializeObject<Customers>(jsonRead);
                _customers = customers;

                CustomerData customerToDelete = _customers.customers.First(c => c.Id == id);

                _customers.customers.Remove(customerToDelete);
                using (StreamWriter writeCustomer = new StreamWriter(@"./Data/database.json", false))
                {
                    await writeCustomer.WriteLineAsync(JsonConvert.SerializeObject(_customers));
                }

                return _customers.customers.ToList();

            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
