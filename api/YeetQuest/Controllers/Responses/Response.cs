namespace YeetQuest.Controllers.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string? Message { get; set; }

        public Response() { }

        public Response(T data, string? message = null)
        {
            Data = data;
            Message = message;
        }
    }
}
