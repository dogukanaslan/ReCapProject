using Business.Abstract;
using Business.Constants;
using Core1.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarRentalManager : ICarRentalService
    {
        ICarRentalDal _carRentalDal;

        public CarRentalManager(ICarRentalDal carRentalDal)
        {
            _carRentalDal = carRentalDal;
        }

        public IResult Add(CarRental carRental)
        {
            var check = _carRentalDal.GetAll(c => c.CarId == carRental.CarId && c.ReturnDate == null);
            if (check.Count>0)
            {
                return new ErrorResult(Messages.CarReturnInValid);
            }
            else
            {
                _carRentalDal.Add(carRental);
                return new SuccessResult(Messages.CarRentalAdded);
            }
        }

        public IResult Delete(CarRental carRental)
        {
            _carRentalDal.Delete(carRental);
            return new SuccessResult(Messages.CarRentalDeleted);
        }

        public IDataResult<List<CarRental>> GetAll()
        {
            return new SuccessDataResult<List<CarRental>>(_carRentalDal.GetAll(), Messages.CarRentalListed);
        }

        public IDataResult<CarRental> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CarRental>(_carRentalDal.Get(c=> c.CustomerId == customerId));
        }

        public IResult Update(CarRental carRental)
        {
            _carRentalDal.Update(carRental);
            return new SuccessResult(Messages.CarRentalUpdated);
        }
    }
}
