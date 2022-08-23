using Core1.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarRentalDal : EfEntityRepositoryBase<CarRental, NorthwindContext>, ICarRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                     var result = from ca in context.Cars
                                   join b in context.Brands
                                   on ca.BrandId equals b.BrandId
                                   join re in context.CarRentals
                                   on ca.CarId equals re.CarId
                                   join co in context.Colors
                                   on ca.ColorId equals co.ColorId
                                   from u in context.Users
                                   join cu in context.Customers
                                   on u.Id equals cu.UserId
                                  from rent in context.CarRentals
                                  join p in context.Payments
                                  on rent.PaymentId equals p.PaymentId
                                  select new RentalDetailsDto
                                   {
                                       Id = ca.CarId,
                                       ColorName = co.ColorName,
                                       BrandName = b.BrandName,
                                       ModelName = ca.Descriptions,
                                       RentDate = re.RentDate,
                                       ReturnDate = re.ReturnDate,
                                       FullName = u.FirstName + " " + u.LastName,
                                       PaymentId = p.PaymentId


                                   };
                    return result.ToList();
            }
        }
    }
}
