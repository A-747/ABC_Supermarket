using ABC_Supermarket.Server.Context;
using ABC_Supermarket.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Supermarket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDetailsController : ControllerBase
    {
        private DatabaseContext _dbContext = null;

        public ItemDetailsController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateItem(ItemDetails itemObj)
        {
            _dbContext.Add(itemObj);
            await _dbContext.SaveChangesAsync();
            return Ok(itemObj.ItemCode);
        }
        [HttpGet]
        public async Task<IActionResult> Getitems()
        {
            List<ItemDetails> ObjItem = await _dbContext.Item.ToListAsync();
            return Ok(ObjItem);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemsById(int id)
        {
            var ObjItem = await _dbContext.Item.FirstOrDefaultAsync(p => p.ItemCode == id);
            return Ok(ObjItem);
        }
        public async Task<IActionResult> UpdateItem(ItemDetails itemObj)
        {
            _dbContext.Entry(itemObj).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Route("[action]")]
        public async Task<IActionResult> DeleteItem(int id)
        {

            ItemDetails ObjItem = new ItemDetails { ItemCode = id };
            _dbContext.Remove(ObjItem);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
