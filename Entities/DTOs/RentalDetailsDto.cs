using Core1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailsDto:IDto
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public string FullName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ModelName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
