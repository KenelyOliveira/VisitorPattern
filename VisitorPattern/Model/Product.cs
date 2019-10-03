using System;

namespace VisitorPattern
{
    public class Product : IVisitorContext
    {
        public Product(Guid id, string description, decimal value)
        {
            Id = id;
            Description = description;
            Value = value;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal  Value { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return $"Id: {Id} - Description: {Description} - Value: {Value}";
        }
    }
}
