using Business.Absract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new ImCarDal());
            Car car1 = new Car { Id = 1, BrandId = 4, ColorId = 5, DailyPrice = 150, ModelYear = new DateTime(2016,1,1), Description = "5 Vites,Dizel" };
            Car car2 = new Car { Id = 2, BrandId = 1, ColorId = 4, DailyPrice = 250, ModelYear = new DateTime(2018,1,1), Description = "6 Vites,Benzin" };
            Car car3 = new Car { Id = 3, BrandId = 5, ColorId = 1, DailyPrice = 100, ModelYear = new DateTime(2012,1,1), Description = "5 Vites,LPG" };
            Car car4 = new Car { Id = 4, BrandId = 2, ColorId = 7, DailyPrice = 375, ModelYear = new DateTime(2018,1,1), Description = "Camlıvan" };
            carService.Add(car1);
            carService.Add(car2);
            carService.Add(car3);
            carService.Add(car4);

            carService.GetAll().ForEach((c) => { Console.WriteLine($"{c.Description}"); });

            carService.Delete(new Car { Id=3 });
            carService.GetAll().ForEach((c) => { Console.WriteLine($"{c.Description}"); });

            Console.WriteLine($"{carService.GetById(1).ModelYear.Year}");

            Car car4update = new Car { Id = 4, BrandId = 2, ColorId = 7, DailyPrice = 450, ModelYear = new DateTime(2018,1,1), Description = "Camlıvan" };
            Console.WriteLine($"Günlük kirası = {carService.GetById(4).DailyPrice} TL");

            carService.Update(car4update);
            Console.WriteLine($"Günlük kirası = {carService.GetById(4).DailyPrice} TL");

            Console.ReadLine();
        }
    }
}
