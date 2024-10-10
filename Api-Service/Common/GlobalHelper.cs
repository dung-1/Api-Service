using Api_Service.Mappings;
using Api_Service.Repository;
using Api_Service.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

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

            // Đăng ký Service
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
        public static void AddMappingProfiles(this IServiceCollection services)
        {
            // Đăng ký tất cả các mapping profiles tại đây
            services.AddAutoMapper(
                typeof(CategoryProfile),
                typeof(ProductProfile)
            );
        }
    }
}
