using EFRepositoryUoW.Core.IRepositories;
using EFRepositoryUoW.Data;
using EFRepositoryUoW.Models;
using Microsoft.EntityFrameworkCore;

namespace EFRepositoryUoW.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ILogger _logger;

        public UserRepository(
            ApplicationDbContext context,
            ILogger logger) : base(context, logger) 
        {
            _logger = logger;
        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error ", typeof(UserRepository));
                return new List<User>();
            }
        }

        public override async Task<bool> Upsert(User entity)
        {
            try
            {
                var existingUser = await _dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error ", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

                if(exist != null)
                {
                    _dbSet.Remove(exist);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error ", typeof(UserRepository));
                return false;
            }
        }
    }
}
