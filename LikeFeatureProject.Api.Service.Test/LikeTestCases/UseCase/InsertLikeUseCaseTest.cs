using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Domain.Interfaces.Repository;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase;
using LikeFeatureProject.Api.Domain.Interfaces.Transactions;
using LikeFeatureProject.Api.Service.Services.LikeUseCases.UseCase;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace LikeFeatureProject.Api.Service.Test.LikeTestCases.UseCase
{
    public class InsertLikeUseCaseTest
    {
        private IInsertLikeUseCase _insertLikeUseCase;
        private Mock<ILikeRepository> _likeRespository { get; set; }
        private Mock<IUnitOfWork> _unitOfWork { get; set; }

        public InsertLikeUseCaseTest()
        {
            _likeRespository = new Mock<ILikeRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _insertLikeUseCase = new InsertLikeUseCase(_likeRespository.Object, _unitOfWork.Object);
        }


        [Fact]
        public void InsertLikeSuccess()
        {
            Like like = Like.Create(5, 10);

            // Mock
            this._likeRespository
                .Setup(b => b.Save(like))
                .Returns(like);

            this._unitOfWork
                .Setup(b => b.SaveChangesAsync());

            // Act
            var result = _insertLikeUseCase.Execute(like).Result;

            // Assert
            Assert.Equal(like.ArticleId, result.ArticleId);
            Assert.Equal(like.Count, result.Count);
        }
    }
}
