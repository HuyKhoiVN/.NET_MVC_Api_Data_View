using AppData.Context;
using AppData.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repositories
{
    public class AllRepos<T> : IAllRepos<T> where T : class
    {
        NhanVienContext context;
        DbSet<T> dbSet; //Tao moi vi dung generic khong tro toi 1 dbset cu the

        public AllRepos()
        {
            
        } 

        public AllRepos(NhanVienContext context, DbSet<T> dbSet)
        {
            this.context = context;
            this.dbSet = dbSet;
        }
        public bool CreateItem(T item)
        {
            try
            {
                dbSet.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteItem(T item)
        {
            try
            {
                dbSet.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAllItems()
        {
            return dbSet.ToList();
        }

        public T GetByID(Guid id)
        {
            return dbSet.Find(id);
        }

        public bool UpdateItem(T item)
        {
            try
            {
                dbSet.Update(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
