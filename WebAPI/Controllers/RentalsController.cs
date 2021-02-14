using Business.Absract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult RentCar(Rental rental)
        {
            var result = _rentalService.RentCar(rental);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByCustomerId(int id)
        {
            var result = _rentalService.GetByCustomerId(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByDate(DateTime startTime,DateTime endTime)
        {
            var result = _rentalService.GetByDate(startTime,endTime);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetRentals()
        {
            var result = _rentalService.GetRentals();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
