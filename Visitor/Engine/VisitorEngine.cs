using System;
using Microsoft.Extensions.DependencyInjection;

namespace Visitor
{
    public static class VisitorEngine
    {
        public static void Run(IServiceProvider serviceProvider, IVisitorContext context)
        {
            var visitors = serviceProvider.GetServices<IVisitor>();
            foreach (var visitor in visitors)
            {
                context.Accept(visitor);
            }
        }
    }
}
