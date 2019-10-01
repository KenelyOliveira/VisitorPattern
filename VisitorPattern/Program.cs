using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace VisitorPattern
{
    static class Program
    {
        private static IVisitorContext order;
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            RegisterDependencies();

            Log("Creating Order...");
            order =
                new Order(new List<Product>
                {
                    new Product(Guid.NewGuid(), "Book", 12.0M),
                    new Product(Guid.NewGuid(), "Record", 7.0M)
                });
            Log(order.ToString());
            Log("Applying visitors");

            VisitorEngine.Run(serviceProvider, order);

            Log(order.ToString());
            Console.ReadLine();
        }

        private static void Log(string message) => Console.WriteLine($"{message}{Environment.NewLine}");

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
    }

    public static class VisitorEngine
    {
        public static void Run(IServiceProvider serviceProvider, IVisitorContext order)
        {
            var visitors = serviceProvider.GetServices<IVisitor>();
            foreach (var visitor in visitors)
            {
                order.Accept(visitor);
            }
        }
    }
}
