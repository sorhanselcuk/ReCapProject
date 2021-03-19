using Business.Absract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new Result(true,Messages.Success);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var data = _carDal.GetAll();
            if (data is null)
                return new ErrorDataResult<List<Car>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<Car>>(data,Messages.Success);
        }

        public IDataResult<List<CarDetailDto>> GetAllWithDetails()
        {
            var data = _carDal.GetCarsDetails();
            if (data is null)
                return new ErrorDataResult<List<CarDetailDto>>(Messages.ThereIsNoSuchData);
            foreach (var car in data)
            {
                car.CarImages = _carImageService.GetImagesByCarId(car.CarId).Data;
            }
            return new SuccessDataResult<List<CarDetailDto>>(data, Messages.Success);
        }

        public IDataResult<List<CarDetailDto>> GetAllWithDetailsByBrandId(int brandId)
        {
            var data = _carDal.GetCarsDetailsByBrandId(brandId);
            if (data is null)
                return new ErrorDataResult<List<CarDetailDto>>(Messages.ThereIsNoSuchData);
            foreach (var car in data)
            {
                car.CarImages = _carImageService.GetImagesByCarId(car.CarId).Data;
            }
            return new SuccessDataResult<List<CarDetailDto>>(data, Messages.Success);
        }

        public IDataResult<Car> GetById(int id)
        {
            var data = _carDal.Get(c => c.Id == id);
            if (data is null)
                return new ErrorDataResult<Car>(Messages.ThereIsNoSuchData);
            return new DataResult<Car>(data,true,Messages.Success);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var data = _carDal.GetAll(c => c.BrandId == id);
            if (data is null)
                return new ErrorDataResult<List<Car>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<Car>>(data,Messages.Success);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var data = _carDal.GetAll(c => c.ColorId == id);
            if (data is null)
                return new ErrorDataResult<List<Car>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<Car>>(data,Messages.Success);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            var data = _carDal.GetCarsDetails();
            if (data is null)
                return new ErrorDataResult<List<CarDetailDto>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<CarDetailDto>>(data,Messages.Success);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int colorId)
        {
            var data = _carDal.GetCarsDetailsByColorId(colorId);
            if (data is null)
                return new ErrorDataResult<List<CarDetailDto>>(Messages.ThereIsNoSuchData);
            foreach (var car in data)
            {
                car.CarImages = _carImageService.GetImagesByCarId(car.CarId).Data;
            }
            return new SuccessDataResult<List<CarDetailDto>>(data, Messages.Success);
        }

        public IDataResult<CarDetailDto> GetCarsDetailsById(int id)
        {
            var data = _carDal.GetCarsDetailsById(id);
            if (data is null)
                return new ErrorDataResult<CarDetailDto>(Messages.ThereIsNoSuchData);
           
                data.CarImages = _carImageService.GetImagesByCarId(data.CarId).Data;
            
            return new SuccessDataResult<CarDetailDto>(data, Messages.Success);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, Messages.Success);
        }
    }
}
