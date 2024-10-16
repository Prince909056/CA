namespace CleanArchitecture.WebAPI
{
    public class ApiRoutes
    {
        public const string BaseRoutes = "api/v{v:apiVersion}/[controller]/[action]";
        public class UserProfiles
        {
            public const string IdRoutes = "{id}";
        }

        public class Post
        {
            public const string IdRoutes = "{id}";
        }
    }
}
