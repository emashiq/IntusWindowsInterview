public class NewOrderCreateAction
{
    public Order Order { get; set; }
    public NewOrderCreateAction(Order order)
    {
        Order = order;
    }
}

public class GetOrderAction
{
    public Order Order { get; set; }
    public GetOrderAction(Order order)
    {
        Order = order;
    }
}
public class GetOrdersAction
{
    public List<Order> Orders { get; set; }
    public GetOrdersAction(List<Order> orders)
    {
        Orders = orders;
    }
}

public class OrderSaveSuccessAction
{
    public Order Order { get; set; }
    public OrderSaveSuccessAction()
    {
        Order = new();
    }
}
public class AddNewWindowAction
{
    public Window Window { get; set; }
    public AddNewWindowAction(Window window)
    {
        Window = window;
    }
}

public class AddNewSubElementAction
{
    public SubElement SubElement { get; set; }
    public int Index { get; set; }
    public AddNewSubElementAction(SubElement subElement, int index)
    {
        SubElement = subElement;
        Index = index;
    }
}

public class RemoveWindowAction
{
    public Window Window { get; set; }
    public RemoveWindowAction(Window window)
    {
        Window = window;
    }
}

public class RemoveSubElementAction
{
    public SubElement SubElement { get; set; }
    public int WindowIndex { get; set; }
    public RemoveSubElementAction(int windowIndex, SubElement subElement)
    {
        SubElement = subElement;
        WindowIndex = windowIndex;
    }
}