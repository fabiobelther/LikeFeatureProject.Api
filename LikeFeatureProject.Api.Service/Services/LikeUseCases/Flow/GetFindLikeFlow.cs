using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.Flow;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase;
using System;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Service.Services.LikeUseCases.Flow
{
    public class GetFindLikeFlow : IGetFindLikeFlow
    {
        private IGetLikeByArticleIdUseCase _getLikeByArticleIdUseCase;

        public GetFindLikeFlow(IGetLikeByArticleIdUseCase getLikeByArticleIdUseCase)
        {
            _getLikeByArticleIdUseCase = getLikeByArticleIdUseCase;
        }

        public async Task<Like> Execute(int articleId)
        {
            try
            {
                var like = await _getLikeByArticleIdUseCase.Execute(articleId);

                if (like == null)
                    like = Like.Create(articleId, 0);

                return like;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
