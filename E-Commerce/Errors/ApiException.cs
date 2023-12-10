namespace E_Commerce.Errors
{
    public class ApiException:ApiResponse
    {
        public ApiException(int stausCode,string message=null,string details=null):base(stausCode,message)
        {
           
            _details = details;
        }
       
        public string _details { get; set; }
    }
}
