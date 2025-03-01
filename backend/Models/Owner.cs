


namespace backend.Models{
    public class Owner{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IDNumber { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;

        // Many-to-many relationship with Houses
        public ICollection<House> Houses { get; set; } = new List<House>();
    }

}