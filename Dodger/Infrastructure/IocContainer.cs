using System;
using Autofac;
using Dodger.Handlers;

namespace Dodger.Infrastructure
{
    public static class IocContainer
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            var container = builder.Build();

            return container;
        }
    }
}