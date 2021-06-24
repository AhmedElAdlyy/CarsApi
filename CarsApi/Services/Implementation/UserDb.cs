﻿using CarsApi.Models;
using CarsApi.Services.Interface;
using CarsApi.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace CarsApi.Services.Implementation
{
    public class UserDb : IUser
    {
        private UserManager<ApplicationUser> _userManager;
        private IConfiguration _configuration;
        private IMail _mail;
        private CarsContext _db;

        public UserDb(UserManager<ApplicationUser> userManager, IConfiguration configuration, IMail mail, CarsContext db)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mail = mail;
            _db = db;
        }
        public async Task<UserProfileViewModel> GetProfileData(string userId)
        {
            UserProfileViewModel userProfileData = new UserProfileViewModel();
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new UserProfileViewModel { IsSuccess = false };

            var phones =  _db.UserPhone.Where(w => w.UserId == userId);
            foreach (var phone in phones)
            {
                userProfileData.Phones.Add(phone.Number);
            }

            userProfileData.IsSuccess = true;
            userProfileData.Fullname = user.FullName;
            userProfileData.Email = user.Email;

            return userProfileData;
        }
        public async Task<MessageResponseViewModel> RegisterAsync(RegisterViewModel registeration)
        {
            if (registeration == null)
                throw new NullReferenceException("User is null");

            var identityUser = new ApplicationUser
            {
                Email = registeration.Email,
                UserName = registeration.Email,
                FullName = registeration.FullName,
                NationalId = registeration.NationalId,
                PersonalLicenceNo = registeration.PersonalLicenceNo
            };

            var result = await _userManager.CreateAsync(identityUser, registeration.Password);

            if (result.Succeeded)
                return new MessageResponseViewModel
                {
                    Message = "account created successfully",
                    IsSuccess = true,
                };


            return new MessageResponseViewModel
            {
                Message = "something went wrong while creating account",
                IsSuccess = false,
                Errors = result.Errors.Select(s => s.Description)
            };
        }

        public async Task<MessageResponseViewModel> LoginUserAsync([FromBody] LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return new MessageResponseViewModel
                {
                    Message = "there is no account attached to that email",
                    IsSuccess = false
                };
            }

            bool result = await _userManager.CheckPasswordAsync(user, login.Password);

            if (!result)
            {
                return new MessageResponseViewModel
                {
                    Message = "Invalid Credenitials",
                    IsSuccess = false
                };
            }

            var Claims = new[]
            {
                new Claim("Email",login.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(_configuration["AuthSettings:Issuer"], _configuration["AuthSettings:Issuer"], claims: Claims, expires: DateTime.Now.AddMinutes(120), signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new MessageResponseViewModel
            {
                Token = tokenString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };
        }

        public async Task<MessageResponseViewModel> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new MessageResponseViewModel
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new MessageResponseViewModel
                {
                    IsSuccess = true,
                    Message = "Email Confirmed Successfully"
                };


            return new MessageResponseViewModel
            {
                IsSuccess = false,
                Message = "Email not confirmed",
                Errors = result.Errors.Select(s => s.Description)
            };

        }

        public async Task<MessageResponseViewModel> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new MessageResponseViewModel
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var encodedChangePaaswordToken = Encoding.UTF8.GetBytes(token);
            var validChangePasswordToken = WebEncoders.Base64UrlEncode(encodedChangePaaswordToken);

            string url = $"{_configuration["AppUrl"]}api/user/resetpassword?email={email}&token={validChangePasswordToken}";

            await _mail.SendEmilAsync(email, "Reset Password", $"<h1>Reset Your Password</h1> <p>to resest your password</p><a href='{url}' >click here</a>");

            return new MessageResponseViewModel
            {
                IsSuccess = true,
                Message = "reset password url has been sent to your email",
            };

        }

        public async Task<MessageResponseViewModel> ResetPasswordAsync(ResetPasswordViewModel reset)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(reset.Email);
            if (user == null)
                return new MessageResponseViewModel
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(reset.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, reset.Password);

            if (result.Succeeded)
                return new MessageResponseViewModel
                {
                    IsSuccess = true,
                    Message = "password changes successfully"
                };

            return new MessageResponseViewModel
            {
                Message = "something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(s => s.Description)
            };
        }


        private async Task<string> GenerateConfirmationTokenURL(ApplicationUser identityUser)
        {
            var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
            var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
            var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

            return $"{_configuration["AppUrl"]}api/user/ConfirmEmail?userId={identityUser.Id}&token={validEmailToken}";
        }

    }
}
