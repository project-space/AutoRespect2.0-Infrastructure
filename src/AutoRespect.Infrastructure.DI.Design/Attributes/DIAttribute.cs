using System;

namespace AutoRespect.Infrastructure.DI.Design.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DIAttribute : Attribute
    {
        public readonly LifeCycleType lifeCycle;

        public DIAttribute(LifeCycleType lifeCycle) => this.lifeCycle = lifeCycle;
    }
}
