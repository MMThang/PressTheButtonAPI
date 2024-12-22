using System.ComponentModel.DataAnnotations.Schema;

namespace PressTheButtonAPI.Entities
{
    public class FavoriteScenarioUser
    {
        [ForeignKey("User")]
        public Guid userId { get; set; }
        [NotMapped]
        public User user { get; set; }
        [ForeignKey("Scenario")]
        public int scenarioId { get; set; }
        [NotMapped]
        public Scenario scenario { get; set; } 
    }
}
