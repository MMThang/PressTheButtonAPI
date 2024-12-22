using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace PressTheButtonAPI.Entities
{
    public class Scenario
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public Guid ScenarioOwnerId { get; set; }        
        public User ScenarioOwner { get; set; } = null!;
        [NotMapped]
        [IgnoreDataMember]
        public List<HistoryScenarioUser> HistoryUsers { get; set; } = new List<HistoryScenarioUser>();
        [NotMapped]
        [IgnoreDataMember]
        public List<FavoriteScenarioUser> FavoriteUsers { get; set; } = new List<FavoriteScenarioUser>();
        [Required]
        public string GoodOutcome { get; set; } = null!;
        [Required]
        public string BadOutcome { get; set; } = null!;
        public int PressedCount { get; set; } = 0;
        public int DeniedCount { get; set; } = 0;
        public DateTime PostDate { get; set; } = DateTime.UtcNow;
    }
}
