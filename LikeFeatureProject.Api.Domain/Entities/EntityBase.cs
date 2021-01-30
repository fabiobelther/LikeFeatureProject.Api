using System;

namespace LikeFeatureProject.Api.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; protected set; }
        public bool IsNew => Id == 0;
    }
}
