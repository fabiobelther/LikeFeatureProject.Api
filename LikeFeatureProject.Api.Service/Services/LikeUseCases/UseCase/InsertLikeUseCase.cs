using System.Threading.Tasks;
using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Domain.Interfaces.Repository;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase;
using LikeFeatureProject.Api.Domain.Interfaces.Transactions;

namespace LikeFeatureProject.Api.Service.Services.LikeUseCases.UseCase
{
    public class InsertLikeUseCase : IInsertLikeUseCase
    {   
        private ILikeRepository _likeRespository;
        private readonly IUnitOfWork _unitOfWork;


        public InsertLikeUseCase(ILikeRepository likeRespository,
                                 IUnitOfWork unitOfWork)
        {
            _likeRespository = likeRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Like> Execute(Like like)
        {
            var savedLike = _likeRespository.Save(like) ;
            await _unitOfWork.SaveChangesAsync();
            return savedLike;
        }
    }
}
