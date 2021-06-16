using CarsApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarDetails _db;

        public CarsController(ICarDetails db)
        {
            _db = db;
        }

        [HttpGet("{carDetailsId}")]
        public ActionResult GetCarDetails(int carDetailsId)
        {
            var result = _db.ViewCarDetails(carDetailsId);

            if (result.IsSuccess == false)
                return NotFound();

            return Ok(result);
        }
    }
}
