using Microsoft.AspNetCore.Mvc;
using PressTheButtonAPI.Entities;

namespace PressTheButtonAPI.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> CreateUserRepository(string name, string password, string recheckPassword);
        public Task<string> LoginUserRepository(string name, string password);
        public Task<bool> CheckTokenRepository(string token);
        public Task<User> GetUserRepository(Guid id);
        public Task<User> DeleteUserRepository(Guid id);
        public Task<FavoriteScenarioUser> LikeScenarioRepository(Guid userId, int scenarioId);
        public Task<bool> IsScenarioLikeRepository(Guid userId, int scenarioId);
        public Task<FavoriteScenarioUser> DeleteFavoriteScenarioUserRepository(Guid userId, int scenarioId);
        public Task<HistoryScenarioUser> HistoryScenarioRepository(Guid userId, int scenarioId);
    }
}
