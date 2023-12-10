using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Net.NetworkInformation;

namespace E_Commerce.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int _statusCode,string _message=null)
        {
            statusCode = _statusCode;
            message = _message ?? GetDefultMessageForStausCode(statusCode);
        }
        public int statusCode { get; set; } 
        public string message { get; set; }
        private string  GetDefultMessageForStausCode(int statusCode)
        {
            return statusCode switch
            {
                400=>"A badRequest , you have made",
                401=>"You are not Authorize",
                404=>"Response not found",
                500=>"Server Error Occor",
                _=> null
            };
        }
    }
}
