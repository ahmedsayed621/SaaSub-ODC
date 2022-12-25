namespace ContactUs.API.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
}
