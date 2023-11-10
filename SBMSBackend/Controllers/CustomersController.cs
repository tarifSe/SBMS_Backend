using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBMS.BLL.Managers;
using SBMS.BLL.Services;
using SBMS.DatabaseContexts.DatabaseContext;
using SBMS.Models.EntityModels;

namespace SBMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        public CustomersController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerManager.GetAll();
            if (customers == null)
            {
                return NotFound();
            }
            return customers;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerManager.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            try
            {
                await _customerManager.Update(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CustomerExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                throw;
                //}
            }

            return Ok(await _customerManager.GetAll());
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            await _customerManager.Add(customer);

            return Ok(await _customerManager.GetAll());
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerManager.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customerManager.Delete(customer);

            return Ok(await _customerManager.GetAll());
        }

        //private bool CustomerExists(int id)
        //{
        //    return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
