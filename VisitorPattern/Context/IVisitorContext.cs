namespace VisitorPattern
{
    public interface IVisitorContext
    {
        void Accept(IVisitor visitor);
    }
}
