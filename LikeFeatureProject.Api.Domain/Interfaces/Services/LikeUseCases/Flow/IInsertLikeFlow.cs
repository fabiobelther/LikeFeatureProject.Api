using LikeFeatureProject.Api.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.Flow
{
    public interface IInsertLikeFlow
    {
        Task<Like> Execute(int articleId);
    }
}
