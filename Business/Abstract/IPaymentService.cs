using Core1.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Add(Payment payment);

        IResult Delete(Payment payment);

        IDataResult<List<Payment>> GetAll();
    }
}
