using NetCore_API.Entity;

namespace NetCore_API.Model
{
    public class AssignmentModel
    {
        public int Asset_Id { get; set; }
        public int User_Id { get; set; }
        public User? User { get; set; }
        public Asset? asset { get; set; } 
    }

}
