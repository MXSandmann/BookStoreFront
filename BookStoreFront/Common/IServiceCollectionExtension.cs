using BookStoreFront.HttpClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace BookStoreFront.Common
{
    public static class IServiceCollectionExtension
    {
       
        public static void RegisterHttpClients(this IServiceCollection services)
        {

            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetExportedTypes().Where(el => !el.IsAbstract && typeof(BaseHttpClient).IsAssignableFrom(el));
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type, new object[] { "https://localhost:5001/" });
                services.AddSingleton(type, instance);
            }
            
        }
    }
}
