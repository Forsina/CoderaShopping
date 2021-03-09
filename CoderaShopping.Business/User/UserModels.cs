using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using CoderaShopping.Domain;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;
using static CoderaShopping.Domain.User;

namespace CoderaShopping.Business.Models
{
    //Communicate between user and controller, 

    [Validator(typeof(UserViewModelValidator))]
    public class UserViewModel
    {
        public Guid? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStat UserStatus { get; set; }

    }

    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("Name should not be empty!");
            //.Matches("[a-z][A-Z]").WithMessage("The name can not contain numbers")
            //.Matches(@"^[\p{L} \.'\-]+$").WithMessage("The name is not in a valid format")
            //.Length(2, 50).WithMessage("The length of the name is not valid");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Last name should not be empty!");
            //.Matches("[a-z][A-Z]").WithMessage("The last name can not contain numbers")
            //.Matches("/^[a-z ,.'-]+$/i").WithMessage("The last name is not in a valid format")
            //.Length(2, 50).WithMessage("The length of the last name is not valid");

            RuleFor(x => x.Country)
                .NotNull().WithMessage("You must choose a country");

            RuleFor(x => x.Zip)
                .NotNull().WithMessage("Zip code should not be empty!");
            //.Matches("^[1,2,6,7]{4}").WithMessage("Enter an valid zip code.");

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Address is requiered!");
            //.Length(5, 50).WithMessage("Enter an valid address.");

            RuleFor(x => x.ContactNumber)
                .NotNull().WithMessage("Contact number should not be empty!");
            //.Matches("^07[1-9]{6}").WithMessage("You must enter an valid mobile phone."); ;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Wou must enter an email.");
            //.EmailAddress().WithMessage("You must enter an valid email address.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password not be empty!");
            //.Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\\$%\\^&\\*])(?=.{8,})")
            //.WithMessage("Password sepoused to contain at least 1 letter,1 special caracter and 1 capital letter.");

            //RuleFor(x => x.isAdmin)
            //    .NotNull().WithMessage("You must choose the role of user");

            RuleFor(x => x.UserStatus)
                .NotNull().WithMessage("You must choose the status of user");

            //RuleFor(x => x.MemberSince)
            //    .NotNull().WithMessage("You must choose the date of user validation");
        }
    }

    [Validator(typeof(UserGridModelValidator))]
    public class UserGridModel
    {
        public Guid UserId { get; internal set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public UserStat UserStatus { get; set; }
        public string MemberSince { get; set; }
    }
    public class UserGridModelValidator : AbstractValidator<UserGridModel>
    {
        public UserGridModelValidator()
        {

        }
    }
}
