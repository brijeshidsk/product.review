using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFullWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public Decimal UnitPrice { get; set; }
        public string Brand { get; set; }
        public string SellerName { get; set; }
        public string SellerContact { get; set; }
        public string SellerEmail { get; set; }
        public string Description { get; set; }
        public Int16 UnitsInStock { get; set; }
        public string Image { get; set; }
        public int NumReviews { get; set; }
        public int Rating { get; set; }
        public List<Review>? Reviews { get; set; }


    }
}
