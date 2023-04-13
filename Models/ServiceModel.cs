namespace BD9.Models
{
    public class ServiceModel
    {
        public int id { get; set; }
        public Model model { get; set; }
        public int ModelId { get; set; }
        public Service Services { get; set; }
        public int ServiseId { get; set; }

        public string Note { get; set; }
        public string Discription { get; set; }
    }
}
