using System.ComponentModel.DataAnnotations;

namespace NetCore_API.Entity
{
    public class Asset
    {
        [Key]
        public int Asset_Id { get; set; }
        [Required]
        public string Asset_Name { get; set; }
        //Relationship
        public List<Assignment>? Assignments { get; set; }
       
    }
}
