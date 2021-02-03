using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LINEScratch.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormCollection post)
        {
            string account = post["account"];
            string password = post["password"];

            string userAccount = _configuration.GetValue<string>("USER:account");
            string userPassword = _configuration.GetValue<string>("USER:password");

            if (String.IsNullOrEmpty(account) || String.IsNullOrEmpty(password))
            {
                ViewBag.Msg = "請輸入帳號密碼";
                return View("Index");
            }
            else {
                if (userAccount.Equals(account) && userPassword.Equals(password))
                {
                    HttpContext.Session.SetString("account", account);
                    return RedirectToAction("Index", "Prize");
                }
                else {
                    ViewBag.Msg = "帳號或密碼錯誤";
                    return View("Index");
                }
            }
        }
    }
}
