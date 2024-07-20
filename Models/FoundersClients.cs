using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public class FoundersClients
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int FounderId { get; set; }
    }
}
