namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Common
{
    using ShopingRequestSystem.Application.Common;

    public abstract class ShopingRequestCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string RequestId { get; set; } = default!;

        public string RequesterId { get; set; } = default!;

        public string DeliveryAddress { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal PaymentSum { get; set; }
    }
}
