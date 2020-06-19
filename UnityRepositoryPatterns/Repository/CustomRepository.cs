using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using UnityRepositoryPatterns.IRepository;
using UnityRepositoryPatterns.Models;

namespace UnityRepositoryPatterns.Repository
{
    public class CustomRepository : Repository<Book>, ICustomRepository
    {

        public CustomRepository(DBEntities context) : base(context)
        {
        }

        public DBEntities DBEntities
        {
            get { return db as DBEntities; }
        }

        public IEnumerable<Book> GetTop5CostlyBook()
        {
            return DBEntities.Books.OrderByDescending(s => s.Price).Take(5).ToList();
        }

        public IEnumerable<Book> GetBookAutherWise(long AutherID)
        {
            return DBEntities.Books.Where(s => s.AutherID == AutherID).ToList();
        }
    }
}