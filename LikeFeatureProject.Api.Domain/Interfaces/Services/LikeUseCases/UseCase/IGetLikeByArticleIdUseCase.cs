using LikeFeatureProject.Api.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase
{
    public interface IGetLikeByArticleIdUseCase
    {
        Task<Like> Execute(int articleId);
    }
}
