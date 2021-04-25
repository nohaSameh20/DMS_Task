using Application.Data;
using Application.Interfaces;
using DMS.Application;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        IDatabaseService databaseService;
        IHashService hashService;
        public AccountService(IDatabaseService databaseService, IHashService hashService)
        {
            this.databaseService = databaseService;
            this.hashService = hashService;
        }
        public LoginDto Login(LoginModel model)
        {
            //check model Validation
            if (!model.ValidationState.IsValid)
                throw new ValidationsException("Invalid_model", model.ValidationState.ValidationResults);

            var user = databaseService.Users.Single(obj => obj.Email.ToUpper() == model.Email.ToUpper());

            //Checking email
            if (user == null)
                throw new BusinessException("Incorrect_Email", "EmailNotFound");

            //Checking password
            if (!hashService.Validate(model.Password, user.Salt, user.HashPassword))
                throw new BusinessException("Incorrect_password", "InvalidPassword");


            LoginDto res = new LoginDto()
            {
                Name = user.Name,
                UserRole = user.UserRole,
            };
            return res;

        }
    }
}