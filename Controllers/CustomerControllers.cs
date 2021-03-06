﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindApiDemo.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        [HttpGet()]
        public IActionResult GetCustomers()
        {
            return new JsonResult(Repository.Instance.Customers);
            //return new JsonResult(new List<object>()
            //{
            //    new { CustomerdID = 1, ContactName = "Anderson"},
            //    new { CustomerID = 2, ContactName = "Solaris"}
            //});
        }

       [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var result =
                Repository.Instance.Customers
                .FirstOrDefault(c => c.Id == id);
            // no hay ningun customer ocn ese id
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
            //return new JsonResult(result);
        }
    }
}