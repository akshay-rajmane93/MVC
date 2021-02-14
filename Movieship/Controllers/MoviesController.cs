using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movieship.Models;
using Movieship.ViewModel;

namespace Movieship.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageCustomer))
            {
                return View("index");
            }
            else
            {
                return View("TolistMovie");
            }
        }
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewmodel = new MovieModelForm()
            {
                Genres = genres
            };
                
            return View("new",viewmodel);
        }
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();

            var viewmodel = new MovieModelForm()
            {
                Genres = _context.Genres.ToList()
            };
            return View("new", viewmodel);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public ActionResult Save([Bind(Exclude ="Id")] Movies movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieModelForm(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("New", viewModel);
            }

            if (movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var moviedb = _context.Movies.Single(m => m.Id == movie.Id);
                moviedb.Name = movie.Name;
                moviedb.GenreId = movie.GenreId;
                moviedb.NumberInStock = movie.NumberInStock;
                moviedb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();

            

            return RedirectToAction("Index", "Movies");
        }
    }
}