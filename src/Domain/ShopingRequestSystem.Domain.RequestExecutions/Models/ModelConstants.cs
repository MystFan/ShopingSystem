namespace ShopingRequestSystem.Domain.RequestExecutions.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int Zero = 0;
        }

        public class RequestExecution
        {
            public const int MaxNotesLength = 2000;
        }

        public class Transport
        {
            public const int MinNameLength = 20;
            public const int MaxNameLength = 1000;
        }

        public class TransportType
        {
            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 1000;
            public const int MinNameLength = 2;
            public const int MaxNameLength = 100;
        }

        public class ShopingRequest
        {
            public const int MinRequestIdLength = 36;
            public const int MaxRequestIdLength = 36;
        }
    }
}
