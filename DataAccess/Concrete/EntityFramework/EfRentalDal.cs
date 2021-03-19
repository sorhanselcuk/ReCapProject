using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (var context = new RentCarDbContext())
            {
                var result = from rentals in context.Rentals
                             join customers in context.Customers
                             on rentals.CustomerId equals customers.Id
                             join users in context.Users
                             on customers.UserId equals users.Id
                             join cars in context.Cars
                             on rentals.CarId equals cars.Id
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             select new RentalDetailDto
                             {
                                 Id=rentals.Id,
                                 ReturnDate=rentals.ReturnDate,
                                 FirstName=users.FirstName,
                                 LastName=users.LastName,
                                 BrandName=brands.Name,
                                 ColorName=colors.Name
                             };
                return result.ToList();
                            
            }
        }
    }
}
