using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace UnityRepositoryPatterns.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //This method is use for insert single row in single table   
        void Add(TEntity entity);

        //This method is use for insert multiple rows in single table
        void AddRange(IEnumerable<TEntity> entities);

        //This method is use for remove single row from single table   
        void Remove(TEntity entity);

        //This method is use for remove multiple row from single table   
        void RemoveRange(IEnumerable<TEntity> entities);

        //This method is use for retrive single row according to id from table
        TEntity Get(int id);

        //This method is use for retrive all rows from table
        IEnumerable<TEntity> GetAll();

        //This method is use for retrive all rows according to input condition from table
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

       
    }
}