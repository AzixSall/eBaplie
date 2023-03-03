namespace eBaplie.Models
{
    public class Vessel
    {
        public Vessel()
        {
            VoyagesNavigation = new HashSet<Voyage>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Image { get; set; }

        public virtual ICollection<Voyage>? VoyagesNavigation { get; set; }
    }
}
