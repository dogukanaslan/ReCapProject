using Core1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    
    public class CarRental:IEntity
    {
       [Key]
        public int RentId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int PaymentId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
