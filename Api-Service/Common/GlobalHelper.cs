using Api_Service.Mappings;
using Api_Service.Repository;
using Api_Service.Services;
using Api_Service.Services.Jwt;

namespace Api_Service.Common
{
    public static class GlobalHelper
    {
        /// <summary>
        /// Phương thức mở rộng để đăng ký các dịch vụ (Services) vào Dependency Injection container.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Đăng ký AutoMapper
            services.AddAutoMapper(typeof(Program));

            // Đăng ký Repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            // Đăng ký Service
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPostService, PostService>();
            //services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<IJwtService, JwtService>();

            return services;
        }
        public static void AddMappingProfiles(this IServiceCollection services)
        {
            // Đăng ký tất cả các mapping profiles tại đây
            services.AddAutoMapper(
                typeof(CategoryProfile),
                typeof(ProductProfile),
                typeof(PostProfile)

            );
        }
    }
}
