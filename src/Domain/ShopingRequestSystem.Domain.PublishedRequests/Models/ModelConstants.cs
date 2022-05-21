namespace ShopingRequestSystem.Domain.PublishedRequests.Models
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

        public class PhoneNumber
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";
        }
    }
}
