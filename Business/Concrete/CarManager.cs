using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core1.Aspects.Autofac.Caching;
using Core1.Aspects.Autofac.Performance;
using Core1.Aspects.Autofac.Transaction;
using Core1.Aspects.Autofac.Validation;
using Core1.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice< 2000)
            {
                throw new Exception("");
            }
            Add(car);

            return null;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessDataResult<Car>(Messages.CarDeleted);
        }
        [PerformanceAspect(5)]
        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 15)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>((_carDal.GetAll(c => c.BrandId == brandId)), Messages.CarListed);
        }

        public IDataResult<Car> GetByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(cr => cr.CarId == carId));
        }

        public IDataResult<List<Car>>  GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
