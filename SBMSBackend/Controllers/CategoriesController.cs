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
            //if (_categoryManager.Categories == null)
            //{
            //    return NotFound();
            //}
            return _categoryManager.GetAll().ToList();
        }

        //// GET: api/Categories/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Category>> GetCategory(int id)
        //{
        //  if (_categoryManager.Categories == null)
        //  {
        //      return NotFound();
        //  }
        //    var category = await _categoryManager.Categories.FindAsync(id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return category;
        //}

        //// PUT: api/Categories/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCategory(int id, Category category)
        //{
        //    if (id != category.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _categoryManager.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        await _categoryManager.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Categories
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Category>> PostCategory(Category category)
        //{
        //  if (_categoryManager.Categories == null)
        //  {
        //      return Problem("Entity set 'SBMSDbContext.Categories'  is null.");
        //  }
        //    _categoryManager.Categories.Add(category);
        //    await _categoryManager.SaveChangesAsync();

        //    return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        //}

        //// DELETE: api/Categories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    if (_categoryManager.Categories == null)
        //    {
        //        return NotFound();
        //    }
        //    var category = await _categoryManager.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _categoryManager.Categories.Remove(category);
        //    await _categoryManager.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CategoryExists(int id)
        //{
        //    return (_categoryManager.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
