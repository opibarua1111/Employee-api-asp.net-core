namespace Employee_Info.api.Request
{
    public class EmployeeQueryParameters : QueryParameters
    {
        public decimal? MinAge { get; set; }
        public decimal? MaxAge { get; set; }

        public string? Designation { get; set; } = string.Empty;
        public string? SearchName { get; set; } = string.Empty;
    }
}
