using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFullWebAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public Employee? Employee { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}

