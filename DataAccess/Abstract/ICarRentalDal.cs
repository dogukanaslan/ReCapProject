﻿using Core1.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarRentalDal:IEntityRepository<CarRental>
    {
        List<RentalDetailsDto> GetRentalDetails();
    }
}
