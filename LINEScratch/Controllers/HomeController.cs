using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LINEScratch.Models;
using System.Xml;
using LINEScratch.ViewModels;
using Microsoft.Extensions.Configuration;

namespace LINEScratch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DBContext _context;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index(Result r)
        {
            ViewBag.ID = r.LineId;
            ViewBag.ImgUrl = r.ImgUrl;
            ViewBag.Name = r.UserName;
            return View();
        }
        public IActionResult UseLINE()
        {
            return View();
        }
        public IActionResult Loading()
        {
            ViewBag.LIFFID = _configuration.GetValue<string>("LIFF:LIFFID1");
            return View();
        }

        [HttpPost]
        public IActionResult Loading(string userId,string displayName,string pictureUrl,string statusMessage)
        {
            var member = new LINEMember() { 
                LineId = userId,
                Name = displayName,
                PicUrl = pictureUrl,
                Status = statusMessage
            };

            if (_context.LINEMember.FirstOrDefault(m => m.LineId == member.LineId) == null)
            {
                _context.Add(member);
                _context.SaveChanges();
            }

            var id = _context.LINEMember.FirstOrDefault(m => m.LineId == member.LineId).Id;
            var name = _context.LINEMember.FirstOrDefault(m => m.LineId == member.LineId).Name;

            //使用者是否抽中得獎票卷號碼
            var winId = _context.Prize.FirstOrDefault(m => m.PrizeId == id);

            if (winId == null)
            {
                Result r = new Result()
                {
                    ImgUrl = "~/img/thankyou.png",
                    Id = id,
                    LineId = member.LineId,
                    PrizeName = "Thankyou",
                    UserName = name
                };
                return RedirectToAction("Index", r); 
            }
            else
            {
                Result r = new Result()
                {
                    ImgUrl = winId.PrizePic,
                    Id = id,
                    LineId = member.LineId,
                    PrizeName = winId.PrizeName,
                    UserName = name
                };
                return RedirectToAction("Index", r);
            }
        }

    }
}
