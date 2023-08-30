using FinanceAssistantAPI.Data;
using FinanceAssistantAPI.Models;
using FinanceAssistantAPI.Repository.IRepository;

namespace FinanceAssistantAPI.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<ApplicationUser> Update(ApplicationUser entity)
        {
            _contextDb.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
