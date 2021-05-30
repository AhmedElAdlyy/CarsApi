using CarsApi.Models;
using CarsApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Services.Implementation
{
    public class UserDb : IUser
    {
        private CarsContext _db;

        public UserDb(CarsContext db)
        {
            _db = db;
        }
        public User Register(User user)
        {
            User AnonUser = new User
            {
                Email = user.Email,
                FullName = user.FullName,
                NationalId = user.NationalId,
                PersonalLicenceNo = user.PersonalLicenceNo,
                Password = user.Password
            };

            try
            {
                _db.User.Add(AnonUser);
                Save();
                return AnonUser;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private void Save()
        {
            _db.SaveChanges();
        }


    }
}
