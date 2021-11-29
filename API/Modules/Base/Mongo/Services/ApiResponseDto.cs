namespace API.Modules.Base.Services
{
    public class ApiResponseDto
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
}