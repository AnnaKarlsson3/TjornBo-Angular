


namespace backend.Models{

    public class Address{
        public int Id { get; set; } 
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int PostalCode { get; set; }

        // Navigation property for House
        public House? House { get; set; }
    }




}