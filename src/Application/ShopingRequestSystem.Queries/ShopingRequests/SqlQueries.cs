namespace ShopingRequestSystem.Queries.ShopingRequests
{
    using System.Linq;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Search;

    internal static class SqlQueries
    {
        private static string[] requestColumns = new string[]
        {
            nameof(ShopingRequestDetailsModel.Id),
            nameof(ShopingRequestDetailsModel.RequestId),
            nameof(ShopingRequestDetailsModel.RequesterId),
            nameof(ShopingRequestDetailsModel.Name),
            nameof(ShopingRequestDetailsModel.Description),
            nameof(ShopingRequestDetailsModel.DeliveryAddress),
            nameof(ShopingRequestDetailsModel.PaymentSum),
            $"{nameof(ShopingRequestDetailsModel.Status)}_Value AS {nameof(ShopingRequestDetailsModel.Status)}"
        };

        private static string[] requesterColumns = new string[]
        {
            nameof(RequesterDetailsModel.Id),
            nameof(RequesterDetailsModel.Name),
            nameof(RequesterDetailsModel.UserId),
            $"{nameof(RequesterDetailsModel.PhoneNumber)}_Number AS {nameof(RequesterDetailsModel.PhoneNumber)}"
        };

        private static string[] requesterSearchColumns = new string[]
        {
            $"{nameof(RequesterDetailsModel.Id)} AS {nameof(ShopingRequestModel.RequesterId)}",
            $"{nameof(RequesterDetailsModel.Name)} AS {nameof(ShopingRequestModel.RequesterName)}",
            nameof(RequesterDetailsModel.UserId),
            $"{nameof(RequesterDetailsModel.PhoneNumber)}_Number AS {nameof(ShopingRequestModel.RequesterPhoneNumber)}"
        };

        public static class ShopingRequest
        {
            public static string All() => @$"
                SELECT {string.Join(",", requestColumns)} FROM [dbo].[ShopingRequests]
            ";

            public static string GetById() => @$"
                SELECT {string.Join(",", requestColumns)} FROM [dbo].[ShopingRequests] 
                WHERE {nameof(ShopingRequestDetailsModel.Id)} = @Id
            ";

            public static string Paged(string filter, string sortBy, string order) 
            {
                filter = !string.IsNullOrWhiteSpace(filter) ? $"WHERE {filter}" : string.Empty;
                sortBy = !string.IsNullOrWhiteSpace(sortBy) ? $"ORDER BY r.{sortBy}" : string.Empty;
                order = !string.IsNullOrWhiteSpace(order) ? order : string.Empty;

                string query = @$"SELECT {string.Join(",", requestColumns.Select(c => $"sr.{c}"))},
                       {string.Join(",", requesterSearchColumns.Select(c => $"r.{c}"))} 
                    FROM [dbo].[ShopingRequests] sr
                    JOIN [dbo].[Requesters] r ON sr.[RequesterId] = r.[Id] 
                    {filter} 
                    {sortBy} {order}
                    OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
                ";

                return query;
            }

            public static string Count(string filter)
            {
                filter = !string.IsNullOrWhiteSpace(filter) ? $"WHERE {filter}" : string.Empty;

                string query = @$"SELECT COUNT(*)
                    FROM [dbo].[ShopingRequests] sr
                    JOIN [dbo].[Requesters] r ON sr.[RequesterId] = r.[Id] 
                    {filter} 
                ";

                return query;
            }
        }

        public static class Requester
        {
            public static string GetById() => @$"
                SELECT {string.Join(",", requesterColumns)} FROM [dbo].[Requesters] 
                WHERE {nameof(RequesterDetailsModel.Id)} = @Id
            ";
        }
    }
}
