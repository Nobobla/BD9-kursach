using System;

namespace BD9.Models
{
    public class Order
    {
        public int id { get; set; }

        public int? ServiceId { get; set; }//внешний ключ1
        public Service? Service { get; set; }

        public string? Warranty { get; set; }

        public int? EmploeeId { get; set; }//внешний ключ2
        public Emploee? Emp { get; set; }

        public int? ClientId { get; set; }//внешний ключ3
        public Client? Client { get; set; }

        public string? Description { get; set; }
        public DateTime? DateIssue { get; set; }

        public int? ComplaintId { get; set; }
        public Complaint Complaints { get; set; }

        public string? UserId { get; set; }//внешний ключ для пользователя
        public User? User { get; set; }
    }
}
