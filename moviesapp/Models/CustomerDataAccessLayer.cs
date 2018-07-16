using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesapp.Models
{
    public class CustomersDataAccessLayer
    {
        dbmoviesContext db = new dbmoviesContext();

        public IEnumerable<TblCustomers> GetAllCustomers()
        {
            try
            {
                return db.TblCustomers.ToList();
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Add new customer record   
        public int AddCustomers(TblCustomers customer)
        {
            try
            {
                db.TblCustomers.Add(customer);
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

        //To Update the records of a particluar customer  
        public int UpdateCustomers(TblCustomers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Modified;
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

        //Get the details of a particular customer  
        public TblCustomers GetCustomersData(int id)
        {
            try
            {
                TblCustomers customer = db.TblCustomers.Find(id);
                return customer;
            }
            catch (System.IO.IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //To Delete the record of a particular customer  
        public int DeleteCustomers(int id)
        {
            try
            {
                TblCustomers emp = db.TblCustomers.Find(id);
                db.TblCustomers.Remove(emp);
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
