using System;
using System.Linq;

namespace LikeFeatureProject.Api.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T, in TPk> : IDisposable
    {
        T Save(T entity);

        IQueryable<T> NoTracking();
    }
}
