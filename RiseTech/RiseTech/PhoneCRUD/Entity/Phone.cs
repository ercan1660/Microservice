using System.ComponentModel.DataAnnotations;

namespace PhoneCRUD.Entity
{
    public class Phone
    {
        [Key]
        public int UUID { get; set; }

        [MaxLength(50)]
        [Required]
        public string UserName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(80)]
        public string Company { get; set; }

        [MaxLength(80)]
        public string PhoneNumber { get; set; }



    }
}
