using FinanceAssistantAPI.Data;
using FinanceAssistantAPI.Models;
using FinanceAssistantAPI.Repository.IRepository;

namespace FinanceAssistantAPI.Repository
{
    public class FinancialRecordRepository : Repository<ApplicationFinancialRecord>, IFinancialRecordRepository
    {
        public FinancialRecordRepository(ApplicationDbContext contextDB) : base(contextDB)
        {

        }
    }
}
