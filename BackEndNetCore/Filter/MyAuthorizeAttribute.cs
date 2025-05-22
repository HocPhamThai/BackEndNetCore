using DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BackEndNetCore.Filter
{
    public class MyAuthorizeAttribute : TypeFilterAttribute
    {
        public MyAuthorizeAttribute(string functionCode = "DEFAULT", string permission = "VIEW") : base(typeof(DemoAuthorizeActioinFilter))
        {
            Arguments = new[] { functionCode, permission };
        }
    }

    public class DemoAuthorizeActioinFilter : IAsyncAuthorizationFilter
    {
        private readonly string _functionCode;
        private readonly string _permission;
        private readonly IAccountServices _accountServices;

        public DemoAuthorizeActioinFilter(IAccountServices accountServices, string functionCode, string permission)
        {
            _functionCode = functionCode;
            _permission = permission;
            _accountServices = accountServices;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var ar = _functionCode;

            var identity = context.HttpContext.User.Identity as ClaimsIdentity; 
            if (identity != null)
            {
                var userClaims = identity.Claims;

                var userId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value != null ?
                    Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value) : 0;

                if (userId == 0) { 
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int) System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = System.Net.HttpStatusCode.Unauthorized,
                        Message = "Vui lòng đăng nhập để thực hiện chức năng này!!!"
                    });
                    return;
                }

                //check permission
                var function = await _accountServices.GetFunctionByCode(_functionCode);
                if (function == null || function.FunctionID <= 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = System.Net.HttpStatusCode.Unauthorized,
                        Message = "Chức năng không tồn tại hoặc đã bị xóa!!!"
                    });
                    return;
                }

                var userPermission = await _accountServices.GetUserPemissionByUserID(userId, function.FunctionID);

                if (userPermission == null || userPermission.UserID < 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = System.Net.HttpStatusCode.Unauthorized,
                        Message = "Bạn không có quyền thực hiện chức năng này!!!"
                    });
                    return;
                }

                switch (_permission) 
                {
                    case "VIEW":
                        if (userPermission.IsView == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                Code = System.Net.HttpStatusCode.Unauthorized,
                                Message = "Bạn không có quyền xem chức năng này!!!"
                            });
                            return;
                        }
                        break;
                    case "INSERT":
                        if (userPermission.IsInsert == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                Code = System.Net.HttpStatusCode.Unauthorized,
                                Message = "Bạn không có quyền sửa chức năng này!!!"
                            });
                            return;
                        }
                        break;
                    case "UPDATE":
                        if (userPermission.IsUpdate == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                Code = System.Net.HttpStatusCode.Unauthorized,
                                Message = "Bạn không có quyền sửa chức năng này!!!"
                            });
                            return;
                        }
                        break;
                    case "DELETE":
                        if (userPermission.IsDelete == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                Code = System.Net.HttpStatusCode.Unauthorized,
                                Message = "Bạn không có quyền xóa chức năng này!!!"
                            });
                            return;
                        }
                        break;
                    case "EXPORT":
                        if (userPermission.IsExport == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                Code = System.Net.HttpStatusCode.Unauthorized,
                                Message = "Bạn không có quyền xuất chức năng này!!!"
                            });
                            return;
                        }
                        break;  
                }
            }
        }
    }
}
