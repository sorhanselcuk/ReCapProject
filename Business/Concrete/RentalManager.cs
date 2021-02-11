using Business.Absract;
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
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.CustomerId==customerId));
        }

        public IDataResult<List<Rental>> GetByDate(DateTime startDate, DateTime endDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.ReturnDate >= startDate && r.ReturnDate <= endDate));
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==rentalId));

        }

        public IDataResult<List<Rental>> GetRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult RentCar(Rental rental)
        {
            var isAvailable = _rentalDal.Get(r => r.CarId == rental.CarId).ReturnDate == null ? true : false;
            if (!isAvailable)
                return new ErrorResult("This car is not avaliable at the moment.");
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
