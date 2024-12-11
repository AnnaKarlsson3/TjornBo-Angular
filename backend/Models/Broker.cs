


namespace backend.Models{

        public class Broker{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Navigation property for Houses
        public House? House { get; set; }
    }


}