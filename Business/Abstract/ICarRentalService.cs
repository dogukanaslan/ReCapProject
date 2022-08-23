using Core1.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarRentalService
    {
        IResult Add(CarRental carRental);
        IResult Delete(CarRental carRental);
        IResult Update(CarRental carRental);
        IDataResult<CarRental> GetByCustomerId(int customerId);
        IDataResult<List<CarRental>> GetAll();
        IDataResult<List<RentalDetailsDto>> GetRentalDetails();
    }
}
