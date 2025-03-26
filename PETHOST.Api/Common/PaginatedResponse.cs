namespace PETHOST.Api.Common
{
    public class PaginatedResponse<T> : ApiResponseWithData<IEnumerable<T>>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
