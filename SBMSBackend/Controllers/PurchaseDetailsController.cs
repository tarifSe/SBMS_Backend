using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBMS.BLL.Services;
using SBMS.DatabaseContexts.DatabaseContext;
using SBMS.Models.EntityModels;
using SBMSBackend.Models.DTOs;

namespace SBMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDetailsController : ControllerBase
    {
        private readonly IPurchaseDetailsManager _purchaseDetailsManager;
        private readonly IMapper _mapper;

        public PurchaseDetailsController(IPurchaseDetailsManager purchaseDetailsManager, IMapper mapper)
        {
            _purchaseDetailsManager = purchaseDetailsManager;
            _mapper = mapper;
        }

        // GET: api/PurchaseDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDetails>>> GetPurchaseDetails()
        {
            var purchaseDetails = await _purchaseDetailsManager.GetAll();
            if (purchaseDetails == null)
            {
                return NotFound();
            }
            return purchaseDetails;
        }

        // GET: api/PurchaseDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDetails>> GetPurchaseDetails(int id)
        {
            var purchaseDetails = await _purchaseDetailsManager.GetById(id);
            if (purchaseDetails == null)
            {
                return NotFound();
            }

            return purchaseDetails;
        }

        // PUT: api/PurchaseDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseDetails(int id, PurchaseDetailsDTO purchaseDetailsDTO)
        {
            var purchaseDetails = _mapper.Map<PurchaseDetails>(purchaseDetailsDTO);
            if (id != purchaseDetails.Id)
            {
                return BadRequest();
            }

            try
            {
                await _purchaseDetailsManager.Update(purchaseDetails);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PurchaseDetailsExists(id))
                //{
                return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return Ok("Updated");
        }

        // POST: api/PurchaseDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseDetails>> PostPurchaseDetails(PurchaseDetailsDTO purchaseDetailsDTO)
        {
            var purchaseDetails=_mapper.Map<PurchaseDetails>(purchaseDetailsDTO);

            await _purchaseDetailsManager.Add(purchaseDetails);
            return CreatedAtAction("GetPurchaseDetails", new { id = purchaseDetails.Id }, purchaseDetails);
        }

        // DELETE: api/PurchaseDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseDetails(int id)
        {
            var purchaseDetails = await _purchaseDetailsManager.GetById(id);
            if (purchaseDetails == null)
            {
                return NotFound();
            }
            
            await _purchaseDetailsManager.Delete(purchaseDetails);

            return Ok("Deleted");
        }

    }
}
