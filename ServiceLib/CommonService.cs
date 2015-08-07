using RepoLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib
{
    /// <summary>
    /// Generic Common Service
    /// </summary>
    /// <typeparam name="Entity">The type of the ntity.</typeparam>
    public class CommonService<Entity> : ICommonService<Entity> where Entity:class
    {
        /// <summary>
        /// The _repository
        /// </summary>
        private readonly IRepository<Entity> _repository; 

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonService{Entity}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CommonService(IRepository<Entity> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Creates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public IResult Create(Entity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this._repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        /// <summary>
        /// Updates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public IResult Update(Entity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this._repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IResult Delete(int Id)
        {
            IResult result = new Result(false);

            try
            {
                var instance = this.GetById(Id);
                if (instance != null)
                {
                    this._repository.Delete(instance);

                    result.Success = true;
                }
                else
                    result.Message = "找不到資料";
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Entity GetById(object Id)
        {
            return this._repository.Find(Id);
        }

        /// <summary>
        /// Determines whether the specified predicate is exists.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public bool IsExists(Expression<Func<Entity, bool>> predicate)
        {
            return this._repository.GetAll().Any(predicate);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Entity> GetAll()
        {
            return this._repository.GetAll();
        }
    }
}
