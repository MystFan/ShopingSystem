namespace ShopingRequestSystem.Application.Common
{
    using ShopingRequestSystem.Domain.Common;
    using System.Threading.Tasks;

    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
