using CarsApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarsApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private IRent _db;
        public RentController(IRent db)
        {
            _db = db;
        }
        [HttpGet("RentInfo")]
        public ActionResult RentResult(int UserId)
        {
            var Result = _db.EditRentDetails(UserId);
            if (Result != null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
