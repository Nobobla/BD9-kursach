using System.Collections.Generic;

namespace BD9.Models
{
    public class Job
    {
        public int id { get; set; }
        public string? JobName { get; set; }
        public List<Emploee> Emploees { get; set; } = new();
    }
}
