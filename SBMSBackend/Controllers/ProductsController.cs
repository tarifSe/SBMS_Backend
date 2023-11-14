using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBMS.DatabaseContexts.DatabaseContext;
using SBMS.Models.EntityModels;
using SBMS.BLL.Services;
using SBMSBackend.Models.DTOs;
using AutoMapper;

namespace SBMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ProductsController(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productManager.GetAll();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productManager.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            if (id != product.Id)
            {
                return BadRequest();
            }
             
            try
            {
                await _productManager.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ProductExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                throw;
                //}
            }

            //return NoContent();
            return Ok(await _productManager.GetAll());
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDTO productDTO)
        {
            var product=_mapper.Map<Product>(productDTO);

            await _productManager.Add(product);
            //return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            return Ok(await _productManager.GetAll());
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            
            var product = await _productManager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productManager.Delete(product);

            return Ok(await _productManager.GetAll());
        }

        //private bool ProductExists(int id)
        //{
        //    return (_productManager.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
