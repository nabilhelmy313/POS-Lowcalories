using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using POS.Data;
using POS.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHubContext<MessageHub> hub;

        public MessageController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IHubContext<MessageHub> hub)
        {
            _context = context;
            this.userManager = userManager;
            this.hub = hub;
        }
        public async Task<IActionResult> Index(int id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("CustomerService"))
            {

                ViewBag.branches = _context.Branches.ToList();
                Branch bran1 = _context.Branches.FirstOrDefault();
                ViewBag.firstbranch = bran1.Name;
                ViewBag.branId = bran1.Id;
               
                if (id == 0)
                {
                    var messages = _context.Messages
                  .Where(c => c.BId == bran1.Id ).
                  OrderBy(o => o.MessageDate).ToList();
                    return View(messages);
                }
                else
                {
                    ViewBag.firstbranch = _context.Branches.Find(id).Name;
                    ViewBag.branId = _context.Branches.Find(id).Id;
                    var messages = _context.Messages.
                        Where(c => c.BId == id ).
                        OrderBy(o => o.MessageDate).ToList();
                    return View(messages);
                }
            }
            else
            {
                var user1 = await userManager.GetUserAsync(HttpContext.User);
                var bran1 = _context.Branches.
                Where(c => c.Name == user1.Branch)
                .FirstOrDefault();
                ViewBag.firstbranch = bran1.Name;
                ViewBag.branId = bran1.Id;
                if (id == 0)
                {
                    var messages = _context.Messages
                  .Where(c => c.BId == bran1.Id ).
                  OrderBy(o => o.MessageDate).ToList();
                    return View(messages);
                }
                else
                {
                    ViewBag.firstbranch = _context.Branches.Find(id).Name;
                    ViewBag.branId = _context.Branches.Find(id).Id;
                    var messages = _context.Messages.
                        Where(c => c.BId == id).
                        OrderBy(o => o.MessageDate).ToList();
                    return View(messages);
                }
            }
        }
        [HttpPost]
        public async Task<JsonResult> SaveMessage(string mm, int bid)
        {
            Message message = new Message();
            message.TextMessage = mm;
            message.MessageDate = DateTime.Now;
            message.ApplicationUser = await userManager.GetUserAsync(HttpContext.User);
            await Send(mm, DateTime.Now.ToString("yyyy:MM:dd HH:mm tt"), bid);
            message.Branch = _context.Branches.
                Where(b => b.Name == message.ApplicationUser.Branch)
                .FirstOrDefault();
            message.BId = bid;
            _context.Add(message);
            await _context.SaveChangesAsync();
            return Json("wow");
        }
        public async Task Send(string messge, string date, int branchId)
        {
            if (User.IsInRole("Admin")||User.IsInRole("CustomerService"))
            {
                Branch bran = _context.Branches.Find(branchId);
                var users = userManager.Users.Where(b => b.Branch == bran.Name).ToList();
                List<string> userids = new List<string>();
                foreach (var item in users)
                {
                    userids.Add(item.Id);
                }
                await hub.Clients.Users(userids).SendAsync("message", messge, date,branchId);
            }
            else
            {
                var admins = await userManager.GetUsersInRoleAsync("Admin");
                var cust = await userManager.GetUsersInRoleAsync("CustomerService");
                var list = admins.ToList();
                var list2 = cust.ToList();
                list.AddRange(list2);

                List<string> userids = new List<string>();
                foreach (var item in list)
                {
                    userids.Add(item.Id);
                }
                await hub.Clients.Users(userids).SendAsync("message", messge, date,branchId);
            }

        }
    }
}
