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
    public class ModelController : ControllerBase
    {
        private IModel _db;

        public ModelController(IModel db)
        {
            _db = db;
        }

        [HttpPost("Create")]
        public ActionResult AddModel(Model model)
        {
            if (ModelState.IsValid)
            {
                var result = _db.AddModel(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            else
            {
                return BadRequest("Data is not correct");
            }
        }


        [HttpPut("{id}")]
        public ActionResult EditModel(int id, Model model)
        {
            if (ModelState.IsValid)
            {
                var result = _db.EditModel(id, model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Data is not correct");
        }

        [HttpGet("All")]
        public ActionResult ViewAllModels()
        {
            var models = _db.GetAllModels();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public ActionResult ViewOneModelDetails(int id)
        {
            var model = _db.GetModelById(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpGet("GetInBrand/{id}")]
        public ActionResult GetModelsOfBrand(int id)
        {
            var models = _db.GetAllModelsInOneBrand(id);
            if (models.Count == 0)
                return NotFound();

            return Ok(models);
        }

    }
}
