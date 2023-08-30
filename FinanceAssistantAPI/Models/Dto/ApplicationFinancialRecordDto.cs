using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceAssistantAPI.Models.Dto
{
    public class ApplicationFinancialRecordDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string CategoryName { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
    }
}
