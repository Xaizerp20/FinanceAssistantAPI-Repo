using FinanceAssistantAPI.Models;

namespace FinanceAssistantAPI.Repository.IRepository
{
    public interface IUserRepository: IRepository<ApplicationUser> 
    {
        Task<ApplicationUser> Update(ApplicationUser entity);
    }
}
