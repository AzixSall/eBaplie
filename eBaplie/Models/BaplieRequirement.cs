namespace eBaplie.Models
{
    public class BaplieRequirement
    {
        public BaplieRequirement()
        {
            BapliesNavigation = new HashSet<EdifactGlobal>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? RequireContainerSize { get; set; }
        public bool? RequireContainerNumber { get; set; }
        public bool? RequireContainerType { get; set; }
        public bool? RequireVesselVoyagNumber { get; set; }
        public bool? RequirePackagingDetails { get; set; }
        public bool? RequireConsigneeDetails { get; set; }

        public virtual ICollection<EdifactGlobal>? BapliesNavigation { get; set; }

    }
}
