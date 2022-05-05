namespace ShopingRequestSystem.Application.ShopingRequests.Requesters.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Common.Contracts;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;
    using ShopingRequestSystem.Domain.ShopingRequests.Repositories;

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
            Requester requester = await this.requesterRepository.FindByUser(
                this.currentUser.UserId,
                cancellationToken);

            if (request.Id != requester.Id)
            {
                return "You cannot edit this requester.";
            }

            requester.UpdatePhoneNumber(request.PhoneNumber);

            await this.requesterRepository.Save(requester, cancellationToken);

            return Result.Success;
        }
    }
}
