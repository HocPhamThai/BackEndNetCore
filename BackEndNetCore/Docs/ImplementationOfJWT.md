#### B1: Client gữi token lên server (thông qua field authorization) hoặc đưa token vào Bearer ```yourtoken```
#### B2: Server check token -> định danh là ai?
 B2.1: Tạo class attribute và kế thừa class TypeFilterAttribute  

 B2.2: Tạo class AuthorizeAction filter implement IAsyncAuthorizationFilter
 
 B2.3: Trong hàm khởi tạo class attribute ở bước 2.1 thì gọi đến class AuthorizeActionFilter ở bước 2.2

 B2.4: 
- Trong hàm override onAuthorizationAsync của interface IAsyncAuthorizationFilter
- Lấy ra HttpContext.User.Identity
* Từ identity lấy ra claims  
	* Claims có thông tin -> người dùng có truyền lên token
	* Claims không có thông tin -> không truyền token

Dùng AttributeFilter
Từ Claims lấy ra claim ClaimTypes (theo ClaimTypes tạo ở hàm login)