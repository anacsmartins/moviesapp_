using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moviesapp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace moviesapp.Controllers
{
    public class LoginController : Controller
    {
        LoginDataAccessLayer objlogin = new LoginDataAccessLayer();

        [HttpGet]
        [Route("api/Login/Index")]
        public IEnumerable<TblLogin> Index()
        {
            return objlogin.GetAllLogin();
        }

        [HttpPost]
        [Route("api/Login/Create")]
        public int Create(TblLogin login)
        {
            return objlogin.AddLogin(login);
        }

        [HttpGet]
        [Route("api/Login/Details/{id}")]
        public TblLogin Details(int id)
        {
            return objlogin.GetLoginData(id);
        }

        [HttpPut]
        [Route("api/Login/Edit")]
        public int Edit(TblLogin login)
        {
            return objlogin.UpdateLogin(login);
        }

        [HttpDelete]
        [Route("api/Login/Delete/{id}")]
        public int Delete(int id)
        {
            return objlogin.DeleteLogin(id);
        }

    }
}
