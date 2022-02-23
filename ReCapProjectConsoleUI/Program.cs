using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using System;

namespace ReCapProjectConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                if (car.DailyPrice>5000)
                {
                    Console.WriteLine("Modeli : " + " " + car.Description);
                    Console.WriteLine("Günlük Ücreti : " + " " + car.DailyPrice);
                    Console.WriteLine("Model Tarihi : " + " " + car.ModelYear);
                }
            }
        }
    }
}
