using System;
using System.Linq;
using Microsoft.Data.Entity;
using RepairPartsCatalog.Domain.Contracts.Repositories;
using RepairPartsCatalog.Entities.Catalog.Common;

namespace RepairPartsCatalog.Domain.Data.Catalog.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        public BaseRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }

            DbContext = dbContext;
        }

        /// <summary>
        /// Gets or sets dbcontext
        /// </summary>
        protected DbContext DbContext { get; set; }

        /// <summary>
        /// Gets or sets dbset
        /// </summary>
        protected DbSet<T> DbSet => DbContext.Set<T>();

        #region IRepository<T> Members

        /// <summary>
        /// Gets all the entities of type T
        /// </summary>
        /// <returns>Result set of all the entities</returns>
        public virtual IQueryable<T> All()
        {
            return DbSet;
        }

        /// <summary>
        /// Gets entity from repository by id.
        /// </summary>
        /// <param name="id">System identifier of entity in application.</param>
        /// <returns>Returns loaded entity or null.</returns>
        public virtual T GetById(long id)
        {
            return DbSet.FirstOrDefault(it => it.Id == id);
        }

        /// <summary>
        /// Saves entity in the repository.
        /// </summary>
        /// <param name="entity">Entity to save.</param>
        public virtual void InsertOrUpdate(T entity, bool startTrackProperties = false)
        {
            if (IsNew(entity))
            {
                DbSet.Add(entity);
            }

            AttachForUpdate(entity, startTrackProperties);
        }

        /// <summary>
        /// Deletes entity from repository.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        public virtual void Delete(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).SetState(EntityState.Deleted);
            DbSet.Remove(entity);
        }

        /// <summary>
        /// Deletes entity by mathing id.
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(long id)
        {
            DbSet.Remove(GetById(id));
        }

        #endregion

        /// <summary>
        /// Attaches entity to context and marks it as updated for EF to update.
        /// </summary>
        /// <param name="entity">Entity to attach.</param>
        /// <typeparam name="T">Type of entity to attach.</typeparam>
        protected void AttachForUpdate(T entity, bool startTrackProperties)
        {
            if (IsNew(entity))
            {
                return;
            }

            DbContext.Set<T>().Attach(entity);
            if (!startTrackProperties)
            {
                DbContext.Entry(entity).SetState(EntityState.Modified);
            }
        }

        /// <summary>
        /// Checks if entity is new.
        /// </summary>
        /// <param name="entity">Entity to check.</param>
        /// <typeparam name="T">Type of entity to attach.</typeparam>
        /// <returns>Returns a value indicating whether provided entity is new (not added previously).</returns>
        protected bool IsNew(T entity)
        {
            return entity.Id <= 0;
        }
    }
}