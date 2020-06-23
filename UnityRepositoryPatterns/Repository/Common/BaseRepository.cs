using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using UnityRepositoryPatterns.Persistence;
using UnityRepositoryPatterns.Persistence.Contexts;

namespace UnityRepositoryPatterns.Repository.Common
{
    public abstract class BaseRepository
    {
        protected readonly BookManageDbContext _context;

        public BaseRepository(BookManageDbContext bokManageDbContext)
        {
            _context = bokManageDbContext;
        }

    }
}