﻿using CordCraftBanAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CordCraftBanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanController : ControllerBase
    {
        private readonly BanDbContext _context;

        public BanController(BanDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ban>>> GetBans()
        {
            return await _context.Bans.ToListAsync();
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<Ban>> GetBan(string uuid)
        {
            var ban = await _context.Bans.FirstOrDefaultAsync(b => b.UUID == uuid);
            if (ban == null) 
                return NotFound();
            if (DateTime.Now > ban.ExpiresAt)
            {
                await DeleteBan(uuid);
                return NoContent();
            }
            return ban;
        }

        [HttpPost]
        public async Task<ActionResult<Ban>> AddBan(Ban ban)
        {
            _context.Bans.Add(ban);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBan), new { uuid = ban.UUID }, ban);
        }

        [HttpDelete("{uuid}")]
        public async Task<IActionResult> DeleteBan(string uuid)
        {
            var ban = await _context.Bans.FirstOrDefaultAsync(b => b.UUID == uuid);
            if (ban == null) return NotFound();

            _context.Bans.Remove(ban);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
