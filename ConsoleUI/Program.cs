using Business.Absract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CrudTest();

            //CarServiceTest();

            //IRentalService rentalService = new RentalManager(new EfRentalDal());
            //ICarService carService = new CarManager(new EfCarDal());
            //IUserService userService = new UserManager(new EfUserDal());
            //ICustomerService customerService = new CustomerManager(new EfCustomerDal());
            //rentalService.GetRentals().Data.ForEach((r) =>
            //{
            //    var car = carService.GetById(r.CarId).Data;
            //    var customer = customerService.GetById(r.CustomerId).Data;
            //    var user = userService.GetByUserId(customer.UserId).Data;
            //    Console.WriteLine($"Id              {r.Id}");
            //    Console.WriteLine($"CarId           {r.CarId}");
            //    Console.WriteLine($"CustomerId      {r.CustomerId}");
            //    Console.WriteLine($"Return Date     {r.ReturnDate.ToString()}");

            //    Console.WriteLine("Car Details --------->");
                
            //    Console.WriteLine($"Car's name is           {car.Name}");
            //    Console.WriteLine($"Car's Description is    {car.Description}");
            //    Console.WriteLine($"Car's daily price is    {car.DailyPrice.ToString("#.##")}");

            //    Console.WriteLine("Car Details --------->");

            //    Console.WriteLine();

            //    Console.WriteLine("Customer Details --------->");

            //    Console.WriteLine($"Customer's first name is         {user.FirstName}");
            //    Console.WriteLine($"Customer's last name is          {user.LastName}");
            //    Console.WriteLine($"Customer's E-Mail address is     {user.EMail}");
            //    Console.WriteLine($"Customer's company name is       {customer.CompanyName}");

            //    Console.WriteLine("Customer Details --------->");
                
            //    Console.WriteLine();

            //    Console.WriteLine("-------------------------------------------------------------------------------------");

            //});

            //Console.ReadLine();
        }

        private static void CarServiceTest()
        {
            //ICarService carService = new CarManager(new EfCarDal());
            //carService.GetCarsDetails().Data.ForEach((c) =>
            //{
            //    Console.WriteLine($"Car id is {c.CarId}");
            //    Console.WriteLine($"Car's name is {c.CarName}");
            //    Console.WriteLine($"Car's brand name is {c.BrandName}");
            //    Console.WriteLine($"Car's color is {c.ColorName}");
            //    Console.WriteLine($"Car's daily price is {c.DailyPrice.ToString("#.##")}");
            //    Console.WriteLine("--------------------------");
            //});
        }

        private static void CrudTest()
        {
            //ICarService carService = new CarManager(new EfCarDal());
            //Car car1 = new Car { BrandId = 4, ColorId = 5, DailyPrice = 150, ModelYear = new DateTime(2016, 1, 1), Description = "5 Vites,Dizel" };
            //Car car2 = new Car { BrandId = 1, ColorId = 4, DailyPrice = 250, ModelYear = new DateTime(2018, 1, 1), Description = "6 Vites,Benzin" };
            //Car car3 = new Car { BrandId = 5, ColorId = 1, DailyPrice = 100, ModelYear = new DateTime(2012, 1, 1), Description = "5 Vites,LPG" };
            //Car car4 = new Car { BrandId = 2, ColorId = 7, DailyPrice = 375, ModelYear = new DateTime(2018, 1, 1), Description = "Camlıvan" };
            //carService.Add(car1);
            //carService.Add(car2);
            //carService.Add(car3);
            //carService.Add(car4);

            //carService.GetAll().Data.ForEach((c) => { Console.WriteLine($"{c.Description}"); });

            //carService.Delete(new Car { Id = 3 });
            //carService.GetAll().Data.ForEach((c) => { Console.WriteLine($"{c.Description}"); });

            //Console.WriteLine($"{carService.GetById(1).Data.ModelYear.Year}");

            //Car car4update = new Car { Id = 4, BrandId = 2, ColorId = 7, DailyPrice = 450, ModelYear = new DateTime(2018, 1, 1), Description = "Camlıvan" };
            //Console.WriteLine($"Günlük kirası = {carService.GetById(4).Data.DailyPrice} TL");

            //carService.Update(car4update);
            //Console.WriteLine($"Günlük kirası = {carService.GetById(4).Data.DailyPrice} TL");
        }
    }
}
