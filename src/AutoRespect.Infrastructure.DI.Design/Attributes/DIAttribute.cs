using System;

namespace AutoRespect.Infrastructure.DI.Design.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DIAttribute : Attribute
    {
        public readonly LifeCycle LifeCycle;

        public DIAttribute(LifeCycle lifeCycle) => this.LifeCycle = lifeCycle;
    }
}
