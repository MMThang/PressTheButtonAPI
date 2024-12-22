using Microsoft.EntityFrameworkCore;
using PressTheButtonAPI.Data;
using PressTheButtonAPI.Entities;
using PressTheButtonAPI.Interfaces;

namespace PressTheButtonAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext db;
        private readonly IJwtRepository jwt;
        public UserRepository(AppDbContext context, IJwtRepository jwt)
        {
            db = context;
            this.jwt = jwt;
        }

        public async Task<User> CreateUserRepository(string name, string password, string recheckPassword)
        {          
            try 
            {
                if(name.Length < 6)
                {
                    throw new Exception("Account minimum 6 characters");
                }
                if (password.Length < 6 || recheckPassword.Length <=6)
                {
                    throw new Exception("Password minimum 6 characters");
                }
                
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, 11);
                bool checkedUser = db.Users.Any(user => user.Name == name);
                if (checkedUser == false)
                {
                    if(password == recheckPassword)
                    {
                        User user = new User() { Name = name, Password = hashedPassword };
                        await db.Users.AddAsync(user);
                        await db.SaveChangesAsync();
                        return user;
                    } else
                    {
                        throw new Exception("Password don't match");
                    }
                } else
                {
                    throw new Exception("User already existed");                   
                }
            } 
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> LoginUserRepository(string name, string password)
        {
            try
            {                

                    User existedUser = await db.Users.FirstOrDefaultAsync(f => f.Name == name);
                
                if (existedUser != null)
                {
                    bool checkPassword = BCrypt.Net.BCrypt.Verify(password, existedUser.Password);
                    if(checkPassword == true)
                    {
                        
                        string token = jwt.GenerateJwtToken(existedUser);
                        return token;
                    }
                    else
                    {
                        throw new Exception("Wrong password");
                    }
                    
                }
                else
                {
                    throw new Exception("User does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CheckTokenRepository(string token)
        {
            try { 
                var verified = jwt.CheckToken(token);
                if (verified == true)
                {
                    return true;
                } else
                {
                    return false; //Không được xóa else
                }
            } catch(Exception ex)
            {
                return false;
            }   
           
            
        }

        public async Task<User> GetUserRepository(Guid id)
        {           
            try
            {

                var user = await db.Users.FirstAsync(f => f.Id == id);
                if (user != null)
                {                 
                    return user;
                } else { 
                    throw new Exception("User does not existed"); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<User> DeleteUserRepository(Guid id)
        {
            try
            {
                var user = await db.Users.FindAsync(id);
                if (user != null)
                {

                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return user;
                }
                else
                {
                    throw new Exception("User does not existed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FavoriteScenarioUser> LikeScenarioRepository(Guid userId, int scenarioId)
        {
            try
            {
                var user = await db.Users.FindAsync(userId);
                if (user == null)
                {
                    throw new Exception("User does not existed");
                }
                var scenario = await db.Scenarios.FindAsync(scenarioId);
                if (scenario == null)
                {
                    throw new Exception("Scenario does not existed");
                }
                var checkExisted = await db.FavoriteScenarioUsers.FindAsync(userId, scenarioId);
                if (checkExisted != null)
                {
                    throw new Exception("Already existed");
                }
                FavoriteScenarioUser FavObj = new FavoriteScenarioUser { userId = userId, scenarioId = scenarioId };
                
                await db.FavoriteScenarioUsers.AddAsync(FavObj);
                await db.SaveChangesAsync();

                return FavObj;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IsScenarioLikeRepository(Guid userId, int scenarioId)
        {
            try
            {
                if (userId != null)
                {
                    var isFavScenarioExisted = await db.FavoriteScenarioUsers.FindAsync(userId, scenarioId);
                    if (isFavScenarioExisted != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FavoriteScenarioUser> DeleteFavoriteScenarioUserRepository(Guid userId, int scenarioId)
        {
            try
            {
                var FavObj = await db.FavoriteScenarioUsers.FindAsync(userId, scenarioId);
                if (FavObj != null)
                {
                    db.FavoriteScenarioUsers.Remove(FavObj);
                    await db.SaveChangesAsync();
                    return FavObj;
                }else
                {
                    throw new Exception("Fav scenario not existed");
                }
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<HistoryScenarioUser> HistoryScenarioRepository(Guid userId, int scenarioId)
        {
            try
            {
                var user = await db.Users.FindAsync(userId);
                if (user == null)
                {
                    throw new Exception("User does not existed");
                }
                var scenario = await db.Scenarios.FindAsync(scenarioId);
                if (scenario == null)
                {
                    throw new Exception("Scenario does not existed");
                }
                var historyScenarioUser = await db.HistoryScenarioUsers.FindAsync(userId, scenarioId);
                if (historyScenarioUser != null)
                {
                    throw new Exception("Duplicate database");
                }
                var scenarios = await db.HistoryScenarioUsers.Where(w => w.userId == userId).ToListAsync();
                HistoryScenarioUser HistoryObj = new HistoryScenarioUser { userId = userId, scenarioId = scenarioId };
                if (scenarios.Count() <= 10)
                {
                    
                    await db.HistoryScenarioUsers.AddAsync(HistoryObj);
                    await db.SaveChangesAsync();
                } else
                {
                    db.HistoryScenarioUsers.Remove(scenarios[0]);
                    await db.HistoryScenarioUsers.AddAsync(HistoryObj);
                    db.SaveChangesAsync();
                }
                return HistoryObj;
                
                                              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
