

namespace Demo.Infra.Helpers
{
    public class AppUserParams : PaginationParams
    {
        public string OrderBy { get; set; } = "dataCreated";
    }
}
