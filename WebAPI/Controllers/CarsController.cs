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
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCarsDetails()
        {
            var result = _carService.GetCarsDetails();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
