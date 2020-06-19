using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnityRepositoryPatterns.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomRepository abc { get; }
        IAuthurResponsitory hehe { get; }
        int SaveChanges();
    }
}