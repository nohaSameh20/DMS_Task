﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;

namespace Application.Interfaces
{
    public interface IRepository
    {

    }

    public interface IRepository<T> : IRepository where T : class, IEntity
    {
        //EntityEntry Attach(T element);

        //======Simple CRUD ==========
        T Add(T item);
        void AddRange(List<T> range);

        T Update(T item);
        void UpdateRange(List<T> range);

        // Marks an entity to be removed
        void Delete(T entity);
        void DeleteRange(List<T> range);
        void Delete(Expression<Func<T, bool>> where);

        void Remove(T entity);

        //Get an item by id 
        T GetById(object id);
        IList<T> Get(Expression<Func<T, bool>> where);
        IList<T> GetAll();

        List<T> GetWith(Expression<Func<T, bool>> where);
        List<T> GetWith(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        IQueryable<T> Where(Expression<Func<T, bool>> where);

        T Single(Expression<Func<T, bool>> where);
        T Single(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        T Last(Expression<Func<T, bool>> where);


        List<T> GetPage(int pageIndex, int pageSize);
        List<T> GetPage(int pageIndex, int pageSize, params Expression<Func<T, bool>>[] conditions);
        List<T> GetPage(int pageIndex, int pageSize, params Expression<Func<T, object>>[] includes);

        int Count(Expression<Func<T, bool>> where);
        int Count();

        bool Any(Expression<Func<T, bool>> where);
        bool Any();
    }
}