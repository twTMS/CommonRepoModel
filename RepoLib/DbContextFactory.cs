using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLib
{
    /// <summary>
    /// Db Context Factory
    /// </summary>
    public class DbContextFactory : DbContext, IDbContextFactory
    {
        /// <summary>
        /// The _instance identifier
        /// </summary>
        private readonly Guid _instanceId;

        /// <summary>
        /// The _connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// The _DB context
        /// </summary>
        private DbContext _dbContext;

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        private DbContext DbContext
        {
            get
            {
                if (this._dbContext == null)
                {
                    Type t = typeof(DbContext);
                    this._dbContext = (DbContext)Activator.CreateInstance(t, this._connectionString);
                }
                return _dbContext;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextFactory"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public DbContextFactory(string connectionString) : base(connectionString)
        {
            _instanceId = Guid.NewGuid();
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            this._connectionString = connectionString;
        }

        /// <summary>
        /// Gets the instance identifier.
        /// </summary>
        /// <value>
        /// The instance identifier.
        /// </value>
        public Guid InstanceId { get { return _instanceId; } }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            return this.DbContext;
        }
    }
}
