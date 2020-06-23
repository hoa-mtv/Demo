using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnityRepositoryPatterns.IRepository;
using UnityRepositoryPatterns.Models;
using System.Data;
using UnityRepositoryPatterns.Persistence.Contexts;
using UnityRepositoryPatterns.Repository.Common;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UnityRepositoryPatterns.Repository
{
    public class AuthorRespository : BaseRepository, IAuthurResponsitory
    {
        public AuthorRespository(BookManageDbContext context) : base(context)
        {
        }
        //public DBEntities DBEntities
        //{
        //    get { return db as DBEntities; }
        //}

        public IEnumerable<Auther> getlist()
        {
            return _context.Auther.ToList();
        }

        //public IEnumerable<Book> GetTop5CostlyBook()
        //{
        //    return _context.Books.OrderByDescending(s => s.Price).Take(5).ToList();
        //}

        //public async Task<IEnumerable<Auther>> getlist()
        //{
        //    return await _context.Auther.ToListAsync();
        //}

        public DataTable getdb()
        {
            string sql = " select * from auther ";
            DataTable dt = Help.DataTable_Sql(sql);
            return dt;
            
        }

        public Auther FindAutherById(long id)
        {
            return _context.Auther.Find(id);
        }

        public Auther DeleteAutherById(long id)
        {
            Auther auther = FindAutherById(id);
            if (auther != null)
            {
                _context.Auther.Remove(auther);
            }
            return auther;
        }
    }
}