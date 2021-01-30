using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.Flow;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase;
using System;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Service.Services.LikeUseCases.Flow
{
    public class InsertLikeFlow : IInsertLikeFlow
    {
        private IGetLikeByArticleIdUseCase _getLikeByArticleIdUseCase;
        private IInsertLikeUseCase _insertLikeUseCase;

        public InsertLikeFlow(IGetLikeByArticleIdUseCase getLikeByArticleIdUseCase,
                              IInsertLikeUseCase insertLikeUseCase)
        {
            _getLikeByArticleIdUseCase = getLikeByArticleIdUseCase;
            _insertLikeUseCase = insertLikeUseCase;
        }
        public async Task<Like> Execute(int articleId)
        {
            try
            {
                var like = await _getLikeByArticleIdUseCase.Execute(articleId);

                if (like == null)
                    like = Like.Create(articleId, 1);
                else
                    like.SetCount(like.Count + 1);

                return await _insertLikeUseCase.Execute(like);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
