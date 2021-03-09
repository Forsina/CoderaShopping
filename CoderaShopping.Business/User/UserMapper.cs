using System;
using CoderaShopping.Business.Models;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Mappers
{
    //transform data from domain object to viewModel object
    public static class UserMapper
    {
        public static UserViewModel MapToViewModel(this User user)
        {
            UserViewModel viewModel = new UserViewModel();

            viewModel.UserId = user.UserId;
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;
            viewModel.Country = user.Country;
            viewModel.City = user.City;
            viewModel.Zip = user.Zip;
            viewModel.Address = user.Address;
            viewModel.ContactNumber = user.ContactNumber;
            viewModel.Email = user.Email;
            viewModel.Password = user.Password;
            viewModel.UserStatus = user.UserStatus;
            //viewModel.MemberSince = user.MemberSince;

            return viewModel;
        }
        public static UserGridModel MapToGridModel(this User user)
        {
            UserGridModel gridModel = new UserGridModel();

            gridModel.UserId = user.UserId;
            gridModel.FullName = user.FirstName + " " + user.LastName;
            gridModel.Country = user.Country;
            gridModel.City = user.City;
            gridModel.Zip = user.Zip;
            gridModel.Address = user.Address;
            gridModel.ContactNumber = user.ContactNumber;
            gridModel.Email = user.Email;
            gridModel.UserStatus = user.UserStatus;
            string modifiedDateFormat = user.MemberSince.ToString(format: "dd/MM/yyyy");
            gridModel.MemberSince = modifiedDateFormat;

            return gridModel;
        }
    }
}
