using System.ComponentModel.DataAnnotations;

namespace PressTheButtonAPI.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Scenario> MyScenarios { get; set; } = new List<Scenario>();
        public List<FavoriteScenarioUser> Favorites { get; set; } = new List<FavoriteScenarioUser>();
        public List<HistoryScenarioUser> History { get; set; } = new List<HistoryScenarioUser>();

    }
}
