using MultiTool.Models;

namespace Pr.Repositories
{
    public interface IUserRepository
    {
        public Task<IUser> FetchUser(string id);
        public Task AddUser(string id);
    }
    public class UserRepository : IUserRepository
    {
        public Task AddUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IUser> FetchUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
