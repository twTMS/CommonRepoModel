using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLib
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets or sets the database context factory.
        /// </summary>
        /// <value>
        /// The database context factory.
        /// </value>
        private IDbContextFactory DbContextFactory { get; set; }

        /// <summary>
        /// The _context
        /// </summary>
        private DbContext _context;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public DbContext Context
        {
            get
            {
                if (_context == null)
                {
                    this._context = DbContextFactory.GetDbContext();
                }
                return this._context;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public UnitOfWork(IDbContextFactory factory)
        {
            this.DbContextFactory = factory;
        }

        /// <summary>
        /// Saves the change.
        /// </summary>
        /// <returns></returns>
        public int SaveChange()
        {
            return this.Context.SaveChanges();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                    this._context = null;
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
