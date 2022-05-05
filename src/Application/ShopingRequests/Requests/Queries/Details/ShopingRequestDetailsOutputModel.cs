namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Details
{
    using AutoMapper;
    using ShopingRequestSystem.Application.ShopingRequests.Requesters.Queries.Common;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Common;
    using ShopingRequestSystem.Domain.Common.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class ShopingRequestDetailsOutputModel : ShopingRequestOutputModel
    {
        public string RequestId { get; private set; } = default!;

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public string DeliveryAddress { get; private set; } = default!;

        public decimal PaymentSum { get; private set; }

        public string Status { get; private set; } = default!;

        public RequesterOutputModel Requester { get; set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<ShopingRequest, ShopingRequestDetailsOutputModel>()
                .IncludeBase<ShopingRequest, ShopingRequestOutputModel>()
                .ForMember(sr => sr.Status, cfg => cfg
                    .MapFrom(c => Enumeration.NameFromValue<RequestStatus>(
                        c.Status.Value)));
    }
}
