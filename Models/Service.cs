using System.Collections.Generic;

namespace BD9.Models
{
    public class Service
    {
        public int id { get; set; }
        public string? ServiceName { get; set; }
        public List<ServiceModel> serviceModels { get; set; }
        public List<Order> Orders { get; set; }
        public decimal Price { get; set; }
    }
}
