namespace Acme.DemoServer.Processing.Api.Common;

public static class DemoObjectControllerConstants
{
    public const string Route = "api/v1/demoobject";

    public static class MethodCreate
    {
        public const string Name = "create";
        public const string UrlSuffix = Route + "/" + Name;
    }

    public static class MethodUpdate
    {
        public const string Name = "update";
        public const string UrlSuffix = Route + "/" + Name;
    }

    public static class MethodRead
    {
        public const string Name = "read";
        public const string UrlSuffix = Route + "/" + Name;

        public static class Arguments
        {
            public const string Id = "id";
        }
    }
}
