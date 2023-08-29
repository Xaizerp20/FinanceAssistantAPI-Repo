using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceAssistantAPI.Models
{
    public class ApplicationFinancialRecordDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }             // Identificador único del gasto
        public string Description { get; set; } // Descripción del gasto

        [Required]
        public decimal Amount { get; set; }     // Monto del gasto

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ApplicationCategory ApplicationCategory { get; set; }

        public DateTime Date { get; set; }      // Fecha del gasto

        public string UserId { get; set; }      // Identificador del usuario que registró el gasto

        [ForeignKey("UserId")]
        public virtual ApplicationUser UserAplication { get; set; } // Propiedad de navegación al usuario



    }
}
