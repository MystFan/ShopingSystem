namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Common
{
    using AutoMapper;
    using ShopingRequestSystem.Application.Common.Mapping;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class ShopingRequestOutputModel : IMapFrom<ShopingRequest>
    {
        public int Id { get; private set; }

        public virtual void Mapping(Profile profile) 
            => profile
                .CreateMap<ShopingRequest, ShopingRequestOutputModel>();
    }
}
