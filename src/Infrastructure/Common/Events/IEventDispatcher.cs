namespace ShopingRequestSystem.Infrastructure.Common.Events
{
    using ShopingRequestSystem.Domain.Common;
    using System.Threading.Tasks;

    internal interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
