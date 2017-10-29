using System;
using System.Reflection;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using StructureMap.Pipeline;

namespace AutoRespect.Infrastructure.DI
{
    internal class DIAttributeConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.AllTypes())
            {
                var contract = type.GetInterface($"I{type.Name}");
                var diAttribute = type.GetCustomAttribute<DIAttribute>();

                var cantBeInjected =
                    contract == null ||
                    diAttribute == null ||
                    type.IsAbstract ||
                    !type.IsClass;

                if (cantBeInjected)
                    continue;

                registry
                    .For(contract)
                    .Add(type)
                    .SetLifecycleTo(GetLifecycleByDIAttribute(diAttribute));
            }
        }

        private LifecycleBase GetLifecycleByDIAttribute (DIAttribute attribute)
        {
            switch (attribute.lifeCycle)
            {
                case LifeCycleType.Singleton:
                    return new SingletonLifecycle();
                case LifeCycleType.Scope:
                    return new UniquePerRequestLifecycle();
                case LifeCycleType.Transient:
                    return new TransientLifecycle();
                default:
                    throw new Exception("UNSUPPORTED LIFECYCLE TYPE");
            }
        }
    }
}
