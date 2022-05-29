namespace ShopingRequestSystem.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Identity.Commands;
    using ShopingRequestSystem.Domain.Identity.Repositories;
    using ShopingRequestSystem.Domain.PublishedRequests.Factories.Contractors;
    using ShopingRequestSystem.Domain.PublishedRequests.Models;
    using ShopingRequestSystem.Domain.PublishedRequests.Repositories;
    using ShopingRequestSystem.Domain.Requests.Factories.Requesters;
    using ShopingRequestSystem.Domain.Requests.Models;
    using ShopingRequestSystem.Domain.Requests.Repositories;

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
            var result = await identity.Register(new UserInputModel(request.Email, request.Password));

            if (!result.Succeeded)
            {
                return result;
            }

            string userId = await userRepository.GetUserId(request.Email, cancellationToken);

            Requester requester = requesterFactory
                .WithUserId(userId)
                .WithName(request.Name)
                .WithPhoneNumber(request.PhoneNumber)
                .Build();

            Contractor contractor = contractorFactory
                .WithUserId(userId)
                .WithName(request.Name)
                .WithPhoneNumber(request.PhoneNumber)
                .Build();

            await requesterRepository.Save(requester, cancellationToken);
            await contractorRepository.Save(contractor, cancellationToken);

            return result;
        }
    }
}