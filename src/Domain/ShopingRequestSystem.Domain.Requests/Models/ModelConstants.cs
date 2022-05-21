namespace ShopingRequestSystem.Domain.Requests.Models
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
            public const int MinRequestIdLength = 36;
            public const int MaxRequestIdLength = 36;
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

        public class PhoneNumber
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";
        }
    }
}
