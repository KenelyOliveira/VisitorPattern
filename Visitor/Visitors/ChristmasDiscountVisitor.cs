using System;

namespace Visitor
{
    public class ChristmasDiscountVisitor : IChristmasDiscountVisitor
    {
        private const decimal shipping_tax = .87M;
        public void Visit(IVisitorContext context)
        {
            if (IsChristmas())
            {
                (context as Product).Value *= shipping_tax;
            }
        }

        private bool IsChristmas()
        {
            if (DateTime.Now.Month == 12 && DateTime.Now.Day > 10)
            {
                return true;
            }

            return false;
        }
    }
}
