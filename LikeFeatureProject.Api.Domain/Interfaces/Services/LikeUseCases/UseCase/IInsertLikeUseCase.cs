using LikeFeatureProject.Api.Domain.Entities;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase
{
    public interface IInsertLikeUseCase
    {
        Task<Like> Execute(Like like);
    }
}
