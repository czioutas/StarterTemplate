using System;
using System.Linq;
using System.Reflection;
using StarterTemplate.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using StarterTemplate.Settings;
using StarterTemplate.Repositories.Contracts;

namespace StarterTemplate
{
    public static class StartupExtensions
    {
        private const string BaseNameSpace = "StarterTemplate";
        
        public static void AutoDiscover(IServiceCollection services, IConfiguration configuration)
        {
            SetupAPIs(services);
            SetupRepositories(services);
            SetupServices(services);
            SetupSettingsModels(services, configuration);
        }

        private static void SetupAPIs(IServiceCollection services)
        {
            IEnumerable<Type> allApi = Assembly.GetEntryAssembly().GetTypes().
                                Where(a => a.GetTypeInfo().IsClass &&
                                        a.Namespace != null &&
                                        a.Namespace.Contains($"{BaseNameSpace}.APIs") &&
                                        a.Name.EndsWith("APIClient"));

            foreach (Type apiClient in allApi)
            {
                Type mainInterface = apiClient.GetInterfaces().First();

                services.AddScoped(mainInterface, apiClient);
            }
        }

        private static void SetupServices(IServiceCollection services)
        {
            IEnumerable<Type> allServices = Assembly.GetEntryAssembly().GetTypes().
                                Where(s => s.GetTypeInfo().IsClass &&
                                        s.Namespace != null &&
                                        s.Namespace.Contains($"{BaseNameSpace}.Services") &&
                                        s.Name.EndsWith("Service"));

            foreach (Type service in allServices)
            {
                Type mainInterface = service.GetInterfaces()
                    .Where(t => t.AssemblyQualifiedName != typeof(ITransientServiceInterface).AssemblyQualifiedName)
                    .First();

                if (service.GetInterfaces().Contains(typeof(ITransientServiceInterface)))
                {
                    services.AddTransient(mainInterface, service);
                }
                else
                {
                    services.AddScoped(mainInterface, service);
                }
            }
        }

        private static void SetupRepositories(IServiceCollection services)
        {
            IEnumerable<Type> allRepositores = Assembly.GetEntryAssembly().GetTypes()
                .Where(a => a.GetTypeInfo().IsClass &&
                    a.Namespace != null &&
                    a.Namespace.Contains($"{BaseNameSpace}.Repositories") &&
                    a.Name.EndsWith("Repository")
                );

            foreach (Type repository in allRepositores)
            {
                Type mainInterface = repository.GetInterfaces().Where(i => !i.Name.Contains("IBaseRepository")).First();
                
                if (repository.GetInterfaces().Contains(typeof(ITransientRepositoryInterface)))
                {
                    services.AddTransient(mainInterface, repository);
                }
                else
                {
                    services.AddScoped(mainInterface, repository);
                }
            }
        }

        private static void SetupSettingsModels(IServiceCollection services, IConfiguration configuration)
        {
            IEnumerable<Type> allSettings = Assembly.GetEntryAssembly().GetTypes().
                    Where(s => s.GetTypeInfo().IsClass &&
                            s.Namespace != null &&
                            s.Namespace.Contains($"{BaseNameSpace}.Settings") &&
                            s.Name.EndsWith("Settings"));

            // How do we correctly set the type?
            //foreach(Type setting in allSettings)
            //{   
            //    services.Configure<setting>(configuration.GetSection(setting.Name));
            //}

            services.Configure<HeartBeatSettings>(configuration.GetSection(nameof(HeartBeatSettings)));
        }
    }
}