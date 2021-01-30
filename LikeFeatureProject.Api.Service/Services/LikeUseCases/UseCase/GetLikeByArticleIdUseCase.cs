using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Domain.Interfaces.Repository;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase;
using System;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Service.Services.LikeUseCases.UseCase
{
    public class GetLikeByArticleIdUseCase : IGetLikeByArticleIdUseCase
    {
        private ILikeRepository _likeRespository;
        public GetLikeByArticleIdUseCase(ILikeRepository likeRespository)
        {
            _likeRespository = likeRespository;
        }
        public async Task<Like> Execute(int articleId)
        {
            return await _likeRespository.FindByArticleId(articleId);
        }
    }
}
