using System.Collections.Generic;

namespace BD9.Models
{
   public class Client
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; } // имя пользователя
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public long? Phone { get; set; }

        public List<Client> Clients { get; set; } = new();
    }
}
