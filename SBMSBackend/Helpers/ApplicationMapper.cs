using AutoMapper;
using SBMS.Models.EntityModels;
using SBMSBackend.Models.DTOs;

namespace SBMSBackend.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Purchase, PurchaseDTO>().ReverseMap();
            CreateMap<PurchaseDetails,PurchaseDetailsDTO>().ReverseMap();
        }
    }
}
