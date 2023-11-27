using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.EntityModels
{
    public class Purchase
    {   
        public int Id { get; set; }
        public double PurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime PurchaseModificationDate { get; set; }
        public string Comments { get; set; }
        public IList<PurchaseDetails> PurchaseDetails { get; set; }

    }
}
