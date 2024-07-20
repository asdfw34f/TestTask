using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName ="varchar(12)")]
        public string INN { get; set; }
        public bool isLE { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public List<FoundersClients> FoundersClient { get; set; } = new List<FoundersClients>();
    }
}
