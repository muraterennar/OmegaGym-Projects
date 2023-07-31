using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.GenericRepository.FranchisingRepo;
using OmegaGymServer.Application.GenericRepository.ImageRepo;
using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;
using OmegaGymServer.Application.GenericRepository.SubscriptionCategoryRepo;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;
using OmegaGymServer.Application.GenericRepository.UserRepo;
using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;
using OmegaGymServer.Persistence.Contexts;
using OmegaGymServer.Persistence.GenericRepository.FranchisingRepo;
using OmegaGymServer.Persistence.GenericRepository.ImageRepo;
using OmegaGymServer.Persistence.GenericRepository.OperationClaimRepo;
using OmegaGymServer.Persistence.GenericRepository.SubscriptionCategoryRepo;
using OmegaGymServer.Persistence.GenericRepository.SubscriptionRepo;
using OmegaGymServer.Persistence.GenericRepository.UserRepo;
using OmegaGymServer.Persistence.GenericRepository.UserSubscriptionRepo;
using OmegaGymServer.Persistence.Services;

namespace OmegaGymServer.Persistence;

public static class ServiceRegistiration
{
    public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OmegaGymEfDbContext>(
                options =>
                options.UseSqlServer(configuration["ConnectionStrings:MsSqlServer"], opt => opt.EnableRetryOnFailure())
            );

        //User
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();

        //Subscription Category
        services.AddScoped<ISubscriptionReadRepository, SubscriptionReadRepository>();
        services.AddScoped<ISubscriptionWriteRepository, SubscriptionWriteRepository>();
        services.AddScoped<ISubscriptionCategoryService, SubscriptionCategoryService>();

        //Subscription
        services.AddScoped<ISubscriptionCategoryReadRepository, SubscriptionCategoryReadRepository>();
        services.AddScoped<ISubscriptionCategoryWriteRepository, SubscriptionCategoryWriteRepository>();
        services.AddScoped<ISubscriptionService, SubscriptionService>();

        //OperationClaim
        services.AddScoped<IOperationClaimReadRepository, OperationClaimReadRepository>();
        services.AddScoped<IOperationClaimWriteRepositoory, OperationClaimWriteRepository>();
        services.AddScoped<IOperationClaimService, OperationClaimService>();

        //UserSubscription
        services.AddScoped<IWriteUserSubscriptionRepository, UserSubscriptionWriteRepository>();
        services.AddScoped<IReadUserSubscriptionRepository, UserSubscriptionReadRepository>();

        //Image
        services.AddScoped<IImageWriteRepository, ImageWriteRepository>();
        services.AddScoped<IImageReadRepository, ImageReadRepository>();
        services.AddScoped<IImageService, ImageService>();

        //Franchising
        services.AddScoped<IFranchinsingWriteRepository, WriteFranchisingRepository>();
        services.AddScoped<IFranchisingReadRepository, ReadFranchisingRepository>();
        services.AddScoped<IFranchisingService, FranchisingService>();




        // ------- DataSeeding
        var seedData = new SeedData();
        seedData.SeedAsync(configuration).GetAwaiter().GetResult();
    }
}

