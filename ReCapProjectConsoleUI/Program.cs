using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ReCapProjectConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //Console.WriteLine(Messages.ColorAdded);
            //colorManager.Add(new Color { ColorId = 5, ColorName = "Orange" });
            //var result = carManager.GetCarDetails();
            //if (result.Success == true)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.Descriptions + " / " + car.DailyPrice + " / " + car.ColorName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            CarRentalManager carRentalManager = new CarRentalManager(new EfCarRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            carRentalManager.Add(new CarRental { CarId = 1, CustomerId = 172, RentId = 1 });
            var result = userManager.Add(new User { UserId = 16328, UserFirstName = "Doğukan", UserLastName = "Aslan", UserEmail = "dogukanaslan_@gmail.com", Password = "1996326ds" });
            Console.WriteLine(result.Message);
            var result2 = customerManager.Add(new Customer { CustomerId = 1629435, UserId = 16328, CompanyName = "Single Customer" });
            Console.WriteLine(result2.Message);
            var result3 = carRentalManager.Add(new CarRental { RentId = 12022, CarId = 4, CustomerId = 1629435, RentDate = new DateTime(2022, 03, 15), ReturnDate = new DateTime(2022, 03, 17) });
            Console.WriteLine(result3.Message);
        }
    }
}
