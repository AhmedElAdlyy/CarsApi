using CarsApi.Services.Interface;
using CarsApi.ViewModels;
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
    public class SearchController : ControllerBase
    {
        private ISearch _db;
        public SearchController(ISearch db)
        {
            _db = db;
        }
        [HttpGet("SearchByBrand")]
        public ActionResult SearchResult(int Brand)
        {
            var Result = _db.SearchViewModel(Brand);
            if (Result != null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("SearchByBrandModel")]
        public ActionResult SearchResult(int Brand, int Model)
        {
            var Result = _db.SearchViewModel(Brand, Model);
            if (Result != null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("SearchByAll")]
        public ActionResult SearchResult(int Brand, int Model, int Body)
        {
            var Result = _db.SearchViewModel(Brand, Model, Body);
            if (Result != null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("SearchByBody")]
        public ActionResult SearchResultBody(int Body)
        {
            var Result = _db.SearchByBody(Body);
            if (Result != null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("SearchByPrice")]
        public ActionResult SearchResultPrice(int price1,int price2)
        {
            var Result = _db.SearchByPrice(price1,price2);
            if (Result != null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("SearchByYear")]
        public ActionResult SearchResultYear(int year)
        {
            var Result = _db.SearchByYear(year);
            if (Result != null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("General")]
        public ActionResult GeneralSearchResult([FromQuery]SearchFormViewModel model)
        {
            var result = _db.SearchByAll(model);
            if (result.IsSuccess)
                return Ok(result.SearchResults);

            return BadRequest();
        }
    }
}

