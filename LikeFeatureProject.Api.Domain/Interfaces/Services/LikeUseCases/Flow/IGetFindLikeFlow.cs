using LikeFeatureProject.Api.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.Flow
{
    public interface IGetFindLikeFlow
    {
        Task<Like> Execute(int articleId);
    }
}
