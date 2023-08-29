using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceAssistantAPI.Models
{
    public class ApplicationCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }         // Identificador único de la categoría
        public string Name { get; set; }            // Nombre de la categoría (por ejemplo, "Alimentos", "Transporte", etc.)
        public string Description { get; set; }     // Descripción de la categoría
                                                
    }
}
