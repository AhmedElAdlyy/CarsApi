﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string Password { get; set; }


        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }


        [StringLength(14, MinimumLength = 14)]
        public string NationalId { get; set; }


        public string PersonalLicenceNo { get; set; }


        public virtual ICollection<UserCar> UserCars { get; set; }
        public virtual ICollection<UserPhone> UserPhones { get; set; }
    }
}
