
using System;

namespace LikeFeatureProject.Api.Domain.Entities
{
    public class Like: EntityBase
    {
        public int ArticleId { get; private set; }

        public int Count { get; private set; }

        public void SetCount(int count) => this.Count = count;

        public static Like Create(int articleId, int count) => new Like { ArticleId = articleId, Count = count };
    }

}   
