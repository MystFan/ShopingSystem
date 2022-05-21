namespace ShopingRequestSystem.Application.ShopingRequests.Commands.Requesters.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Domain.Requests.Models;
    using ShopingRequestSystem.Domain.Requests.Repositories;

    public class EditRequesterCommandHandler : IRequestHandler<EditRequesterCommand, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IRequesterDomainRepository requesterRepository;

        public EditRequesterCommandHandler(
            ICurrentUser currentUser,
            IRequesterDomainRepository requesterRepository)
        {
            this.currentUser = currentUser;
            this.requesterRepository = requesterRepository;
        }

        public async Task<Result> Handle(
            EditRequesterCommand request,
            CancellationToken cancellationToken)
        {
            Requester requester = await requesterRepository.FindByUser(
                currentUser.UserId,
                cancellationToken);

            if (request.Id != requester.Id)
            {
                return "You cannot edit this requester.";
            }

            requester.UpdatePhoneNumber(request.PhoneNumber);

            await requesterRepository.Save(requester, cancellationToken);

            return Result.Success;
        }
    }
}
