using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomersController : BaseApiController
    {
        [HttpGet("{id}")]
        public string GetCustomer(int id)
        {
            return "single customer";
        }
        [HttpGet]
        public string GetCustomers()
        {
            return "customer list";
        }
    }
}