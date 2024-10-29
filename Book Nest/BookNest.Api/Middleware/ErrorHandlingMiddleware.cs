using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Serilog;

namespace BookNest.Api.Middleware // تأكد من تعديل الـ namespace حسب الهيكل الخاص بك
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // استدعاء الـ middleware التالي
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unexpected error occurred."); // تسجيل الخطأ باستخدام Serilog

                // إرجاع استجابة موحدة للعميل
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("An unexpected error occurred.");
            }
        }
    }
}
