namespace Visitor
{
    public interface IVisitorContext
    {
        void Accept(IVisitor visitor);
    }
}
