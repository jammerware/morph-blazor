using Microsoft.Extensions.DependencyInjection;

namespace MorphShared.Services
{
    public class MorphServicesBuilder
    {
        private IServiceCollection Services { get; set; }

        internal MorphServicesBuilder(IServiceCollection services)
        {
            this.Services = services;
        }

        public void AddClipboardService<T>() where T : class, IClipboardService
        {
            this.Services.AddScoped<IClipboardService, T>();
        }

        public void AddShareService<T>() where T : class, IShareService
        {
            this.Services.AddScoped<IShareService, T>();
        }
    }
}
