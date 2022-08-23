using Core1.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from cr in context.Cars
                             join c in context.Colors on cr.ColorId equals c.ColorId
                             join b in context.Brands on cr.BrandId equals b.BrandId
                             select new CarDetailsDto
                             {   
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = cr.DailyPrice,
                                 Descriptions = cr.Descriptions, 
                                 ModelYear = cr.ModelYear,
                                 CarId = cr.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 ImagePath = (from m in context.CarImages where m.CarId == cr.CarId select m.ImagePath).FirstOrDefault()
                             };
                return filter == null
                 ? result.ToList()
                 : result.Where(filter).ToList();
            }
        }
    }
}

