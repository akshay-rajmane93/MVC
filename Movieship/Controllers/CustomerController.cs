using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movieship.Models;
using System.Data.Entity;
using Movieship.ViewModel;

namespace Movieship.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
      
        public ActionResult Index()

        {

            if(User.IsInRole(RoleName.CanManageCustomer))
            return View("Index");

            return View("ReadOnlyList");
        }
        
        public ActionResult Details(int Id)
        {
            var customer = _context.Customer.Include(c=>c.MemberShip).SingleOrDefault(c => c.Id == Id);
            return View(customer);
        }
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public ActionResult New()

        {
            var membership = _context.MemberShip.ToList();
            var viewmodel = new ViewModel1
            {
                MemberShip = membership
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public ActionResult Create(Customer customer)

        {
           //if(!ModelState.IsValid) // for validation
           // {
           //     var view = new ViewModel1
           //     {
           //         Customer = customer,
           //         MemberShip = _context.MemberShip.ToList()

           //     };
           // return View("New", view);
           //}
           // above code is dont use for validation

            if (customer.Id == 0)
            {
                _context.Customer.Add(customer);
                
            }
            else
            {
                var custInDb = _context.Customer.Single(c => c.Id == customer.Id);
                custInDb.Name = customer.Name;
                custInDb.Birthdate = customer.Birthdate;
                custInDb.IsSuscribed = customer.IsSuscribed;
                custInDb.MembId=customer.MembId;
               
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public ActionResult Edit(int Id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == Id);
            var viewmodel = new ViewModel1
            {
                Customer = customer,
                MemberShip = _context.MemberShip.ToList()

            };
            return View("New", viewmodel);
        }
    }
}
