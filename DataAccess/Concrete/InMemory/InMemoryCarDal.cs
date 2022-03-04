using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=2000, ModelYear= 2013, Descriptions="Fiat Egea"},
                new Car{CarId=2, BrandId=6, ColorId=1, DailyPrice=2500, ModelYear= 2015, Descriptions="Opel Corsa"},
                new Car{CarId=3, BrandId=3, ColorId=3, DailyPrice=10000, ModelYear= 2019, Descriptions="BMW M5"},
                new Car{CarId=4, BrandId=4, ColorId=2, DailyPrice=3000, ModelYear= 2020, Descriptions="Seat Leon"},
                new Car{CarId=5, BrandId=5, ColorId=2, DailyPrice=20000, ModelYear= 2020, Descriptions="Mercedes AMG"},
                new Car{CarId=6, BrandId=2, ColorId=1, DailyPrice=1900, ModelYear= 2014, Descriptions="Ford Focus"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
           return _cars.Where(c => c.CarId == id).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
        }
    }
}
