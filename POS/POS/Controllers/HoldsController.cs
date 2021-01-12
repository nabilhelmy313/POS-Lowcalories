using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Hubs;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Controllers
{
    public class HoldsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<NotificationHub> hub;
        private readonly UserManager<ApplicationUser> userManager;

        public HoldsController(ApplicationDbContext context,
            IHubContext<NotificationHub> hub,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.hub = hub;
            this.userManager = userManager;
        }
        public IActionResult Index(HoldVM holdVM)
        {

            if (holdVM.CustPhone==null)
            {
                var stat = _context.Orders.Where(s => s.Status == 0 || s.Status == 1).ToList();
                holdVM.Orders = stat;
                if (stat.Count != 0)
                {
                    foreach (var item in stat)
                    {
                        if (item.Status == 0 || item.Status == 1)
                        {
                            var holde = _context.Orders.Where(s => s.Status == 0 || s.Status == 1).OrderByDescending(o => o.OrderDate).ToList();
                            holdVM.Orders = holde;
                            return View(holdVM);
                        }
                    }

                }

                return View(holdVM);
            }
            else
            {
                var stat = _context.Orders.Where(s=>s.CustPhone==holdVM.CustPhone).ToList();
                holdVM.Orders = stat; ;
                if (stat.Count != 0)
                {
                    foreach (var item in stat)
                    {
                        if (item.Status == 0 || item.Status == 1)
                        {
                            var holde = _context.Orders.Where(s => s.Status == 0 || s.Status == 1&&s.CustPhone==holdVM.CustPhone).OrderByDescending(o => o.OrderDate).ToList();
                            holdVM.Orders = holde;
                            return View(holdVM);
                        }
                    }

                }
                else
                {
                    holdVM.Orders = stat;
                    return View(holdVM);
                }
                return View(holdVM);
            }
           
        }
        //SEARCH CUSTOMER HOLD
        //public JsonResult SearchCustomer(string number)
        //{
        //    string html = @"
        //                <tr>
        //                    <td data-label='Order Number'># {0}</td>
        //                    <td data-label='Order Type'>{1}</td>
        //                    <td data-label='Customer Phone'>{5}</td>
        //                    <td data-label='Status'>{3}</td>
        //                    <td data-label='Remainin Time'>{4}</td>
        //                    <td data-label='Edit'><i class='far fa-edit pointer'></i></td>
        //                    <td data-label='Details'><i class='fas fa-info-circle pointer'></i></td>
        //                  </tr>
        //                ";
        //    if (number == null)
        //    {
        //        var stat = _context.Orders.ToList();
        //        foreach (var item in stat)
        //        {
        //            if (item.Status == 0|| item.Status == 1)
        //            {
        //                var hold = _context.Orders.Where(s => s.Status == 0|| s.Status == 1).ToList();
        //                StringBuilder builder = new StringBuilder();
                        
        //                hold.ForEach(m =>
        //                builder.AppendFormat(html, m.Id, m.Type, m.CustPhone, m.Status,
        //                m.OrderDate.Add(m.DiliveryTime.TimeOfDay - m.OrderDate.TimeOfDay).TimeOfDay - m.OrderDate.TimeOfDay
        //                , m.CustPhone)
        //               );
        //                return Json(builder.ToString());
        //            }
        //        }
        //    }
        //    else
        //    {
        //        var stat = _context.Orders.ToList();
        //        foreach (var item in stat)
        //        {
        //            if (item.Status == "HOLDING" || item.Status == "PREPARATION")
        //            {

        //                var hold = _context.Orders.
        //                    Where((s => s.Status == "PREPARATION" || s.Status == "HOLDING"));
        //                var holdphone = hold.Include(c => c.Customer).
        //                    Where(p => p.Customer.Phone1 == number || p.Customer.Phone2 == number).ToList();
        //                StringBuilder builder = new StringBuilder();
        //                holdphone.ForEach(m =>
        //                builder.AppendFormat(html, m.Id, m.Type, m.Customer.Name, m.Status,
        //                m.OrderDate.Add(m.DiliveryTime.TimeOfDay - m.OrderDate.TimeOfDay).TimeOfDay - m.OrderDate.TimeOfDay
        //                , m.Customer.Phone1)
        //               );
        //                return Json(builder.ToString());
        //            }
        //        }
        //    }
        //    return Json("error");
        //}
        [HttpGet]
        public async Task<IActionResult> EditHold()
        {
            var UserId = userManager.GetUserId(HttpContext.User);
            var user = await userManager.FindByIdAsync(UserId);
           
            var x = _context.Orders.Include(b=>b.Branch).Include(u=>u.ApplicationUser).
                Where(s => s.Status != 3 &&s.Branch.Name==user.Branch).OrderBy(o => o.OrderDate).ToList();
            return View(x);
        }
        [HttpGet]
        public async Task<IActionResult> MakeTime(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Order order = await _context.Orders.FindAsync(id);
            EditHoldViewModel model = new EditHoldViewModel
            {
                OrderDate = order.OrderDate,
                CookingTime = (order.CookingTime - order.OrderDate).Minutes,
                DiliveryTime = (order.DiliveryTime - order.CookingTime).Minutes,
                Type = order.Type,
                Status = 1
            };

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MakeTime(int id, EditHoldViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Order order = _context.Orders.Where(i => i.Id == id).FirstOrDefault();
                    if (model.Status != 3)
                    {
                        order.OrderDate = DateTime.Now;
                        order.CookingTime = DateTime.Now.AddMinutes(model.CookingTime);
                        var x = order.CookingTime.Minute - order.OrderDate.Minute;
                        order.DiliveryTime = DateTime.Now.AddMinutes((model.DiliveryTime + x));
                        order.Type = model.Type;
                        order.Status = 1;
                        _context.Update(order);
                        await _context.SaveChangesAsync();

                    }


                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(EditHold));

            }
            return View(model);
        }
        public async Task<JsonResult> getNotification()
        {
            var UserId = userManager.GetUserId(HttpContext.User);
            var user = await userManager.FindByIdAsync(UserId);
            var roleadmin = await userManager.IsInRoleAsync(user, "Admin");
            var rolecv = await userManager.IsInRoleAsync(user, "CustomerService");
            var rolebranch = await userManager.IsInRoleAsync(user, "Branch");
            string notifcation = @"<li class='m-2'>
                                <span>OrderDate:{0}</span>
                                <span>OrderId#{1}</span>
                                <hr />
                            </li>
                                   ";
            //notifcatio for admin
            if (roleadmin || rolecv)
            {
                var modeladmin = _context.Orders.Include(b => b.Branch).Include(u => u.ApplicationUser).
               Where(s => s.Status == 0).OrderByDescending(o => o.OrderDate).ToList();
                StringBuilder builder = new StringBuilder();
                modeladmin.ForEach(o =>
                {
                    builder.AppendFormat(notifcation, o.OrderDate, o.Id);
                });
                return Json(builder.ToString());
            }
            //notifaction for brranch
            if (rolebranch)
            {
                var model = _context.Orders.Include(b => b.Branch).Include(u => u.ApplicationUser).
              Where(s => s.Status == 0 && s.Branch.Name == user.Branch).OrderByDescending(o => o.OrderDate).ToList();
                StringBuilder builder = new StringBuilder();
                model.ForEach(o =>
                {
                    builder.AppendFormat(notifcation, o.OrderDate, o.Id);
                });
                return Json(builder.ToString());
            }
            return Json("Empty notifaction");

        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var x = _context.Orders.Where(s => s.Status == 1).ToList();
            if (x.Count != 0)
            {
                foreach (var item in x)
                {
                    if (item.DiliveryTime <= DateTime.Now)
                    {
                        item.Status = 3;
                        _context.Update(item);
                        _context.SaveChanges();
                    }
                }
            }
            return Json(x);
        }
        //SEARCH CUSTOMER EDIT HOLD
        //public JsonResult SearchCustomerNum(string number)
        //{
        //    string html = @"
        //                <tr>
        //                    <td data-label='Order Number'># {0}</td>
        //                    <td data-label='Order Type'>{1}</td>
        //                    <td data-label='Customer Name'>{2}</td>
        //                    <td data-label='Customer Phone'>{5}</td>
        //                    <td data-label='Status'>{3}</td>
        //                    <td data-label='Remainin Time'>{4}</td>
        //                    <td data-label='Edit'><i class='far fa-edit pointer'></i></td>
        //                    <td data-label='Details'><i class='fas fa-info-circle pointer'></i></td>
        //                  </tr>
        //                ";
        //    if (number == null)
        //    {
        //        var stat = _context.Orders.ToList();
        //        foreach (var item in stat)
        //        {
        //            if (item.Status == "HOLDING" || item.Status == "PREPARATION")
        //            {
        //                var hold = _context.Orders.Include(c => c.Customer).Where(s => s.Status == "PREPARATION" || s.Status == "HOLDING").ToList();
        //                StringBuilder builder = new StringBuilder();
        //                hold.ForEach(m =>
        //                builder.AppendFormat(html, m.Id, m.Type, m.Customer.Name, m.Status,
        //                m.OrderDate.Add(m.DiliveryTime.TimeOfDay - m.OrderDate.TimeOfDay).TimeOfDay - m.OrderDate.TimeOfDay
        //                , m.Customer.Phone1)
        //               );
        //                return Json(builder.ToString());
        //            }
        //        }
        //    }
        //    else
        //    {
        //        var stat = _context.Orders.ToList();
        //        foreach (var item in stat)
        //        {
        //            if (item.Status == "HOLDING" || item.Status == "PREPARATION")
        //            {

        //                var hold = _context.Orders.
        //                    Where((s => s.Status == "PREPARATION" || s.Status == "HOLDING"));
        //                var holdphone = hold.Include(c => c.Customer).
        //                    Where(p => p.Customer.Phone1 == number || p.Customer.Phone2 == number).ToList();
        //                StringBuilder builder = new StringBuilder();
        //                holdphone.ForEach(m =>
        //                builder.AppendFormat(html, m.Id, m.Type, m.Customer.Name, m.Status,
        //                m.OrderDate.Add(m.DiliveryTime.TimeOfDay - m.OrderDate.TimeOfDay).TimeOfDay - m.OrderDate.TimeOfDay
        //                , m.Customer.Phone1)
        //               );
        //                return Json(builder.ToString());
        //            }
        //        }
        //    }
        //    return Json("error");
        //}
        [HttpGet]
        public IActionResult EditOrder(int id)
        {

            var o = _context.Orders.Where(i => i.Id == id).FirstOrDefault();
            EditOrderVM viewModel = new EditOrderVM
            {
                Categories = _context.Categories.ToList(),
                Branches = _context.Branches.ToList(),
                Order = o,
                OrderDetails = _context.OrderDetails.Include(m => m.Meal).Where(oo => oo.Order == o).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult EditOrder(EditOrderVM orderVM)
        {
            Order order = _context.Orders.Find(orderVM.OrderId);
            var ODeltes = _context.OrderDetails.Where(o => o.Order == order).ToList();
            foreach (var item in ODeltes)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
            order.Status = 0;
            order.Type = orderVM.Type;
            order.OrderDate = DateTime.Now;
            Branch branch = _context.Branches.Where(i => i.Id == orderVM.BranchId).FirstOrDefault();
            order.Branch = branch;
            var address = _context.Addresses.Where(a => a.Id == orderVM.AddressId).FirstOrDefault();
            order.Address = address;
            order.Net = orderVM.Net;
            if (orderVM.Service < 1)
                order.Service = orderVM.Net - (orderVM.Service * 100);
            else
                order.Service = orderVM.Service;
            if (orderVM.Tax < 1)
                order.Tax = orderVM.Net - (orderVM.Tax * 100);
            else
                order.Tax = orderVM.Tax;
            if (orderVM.Discount < 1)
                order.Discount = orderVM.Net - (orderVM.Discount * 100);
            else
                order.Discount = orderVM.Discount;
            order.Total = orderVM.Total;
            order.CustPhone = orderVM.Phone;
            _context.Update(order);
            _context.SaveChanges();
            int oid = order.Id;
            foreach (var item in orderVM.OrderdetailVMs)
            {
                OrderDetail orderDetail = new OrderDetail();
                Meal meal = _context.Meals.Where(m => m.Id == item.MealId).FirstOrDefault();
                orderDetail.Meal = meal;
                orderDetail.Order = _context.Orders.Where(o => o.Id == oid).FirstOrDefault();
                orderDetail.Quantity = item.Quantity;
                orderDetail.ItemNote = item.ItemNote;
                orderDetail.UnitPrice = item.UnitPrice;
                orderDetail.Discount = item.Discount;
                _context.Add(orderDetail);
                _context.SaveChanges();

            }


            return View();
        }
        [HttpGet]
        public IActionResult CancelOrder(int? id)
        {
            Order o = _context.Orders.Where(i => i.Id == id).FirstOrDefault();
            return View(o);
        }
        [HttpPost]
        public IActionResult CancelOrder(int id)
        {
            Order o = _context.Orders.Find(id);
            var det = _context.OrderDetails.Where(or => or.Order == o).ToList();
            if (det.Count() != 0)
            {
                foreach (var item in det)
                {
                    var x = _context.OrderDetails.Find(item.Id);
                    _context.OrderDetails.Remove(x);
                    _context.SaveChanges();
                }
            }
            _context.Orders.Remove(o);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
