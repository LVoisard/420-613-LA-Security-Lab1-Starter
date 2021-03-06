﻿
using SecurityLab1_Starter.Infrastructure.Abstract;
using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        string fileName = "userAccess.log";

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Username, model.Password))
                {
                    Logger.Log(model.Username + ",logged in",fileName);
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    Logger.Log( model.Username + ",tried to log in unsuccessfully",fileName);
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                Logger.Log("User: " + model.Username + ",encountered a loggin error",fileName);
                return View();
            }
        }

        public ActionResult Logout(string returnUrl)
        {
            Logger.Log( System.Web.HttpContext.Current.User.Identity.Name + ",Loggout", fileName);
            authProvider.DeAuthenticate();
            return Redirect(returnUrl ?? Url.Action("Index", "Home"));
        }
    }
}