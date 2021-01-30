using Microsoft.EntityFrameworkCore;
using LikeFeatureProject.Api.Domain.Entities;

namespace LikeFeatureProject.Api.Respository.Database.Context
{
    public class LikeFeatureProjectContext: DbContext
    {

        public DbSet<Like> Like { get; set; }

        public LikeFeatureProjectContext(DbContextOptions<LikeFeatureProjectContext> options)
            :base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
      
    }
}
