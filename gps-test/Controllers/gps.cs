using gps_test.Context;
using gps_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace gps_test.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class gps : ControllerBase
    {
        readonly gpsContext _gpsContext;
        public gps(gpsContext gpsContext)
        {
            _gpsContext = gpsContext;
        }

        [HttpGet]
        public IActionResult getAllGps()
        {
            var item = (from _item in _gpsContext.locations
                        select _item).ToList();
            return Ok(item);
        }

        [HttpGet]
        public IActionResult getOneGps( int id)
        {
            var item = (from _item in _gpsContext.locations
                        where _item.locationId == id
                        select _item).First();
            return Ok(item);
        }

        


        [HttpPost]
        public IActionResult craeteGps([FromBody]Loca req)
        {
            var location = new location() { locationLat = req.locationLat,locationLng=req.locationLng,locationName=req.locationName };
            _gpsContext.locations.Add(location);
            _gpsContext.SaveChanges();
            return Ok(location.locationId);
        }

        [HttpPost]
        public IActionResult updateGps([FromBody] Loca req)
        {
            var location = new location() { locationLat = req.locationLat, locationLng = req.locationLng, locationName = req.locationName,locationId=req.locationId??-1 };
            _gpsContext.locations.Update(location);
            _gpsContext.SaveChanges();
            return Ok(location.locationId);
        }
    }
    public class Loca
    {
        public int? locationId { get; set; }

        public decimal locationLng { get; set; }

        public decimal locationLat { get; set; }

        public string locationName { get; set; } = null!;
    }
}