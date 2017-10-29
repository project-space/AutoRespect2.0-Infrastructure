using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace AutoRespect.Infrastructure.DI
{

    public static class DIAttributeInstaller
    {
        public static IServiceProvider Install (
            IServiceCollection services,
            Func<Assembly, bool> assemblyFilter = null)
        {
            var container = new Container();
            container.Configure(c =>
            {
                Func<Assembly, bool> defaultAssemblyFilter = 
                    (assembly) => assembly.FullName.StartsWith("AutoRespect");


                c.Scan((scanner) => {
                    scanner.Convention<DIAttributeConvention>();
                    scanner.AssembliesFromPath(
                        AppDomain.CurrentDomain.BaseDirectory,
                        (assemblyFilter ?? defaultAssemblyFilter));
                });

                c.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }
    }
}
