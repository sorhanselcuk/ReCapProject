using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Absract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage,IFormFile formFile);
        IResult Update(CarImage carImage,IFormFile formFile);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IDataResult<CarImage> GetImagesByImageId(int imageId);
    }
}
