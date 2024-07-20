using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public class Founder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FIO { get; set; }
        public int INN { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public List<FoundersClients> FounderClients { get; set; } = new List<FoundersClients>();

    }
}
