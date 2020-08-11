using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Data.Bases;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework.Bases
{
    public abstract class RepositoryBase<TEntity> : IDisposable where TEntity : BaseEntity, new()
    {
        private readonly DbContext _context;

        public bool Commit { get; set; }

        public RepositoryBase(DbContext context)
        {
            _context = context;
            Commit = true;
        }

        public virtual IQueryable<TEntity> GetEntityQuery()
        {
            try
            {
                return _context.Set<TEntity>().AsQueryable();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual IQueryable<TEntity> GetEntityQuery(params string[] entitiesToInclude)
        {
            try
            {
                var queryEntity = GetEntityQuery();
                foreach (string entityToInclude in entitiesToInclude)
                {
                    queryEntity = queryEntity.Include(entityToInclude);
                }
                return queryEntity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual IQueryable<TEntity> GetEntityQuery(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return GetEntityQuery().Where(predicate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual IQueryable<TEntity> GetEntityQuery(Expression<Func<TEntity, bool>> predicate, params string[] entitiesToInclude)
        {
            try
            {
                var queryEntity = GetEntityQuery(entitiesToInclude);
                return queryEntity.Where(predicate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual List<TEntity> GetEntities()
        {
            try
            {
                return GetEntityQuery().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual List<TEntity> GetEntities(params string[] entitiesToInclude)
        {
            try
            {
                var queryEntity = GetEntityQuery(entitiesToInclude);
                return queryEntity.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual List<TEntity> GetEntities(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return GetEntityQuery(predicate).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual List<TEntity> GetEntities(Expression<Func<TEntity, bool>> predicate, params string[] entitiesToInclude)
        {
            try
            {
                var queryEntity = GetEntityQuery(entitiesToInclude);
                return queryEntity.Where(predicate).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity GetEntity(int id)
        {
            try
            {
                return GetEntityQuery().SingleOrDefault(e => e.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity GetEntity(string guid)
        {
            try
            {
                return GetEntityQuery().SingleOrDefault(e => e.Guid == guid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity GetEntity(int id, params string[] entitiesToInclude)
        {
            try
            {
                return GetEntityQuery(entitiesToInclude).SingleOrDefault(e => e.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity GetEntity(string guid, params string[] entitiesToInclude)
        {
            try
            {
                return GetEntityQuery(entitiesToInclude).SingleOrDefault(e => e.Guid == guid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity GetEntity(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return GetEntityQuery().SingleOrDefault(predicate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity GetEntity(Expression<Func<TEntity, bool>> predicate, params string[] entitiesToInclude)
        {
            try
            {
                return GetEntityQuery(entitiesToInclude).SingleOrDefault(predicate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual bool EntityExists(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (GetEntityQuery().Any(predicate))
                    return true;
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int GetEntityCount()
        {
            try
            {
                return GetEntityQuery().Count();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int GetEntityCount(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return GetEntityQuery().Count(predicate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void AddEntity(TEntity entity)
        {
            try
            {
                entity.Guid = Guid.NewGuid().ToString();
                var contextEntity = _context.Entry(entity);
                contextEntity.State = EntityState.Added;
                if (Commit)
                    SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void UpdateEntity(TEntity entity)
        {
            try
            {
                var contextEntity = _context.Entry(entity);
                contextEntity.State = EntityState.Modified;
                if (Commit)
                    SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void DeleteEntity(int id)
        {
            try
            {
                var entity = GetEntity(id);
                DeleteEntity(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void DeleteEntity(string guid)
        {
            try
            {
                var entity = GetEntity(guid);
                DeleteEntity(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void DeleteEntity(TEntity entity)
        {
            try
            {
                var contextEntity = _context.Entry(entity);
                contextEntity.State = EntityState.Deleted;
                if (Commit)
                    SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int SaveChanges()
        {
            try
            {
                Commit = true;
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void ExecuteSql(string sql)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(sql);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region Dispose
        private bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context?.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
