using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation
{
    /// <summary>
    /// Generic repository 
    /// </summary>
    /// <typeparam name="TEntity">Entity type </typeparam>
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal MoviesRecDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(MoviesRecDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }


        /// <summary>
        /// Function to get a collection of entities async 
        /// </summary>
        /// <param name="filter">Expression to filter query </param>
        /// <param name="orderBy">Func to order query by </param>
        /// <param name="includeProperties">properties to include </param>
        /// <returns> Collection of entities </returns>

        public virtual async Task <ICollection<TEntity>> GetAsync(
            Expression<Func<TEntity,bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = this.dbSet;

            if (filter != null)
                query = query.Where(filter);


            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }


            if (orderBy != null)
                return  await orderBy(query).ToListAsync();
            else
                return await query.ToListAsync();
        }

        /// <summary>
        /// Method that gets entity by its id
        /// </summary>
        /// <param name="id"> id of entity </param>
        /// <returns> entity object </returns>

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        /// <summary>
        /// Function to insert entity into set
        /// </summary>
        /// <param name="entity"> entity to insert </param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Funtion to delete entity specified by its id
        /// </summary>
        /// <param name="id"> id of the entity to delete </param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Function to delete entity directly 
        /// </summary>
        /// <param name="entityToDelete"> entity to delete </param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }


        /// <summary>
        /// Function to upadte the entity 
        /// </summary>
        /// <param name="entityToUpdate"> entity to update </param>
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
