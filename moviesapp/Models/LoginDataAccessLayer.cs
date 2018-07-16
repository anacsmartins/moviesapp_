using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesapp.Models
{
    public class LoginDataAccessLayer
    {
        dbmoviesContext db = new dbmoviesContext();

        public IEnumerable<TblLogin> GetAllLogin()
        {
            try
            {
                return db.TblLogin.ToList();
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Add new login record   
        public int AddLogin(TblLogin login)
        {
            try
            {
                db.TblLogin.Add(login);
                db.SaveChanges();
                return 1;
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Update the records of a particluar login  
        public int UpdateLogin(TblLogin login)
        {
            try
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //Get the details of a particular login  
        public TblLogin GetLoginData(int id)
        {
            try
            {
                TblLogin login = db.TblLogin.Find(id);
                return login;
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Delete the record of a particular login  
        public int DeleteLogin(int id)
        {
            try
            {
                TblLogin emp = db.TblLogin.Find(id);
                db.TblLogin.Remove(emp);
                db.SaveChanges();
                return 1;
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

    }
}
