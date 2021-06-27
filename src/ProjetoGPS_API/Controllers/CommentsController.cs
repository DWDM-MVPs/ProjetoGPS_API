using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoGPS_API.Models;

namespace ProjetoGPS_API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly Context _context;

        public CommentsController(Context context)
        {
            _context = context;
        }

        private bool CommentsExists(long id)
        {
            return _context.Comments.Any(e => e.ID == id);
        }





        // ░██████╗░███████╗████████╗
        // ██╔════╝░██╔════╝╚══██╔══╝
        // ██║░░██╗░█████╗░░░░░██║░░░
        // ██║░░╚██╗██╔══╝░░░░░██║░░░
        // ╚██████╔╝███████╗░░░██║░░░
        // ░╚═════╝░╚══════╝░░░╚═╝░░░
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comments>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }





        // ░██████╗░███████╗████████╗  ██████╗░██╗░░░██╗  ██╗██████╗░
        // ██╔════╝░██╔════╝╚══██╔══╝  ██╔══██╗╚██╗░██╔╝  ██║██╔══██╗
        // ██║░░██╗░█████╗░░░░░██║░░░  ██████╦╝░╚████╔╝░  ██║██║░░██║
        // ██║░░╚██╗██╔══╝░░░░░██║░░░  ██╔══██╗░░╚██╔╝░░  ██║██║░░██║
        // ╚██████╔╝███████╗░░░██║░░░  ██████╦╝░░░██║░░░  ██║██████╔╝
        // ░╚═════╝░╚══════╝░░░╚═╝░░░  ╚═════╝░░░░╚═╝░░░  ╚═╝╚═════╝░
        [HttpGet("{id}")]
        public async Task<ActionResult<Comments>> GetComments(long id)
        {
            var comments = await _context.Comments.FindAsync(id);

            if (comments == null)
            {
                return NotFound();
            }

            return comments;
        }





        // ░█████╗░██████╗░███████╗░█████╗░████████╗███████╗
        // ██╔══██╗██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██╔════╝
        // ██║░░╚═╝██████╔╝█████╗░░███████║░░░██║░░░█████╗░░
        // ██║░░██╗██╔══██╗██╔══╝░░██╔══██║░░░██║░░░██╔══╝░░
        // ╚█████╔╝██║░░██║███████╗██║░░██║░░░██║░░░███████╗
        // ░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚══════╝
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComments(long id, Comments comments)
        {
            if (id != comments.ID)
            {
                return BadRequest();
            }

            _context.Entry(comments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }





        // ██╗░░░██╗██████╗░██████╗░░█████╗░████████╗███████╗
        // ██║░░░██║██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝
        // ██║░░░██║██████╔╝██║░░██║███████║░░░██║░░░█████╗░░
        // ██║░░░██║██╔═══╝░██║░░██║██╔══██║░░░██║░░░██╔══╝░░
        // ╚██████╔╝██║░░░░░██████╔╝██║░░██║░░░██║░░░███████╗
        // ░╚═════╝░╚═╝░░░░░╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░╚══════╝
        [HttpPost]
        public async Task<ActionResult<Comments>> PostComments(Comments comments)
        {
            _context.Comments.Add(comments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComments", new { id = comments.ID }, comments);
        }





        // ██████╗░███████╗██╗░░░░░███████╗████████╗███████╗
        // ██╔══██╗██╔════╝██║░░░░░██╔════╝╚══██╔══╝██╔════╝
        // ██║░░██║█████╗░░██║░░░░░█████╗░░░░░██║░░░█████╗░░
        // ██║░░██║██╔══╝░░██║░░░░░██╔══╝░░░░░██║░░░██╔══╝░░
        // ██████╔╝███████╗███████╗███████╗░░░██║░░░███████╗
        // ╚═════╝░╚══════╝╚══════╝╚══════╝░░░╚═╝░░░╚══════╝
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComments(long id)
        {
            var comments = await _context.Comments.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comments);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
