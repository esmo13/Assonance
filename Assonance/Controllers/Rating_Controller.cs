using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assonance.Models;

namespace Assonance.Controllers
{
    [Route("api/Rating")]
    [ApiController]
    public class Rating_Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Rating_Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Rating_
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating_>>> GetRating_()
        {
            return await _context.Rating_.ToListAsync();
        }

        // GET: api/Rating_/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rating_>> GetRating_(long id)
        {
            var rating_ = await _context.Rating_.FindAsync(id);

            if (rating_ == null)
            {
                return NotFound();
            }

            return rating_;
        }

        // PUT: api/Rating_/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRating_(long id, PutRateForm rate)
        {
            var res = _context.Rating_.SingleOrDefault(rat=>rat.Id==id);
            if (res == null)
                return BadRequest();
            res.Rating = rate.Rating;
           await _context.SaveChangesAsync();
            return Ok();

                
        }

        // POST: api/Rating_
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rating_>> PostRating_(Rating_ rating_)
        {
            var test = _context.Rating_.Where(rat => rat.AlbumId == rating_.AlbumId && rat.UserId == rating_.UserId).FirstOrDefault();
            if (test != null)
                return BadRequest();
            _context.Rating_.Add(rating_);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRating_", new { id = rating_.Id }, rating_);
        }

        // DELETE: api/Rating_/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating_(long id)
        {
            var rating_ = await _context.Rating_.FindAsync(id);
            if (rating_ == null)
            {
                return NotFound();
            }

            _context.Rating_.Remove(rating_);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("count")]
        public int CountRatings()
        {
            return _context.Rating_.Count();
        }
        [HttpGet("{albumId}/{userId}")]
        public Rating_ getRatingById(long albumId, long userId) {

            var _rating = _context.Rating_.Where(rat => rat.AlbumId == albumId && rat.UserId == userId).FirstOrDefault();
            if (_rating == null)
                return null;
            return _rating;
        }
        [HttpGet("count/{albumId}")]
        public int CountRatingsByAlbum(long albumId) {
            int res = _context.Rating_.Where(rat => rat.AlbumId == albumId).Count();
            return res;
        }
        [HttpGet("avg/{albumId}")]
        public double AvgRatingByAlbum(long albumId) {
            List<Rating_> res = _context.Rating_.Where(rat => rat.AlbumId == albumId).ToList();
            if (res.Count == 0)
                return 0;

            return _context.Rating_.Where(rat => rat.AlbumId == albumId).Average(rat => rat.Rating);
        }


        private bool Rating_Exists(long id)
        {
            return _context.Rating_.Any(e => e.Id == id);
        }
    }
}
