namespace BackEndNetCore
{
    public class MyCustomMiddleware2
    {
        private RequestDelegate _next;
        public MyCustomMiddleware2(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Append("Device", "PC");
            return _next(context);
        }
    }
}
