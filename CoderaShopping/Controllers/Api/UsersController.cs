using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.UI.WebControls;
using CoderaShopping.Business.Models;
using CoderaShopping.Business.Services;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace CoderaShopping.Controllers.Api
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //CRUD

        [HttpPost]
        public ActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Json(users);
        }

        [HttpPost]
        public ActionResult GetById(Guid userId)
        {
            var user = _userService.GetById(userId);
            return Json(user);
        }

        [HttpPost]
        public ActionResult Delete(Guid userId)
        {
            _userService.Delete(userId);
            return Json(true);
        }

        //[HttpPost]
        //public ActionResult DeleteMultipleUsers(IList<UserGridModel> userModel)
        //{
        //    _userService.DeleteMultipleUsers(userModel);
        //    return Json(true);
        //}

        [HttpPost]
        public ActionResult CreateUser(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("CreateUser Error");
            }

            _userService.CreateUser(userModel);
            return Json(true);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("EditUser Error");
            }

            _userService.EditUser(userModel);
            return Json(true);
        }

        //Search
        [HttpPost]
        public ActionResult SearchName(string userName)
        {
            var search = _userService.SearchName(userName);
            return Json(search);
            //return Json(_userService.SearchByName(userName), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SearchByStatus(string userStatus)
        {
            var search = _userService.SearchName(userStatus);
            return Json(search);
            //return Json(_userService.SearchByName(userName), JsonRequestBehavior.AllowGet);
        }

        //Paginate
        [HttpPost]
        public ActionResult UserListCount()
        {
            return Json(_userService.UserListCount(), JsonRequestBehavior.AllowGet);
            //    var count = _userService.UserListCount();
            //    return Json(count);
        }

        [HttpPost]
        public ActionResult PaginateUsers(int page, int size)
        {
            return Json(_userService.PaginateUsers(page, size), JsonRequestBehavior.AllowGet);
            //var paginate = _userService.PaginateUsers(page, size);
            //    return Json(paginate);
        }
    }
}