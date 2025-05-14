namespace BackEndNetCore
{
    public static class MyMiddlewareExtension
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<MyCustomMiddleware>();
            builder.UseMiddleware<MyCustomMiddleware2>();
            return builder;
        }
    }
}
