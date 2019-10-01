namespace VisitorPattern
{
    public interface IChristmasDiscountVisitor : IVisitor
    {
    }

    public interface IVisitor
    {
        void Visit(IVisitorContext context);
    }
}
