using DvdCenter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DvdCenter.ViewModel;
using System.Data.Entity.Validation;

namespace DvdCenter.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var Genre = _context.Genre.ToList();
            var ViewModel = new NewMovieViewModel
            {
                Genre = Genre

            };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    Genre = _context.Genre.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var customerInDb = _context.Movies.Single(c => c.Id == movie.Id);
                customerInDb.Name = movie.Name;
                customerInDb.GenreId = movie.GenreId;
                customerInDb.ReleaseDate = movie.ReleaseDate;
                customerInDb.NumberInStock = movie.NumberInStock;
                
               

            }
           

            _context.SaveChanges();

            return RedirectToAction("Index","Movie");
        }


        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");
          
            return View("ReadOnlyList");
          
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();


            return View(movie);
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewMovieViewModel(movie)  
            {
               
                Genre = _context.Genre.ToList()
            };
            return View("New", viewModel);
        }
    }
}