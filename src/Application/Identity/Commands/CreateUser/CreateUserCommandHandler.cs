namespace ShopingRequestSystem.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Domain.Identity.Repositories;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Factories.Requesters;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Models;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Repositories;
    using ShopingRequestSystem.Domain.ShopingRequests.Factories.Requesters;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Repositories;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IIdentityService identity;
        private readonly IRequesterDomainRepository requesterRepository;
        private readonly IContractorDomainRepository contractorRepository;
        private readonly IUserDomainRepository userRepository;
        private readonly IRequesterFactory requesterFactory;
        private readonly IContractorFactory contractorFactory;

        public CreateUserCommandHandler(
            IIdentityService identity, 
            IRequesterDomainRepository requesterRepository,
            IContractorDomainRepository contractorRepository,
            IUserDomainRepository userRepository,
            IRequesterFactory requesterFactory,
            IContractorFactory contractorFactory)
        {
            this.identity = identity;
            this.requesterRepository = requesterRepository;
            this.contractorRepository = contractorRepository;
            this.userRepository = userRepository;
            this.requesterFactory = requesterFactory;
            this.contractorFactory = contractorFactory;
        }

        public async Task<Result> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await this.identity.Register(request);

            if (!result.Succeeded)
            {
                return result;
            }

            string userId = await this.userRepository.GetUserId(request.Email, cancellationToken);

            Requester requester = this.requesterFactory
                .WithUserId(userId)
                .WithName(request.Name)
                .WithPhoneNumber(request.PhoneNumber)
                .Build();

            Contractor contractor = this.contractorFactory
                .WithUserId(userId)
                .WithName(request.Name)
                .WithPhoneNumber(request.PhoneNumber)
                .Build();

            await this.requesterRepository.Save(requester, cancellationToken);
            await this.contractorRepository.Save(contractor, cancellationToken);

            return result;
        }
    }
}