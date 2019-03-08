using System;
using System.Linq;
using System.Reflection;
using StarterTemplate.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using StarterTemplate.Settings;

namespace StarterTemplate
{
    public static class StartupExtensions
    {
        private const string BaseNameSpace = "StarterTemplate";
        
        public static void AutoDiscover(IServiceCollection services, IConfiguration configuration)
        {
            SetupRepositories(services);
            SetupServices(services);
            SetupSettingsModels(services, configuration);
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
                if (service.GetInterfaces().Contains(typeof(ITransientServiceInterface)))
                {
                    Type mainInterface = service.GetInterfaces()
                    .Where(t => t.AssemblyQualifiedName != typeof(ITransientServiceInterface).AssemblyQualifiedName).First();

                    services.AddTransient(mainInterface, service);
                }
                else if (service.GetInterfaces().Count() == 0)
                {
                    services.AddScoped(service);
                }
            }
        }

        private static void SetupRepositories(IServiceCollection services)
        {
            IEnumerable<Type> allRepositories = Assembly.GetEntryAssembly().GetTypes().
                                Where(r => r.GetTypeInfo().IsClass &&
                                        r.Namespace != null &&
                                        r.Namespace.Contains($"{BaseNameSpace}.Repository") &&
                                        r.Name.EndsWith("Repository"));

            foreach (Type repository in allRepositories)
            {
                if (repository.GetInterfaces().Contains(typeof(ITransientServiceInterface)))
                {
                    Type mainInterface = repository.GetInterfaces()
                        .Where(t => t.AssemblyQualifiedName != typeof(ITransientServiceInterface).AssemblyQualifiedName)
                        .Where(i => !i.Name.Contains("IRepositoryBase"))
                        .First();

                    services.AddTransient(mainInterface, repository);
                }
                else if (repository.GetInterfaces().Count() == 0)
                {
                    services.AddScoped(repository);
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