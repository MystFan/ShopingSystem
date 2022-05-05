namespace ShopingRequestSystem.Domain.PublishedShopingRequests.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int Zero = 0;
        }

        public class PublishedShopingRequest
        {
            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 2000;
        }

        public class Contractor
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
        }
    }
}
