using LikeFeatureProject.Api.Domain.Interfaces.Transactions;
using LikeFeatureProject.Api.Respository.Database.Context;
using System;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Respository.Database.Transacions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LikeFeatureProjectContext _context;

        public UnitOfWork(LikeFeatureProjectContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }

}
