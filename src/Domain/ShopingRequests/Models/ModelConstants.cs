namespace ShopingRequestSystem.Domain.ShopingRequests.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int Zero = 0;
            public const int MinAddressLength = 2;
            public const int MaxAddressLength = 500;
        }

        public class ShopingRequest
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 200;
            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 2000;
        }

        public class ShopingItem
        {
            public const int MinProductLength = 2;
            public const int MaxProductLength = 500;
            public const int MinUnitLength = 1;
            public const int MaxUnitLength = 100;
        }

        public class Requester
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
        }
    }
}
