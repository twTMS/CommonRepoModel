using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ServiceLib
{
    public interface ICommonService<Entity> where Entity : class
    {
        IResult Create(Entity instance);
        IResult Delete(int Id);
        IEnumerable<Entity> GetAll();
        Entity GetById(object Id);
        bool IsExists(Expression<Func<Entity, bool>> predicate);
        IResult Update(Entity instance);
    }
}