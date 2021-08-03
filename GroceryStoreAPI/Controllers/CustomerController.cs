using GroceryStoreAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using GroceryStoreAPI.Models;
using System.Linq;
using GroceryStoreAPI.Services.Customer;

namespace GroceryStoreAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase

    {
       /*static WebClient client = new WebClient();
        string json = client.DownloadString(@"./Data/database.json");
       */
  
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerData>>> GetCustomers()
        {
           
            return Ok(await _customerService.GetAllCustomer());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerData>> GetCustomerById(int id)
        {
           
            return Ok(await _customerService.GetCustomerById(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<CustomerData>>> AddCustomerById(CustomerData newCustomer)
        {
          
            return Ok(await _customerService.AddCustomer(newCustomer));
        }

        [HttpPut]
        public async Task<ActionResult<List<CustomerData>>> updateCustomer(CustomerData newCustomer)
        {

            return Ok(await _customerService.UpdateCustomer(newCustomer));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CustomerData>>> deleteCustomerById(int id)
        {

            return Ok(await _customerService.DeleteCustomerById(id));
        }
    }
}
