using Business.Absract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            var data = _rentalDal.GetAll(r => r.CustomerId == customerId);
            if (data is null)
                return new ErrorDataResult<List<Rental>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<Rental>>(data,Messages.Success);
        }

        public IDataResult<List<Rental>> GetByDate(DateTime startDate, DateTime endDate)
        {
            var data = _rentalDal.GetAll(r => r.ReturnDate >= startDate && r.ReturnDate <= endDate);
            if (data is null)
                return new ErrorDataResult<List<Rental>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<Rental>>(data,Messages.Success);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var data = _rentalDal.Get(r => r.Id == rentalId);
            if (data is null)
                return new ErrorDataResult<Rental>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<Rental>(Messages.Success);

        }

        public IDataResult<List<Rental>> GetRentals()
        {
            var data = _rentalDal.GetAll();
            if (data is null)
                return new ErrorDataResult<List<Rental>>(Messages.ThereIsNoSuchData);
            return new SuccessDataResult<List<Rental>>(Messages.Success);
        }

        public IResult RentCar(Rental rental)
        {
            var isAvailable = _rentalDal.Get(r => r.CarId == rental.CarId).ReturnDate == null ? true : false;
            if (!isAvailable)
                return new ErrorResult(Messages.CarIsNotAvailable);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Success);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Success);
        }
    }
}
