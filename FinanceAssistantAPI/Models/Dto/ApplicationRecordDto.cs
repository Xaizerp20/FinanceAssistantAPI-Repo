using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceAssistantAPI.Models.Dto
{
    public class ApplicationFinancialRecordDto
    {
        public int Id { get; set; }             // Identificador único del gasto
        public string Description { get; set; } // Descripción del gasto

        [Required]
        public decimal Amount { get; set; }     // Monto del gasto
        public DateTime Date { get; set; }      // Fecha del gasto
        public string CategoryName { get; set; } // Nombre de la categoría del gasto
        public string UserName { get; set; }    // Nombre del usuario que realizó el gasto
    }
}
