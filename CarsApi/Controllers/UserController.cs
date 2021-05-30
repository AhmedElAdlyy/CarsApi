using CarsApi.Models;
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
    public class UserController : ControllerBase
    {
        IUser _db;

        public UserController(IUser db)
        {
            _db = db;
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            User u = _db.Register(user);

            if (u != null)
            {
                return Ok(u);
            }
            else
            {
                return BadRequest();
            }
        }

       




    }
}
