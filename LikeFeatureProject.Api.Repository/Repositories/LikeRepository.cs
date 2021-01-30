using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Domain.Interfaces.Repository;
using LikeFeatureProject.Api.Respository.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Respository.Database.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(LikeFeatureProjectContext context) : base(context) { }

        public async Task<Like> FindByArticleId(int articleId) =>
            await NoTracking().FirstOrDefaultAsync(x => x.ArticleId == articleId);


    }
}
