using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnityRepositoryPatterns.IRepository;
using UnityRepositoryPatterns.Models;
using UnityRepositoryPatterns.Persistence.Contexts;

namespace UnityRepositoryPatterns.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookManageDbContext _bookManageContext;

        public UnitOfWork(BookManageDbContext context)
        {
            _bookManageContext = context;
            abc = new CustomRepository(_bookManageContext);
            hehe = new AuthorRespository(_bookManageContext);

        }

        public ICustomRepository abc { get; private set; }
        public IAuthurResponsitory hehe { get; private set; }

        //IAuthurResponsitory IUnitOfWork.hehe => throw new NotImplementedException();

        public int SaveChanges()
        {
            return _bookManageContext.SaveChanges();
        }

        public void Dispose()
        {
            _bookManageContext.Dispose();
        }
    }
}