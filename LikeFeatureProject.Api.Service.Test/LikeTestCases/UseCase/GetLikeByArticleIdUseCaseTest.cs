using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Domain.Interfaces.Repository;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase;
using LikeFeatureProject.Api.Service.Services.LikeUseCases.UseCase;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace LikeFeatureProject.Api.Service.Test.LikeTestCases.UseCase
{
    public class GetLikeByArticleIdUseCaseTest
    {
        private IGetLikeByArticleIdUseCase _getLikeByArticleIdUseCase;
        private Mock<ILikeRepository> _likeRespository { get; set; }

        public GetLikeByArticleIdUseCaseTest()
        {
            _likeRespository = new Mock<ILikeRepository>();
            _getLikeByArticleIdUseCase = new GetLikeByArticleIdUseCase(_likeRespository.Object);
        }


        [Fact]
        public void GetLikeByArticleIdFound()
        {
            int articleId = 5;
            int count = 2;

            // Mock
            this._likeRespository
                .Setup(b => b.FindByArticleId(articleId))
                .ReturnsAsync(Like.Create(articleId, count));

            // Act
            var result = _getLikeByArticleIdUseCase.Execute(articleId).Result;

            // Assert
            Assert.Equal(articleId, result.ArticleId);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void GetLikeByArticleIdNotFound()
        {
            Like returnRepository = null;

            // Mock
            this._likeRespository
                .Setup(b => b.FindByArticleId(It.IsAny<int>()))
                .ReturnsAsync(returnRepository);

            // Act
            var result = _getLikeByArticleIdUseCase.Execute(10).Result;

            // Assert
            Assert.Null(result);
        }
    }
}
