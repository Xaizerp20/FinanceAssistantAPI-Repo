﻿namespace FinanceAssistantAPI.Models.Dto
{
    public class ApplicationFinancialRecordCreateDTO
    { 
            public string Description { get; set; }
            public decimal Amount { get; set; }
            public int CategoryId { get; set; }
            public DateTime Date { get; set; }
            public string UserId { get; set; }
        
    }
}
