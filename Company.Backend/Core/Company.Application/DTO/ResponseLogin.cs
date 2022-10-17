namespace Company.Application.DTO
{
    public class ResponseLogin
    {
        public string Email { get; set; }

        public string RoleName { get; set; }

        public bool IsSuccessfully { get; set; }

        public string? Error { get; set; }
    }
}
