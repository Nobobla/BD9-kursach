using System.Collections.Generic;

namespace BD9.Models
{
    public class Emploee
    {
        public int id { get; set; }
        public int? ContactId { get; set; }
        public string Name { get; set; }
        public ContactInform? ContactInform { get; set; }
        public int? JobId { get; set; }//внешний ключ для работы
        public Job? Job { get; set; }

        public int? OfficeId { get; set; }//внешний ключ для офиса
        public Office? Office { get; set; }

        public List<Order> Orders { get; set; } = new();
        public Emploee() {
            Name = "1111111";
        }
    }
}
