namespace NetCore_API.Model
{
    public class UserRepuest
    {
        public string User_Name { get; set; }
        public string Number_Phone { get; set; }
        public DateTime DateOfbirth { get; set; }
        public int Depart_Id { get; set; }
    }

    public class UserRespone
    {
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string Number_Phone { get; set; }
        public DateTime DateOfbirth { get; set; }
        public int? Depart_Id { get; set; }

    }

    public class UserVM
    {
        public string Number_Phone { get; set; }
        public DateTime DateOfbirth { get; set; }
        public int? Depart_Id { get; set; }
    }
}
