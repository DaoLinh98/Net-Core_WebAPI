using NetCore_API.Entity;
using System.ComponentModel.DataAnnotations;

namespace NetCore_API.Model

{
    public class AssetRequest
    {
        public string Asset_Name { get; set; }
        //Relationship
    
    }


public class AssetRespone
    {
     
        public int Asset_Id { get; set; }
        public string Asset_Name { get; set; }
        public List<UserRespone> userVMs { get; set; } = new List<UserRespone>();
      
    }
}
