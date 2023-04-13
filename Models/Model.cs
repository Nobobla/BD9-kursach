using System.Collections.Generic;

namespace BD9.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string? Manufacture { get; set; }
        public string? ModelName { get; set; }
        public List<ServiceModel> serviceModels { get; set; } = new();
        
    }
}
