namespace ApiLogin.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public required string Message { get; set; }
    }
}
