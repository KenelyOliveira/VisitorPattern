namespace Visitor
{
    using System.Linq;
    public class MothersDayDiscountVisitor : IMothersDayDiscountVisitor
    {
        private const decimal discount = 1.2M;
        public void Visit(IVisitorContext context)
        {
            Order order = context as Order;

            if (IsMothersDay())
            {
                order.Products.ToList().ForEach(p => p.Value *= discount);
            }
        }

        private bool IsMothersDay()
        {
            return true;
        }
    }
}
