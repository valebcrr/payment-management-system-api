namespace PaymentManagementSystem.DTOs
{
    public class PagedResultDto<T>
    {
        public int TotalItems { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Items { get; set; } = new List<T>();
    }
}
