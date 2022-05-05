namespace ShopingRequestSystem.Application.ShopingRequests.Requesters.Queries.Details
{
    using AutoMapper;
    using ShopingRequestSystem.Application.ShopingRequests.Requesters.Queries.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class RequesterDetailsOutputModel : RequesterOutputModel
    {
        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Requester, RequesterDetailsOutputModel>()
                .IncludeBase<Requester, RequesterOutputModel>();
    }
}
