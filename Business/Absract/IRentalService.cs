using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Absract
{
    public interface IRentalService
    {
        IResult RentCar(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<Rental>> GetByCustomerId(int customerId);
        IDataResult<List<Rental>> GetByDate(DateTime startDate,DateTime endDate);
        IDataResult<List<Rental>> GetRentals();
        IDataResult<List<RentalDetailDto>> GetAllRentalsDetails();
    }
}
