using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.Flow;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase;
using LikeFeatureProject.Api.Service.Services.LikeUseCases.Flow;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace LikeFeatureProject.Api.Service.Test.LikeTestCases.Flow
{
    public class GetFindLikeFlowTest
    {
        private IGetFindLikeFlow _getFindLikeFlow;
        private Mock<IGetLikeByArticleIdUseCase> _getLikeByArticleIdUseCase { get; set; }

        public GetFindLikeFlowTest()
        {
            _getLikeByArticleIdUseCase = new Mock<IGetLikeByArticleIdUseCase>();
            _getFindLikeFlow = new GetFindLikeFlow(_getLikeByArticleIdUseCase.Object);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { 5, Like.Create(5, 10), Like.Create(5, 10) },
            new object[] { 6, null, Like.Create(6, 0) }
        };


        [Theory]
        [MemberData(nameof(Data))]
        public void GetFindLikeSuccess(int articleId, Like returnUseCase, Like expected)
        {
            // Mock
            this._getLikeByArticleIdUseCase
                .Setup(b => b.Execute(articleId))
                .ReturnsAsync(returnUseCase);

            // Act
            var result = _getFindLikeFlow.Execute(articleId).Result;

            // Assert
            Assert.Equal(expected.ArticleId, result.ArticleId);
            Assert.Equal(expected.Count, result.Count);
        }
    }
}
