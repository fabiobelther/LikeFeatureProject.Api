using Microsoft.EntityFrameworkCore;
using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Domain.Interfaces.Repository;
using System;
using System.Linq;

namespace LikeFeatureProject.Api.Respository.Database.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T, int> where T : EntityBase
    {
        public readonly DbContext Context;
        public readonly DbSet<T> DbSet;

        public BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual T Save(T entity)
        {
            if (entity.IsNew)
                DbSet.Add(entity);
            else
                DbSet.Update(entity);

            return entity;
        }

        public virtual IQueryable<T> NoTracking()
        {
            return DbSet.AsNoTracking();
        }
    }
}
