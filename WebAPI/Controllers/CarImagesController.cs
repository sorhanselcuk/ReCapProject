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
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;
        

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage,file);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, int carImageId)
        {
            var carImageResult = _carImageService.GetImagesByImageId(carImageId);
            if (!carImageResult.Success)
                return BadRequest(carImageResult.Message);
            var updateResult = _carImageService.Update(carImageResult.Data, file);
            if (!updateResult.Success)
                return BadRequest(updateResult.Message);
            return Ok(updateResult);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Delete(int carImageId)
        {
            var carImageResult = _carImageService.GetImagesByImageId(carImageId);
            if (!carImageResult.Success)
                return BadRequest(carImageResult.Message);
            var deleteResult = _carImageService.Delete(carImageResult.Data.ImagePath);
            if (!deleteResult.Success)
                return BadRequest(deleteResult.Message);
            return Ok(deleteResult);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetImages(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetImage(int imageId)
        {
            var result = _carImageService.GetImagesByImageId(imageId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
