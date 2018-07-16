using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesapp.Models
{
    public class MoviesDataAccessLayer
    {
        dbmoviesContext db = new dbmoviesContext();

        public IEnumerable<TblMovies> GetAllMovies()
        {
            try
            {
                return db.TblMovies.ToList();
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Add new movie record   
        public int AddMovies(TblMovies movie)
        {
            try
            {
                Console.Write("MOVIE ADD");
                Console.Write(movie);
                db.TblMovies.Add(movie);
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

        //To Update the records of a particluar movie  
        public int UpdateMovies(TblMovies movie)
        {
            try
            {
                Console.Write("MOVIE EDIT");
                Console.Write(movie);
                db.Entry(movie).State = EntityState.Modified;
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

        //Get the details of a particular movie  
        public TblMovies GetMoviesData(int id)
        {
            try
            {
                TblMovies movie = db.TblMovies.Find(id);
                return movie;
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Delete the record of a particular movie  
        public int DeleteMovies(int id)
        {
            try
            {
                TblMovies emp = db.TblMovies.Find(id);
                db.TblMovies.Remove(emp);
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

        //To Get the list of Genres  
        public List<TblGenres> GetGenres()
        {
            List<TblGenres> lstgenre = new List<TblGenres>();
            lstgenre = (from genreList in db.TblGenres select genreList).ToList();

            return lstgenre;
        }

    }
}
