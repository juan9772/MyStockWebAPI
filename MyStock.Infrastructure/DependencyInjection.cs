using MyStock.Application.Services;
using MyStock.Domain.Repositories;
using MyStock.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MyStock.Infrastructure
{
    /// <summary>
    /// Extensiones para registrar servicios de infraestructura
    /// </summary>
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Registrar repositorios
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            // Registrar servicios de aplicacion
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockService, StockService>();

            return services;
        }
    }
}
