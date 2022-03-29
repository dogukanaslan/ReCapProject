using Core1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        [Key]
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string  UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
