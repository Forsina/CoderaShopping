using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using CoderaShopping.Business.Mappers;
using CoderaShopping.Business.Models;
using CoderaShopping.DataNHibernate;
using CoderaShopping.DataNHibernate.Repositories;
using CoderaShopping.Domain;

namespace CoderaShopping.Business.Services
{
    public interface IUserService
    {
        //  To UI
        List<UserGridModel> GetAll();
        UserViewModel GetById(Guid id);
        int UserListCount();
        List<UserGridModel> PaginateUsers(int page, int size);

        //  To DB
        void Delete(Guid id);
        void CreateUser(UserViewModel userModel);
        void EditUser(UserViewModel userModel);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public List<UserGridModel> GetAll()
        {
            _unitOfWork.BeginTransaction();

            if (_userRepository.GetAll() == null)
            {
                throw new Exception("Empty User List");
            }
            var users = _userRepository.GetAll().Select(x => x.MapToGridModel()).ToList();
            _unitOfWork.Commit();

            //return just users with status active
            //var users = _userRepository.GetAll()
            //    .Where(x => x.Status == UserStatus.Active)
            //    .Select(x => x.MapToGridModel()).ToList();

            return users;
        }

        public UserViewModel GetById(Guid id)
        {
            _unitOfWork.BeginTransaction();

            var user = _userRepository.GetById(id).MapToViewModel();

            _unitOfWork.Commit();

            return user;
        }

        public int UserListCount()
        {
            _unitOfWork.BeginTransaction();

            var count = _userRepository.GetAll().Count();

            _unitOfWork.Commit();

            return count;
        }

        public List<UserGridModel> PaginateUsers(int page, int size)
        {
            _unitOfWork.BeginTransaction();

            var result = _userRepository.GetAll().Skip((page - 1) * size).Take(size).Select(x => x.MapToGridModel()).ToList();

            _unitOfWork.Commit();

            return result;
        }

        public void Delete(Guid userId)
        {
            _unitOfWork.BeginTransaction();

            var curentUser = _userRepository.GetById(userId);

            if (userId == null)
            {
                throw new Exception("Bad Request");
            }

            _userRepository.Delete(curentUser);

            _unitOfWork.Commit();
        }

        public void CreateUser(UserViewModel userModel)
        {
            _unitOfWork.BeginTransaction();

            User user = new User();

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Country = userModel.Country;
            user.City = userModel.City;
            user.Zip = userModel.Zip;
            user.Address = userModel.Address;
            user.ContactNumber = userModel.ContactNumber;
            user.Email = userModel.Email;
            user.Password = userModel.Password;
            user.UserStatus = userModel.UserStatus;
            //user.MemberSince = userModel.MemberSince;

            if (!_userRepository.IsUserUnique(user))
            {
                throw new Exception("User Already exist");
            }

            _userRepository.Add(user);

            _unitOfWork.Commit();
        }

        public void EditUser(UserViewModel userModel)
        {
            _unitOfWork.BeginTransaction();

            var curentUser = _userRepository.GetById(userModel.UserId.Value);

            if (curentUser == null)
            {
                throw new Exception("Invalid ID");
            }

            curentUser.FirstName = userModel.FirstName;
            curentUser.LastName = userModel.LastName;
            curentUser.Country = userModel.Country;
            curentUser.City = userModel.City;
            curentUser.Zip = userModel.Zip;
            curentUser.Address = userModel.Address;
            curentUser.ContactNumber = userModel.ContactNumber;
            curentUser.Email = userModel.Email;
            curentUser.Password = userModel.Password;
            curentUser.UserStatus = userModel.UserStatus;
            //curentUser.MemberSince = userModel.MemberSince;

            if (!_userRepository.IsUserUnique(curentUser))
            {
                throw new Exception("User Already exist");
            }

            _userRepository.Update(curentUser);

            _unitOfWork.Commit();
        }
    }
}
