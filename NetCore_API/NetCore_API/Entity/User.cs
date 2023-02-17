using System.ComponentModel.DataAnnotations;

namespace NetCore_API.Entity
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        [Required]
        public string User_Name { get; set; }
        [Required]
        public string Number_Phone { get; set; }
        public DateTime DateOfbirth { get; set; } 

        //Relationship
        public int? Depart_Id { get; set; }
        public virtual Department Department { get; set; }

        public List<Assignment> Assignments { get; set; }
  
    }

    public class UserViewModel
    {
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string Number_Phone { get; set; }
        public DateTime DateOfbirth { get; set; }

        //Relationship
        public int Depart_Id { get; set; }
    }
}
