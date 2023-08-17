using System.ComponentModel.DataAnnotations;

namespace RestFullWebAPI.Models.DTO
{
    public class ReviewParam
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
