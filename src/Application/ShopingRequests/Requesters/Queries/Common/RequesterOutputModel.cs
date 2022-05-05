namespace ShopingRequestSystem.Application.ShopingRequests.Requesters.Queries.Common
{
    using Application.Common.Mapping;
    using AutoMapper;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class RequesterOutputModel : IMapFrom<Requester>
    {
        public int Id { get; private set; }

        public string UserId { get; private set; }

        public string Name { get; private set; } = default!;

        public string PhoneNumber { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Requester, RequesterOutputModel>()
                .ForMember(r => r.PhoneNumber, cfg => cfg
                    .MapFrom(r => r.PhoneNumber.Number));
    }
}
