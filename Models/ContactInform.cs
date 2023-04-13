using System;

namespace BD9.Models
{
    public class ContactInform
    {
        public int Id { get; set; }

        public int? EmploeeId { get; set; }//для 1 к 1 связь
        public Emploee? Emploee { get; set; } 
        
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public long? Phone { get; set; }
        public long? PSeries { get; set; }
        public long? PNumber { get; set; }
        public long? Snils { get; set; }
        public string? Adress { get; set; }
        public DateTime? Date { get; set; }

    }
}
