using System;
using System.Data.Entity;

namespace RepoLib
{
    /// <summary>
    /// The db context factory interface
    /// </summary>
    public interface IDbContextFactory
    {
        /// <summary>
        /// Gets the instance identifier.
        /// </summary>
        /// <value>
        /// The instance identifier.
        /// </value>
        Guid InstanceId { get; }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <returns></returns>
        DbContext GetDbContext();
    }
}