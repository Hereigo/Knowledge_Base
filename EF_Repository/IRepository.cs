﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EF_Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Edit(T entity);
    }

    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }
}
