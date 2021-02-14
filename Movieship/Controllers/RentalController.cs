using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movieship.Models;

namespace Movieship.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public ActionResult Index()
        {
            return View();
        }
    }
}