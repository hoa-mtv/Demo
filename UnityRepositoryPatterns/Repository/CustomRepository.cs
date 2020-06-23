using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using UnityRepositoryPatterns.IRepository;
using UnityRepositoryPatterns.Models;
using UnityRepositoryPatterns.Persistence.Contexts;
using UnityRepositoryPatterns.Repository.Common;

namespace UnityRepositoryPatterns.Repository
{
    public class CustomRepository : BaseRepository, ICustomRepository
    {

        public CustomRepository(BookManageDbContext context) : base(context)
        {
        }

        //public DBEntities DBEntities
        //{
        //    get { return db as DBEntities; }
        //}

        public IEnumerable<Book> GetTop5CostlyBook()
        {
            return _context.Books.OrderByDescending(s => s.Price).Take(5).ToList();
        }

        public IEnumerable<Book> GetBookAutherWise(long AutherID)
        {
            return _context.Books.Where(s => s.AutherID == AutherID).ToList();
        }
    }
}