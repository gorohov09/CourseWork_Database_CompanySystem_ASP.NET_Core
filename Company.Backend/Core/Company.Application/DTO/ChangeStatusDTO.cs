namespace Company.Application.DTO
{
    public class ChangeStatusDTO
    {
        public int ProjectId { get; set; }

        public string NewStatus { get; set; }

        public string EmailEmployee { get; set; }
    }
}
