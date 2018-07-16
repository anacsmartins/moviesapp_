using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesapp.Models
{
    public class LocationDataAccessLayer
    {
        dbmoviesContext db = new dbmoviesContext();

        public IEnumerable<TblLocation> GetAllLocation()
        {
            try
            {
                return db.TblLocation.ToList();
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Add new location record   
        public int AddLocation(TblLocation location)
        {
            try
            {
                db.TblLocation.Add(location);
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

        //To Update the records of a particluar location  
        public int UpdateLocation(TblLocation location)
        {
            try
            {
                db.Entry(location).State = EntityState.Modified;
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

        //Get the details of a particular location  
        public TblLocation GetLocationData(int id)
        {
            try
            {
                TblLocation location = db.TblLocation.Find(id);
                return location;
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Delete the record of a particular location  
        public int DeleteLocation(int id)
        {
            try
            {
                TblLocation emp = db.TblLocation.Find(id);
                db.TblLocation.Remove(emp);
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

        //To Get the list of Movies  
        public List<TblMovies> GetMovies()
        {
            List<TblMovies> lstmovie = new List<TblMovies>();
            lstmovie = (from movieList in db.TblMovies select movieList).ToList();

            return lstmovie;
        }

        //To Get the list of Customers  
        public List<TblCustomers> GetCustomers()
        {
            List<TblCustomers> lstcustomer = new List<TblCustomers>();
            lstcustomer = (from customerList in db.TblCustomers select customerList).ToList();

            return lstcustomer;
        }

    }
}
