using Microsoft.Extensions.DependencyInjection;
using MorphShared.Services;

namespace MorphShared
{
    public static class Extensions
    {
        public static void AddMorphSharedServices(this IServiceCollection services)
        {
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<FrequencyRankService>();
        }
    }
}
