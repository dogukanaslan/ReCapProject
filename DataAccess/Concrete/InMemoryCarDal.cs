using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=2000, ModelYear= 2013, Description="Fiat Egea"},
                new Car{Id=2, BrandId=2, ColorId=1, DailyPrice=2500, ModelYear= 2015, Description="Opel Corsa"},
                new Car{Id=3, BrandId=3, ColorId=3, DailyPrice=10000, ModelYear= 2019, Description="BMW M5"},
                new Car{Id=4, BrandId=4, ColorId=2, DailyPrice=3000, ModelYear= 2020, Description="Seat Leon"},
                new Car{Id=5, BrandId=5, ColorId=2, DailyPrice=20000, ModelYear= 2020, Description="Mercedes AMG"},
                new Car{Id=6, BrandId=2, ColorId=1, DailyPrice=1900, ModelYear= 2014, Description="Ford Focus"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
           return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
        }
    }
}
