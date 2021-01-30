using Microsoft.Extensions.DependencyInjection;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.Flow;
using LikeFeatureProject.Api.Service.Services.LikeUseCases.Flow;
using LikeFeatureProject.Api.Domain.Interfaces.Repository;
using LikeFeatureProject.Api.Respository.Database.Repositories;
using LikeFeatureProject.Api.Domain.Interfaces.Services.LikeUseCases.UseCase;
using LikeFeatureProject.Api.Service.Services.LikeUseCases.UseCase;

namespace LikeFeatureProject.Api.Host.DependencyInjection
{

    public static class ServiceDependency
    {
        public static void AddServiceDependecies(this IServiceCollection services)
        {
            services.AddScoped<IGetFindLikeFlow, GetFindLikeFlow>();
            services.AddScoped<IInsertLikeFlow, InsertLikeFlow>();

            services.AddScoped<IGetLikeByArticleIdUseCase, GetLikeByArticleIdUseCase>();
            services.AddScoped<IInsertLikeUseCase, InsertLikeUseCase>();

            services.AddScoped<ILikeRepository, LikeRepository>();
        }
    }
}
