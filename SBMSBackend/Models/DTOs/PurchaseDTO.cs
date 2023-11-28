
namespace SBMSBackend.Models.DTOs
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public double PurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime PurchaseModificationDate { get; set; }
        public string Comments { get; set; }
        public int SupplierId { get; set; }
        public IList<PurchaseDetailsDTO> PurchaseDetailsDto { get; set; }
    }
}
