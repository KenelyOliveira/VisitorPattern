// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MothersDayDiscountVisitor.cs" company="Farfetch">
//   Copyright (c) Farfetch. All rights reserved.
// </copyright>
// <summary>
// MothersDayDiscountVisitor
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VisitorPattern
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
