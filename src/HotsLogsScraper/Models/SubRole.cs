using System.ComponentModel.DataAnnotations;

namespace HotsLogsScraper.Models
{
    public enum SubRole
    {
        [Display(Name = "Unknown SubRole")]
        Unknown,
        [Display(Name = "Tank")]
        Tank,
        [Display(Name = "Bruiser")]
        Bruiser,
        [Display(Name = "Healer")]
        Healer,
        [Display(Name = "Support")]
        Support,
        [Display(Name = "Ambusher")]
        Ambusher,
        [Display(Name = "Burst Damage")]
        BurstDamage,
        [Display(Name = "Sustained Damage")]
        SustainedDamage,
        [Display(Name = "Siege")]
        Siege,
        [Display(Name = "Utility")]
        Utility
    }
}