using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moviesapp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace moviesapp.Controllers
{
    public class CustomersController : Controller
    {
        CustomersDataAccessLayer objcustomer = new CustomersDataAccessLayer();

        [HttpGet]
        [Route("api/Customers/Index")]
        public IEnumerable<TblCustomers> Index()
        {
            return objcustomer.GetAllCustomers();
        }

        [HttpPost]
        [Route("api/Customers/Create")]
        public int Create(TblCustomers customer)
        {
            return objcustomer.AddCustomers(customer);
        }

        [HttpGet]
        [Route("api/Customers/Details/{id}")]
        public TblCustomers Details(int id)
        {
            return objcustomer.GetCustomersData(id);
        }

        [HttpPut]
        [Route("api/Customers/Edit")]
        public int Edit(TblCustomers customer)
        {
            return objcustomer.UpdateCustomers(customer);
        }

        [HttpDelete]
        [Route("api/Customers/Delete/{id}")]
        public int Delete(int id)
        {
            return objcustomer.DeleteCustomers(id);
        }

    }
}
