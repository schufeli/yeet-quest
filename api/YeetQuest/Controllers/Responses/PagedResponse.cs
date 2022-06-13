namespace YeetQuest.Controllers.Responses
{
    public class PagedResponse<T> : Response<T>
    {
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public int? TotalRecords { get; set; }
        public int? Count { get; set; }

        public PagedResponse(T data, int? start = null, int? limit = null, int? totalRecords = null, int? count = null, string? message = null)
        {
            Data = data;
            Start = start;
            Limit = limit;
            Message = message;
            TotalRecords = totalRecords;
            Count = count;
        }
    }
}
