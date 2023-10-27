using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBMS.BLL.Services;
using SBMS.DatabaseContexts.DatabaseContext;
using SBMS.Models.EntityModels;

namespace SBMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;

        public CategoriesController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryManager.GetAll();
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryManager.GetById(id);
            
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            try
            {
                await _categoryManager.Update(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CategoryExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                throw;
                //}
            }

            //return NoContent();
            return Ok(await _categoryManager.GetAll());
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            //if (_categoryManager.Categories == null)
            //{
            //    return Problem("Entity set 'SBMSDbContext.Categories'  is null.");
            //}
            await _categoryManager.Add(category);

            //return CreatedAtAction("GetCategory", new { id = category.Id }, category);
            return Ok(await _categoryManager.GetAll());
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            //if (_categoryManager.Categories == null)
            //{
            //    return NotFound();
            //}
            var category = await _categoryManager.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryManager.Delete(category);

            return Ok(await _categoryManager.GetAll());
        }

        //private bool CategoryExists(Category id)
        //{
        //    return _categoryManager.IsExists(id);
        //}
    }
}
