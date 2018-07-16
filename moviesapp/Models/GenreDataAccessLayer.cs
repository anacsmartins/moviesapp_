using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesapp.Models
{
    public class GenreDataAccessLayer
    {
        dbmoviesContext db = new dbmoviesContext();

        public IEnumerable<TblGenres> GetAllGenres()
        {
            try
            {
                return db.TblGenres.ToList();
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Add new genre record   
        public int AddGenres(TblGenres genre)
        {
            try
            {
                db.TblGenres.Add(genre);
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

        //To Update the records of a particluar genre  
        public int UpdateGenres(TblGenres genre)
        {
            try
            {                
                db.Entry(genre).State = EntityState.Modified;
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

        //Get the details of a particular genre  
        public TblGenres GetGenresData(int id)
        {
            try
            {
                TblGenres genre = db.TblGenres.Find(id);
                return genre;
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Delete the record of a particular genre  
        public int DeleteGenres(int id)
        {
            try
            {
                TblGenres genre = db.TblGenres.Find(id);
                db.TblGenres.Remove(genre);
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
