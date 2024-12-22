namespace PressTheButtonAPI.DTOs.ScenarioDTOs
{
    public class UpdateScenarioDTO
    {
        public int scenarioId {  get; set; }
        public string? GoodOutcome { get; set; }
        public string? BadOutcome { get; set; }
    }
}
