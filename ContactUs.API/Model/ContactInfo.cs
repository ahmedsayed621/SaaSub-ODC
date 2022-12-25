using ContactUs.API.Data;

namespace ContactUs.API.Model
{
    public class ContactInfo :BaseEntity
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
     
    }
}
