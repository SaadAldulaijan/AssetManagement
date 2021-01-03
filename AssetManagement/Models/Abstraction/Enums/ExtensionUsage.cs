using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models.Abstraction.Enums
{
    public enum ExtensionUsage
    {
        [Display(Name = "End User")]
        EndUser,
        [Display(Name = "System Use")]
        SystemUse,
        [Display(Name = "Pilot Number")]
        PilotNumber,
        Available,
        [Display(Name = "Hunt Group")]
        HuntGroup
    }
}
