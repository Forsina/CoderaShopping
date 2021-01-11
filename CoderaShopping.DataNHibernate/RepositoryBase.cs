using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;

namespace CoderaShopping.DataNHibernate
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);

        // Marks an entity as modified
        void Update(T entity);

        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);

        // Get an entity by Guid id
        T GetById(Guid id);

        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);

        // Gets all entities of type T
        IQueryable<T> GetAll();

        // Gets entities using delegate
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        // Checks whether an entity is unique
        bool IsUnique(T entity);
    }

    public abstract class RepositoryBase<T> where T : class
    {
        private readonly UnitOfWork _unitOfWork;

        protected ISession Session => _unitOfWork.Session;

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public virtual void Add(T entity)
        {
            Session.Save(entity);
        }

        public virtual void Update(T entity)
        {
            Session.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = Session.Query<T>().Where(where);

            foreach (T obj in objects)
                Session.Delete(obj);
        }

        public virtual T GetById(Guid id)
        {
            return Session.Get<T>(id);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return Session.Query<T>().Where(where).FirstOrDefault();
        }

        public virtual IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return Session.Query<T>().Where(where);
        }

        public virtual bool IsUnique(T entity) => !Session.Query<T>().Any();
    }
}
