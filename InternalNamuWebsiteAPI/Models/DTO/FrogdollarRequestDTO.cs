using System;
namespace InternalNamuWebsiteAPI.Models.DTO
{
    public class FrogdollarRequestDTO
    {
        public FrogdollarRequestDTO()
        {
        }

        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
