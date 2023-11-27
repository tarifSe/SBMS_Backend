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
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseManager _purchaseManager;

        public PurchasesController(IPurchaseManager purchaseManager)
        {
            _purchaseManager = purchaseManager;
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
        {
            var purchases= await _purchaseManager.GetAll();
            if (purchases == null)
            {
                return NotFound();
            }
            return purchases;
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            var purchase = await _purchaseManager.GetById(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return purchase;
        }

        // PUT: api/Purchases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return BadRequest();
            }

            try
            {
                await _purchaseManager.Update(purchase);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PurchaseExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                    throw;
                //}
            }

            return Ok("Updated");
        }

        // POST: api/Purchases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
            await _purchaseManager.Add(purchase);
            return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var purchase = await _purchaseManager.GetById(id);
            if (purchase == null)
            {
                return NotFound();
            }

            await _purchaseManager.Delete(purchase);
            return Ok("Deleted");
        }

        //private bool PurchaseExists(int id)
        //{
        //    return (_purchaseManager.Purchases?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
