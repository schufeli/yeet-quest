namespace YeetQuest.Controllers.Filters
{
    public class PaginationFilter
    {
        public int Start { get; set; }
        public int Limit { get; set; }

        public PaginationFilter()
        {
            this.Start = 1;
            this.Limit = 20;
        }

        public PaginationFilter(int start, int limit)
        {
            this.Start = start < 1 ? 1 : start;
            this.Limit = limit > 20 ? 20 : limit;
        }
    }
}
