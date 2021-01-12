using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Controllers
{
    public class DailyOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DailyOrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var model = new DailyOrderVM
            {
                Branches = _context.Branches.ToList(),
                Serchdate=DateTime.Now,
                Orders = _context.Orders.Where(s => s.Status == 3 && s.OrderDate.Date == DateTime.Now.Date).OrderByDescending(o => o.OrderDate).ToList(),
            };
            ViewBag.total = model.Orders.Sum(t => t.Total);

            return View(model);
        }
        [HttpGet]
        public IActionResult SearchDate(DailyOrderVM date)
        {
            if (date.BranchId==0)
            {
                DailyOrderVM vM = new DailyOrderVM()
                {
                    Branches = _context.Branches.ToList(),
                    Serchdate = date.Serchdate,
                    Orders = _context.Orders.Where(s => s.Status == 3 && s.OrderDate.Date == date.Serchdate.Date).OrderByDescending(o => o.OrderDate).ToList(),
                };
                ViewBag.total = vM.Orders.Sum(t => t.Total);
                return View("Index", vM);
            }
            else
            {
                DailyOrderVM vM = new DailyOrderVM()
                {
                    Branches = _context.Branches.ToList(),
                    Serchdate = date.Serchdate,
                    Orders = _context.Orders.Where(s => s.Status == 3 && s.OrderDate.Date == date.Serchdate.Date &&s.Branch==_context.Branches.Find(date.BranchId)).OrderByDescending(o => o.OrderDate).ToList(),
                };
                ViewBag.total = vM.Orders.Sum(t => t.Total);
                return View("Index", vM);
            }
           
        }
        public IActionResult Details(int id)
        {
            
            var Order = _context.Orders.Where(i => i.Id == id).FirstOrDefault();
            var detail = _context.OrderDetails.Include(a=>a.Meal).Include(o=>o.Order)
                .Where(oid => oid.Order == Order).ToList();
            
            return View(detail);
        }
    }
}
