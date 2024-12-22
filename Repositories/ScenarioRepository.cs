using Microsoft.EntityFrameworkCore;
using PressTheButtonAPI.Data;
using PressTheButtonAPI.Entities;
using PressTheButtonAPI.Interfaces;

namespace PressTheButtonAPI.Repositories
{
    public class ScenarioRepository : IScenarioRepository
    {

        private readonly AppDbContext db;
        public ScenarioRepository(AppDbContext context)
        { 
            db = context; 
        }
        public async Task<Scenario> CreateScenarioRepository(Guid ownerId, string goodOutcome, string badOutcome)
        {
            try
            {
                var checkUser = await db.Users.FindAsync(ownerId);
                if(checkUser == null)
                {
                    throw new Exception("User does not existed");
                }
                
                Scenario scenario = new Scenario() { ScenarioOwnerId = ownerId, GoodOutcome = goodOutcome, BadOutcome = badOutcome };
                var addedScenario = await db.Scenarios.AddAsync(scenario);
                await db.SaveChangesAsync();
                
                if (addedScenario != null)
                {                                      
                    return scenario;
                }
                else
                {
                    throw new Exception("Create scenario failed");
                }                              
            } 
            catch (Exception ex) 
            {
                throw new Exception("scenario failed" + ex.Message);
            }
        }

        public async Task<Scenario> GetScenarioRepository(int currentId)
        {
            try
            {
                Scenario scenario = await db.Scenarios.FindAsync(currentId);
                if (scenario == null)
                {
                    throw new Exception("scenario not found");
                }
                else
                {
                    return scenario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("scenario failed" + ex.Message);
            }

        }

        public async Task<int> GetARandomIdRepository(int currentId)
        {
            try
            {
                int maxId = db.Scenarios.Max(x => x.Id);
                int minId = db.Scenarios.Min(x => x.Id);
                Scenario scenario;
                Random rand = new Random();
                int randomId;
                
                do
                {
                    randomId = rand.Next(minId, (maxId + 1));
                    scenario = await db.Scenarios.FindAsync(randomId);

                } while (randomId == currentId || scenario == null);

                return randomId;
            }
            catch (Exception ex)
            {
                throw new Exception("scenario failed" + ex.Message);
            }
        }

        public async Task<Tuple<int, List<Scenario>>> GetAlotScenariosRepository(Guid userId,string category, int page)
        {
            try
            {
                int limit = 10;
                List<Scenario> scenarios = new List<Scenario>();
                int scenariosCount;
                switch (category)
                {
                    case "your":
                        scenarios = await db.Users.Where(p => p.Id == userId).SelectMany(p => p.MyScenarios).Skip((page - 1) * limit).Take(limit).ToListAsync();
                        scenariosCount = db.Users.Where(p => p.Id == userId).SelectMany(p => p.MyScenarios).Count();
                        break;
                    case "favorite":
                        scenarios = await db.FavoriteScenarioUsers.Where(w => w.userId == userId).Select(scenario => new Scenario { 
                            Id = scenario.scenarioId, 
                            GoodOutcome = scenario.scenario.GoodOutcome, 
                            BadOutcome = scenario.scenario.BadOutcome 
                        })
                        .Skip((page - 1) * limit)
                        .Take(limit)
                        .ToListAsync();
                        scenariosCount = db.FavoriteScenarioUsers.Where(w => w.userId == userId).Count();
                        break;
                    case "history":
                        scenarios = await db.HistoryScenarioUsers.Where(w => w.userId == userId).Select(scenario => new Scenario
                        {
                            Id = scenario.scenarioId,
                            GoodOutcome = scenario.scenario.GoodOutcome,
                            BadOutcome = scenario.scenario.BadOutcome
                        })                        
                        .ToListAsync();
                        scenariosCount = 10;
                        break;
                    default:
                        throw new Exception("Cannot get scenarios");
                        
                }
                if (scenarios != null)
                {
                   
                    return new Tuple<int,List<Scenario>>((int)Math.Ceiling((double)scenariosCount / (double)limit), scenarios);
                   
                }
                else
                {
                    throw new Exception("No scenario found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("scenario failed" + ex.Message);
            }
        }

        public async Task<Scenario> UpdateScenarioRepository(int scenarioId, string? updateGoodOutcome, string? updateBadOutcome)
        {
            try
            {

                var scenario = await db.Scenarios.FindAsync(scenarioId);
                if (scenario != null)
                {
                    if(updateGoodOutcome != null)
                    {
                        scenario.GoodOutcome = updateGoodOutcome;
                    }
                    if(updateBadOutcome != null)
                    {
                        scenario.BadOutcome = updateBadOutcome;
                    }
                    await db.SaveChangesAsync();
                    return scenario;
                }
                else
                {
                    throw new Exception("No scenario found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("scenario failed" + ex.Message);
            }
        }

        public async Task<Scenario> DeleteScenarioRepository(int scenarioId)
        {
            try
            {
                var scenario = await db.Scenarios.FindAsync(scenarioId);
                db.Scenarios.Remove(scenario);
                await db.SaveChangesAsync();
                return scenario;
            }
            catch (Exception ex)
            {
                throw new Exception("scenario failed " + ex.Message);
            }
        }

        public async Task<Scenario> UpdatePlayedCount(int scenarioId, bool isPressed)
        {
            try
            {

                var scenario = await db.Scenarios.FindAsync(scenarioId);
                if (scenario != null)
                {
                    if(isPressed == true)
                    {
                        scenario.PressedCount++;
                        await db.SaveChangesAsync();
                        return scenario;
                    } else
                    {
                        scenario.DeniedCount++;
                        await db.SaveChangesAsync();
                        return scenario;
                    }
                }
                else
                {
                    throw new Exception("No scenario found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("scenario failed" + ex.Message);
            }
        }
    }
}
