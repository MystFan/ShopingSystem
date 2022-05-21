namespace ShopingRequestSystem.Queries.PublishedShopingRequests
{
    using ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details;

    internal static class SqlQueries
    {
        private static string[] contractorColumns = new string[]
        {
            nameof(ContractorDetailsModel.Id),
            nameof(ContractorDetailsModel.Name),
            nameof(ContractorDetailsModel.UserId),
            $"{nameof(ContractorDetailsModel.PhoneNumber)}_Number AS {nameof(ContractorDetailsModel.PhoneNumber)}"
        };

        public static class Contractor
        {
            public static string GetById() => @$"
                SELECT {string.Join(",", contractorColumns)} FROM [dbo].[Contractors] 
                WHERE {nameof(ContractorDetailsModel.Id)} = @Id
            ";
        }
    }
}
