namespace VisitorPattern
{
    public class DoSomethingElseVisitor : IDoSomethingElseVisitor
    {
        public void Visit(IVisitorContext context)
        {
            (context as Order).OrderStatus = OrderStatus.AwaitingPayment;
        }
    }
}
