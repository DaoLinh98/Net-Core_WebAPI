using NetCore_API.Entity;

namespace NetCore_API.Model
{
    public class DepartmentRequest
    {
        public string? Depart_Name { get; set; }

    }

    public class DepartmentRespone
    {
        public int Depart_Id { get; set; }
        public string? Depart_Name { get; set; }
        public List<UserRespone> Users { get; set; }
    }
}
