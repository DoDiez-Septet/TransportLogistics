namespace TransportLogistics.Domain.Enums.Orders;

public enum OrderStatus
{
    Received = 1,
    Confirmed = 2,
    Loading = 3,
    Loaded = 4,
    Delivering = 5,
    Delivered = 6,
    WaitingForConsumer = 7,
    Closed = 8
}