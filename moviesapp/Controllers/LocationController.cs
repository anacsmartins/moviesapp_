using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moviesapp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace moviesapp.Controllers
{
    public class LocationsController : Controller
    {
        LocationDataAccessLayer objlocation = new LocationDataAccessLayer();

        [HttpGet]
        [Route("api/Locations/Index")]
        public IEnumerable<TblLocation> Index()
        {
            return objlocation.GetAllLocation();
        }

        [HttpPost]
        [Route("api/Locations/Create")]
        public int Create(TblLocation location)
        {
            return objlocation.AddLocation(location);
        }

        [HttpGet]
        [Route("api/Locations/Details/{id}")]
        public TblLocation Details(int id)
        {
            return objlocation.GetLocationData(id);
        }

        [HttpPut]
        [Route("api/Locations/Edit")]
        public int Edit(TblLocation location)
        {
            return objlocation.UpdateLocation(location);
        }

        [HttpDelete]
        [Route("api/Locations/Delete/{id}")]
        public int Delete(int id)
        {
            return objlocation.DeleteLocation(id);
        }

        [HttpGet]
        [Route("api/Locations/GetMovieList")]
        public IEnumerable<TblMovies> Details()
        {
            return objlocation.GetMovies();
        }

        [HttpGet]
        [Route("api/Locations/GetCustomerList")]
        public IEnumerable<TblCustomers> Customers()
        {
            return objlocation.GetCustomers();
        }
    }
}
