using NetCore_API.Entity;
using NetCore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.TestAPI.MockData
{
    public class MockData
    {
        public static List<DepartmentRespone> getDeparts()
        {
            return new List<DepartmentRespone> {
                new DepartmentRespone()
                {
                    Depart_Id  =1,
                    Depart_Name = "abc",
                    Users = null
    },
                new DepartmentRespone()
                {
                    Depart_Id  =2,
                    Depart_Name = "abc",
                    Users = null
                }
            };
        }
        public static List<AssetResponseAll> GetAssets()
        {
            return new List<AssetResponseAll>{
             new AssetResponseAll{
                 Asset_Id = 1,
                 Asset_Name = "Keyboard",
             },
             new AssetResponseAll{
                 Asset_Id = 2,
                 Asset_Name = "Ram",
             },
             new AssetResponseAll{
                 Asset_Id = 3,
                 Asset_Name = "CPU",
             },
         };
        }

   public static List<UserRespone> GetUsers()
        {
            return new List<UserRespone>
            {
                new UserRespone
                {
                    User_Id= 1,
                    User_Name="asd",
                    DateOfbirth= DateTime.Now,
                    Number_Phone= "123",
                    Depart_Id= 1,
                },
                new UserRespone
                {
                    User_Id= 2,
                    User_Name="asd",
                    DateOfbirth= DateTime.Now,
                    Number_Phone= "123",
                    Depart_Id= 2,
                },

            };
        }
        public static List<UserRespone> GetEmptyUser()
        {
            return null;
        }

        public static List<AssetResponseAll> GetEmptyAssets()
        {
            return null;
        }

    }
}
