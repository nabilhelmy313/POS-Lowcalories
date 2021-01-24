using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize]
    public class DailyOrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public DailyOrderController(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        public async  Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin")||User.IsInRole("CustomerService"))
            {
                var model = new DailyOrderVM
                {
                    Branches = _context.Branches.ToList(),
                    Serchdate = DateTime.Now,
                    Orders = _context.Orders.Where(s => s.Status == 3 && s.OrderDate.Date == DateTime.Now.Date).OrderByDescending(o => o.OrderDate).ToList(),
                };
                ViewBag.total = model.Orders.Sum(t => t.Total);

                return View(model);
            }
            else
            {
                var userid = userManager.GetUserId(HttpContext.User);
                var user =await userManager.FindByIdAsync(userid);
                var model = new DailyOrderVM
                {
                    Branches = _context.Branches.ToList(),
                    Serchdate = DateTime.Now,
                    Orders = _context.Orders.Include(b=>b.Branch)
                    .Where(s => s.Status == 3 && s.OrderDate.Date == DateTime.Now.Date&&s.Branch.Name==user.Branch).OrderByDescending(o => o.OrderDate).ToList(),
                };
                ViewBag.total = model.Orders.Sum(t => t.Total);

                return View(model);
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> SearchDate(DailyOrderVM date)
        {
            if (User.IsInRole("Admin")||User.IsInRole("CustomerService"))
            {
                
                if (date.CustPhone==null && date.BranchId == 0)
                {
                    DailyOrderVM vM = new DailyOrderVM()
                    {
                        Branches = _context.Branches.ToList(),
                        Serchdate = date.Serchdate,
                        Orders = _context.Orders.
                        Where(s => s.Status == 3 
                        && s.OrderDate.Date == date.Serchdate.Date).
                        OrderByDescending(o => o.OrderDate).ToList(),
                    };
                   
                    ViewBag.total = vM.Orders.Sum(t => t.Total);
                    return View("Index", vM);
                }
                else if (date.CustPhone != null && date.BranchId != 0)
                {

                    DailyOrderVM vM = new DailyOrderVM()
                    {
                        Branches = _context.Branches.ToList(),
                        Serchdate = date.Serchdate,
                        Orders = _context.Orders.Include(b => b.Branch)
                        .Where(s => s.Status == 3 &&
                        s.OrderDate.Date == date.Serchdate.Date &&
                        s.CustPhone == date.CustPhone &&
                        s.Branch== _context.Branches.Find(date.BranchId)
                        )
                        .OrderByDescending(o => o.OrderDate).ToList(),
                    };
                    ViewBag.total = vM.Orders.Sum(t => t.Total);
                    return View("Index", vM);
                }

                else if (date.CustPhone != null && date.BranchId == 0)
                {
                   
                    DailyOrderVM vM = new DailyOrderVM()
                    {
                        Branches = _context.Branches.ToList(),
                        Serchdate = date.Serchdate,
                        Orders = _context.Orders.Include(b => b.Branch)
                        .Where(s => s.Status == 3 &&
                        s.OrderDate.Date == date.Serchdate.Date &&
                        s.CustPhone == date.CustPhone 
                        )
                        .OrderByDescending(o => o.OrderDate).ToList(),
                    };
                    ViewBag.total = vM.Orders.Sum(t => t.Total);
                    return View("Index", vM);
                }
                else if (date.CustPhone == null && date.BranchId != 0)
                {
                    DailyOrderVM vM = new DailyOrderVM()
                    {
                        Branches = _context.Branches.ToList(),
                        Serchdate = date.Serchdate,
                        Orders = _context.Orders.Include(b=>b.Branch)
                        .Where(s => s.Status == 3 &&
                        s.OrderDate.Date == date.Serchdate.Date &&
                        s.Branch == _context.Branches.Find(date.BranchId))
                        .OrderByDescending(o => o.OrderDate).ToList(),
                    };
                    ViewBag.total = vM.Orders.Sum(t => t.Total);
                    return View("Index", vM);
                }
                return View();
            }
            else
            {
                var userid = userManager.GetUserId(HttpContext.User);
                var user = await userManager.FindByIdAsync(userid);
                if (date.CustPhone != null)
                {
                    DailyOrderVM vM = new DailyOrderVM()
                    {
                        Branches = _context.Branches.ToList(),
                        Serchdate = date.Serchdate,
                        Orders = _context.Orders.Include(b => b.Branch).
                        Where(s => s.Status == 3 &&
                        s.OrderDate.Date == date.Serchdate.Date &&
                        s.Branch.Name == user.Branch &&
                        s.CustPhone==date.CustPhone
                        )
                        .OrderByDescending(o => o.OrderDate).ToList(),
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
                        Orders = _context.Orders.Include(b => b.Branch).
                        Where(s => s.Status == 3 &&
                        s.OrderDate.Date == date.Serchdate.Date &&
                        s.Branch.Name == user.Branch)
                        .OrderByDescending(o => o.OrderDate).ToList(),
                    };
                    ViewBag.total = vM.Orders.Sum(t => t.Total);
                    return View("Index", vM);
                }
            }
           
           
        }
        public IActionResult Details(int id)
        {
            
            var Order = _context.Orders.Where(i => i.Id == id).FirstOrDefault();
            var detail = _context.OrderDetails.Include(a=>a.Meal).
                Include(o=>o.Order)
                .Where(oid => oid.Order == Order).ToList();
            List<string> mealname = new List<string>();
            foreach (var item in detail)
            {
                if (item.Meal.IsChild==true)
                {
                    var meal = _context.Meals.Where(i => i.Id == item.Meal.ParentId).FirstOrDefault().Name;
                    mealname.Add(meal);
                }
            }
            ViewBag.MealNameList = mealname;
            return View(detail);
        }
    }
}
