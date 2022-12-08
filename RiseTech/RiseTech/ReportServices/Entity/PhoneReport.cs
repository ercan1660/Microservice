using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportServices.Entity
{
    public class PhoneReport
    {
        [Key ]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UUID { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
