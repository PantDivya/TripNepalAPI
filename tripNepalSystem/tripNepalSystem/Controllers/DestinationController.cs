using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tripNepalSystem.DAL;
using tripNepalSystem.DTO;
using tripNepalSystem.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tripNepalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly TripNepalDbContext _db;

        public DestinationController(TripNepalDbContext _context)
        {
            _db = _context;
        }
        // GET: api/<DestinationController>
        [HttpGet]
        public IActionResult Get()
        {
            var destinationList = _db.Destinations.Where(x => x.IsActive == true).Include(y => y.Map).ToList();
            return Ok(destinationList);
        }

        // GET api/<DestinationController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var destination = _db.Destinations.Include(y => y.Map).Where(x => x.Id == id).FirstOrDefault();

            return Ok(destination);
        }

        // POST api/<DestinationController>
        [HttpPost]
        public void Add([FromBody] DestinationDTO destinations)
        {
            var map = _db.Maps.Where(x => x.Id == destinations.Map).FirstOrDefault();

            Destination newDestination = new Destination();
            newDestination.Id = destinations.Id;
            newDestination.Photo = destinations.Photo;
            newDestination.Name = destinations.Name;
            newDestination.Description = destinations.Description;
            newDestination.Features = destinations.Features;
            newDestination.Map = map;
            newDestination.OtherDetails = destinations.OtherDetails;
            newDestination.Rating = destinations.Rating;
            newDestination.IsActive = true;

            _db.Add(newDestination);
            _db.SaveChanges();
        }

        // PUT api/<DestinationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DestinationDTO destinationDTO)
        {
            var editDestination = _db.Destinations.Where(x => x.Id == id).FirstOrDefault();
            var map = _db.Maps.Where(x => x.Id == destinationDTO.Map).FirstOrDefault();

            editDestination.Photo = destinationDTO.Photo;
            editDestination.Name = destinationDTO.Name;
            editDestination.Description = destinationDTO.Description;
            editDestination.Features = destinationDTO.Features;
            editDestination.Map = map;
            editDestination.OtherDetails = destinationDTO.OtherDetails;
            editDestination.Rating = destinationDTO.Rating;
            editDestination.IsActive = destinationDTO.IsActive;

            _db.SaveChanges();
            return Ok(editDestination);
        }

        // DELETE api/<DestinationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var destination = _db.Destinations.Where(x => x.Id == id).FirstOrDefault();
            destination.IsActive = false;
            _db.SaveChanges();
        }
    }
}
