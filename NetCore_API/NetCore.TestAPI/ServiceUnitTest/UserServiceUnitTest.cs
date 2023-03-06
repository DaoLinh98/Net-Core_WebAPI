using Moq;
using NetCore_API.Model;
using NetCore_API.Repository;
using NetCore_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.TestAPI.ServiceUnitTest
{
    public class UserServiceUnitTest
    {
        [Fact]
        public void getAll_ReturnList()
        {

            // Arrange
            var expected = MockData.MockData.GetUsers();
            var repo = new Mock<IUserRepository>();
            repo.Setup(_ => _.getAll()).Returns(expected);
            var sut = new UserService(repo.Object);
            // Act
            var actual = sut.getAll();
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void getAll_ReturnEmpty()
        {
            // Arrange
            List<UserRespone> expected = null;
            var repo = new Mock<IUserRepository>();
            repo.Setup(_ => _.getAll()).Returns(expected);
            var sut = new UserService(repo.Object);
            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.getAll()); //run mothod real at service
            Assert.Equal("List Item is null", ex.Message); //compare result Expected.

        }

        [Fact]
        public void add_value_null()
        {
            UserRepuest userRepuest = null;
            //var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            //repo.Setup(_ => _.get()).Returns(expected);
            var sut = new UserService(repo.Object);
            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.add(userRepuest));
            Assert.Equal("User incorrect!", ex.Message);

        }
        [Fact]
        public void add_assetName_already()
        {
            UserRepuest user = new UserRepuest()
            {

                User_Name = "asd",
                Number_Phone = "0123",
                DateOfbirth = DateTime.Now,
                Depart_Id = 1
            };
            // Arrange
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            //
            int? a = 1;
            // a is result expect in repo
            repo.Setup(_ => _.getByUserName(user.User_Name)).Returns(a); // Expect return in a.
            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.add(user)); //run mothod real at service
            Assert.Equal("Asset Name allredy!", ex.Message); //compare result Expected.

        }

        [Fact]
        public void add_value_valid()
        {
            // Arrange
            UserRepuest user = new UserRepuest()
            {
                User_Name = "asd",
                Number_Phone = "0123",
                DateOfbirth = DateTime.Now,
                Depart_Id = 1
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            //
            int? a = null;
            // a is result expect in repo
            repo.Setup(_ => _.getByUserName(user.User_Name)).Returns(a); // Expect return in a.
            // Act
            var actual = sut.add(user);
            // Assert
            Assert.Equal("Done", actual); //compare result Expected.

        }

        [Fact]
        public void getById_return_null()
        {
            // Arrange
            UserRespone user = null; 
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(user); // Expect return in a.
            // Act /Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.getById(id)); //run mothod real at service
            Assert.Equal("User does not exist!", ex.Message); //compare result Expected.

        }
        [Fact]
        public void getById_return_userValid()
        {
            // Arrange
            UserRespone user = new UserRespone()
            {
                User_Id= 1,
                User_Name = "asd",
                Number_Phone = "0123",
                DateOfbirth = DateTime.Now,
                Depart_Id = 1
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(user); // Expect return in a.
            // Act
            var actual = sut.getById(id);
            // Act /Assert
            Assert.Equal(actual,user); //compare result Expected.

        }

        [Fact]
        public void deleteById_return_exception()
        {
            // Arrange
            UserRespone user = null;
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            // a is result expect in repo
            int id = 1;
             repo.Setup(_ => _.getById(id)).Returns(user); // Expect return in a.
            // Act /Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.deleteById(id)); //run mothod real at service
            Assert.Equal("User does not exit!", ex.Message); //compare result Expected.
        }
        [Fact]
        public void deleteById_success()
        {
            // Arrange
            UserRespone user = new UserRespone()
            {
                User_Id = 1,
                User_Name = "asd",
                Number_Phone = "0123",
                DateOfbirth = DateTime.Now,
                Depart_Id = 1
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            //
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(user); // Expect return in a.

            // Act
            var actual = sut.deleteById(id);
            // Act /Assert
            Assert.Equal("Done",actual); //compare result Expected.
        }
        [Fact]
        public void updateById_value_null_return_exception()
        {
            // Arrange
            UserRespone user = null;
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            //
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(user); // Expect return in a.
            // Act /Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.updateById(id,user)); //run mothod real at service
            Assert.Equal("User does not exist!", ex.Message); //compare result Expected.
        }
        [Fact]
        public void updateById_success()
        {
            // Arrange
            UserRespone user = new UserRespone()
            {
                User_Id = 1,
                User_Name = "asd",
                Number_Phone = "0123",
                DateOfbirth = DateTime.Now,
                Depart_Id = 1
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            // a is result expect in repo
            int id = 1;
            repo.Setup(_ => _.getById(id)).Returns(user); // Expect return in a.
            // Act
            var actual = sut.updateById(id, user);
            // Act /Assert
            Assert.Equal("Done", actual); //compare result Expected.
        }
        [Fact]
        public void updateById_id_notMacth()
        {
            // Arrange
            UserRespone user = new UserRespone()
            {
                User_Id = 1,
                User_Name = "asd",
                Number_Phone = "0123",
                DateOfbirth = DateTime.Now,
                Depart_Id = 1
            };
            // mock
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            //
            // a is result expect in repo
            int id = 2;
            repo.Setup(_ => _.getById(id)).Returns(user); // Expect return in a.
            // Act /Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.updateById(id, user)); //run mothod real at service
            Assert.Equal("Update incorrect!", ex.Message); //compare result Expected.
        }

        [Fact]
        public void paging_return_exception_pageIndex()
        {
            // Arrange
            UserRespone user = new UserRespone()
            {
                User_Id = 1,
                User_Name = "asd",
                Number_Phone = "0123",
                DateOfbirth = DateTime.Now,
                Depart_Id = 1
            };
            // mock
            int pageIndex = -1;
            int pageSize = 1;
            string sortBy = "User_Id";
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            // a is result expect in repo
            int id = 1;
            // Act /Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.pagingAndSorting(pageIndex, pageSize, sortBy)); //run mothod real at service
            Assert.Equal("Page index incorect!", ex.Message); //compare result Expected.
        }

        [Fact]
        public void paging_return_exception_pageSize()
        {
            // Arrange
            // Arrange
            UserRespone user = new UserRespone()
            {
                User_Id = 1,
                User_Name = "asd",
                Number_Phone = "0123",
                DateOfbirth = DateTime.Now,
                Depart_Id = 1
            };
            // mock
            int pageIndex = 1;
            int pageSize = -1;
            string sortBy = "User_Id";
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            // a is result expect in repo
            int id = 1;
            // Act /Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.pagingAndSorting(pageIndex, pageSize, sortBy)); //run mothod real at service
            Assert.Equal("Page size incorrect!", ex.Message); //compare result Expected.
        }

        [Fact]
        public void paging_return_users()
        {
            // Arrange
            var users = MockData.MockData.GetUsers();
            // mock
            int pageIndex = 1;
            int pageSize = 1;
            string sortBy = "User_Id";
            var expected = MockData.MockData.GetAssets();
            var repo = new Mock<IUserRepository>();
            var sut = new UserService(repo.Object);
            repo.Setup(_ => _.pagingAndSorting(pageIndex,pageSize,sortBy)).Returns(users); // Expect return in a.
            // Act
            var actual = sut.pagingAndSorting(pageIndex, pageSize, sortBy);
            // Act /Assert
            Assert.Equal(users, actual); //compare result Expected.
        }


    }

}
