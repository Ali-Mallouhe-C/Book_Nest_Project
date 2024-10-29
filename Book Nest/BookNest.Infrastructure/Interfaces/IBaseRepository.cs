using System.Linq.Expressions;

namespace BookNest.Infrastructure.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Retrieves a single entity asynchronously.
        /// </summary>
        /// <returns>The entity of type <typeparamref name="TEntity"/>.</returns>
        Task<IEnumerable<TEntity>> GetAsync(int pageNumber = 1, int pageSize = 10);

        /// <summary>
        /// Retrieves an entity by its unique identifier asynchronously, with optional includes for related entities.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <param name="includes">Related entities to include in the result.</param>
        /// <returns>The entity of type <typeparamref name="TEntity"/> if found; otherwise, <c>null</c>.</returns>
        Task<TEntity?> GetByIdAsync(int id);

        /// <summary>
        /// Adds a new entity asynchronously to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity of type <typeparamref name="TEntity"/>.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Updates an existing entity asynchronously in the repository.
        /// </summary>
        /// <param name="entity">The entity with updated values.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes an entity by its unique identifier asynchronously from the repository.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        /// <returns>The deleted entity of type <typeparamref name="TEntity"/> if found; otherwise, <c>null</c>.</returns>
        Task<TEntity?> DeleteAsync(int id);

        /// <summary>
        /// Retrieves a single entity asynchronously based on a specified property expression.
        /// </summary>
        /// <param name="expression">The expression used to find the entity.</param>
        /// <returns>The entity of type <typeparamref name="TEntity"/> if found; otherwise, <c>null</c>.</returns>
        Task<TEntity?> GetByPropertyAsync(Expression<Func<TEntity, bool>> expression);
    }
}