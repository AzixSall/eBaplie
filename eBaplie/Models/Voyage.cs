using System.ComponentModel.DataAnnotations;

namespace eBaplie.Models
{
    public class Voyage
    {
        public Voyage()
        {
            Baplies = new HashSet<EdifactGlobal>();
        }

        public int Id { get; set; }

        [Display(Name = "Voyage Number")]
        public string? VoygeNumber { get; set; }

        [Display(Name = "Vessel")]
        public int? VesselId { get; set; }

        [Display(Name = "BAPLIE File")]
        public byte[]? BaplieFile { get; set; }

        [Display(Name = "Requirement")]
        public int? RequirementId { get; set; }

        [Display(Name = "Vessel")]
        public virtual Vessel? VesselNavigation { get; set; }

        [Display(Name = "Requirement")]
        public virtual BaplieRequirement? BaplieRequirementNavigation { get; set; }

        public virtual ICollection<EdifactGlobal>? Baplies { get; set; }
    }
}
