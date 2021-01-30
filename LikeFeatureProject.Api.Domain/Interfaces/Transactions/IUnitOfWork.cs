using System;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Domain.Interfaces.Transactions
{
    public interface IUnitOfWork: IDisposable
    {
        bool SaveChanges();

        Task<bool> SaveChangesAsync();
    }
}
