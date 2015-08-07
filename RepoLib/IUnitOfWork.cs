using System;
using System.Data.Entity;

namespace RepoLib
{
    /// <summary>
    /// Unit of work 
    /// </summary>
    public interface IUnitOfWork: IDisposable
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        DbContext Context { get; }

        /// <summary>
        /// Saves the change.
        /// </summary>
        /// <returns></returns>
        int SaveChange();
    }
}