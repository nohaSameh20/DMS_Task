using Application.Interfaces;
using DMS.Application;
using Domain.Common;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users
{
    public class AddUserCommand : IAddUserCommand
    {
        IDatabaseService databaseService;
        readonly IHashService hashService;
        public AddUserCommand(IDatabaseService databaseServic, IHashService hashService)
        {
            this.databaseService = databaseServic;
            this.hashService = hashService;
        }
        public Guid Execute(AddUserModel model)
        {
            try
            {
                if (!model.ValidationState.IsValid)
                    throw new ValidationsException("Invalid_model", model.ValidationState.ValidationResults);

                bool userExist = databaseService.Users.Any(obj => obj.Active && obj.Email.ToUpper() == model.Email.Trim().ToUpper());

                if (userExist)
                    throw new BusinessException("User_exist", "ContactDuplicated");

                string salt = hashService.CreateSalt();
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Active = true,
                    Deleted=false,
                    Name=model.Name,
                    CreatedAt=DateTime.Now,
                    EntityStatus= EntityStatus.New,
                    UserRole=model.UserRole,
                    HashPassword = hashService.Create(model.Password, salt),
                    Salt = salt,

                };
                
                databaseService.Users.Add(user);
                databaseService.SaveChanges();

                return user.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
