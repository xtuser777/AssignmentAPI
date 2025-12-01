namespace Assignment.Api.Responses;

public class FindManyResponse<T>
{
    public IEnumerable<T> Data { get; set; } = [];
    public PaginationResponse? Pagination { get; set; }
}