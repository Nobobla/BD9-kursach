using System.Collections.Generic;

namespace BD9.Models
{
    public class Complaint
    {
        public int id { get; set; }

        public string Discription { get; set; }
        public string ComplaintType { get; set; }
        public List<Order> Orders { get; set; }
    }
}
