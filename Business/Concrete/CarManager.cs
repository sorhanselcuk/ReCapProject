using Business.Absract;
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

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice < 0)
                return new ErrorResult("Car's daily price is must be greather than 0");
            _carDal.Add(car);
            return new Result(true,"The car was successfully added !");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("The car was successfully deleted !");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new DataResult<Car>(_carDal.Get(c=>c.Id==id),true);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var cars = _carDal.GetAll(c => c.BrandId == id);
            return new SuccessDataResult<List<Car>>(cars,"The cars are the same brand.");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, "The car was successfully updated !");
        }
    }
}
