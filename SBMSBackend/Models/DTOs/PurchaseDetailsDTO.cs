
namespace SBMSBackend.Models.DTOs
{
    public class PurchaseDetailsDTO
    {
        public int Id { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public double NewMRP { get; set; }
        public string Remarks { get; set; }
        public int ProductId { get; set; }
        public int PurchaseId { get; set; }
    }
}
