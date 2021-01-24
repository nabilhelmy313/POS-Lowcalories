using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<NotificationHub> hub;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(ApplicationDbContext context,
            IHubContext<NotificationHub> hub, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.hub = hub;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            OrderViewModel viewModel = new OrderViewModel
            {
                Categories = _context.Categories.ToList(),
                Branches = _context.Branches.ToList(),
                UserId = userManager.GetUserId(HttpContext.User)
            };
            return View(viewModel);
        }
        //GET MEALS
        [HttpGet]
        public JsonResult GetMeals(int id)
        {
            string html = @" <div class='col-lg-4 col-sm-6 my-3'>
                                    <div class='meal-img m-auto' style='width: fit-content;'>
                                        <img src='/images/{0}' alt='{1}' class='img-fluid radius'>
                                        <div class='overlay text-center bg-overlay text-white radius d-flex justify-content-center align-items-center'>
                                            <div>
                                                <h4>{1}</h4>
                                                <b class='d-block'><small><span>{2}</span> AED</small></b>
                                                <button id='{3}' class='btn bg-gradient radius text-white buyNow'>BUY NOW</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>";
            OrderViewModel model = new OrderViewModel
            {
                Meals = _context.Meals.Where(c => c.Category.Id == id && c.IsChild == false).ToList(),
            };
            var builder = new StringBuilder();
            model.Meals.ForEach(m =>
            builder.AppendFormat(html, m.Photo, m.Name, m.Price, m.Id));
            return Json(builder.ToString());
        }
        //GET MEALS DETAILS 
        [HttpGet]
        public JsonResult GetDetails(int id)
        {
            var getsize = _context.Meals.Where(p => p.ParentId == id).ToList();
            var getmeal = _context.Meals.Where(i => i.Id == id).FirstOrDefault();
            if (getsize.Count() == 0)
            {
                string html1 = @"<h6 class='text-center text-white my-3 mealname' data-topass='{0}' id='{1}'>
                               {0}
                            </h6>";
                string html = @"
                            <div id='{2}' class='bg-white overflow-auto radius py-3 px-2 my-3 meal-details'>
                                <small class='text-gradient float-left'>
                                    <b class='qan' id='{2}q'>{0}</b>
                                </small>
                                <small class='text-gradient float-right'> AED </small>
                                <small class='text-gradient float-right'>
                                    <b id='{2}p' class='price'>{1}</b>
                                </small>
                            </div>";
                OrderViewModel model = new OrderViewModel
                {
                    Meals = _context.Meals.Where(m => m.Id == id).ToList(),
                };
                OrderViewModel model1 = new OrderViewModel
                {
                    Meals = _context.Meals.Where(m => m.Id == id).ToList(),
                };
                StringBuilder builder1 = new StringBuilder();
                model1.Meals.ForEach(m =>
                builder1.AppendFormat(html1, getmeal.Name, getmeal.Id)
                );
                StringBuilder builder = new StringBuilder();
                model.Meals.ForEach(m =>
                builder.AppendFormat(html, m.Quantity, m.Price, m.Id)
                );
                return Json(builder1.ToString() + builder.ToString());
            }
            else
            {
                string html1 = @"<h6 class='text-center text-white my-3 mealname' data-topass='{0}' id='{1}'>
                               {0}
                            </h6>";
                string html = @"
                            <div id='{2}' class='bg-white overflow-auto radius py-3 px-2 my-3 meal-details'>
                                <small class='text-gradient float-left'>
                                    <b class='qan' id='{2}q'>{0}</b>
                                </small>
                                <small class='text-gradient float-right'> AED </small>
                                <small class='text-gradient float-right'>
                                    <b id='{2}p' class='price'>{1}</b>
                                </small>
                            </div>";


                OrderViewModel model = new OrderViewModel
                {
                    Meals = _context.Meals.Where(m => m.ParentId == id).ToList(),
                };
                OrderViewModel model1 = new OrderViewModel
                {
                    Meals = _context.Meals.Where(m => m.Id == id).ToList(),
                };
                StringBuilder builder1 = new StringBuilder();
                model1.Meals.ForEach(m =>
                builder1.AppendFormat(html1, getmeal.Name, getmeal.Id)
                );
                StringBuilder builder = new StringBuilder();
                model.Meals.ForEach(m =>
                builder.AppendFormat(html, m.Quantity, m.Price, m.Id)
                );
                return Json(builder1.ToString() + builder.ToString());
            }
        }
        //SERACH MEAL 
        public JsonResult SearchMeal(string meal)
        {
            string html = @" <div class='col-lg-4 col-sm-6 my-3'>
                                    <div class='meal-img m-auto' style='width: fit-content;'>
                                        <img src='/images/{0}' alt='{1}' class='img-fluid radius'>
                                        <div class='overlay text-center bg-overlay text-white radius d-flex justify-content-center align-items-center'>
                                            <div>
                                                <h4>{1}</h4>
                                                <b class='d-block'><small><span>{2}</span> AED</small></b>
                                                <button id='{3}' class='btn bg-gradient radius text-white buyNow'>BUY NOW</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>";

            if (meal == null)
            {
                OrderViewModel model = new OrderViewModel
                {
                    Meals = _context.Meals.Where(c => c.IsChild == false).ToList(),
                };
                var builder = new StringBuilder();
                model.Meals.ForEach(m =>
                builder.AppendFormat(html, m.Photo, m.Name, m.Price, m.Id));
                return Json(builder.ToString());
            }
            else
            {
                OrderViewModel model = new OrderViewModel
                {
                    Meals = _context.Meals.Where(m => m.Name.Contains(meal) && m.IsChild == false).ToList(),
                };
                var builder = new StringBuilder();
                model.Meals.ForEach(m =>
                builder.AppendFormat(html, m.Photo, m.Name, m.Price, m.Id));
                return Json(builder.ToString());
            }
        }
        //GET ORDER not use
        public JsonResult GetOrder(int id)
        {
            string html = @" <div class='order-number overflow-auto my-4'>
                        <div class='order-name float-left d-flex justify-content-center align-items-center'>
                            <i class='far fa-trash-alt text-gradient pointer' onclick='deleteOrder(event)'></i>
                          <div class='ml-2'>
                          <h6 class='m-0' style='font-size: 14px;'>{0}</h6>
                          <small class='text-muted qaunt'>{2}</small>
                          <small class='text-muted'>{1}</small>
                          </div>
                        </div>
                        <div class='counter float-right d-flex justify-content-center align-items-center'>
                          <div class='num'>1</div>
                          <div class='counterBtn'>
                              <button class='btn bg-gradient text-white d-block py-0 px-2 counterUp' onclick='getCounterUp(event)'>
                                  <i class='fas fa-angle-up'></i>
                              </button>
                              <button class='btn bg-gradient text-white iteitem-block py-0 px-2 counterDown' onclick='getCounterDown(event)'>
                                  <i class='fas fa-angle-down'></i>
                              </button>
                          </div>
                        </div>
                        <div class='clearfix'></div>
                        <small class='float-right mr-1 price'> {1}</small>
                     </div>
                                ";
            var ischild = _context.Meals.Where(h => h.Id == id).FirstOrDefault().IsChild;
            if (ischild == true)
            {
                var meal = _context.Meals.Where(i => i.Id == id).FirstOrDefault();
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat(html, meal.Name, meal.Price, meal.Quantity);
                return Json(builder.ToString());

            }
            return Json("error");
        }
        //Get address Form
        public JsonResult AddressForm(string CustPhone)
        {
            if (CustPhone != null)
            {
                var customer = _context.Customers.Where(c => c.Phone1 == CustPhone || c.Phone2 == CustPhone).FirstOrDefault();
                if (customer != null)
                {


                    var zoons = _context.Zoons.ToList();
                    List<string> options = new List<string>();
                    foreach (var item in zoons)
                    {
                        options.Add("<option value='" + item.Id + "'>" + item.Name + "</option>");
                    }
                    string html = @"
                        <section id='createCustomer'>
                           <div class='container py-3'>
                          <form asp-action='Create' enctype='multipart/form-data' class='row mx-2'>


                            <div class='col-12'>
                            <label class='text-gradient font-weight-bold'>User Name</label>
                            <input  type='text' class='username form-control' value='" + customer.Name + @"' disabled>
                            <span class='text-danger mt-1'></span>
                            </div>

                            <div class='col-6'>
                                <label class='text-gradient font-weight-bold'>PHONE</label>
                                <input type='text'  class='phone1 form-control' value='" + customer.Phone1 + @"' disabled>
                                <span  class=' text-danger mt-1'></span> 

                            </div>

                            <div class='col-6'>
                                <label class='text-gradient font-weight-bold'> ANOTHR PHONE</label>
                                <input type='text' class='phone2 form-control' value='" + customer.Phone2 + @"' disabled>
                            </div>
                            <div class='col-6'>
                                <label class='text-gradient font-weight-bold'>STREET</label>
                                <input type='text' class='street form-control'>
                                <span class='text-danger mt-1'></span>

                            </div>

                            <div class='col-6'>
                                <label class='text-gradient font-weight-bold'>FLOOR</label>
                                <input type='text' class='floor form-control'>
                            </div>
                            <div class='col-6'>
                                <label class='text-gradient font-weight-bold'>FLAT</label>
                                <input type='text' class='flat form-control'>
                            </div>
                            <div class='col-6'>
                                <label class='text-gradient font-weight-bold'>LANDMARK</label>
                                <input type='text' class='landmark form-control'>
                            </div>
                            <div class='col-6'>
                            <label class='text-gradient font-weight-bold'>AREA</label>
                            <select  class='zoon form-control  text-gradient2'>
                              <option value='0'>No Area</option>
                            " + string.Join(" ", options) +
                                    @"</select>
                            </div >
                        <button type='button' class='btn btn-block bg-gradient text-white mt-3 createcustomer'>Create</button>
                        </form>
                      </div>
                    </section>
                     ";
                    StringBuilder builder1 = new StringBuilder();
                    builder1.AppendFormat(html);
                    return Json(builder1.ToString());
                }
                else
                {
                    return Json("Please Add The New Customer");

                }
            }
            return Json("Please Put Customer Number");
        }
        //GET CUSTOMER
        [HttpGet]
        public JsonResult GetCustomer(string? phone1, string? phone2)
        {
            var zoons = _context.Zoons.ToList();
            List<string> options = new List<string>();
            foreach (var item in zoons)
            {
                options.Add("<option value='" + item.Id + "'>" + item.Name + "</option>");
            }
            string html = @"
            <section id='createCustomer'>
               <div class='container py-3'>
              <form asp-action='Create' enctype='multipart/form-data' class='row mx-2'>


                <div class='col-12'>
                <label class='text-gradient font-weight-bold'>User Name</label>
                <input  type='text' class='username form-control'>
                <span class='text-danger mt-1'></span>
                </div>

                <div class='col-6'>
                    <label class='text-gradient font-weight-bold'>PHONE</label>
                    <input type='text' class='phone1 form-control'>
                    <span  class=' text-danger mt-1'></span> 

                </div>

                <div class='col-6'>
                    <label class='text-gradient font-weight-bold'> ANOTHR PHONE</label>
                    <input type='text' class='phone2 form-control'>
                </div>
                <div class='col-6'>
                    <label class='text-gradient font-weight-bold'>STREET</label>
                    <input type='text' class='street form-control'>
                    <span class='text-danger mt-1'></span>

                </div>

                <div class='col-6'>
                    <label class='text-gradient font-weight-bold'>FLOOR</label>
                    <input type='text' class='floor form-control'>
                </div>
                <div class='col-6'>
                    <label class='text-gradient font-weight-bold'>FLAT</label>
                    <input type='text' class='flat form-control'>
                </div>
                <div class='col-6'>
                    <label class='text-gradient font-weight-bold'>LANDMARK</label>
                    <input type='text' class='landmark form-control'>
                </div>
                <div class='col-6'>
                <label class='text-gradient font-weight-bold'>AREA</label>
                <select  class='zoon form-control  text-gradient2'>
                  <option value='0'>No Area</option>
                " + string.Join(" ", options) +
                @"</select>
                </div >
            <button type='button' class='btn btn-block bg-gradient text-white mt-3 createcustomer'>Create</button>
            </form>
          </div>
        </section>
                   
";
            StringBuilder builder1 = new StringBuilder();
            builder1.AppendFormat(html);
            if (phone1 == null && phone2 == null)
            {
                return Json(builder1.ToString());
            }
            var cust = _context.Customers.Where(p => p.Phone1 == phone1.ToString() || p.Phone2 == phone2.ToString()).FirstOrDefault();
            var address = _context.Addresses.Include(z => z.Zoon).
                    Where(c => c.Customer == cust).ToList();

            if (cust != null)
            {
                OrderViewModel model = new OrderViewModel
                {
                    Customer = cust,
                    Addresses = address,
                    Orders = _context.Orders.Where(c => c.CustPhone == phone1 || c.CustPhone == phone2).OrderByDescending(o => o.OrderDate).ToList(),
                };
                string data = @"
                                    <h6 class='text-muted'><i class='fas fa-user-tag text-gradient pr-2' style='padding-left: 2px;'></i> Name : <span>{0}</span></h6>
                                    <h6 class='text-muted'><i class='fas fa-mobile-alt text-gradient pr-3 pl-1'></i> Phone : <span>{1}</span></h6>
                                    <h6 class='text-muted'><i class='fas fa-mobile-alt text-gradient pr-3 pl-1'></i> Phone 2 : <span>{2}</span></h6>        
                               <hr> ";
                string add = "<h6 class='text-muted'><i class='fas fa-home text-gradient pr-3 pl-1'></i>  AREA : <span>{0}</span> STREET : <span>{1}</span> FLOOR : <span>{2}</span> FLAT :<span>{3}</span></h6>";
                string oo = "<hr/><h6 class='text-muted'><i class='fas fa-pizza-slice text-gradient pr-3 pl-1'></i> ORDER DATE :{0} </h6>";
                string oo1 = "<option value='{0}'>{1}</option>";
                StringBuilder builder = new StringBuilder();
                StringBuilder builderlist = new StringBuilder();
                StringBuilder orderist = new StringBuilder();
                StringBuilder adddrop = new StringBuilder();
                builder.AppendFormat(data, model.Customer.Name, model.Customer.Phone1, model.Customer.Phone2);
                model.Addresses.ForEach(a =>
                builderlist.AppendFormat(add, a.Zoon.Name, a.Street, a.Floor, a.Flat)
                );
                model.Orders.ForEach(o =>
                orderist.AppendFormat(oo, o.OrderDate));
                model.Addresses.ForEach(o =>
                    adddrop.AppendFormat(oo1, o.Id, o.Street + " " + o.Floor + " " + o.Flat));
                return Json(builder.ToString() + builderlist.ToString() + orderist.ToString());
            }
            return Json(builder1.ToString());
        }
        [HttpPost]
        public JsonResult AddCustomer(AddCustomerVM vM)
        {
            var custexist = _context.Customers.Where(c => c.Phone1 == vM.Phone1 || c.Phone2 == vM.Phone2).FirstOrDefault();
            if (custexist == null)
            {

                Customer customer = new Customer();
                customer.Name = vM.Name;
                customer.Phone1 = vM.Phone1;
                customer.Phone2 = vM.Phone2;
                _context.Add(customer);
                _context.SaveChanges();

                var zoon = _context.Zoons.Find(vM.ZoonId);
                if (zoon != null)
                {
                    Address address = new Address();
                    address.Flat = vM.Flat;
                    address.Floor = vM.Floor;
                    address.Landmark = vM.Landmark;
                    address.Street = vM.Street;
                    address.Zoon = zoon;
                    address.Customer = customer;
                    _context.Add(address);
                    _context.SaveChanges();
                }
            }
            else
            {
                var zoon = _context.Zoons.Find(vM.ZoonId);
                if (zoon != null)
                {
                    Address address = new Address();
                    address.Flat = vM.Flat;
                    address.Floor = vM.Floor;
                    address.Landmark = vM.Landmark;
                    address.Street = vM.Street;
                    address.Zoon = zoon;
                    address.Customer = custexist;
                    _context.Add(address);
                    _context.SaveChanges();
                }
            }
            return Json("Done");

        }
        public JsonResult GetAddress(string? phone1, string? phone2, bool isDelivery)
        {
            if (phone1 != null)
            {
                var cust = _context.Customers.Where(p => p.Phone1 == phone1.ToString() || p.Phone2 == phone2.ToString()).FirstOrDefault();
                var address = _context.Addresses.Include(z => z.Zoon).
                Where(c => c.Customer == cust).ToList();
                if (cust != null)
                {


                    OrderViewModel model = new OrderViewModel
                    {
                        Addresses = address,
                        Customer = _context.Customers.Where(c => c.Phone1 == phone1 || c.Phone2 == phone2).FirstOrDefault(),
                        Orders = _context.Orders.Where(c => c.CustPhone == phone1 || c.CustPhone == phone2).OrderByDescending(o => o.OrderDate).ToList(),
                    };
                    StringBuilder adddrop = new StringBuilder();
                    if (isDelivery == true)
                    {
                        string oo1 = "<option value='{0}'>{1}</option>"; ;
                        model.Addresses.ForEach(o =>
                               adddrop.AppendFormat(oo1, o.Id, o.Street + " - " + o.Floor + " - " + o.Flat));

                        return Json(adddrop.ToString());

                    }
                    else
                    {
                        string oo1 = "{0}"; ;
                        adddrop.AppendFormat(oo1, model.Customer.Name);
                        return Json(adddrop.ToString());
                    }
                }
            }

            return Json("Please Search customer");
        }
        //branch address
        public JsonResult BranchAddress(int branchid)
        {

            var x = _context.Branches.Find(branchid).Address;
            if (x == null)
            {
                return Json("Empty Address");
            }
            else
            {
                return Json(x);

            }
        }
        //SAVE ORDER
        [HttpPost]
        public async Task<IActionResult> SaveOrder(orderVM orderVM)
        {
            var user = await userManager.FindByIdAsync(orderVM.UserId);
            Order order = new Order();
            order.Status = 0;
            order.Type = orderVM.Type;
            order.OrderDate = DateTime.Now;
            Branch branch = new Branch();
            if (orderVM.BranchId == 0)
            {
                branch = _context.Branches.Where(b => b.Name == user.Branch).FirstOrDefault();
                order.Branch = branch;

            }
            else
            {
                branch = _context.Branches.Where(i => i.Id == orderVM.BranchId).FirstOrDefault();
                order.Branch = branch;
            }
            var address = _context.Addresses.Where(a => a.Id == orderVM.AddressId).FirstOrDefault();
            order.Address = address;
            order.Net = orderVM.Net;
            if (orderVM.Service < 1)
                order.Service = (orderVM.Service * orderVM.Net);
            else
                order.Service = orderVM.Service;
            if (orderVM.Tax < 1)
                order.Tax = (orderVM.Tax * orderVM.Net);
            else
                order.Tax = orderVM.Tax;
            if (orderVM.Discount < 1)
                order.Discount = (orderVM.Discount * orderVM.Net);
            else
                order.Discount = orderVM.Discount;
            order.Total = orderVM.Total;
            order.CustPhone = orderVM.Phone;
            order.ApplicationUser = user;
            _context.Add(order);
            await _context.SaveChangesAsync();
            int oid = order.Id;

            foreach (var item in orderVM.OrderdetailVMs)
            {
                OrderDetail orderDetail = new OrderDetail();
                Meal meal = _context.Meals.Where(m => m.Id == item.MealId).FirstOrDefault();
                orderDetail.Meal = meal;
                if (meal.IsChild == false)
                    orderDetail.Name = meal.Name;
                else
                    orderDetail.Name = _context.Meals.Where(m => m.Id == meal.ParentId).FirstOrDefault().Name;

                orderDetail.Order = _context.Orders.Where(o => o.Id == oid).FirstOrDefault();
                orderDetail.Quantity = item.Quantity;
                orderDetail.ItemNote = item.ItemName;
                orderDetail.UnitPrice = item.UnitPrice;
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
            }
            await SendMessage(oid, order.OrderDate, branch.Name);
            OrderViewModel viewModel = new OrderViewModel
            {
                Categories = _context.Categories.ToList(),
                Branches = _context.Branches.ToList(),
                UserId = userManager.GetUserId(HttpContext.User)
            };
            return View(viewModel);


        }
        public async Task SendMessage(int id, DateTime date, string branch)
        {

            var users = userManager.Users.Where(b => b.Branch == branch).ToList();
            List<string> userids = new List<string>();
            foreach (var item in users)
            {
                userids.Add(item.Id);
            }
            await hub.Clients.Users(userids).SendAsync("NewOrder", id, date.ToString("hh:mm tt"));
        }
    }
}
