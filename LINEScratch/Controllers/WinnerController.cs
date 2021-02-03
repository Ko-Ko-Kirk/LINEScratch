using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LINEScratch.Models;
using LINEScratch.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LINEScratch.Controllers
{
    public class WinnerController : Controller
    {
        private readonly DBContext _context;

        public WinnerController(DBContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var winnerList = (from m in _context.LINEMember
                              join w in _context.Prize
                              on m.Id equals w.PrizeId
                              select new ListWinner 
                              {
                                PrizeId = w.PrizeId,
                                LineId = m.LineId,
                                PicUrl = m.PicUrl,
                                Name = m.Name,
                                PrizeName = w.PrizeName
                              }).OrderBy(m => m.PrizeId).ToList();

            winnerList.Reverse();

            return View(winnerList); 
        }

        public ActionResult Members()
        {
            var member = _context.LINEMember.Where(x => x.LineId != "");

            return View(member);
        }

    }
}
