using System.ComponentModel.DataAnnotations;

namespace NetCore_API.Entity
{
    public class Department
    {
        [Key]
        public int Depart_Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(100)]
        public string Depart_Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
