namespace ShopingRequestSystem.Domain.ShopingRequests.Models
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.PublishedShopingRequests.Exceptions;

    public static class RequestStatusGuard
    {
        public static void ForValidStatus<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            switch (status)
            {
                case RequestStatus value when value.Equals(RequestStatus.New):
                    ForValidStatusFromNew<InvalidPublishedShopingRequestException>(newStatus, status, name);
                    break;
                case RequestStatus value when value.Equals(RequestStatus.Published):
                    ForValidStatusFromPublished<InvalidPublishedShopingRequestException>(newStatus, status, name);
                    break;
                case RequestStatus value when value.Equals(RequestStatus.InProgress):
                    ForValidStatusFromInProgress<InvalidPublishedShopingRequestException>(newStatus, status, name);
                    break;
                case RequestStatus value when value.Equals(RequestStatus.Completed):
                    ForValidStatusFromCompleted<InvalidPublishedShopingRequestException>(newStatus, status, name);
                    break;
                default:
                    break;
            }
        }

        private static void ForValidStatusFromNew<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (newStatus.Equals(RequestStatus.Published) && status.Equals(RequestStatus.New))
            {
                return;
            }

            ThrowException<TException>($"Cannot change status from \"{RequestStatus.New.Name}\" to \"{newStatus.Name}\".");
        }

        private static void ForValidStatusFromPublished<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if ((newStatus.Equals(RequestStatus.InProgress) || (newStatus.Equals(RequestStatus.New)))
                && status.Equals(RequestStatus.Published))
            {
                return;
            }

            ThrowException<TException>($"Cannot change status from \"{RequestStatus.Published.Name}\" to \"{newStatus.Name}\".");
        }

        private static void ForValidStatusFromInProgress<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (newStatus.Equals(RequestStatus.Published) && status.Equals(RequestStatus.InProgress))
            {
                return;
            }

            ThrowException<TException>($"Cannot change status from \"{RequestStatus.InProgress.Name}\" to \"{newStatus.Name}\".");
        }

        private static void ForValidStatusFromCompleted<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (newStatus.Equals(RequestStatus.InProgress) && status.Equals(RequestStatus.Completed))
            {
                return;
            }

            ThrowException<TException>($"Cannot change status from \"{RequestStatus.Completed.Name}\" to \"{newStatus.Name}\".");
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException, new()
        {
            var exception = new TException
            {
                Error = message
            };

            throw exception;
        }
    }
}
