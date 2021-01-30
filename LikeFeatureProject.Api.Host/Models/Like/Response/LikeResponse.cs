namespace LikeFeatureProject.Api.Host.Models.Like.Response
{
    public class LikeResponse
    {
        public int ArticleId { get; private set; }

        public int Count { get; private set; }

        public static LikeResponse Create(int articleId, int count) => new LikeResponse { ArticleId = articleId, Count = count };
    }
}
