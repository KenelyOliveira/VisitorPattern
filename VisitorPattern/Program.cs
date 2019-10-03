using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace VisitorPattern
{
    public static class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            RegisterDependencies();
            RunVisitors();
           
            Console.ReadLine();
        }

        private static void RegisterDependencies()
        {
            serviceProvider = new ServiceCollection()
                .AddSingleton<IChristmasDiscountVisitor, ChristmasDiscountVisitor>()
                .AddSingleton<IMothersDayDiscountVisitor, MothersDayDiscountVisitor>()
                .AddSingleton<IDoSomethingElseVisitor, DoSomethingElseVisitor>()
                .AddSingleton<IVisitor>(s => s.GetRequiredService<IChristmasDiscountVisitor>())
                .AddSingleton<IVisitor>(s => s.GetRequiredService<IMothersDayDiscountVisitor>())
                .AddSingleton<IVisitor>(s => s.GetRequiredService<IDoSomethingElseVisitor>())
                .BuildServiceProvider();
        }

        public static void RunVisitors()
        {
            IVisitorContext order =
                new Order(new List<Product>
                {
                    new Product(Guid.NewGuid(), "Book", 12.0M),
                    new Product(Guid.NewGuid(), "Record", 7.0M)
                });

            VisitorEngine.Run(serviceProvider, order);
        }
    }

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


    public class TestClass
    {
        [Fact]
        public void Test()
        {
            Program.RunVisitors();


        }
    }
}
