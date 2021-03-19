using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails()
        {
            using (var context = new RentCarDbContext())
            {
                var result = from cars in context.Cars
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id 
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             select new CarDetailDto { 
                                CarId=cars.Id,
                                CarName=cars.Name,
                                BrandName=brands.Name,
                                ColorName=colors.Name,
                                DailyPrice=cars.DailyPrice,
                                Description=cars.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrandId(int brandId)
        {
            using (var context = new RentCarDbContext())
            {
                var result = from cars in context.Cars
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             where cars.BrandId == brandId
                             select new CarDetailDto
                             {
                                 CarId = cars.Id,
                                 CarName = cars.Name,
                                 BrandName = brands.Name,
                                 ColorName = colors.Name,
                                 DailyPrice = cars.DailyPrice,
                                 Description = cars.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByColorId(int colorId)
        {
            using (var context = new RentCarDbContext())
            {
                var result = from cars in context.Cars
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             where cars.ColorId == colorId
                             select new CarDetailDto
                             {
                                 CarId = cars.Id,
                                 CarName = cars.Name,
                                 BrandName = brands.Name,
                                 ColorName = colors.Name,
                                 DailyPrice = cars.DailyPrice,
                                 Description = cars.Description
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarsDetailsById(int id)
        {
            using (var context = new RentCarDbContext())
            {
                var result = from cars in context.Cars
                             join brands in context.Brands
                             on cars.BrandId equals brands.Id
                             join colors in context.Colors
                             on cars.ColorId equals colors.Id
                             where cars.Id == id
                             select new CarDetailDto
                             {
                                 CarId = cars.Id,
                                 CarName = cars.Name,
                                 BrandName = brands.Name,
                                 ColorName = colors.Name,
                                 DailyPrice = cars.DailyPrice,
                                 Description = cars.Description
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
