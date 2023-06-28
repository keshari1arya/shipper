namespace shipper_api.DTO
{
    public class Quote
    {
        public string _Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public List<string> Tags { get; set; }
        public string AuthorSlug { get; set; }
        public int Length { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class PaginatedQuoteResponse
    {
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int LastItemIndex { get; set; }
        public List<Quote> Results { get; set; }
    }
}
