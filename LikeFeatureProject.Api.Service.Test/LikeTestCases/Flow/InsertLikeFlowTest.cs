using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.Flow;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase;
using LikeFeatureProject.Api.Service.Services.LikeUseCases.Flow;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace LikeFeatureProject.Api.Service.Test.LikeTestCases.Flow
{
    public class InsertLikeFlowTest
    {
        private IInsertLikeFlow _insertLikeFlow;
        private Mock<IGetLikeByArticleIdUseCase> _getLikeByArticleIdUseCase { get; set; }
        private Mock<IInsertLikeUseCase> _insertLikeUseCase { get; set; }

        public InsertLikeFlowTest()
        {
            _getLikeByArticleIdUseCase = new Mock<IGetLikeByArticleIdUseCase>();
            _insertLikeUseCase = new Mock<IInsertLikeUseCase>();
            _insertLikeFlow = new InsertLikeFlow(_getLikeByArticleIdUseCase.Object, _insertLikeUseCase.Object);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { 5, Like.Create(5, 10), Like.Create(5, 11) },
            new object[] { 6, null, Like.Create(6, 1) }
        };


        [Theory]
        [MemberData(nameof(Data))]
        public void InsertLikeSuccess(int articleId, Like returnGetUseCase, Like expected)
        {
            // Mock
            this._getLikeByArticleIdUseCase
                .Setup(b => b.Execute(articleId))
                .ReturnsAsync(returnGetUseCase);

            this._insertLikeUseCase
                .Setup(b => b.Execute(It.IsAny<Like>()))
                .ReturnsAsync(expected);

            // Act
            var result = _insertLikeFlow.Execute(articleId).Result;

            // Assert
            Assert.Equal(expected.ArticleId, result.ArticleId);
            Assert.Equal(expected.Count, result.Count);
        }
    }
}
