using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using CoderaShopping.Business.Models;
using CoderaShopping.Business.Services;

namespace CoderaShopping.Controllers.Api
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult GetById(Guid id)
        {
            return Json("SINGLE USER");
        }

        public ActionResult GetAll()
        {
            return Json("USERS ARRAY", JsonRequestBehavior.AllowGet);
        }
    }
}