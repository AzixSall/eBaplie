using eBaplie.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace eBaplie.Models
{
    public class EdiChangeLog
    {
        public int Id { get; set; }

        [Display(Name = "Edifact")]
        public int EdifactId { get; set; }

        [Display(Name = "Change Type")]
        public ChangeType ChangeType { get; set; }

        [Display(Name = "Old Value")]
        public string? OldValue { get; set; }

        [Display(Name = "New Value")]
        public string? NewValue { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdated { get; set; }


        [Display(Name = "EDI")]
        public virtual EdifactGlobal? EdifactNavigation { get; set; }
    }
}
