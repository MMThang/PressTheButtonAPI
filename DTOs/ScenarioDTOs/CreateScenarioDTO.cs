namespace PressTheButtonAPI.DTOs.ScenarioDTOs
{
    public class CreateScenarioDTO
    {
        public Guid OwnerId { get; set; }
        public string GoodOutcome { get; set; }
        public string BadOutcome  { get; set; }
    }
}
