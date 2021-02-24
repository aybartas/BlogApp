using BlogApp.Entities.DTO.UserDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Business.Validation
{
    public class UserLoginValidator : AbstractValidator<UserLoginDTO>
    {
        public UserLoginValidator()
        {
            RuleFor(I => I.Username).NotEmpty().WithMessage("Username can't be null");
            RuleFor(I => I.Username).MinimumLength(5).WithMessage('Username should be more than 5 characters');
            RuleFor(I => I.Password).NotEmpty().WithMessage("Password can't be null");



        }
    }
}
