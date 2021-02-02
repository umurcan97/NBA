namespace NBA.Web.Models.Api
{
    public class ApiResult
    {
        public bool succeeded { get; set; }
        public ApiError error { get; set; }
    }

    public class ApiResult<T> : ApiResult
    {
        public T data { get; set; }
    }

    public class ApiError
    {
        public string message { get; set; }
        public int code { get; set; }
    }
}