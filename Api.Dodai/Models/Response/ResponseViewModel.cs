namespace Api.Dodai.Models.Response
{
    public record StatusResponseViewModel
    {
        public int Code { get; set; }
        public string? Message { get; set; }
    }
    public record ResponseViewModel
    {
        public object? Data { get; set; }
        public StatusResponseViewModel? Status { get; set; }

    };
}
