using System;
using System.Threading.Tasks;
using LikeFeatureProject.Api.Domain.Entities;

namespace LikeFeatureProject.Api.Domain.Interfaces.Repository
{
    public interface ILikeRepository
    {
        Like Save(Like like);

        Task<Like> FindByArticleId(int articleId);
    }
}
