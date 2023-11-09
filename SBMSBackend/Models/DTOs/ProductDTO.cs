namespace SBMSBackend.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
