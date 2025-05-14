namespace BackEndNetCore
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        public MyCustomMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Append("Hacker_By", "HocLord");
            return _next(context);
        }
    }
}
