namespace ShopingRequestSystem.Application.PublishedShopingRequests.Contractors.Queries.Details
{
    using AutoMapper;
    using ShopingRequestSystem.Application.PublishedShopingRequests.Contractors.Queries.Common;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;

    public class ContractorDetailsOutputModel : ContractorOutputModel
    {
        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Contractor, ContractorDetailsOutputModel>()
                .IncludeBase<Contractor, ContractorOutputModel>();
    }
}
