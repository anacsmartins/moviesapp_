using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moviesapp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace moviesapp.Controllers
{
    public class MoviesController : Controller
    {
        MoviesDataAccessLayer objmovie = new MoviesDataAccessLayer();

        [HttpGet]
        [Route("api/Movies/Index")]
        public IEnumerable<TblMovies> Index()
        {
            return objmovie.GetAllMovies();
        }

        [HttpPost]
        [Route("api/Movies/Create")]
        public int Create(TblMovies movie)
        {
            return objmovie.AddMovies(movie);
        }

        [HttpGet]
        [Route("api/Movies/Details/{id}")]
        public TblMovies Details(int id)
        {
            return objmovie.GetMoviesData(id);
        }

        [HttpPut]
        [Route("api/Movies/Edit")]
        public int Edit(TblMovies movie)
        {
            return objmovie.UpdateMovies(movie);
        }

        [HttpDelete]
        [Route("api/Movies/Delete/{id}")]
        public int Delete(int id)
        {
            return objmovie.DeleteMovies(id);
        }

        [HttpGet]
        [Route("api/Movies/GetGenreList")]
        public IEnumerable<TblGenres> Details()
        {
            return objmovie.GetGenres();
        }
    }
}
