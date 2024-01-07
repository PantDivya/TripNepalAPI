using Microsoft.AspNetCore.Mvc;
using tripNepalSystem.DAL;
using tripNepalSystem.DTO;
using tripNepalSystem.Migrations;
using tripNepalSystem.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tripNepalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly TripNepalDbContext _db;
         public MapController(TripNepalDbContext _context)
        {
            _db = _context;
        }

        // GET: api/<MapController>
        [HttpGet]
        public IActionResult Get()
        {
           var mapList = _db.Maps.Where(x => x.IsActive == true).ToList();
            return Ok(mapList);
        }

        // GET api/<MapController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var map = _db.Maps.Where(x => x.Id == id).FirstOrDefault();
            return Ok(map);
        }

        // POST api/<MapController>
        [HttpPost]
        // To add Map
        public void Add([FromBody] MapDTO mapsDTO)
        {
            Map newMap = new Map();
            newMap.Id = mapsDTO.Id;
            newMap.Latitude = mapsDTO.Latitude;
            newMap.Longitude = mapsDTO.Longitude;
            newMap.IsActive = true;

            _db.Add(newMap);
            _db.SaveChanges();
            
        }

        // PUT api/<MapController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] MapDTO mapDTO)
        {
            var editMap = _db.Maps.Where(x => x.Id == id).FirstOrDefault();

            //editMap.Id = map.Id;
            editMap.Latitude = mapDTO.Latitude;
            editMap.Longitude = mapDTO.Longitude;
            editMap.IsActive = mapDTO.IsActive;

            _db.SaveChanges();
            return Ok(editMap);
        }

        // DELETE api/<MapController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var map = _db.Maps.Where(x => x.Id == id).FirstOrDefault();
            map.IsActive = false;
            _db.SaveChanges();
        }
    }
}
