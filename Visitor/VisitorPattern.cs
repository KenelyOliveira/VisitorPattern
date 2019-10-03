using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Visitor
{
    public class VisitorPattern
    {
        public IServiceProvider serviceProvider;
        public IVisitorContext order => new Order(new List<Product>
                {
                    new Product(Guid.NewGuid(), "Book", 12.0M),
                    new Product(Guid.NewGuid(), "Record", 7.0M)
                });

        private void RegisterDependencies()
        {
            serviceProvider = new ServiceCollection()
                .BuildServiceProvider();
        }

        public void RunVisitors()
        {
            RegisterDependencies();

            VisitorEngine.Run(serviceProvider, order);
        }
    }
}
