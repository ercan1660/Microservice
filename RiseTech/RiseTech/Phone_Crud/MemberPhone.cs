using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Crud
{
    public class MemberPhone
    {
        [Key]
        public int UUID { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(150)]
        public string Company { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(80)]
        public string Location { get; set; }





    }
}
