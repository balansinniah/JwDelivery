using System;
using System.Threading.Tasks;

namespace EntityFramework.Core.Generic.Pattern.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private IDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The object context</param>
        public UnitOfWork(IDbContext context)
        {

            _dbContext = context;
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public async Task<int> Commit()
        {
            // Save changes with the default options
            return await _dbContext.SaveChangesAsync();
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing || _dbContext == null) return;
            _dbContext.Dispose();
            _dbContext = null;
        }
    }
}
