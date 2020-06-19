using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnityRepositoryPatterns.IRepository;
using UnityRepositoryPatterns.Models;


namespace UnityRepositoryPatterns.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBEntities db;

        public UnitOfWork(DBEntities context)
        {
            db = context;
            abc = new CustomRepository(db);
            hehe = new AuthorRespository(db);

        }

        public ICustomRepository abc { get; private set; }
        public IAuthurResponsitory hehe { get; private set; }

        //IAuthurResponsitory IUnitOfWork.hehe => throw new NotImplementedException();

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}