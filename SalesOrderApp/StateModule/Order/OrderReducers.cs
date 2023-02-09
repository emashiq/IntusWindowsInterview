using Fluxor;

public static class OrderReducer
{
    [ReducerMethod]
    public static OrderState ReduceNewOrderCreateAction(OrderState payload, NewOrderCreateAction action)
    {
        return new OrderState();
    }

    [ReducerMethod]
    public static OrderState ReduceEditOrderToShow(OrderState payload, NewOrderCreateAction action)
    {
        return new OrderState(action.Order);
    }
    [ReducerMethod]
    public static OrderState ReduceAddWindowsToOrder(OrderState payload, AddNewWindowAction action)
    {
        payload.Order.Windows.Insert(0, action.Window);
        return payload;
    }
    [ReducerMethod]
    public static OrderState ReduceAddSubElementToWindow(OrderState state, AddNewSubElementAction action)
    {
        state.Order.Windows[action.Index].SubElements.Add(action.SubElement);
        return state;
    }

    [ReducerMethod]
    public static OrderState ReduceRemoveSubElementFromWindow(OrderState state, RemoveSubElementAction action)
    {
        state.Order.Windows[action.WindowIndex].SubElements.Remove(action.SubElement);
        return state;
    }

    [ReducerMethod]
    public static OrderState ReduceRemoveWindowFromOrder(OrderState state, RemoveWindowAction action)
    {
        state.Order.Windows.Remove(action.Window);
        return state;
    }
    [ReducerMethod]
    public static OrderState ReduceOrderSaveSucces(OrderState state, OrderSaveSuccessAction action)
    {
        state = new OrderState(action.Order);
        return state;
    }
    [ReducerMethod]
    public static OrderState ReduceEditOrder(OrderState state, GetOrderAction action)
    {
        state.Order = action.Order;
        return state;
    }

    [ReducerMethod]
    public static OrderListState ReduceGetOrders(OrderListState state, GetOrdersAction action)
    {
        state.Orders = action.Orders;
        return state;
    }
}