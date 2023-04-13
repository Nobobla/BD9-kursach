using System.Collections.Generic;

namespace BD9.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string? Adress { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public List<Emploee> Emploees { get; set; } = new();
    }
}
