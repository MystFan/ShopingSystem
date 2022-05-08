namespace ShopingRequestSystem.Domain.ShopingRequests.Models
{
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Exceptions;

    public static class RequestStatusGuard
    {
        public static void ForValidStatus<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            switch (status)
            {
                case RequestStatus value when value.Equals(RequestStatus.Open):
                    ForValidStatusFromOpen<InvalidShopingRequestException>(newStatus, status, name);
                    break;
                case RequestStatus value when value.Equals(RequestStatus.Published):
                    ForValidStatusFromPublished<InvalidShopingRequestException>(newStatus, status, name);
                    break;
                case RequestStatus value when value.Equals(RequestStatus.InProgress):
                    ForValidStatusFromInProgress<InvalidShopingRequestException>(newStatus, status, name);
                    break;
                case RequestStatus value when value.Equals(RequestStatus.Completed):
                    ForValidStatusFromCompleted<InvalidShopingRequestException>(newStatus, status, name);
                    break;
                case RequestStatus value when value.Equals(RequestStatus.Closed):
                    ForValidStatusFromClosed<InvalidShopingRequestException>(newStatus, status, name);
                    break;
                default:
                    break;
            }
        }

        private static void ForValidStatusFromOpen<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (newStatus.Equals(RequestStatus.Published) && status.Equals(RequestStatus.Open))
            {
                return;
            }

            ThrowException<TException>($"Cannot change status from \"{RequestStatus.Open.Name}\" to \"{newStatus.Name}\".");
        }

        private static void ForValidStatusFromPublished<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if ((newStatus.Equals(RequestStatus.InProgress) || newStatus.Equals(RequestStatus.Open))
                && status.Equals(RequestStatus.Published))
            {
                return;
            }

            ThrowException<TException>($"Cannot change status from \"{RequestStatus.Published.Name}\" to \"{newStatus.Name}\".");
        }

        private static void ForValidStatusFromInProgress<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (newStatus.Equals(RequestStatus.Completed) && status.Equals(RequestStatus.InProgress))
            {
                return;
            }

            ThrowException<TException>($"Cannot change status from \"{RequestStatus.InProgress.Name}\" to \"{newStatus.Name}\".");
        }

        private static void ForValidStatusFromCompleted<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (newStatus.Equals(RequestStatus.Closed) && status.Equals(RequestStatus.Completed))
            {
                return;
            }

            ThrowException<TException>($"Cannot change status from \"{RequestStatus.Completed.Name}\" to \"{newStatus.Name}\".");
        }

        private static void ForValidStatusFromClosed<TException>(RequestStatus newStatus, RequestStatus status, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (newStatus.Equals(RequestStatus.Closed) && status.Equals(RequestStatus.Closed))
            {
                return;
            }

            ThrowException<TException>($"Cannot change status from \"{RequestStatus.Closed.Name}\" to \"{newStatus.Name}\".");
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
