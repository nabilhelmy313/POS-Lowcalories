using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.ViewModel;

namespace POS.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Addresses.Include(z => z.Zoon).ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            AddAddressViewModel model = new AddAddressViewModel
            {
                Zoons = _context.Zoons.ToList(),

            };
            return View(model);
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddAddressViewModel model)
        {
            if (model.CustPhone != null)
            {
                var cust = _context.Customers.Where(c => c.Phone1 == model.CustPhone || c.Phone2 == model.CustPhone).FirstOrDefault();
                Address address = new Address();
                address.Street = model.Street;
                address.Flat = model.Flat;
                address.Floor = model.Floor;
                address.Landmark = model.Landmark;
                address.Zoon = _context.Zoons.Where(id => id.Id == model.Address.Zoon.Id).FirstOrDefault();
                address.Customer = cust;
                if (ModelState.IsValid)
                {
                    _context.Add(address);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return NotFound();
        }
        public JsonResult GetCustomer(string? phone1, string? phone2)
        {
            string html = "<div class='alert alert-warning d-flex justify-content-center' role='alert'><span class='mr-5'>CUSTOMER NOT FOUND</span> <a class='btn btn-outline-warning ml-5' href='/Customers/Create'><i class='fas fa-user-plus'></i>ADD NEW CUSTOMER</a></ div > ";
            StringBuilder error = new StringBuilder();
            error.AppendFormat(html);
            if (phone1 == null && phone2 == null)
            {
                return Json(error.ToString());
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
                };
                string data = @"
                                    <h6 class='text-muted'><i class='fas fa-user-tag text-gradient pr-2' style='padding-left: 2px;'></i> Name : <span>{0}</span></h6>
                                    <h6 class='text-muted'><i class='fas fa-mobile-alt text-gradient pr-3 pl-1'></i> Phone : <span>{1}</span></h6>
                                    <h6 class='text-muted'><i class='fas fa-mobile-alt text-gradient pr-3 pl-1'></i> Phone 2 : <span>{2}</span></h6>        
                               <hr> ";
                string add = "<h6 class='text-muted'><i class='fas fa-home text-gradient pr-3 pl-1'></i>  AREA : <span>{0}</span> STREET : <span>{1}</span> FLOOR : <span>{2}</span> FLAT :<span>{3}</span></h6>";

                StringBuilder builder = new StringBuilder();
                StringBuilder builderlist = new StringBuilder();

                builder.AppendFormat(data, model.Customer.Name, model.Customer.Phone1, model.Customer.Phone2);
                model.Addresses.ForEach(a =>
                builderlist.AppendFormat(add, a.Zoon.Name, a.Street, a.Floor, a.Flat)
                );

                return Json(builder.ToString() + builderlist.ToString());
            }
            return Json(error.ToString());
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Floor,Street,Flat,Landmark")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
