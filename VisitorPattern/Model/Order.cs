using System;
using System.Linq;
using System.Collections.Generic;

namespace VisitorPattern
{
    public class Order : IVisitorContext
    {
        public Order(IEnumerable<Product> products)
        {
            Id = Guid.NewGuid();
            this.Products = products;
        }

        public Guid Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            var products = string.Join(Environment.NewLine, Products.Select(p => p.ToString()));

            return  $"Order Id...: {Id} {Environment.NewLine}" +
                    $"Products...: {Environment.NewLine}{products}{Environment.NewLine}" +
                    $"Status.....: {OrderStatus}{Environment.NewLine}" +
                    $"Total......: {Products.Sum(p => p.Value)}";
        }
    }
}
