using LikeFeatureProject.Api.Domain.Entities;
using LikeFeatureProject.Api.Host.Models.Like.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LikeFeatureProject.Api.Host.Translate.LikeTranslate.Response
{
    public class LikeToLikeResponse
    {
        public static LikeResponse Translate(Like entity) =>
            LikeResponse.Create(
                articleId: entity.ArticleId,
                count: entity.Count
                );
    }
}
