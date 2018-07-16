using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moviesapp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace moviesapp.Controllers
{
    public class GenresController : Controller
    {
        GenreDataAccessLayer objgenre = new GenreDataAccessLayer();

        [HttpGet]
        [Route("api/Genres/Index")]
        public IEnumerable<TblGenres> Index()
        {
            return objgenre.GetAllGenres();
        }

        [HttpPost]
        [Route("api/Genres/Create")]
        public int Create(TblGenres genre)
        {
            return objgenre.AddGenres(genre);
        }

        [HttpGet]
        [Route("api/Genres/Details/{id}")]
        public TblGenres Details(int id)
        {
            return objgenre.GetGenresData(id);
        }

        [HttpPut]
        [Route("api/Genres/Edit")]
        public int Edit(TblGenres genre)
        {
            return objgenre.UpdateGenres(genre);
        }

        [HttpDelete]
        [Route("api/Genres/Delete/{id}")]
        public int Delete(int id)
        {
            return objgenre.DeleteGenres(id);
        }

        [HttpGet]
        [Route("api/Genres/GetGenreList")]
        public IEnumerable<TblGenres> Details()
        {
            return objgenre.GetGenres();
        }
    }
}
