using PressTheButtonAPI.Entities;

namespace PressTheButtonAPI.Interfaces
{
    public interface IScenarioRepository
    {
        public Task<Scenario> CreateScenarioRepository(Guid ownerId, string GoodOutcome, string BadOutcome);
        public Task<Scenario> GetScenarioRepository(int currentId);
        public Task<int> GetARandomIdRepository(int previousId);       
        public Task<Tuple<int,List<Scenario>>> GetAlotScenariosRepository(Guid userId,string category, int page);
        public Task<Scenario> UpdateScenarioRepository(int scenarioId, string? updateGoodOutcome, string? updateBadOutcome);
        public Task<Scenario> DeleteScenarioRepository(int scenarioId);
        public Task<Scenario> UpdatePlayedCount(int scenarioId, bool isPressed);
    }
}
