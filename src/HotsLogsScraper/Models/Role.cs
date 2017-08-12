using System.ComponentModel.DataAnnotations;

namespace HotsLogsScraper.Models
{
    public enum Role
    {
        [Display(Name = "Unknown Role")]
        Unknown,
        [Display(Name = "Warrior")]
        Warrior,
        [Display(Name = "Assassin")]
        Assassin,
        [Display(Name = "Support")]
        Support,
        [Display(Name = "Specialist")]
        Specialist
    }
}