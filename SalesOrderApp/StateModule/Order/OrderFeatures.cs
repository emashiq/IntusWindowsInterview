using Fluxor;

[FeatureState(Name = "order")]
public class OrderState
{
    public Order Order { get; set; }
    private static OrderState GetInitialState()
    {
        return new OrderState();
    }
    public OrderState(Order order)
    {
        Order = order;
    }
    public OrderState()
    {
        Order = new();
    }
}
[FeatureState]
public class OrderListState
{
    private static OrderListState GetInitialState()
    {
        return new OrderListState();
    }
    public bool IsLoadCompleted { get; set; }
    public bool IsRequestEnd { get; set; }
    public bool IsRequestStarted { get; set; }
    public int Percentage { get; set; }
    public List<Order> Orders { get; set; }
    public OrderListState(List<Order> orders)
    {
        Orders = orders;
    }
    public OrderListState()
    {
        Orders = new();
    }
}