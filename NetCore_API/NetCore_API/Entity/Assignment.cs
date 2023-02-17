namespace NetCore_API.Entity
{
    public class Assignment
    {
        public int Asset_Id { get; set; }
        public int User_Id { get; set; }
        public string Status { get; set; }
        //Relationship
        public User User { get; set; }
        public Asset Asset { get; set; }
    }


}
