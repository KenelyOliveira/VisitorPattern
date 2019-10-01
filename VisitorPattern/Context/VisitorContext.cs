namespace VisitorPattern
{
    public abstract class VisitorContext : IVisitorContext
    {
        public abstract void Accept(IVisitor visitor);
    }
}
