using Business.Absract;
using Business.Constants;
using Business.Utilities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IImageService _imageService;
        public CarImageManager(ICarImageDal carImageDal, IImageService imageService)
        {
            _carImageDal = carImageDal;
            _imageService = imageService;
        }

        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            var imagePathResult = _imageService.Add(formFile);
            if (!imagePathResult.Success)
                return new ErrorResult(imagePathResult.Message);
            carImage.ImagePath = imagePathResult.Data;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(string path)
        {
            var result = _imageService.Delete(path);
            if (!result.Success)
                return new ErrorResult(result.Message);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var data = _carImageDal.GetAll(c => c.CarId == carId);
            if (data.Count == 0)
                return new SuccessDataResult<List<CarImage>>(
                    new List<CarImage> {
                        new CarImage {
                                CarId=carId,
                                ImagePath = ImageHelper.GetDefaultImage()
                }
                    }, Messages.NoImageHasBeenUploadedYet);
            return new SuccessDataResult<List<CarImage>>(data, Messages.Success);
        }

        public IDataResult<CarImage> GetImagesByImageId(int imageId)
        {
            var data = _carImageDal.Get(c => c.Id == imageId);
            if (data is null)
                return new ErrorDataResult<CarImage>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<CarImage>(data, Messages.Success);
        }

        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            var result = _imageService.Update(carImage.ImagePath, formFile);
            if (!result.Success)
                return new ErrorResult(result.Message);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Success);
        }
    }
}
