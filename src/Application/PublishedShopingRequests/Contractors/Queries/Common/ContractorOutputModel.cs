namespace ShopingRequestSystem.Application.PublishedShopingRequests.Contractors.Queries.Common
{
    using AutoMapper;
    using ShopingRequestSystem.Application.Common.Mapping;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;

    public class ContractorOutputModel : IMapFrom<Contractor>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string PhoneNumber { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Contractor, ContractorOutputModel>()
                .ForMember(r => r.PhoneNumber, cfg => cfg
                    .MapFrom(r => r.PhoneNumber.Number));
    }
}
